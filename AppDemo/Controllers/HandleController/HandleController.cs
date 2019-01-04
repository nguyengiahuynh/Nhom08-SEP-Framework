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

        public DataTable ReadDataFirstTime(string nameTable)
        {
            string sql = "select * from " + nameTable;
            DataTable result = this.hdl_data.getData(sql);
            return result;
        }

        public DataTable ReadData(string nameTable)
        {
            string sql = "select * from " + nameTable + " where isDelete <> 1";
            DataTable result = this.hdl_data.getData(sql);
            return result;
        }

        public bool AddData(Dictionary<string, string> data, string nameTable)
        {
            string sql = "insert into " + nameTable + " values(";
            for (int i = 0; i < data.Count; i++)
            {
                if(i < data.Count - 1)
                {
                    sql += ("N'" + data.ElementAt(i).Value + "', ");
                }
                else
                {
                    sql += ("N'" + data.ElementAt(i).Value + "', 0)");
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

        public bool UpdateData(Dictionary<string, string> data, string nameTable, string primaryKey)
        {
            string sql = "update " + nameTable + " set ";
            for (int i = 0; i < data.Count; i++)
            {
                if(data.ElementAt(i).Key != primaryKey)
                {
                    if (i < data.Count - 1)
                    {
                        sql += (data.ElementAt(i).Key + " = '" + data.ElementAt(i).Value + "', ");
                    }
                    else
                    {
                        sql += (data.ElementAt(i).Key + " = ' " + data.ElementAt(i).Value + "'");
                    }
                }
            }
            sql += " where " + primaryKey + " = " + data[primaryKey];

            try
            {
                hdl_data.executeData(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        public bool DeleteData(Dictionary<string, string> data, string nameTable, string primaryKey)
        {
            string sql = "update " + nameTable + " set ";
            for (int i = 0; i < data.Count; i++)
            {
                if (data.ElementAt(i).Key != primaryKey)
                {
                    if (i < data.Count - 1)
                    {
                        sql += (data.ElementAt(i).Key + " = '" + data.ElementAt(i).Value + "', ");
                    }
                    else
                    {
                        sql += (data.ElementAt(i).Key + " = ' " + data.ElementAt(i).Value + "', isDelete = 1");
                    }
                }
            }
            sql += " where " + primaryKey + " = " + data[primaryKey];

            try
            {
                hdl_data.executeData(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        public HandleController(string url)
        {
            this.hdl_data = new HandleData(url);
            this._urlDB = url;
        }

        public bool InitData(string nameTable)
        {
            string sql = "alter table " + nameTable + " add isDelete bit not null default 0";

            try
            {
                hdl_data.executeData(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }
    }
}

