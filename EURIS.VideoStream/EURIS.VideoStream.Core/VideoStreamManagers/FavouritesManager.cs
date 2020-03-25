using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EURIS.VideoStream.Entity;

namespace EURIS.VideoStream.Core.VideoStreamManagers
{
    public class FavouritesManager
    {
        private FavouritesRepository _FavouritesRep = new FavouritesRepository();

        public IEnumerable<Favourites> GetAllFavourites()
        {
            return _FavouritesRep.GetAllFavourites().ToList();
        }

        public Favourites GetFavourites(Guid favouriteId)
        {
            try
            {
                if(favouriteId == Guid.Empty || favouriteId == null)
                {
                    throw new Exception("Provide valid Id");
                }
                var favoriteExists = _FavouritesRep.GetFavouriteById(favouriteId);
                if(favoriteExists == null)
                {
                    throw new Exception("Favourites are not present in data with the Id:" + favouriteId);
                }
                return favoriteExists;
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Favourites> GetProfileFavourites(Guid profileId)
        {
            try
            {
                if (profileId == Guid.Empty || profileId == null)
                {
                    throw new Exception("Provide valid Id");
                }
                var favouritesExists = _FavouritesRep.GetAllFavourites().Where(s => s.UserProfileId == profileId);
                if (favouritesExists == null)
                {
                    throw new Exception("No data found with this profile Id:" + profileId);
                }
                return favouritesExists.ToList();
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Favourites> GetContentFavourites(Guid contentId)
        {
            try
            {
                if (contentId == Guid.Empty || contentId == null)
                {
                    throw new Exception("Provide valid Id");
                }
                var favouritesExists = _FavouritesRep.GetAllFavourites().Where(s => s.ContentId == contentId);
                if (favouritesExists == null)
                {
                    throw new Exception("No data found with this profile Id:" + contentId);
                }
                return favouritesExists.ToList();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateFavourites(Favourites favourites)
        {
            try
            {
                var favouriteExists = _FavouritesRep.GetFavouriteById(favourites.FavouritesId);
                if(favouriteExists == null)
                {
                    throw new Exception("There is no favorites with the favourite id: " + favourites.FavouritesId);
                }
                favouriteExists.Name = favourites.Name;
                favourites.UserProfileId = favourites.UserProfileId;
                favourites.ContentId = favourites.ContentId;

                _FavouritesRep.UpdateFavourite(favouriteExists);
                _FavouritesRep.SaveFavourite();
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddFavourites(Favourites favourites)
        {
            try
            {
                var favouriteExists = _FavouritesRep.GetFavouriteById(favourites.FavouritesId);
                if(favouriteExists != null)
                {
                    throw new Exception("This favourites is already exists with Id:" + favourites.FavouritesId);
                }
                _FavouritesRep.InsertFavourite(favourites);
                _FavouritesRep.SaveFavourite();
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteFavourites(Guid favouriteId)
        {
            try
            {
                var favouriteExists = _FavouritesRep.GetFavouriteById(favouriteId);
                if (favouriteExists == null)
                {
                    throw new Exception("No favourites are found with the Id:" + favouriteId);
                }
                _FavouritesRep.DeleteFavourite(favouriteExists.FavouritesId);
                _FavouritesRep.SaveFavourite();
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
