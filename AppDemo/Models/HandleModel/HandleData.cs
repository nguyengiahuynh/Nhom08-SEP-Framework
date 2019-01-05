using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AppDemo.Models.HandleModel
{
    public class HandleData : AbstractHandleData
    {
        public HandleData(string url)
        {
            this.connect = new SqlConnection(url);
        }

        public override DataTable getData(string sql)
        {
            this.connect.Open();
            try
            {
                SqlDataAdapter adapt = new SqlDataAdapter(sql, this.connect);

                DataTable table_data = new DataTable();
                adapt.Fill(table_data);
                this.connect.Close();
                return table_data;
            }
            catch (Exception ex)
            {
                this.connect.Close();
                throw ex;
            }
        }

        public override int executeData(string sql)
        { 
            SqlCommand sql_query = new SqlCommand(sql, this.connect);
            this.connect.Open();
            int result = 1;
            try
            {
                result = sql_query.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                this.connect.Close();
                throw ex;
            }

            this.connect.Close();
            return result;
        }

        public override bool isExist(string sql)
        {
            SqlCommand lenh = new SqlCommand(sql, this.connect);
            this.connect.Open();

            SqlDataReader dr = lenh.ExecuteReader();

            if (dr.Read() == true)
            {
                this.connect.Close();
                return true;
            }
            else
            {
                this.connect.Close();
                return false;
            }
        }
    }
}




