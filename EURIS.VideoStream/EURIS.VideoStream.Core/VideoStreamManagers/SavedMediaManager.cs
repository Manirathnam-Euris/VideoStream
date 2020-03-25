﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
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
                var savedMediaExists = _SavedMediaRep.GetAllSavedMedia().Where(s => s.UserProfileId == profileId);
                if(savedMediaExists == null)
                {
                    throw new Exception("No data found with this profile Id:" + profileId);
                }
                return savedMediaExists.ToList();
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
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
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
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
                savedMediaExists.Name = savedMedia.Name;
                savedMediaExists.UserProfileId = savedMedia.UserProfileId;
                savedMediaExists.ContentId = savedMedia.ContentId;

                _SavedMediaRep.UpdateSavedMedia(savedMediaExists);
                _SavedMediaRep.SaveToSavedMedia();
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<SavedMedia> GetContentSavedMedia(Guid contentId)
        {
            try
            {
                if(contentId == Guid.Empty || contentId == null)
                {
                    throw new Exception("Please provide valid contentId");
                }
                var savedMediaExists = _SavedMediaRep.GetAllSavedMedia().Where(s => s.ContentId == contentId);
                if (savedMediaExists == null)
                {
                    throw new Exception("No data found with this profile Id:" + contentId);
                }
                return savedMediaExists.ToList();
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
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
                _SavedMediaRep.DeleteSavedMedia(savedMediaExists.SavedMediaId);
                _SavedMediaRep.SaveToSavedMedia();
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        } 
    }
}
