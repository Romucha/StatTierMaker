﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StatTierMaker.API.Tiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatTierMaker.Db
{
    public class TierDbContext : DbContext
    {
        private readonly IConfiguration configuration;

        public DbSet<TierList> TierLists { get; set; }

        public DbSet<Tier> Tiers { get; set; }

        public DbSet<TierEntity> TierEntities { get; set; }

        public DbSet<TierParameter> TierParameters { get; set; }

        public TierDbContext(IConfiguration configuration, DbContextOptions options) : base(options)
        {
            this.configuration = configuration;
            Database.EnsureCreated();
            if (Database.IsRelational())
            {
                Database.Migrate();
            }

        }
    }
}
