using RealApp.Models;
using RealApp.Services.Base;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RealApp.Services
{
    public class ItemRepository
    {

        LocalRepo _LocalRepo;
        
        public ItemRepository()
        {
            SQLiteConnection DbConnection = DependencyService.Get<IDatabaseAccess>().GetConnection();

            DbConnection.CreateTable<Story>();
            DbConnection.CreateTable<Word>();

            _LocalRepo = new LocalRepo(DbConnection);
        }

        public LocalRepo LocalRepo => _LocalRepo;

    }
}
