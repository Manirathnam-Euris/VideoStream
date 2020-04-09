using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EURIS.VideoStream.Entity;

namespace EURIS.VideoStream.Core.VideoStreamManagers
{
    public class MediaContentManager
    {
        UnitOfWork _unitOfWork = new UnitOfWork(new VideoStreamContext());

        public IEnumerable<MediaContent> GetAllMediaContents()
        {
            return _unitOfWork.MediaRep.GetAll().ToList();
        }

        public MediaContent GetMediaContent(Guid contentId)
        {
            try
            {
                if(contentId == Guid.Empty || contentId == null)
                {
                    throw new Exception("Provide valid Id");
                }
                var mediaExists = _unitOfWork.MediaRep.GetById(contentId);
                if (mediaExists == null)
                {
                    throw new Exception("Media is not exists with this Id:" + contentId);
                }
                return mediaExists;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddMediaContent(MediaContent mediaContent)
        {
            try
            {
                var mediaExists = _unitOfWork.MediaRep.GetById(mediaContent.ContentId);
                if (mediaExists != null)
                {
                    throw new Exception("This media is already exists");
                }
                _unitOfWork.MediaRep.Insert(mediaContent);
                _unitOfWork.Save();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateMediaContent(MediaContent mediaContent)
        {
            try
            {
                var mediaExists = _unitOfWork.MediaRep.GetById(mediaContent.ContentId);
                if (mediaExists == null)
                {
                    throw new Exception("Media is not exists to update");
                }
                mediaExists.Title = mediaContent.Title;
                mediaExists.Episode = mediaContent.Episode;
                mediaExists.Genre = mediaContent.Genre;
                mediaExists.TimeLength = mediaContent.TimeLength;
                mediaExists.ReleaseDate = mediaContent.ReleaseDate;
                mediaExists.Distributor = mediaContent.Distributor;
                mediaExists.Language = mediaContent.Language;
                mediaExists.AverageRating = mediaContent.AverageRating;
                mediaExists.HeroineName = mediaContent.HeroineName;
                mediaExists.HeroName = mediaContent.HeroName;
                mediaExists.Director = mediaContent.Director;
                mediaExists.Producer = mediaContent.Producer;
                mediaExists.ProductionHouse = mediaContent.ProductionHouse;

                _unitOfWork.MediaRep.Update(mediaExists);
                _unitOfWork.Save();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteMediaContent(Guid contentId)
        {
            try
            {
                if(contentId == Guid.Empty || contentId == null)
                {
                    throw new Exception("Provide valid Id");
                }
                var mediaExists = _unitOfWork.MediaRep.GetById(contentId);
                if (mediaExists == null)
                {
                    throw new Exception("Media is not exists whith this id:" + contentId);
                }
                _unitOfWork.MediaRep.Delete(mediaExists.ContentId);
                _unitOfWork.Save();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
