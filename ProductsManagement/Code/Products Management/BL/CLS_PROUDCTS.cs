using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Products_Management.BL
{
    class CLS_PROUDCTS
    {
        public DataTable GET_ALL_CATEGORTES()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("GET_ALL_CATEGORTES", null);
            DAL.Close();
            return dt;
        }
       
        public void ADD_PROUDCT(int ID_CAT, string Label_Proudct, string ID_Proudct, int Qte, string Price, byte[] img)
        {

            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.Open();
            SqlParameter[] parm = new SqlParameter[6];
            parm[0] = new SqlParameter("@ID_CAT", SqlDbType.Int);
            parm[0].Value = ID_CAT;

            parm[1] = new SqlParameter("@ID_PROUDCT", SqlDbType.VarChar, 30);
            parm[1].Value = ID_Proudct;

            parm[2] = new SqlParameter("@Label", SqlDbType.VarChar, 30);
            parm[2].Value = Label_Proudct;

            parm[3] = new SqlParameter("@Qte", SqlDbType.Int);
            parm[3].Value = Qte;

            parm[4] = new SqlParameter("@Price", SqlDbType.VarChar, 30);
            parm[4].Value = Price;

            parm[5] = new SqlParameter("@IMG", SqlDbType.Image);
            parm[5].Value = img;

            DAL.ExecuteCommand("ADD_PROUDCT", parm);
            DAL.Close();

        }



        public void UPDATE_PRODUCT(int ID_CAT, string Label_Proudct, string ID_Proudct, int Qte, string Price, byte[] img)
        {

            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.Open();
            SqlParameter[] parm = new SqlParameter[6];
            parm[0] = new SqlParameter("@ID_CAT", SqlDbType.Int);
            parm[0].Value = ID_CAT;

            parm[1] = new SqlParameter("@ID_PROUDCT", SqlDbType.VarChar, 30);
            parm[1].Value = ID_Proudct;

            parm[2] = new SqlParameter("@Label", SqlDbType.VarChar, 30);
            parm[2].Value = Label_Proudct;

            parm[3] = new SqlParameter("@Qte", SqlDbType.Int);
            parm[3].Value = Qte;

            parm[4] = new SqlParameter("@Price", SqlDbType.VarChar, 30);
            parm[4].Value = Price;

            parm[5] = new SqlParameter("@IMG", SqlDbType.Image);
            parm[5].Value = img;

            DAL.ExecuteCommand("UPDATE_PRODUCT", parm);
            DAL.Close();

        }
        public DataTable verifyProductID(string ID)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            param[0].Value = ID;
            dt = DAL.SelectData("verifyProductID", param);
            DAL.Close();
            return dt;
        }

        public DataTable GET_ALL_PRODUCTS()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("GET_ALL_PRODUCTS", null);
            DAL.Close();
            return dt;
        }

        public DataTable SearchProduct(string ID)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            param[0].Value = ID;
            dt = DAL.SelectData("SearchProduct", param);
            DAL.Close();
            return dt;
        }

        public void DeleteProduct(String ID)
        {

            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.Open();
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            parm[0].Value = ID;



            DAL.ExecuteCommand("DeleteProduct", parm);
            DAL.Close();

        }

        public DataTable GET_IMAGE_PRODUCT(string ID)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            param[0].Value = ID;
            dt = DAL.SelectData("GET_IMAGE_PRODUCT", param);
            DAL.Close();
            return dt;
        }

    }
}
