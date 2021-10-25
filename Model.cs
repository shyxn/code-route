using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace code_route
{
    public class Model
    {
        private SQLite _sqliteModel;
        public Model()
        {
            this._sqliteModel = new SQLite();
        }
        public void ReadAllTable()
        {
            SQLiteConnection connection = this._sqliteModel.CreateConnection();
            this._sqliteModel.ReadData(connection);
        }
    }
}
