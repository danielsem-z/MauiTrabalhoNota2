using LiteDB;
using MauiApp1.Entity;
using MauiApp1.Repository;
using System.Collections.Generic;

namespace MauiApp1.Data
{
    internal class PrevisaoRepository : DatabaseConnection
    {
        private static readonly string _databasePath =
            System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "previsao.db");

        public PrevisaoRepository() : base(_databasePath)
        {
        }

        public void Add(PrevisaoEntity previsao)
        {
            using var db = GetDatabase();
            var collection = db.GetCollection<PrevisaoEntity>();
            previsao.CreatedDate = DateTime.Now;
            collection.Insert(previsao);
        }

        public List<PrevisaoEntity> GetAll()
        {
            using var db = GetDatabase();
            var collection = db.GetCollection<PrevisaoEntity>();
            return collection.FindAll().ToList();
        }

        public void Delete(int id)
        {
            using var db = GetDatabase();
            var collection = db.GetCollection<PrevisaoEntity>();
            collection.Delete(id);
        }

        public List<PrevisaoEntity> GetByDate(DateTime date)
        {
            using var db = GetDatabase();
            var collection = db.GetCollection<PrevisaoEntity>();
            return collection.Find(p => p.CreatedDate.HasValue && p.CreatedDate.Value.Date == date.Date).ToList();
        }
    }
}
