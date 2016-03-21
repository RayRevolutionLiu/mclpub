using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;


namespace mclpub
{
    public class SetSAPManage_DB
    {

        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"].ToString();

        public DataTable SelectComp(string sysoc)
        {


            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            //sb.Append(@"SELECT mfr_mfrid, mfr_mfrno, mfr_inm FROM mfr WHERE 1=1 ");

            sb.Append(@"SELECT TOP 1000 * FROM mclpub.dbo.ia ");

            if (sysoc.ToString() != "")
            {
                sb.Append(@"and ia_syscd=@sysoc ");
            }

            /*
            if (company.ToString() != "")
            {
                sb.Append(@"and mfr_inm=@company ");
            }

            */
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataTable ds = new DataTable();

            oCmd.Parameters.AddWithValue("@sysoc", sysoc);

            oda.Fill(ds);
            return ds;

        }

        public DataTable SelectC1cust(string sysoc, string fgitri)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();

            sb.Append(@"SELECT *, ");
            sb.Append(@"CASE ia_invcd WHEN '2' THEN '二聯式' WHEN '3' THEN '三聯式' WHEN '4' THEN '其他' ELSE '' END AS ia_invcdN,");
            sb.Append(@"CASE ia_taxtp WHEN '1' THEN '應稅' WHEN '2' THEN '零稅' WHEN '3' THEN '免稅' ELSE '' END AS ia_taxtpN,");
            sb.Append(@"CASE ia_fgitri WHEN '06' THEN '所內委託' WHEN '07' THEN '院內往來' ELSE '' END AS ia_fgitriN ");
            //sb.Append(@"");
            sb.Append(@"FROM ia AS a JOIN mfr AS b ON a.ia_mfrno = b.mfr_mfrno WHERE a.ia_status='' and a.ia_fgitri=@fgitri ");
            // SELECT * FROM ia AS a JOIN mfr AS b ON a.ia_mfrno = b.mfr_mfrno
           
            if (sysoc.ToString() != "")
            {
                sb.Append(@"and a.ia_syscd=@sysoc ");
            }

            sb.Append(@"ORDER BY a.ia_iano ASC ");
             
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataTable ds = new DataTable();

            oCmd.Parameters.AddWithValue("@sysoc", sysoc);
            oCmd.Parameters.AddWithValue("@fgitri", fgitri);

            oda.Fill(ds);
            return ds;

        }

        public int getNext(string sysoc, string fgitri, string nowym)
        {
            //新增SQL 指令
            SqlCommand oCmd = new SqlCommand();

            //新增SQL指令的連線
            oCmd.Connection = new SqlConnection(Conn);

            //設定資料讀取
            SqlDataReader dr = null;

            //設定SQL指令
            oCmd = new SqlCommand("SELECT  max(ias.ias_iasseq) as ias_iasseq FROM ias WHERE ( ias.ias_syscd = @sysoc ) AND ( ias.ias_iasdate = @nowym ) GROUP BY ias.ias_syscd,ias.ias_iasdate", oCmd.Connection);

            oCmd.Parameters.AddWithValue("@sysoc", sysoc); //系統代號
            //oCmd.Parameters.AddWithValue("@fgitri", fgitri); //往來種類
            oCmd.Parameters.AddWithValue("@nowym", nowym); //年月
            

            //資料庫連線
            oCmd.Connection.Open();

            //執行資料庫指令
            dr = oCmd.ExecuteReader();

            //讀取一筆資料
            dr.Read();

            int maxBatch = 0;

            //空值處理
            if (!dr.HasRows)
            {

                string oc = sysoc;

                if (oc == "C1")
                {
                    maxBatch = 11000;
                }

                if (oc == "C2")
                {
                    maxBatch = 12000;
                }

                if (oc == "C3")
                {
                    maxBatch = 14000;
                }

                if (oc == "C4")
                {
                    maxBatch = 16000;
                }

            }
            else {
                 maxBatch = Convert.ToInt32(dr["ias_iasseq"]);  //最大批號
            }
          

            int nextBatch = maxBatch + 1;   //下一個批號

            //將所查詢的結果回傳
            return nextBatch;
        
        }

        public int getId()
        {
            //新增SQL 指令
            SqlCommand oCmd2 = new SqlCommand();
            //新增SQL指令的連線
            oCmd2.Connection = new SqlConnection(Conn);

            //設定資料讀取
            SqlDataReader dr = null;

            //設定SQL指令
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 [ias_iasid] FROM [mclpub].[dbo].[ias] ORDER BY [ias_iasid] DESC", oCmd2.Connection);

            //資料庫連線
            oCmd2.Connection.Open();
            //執行資料庫指令
            dr = cmd.ExecuteReader();

            //讀取一筆資料
            dr.Read();

            //將所查詢的結果 回傳頁面
            int maxId = Convert.ToInt32(dr["ias_iasid"]);  //最大ID
            int nextId = maxId + 1;   //下一個ID

            return nextId;

        }

        //系統下拉選單
        public DataTable syscdDrpdownList()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT [sys_syscd] ,[sys_nm] FROM [mclpub].[dbo].[syscd]");
           
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
           
            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;

        }

        //系統下拉選單
        public DataTable fgitriDrpdownList()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT [fgitri_fgitri],[fgitri_name] FROM [mclpub].[dbo].[fgitri]");

            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);

            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;

        }

    }
}