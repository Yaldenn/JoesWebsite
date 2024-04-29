using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RZAWeb.Data;
using RZAWeb.Models;
using System;
using System.Linq;

namespace RZAWeb;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RZAWebContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<RZAWebContext>>()))
        {

            if (context.Rewards.Any())
            {
                return;   // DB has been seeded
            }

            // Adding in four example rewards
            context.Rewards.AddRange(
                new Rewards
                {
                    Id = "1",
                    RewardName = "One adult day ticket for the zoo",
                    RewardDescription = "A free day ticket to the zoo for one person",
                    RewardImage = "~/Images/Giraffe.jpg",
                    RewardPoints = 200,
                },
                new Rewards
                {
                    Id = "2",
                    RewardName = "One night stay at our luxury hotel",
                    RewardDescription = "A free one night stay at our luxury hotel, including an en suite bathroom, a view across the zoo and access to our swimming pool.",
                    RewardImage = "~/Images/Giraffe.jpg",
                    RewardPoints = 500,
                },
                new Rewards
                {
                    Id = "3",
                    RewardName = "Free animal snacks",
                    RewardDescription = "Get a free bag of snacks to feed to the animals, this can be nuts for the monkeys, leaves for the giraffes or fruit for the elephants.",
                    RewardImage = "~/Images/Giraffe.jpg",
                    RewardPoints = 50,
                },
                new Rewards
                {
                    Id = "4",
                    RewardName = "Free merchandise",
                    RewardDescription = "Choose one of our items of clothing we offer at our gift shop",
                    RewardImage = "~/Images/Giraffe.jpg",
                    RewardPoints = 100,
                }
            );
            context.SaveChanges();

        }
    }
}