using MobileCamoes.Model;
using System.Collections.Generic;

namespace MobileCamoes.Infra.Repository
{
    public interface IRepository<T> where T : DBEntity
    {
        void Add(T entity);
        IEnumerable<T> Get();
        T Get(int id);
        bool Exist(T entity);
        bool Exist(int id);
        void Remove(T entity);
    }
}
