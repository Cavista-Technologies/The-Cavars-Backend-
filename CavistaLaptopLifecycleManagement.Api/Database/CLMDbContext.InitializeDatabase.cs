using CavistaLaptopLifecycleManagement.Api.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CavistaLaptopLifecycleManagement.Api.Database
{
    public partial class CLMDbContext
    {
        public void InitializeDatabase()
        {
            this.Database.EnsureCreated();

            // Look for any students.
            if (this.Users.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
                new User
                {
                    Auth0UserId = "1",
                    FirstName = "Alice",
                    LastName = "Smith",
                    EmailAddress = "AliceSmith@example.com",
                    MiddleName = "Md",
                    IsActive = true,
                    LastLogin = DateTime.Parse("2026-08-23").ToUniversalTime(),
                    Roles = "",
                    Created_At = DateTime.Parse("2026-08-23").ToUniversalTime(),
                    Modified = DateTime.Parse("2026-08-23").ToUniversalTime(),
                },
                new User
                {
                    Auth0UserId = "2",
                    FirstName = "Bob",
                    LastName = "Alexander",
                    EmailAddress = "BobSmith@example.com",
                    MiddleName = "KC",
                    IsActive = true,
                    LastLogin = DateTime.Parse("2026-08-23").ToUniversalTime(),
                    Roles = "",
                    Created_At = DateTime.Parse("2026-08-23").ToUniversalTime(),
                    Modified = DateTime.Parse("2026-08-23").ToUniversalTime()
                },
            };

            foreach (User user in users)
            {
                this.Users.Add(user);
            }
            this.SaveChanges();

            var userLaptops = new UserLaptop[]
            {
                new UserLaptop
                {
                    UserID = users[0].Id,
                    AssetName ="Chemistry",
                    Model = "Hp3113",
                    Comment = "Super fast",
                    AssetLocation = "Lagos, Nigeria",
                    EmployeeDepartment = "Engineering",
                    Condition = UserLaptopCondition.Active,
                    Price = 1000000,
                    EstimationUsefulLifeYear = DateTime.Parse("2026-08-23").ToUniversalTime(),
                    DepreciationEstimationDate = DateTime.Parse("2026-08-23").ToUniversalTime(),
                    WarrantyExpirationDate = DateTime.Parse("2026-08-23").ToUniversalTime(),
                    PurchaseYear = DateTime.Parse("2026-08-23").ToUniversalTime(),
                    Created_At = DateTime.Parse("2026-08-23").ToUniversalTime(),
                    Modified = DateTime.Parse("2026-08-23").ToUniversalTime(),
                },
                new UserLaptop
                {
                    UserID = users[1].Id,
                    AssetName ="Chemistry",
                    Model = "Hp3113",
                    Comment = "Super fast",
                    AssetLocation = "Lagos, Nigeria",
                    EmployeeDepartment = "Engineering",
                    Condition = UserLaptopCondition.Active,
                    Price = 1000000,
                    EstimationUsefulLifeYear = DateTime.Parse("2026-08-23").ToUniversalTime(),
                    DepreciationEstimationDate = DateTime.Parse("2026-08-23").ToUniversalTime(),
                    WarrantyExpirationDate = DateTime.Parse("2026-08-23").ToUniversalTime(),
                    PurchaseYear = DateTime.Parse("2026-08-23").ToUniversalTime(),
                    Created_At = DateTime.Parse("2026-08-23").ToUniversalTime(),
                    Modified = DateTime.Parse("2026-08-23").ToUniversalTime(),
                }
            };

            foreach (UserLaptop userLaptop in userLaptops)
            {
                this.UserLaptops.Add(userLaptop);
            }
            this.SaveChanges();

            //var enrollments = new Enrollment[]
            //{
            //new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
            //new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
            //new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
            //new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
            //new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},
            //new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F},
            //new Enrollment{StudentID=3,CourseID=1050},
            //new Enrollment{StudentID=4,CourseID=1050},
            //new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
            //new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
            //new Enrollment{StudentID=6,CourseID=1045},
            //new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A},
            //};
            //foreach (Enrollment e in enrollments)
            //{
            //    context.Enrollments.Add(e);
            //}
            //context.SaveChanges();
        }
    }
}
