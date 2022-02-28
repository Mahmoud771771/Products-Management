using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace Products_Management.BL
{
    class CLSLOGIN
    {
        public DataTable LOGIN(string ID, String PWD) {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            param[0].Value = ID;

            param[1] = new SqlParameter("@PWD", SqlDbType.VarChar, 50);
            param[1].Value = PWD;

            DAL.Open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("SP_LOGIN", param);
            DAL.Close();
            return dt;

        }

        public void ADD_USER(String ID, string FullName, string PWD, string UserType)
        {

            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.Open();
            SqlParameter[] parm = new SqlParameter[4];
            parm[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            parm[0].Value = ID;

            parm[1] = new SqlParameter("@FullName", SqlDbType.VarChar, 50);
            parm[1].Value = FullName;

            parm[2] = new SqlParameter("@PWD", SqlDbType.NVarChar, 50);
            parm[2].Value = PWD;

            parm[3] = new SqlParameter("@UserType", SqlDbType.VarChar, 50);
            parm[3].Value = UserType;

            

            DAL.ExecuteCommand("ADD_USER", parm);
            DAL.Close();

        }
        public void EDIT_USER(String ID, string FullName, string PWD, string UserType)
        {

            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.Open();
            SqlParameter[] parm = new SqlParameter[4];
            parm[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            parm[0].Value = ID;

            parm[1] = new SqlParameter("@FullName", SqlDbType.VarChar, 50);
            parm[1].Value = FullName;

            parm[2] = new SqlParameter("@PWD", SqlDbType.NVarChar, 50);
            parm[2].Value = PWD;

            parm[3] = new SqlParameter("@UserType", SqlDbType.VarChar, 50);
            parm[3].Value = UserType;



            DAL.ExecuteCommand("EDIT_USER", parm);
            DAL.Close();

        }

        public void DELETE_USER(String ID)
        {

            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.Open();
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            parm[0].Value = ID;

           

            DAL.ExecuteCommand("DELETE_USER", parm);
            DAL.Close();

        }
        public DataTable SearchUser(string Criterion)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Criterion", SqlDbType.VarChar, 50);
            param[0].Value = Criterion;


            dt = DAL.SelectData("SearchUser", param);
            DAL.Close();
            return dt;
        }
    }
}
