namespace EURIS.VideoStream.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Favourites",
                c => new
                    {
                        FavouritesId = c.Guid(nullable: false),
                        Name = c.String(),
                        UserProfile_ProfileId = c.Guid(),
                    })
                .PrimaryKey(t => t.FavouritesId)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfile_ProfileId)
                .Index(t => t.UserProfile_ProfileId);
            
            CreateTable(
                "dbo.MediaContents",
                c => new
                    {
                        ContentId = c.Guid(nullable: false),
                        Title = c.String(),
                        Episode = c.Int(nullable: false),
                        Genre = c.String(),
                        TimeLength = c.Int(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        Distributor = c.String(),
                        Language = c.String(),
                        AverageRating = c.Int(nullable: false),
                        HeroName = c.String(),
                        HeroineName = c.String(),
                        Director = c.String(),
                        Producer = c.String(),
                        ProductionHouse = c.String(),
                        Favourites_FavouritesId = c.Guid(),
                        SavedMedia_SavedMediaId = c.Guid(),
                        Subscription_SubscriptionId = c.Guid(),
                    })
                .PrimaryKey(t => t.ContentId)
                .ForeignKey("dbo.Favourites", t => t.Favourites_FavouritesId)
                .ForeignKey("dbo.SavedMedias", t => t.SavedMedia_SavedMediaId)
                .ForeignKey("dbo.Subscriptions", t => t.Subscription_SubscriptionId)
                .Index(t => t.Favourites_FavouritesId)
                .Index(t => t.SavedMedia_SavedMediaId)
                .Index(t => t.Subscription_SubscriptionId);
            
            CreateTable(
                "dbo.SavedMedias",
                c => new
                    {
                        SavedMediaId = c.Guid(nullable: false),
                        Name = c.String(),
                        UserProfile_ProfileId = c.Guid(),
                    })
                .PrimaryKey(t => t.SavedMediaId)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfile_ProfileId)
                .Index(t => t.UserProfile_ProfileId);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        ProfileId = c.Guid(nullable: false),
                        ProfileName = c.String(),
                        SubscriptionType_SubscriptionTypeId = c.Guid(),
                        UserAccount_UserId = c.Guid(),
                    })
                .PrimaryKey(t => t.ProfileId)
                .ForeignKey("dbo.SubscriptionTypes", t => t.SubscriptionType_SubscriptionTypeId)
                .ForeignKey("dbo.UserAccounts", t => t.UserAccount_UserId)
                .Index(t => t.SubscriptionType_SubscriptionTypeId)
                .Index(t => t.UserAccount_UserId);
            
            CreateTable(
                "dbo.StreamDatas",
                c => new
                    {
                        StreamDataId = c.Guid(nullable: false),
                        StreamDate = c.DateTime(nullable: false),
                        StreamTime = c.DateTime(nullable: false),
                        StreamLength = c.Int(nullable: false),
                        StreamRate = c.String(),
                        MediaContent_ContentId = c.Guid(),
                        UserProfile_ProfileId = c.Guid(),
                    })
                .PrimaryKey(t => t.StreamDataId)
                .ForeignKey("dbo.MediaContents", t => t.MediaContent_ContentId)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfile_ProfileId)
                .Index(t => t.MediaContent_ContentId)
                .Index(t => t.UserProfile_ProfileId);
            
            CreateTable(
                "dbo.UserAccounts",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        Name = c.String(),
                        SurName = c.String(),
                        Email = c.String(),
                        ContactNumber = c.Int(nullable: false),
                        Address = c.String(),
                        DateOfBirth = c.String(),
                        CreditCardNumber = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Subscriptions",
                c => new
                    {
                        SubscriptionId = c.Guid(nullable: false),
                        Price = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SubscriptionId)
                .ForeignKey("dbo.UserAccounts", t => t.SubscriptionId)
                .Index(t => t.SubscriptionId);
            
            CreateTable(
                "dbo.SubscriptionTypes",
                c => new
                    {
                        SubscriptionTypeId = c.Guid(nullable: false),
                        Name = c.String(),
                        Type = c.String(),
                        Subscripiton_SubscriptionId = c.Guid(),
                    })
                .PrimaryKey(t => t.SubscriptionTypeId)
                .ForeignKey("dbo.Subscriptions", t => t.Subscripiton_SubscriptionId)
                .Index(t => t.Subscripiton_SubscriptionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProfiles", "UserAccount_UserId", "dbo.UserAccounts");
            DropForeignKey("dbo.Subscriptions", "SubscriptionId", "dbo.UserAccounts");
            DropForeignKey("dbo.UserProfiles", "SubscriptionType_SubscriptionTypeId", "dbo.SubscriptionTypes");
            DropForeignKey("dbo.SubscriptionTypes", "Subscripiton_SubscriptionId", "dbo.Subscriptions");
            DropForeignKey("dbo.MediaContents", "Subscription_SubscriptionId", "dbo.Subscriptions");
            DropForeignKey("dbo.StreamDatas", "UserProfile_ProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.StreamDatas", "MediaContent_ContentId", "dbo.MediaContents");
            DropForeignKey("dbo.SavedMedias", "UserProfile_ProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.Favourites", "UserProfile_ProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.MediaContents", "SavedMedia_SavedMediaId", "dbo.SavedMedias");
            DropForeignKey("dbo.MediaContents", "Favourites_FavouritesId", "dbo.Favourites");
            DropIndex("dbo.SubscriptionTypes", new[] { "Subscripiton_SubscriptionId" });
            DropIndex("dbo.Subscriptions", new[] { "SubscriptionId" });
            DropIndex("dbo.StreamDatas", new[] { "UserProfile_ProfileId" });
            DropIndex("dbo.StreamDatas", new[] { "MediaContent_ContentId" });
            DropIndex("dbo.UserProfiles", new[] { "UserAccount_UserId" });
            DropIndex("dbo.UserProfiles", new[] { "SubscriptionType_SubscriptionTypeId" });
            DropIndex("dbo.SavedMedias", new[] { "UserProfile_ProfileId" });
            DropIndex("dbo.MediaContents", new[] { "Subscription_SubscriptionId" });
            DropIndex("dbo.MediaContents", new[] { "SavedMedia_SavedMediaId" });
            DropIndex("dbo.MediaContents", new[] { "Favourites_FavouritesId" });
            DropIndex("dbo.Favourites", new[] { "UserProfile_ProfileId" });
            DropTable("dbo.SubscriptionTypes");
            DropTable("dbo.Subscriptions");
            DropTable("dbo.UserAccounts");
            DropTable("dbo.StreamDatas");
            DropTable("dbo.UserProfiles");
            DropTable("dbo.SavedMedias");
            DropTable("dbo.MediaContents");
            DropTable("dbo.Favourites");
        }
    }
}
