using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AppDemo.Models.HandleModel;

namespace AppDemo.Controllers.HandleController
{
    public abstract class AbstractHandleController
    {
        protected AbstractHandleData hdl_data;
        protected string _urlDB;

        public abstract DataTable ReadDataFirstTime(string nameTable);

        public abstract string GetPrimaryKey(string nameTable);

        public abstract DataTable ReadData(string nameTable);

        public abstract bool AddData(Dictionary<string, string> data, string nameTable);

        public abstract bool UpdateData(Dictionary<string, string> data, string nameTable, string primaryKey);

        public abstract bool DeleteData(Dictionary<string, string> data, string nameTable, string primaryKey);

        public abstract bool InitData(string nameTable);
    }
}
