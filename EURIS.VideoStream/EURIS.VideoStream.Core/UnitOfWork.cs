using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EURIS.VideoStream.Entity;

namespace EURIS.VideoStream.Core
{
    public class UnitOfWork
    {
        private UserProfileRepository _userProfileRep;
        private UserAccountRepository _userAccountRep;
        private SubscripitionRepository _subscripitonRep;
        private SubscriptionTypeRepository _subscriptionTypeRep;
        private MediaContentRepository _mediaRep;
        private FavouritesRepository _favRep;
        private SavedMediaRepository _savedRep;
        private StreamDataRepository _streamRep;

        private VideoStreamContext _videoStreamContext;

        public UnitOfWork(VideoStreamContext VideoStream)
        {
            _videoStreamContext = VideoStream;
        }

        public UserAccountRepository UserAccountRep
        {
            get
            {
                if(_userAccountRep == null)
                {
                    _userAccountRep = new UserAccountRepository(_videoStreamContext);
                }
                return _userAccountRep;
            }
        }

        public UserProfileRepository UserProfileRep
        {
            get
            {
                if(_userProfileRep == null)
                {
                    _userProfileRep = new UserProfileRepository(_videoStreamContext);
                }
                return _userProfileRep;
            }
        }

        public SubscripitionRepository SubscriptionRep
        {
            get
            {
                if(_subscripitonRep == null)
                {
                    _subscripitonRep = new SubscripitionRepository(_videoStreamContext);
                }
                return _subscripitonRep;
            }
        }

        public SubscriptionTypeRepository SubscriptionTypeRep
        {
            get
            {
                if (_subscriptionTypeRep == null)
                {
                    _subscriptionTypeRep = new SubscriptionTypeRepository(_videoStreamContext);
                }
                return _subscriptionTypeRep;
            }
        }

        public MediaContentRepository MediaRep
        {
            get
            {
                if (_mediaRep == null)
                {
                    _mediaRep = new MediaContentRepository(_videoStreamContext);
                }
                return _mediaRep;
            }
        }

        public SavedMediaRepository SavedRep
        {
            get
            {
                if(_savedRep == null)
                {
                    _savedRep = new SavedMediaRepository(_videoStreamContext);
                }
                return _savedRep;
            }
        }

        public FavouritesRepository FavRep
        {
            get
            {
                if (_favRep == null)
                {
                    _favRep = new FavouritesRepository(_videoStreamContext);
                }
                return _favRep;
            }
        }

        public StreamDataRepository StreamRep
        {
            get
            {
                if(_streamRep == null)
                {
                    _streamRep = new StreamDataRepository(_videoStreamContext);
                }
                return _streamRep;
            }
        }

        public void Save()
        {
            _videoStreamContext.SaveChanges();
        }
    }
}
