using Microsoft.CodeAnalysis.Differencing;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Models;

namespace WatchWise.DTOs.Converters
{
    public class WatchWiseUserConverter
    {
        public WatchWiseUser Convert(WatchWiseUserRequest watchWiseUserRequest)
        {
            WatchWiseUser newWatchWiseUser = new()
            {
                UserName = watchWiseUserRequest.UserName,
                Name = watchWiseUserRequest.Name,
                Email = watchWiseUserRequest.Email,
                PhoneNumber = watchWiseUserRequest.PhoneNumber,
                BirthDate = watchWiseUserRequest.BirthDate,
                Passive = false
            };
            return newWatchWiseUser;
        }

        public WatchWiseUserResponse Convert(WatchWiseUser watchWiseUser)
        {
            WatchWiseUserResponse newWatchWiseUserResponse = new()
            {
                Id = watchWiseUser.Id,
                UserName = watchWiseUser.UserName!,
                Name = watchWiseUser.Name,
                Email = watchWiseUser.Email!,
                PhoneNumber = watchWiseUser.PhoneNumber!,
                BirthDate = watchWiseUser.BirthDate,
                Passive = watchWiseUser.Passive
            };
            if (watchWiseUser.UserPlans != null)
            {
                newWatchWiseUserResponse.PlanIds = watchWiseUser.UserPlans.Select(up => up.PlanId).ToList();
            }
            if (watchWiseUser.UserFavorites != null)
            {
                newWatchWiseUserResponse.FavoriteMediaIds = watchWiseUser.UserFavorites.Select(uf => uf.MediaId).ToList();
            }
            if (watchWiseUser.UserWatchedEpisodes != null)
            {
                newWatchWiseUserResponse.WatchedEpisodeIds = watchWiseUser.UserWatchedEpisodes.Select(up => up.EpisodeId).ToList();
            }
            return newWatchWiseUserResponse;
        }

        public List<WatchWiseUserResponse> Convert(List<WatchWiseUser> watchWiseUsers)
        {
            List<WatchWiseUserResponse> userResponses = new();
            foreach(WatchWiseUser user in watchWiseUsers)
            {
                userResponses.Add(Convert(user));
            }
            return userResponses;
        }

    }
}

