using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDemo.Models.HandleModel
{
    public abstract class AbstractHandleData
    {
        protected string _urlDB;
        protected SqlConnection connect;

        public abstract DataTable getData(string sql);

        public abstract int executeData(string sql);

        public abstract bool isExist(string sql);
    }
}
