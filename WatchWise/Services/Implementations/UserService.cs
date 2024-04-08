using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WatchWise.DTOs.Converters;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Models;
using WatchWise.Models.CrossTables;
using WatchWise.Repositories.Implementations;
using WatchWise.Repositories.Interfaces;
using WatchWise.Services.Interfaces;

namespace WatchWise.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _usersRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly IUserFavoriteRepository _userFavoriteRepository;
        private readonly IUserWatchedEpisodeRepository _userWatchedEpisodeRepository;
        private readonly WatchWiseUserConverter _userConverter;
        private readonly MediaConverter _mediaConverter;
        private readonly SignInManager<WatchWiseUser> _signInManager;
        private readonly IRoleService _roleService;

        public UserService(IUserRepository usersRepository, IMediaRepository mediaRepository
            , WatchWiseUserConverter userConverter, IUserFavoriteRepository userFavoriteRepository
            , IUserWatchedEpisodeRepository userWatchedEpisodeRepository, MediaConverter mediaConverter
            , SignInManager<WatchWiseUser> signInManager, IRoleService roleService)
        {
            _usersRepository = usersRepository;
            _mediaRepository = mediaRepository;
            _userFavoriteRepository = userFavoriteRepository;
            _userWatchedEpisodeRepository = userWatchedEpisodeRepository;
            _userConverter = userConverter;
            _mediaConverter = mediaConverter;
            _signInManager = signInManager;
            _roleService = roleService;
        }

        public List<WatchWiseUserResponse> GetAllUsersResponses(bool includePassive, bool includePlans, bool includeWatchedEpisodes, bool includeFavorites)
        {
            IQueryable<WatchWiseUser> users = _usersRepository.GetAllUsers(includePlans, includeWatchedEpisodes, includeFavorites);
            if (includePassive == false)
            {
                users = users.Where(u => u.Passive == false);
            }
            return _userConverter.Convert(users.AsNoTracking().ToList());
        }

        public WatchWiseUserResponse? GetWatchWiseUserResponseById(long id, bool includePlans, bool includeWatchedEpisodes, bool includeFavorites)
        {
            WatchWiseUser? foundWatchWiseUser = _usersRepository.GetUserById(id, includePlans, includeWatchedEpisodes, includeFavorites);
            if (foundWatchWiseUser != null)
            {
                return _userConverter.Convert(foundWatchWiseUser);
            }
            return null;
        }

        public IdentityResult PostUser(WatchWiseUserRequest watchWiseUserRequest)
        {
            WatchWiseUser newUser = _userConverter.Convert(watchWiseUserRequest);
            IdentityResult addResult = _usersRepository.AddUser(newUser, watchWiseUserRequest.Password);
            if (addResult.Succeeded)
            {
                _roleService.AddRole(newUser,"Guest");
                return addResult;
            }
            return addResult;
        }

        public int DeleteUser(long id)
        {
            WatchWiseUser? foundWatchWiseUser = _usersRepository.GetUserById(id);
            if (foundWatchWiseUser != null)
            {
                if (_roleService.IsInRole(foundWatchWiseUser, "Admin"))
                {
                    return 0;
                }
                foundWatchWiseUser.Passive = true;
                _usersRepository.UpdateUser(foundWatchWiseUser);
                _roleService.RemoveAllRolesFromUser(foundWatchWiseUser);
                return 1;
            }
            return -1;
        }

        public int UpdateUser(long id, WatchWiseUserUpdateRequest watchWiseUserUpdateRequest)
        {
            WatchWiseUser? existingUser = _usersRepository.GetUserById(id);
            if (existingUser != null)
            {
                if (watchWiseUserUpdateRequest.PhoneNumber != null)
                {
                    existingUser.PhoneNumber = watchWiseUserUpdateRequest.PhoneNumber;
                }
                if (watchWiseUserUpdateRequest.UserName != null)
                {
                    existingUser.UserName = watchWiseUserUpdateRequest.UserName;
                }
                if (watchWiseUserUpdateRequest.Email != null)
                {
                    existingUser.Email = watchWiseUserUpdateRequest.Email;
                }
                _usersRepository.UpdateUser(existingUser);
                return 1;
            }
            return -1;
        }

        public SignInResult LogIn(LogInRequest logInRequest)
        {
            string userName = logInRequest.UserName;
            string password = logInRequest.Password;
            WatchWiseUser? watchWiseUser = _usersRepository.GetUserByUserName(userName, includePlans: true, includeWatchedEpisodes: true, includeFavorites: true);
            if (watchWiseUser == null)
            {
                return SignInResult.NotAllowed;
            }
            if (watchWiseUser.UserPlans?.Where(u => u.EndDate >= DateTime.Today).Any() == false)
            {
                _roleService.RemoveRole(watchWiseUser, "Subscriber");
            } else
            {
                if (_roleService.IsInRole(watchWiseUser, "Subscriber"))
                {
                    _roleService.AddRole(watchWiseUser, "Subscriber");
                }
            }
            return _signInManager.PasswordSignInAsync(watchWiseUser, password, false, false).Result;
        }

        public void LogOut()
        {
            _signInManager.SignOutAsync().Wait();
        }

        public List<WatchWiseRole> GetAllRoles()
        {
            return _roleService.GetAllRoles();
        }

        public List<MediaResponse> GetSuggestedMedias(long userId)
        {
            WatchWiseUser watchWiseUser = _usersRepository.GetUserById(userId, includeWatchedEpisodes: true, includeFavorites: true)!;
            IQueryable<Media> suggestedMediaQuery = _mediaRepository.GetAllMedia(includeMediaGenres: true, includeMediaRestrictions: true);
            IQueryable<UserFavorite>? userFavorites = _userFavoriteRepository.GetUserFavoritesByUserId(userId).Include(uf => uf.Media).ThenInclude(m => m!.MediaGenres);
            if (userFavorites != null && userFavorites.Any())
            {
                IGrouping<short, MediaGenre>? mediaGenres = userFavorites
                    .SelectMany(uf => uf.Media!.MediaGenres!)
                    .GroupBy(m => m.GenreId)
                    .AsEnumerable()
                    .OrderByDescending(group => group.Count())
                    .FirstOrDefault();
                if (mediaGenres != null)
                {
                    short mostFrequentGenreId = mediaGenres.Key;
                    suggestedMediaQuery = suggestedMediaQuery.Where(m => m.MediaGenres!.Any(mg => mg.GenreId == mostFrequentGenreId));
                    if (watchWiseUser.UserWatchedEpisodes != null && watchWiseUser.UserWatchedEpisodes.Count > 0)
                    {
                        List<int> watchedMediaIds = _userWatchedEpisodeRepository.GetUserWatchedEpisodesByUserId(userId)
                            .Include(uwe => uwe.Episode)
                            .Select(uwe => uwe.Episode!.MediaId)
                            .ToList();
                        suggestedMediaQuery = suggestedMediaQuery.Where(m => !watchedMediaIds.Contains(m.Id));
                    }
                }
            }
            int age = CalculateCurrentAge(watchWiseUser.BirthDate);
            suggestedMediaQuery = suggestedMediaQuery.Where(m => !m.MediaRestrictions!.Any(mr => mr.RestrictionId >= age));
            return _mediaConverter.Convert(suggestedMediaQuery.ToList());
        }

        private int CalculateCurrentAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }

    }
}

