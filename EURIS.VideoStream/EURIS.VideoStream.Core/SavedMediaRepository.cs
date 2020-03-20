using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using EURIS.VideoStream.Entity;
using EURIS.VideoStream.Interfaces;

namespace EURIS.VideoStream.Core
{
    public class SavedMediaRepository : ISavedMedia
    {
        private VideoStreamContext db;
        private DbSet<SavedMedia> dbSet;

        public SavedMediaRepository()
        {
            db = new VideoStreamContext();
            dbSet = db.Set<SavedMedia>();
        }

        public IEnumerable<SavedMedia> GetAllSavedMedia()
        {
            return dbSet.ToList();
        }

        public SavedMedia GetSavedMediaById(Guid SavedMediaId)
        {
            return dbSet.Find(SavedMediaId);
        }

        public void InsertMedia(SavedMedia SaveMedia)
        {
            dbSet.Add(SaveMedia);
        }

        public void UpdateSavedMedia(SavedMedia SaveMedia)
        {
            db.Entry(SaveMedia).State = EntityState.Modified;
        }

        public void DeleteSavedMedia(Guid SavedMediaId)
        {
            SavedMedia SMedia = dbSet.Find(SavedMediaId);
            dbSet.Remove(SMedia);
        }

        public void SaveToSavedMedia()
        {
            db.SaveChanges();
        }
    }
}
