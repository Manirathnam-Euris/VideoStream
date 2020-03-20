using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EURIS.VideoStream.Entity;

namespace EURIS.VideoStream.Core.VideoStreamManagers
{
    public class SavedMediaManager
    {
        private SavedMediaRepository _SavedMediaRep = new SavedMediaRepository();

        public IEnumerable<SavedMedia> GetAllSavedMedia()
        {
            return _SavedMediaRep.GetAllSavedMedia().ToList();
        }

        public SavedMedia GetSavedMedia(Guid savedMediaId)
        {
            try
            {
                if(savedMediaId == Guid.Empty || savedMediaId == null)
                {
                    throw new Exception("Provide valid Id");
                }
                var savedMediaExists = _SavedMediaRep.GetSavedMediaById(savedMediaId);
                if(savedMediaExists == null)
                {
                    throw new Exception("Saved media is not present with this Id:" + savedMediaId);
                }
                return savedMediaExists;
            }
            catch
            {
                throw new Exception("Something went wrong while getting the saved media with this Id: " + savedMediaId);
            }
        }

        public IEnumerable<SavedMedia> GetProfileSavedMedia(Guid profileId)
        {
            try
            {
                if(profileId == Guid.Empty || profileId == null)
                {
                    throw new Exception("Provide valid Id");
                }
                var savedMediaExists = _SavedMediaRep.GetAllSavedMedia().Where(s => s.UserProfile.ProfileId == profileId);
                if(savedMediaExists == null)
                {
                    throw new Exception("No data found with this profile Id:" + profileId);
                }
                return savedMediaExists.ToList();
            }
            catch
            {
                throw new Exception("Something went wrong while getting the Saved media with  profile Id:" + profileId);
            }
        }

        public void AddSavedMedia(SavedMedia savedMedia)
        {
            try
            {
                var savedMediaExists = _SavedMediaRep.GetSavedMediaById(savedMedia.SavedMediaId);
                if(savedMediaExists != null)
                {
                    throw new Exception("This savedMedia is already exists Id:" + savedMedia.SavedMediaId);
                }
                _SavedMediaRep.InsertMedia(savedMedia);
                _SavedMediaRep.SaveToSavedMedia();
            }
            catch
            {
                throw new Exception("Something went wrong while Adding saved media");
            }
        }

        public void UpdateSavedMedia(SavedMedia savedMedia)
        {
            try
            {
                var savedMediaExists = _SavedMediaRep.GetSavedMediaById(savedMedia.SavedMediaId);
                if(savedMediaExists == null)
                {
                    throw new Exception("There is no saved media to update with this Id: " + savedMedia.SavedMediaId);
                }
                _SavedMediaRep.UpdateSavedMedia(savedMedia);
                _SavedMediaRep.SaveToSavedMedia();
            }
            catch
            {
                throw new Exception("Something went wrong while updating the Saved media");
            }
        }

        public void DeleteSavedMedia(Guid savedMediaId)
        {
            try
            {
                if(savedMediaId == Guid.Empty || savedMediaId == null)
                {
                    throw new Exception("Provide valid Id");
                }
                var savedMediaExists = _SavedMediaRep.GetSavedMediaById(savedMediaId);
                if(savedMediaExists == null)
                {
                    throw new Exception("There is no saved media with this Id:" + savedMediaId);
                }
                _SavedMediaRep.DeleteSavedMedia(savedMediaId);
                _SavedMediaRep.SaveToSavedMedia();
            }
            catch
            {
                throw new Exception("Something wrong while deleting the saved media");
            }
        } 
    }
}
