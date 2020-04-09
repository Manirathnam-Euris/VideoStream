using System;
using System.Collections.Generic;

namespace EURIS.VideoStream.Interfaces
{

    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        void Insert(T enity);
        void Update(T entity);
        void Delete(Guid id);
        //void SaveFavourite();
    }

}
