namespace EURIS.VideoStream.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intial_model : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Favourites",
                c => new
                    {
                        FavouritesId = c.Guid(nullable: false),
                        Name = c.String(),
                        UserProfileId = c.Guid(nullable: false),
                        ContentId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.FavouritesId)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfileId, cascadeDelete: true)
                .Index(t => t.UserProfileId);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        ProfileId = c.Guid(nullable: false),
                        ProfileName = c.String(),
                        UserId = c.Guid(nullable: false),
                        SubscriptionTypeId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ProfileId)
                .ForeignKey("dbo.SubscriptionTypes", t => t.SubscriptionTypeId, cascadeDelete: true)
                .ForeignKey("dbo.UserAccounts", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.SubscriptionTypeId);
            
            CreateTable(
                "dbo.SavedMedias",
                c => new
                    {
                        SavedMediaId = c.Guid(nullable: false),
                        Name = c.String(),
                        UserProfileId = c.Guid(nullable: false),
                        ContentId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.SavedMediaId)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfileId, cascadeDelete: true)
                .Index(t => t.UserProfileId);
            
            CreateTable(
                "dbo.StreamDatas",
                c => new
                    {
                        StreamDataId = c.Guid(nullable: false),
                        StreamDate = c.DateTime(nullable: false),
                        StreamTime = c.DateTime(nullable: false),
                        StreamLength = c.Int(nullable: false),
                        StreamRate = c.String(),
                        UserProfileId = c.Guid(nullable: false),
                        ContentId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.StreamDataId)
                .ForeignKey("dbo.MediaContents", t => t.ContentId, cascadeDelete: true)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfileId, cascadeDelete: true)
                .Index(t => t.UserProfileId)
                .Index(t => t.ContentId);
            
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
                    })
                .PrimaryKey(t => t.ContentId);
            
            CreateTable(
                "dbo.SubscriptionTypes",
                c => new
                    {
                        SubscriptionTypeId = c.Guid(nullable: false),
                        Name = c.String(),
                        Type = c.String(),
                        SubscriptionId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.SubscriptionTypeId)
                .ForeignKey("dbo.Subscriptions", t => t.SubscriptionId, cascadeDelete: true)
                .Index(t => t.SubscriptionId);
            
            CreateTable(
                "dbo.Subscriptions",
                c => new
                    {
                        SubscriptionId = c.Guid(nullable: false),
                        Price = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SubscriptionId);
            
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
                        SubscriptionId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Favourites", "UserProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.UserProfiles", "UserId", "dbo.UserAccounts");
            DropForeignKey("dbo.UserProfiles", "SubscriptionTypeId", "dbo.SubscriptionTypes");
            DropForeignKey("dbo.SubscriptionTypes", "SubscriptionId", "dbo.Subscriptions");
            DropForeignKey("dbo.StreamDatas", "UserProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.StreamDatas", "ContentId", "dbo.MediaContents");
            DropForeignKey("dbo.SavedMedias", "UserProfileId", "dbo.UserProfiles");
            DropIndex("dbo.SubscriptionTypes", new[] { "SubscriptionId" });
            DropIndex("dbo.StreamDatas", new[] { "ContentId" });
            DropIndex("dbo.StreamDatas", new[] { "UserProfileId" });
            DropIndex("dbo.SavedMedias", new[] { "UserProfileId" });
            DropIndex("dbo.UserProfiles", new[] { "SubscriptionTypeId" });
            DropIndex("dbo.UserProfiles", new[] { "UserId" });
            DropIndex("dbo.Favourites", new[] { "UserProfileId" });
            DropTable("dbo.UserAccounts");
            DropTable("dbo.Subscriptions");
            DropTable("dbo.SubscriptionTypes");
            DropTable("dbo.MediaContents");
            DropTable("dbo.StreamDatas");
            DropTable("dbo.SavedMedias");
            DropTable("dbo.UserProfiles");
            DropTable("dbo.Favourites");
        }
    }
}
