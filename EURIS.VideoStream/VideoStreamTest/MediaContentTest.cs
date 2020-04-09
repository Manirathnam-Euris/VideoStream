using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EURIS.VideoStream.Core.VideoStreamManagers;
using EURIS.VideoStream.Entity;

namespace VideoStreamTest
{
    [TestClass]
    public class MediaContentTest
    {
        //private MediaContent _mediaContent = new MediaContent();
        private MediaContentManager _mediaContentManager = new MediaContentManager();

        [TestMethod()]
        public void AddMediaContent_WhenCalled_CheckIfMediaContentIsAdded()
        {
            var mediaContent = new MediaContent()
            {
                ContentId = Guid.NewGuid(),
                Title = "Robo",
                Episode = 0,
                Genre = "Sci-Fi",
                TimeLength = 120,
                ReleaseDate = new DateTime(2014, 10, 11),
                Distributor = "LycaProductions",
                Language = "Telugu",
                AverageRating = 8,
                HeroName = "Rajini",
                HeroineName = "Aishwarya",
                Director = "Shankar",
                Producer = "Subaskaran",
                ProductionHouse = "Lyca Production",
            };
            
            _mediaContentManager.AddMediaContent(mediaContent);
        }

        [TestMethod()]
        public void GetMediaContentById_WhenCalled_CheckMediaContentIsNotNull()
        {
            var mediaContentId = new Guid("04B4346F-D4F3-4CF0-96D8-31882845AF36");

            var mediaContent = _mediaContentManager.GetMediaContent(mediaContentId);

            Assert.IsNotNull(mediaContent);
        }

        [TestMethod()]
        public void UpdateMediaContent_WhenCalled_CheckMediaContentIsUpdated()
        {
            var contentId = new Guid("04B4346F-D4F3-4CF0-96D8-31882845AF36");
            var mediaContent = new MediaContent()
            {
                ContentId = contentId,
                Title = "Robo",
                Episode = 0,
                Genre = "Sci-Fi",
                TimeLength = 120,
                ReleaseDate = new DateTime(2014, 10, 11),
                Distributor = "LycaProductions",
                Language = "Telugu",
                AverageRating = 8,
                HeroName = "Rajini",
                HeroineName = "Aishwarya",
                Director = "Shankar",
                Producer = "Subaskaran",
                ProductionHouse = "Lyca Production",
            };
            _mediaContentManager.AddMediaContent(mediaContent);
        }

        [TestMethod()]
        public void DeleteContent_WhenCalled_CheckIsMediaContentIsDeleted()
        {
            var contentId = new Guid("04B4346F-D4F3-4CF0-96D8-31882845AF36");
            _mediaContentManager.DeleteMediaContent(contentId);
        }

        [TestMethod()]
        public void GetAllContent_WhenCalled_CheckMediaContentIsNotNull()
        {
            var contents = _mediaContentManager.GetAllMediaContents();
            Assert.IsNotNull(contents);
        }
    }
}
