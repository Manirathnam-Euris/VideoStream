using System;
using EURIS.VideoStream.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EURIS.VideoStream.Interfaces
{
    public interface IFavourites
    {
        IEnumerable<Favourites> GetAllFavourites();
        Favourites GetFavouriteById(Guid favouriteId);
        void InsertFavourite(Favourites enity);
        void UpdateFavourite(Favourites entity);
        void DeleteFavourite(Guid favouriteId);
        void SaveFavourite();
		//Testing the git
    }

    public interface IUserAccount
    {
        IEnumerable<UserAccount> GetAllUserAccounts();
        UserAccount GetUserAccountById(Guid UserId);
        void InsertUserAccount(UserAccount entity);
        void UpdateUserAccount(UserAccount entity);
        void DeleteUserAccount(Guid UserId);
        void SaveUserAccount();
    }

    public interface IUserProfile
    {
        IEnumerable<UserProfile> GetAllUserProfiles();
        UserProfile GetUserProfileById(Guid ProfileId);
        void InsertUserProfile(UserProfile entity);
        void UpdateUserProfile(UserProfile entity);
        void DeleteUserProfile(Guid ProfileId);
        void SaveUserProfile();
    }

    public interface IMediaContent
    {
        IEnumerable<MediaContent> GetAllMediaContents();
        MediaContent GetMediaContentById(Guid MediaId);
        void InsertMediaContent(MediaContent entity);
        void UpdateMediaContent(MediaContent entity);
        void DeleteMediaContent(Guid MediaId);
        void SaveMediaContent();
    }

    public interface ISubscription
    {
        IEnumerable<Subscription> GetAllSubscripitons();
        Subscription GetSubscriptionById(Guid SubscriptionId);
        void InsertSubscripiton(Subscription entity);
        void UpdateSubscription(Subscription entity);
        void DeleteSubscription(Guid SubscriptionId);
        void SaveSubscription();
    }

    public interface ISubscriptionType
    {
        IEnumerable<SubscriptionType> GetAllSubscripitonTypes();
        SubscriptionType GetSubscriptionTypeById(Guid SubscriptionTypeId);
        void InsertSubscripitonType(SubscriptionType entity);
        void UpdateSubscriptionType(SubscriptionType entity);
        void DeleteSubscriptionType(Guid SubscriptionTypeId);
        void SaveSubscriptionType();
    }

    public interface IStreamData
    {
        IEnumerable<StreamData> GetAllStreamData();
        StreamData GetStreamDataById(Guid StreamId);
        void InsertStreamData(StreamData entity);
        void UpdateStreamData(StreamData entity);
        void DeleteStreamData(Guid StreamId);
        void SaveStreamData();
    }

    public interface ISavedMedia
    {
        IEnumerable<SavedMedia> GetAllSavedMedia();
        SavedMedia GetSavedMediaById(Guid SavedMediaId);
        void InsertMedia(SavedMedia entity);
        void UpdateSavedMedia(SavedMedia entity);
        void DeleteSavedMedia(Guid SavedMediaId);
        void SaveToSavedMedia();
    }
}
