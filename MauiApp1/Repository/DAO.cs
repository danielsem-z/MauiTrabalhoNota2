using LiteDB;
using System.Diagnostics;

namespace MauiApp1.Repository
{
    internal class DatabaseConnection
    {
        private readonly string _databasePath;

        public DatabaseConnection(string databasePath)
        {
            _databasePath = databasePath;
        }

        protected LiteDatabase GetDatabase()
        {
            Debug.WriteLine(_databasePath);
            return new LiteDatabase(_databasePath);
        }
    }
}
