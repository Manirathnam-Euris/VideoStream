using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EURIS.VideoStream.Core.VideoStreamManagers;
using EURIS.VideoStream.Entity;

namespace VideoStreamTest
{
    [TestClass]
    public class FavouritesTest
    {
        private Favourites _favourites = new Favourites();
        private FavouritesManager _fManager = new FavouritesManager();
        private MediaContentManager _mediaManager = new MediaContentManager();

        [TestMethod]
        public void AddFavouritesTest()
        {
            var media = _mediaManager.GetMediaContent(new Guid("98C2A5E2-F413-4913-BB38-8BD834596713"));
            _favourites.FavouritesId = Guid.NewGuid();
            _favourites.Name = media.Title;
            _favourites.UserProfileId = new Guid("922DB99E-572B-4BEA-91BB-1793F3CD6492");
            _favourites.ContentId = media.ContentId;
            _fManager.AddFavourites(_favourites);
        }

        [TestMethod()]
        public void GetFavouritesByIdTest()
        {
            _fManager.GetFavourites(new Guid("7A4A03C7-903E-43EF-8D73-0154B7F98D9E"));
        }

        [TestMethod]
        public void GetProfileFavouritesTest()
        {
            var savedMedia = _fManager.GetProfileFavourites(new Guid("922DB99E-572B-4BEA-91BB-1793F3CD6492"));
        }

        [TestMethod]
        public void GetContentFavouritesTest()
        {
            var savedMedia = _fManager.GetContentFavourites(new Guid("98C2A5E2-F413-4913-BB38-8BD834596713"));
        }

        [TestMethod]
        public void UpdateFavouritesTest()
        {
            var media = _mediaManager.GetMediaContent(new Guid("98C2A5E2-F413-4913-BB38-8BD834596713"));
            _favourites.FavouritesId = new Guid("7A4A03C7-903E-43EF-8D73-0154B7F98D9E");
            _favourites.Name = media.Title;
            _favourites.UserProfileId = new Guid("922DB99E-572B-4BEA-91BB-1793F3CD6492");
            _favourites.ContentId = media.ContentId;
            _fManager.UpdateFavourites(_favourites);
        }

        [TestMethod]
        public void DeleteFavourites()
        {
            _fManager.DeleteFavourites(new Guid("7A4A03C7-903E-43EF-8D73-0154B7F98D9E"));
        }
    }
}
