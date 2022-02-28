using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Products_Management.BL
{
    class CLS_ORDERS
    {
        public DataTable GET_LAST_ORDER_ID()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("GET_LAST_ORDER_ID", null);
            DAL.Close();
            return dt;
        }

        public DataTable GET_LAST_ORDER_ID_forPrint()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("GET_LAST_ORDER_ID_forPrint", null);
            DAL.Close();
            return dt;
        }
        public void ADD_ORDER(int ID_ORDER, DateTime DATE_ORDER,int CUSTOMER_ID, string DESCRIOTION_ORDER, string SALESMAN)
        {

            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.Open();
            SqlParameter[] parm = new SqlParameter[5];
            parm[0] = new SqlParameter("@ID_ORDER", SqlDbType.Int);
            parm[0].Value = ID_ORDER;

            parm[1] = new SqlParameter("@DATE_ORDER", SqlDbType.DateTime);
            parm[1].Value = DATE_ORDER;

            
            parm[2] = new SqlParameter("@CUSTOMER_ID", SqlDbType.Int);
            parm[2].Value = CUSTOMER_ID;

            parm[3] = new SqlParameter("@DESCRIOTION_ORDER", SqlDbType.VarChar, 250);
            parm[3].Value = DESCRIOTION_ORDER;

            parm[4] = new SqlParameter("@SALESMAN", SqlDbType.VarChar,75);
            parm[4].Value = SALESMAN;

           

            DAL.ExecuteCommand("ADD_ORDER", parm);
            DAL.Close();

        }

        public void ADD_ORDER_DETAILS(string ID_PRODUCT, int ID_ORDER, int QTE, string PRICE, double DISCOUNT,string AMOUNT,string TOTAL_AMOUNT)
        {

            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.Open();
            SqlParameter[] parm = new SqlParameter[7];
            parm[0] = new SqlParameter("@ID_PRODUCT", SqlDbType.VarChar,30);
            parm[0].Value = ID_PRODUCT;

            parm[1] = new SqlParameter("@ID_ORDER", SqlDbType.Int);
            parm[1].Value = ID_ORDER;

            parm[2] = new SqlParameter("@QTE", SqlDbType.Int);
            parm[2].Value = QTE;

            parm[3] = new SqlParameter("@PRICE", SqlDbType.VarChar, 50);
            parm[3].Value = PRICE;

            parm[4] = new SqlParameter("@DISCOUNT", SqlDbType.Float);
            parm[4].Value = DISCOUNT;

            parm[5] = new SqlParameter("@AMOUNT", SqlDbType.VarChar, 50);
            parm[5].Value = AMOUNT;

            parm[6] = new SqlParameter("@TOTAL_AMOUNT", SqlDbType.VarChar, 50);
            parm[6].Value = TOTAL_AMOUNT;

            DAL.ExecuteCommand("ADD_ORDER_DETAILS", parm);
            DAL.Close();

        }


        public DataTable VerifyQTy(string ID_PRODUCT,int QTY_ENTERD  )
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ID_PRODUCT", SqlDbType.VarChar, 30);
            param[0].Value = ID_PRODUCT;

            param[1] = new SqlParameter("@QTY_Entered", SqlDbType.Int);
            param[1].Value = QTY_ENTERD;

            dt = DAL.SelectData("VerifyQTy", param);
            DAL.Close();
            return dt;
        }

        public DataTable GETORDERDETILS( int ID_ORDER)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID_ORDER", SqlDbType.Int);
            param[0].Value = ID_ORDER;


            dt = DAL.SelectData("GETORDERDETILS", param);
            DAL.Close();
            return dt;
        }

        public DataTable SearchOrders(string Criterion)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Criterion", SqlDbType.VarChar,50);
            param[0].Value = Criterion;


            dt = DAL.SelectData("SearchOrders", param);
            DAL.Close();
            return dt;
        }
    }
}
