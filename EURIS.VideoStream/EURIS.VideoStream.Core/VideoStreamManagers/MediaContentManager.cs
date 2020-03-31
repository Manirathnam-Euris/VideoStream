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
        //private MediaContentRepository _MediaContentRep = new MediaContentRepository();

        UnitOfWork _unitOfWork = new UnitOfWork(new VideoStreamContext());

        public IEnumerable<MediaContent> GetAllMediaContents()
        {
            return _unitOfWork.MediaRep.GetAllMediaContents().ToList();
        }

        public MediaContent GetMediaContent(Guid contentId)
        {
            try
            {
                if(contentId == Guid.Empty || contentId == null)
                {
                    throw new Exception("Provide valid Id");
                }
                //var mediaExists = _MediaContentRep.GetMediaContentById(contentId);
                var mediaExists = _unitOfWork.MediaRep.GetMediaContentById(contentId);
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
                //var mediaExists = _MediaContentRep.GetMediaContentById(mediaContent.ContentId);
                var mediaExists = _unitOfWork.MediaRep.GetMediaContentById(mediaContent.ContentId);
                if (mediaExists != null)
                {
                    throw new Exception("This media is already exists");
                }
                //_MediaContentRep.InsertMediaContent(mediaContent);
                //_MediaContentRep.SaveMediaContent();
                _unitOfWork.MediaRep.InsertMediaContent(mediaContent);
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
                //var mediaExists = _MediaContentRep.GetMediaContentById(mediaContent.ContentId);
                var mediaExists = _unitOfWork.MediaRep.GetMediaContentById(mediaContent.ContentId);
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
                //_MediaContentRep.UpdateMediaContent(mediaExists);
                //_MediaContentRep.SaveMediaContent();
                _unitOfWork.MediaRep.UpdateMediaContent(mediaExists);
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
                //var mediaExists = _MediaContentRep.GetMediaContentById(contentId);
                var mediaExists = _unitOfWork.MediaRep.GetMediaContentById(contentId);
                if (mediaExists == null)
                {
                    throw new Exception("Media is not exists whith this id:" + contentId);
                }
                //_MediaContentRep.DeleteMediaContent(mediaExists.ContentId);
                //_MediaContentRep.SaveMediaContent();
                _unitOfWork.MediaRep.DeleteMediaContent(mediaExists.ContentId);
                _unitOfWork.Save();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
