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
    public class FavouritesRepository : IFavourites
    {
        private VideoStreamContext db;
        private DbSet<Favourites> dbSet;

        public FavouritesRepository(VideoStreamContext _videoStreamContext)
        {
            db = _videoStreamContext;
            dbSet = db.Set<Favourites>();
        }

        public IEnumerable<Favourites> GetAllFavourites()
        {
            return dbSet.ToList();
        }

        public Favourites GetFavouriteById(Guid FavouriteId)
        {
            return dbSet.Find(FavouriteId);
        }

        public void InsertFavourite(Favourites FavouriteMedia)
        {
            dbSet.Add(FavouriteMedia);
        }

        public void UpdateFavourite(Favourites FavouriteMedia)
        {
            db.Entry(FavouriteMedia).State = EntityState.Modified;
        }

        public void DeleteFavourite(Guid FavouriteId)
        {
            Favourites FMedia = dbSet.Find(FavouriteId);
            dbSet.Remove(FMedia);
        }

        public void SaveFavourite()
        {
            db.SaveChanges();
        }
    }
}
