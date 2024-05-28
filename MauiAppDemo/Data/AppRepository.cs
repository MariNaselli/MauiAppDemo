using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppDemo.Data
{
    public class AppRepository
    {
        string dbPath;
        
        private SQLiteConnection _connection;

        private void Init()
        {
            if (_connection is not null)
                return;
            _connection = new(dbPath);
        }
    }
}
