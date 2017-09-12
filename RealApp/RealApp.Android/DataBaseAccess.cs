using System;
using System.IO;
using Xamarin.Forms;
using RealApp.Droid;
using SQLite;

[assembly: Dependency(typeof(Database_Android))]
namespace RealApp.Droid
{
    public class Database_Android : IDatabaseAccess
    {
        public Database_Android() { }
        public SQLiteConnection GetConnection()
        {
            var sqlDbFileName = "RealAppDb.db3";
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = System.IO.Path.Combine(documentsPath, sqlDbFileName);

            var connection = new SQLiteConnection(path);

            return connection;
        }
    }
}
