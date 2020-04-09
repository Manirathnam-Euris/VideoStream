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
        public void AddFavourites_WhenCalled_CheckFavouriteIsAdded()
        {
            var contentId = new Guid("98C2A5E2-F413-4913-BB38-8BD834596713");
            var profileId = new Guid("922DB99E-572B-4BEA-91BB-1793F3CD6492");
            var media = _mediaManager.GetMediaContent(contentId);

            if(media != null)
            {
                var favourites = new Favourites()
                {
                    FavouritesId = Guid.NewGuid(),
                    Name = media.Title,
                    UserProfileId = profileId,
                    ContentId = media.ContentId
                };

                _fManager.AddFavourites(favourites);
            }
        }

        [TestMethod()]
        public void GetFavouritesById_WhenCalled_CheckFavoriteIsNotNull()
        {
            var favouriteId = new Guid("7A4A03C7-903E-43EF-8D73-0154B7F98D9E");

            var favourite = _fManager.GetFavourites(favouriteId);

            Assert.IsNotNull(favourite);
        }

        [TestMethod]
        public void GetProfileFavourites_WhenCalled_CheckProfileFavouriteIsNotNull()
        {
            var profileId = new Guid("922DB99E-572B-4BEA-91BB-1793F3CD6492");
            var savedMedia = _fManager.GetProfileFavourites(profileId);
            Assert.IsNotNull(savedMedia);
        }

        [TestMethod]
        public void GetContentFavourites_WhenCalled_CheckContentFavouritesIsNotNull()
        {
            var contentId = new Guid("98C2A5E2-F413-4913-BB38-8BD834596713");
            var savedMedia = _fManager.GetContentFavourites(contentId);
            Assert.IsNotNull(savedMedia);
        }

        //[TestMethod]
        //public void UpdateFavourites_WhenCalled_CheckContentIsUpdated()
        //{
        //    var media = _mediaManager.GetMediaContent(new Guid("98C2A5E2-F413-4913-BB38-8BD834596713"));
        //    _favourites.FavouritesId = new Guid("7A4A03C7-903E-43EF-8D73-0154B7F98D9E");
        //    _favourites.Name = media.Title;
        //    _favourites.UserProfileId = new Guid("922DB99E-572B-4BEA-91BB-1793F3CD6492");
        //    _favourites.ContentId = media.ContentId;
        //    _fManager.UpdateFavourites(_favourites);
        //}

        [TestMethod]
        public void DeleteFavourites_WhenCalled_CheckIfFavouriteIsDeleted()
        {
            var favouriteId = new Guid("7A4A03C7-903E-43EF-8D73-0154B7F98D9E");
            _fManager.DeleteFavourites(favouriteId);
        }
    }
}
