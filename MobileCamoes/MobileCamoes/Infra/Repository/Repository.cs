using System;
using System.Collections.Generic;
using LiteDB;
using MobileCamoes.Model;

namespace MobileCamoes.Infra.Repository
{
    public class Repository<T> : IRepository<T> where T : DBEntity
    {

        private string CollectionName{ get => nameof(T); }

        public void Add(T entity)
            => GetCollection().Insert(entity);

        public bool Exist(T entity)
            => GetCollection().Exists(x => x.Id == entity.Id);

        public bool Exist(int id)
            => GetCollection().Exists(x => x.Id == id);

        public IEnumerable<T> Get()
            => GetCollection().FindAll();

        public T Get(int id)
            => GetCollection().FindById(id);

        public void Remove(T entity)
            => GetCollection().Delete(entity.Id);

        public LiteCollection<T> GetCollection()
            => GetOrCreateDataBase().GetCollection<T>(CollectionName);

        public LiteDatabase GetOrCreateDataBase()
        {
            LiteDatabase result;
            try
            {
                result = new LiteDatabase($@"{AppSettings.OfflineDataBaseLiteDBPath}");
            }
            catch(Exception ex)
            {
                return null;
            }
            return result;
        }
    }
}
