using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EURIS.VideoStream.Entity;

namespace EURIS.VideoStream.Core.VideoStreamManagers
{
    public class MediaContentManager
    {
        private MediaContentRepository _MediaContentRep = new MediaContentRepository();

        public IEnumerable<MediaContent> GetAllMediaContents()
        {
            return _MediaContentRep.GetAllMediaContents().ToList();
        }

        public MediaContent GetMediaContent(Guid contentId)
        {
            try
            {
                if(contentId == Guid.Empty || contentId == null)
                {
                    throw new Exception("Provide valid Id");
                }
                var mediaExists = _MediaContentRep.GetMediaContentById(contentId);
                if(mediaExists == null)
                {
                    throw new Exception("Media is not exists with this Id:" + contentId);
                }
                return mediaExists;
            }
            catch
            {
                throw new Exception("Something went wrong while getting the media with this Id :" + contentId);
            }
        }

        public void AddMediaContent(MediaContent mediaContent)
        {
            try
            {
                var mediaExists = _MediaContentRep.GetMediaContentById(mediaContent.ContentId);
                if(mediaExists != null)
                {
                    throw new Exception("This media is already exists");
                }
                _MediaContentRep.InsertMediaContent(mediaContent);
                _MediaContentRep.SaveMediaContent();
            }
            catch
            {
                throw new Exception("Something went wrong in Adding media content");
            }
        }

        public void UpdateMediaContent(MediaContent mediaContent)
        {
            try
            {
                var mediaExists = _MediaContentRep.GetMediaContentById(mediaContent.ContentId);
                if(mediaExists == null)
                {
                    throw new Exception("Media is not exists to update");
                }
                _MediaContentRep.UpdateMediaContent(mediaContent);
                _MediaContentRep.SaveMediaContent();
            }
            catch
            {
                throw new Exception("Something went wrong while updating the media content");
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
                var mediaExists = _MediaContentRep.GetMediaContentById(contentId);
                if(mediaExists == null)
                {
                    throw new Exception("Media is not exists whith this id:" + contentId);
                }
                _MediaContentRep.DeleteMediaContent(contentId);
                _MediaContentRep.SaveMediaContent();
            }
            catch
            {
                throw new Exception("Something went wrong while deleting content");
            }
        }
    }
}
