//using System;
//using System.Data.Entity;
//using System.Data.Entity.ModelConfiguration;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EURIS.VideoStream.Entity
{
    public class VideoStreamContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=VideoStream;Trusted_Connection=True");
        //}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<UserProfile>()
                .HasRequired<UserAccount>(u => u.UserAccount)
                .WithMany(p => p.UserProfiles)
                .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<UserProfile>()
                .HasRequired<SubscriptionType>(s => s.SubscriptionType)
                .WithMany(u => u.UserProfiles)
                .HasForeignKey(s => s.SubscriptionTypeId);

            modelBuilder.Entity<SubscriptionType>()
                .HasRequired<Subscription>(s => s.Subscripiton)
                .WithMany(s => s.SubscriptionTypes)
                .HasForeignKey(sb => sb.SubscriptionId);

            modelBuilder.Entity<StreamData>()
                .HasRequired<MediaContent>(m => m.MediaContent)
                .WithMany(s => s.StreamDatas)
                .HasForeignKey(s => s.ContentId);

            modelBuilder.Entity<StreamData>()
                .HasRequired<UserProfile>(u => u.UserProfile)
                .WithMany(s => s.StreamDatas)
                .HasForeignKey(u => u.UserProfileId);

            modelBuilder.Entity<SavedMedia>()
                .HasRequired<UserProfile>(u => u.UserProfile)
                .WithMany(s => s.SavedMedias)
                .HasForeignKey(u => u.UserProfileId);

            //modelBuilder.Entity<MediaContent>()
            //   .HasOptional<SavedMedia>(s => s.SavedMedia)
            //   .WithRequired(m => m.MediaContent);

            //modelBuilder.Entity<MediaContent>()
            //   .HasOptional<Favourites>(f => f.Favourites)
            //   .WithRequired(m => m.MediaContent);

            modelBuilder.Entity<Favourites>()
                .HasRequired<UserProfile>(u => u.UserProfile)
                .WithMany(f => f.Favourites)
                .HasForeignKey(u => u.UserProfileId);
        }

        public virtual DbSet<UserAccount> UserAccounts { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public virtual DbSet<Favourites> Favourites { get; set; }
        public virtual DbSet<MediaContent> MediaContents { get; set; }
        public virtual DbSet<SavedMedia> SavedMedias { get; set; }
        public virtual DbSet<StreamData> StreamDatas { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
        public virtual DbSet<SubscriptionType> SubscriptionTypes { get; set; }
        public VideoStreamContext() : base("VideoStreamContext")
        {

        }
    }
}
