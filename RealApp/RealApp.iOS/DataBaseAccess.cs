using RealApp.iOS;
using SQLite;
using SQLitePCL;
using System;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(DataBaseAccess))]
namespace RealApp.iOS
{
    public class DataBaseAccess
    {
        public SQLiteConnection GetConnection()
        {
            var dbName = "RealAppDb.db3";
            string personalFolder =
              System.Environment.
              GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryFolder =
              Path.Combine(personalFolder, "..", "Library");
            var path = Path.Combine(libraryFolder, dbName);
            return new SQLiteConnection(path);
        }
    }
}