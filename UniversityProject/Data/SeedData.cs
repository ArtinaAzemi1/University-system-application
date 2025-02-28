using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace UniversityProject.Data
{
    public class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, RoleManager<IdentityRole> roleManager)
        {
            Console.WriteLine("Seeding roles...");

            string[] roleNames = { "Admin", "Professor", "Student" };
            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    var role = new IdentityRole
                    {
                        Name = roleName,
                        NormalizedName = roleName.ToUpper()
                    };
                    await roleManager.CreateAsync(role);
                    Console.WriteLine($"Role {roleName} created.");
                }
                else
                {
                    Console.WriteLine($"Role {roleName} already exists.");
                }
            }
        }
    }
}
