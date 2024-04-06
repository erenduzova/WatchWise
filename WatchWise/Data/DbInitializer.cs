using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WatchWise.Models;

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
                Name = "WatchWiseAdmin",
                UserName = "WatchWiseAdmin",
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
            string[] genreNames = {"Action", "Adventure", "Animation", "Comedy", "Crime", "Documentary", "Drama", "Fantasy", "Horror", "Mystery", "Romance", "Science Fiction", "Thriller"};
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
    }
}
