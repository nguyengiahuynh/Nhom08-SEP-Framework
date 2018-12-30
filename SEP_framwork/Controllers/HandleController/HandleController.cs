using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SEP_framwork.Models.HandleModel;

namespace SEP_framwork.Controllers.HandleController
{
    public class HandleController
    {
        private HandleData hdl_data;
        private string _urlDB;

        public DataTable ReadData(string nameTable)
        {
            string sql = "select * from " + nameTable;
            DataTable result = this.hdl_data.getData(sql);
            return result;
        }

        public bool AddData(Dictionary<string, string> data, string nameTable)
        {
            string sql = $"insert into {nameTable} values(";
            for (int i = 0; i < data.Count; i++)
            {
                if(i < data.Count - 1)
                {
                    sql += ("N'" + data.ElementAt(i).Value + "', ");
                }
                else
                {
                    sql += ("N'" + data.ElementAt(i).Value + "')");
                }
            }
            
            try
            {
                hdl_data.executeData(sql);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return true;
        }

        //protected bool UpdateData()
        //{
        //    sql = "insert ";
        //    return true;
        //}
        //protected bool DeleteData()
        //{
        //    sql = "insert ";
        //    return true;
        //}

        public HandleController(string url)
        {
            this.hdl_data = new HandleData(url);
            this._urlDB = url;
        }
    }
}

