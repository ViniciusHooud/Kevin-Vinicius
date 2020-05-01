using System.Collections.Generic;
using System.Linq;
using MobileCamoes.Model;
using SQLite;

namespace MobileCamoes.Infra.Repository
{
    public class RepositorySqlite<T> : SQLiteConnection, IRepository<T> where T : DBEntity, new()
    {
        public RepositorySqlite() : base(AppSettings.OfflineDataBaseSQLitePath)
        {
            CreateTable<T>();
        }

        public void Add(T entity)
        {
            try
            {
                BeginTransaction();

                //logica de persitencia de dados

                Insert(entity);
                Commit();
            }
            catch
            {
                Rollback();
            }
        }

        public bool Exist(T entity)
        {
            //select * from Serie where Id = 1
            return (from s in Table<T>() where s.Id == entity.Id select s).Any();
        }

        public bool Exist(int id)
            => (from s in Table<T>() where s.Id == id select s).Any();

        public IEnumerable<T> Get()
            => (from s in Table<T>() select s);

        public T Get(int id)
        {
            return (from s in Table<T>() where s.Id == id select s).FirstOrDefault();
        }

        public void Remove(T entity)
        {
            try
            {
                BeginTransaction();
                Delete(entity);
                Commit();
            }
            catch
            {
                Rollback();
            }
        }
    }
}
