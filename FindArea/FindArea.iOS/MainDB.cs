using App21;
using Xamarin.Forms;
using FindArea.iOS;
using SQLite;
using System;
using System.IO;

[assembly: Dependency(typeof(MainDB))]

namespace FindArea.iOS
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