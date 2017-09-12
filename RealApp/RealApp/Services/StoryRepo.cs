using RealApp.Models;
using RealApp.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealApp.Services
{
    public class StoryRepo : LocalRepo<Story>
    {
        public StoryRepo() : base(App.DbConnection)
        {
            App.DbConnection.CreateTableAsync<Story>();
        }
    }
}
