using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace mclpub
{
    public class AtpMatp_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet GetClass2(int cls2_cls1id)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT * FROM c4_class2 WHERE cls2_cls1id=@cls2_cls1id");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@cls2_cls1id", cls2_cls1id);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }


        public DataSet GetClass3(int cls3_cls1id, int cls3_cls2id)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT cls3_cls1id, cls3_cls2id, cls3_cls3id, cls3_cname, ");
            sb.Append(@"CASE WHEN LEN(cls3_cls1id)=1 THEN '0'+CONVERT(CHAR(1), cls3_cls1id) ELSE CONVERT(CHAR(2), cls3_cls1id) END + ");
            sb.Append(@"CASE WHEN LEN(cls3_cls2id)=1 THEN '0'+CONVERT(CHAR(1), cls3_cls2id) ELSE CONVERT(CHAR(2), cls3_cls2id) END + ");
            sb.Append(@"CASE WHEN LEN(cls3_cls3id)=1 THEN '0'+CONVERT(CHAR(1), cls3_cls3id) ELSE CONVERT(CHAR(2), cls3_cls3id) END AS cls3_cls123id ");
            sb.Append(@"FROM c4_class3 WHERE cls3_cls1id=@cls3_cls1id AND cls3_cls2id=@cls3_cls2id");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@cls3_cls1id", cls3_cls1id);
            oCmd.Parameters.AddWithValue("@cls3_cls2id", cls3_cls2id);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }


        public DataSet GetAtpMtps(string cls_contno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT cls_contno, cls_cls1id, cls_cls2id, cls_cls3id, ");
            sb.Append(@"CASE WHEN LEN(cls_cls1id)=1 THEN '0'+CONVERT(CHAR(1), cls_cls1id) ELSE CONVERT(CHAR(2), cls_cls1id) END + ");
            sb.Append(@"CASE WHEN LEN(cls_cls2id)=1 THEN '0'+CONVERT(CHAR(1), cls_cls2id) ELSE CONVERT(CHAR(2), cls_cls2id) END + ");
            sb.Append(@"CASE WHEN LEN(cls_cls3id)=1 THEN '0'+CONVERT(CHAR(1), cls_cls3id) ELSE CONVERT(CHAR(2), cls_cls3id) END AS cls_cls123id ");
            sb.Append(@"FROM c4_classes WHERE cls_contno=@cls_contno");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@cls_contno", cls_contno);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }


        public void SaveAtpMtps(string contno, object[] objs)
        {

            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"DELETE FROM c4_classes WHERE cls_contno=@contno";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@contno", contno);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
            for (int i = 0; i < objs.Length; i++)
            {
                InsertC4_classes(contno, ((AMEntry)objs.GetValue(i)).Cls1Id.ToString(), ((AMEntry)objs.GetValue(i)).Cls2Id.ToString(), ((AMEntry)objs.GetValue(i)).Cls3Id.ToString());
            }
        }


        public void InsertC4_classes(string contno,string Istr0,string Istr1,string Istr2)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"INSERT INTO c4_classes (cls_contno,cls_cls1id,cls_cls2id,cls_cls3id) VALUES (@contno,@Istr0,@Istr1,@Istr2)";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@contno", contno);
            oCmd.Parameters.AddWithValue("@Istr0", Istr0);
            oCmd.Parameters.AddWithValue("@Istr1", Istr1);
            oCmd.Parameters.AddWithValue("@Istr2", Istr2);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }
    }
}
