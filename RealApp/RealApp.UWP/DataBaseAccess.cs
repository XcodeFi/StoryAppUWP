//using Xamarin.Forms;
//using RealApp.UWP;
//using Windows.Storage;
//using System.IO;

//[assembly: Dependency(typeof(DataBaseAccess))]
//namespace RealApp.UWP
//{
//    public class DataBaseAccess : IDatabaseAccess
//    {
//        public SQLiteConnection DbConnection()
//        {
//            var dbName = "CustomersDb.db3";
//            var path = Path.Combine(ApplicationData.
//              Current.LocalFolder.Path, dbName);
//            return new SQLiteConnection(path);
//        }
//    }
//}
