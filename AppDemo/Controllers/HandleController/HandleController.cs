using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SEP_framwork.Models.HandleModel;
using SEP_framwork.Utils;

namespace SEP_framwork.Controllers.HandleController
{
    public class HandleController
    {
        private HandleData hdl_data;

        public HandleController(string url)
        {
            this.hdl_data = new HandleData(url);
        }

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

        private bool isExistSession()
        {
            var checkTable = "SELECT * FROM INFORMATION_SCHEMA.TABLES Where Table_Schema = 'dbo'  AND Table_Name = 'Session'";
            DataTable dataTable = hdl_data.getData(checkTable);
            return dataTable.Rows.Count != 0;
        }

        public void createSessionTable()
        {
            if (!isExistSession())
            {
                var createTable = "create table Session(username varchar(30), password varchar(30),isLogin bit,ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY)";
                hdl_data.executeData(createTable);
            }
        }

        public bool isExist(string username)
        {
            var check = string.Format("select * from Session where username = '{0}'", username);
            var dt = hdl_data.getData(check);
            return dt.Rows.Count != 0;
        }

        public bool Authen(string username, string password)
        {
            var authen = string.Format("select * from Session where username = '{0}'", username);
            DataTable data = hdl_data.getData(authen);
            if (data.Rows.Count != 0)
            {
                string u = data.Rows[0][0].ToString();
                string p = Crypto.Decrypt(data.Rows[0][1].ToString());
                return username == u && password == p;
            }
            return false;
        }

        public bool Login(string username, string password)
        {
            if (Authen(username, password))
            {
                var login = string.Format("Update Session Set isLogin = 'true' where username ='{0}'", username);
                if (hdl_data.executeData(login) != 0)
                    return true;
            }
            return false;
        }

        public bool Register(string username, string password)
        {
            if (isExist(username)) return false;
            var insert = string.Format("insert into Session values('{0}','{1}','false')", username, Crypto.Encrypt(password));
            if (hdl_data.executeData(insert) != 0)
                return true;
            return false;
        }

        public bool Logout(string username)
        {
            var logout = string.Format("Update Session Set isLogin = 'false' where username ='{0}'", username);
            if (hdl_data.executeData(logout) != 0)
                return true;
            return false;
        }
    }
}

