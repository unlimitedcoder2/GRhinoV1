using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using GRhinoV1.Model;
using System.Threading.Tasks;
using SQLite;

namespace GRhinoV1.Data
{
    public class Database
    {
        public readonly SQLiteAsyncConnection db;
        
        public Database(string path)
        {
            path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), path);
            db = new SQLiteAsyncConnection(path, SQLiteOpenFlags.Create |
            SQLiteOpenFlags.FullMutex |
            SQLiteOpenFlags.ReadWrite);

;           db.CreateTableAsync<User>().Wait();
        }
    }
}