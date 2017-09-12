using System;
using System.IO;
using Xamarin.Forms;
using RealApp.Droid;
using SQLite;

[assembly: Dependency(typeof(DataBaseAccess))]
namespace RealApp.Droid
{
    public class DataBaseAccess : IDatabaseAccess
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var sqlDbFileName = "RealAppDb.db3";
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = System.IO.Path.Combine(documentsPath, sqlDbFileName);

            var connection = new SQLiteAsyncConnection(path);

            return connection;
        }
    }
}
