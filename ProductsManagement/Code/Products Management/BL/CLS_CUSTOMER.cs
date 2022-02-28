using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;// to => datatable  , dataset
using System.Data.SqlClient;// to object connection and dataAdabter 


namespace Products_Management.BL
{
    class CLS_CUSTOMER
    {

        public void ADD_CUSTOMER(String FirstName, string LastName, string Tel,  string Email, byte[] Picture,string Criterion)
        {

            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.Open();
            SqlParameter[] parm = new SqlParameter[6];
            parm[0] = new SqlParameter("@FIRST_NAME", SqlDbType.VarChar,25);
            parm[0].Value = FirstName;

            parm[1] = new SqlParameter("@LAST_NAME", SqlDbType.VarChar,25 );
            parm[1].Value = LastName;

            parm[2] = new SqlParameter("@tel", SqlDbType.NVarChar, 15);
            parm[2].Value = Tel;

            parm[3] = new SqlParameter("@Email", SqlDbType.VarChar, 25);
            parm[3].Value = Email;

            parm[4] = new SqlParameter("@Picrure", SqlDbType.Image);
            parm[4].Value = Picture;

            parm[5] = new SqlParameter("@Criterion", SqlDbType.VarChar,50);
            parm[5].Value = Criterion;

            DAL.ExecuteCommand("ADD_CUSTOMER", parm);
            DAL.Close();

        }

        public void EDIT_CUSTOMER(String FirstName, string LastName, string Tel, string Email, byte[] Picture, string Criterion,int id)
        {

            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.Open();
            SqlParameter[] parm = new SqlParameter[7];
            parm[0] = new SqlParameter("@FIRST_NAME", SqlDbType.VarChar, 25);
            parm[0].Value = FirstName;

            parm[1] = new SqlParameter("@LAST_NAME", SqlDbType.VarChar, 25);
            parm[1].Value = LastName;

            parm[2] = new SqlParameter("@tel", SqlDbType.NVarChar, 15);
            parm[2].Value = Tel;

            parm[3] = new SqlParameter("@Email", SqlDbType.VarChar, 25);
            parm[3].Value = Email;

            parm[4] = new SqlParameter("@Picrure", SqlDbType.Image);
            parm[4].Value = Picture;

            parm[5] = new SqlParameter("@Criterion", SqlDbType.VarChar, 50);
            parm[5].Value = Criterion;

            parm[6] = new SqlParameter("@id", SqlDbType.Int);
            parm[6].Value = id;

            DAL.ExecuteCommand("EDIT_CUSTOMER", parm);
            DAL.Close();

        }

        public void Delete_Customer( int id)
        {

            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.Open();
            SqlParameter[] parm = new SqlParameter[1];
        
            parm[6] = new SqlParameter("@id", SqlDbType.Int);
            parm[6].Value = id;

            DAL.ExecuteCommand("Delete_Customer", parm);
            DAL.Close();

        }


        ////////////////////to  fill groupbpox////////////
        public DataTable GET_ALL_CUSTOMERS()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("GET_ALL_CUSTOMERS", null);
            DAL.Close();
            return dt;
        }

        public DataTable Search_Customer(String Criterion)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            SqlParameter[] param=new SqlParameter[1];
            param[0] = new SqlParameter("@Criterion",SqlDbType.VarChar,50);
            param[0].Value = Criterion;
            dt = DAL.SelectData("Search_Customer", param);
            DAL.Close();
            return dt;
        }
    }
}
