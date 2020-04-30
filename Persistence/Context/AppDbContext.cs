using Microsoft.EntityFrameworkCore;
using sm_coding_challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sm_coding_challenge.Persistence.Context
{
    public class AppDbContext:DbContext
    {
        public DbSet<DataResponseModel> Games { get; set; }

        public DbSet<RushingModel> Rushers { get; set; }
        public DbSet<PassingModel> Passers { get; set; }
        public DbSet<ReceivingModel> Receivers { get; set; }
        public DbSet<KickingModel> Kickers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<DataResponseModel>().ToTable("Games");
            builder.Entity<DataResponseModel>().HasKey(p => p.TimeStamp);
            builder.Entity<DataResponseModel>().Property(p => p.Week).IsRequired();
            builder.Entity<DataResponseModel>().Property(p => p.Week).IsRequired();
            builder.Entity<DataResponseModel>().Property(p => p.SportName).IsRequired();
            builder.Entity<DataResponseModel>().Property(p => p.CompetitionName).IsRequired();
            builder.Entity<DataResponseModel>().Property(p => p.SeasonId).IsRequired();
            builder.Entity<DataResponseModel>().Ignore(p => p.Rushing);
            builder.Entity<DataResponseModel>().Ignore(p => p.Passing);
            builder.Entity<DataResponseModel>().Ignore(p => p.Receiving);
            builder.Entity<DataResponseModel>().Ignore(p => p.Kicking);
            //builder.Entity<DataResponseModel>().HasMany(p => p.Products).WithOne(p => p.Card).HasForeignKey(p => p.CardId);


            builder.Entity<RushingModel>().ToTable("Rushers");
            builder.Entity<RushingModel>().HasKey(p => p.Id);
            builder.Entity<RushingModel>().Property(p => p.EntryId).IsRequired();
            builder.Entity<RushingModel>().Property(p => p.Name).IsRequired();
            builder.Entity<RushingModel>().Property(p => p.Position).IsRequired();
            builder.Entity<RushingModel>().Property(p => p.Yds).IsRequired();
            builder.Entity<RushingModel>().Property(p => p.Att).IsRequired();
            builder.Entity<RushingModel>().Property(p => p.Tds).IsRequired();
            builder.Entity<RushingModel>().Property(p => p.Fum).IsRequired();

            builder.Entity<PassingModel>().ToTable("Passers");
            builder.Entity<PassingModel>().HasKey(p => p.Id);
            builder.Entity<PassingModel>().Property(p => p.EntryId).IsRequired();
            builder.Entity<PassingModel>().Property(p => p.Name).IsRequired();
            builder.Entity<PassingModel>().Property(p => p.Position).IsRequired();
            builder.Entity<PassingModel>().Property(p => p.Yds).IsRequired();
            builder.Entity<PassingModel>().Property(p => p.Att).IsRequired();
            builder.Entity<PassingModel>().Property(p => p.Tds).IsRequired();
            builder.Entity<PassingModel>().Property(p => p.Cmp).IsRequired();
            builder.Entity<PassingModel>().Property(p => p.Int).IsRequired();


            builder.Entity<ReceivingModel>().ToTable("Receivers");
            builder.Entity<ReceivingModel>().HasKey(p => p.Id);
            builder.Entity<ReceivingModel>().Property(p => p.EntryId).IsRequired();
            builder.Entity<ReceivingModel>().Property(p => p.Name).IsRequired();
            builder.Entity<ReceivingModel>().Property(p => p.Position).IsRequired();
            builder.Entity<ReceivingModel>().Property(p => p.Yds).IsRequired();
            builder.Entity<ReceivingModel>().Property(p => p.Tds).IsRequired();
            builder.Entity<ReceivingModel>().Property(p => p.Rec).IsRequired();


            builder.Entity<KickingModel>().ToTable("Kickers");
            builder.Entity<KickingModel>().HasKey(p => p.Id);
            builder.Entity<KickingModel>().Property(p => p.EntryId).IsRequired();
            builder.Entity<KickingModel>().Property(p => p.Name).IsRequired();
            builder.Entity<KickingModel>().Property(p => p.Position).IsRequired();
            builder.Entity<KickingModel>().Property(p => p.GoalsMade).IsRequired();
            builder.Entity<KickingModel>().Property(p => p.GoalsAtt).IsRequired();
            builder.Entity<KickingModel>().Property(p => p.ExtraMade).IsRequired();
            builder.Entity<KickingModel>().Property(p => p.ExtraAtt).IsRequired();
           
        }

    }
}
