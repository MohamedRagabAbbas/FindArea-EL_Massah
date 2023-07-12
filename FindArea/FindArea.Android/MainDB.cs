using App21;
using FindArea.Droid;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(MainDB))]

namespace FindArea.Droid
{
    public class MainDB : DataBase
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var folderName = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(folderName, "MySQLite.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}