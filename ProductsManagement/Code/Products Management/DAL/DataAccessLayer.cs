using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace Products_Management.DAL
{
    class DataAccessLayer
    {
        SqlConnection Sqlconnection;
        public DataAccessLayer() {

            Sqlconnection = new SqlConnection("Server=.;Database=ProductDB;Integrated Security=true");
        }
        //Method to open The Connection
        public void Open() {

            if (Sqlconnection.State != ConnectionState.Open) {
                Sqlconnection.Open();

            }
        }

        //Method to Close The Connection
        public void Close()
        {

            if (Sqlconnection.State == ConnectionState.Open)
            {
                Sqlconnection.Close();

            }
        }

        //Method to read Data From DataBase
        public DataTable SelectData(String stored_Procedure, SqlParameter[] param) {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_Procedure;
            sqlcmd.Connection = Sqlconnection;
            if (param != null) {

                for (int i = 0; i < param.Length; i++) {

                    sqlcmd.Parameters.Add(param[i]);
                }
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        // Method to insert update and delete data from database
        public void ExecuteCommand(String stored_Procedure, SqlParameter[] param) {

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_Procedure;
            sqlcmd.Connection = Sqlconnection;
            if (param != null) {

                sqlcmd.Parameters.AddRange(param);
            }
            sqlcmd.ExecuteNonQuery();
            
       }


    }
}
