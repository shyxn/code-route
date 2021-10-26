using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace code_route
{
    public class Model
    {
        private SQLite _sqliteModel;
        private Controller _controller;
        private List<string[]> _allRoadSignsData;

        public List<string[]> AllRoadSignsData
        {
            get { return _allRoadSignsData; }
            set { _allRoadSignsData = value; }
        }

        public Controller Controller
        {
            get { return _controller; }
            set { _controller = value; }
        }

        public Model()
        {
            this._sqliteModel = new SQLite();
            this._allRoadSignsData = GetAllData();
            
        }
        public List<string[]> GetAllData()
        {
            SQLiteConnection connection = this._sqliteModel.CreateConnection();
            return this._sqliteModel.ReadData(connection);
        }
        public string[] GetCurrentRow(int index)
        {
            return this._allRoadSignsData[index];
        }
        public string[] GetFileNames()
        {
            string path = String.Format(Environment.CurrentDirectory + "\\assets\\allroadsigns");
            string[] filePaths = Directory.GetFiles(path);
            return filePaths;
        }
        public List<string> GetDBFileNames()
        {
            List<string> allDBFileNames = new List<string>();
            foreach (string[] record in this._allRoadSignsData)
            {
                allDBFileNames.Add(record[0]);
            }
            return allDBFileNames;
        }
    }
}
