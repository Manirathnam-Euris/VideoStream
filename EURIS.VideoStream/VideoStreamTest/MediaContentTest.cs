﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EURIS.VideoStream.Core.VideoStreamManagers;
using EURIS.VideoStream.Entity;

namespace VideoStreamTest
{
    [TestClass]
    public class MediaContentTest
    {
        private MediaContent _mediaContent = new MediaContent();
        private MediaContentManager _mediaContentManager = new MediaContentManager();

        [TestMethod()]
        public void AddMediaContent()
        {
            _mediaContent.ContentId = Guid.NewGuid();
            _mediaContent.Title = "Interstellar";
            _mediaContent.Episode = 0;
            _mediaContent.Genre = "Sci-Fi";
            _mediaContent.TimeLength = 120;
            _mediaContent.ReleaseDate = new DateTime(2014,10,14);
            _mediaContent.Distributor = "United States";
            _mediaContent.Language = "English";
            _mediaContent.AverageRating = 8;
            _mediaContent.HeroName = "Matthew";
            _mediaContent.HeroineName = "Anne";
            _mediaContent.Director = "Cristopher nolan";
            _mediaContent.Producer = "Nolan";
            _mediaContent.ProductionHouse = "Warner Bros";
            _mediaContentManager.AddMediaContent(_mediaContent);
        }

        [TestMethod()]
        public void GetMediaContentByIdTest()
        {
            _mediaContentManager.GetMediaContent(new Guid(""));
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void UpdateMediaContentTest()
        {
            _mediaContent.ContentId = new Guid("");
            _mediaContent.Title = "Interstellar";
            _mediaContent.Episode = 0;
            _mediaContent.Genre = "Sci-Fi";
            _mediaContent.TimeLength = 120;
            _mediaContent.ReleaseDate = new DateTime(2014, 10, 14);
            _mediaContent.Distributor = "United States";
            _mediaContent.Language = "English";
            _mediaContent.AverageRating = 8;
            _mediaContent.HeroName = "Matthew";
            _mediaContent.HeroineName = "Anne";
            _mediaContent.Director = "Cristopher nolan";
            _mediaContent.Producer = "Nolan";
            _mediaContent.ProductionHouse = "Warner Bros";
            _mediaContentManager.AddMediaContent(_mediaContent);
        }

        [TestMethod()]
        public void DeleteContentTest()
        {
            _mediaContentManager.DeleteMediaContent(new Guid(""));
        }

        [TestMethod()]
        public void GetAllContent()
        {
            _mediaContentManager.GetAllMediaContents();
        }
    }
}