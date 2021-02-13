﻿using DatingAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DatingAPI.Data
{
    public class Seed
    {
        public static async Task SeedUsers(DataContext context)
        {
            try
            {
                if (await context.Users.AnyAsync()) return;

                var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
                var users = JsonSerializer.Deserialize<List<AppUser>>(userData);
                foreach (var user in users)
                {
                    using var hmac = new HMACSHA512();
                    user.Username = user.Username.ToLower();
                    user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("p@55w0rd"));
                    user.PasswordSalt = hmac.Key;

                    context.Users.Add(user);
                }

                await context.SaveChangesAsync();
            }
            catch(Exception) { }
        }
    }
}
