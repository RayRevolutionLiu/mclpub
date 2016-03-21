using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace mclpub
{
    public class PlaneCont_2_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataTable SelecPCGV2(string cont_custno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT c2_cont.cont_contid, c2_cont.cont_syscd, c2_cont.cont_contno, c2_cont.cont_custno, c2_cont.cont_conttp, c2_cont.cont_bkcd,");
            sb.Append(@" c2_cont.cont_signdate, c2_cont.cont_mfrno, c2_cont.cont_aunm, c2_cont.cont_autel, c2_cont.cont_fgclosed, c2_cont.cont_fgpayonce, ");
            sb.Append(@" book.bk_nm, book.bk_bkcd, mfr.mfr_inm, c2_cont.cont_disc, mfr.mfr_mfrno, c2_cont.cont_clrtm, c2_cont.cont_menotm, c2_cont.cont_getclrtm, ");
            sb.Append(@" c2_cont.cont_fgpubed, c2_cont.cont_sdate, c2_cont.cont_edate, c2_cont.cont_fgcancel, c2_cont.cont_fgtemp ");
            sb.Append(@" FROM c2_cont INNER JOIN book ON c2_cont.cont_bkcd = book.bk_bkcd ");
            sb.Append(@" INNER JOIN mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno WHERE cont_custno=@cont_custno ");
            sb.Append(@" ORDER BY c2_cont.cont_contno DESC");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataTable ds = new DataTable();
            oCmd.Parameters.AddWithValue("@cont_custno", cont_custno);
            oda.Fill(ds);
            return ds;

        }
    }
}
