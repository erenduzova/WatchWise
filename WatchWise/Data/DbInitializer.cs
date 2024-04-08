using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WatchWise.Models;
using WatchWise.Models.CrossTables;

namespace WatchWise.Data
{
    public class DbInitializer
    {
        private readonly WatchWiseContext _watchWiseContext;
        private readonly UserManager<WatchWiseUser> _userManager;
        private readonly RoleManager<WatchWiseRole> _roleManager;

        public DbInitializer(WatchWiseContext watchWiseContext, UserManager<WatchWiseUser> userManager, RoleManager<WatchWiseRole> roleManager)
        {
            _watchWiseContext = watchWiseContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            _watchWiseContext.Database.Migrate();
            if (!_watchWiseContext.Roles.Any())
            {
                CreateRoles();
            }
            if (!_watchWiseContext.Users.Any())
            {
                CreateAdminUser();
                CreateContentManagerUser();
                CreateUserManagerUser();
                CreateRestrictionManagerUser();
            }
            if (!_watchWiseContext.Genres.Any())
            {
                CreateGenres();
            }
            if (!_watchWiseContext.Plans.Any())
            {
                CreatePlans();
            }
            if (!_watchWiseContext.Restrictions.Any())
            {
                CreateRestrictions();
            }
            if (!_watchWiseContext.Stars.Any())
            {
                CreateStars();
            }
            if (!_watchWiseContext.Directors.Any())
            {
                CreateDirectors();
            }
            if (!_watchWiseContext.Medias.Any())
            {
                CreateMedia();
            }
            if (!_watchWiseContext.Episodes.Any())
            {
                CreateEpisodes();
            }
        }

        public void CreateRoles()
        {
            string[] roleNames = { "Admin", "ContentManager", "UserManager", "Subscriber", "Guest", "RestrictionManager" };
            foreach (string roleName in roleNames)
            {
                bool roleExists = _roleManager.RoleExistsAsync(roleName).Result;
                if (!roleExists)
                {
                    WatchWiseRole newRole = new(roleName);
                    _roleManager.CreateAsync(newRole).Wait();
                }
            }
        }

        public void CreateAdminUser()
        {
            WatchWiseUser adminUser = new()
            {
                Name = "Admin",
                UserName = "Admin",
                Email = "watchwiseadmin@gmail.com",
                PhoneNumber = "11111111111",
                BirthDate = new DateTime(1996, 12, 12),
                Passive = false
            };
            string adminPassword = "Admin123!";
            _userManager.CreateAsync(adminUser, adminPassword).Wait();
            _userManager.AddToRoleAsync(adminUser, "Admin").Wait();
        }

        public void CreateContentManagerUser()
        {
            WatchWiseUser contentManagerUser = new()
            {
                Name = "ContentManager",
                UserName = "ContentManager",
                Email = "contentmanager@gmail.com",
                PhoneNumber = "11111111112",
                BirthDate = new DateTime(1990, 1, 1),
                Passive = false
            };
            string contentManagerPassword = "Content123!";
            _userManager.CreateAsync(contentManagerUser, contentManagerPassword).Wait();
            _userManager.AddToRoleAsync(contentManagerUser, "ContentManager").Wait();
        }

        public void CreateUserManagerUser()
        {
            WatchWiseUser userManagerUser = new()
            {
                Name = "UserManager",
                UserName = "UserManager",
                Email = "usermanager@gmail.com",
                PhoneNumber = "11111111113",
                BirthDate = new DateTime(1990, 1, 1),
                Passive = false
            };
            string userManagerPassword = "User123!";
            _userManager.CreateAsync(userManagerUser, userManagerPassword).Wait();
            _userManager.AddToRoleAsync(userManagerUser, "UserManager").Wait();
        }

        public void CreateRestrictionManagerUser()
        {
            WatchWiseUser restrictionManagerUser = new()
            {
                Name = "RestrictionManager",
                UserName = "RestrictionManager",
                Email = "restrictionmanager@gmail.com",
                PhoneNumber = "11111111114",
                BirthDate = new DateTime(1990, 1, 1),
                Passive = false
            };
            string restrictionManagerPassword = "Restriction123!";
            _userManager.CreateAsync(restrictionManagerUser, restrictionManagerPassword).Wait();
            _userManager.AddToRoleAsync(restrictionManagerUser, "RestrictionManager").Wait();
        }

        public void CreateGenres()
        {
            string[] genreNames = { "Action", "Adventure", "Animation", "Comedy", "Crime", "Documentary", "Drama", "Fantasy", "Horror", "Mystery", "Romance", "Science Fiction", "Thriller" };
            foreach (string name in genreNames)
            {
                Genre genre = new() { Name = name };
                _watchWiseContext.Genres.Add(genre);
            }
            _watchWiseContext.SaveChanges();
        }

        public void CreatePlans()
        {
            _watchWiseContext.Plans.Add(new Plan() { Name = "Basic", Price = 119.99f, MaxResolution = "720p" });
            _watchWiseContext.Plans.Add(new Plan() { Name = "Standard", Price = 176.99f, MaxResolution = "1080p" });
            _watchWiseContext.Plans.Add(new Plan() { Name = "Premium", Price = 119.99f, MaxResolution = "4K" });
            _watchWiseContext.SaveChanges();
        }

        public void CreateRestrictions()
        {
            _watchWiseContext.Restrictions.Add(new Restriction() { Id = 0, Name = "General Audience" });
            _watchWiseContext.Restrictions.Add(new Restriction() { Id = 7, Name = "7 and older" });
            _watchWiseContext.Restrictions.Add(new Restriction() { Id = 13, Name = "13 and older" });
            _watchWiseContext.Restrictions.Add(new Restriction() { Id = 18, Name = "18 and older" });
            _watchWiseContext.SaveChanges();
        }

        public void CreateStars()
        {
            string[] starNames = { "David Tennant", "Freema Agyeman", "Carey Mulligan", "Harold Perrineau", "Eion Bailey", "Scott McCord" };
            foreach (string name in starNames)
            {
                Star star = new() { Name = name };
                _watchWiseContext.Stars.Add(star);
            }
            _watchWiseContext.SaveChanges();
        }

        public void CreateDirectors()
        {
            string[] directorNames = { "Hettie Macdonald", "Colin Teague", "Graeme Harper", "Jack Bender" };
            foreach (string name in directorNames)
            {
                Director director = new() { Name = name };
                _watchWiseContext.Directors.Add(director);
            }
            _watchWiseContext.SaveChanges();
        }

        public void CreateMedia()
        {
            // Retrieve or create Star instances
            Star star1 = _watchWiseContext.Stars.FirstOrDefault(s => s.Name == "David Tennant")!;
            Star star2 = _watchWiseContext.Stars.FirstOrDefault(s => s.Name == "Freema Agyeman")!;
            Star star3 = _watchWiseContext.Stars.FirstOrDefault(s => s.Name == "Carey Mulligan")!;

            // Retrieve or create Director instances
            Director director1 = _watchWiseContext.Directors.FirstOrDefault(d => d.Name == "Hettie Macdonald")!;
            Director director2 = _watchWiseContext.Directors.FirstOrDefault(d => d.Name == "Colin Teague")!;
            Director director3 = _watchWiseContext.Directors.FirstOrDefault(d => d.Name == "Graeme Harper")!;

            // Retrieve or create Genre instances
            Genre genre1 = _watchWiseContext.Genres.FirstOrDefault(g => g.Name == "Adventure")!;
            Genre genre2 = _watchWiseContext.Genres.FirstOrDefault(g => g.Name == "Drama")!;
            Genre genre3 = _watchWiseContext.Genres.FirstOrDefault(g => g.Name == "Science Fiction")!;

            // Retrieve or create Restriction instance
            Restriction restriction1 = _watchWiseContext.Restrictions.FirstOrDefault(r => r.Name == "General Audience")!;

            Media media1 = new()
            {
                Name = "Doctor Who",
                Description = "The further adventures in time and space of the alien adventurer known as the Doctor and his companions from planet Earth.",
                ImdbRating = 8.6f,
                Passive = false,
                MediaStars = new List<MediaStar>
                {
                    new MediaStar { Star = star1 },
                    new MediaStar { Star = star2 },
                    new MediaStar { Star = star3 }
                },
                MediaDirectors = new List<MediaDirector>
                {
                    new MediaDirector { Director = director1 },
                    new MediaDirector { Director = director2 },
                    new MediaDirector { Director = director3 }
                },
                MediaGenres = new List<MediaGenre>
                {
                    new MediaGenre { Genre = genre1 },
                    new MediaGenre { Genre = genre2 },
                    new MediaGenre { Genre = genre3 }
                },
                MediaRestrictions = new List<MediaRestriction>
                {
                    new MediaRestriction { Restriction = restriction1 }
                }
            };
            _watchWiseContext.Medias.Add(media1);

            // Retrieve or create Star instances for media2
            Star star4 = _watchWiseContext.Stars.FirstOrDefault(s => s.Name == "Harold Perrineau")!;
            Star star5 = _watchWiseContext.Stars.FirstOrDefault(s => s.Name == "Eion Bailey")!;
            Star star6 = _watchWiseContext.Stars.FirstOrDefault(s => s.Name == "Scott McCord")!;

            // Retrieve or create Director instances for media2
            Director director4 = _watchWiseContext.Directors.FirstOrDefault(d => d.Name == "Jack Bender")!;

            // Retrieve or create Genre instances for media2
            Genre genre4 = _watchWiseContext.Genres.FirstOrDefault(g => g.Name == "Drama")!;
            Genre genre5 = _watchWiseContext.Genres.FirstOrDefault(g => g.Name == "Horror")!;
            Genre genre6 = _watchWiseContext.Genres.FirstOrDefault(g => g.Name == "Mystery")!;

            // Retrieve or create Restriction instance for media2
            Restriction restriction2 = _watchWiseContext.Restrictions.FirstOrDefault(r => r.Name == "18 and older")!;

            Media media2 = new()
            {
                Name = "From",
                Description = "Unravel the mystery of a city in middle U.S.A. that imprisons everyone who enters." +
                " As the residents struggle to maintain a sense of normality and seek a way out," +
                " they must also survive the threats of the surrounding forest.",
                ImdbRating = 7.7f,
                Passive = false,
                MediaStars = new List<MediaStar>
                {
                    new MediaStar { Star = star4 },
                    new MediaStar { Star = star5 },
                    new MediaStar { Star = star6 }
                },
                MediaDirectors = new List<MediaDirector>
                {
                    new MediaDirector { Director = director4 }
                },
                MediaGenres = new List<MediaGenre>
                {
                    new MediaGenre { Genre = genre4 },
                    new MediaGenre { Genre = genre5 },
                    new MediaGenre { Genre = genre6 }
                },
                MediaRestrictions = new List<MediaRestriction>
                {
                    new MediaRestriction { Restriction = restriction2 }
                }
            };
            _watchWiseContext.Medias.Add(media2);

            _watchWiseContext.SaveChanges();
        }

        public void CreateEpisodes()
        {
            Media doctorWhoM = _watchWiseContext.Medias.FirstOrDefault(m => m.Name == "Doctor Who")!;
            Media fromM = _watchWiseContext.Medias.FirstOrDefault(m => m.Name == "From")!;

            Episode doctorWhoM3x10 = new()
            {
                MediaId = doctorWhoM.Id,
                SeasonNum = 3,
                EpisodeNum = 10,
                ReleaseDate = new DateTime(2007, 6, 9),
                Title = "Blink",
                Description = "Sally Sparrow receives a cryptic message from the Doctor about a mysterious new enemy species that is after the TARDIS.",
                Duration = TimeSpan.FromMinutes(45),
                ViewCount = 0,
                Passive = false
            };
            _watchWiseContext.Episodes.Add(doctorWhoM3x10);

            Episode doctorWhoM3x13 = new()
            {
                MediaId = doctorWhoM.Id,
                SeasonNum = 3,
                EpisodeNum = 13,
                ReleaseDate = new DateTime(2007, 6, 30),
                Title = "Last of the Time Lords",
                Description = "It's been a year since The Master unleashed the mysterious Toclafane onto Earth." +
                " With the human race and The Doctor enslaved under The Master's control, Martha Jones is the only person that can help stop the evil Time Lord.",
                Duration = TimeSpan.FromMinutes(50),
                ViewCount = 0,
                Passive = false
            };
            _watchWiseContext.Episodes.Add(doctorWhoM3x13);

            Episode fromM1x1 = new()
            {
                MediaId = fromM.Id,
                SeasonNum = 1,
                EpisodeNum = 1,
                ReleaseDate = new DateTime(2022, 2, 20),
                Title = "Long Day's Journey Into Night",
                Description = "The Matthews' family road trip takes a horrifying turn when they are detoured to a small town from which they cannot leave." +
                " When their family RV crashes, Sheriff Boyd Stevens and other residents rush to save them before the sun goes down.",
                Duration = TimeSpan.FromMinutes(52),
                ViewCount = 0,
                Passive = false
            };
            _watchWiseContext.Episodes.Add(fromM1x1);

            _watchWiseContext.SaveChanges();
        }

    }
}
