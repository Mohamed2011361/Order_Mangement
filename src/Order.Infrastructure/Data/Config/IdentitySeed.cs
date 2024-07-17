using Microsoft.AspNetCore.Identity;
using Order.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.Data.Config
{
    public class IdentitySeed
    {
        public static async Task seedUserAsync(UserManager<AppUser> userManager)
        {
             if (!userManager.Users.Any())
            {
                //create new user
                var user = new AppUser
                {
                    DisplayName = "Ali",
                    UserName = "Ali@yahoo.com",
                    Email = "Ali@yahoo.com",
                    Address = new Address
                    {
                        FirstName="ali",
                        LastName="mohamed",
                        Street="Shoubra",
                        City="Cairo",
                        State="haram",
                        ZipCode="123"
                    }
                };
               await userManager.CreateAsync(user,"Mm@198555");
                
                
            }
            
        }
    }
}
