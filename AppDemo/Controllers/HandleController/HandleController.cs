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
    public class HandleController : AbstractHandleController
    {
        public override DataTable ReadDataFirstTime(string nameTable)
        {
            string sql = "select * from " + nameTable;
            DataTable result = this.hdl_data.getData(sql);
            return result;
        }

        public override string GetPrimaryKey(string nameTable)
        {
            string sql = "SELECT u.COLUMN_NAME, c.CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS c INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS u ON c.CONSTRAINT_NAME = u.CONSTRAINT_NAME where u.TABLE_NAME = '" + nameTable + "' AND c.TABLE_NAME = '" + nameTable + "' and c.CONSTRAINT_TYPE = 'PRIMARY KEY'";
            DataTable result = this.hdl_data.getData(sql);
            return result.Rows[0].Field<string>(0);
        }

        public override DataTable ReadData(string nameTable)
        {
            string sql = "select * from " + nameTable + " where isDelete <> 1";
            DataTable result = this.hdl_data.getData(sql);
            return result;
        }

        public override bool AddData(Dictionary<string, string> data, string nameTable)
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

        public override bool UpdateData(Dictionary<string, string> data, string nameTable, string primaryKey)
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

        public override bool DeleteData(Dictionary<string, string> data, string nameTable, string primaryKey)
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

        public override bool InitData(string nameTable)
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

