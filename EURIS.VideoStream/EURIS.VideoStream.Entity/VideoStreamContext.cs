using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EURIS.VideoStream.Entity
{
    public class VideoStreamContext : DbContext
    {
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Favourites> Favourites { get; set; }
        public DbSet<MediaContent> MediaContents { get; set; }
        public DbSet<SavedMedia> SavedMedias { get; set; }
        public DbSet<StreamData> StreamDatas { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<SubscriptionType> subscriptionTypes { get; set; }
        public VideoStreamContext() : base("VideoStreamContextConnection")
        {

        }
    }
}
