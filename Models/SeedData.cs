﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcSoaps.Data;
using System;
using System.Linq;
using System.Collections.Generic;
using MvcSoaps.Models;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcSoapContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcSoapContext>>()))
            {
                // Look for any movies.
                if (context.Soaps.Any())
                {
                    return;   // DB has been seeded
                }

                context.Soaps.AddRange(
                    new soap
                    {
                        Title = "Cool Fresh",
                        Company = "Detol",
                        ReleaseDate = DateTime.Parse("1920-2-12"),
                        Type = "Anti-becterial",
                        Colour = "Blue",
                        Price = 7.99M
                    },

                    new soap
                    {
                        Title = "Mint",
                        Company = "Celvin Klein",
                        ReleaseDate = DateTime.Parse("1989-7-17"),
                        Type = "Freshner",
                        Colour = "Yellow",
                        Price = 25M
                    },

                    new soap
                    {
                        Title = "Special",
                        Company = "Wild Stone",
                        ReleaseDate = DateTime.Parse("2003-9-7"),
                        Type = "Spicy",
                        Colour = "Black",
                        Price = 100M
                    },

                    new soap
                    {
                        Title = "Mornak",
                        Company = "Old Spice",
                        ReleaseDate = DateTime.Parse("2013-9-27"),
                        Type = "Fruity",
                        Colour = "Purple",
                        Price = 20M
                    },

                    new soap
                    {
                        Title = "Into the night",
                        Company = "Bath and body",
                        ReleaseDate = DateTime.Parse("2007-10-28"),
                        Type = "Smooth",
                        Colour = "White",
                        Price = 40M
                    },

                    new soap
                    {
                        Title = "Kitanu",
                        Company = "Life Boy",
                        ReleaseDate = DateTime.Parse("2017-5-4"),
                        Type = "Anti-becterial",
                        Colour = "Red",
                        Price = 17M
                    },

                    new soap
                    {
                        Title = "Limdo",
                        Company = "Patanjali",
                        ReleaseDate = DateTime.Parse("2015-6-14"),
                        Type = "Organic",
                        Colour = "Green",
                        Price = 56M
                    },

                    new soap
                    {
                        Title = "Wine",
                        Company = "Dr Squach",
                        ReleaseDate = DateTime.Parse("2012-2-5"),
                        Type = "Organic",
                        Colour = "Brown",
                        Price = 30M
                    },

                    new soap
                    {
                        Title = "Siquance",
                        Company = "Zara",
                        ReleaseDate = DateTime.Parse("1999-6-16"),
                        Type = "Luxury",
                        Colour = "Silver",
                        Price = 180M
                    },

                    new soap
                    {
                        Title = "Guilty",
                        Company = "Gucci",
                        ReleaseDate = DateTime.Parse("2000-9-17"),
                        Type = "Rich",
                        Colour = "Golden",
                        Price = 170M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}