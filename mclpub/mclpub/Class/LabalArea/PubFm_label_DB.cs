using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace mclpub
{
    public class PubFm_label_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet SelectC2_cont()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT DISTINCT TOP 100 PERCENT dbo.c2_cont.cont_syscd, dbo.c2_cont.cont_contno, ");
            sb.Append(@"dbo.c2_cont.cont_conttp, CASE WHEN dbo.c2_cont.cont_conttp = '01' THEN '一般' ELSE");
            sb.Append(@" '推廣' END AS cont_conttpName, dbo.c2_cont.cont_bkcd, RTRIM(dbo.book.bk_nm) AS bk");
            sb.Append(@"_nm, dbo.c2_cont.cont_signdate, RTRIM(dbo.c2_cont.cont_empno) AS cont_empno, RTR");
            sb.Append(@"IM(dbo.c2_cont.cont_mfrno) AS cont_mfrno, dbo.c2_cont.cont_sdate, dbo.c2_cont.co");
            sb.Append(@"nt_edate, SUBSTRING(dbo.c2_cont.cont_sdate, 1, 4) + '/' + SUBSTRING(dbo.c2_cont.");
            sb.Append(@"cont_sdate, 5, 6) + '~' + SUBSTRING(dbo.c2_cont.cont_edate, 1, 4) + '/' + SUBSTR");
            sb.Append(@"ING(dbo.c2_cont.cont_edate, 5, 6) AS cont_sedate, dbo.c2_or.or_oritem, RTRIM(dbo");
            sb.Append(@".c2_or.or_inm) AS or_inm, RTRIM(dbo.c2_or.or_nm) AS or_nm, dbo.c2_or.or_mtpcd, R");
            sb.Append(@"TRIM(dbo.mtp.mtp_nm) AS mtp_nm, dbo.c2_or.or_pubcnt, RTRIM(dbo.srspn.srspn_cname");
            sb.Append(@") AS srspn_cname, dbo.c2_or.or_contno, dbo.c2_or.or_syscd, RTRIM(dbo.c2_or.or_zi");
            sb.Append(@"p) AS or_zip, RTRIM(dbo.c2_or.or_addr) AS or_addr, RTRIM(dbo.c2_or.or_jbti) AS o");
            sb.Append(@"r_jbti, RTRIM(dbo.bookp.bkp_pno) AS bkp_pno, dbo.c2_pub.pub_yyyymm, dbo.c2_or.or");
            sb.Append(@"_fgmosea FROM dbo.c2_cont INNER JOIN dbo.book ON dbo.c2_cont.cont_bkcd = dbo.boo");
            sb.Append(@"k.bk_bkcd INNER JOIN dbo.c2_or ON dbo.c2_cont.cont_syscd = dbo.c2_or.or_syscd AN");
            sb.Append(@"D dbo.c2_cont.cont_contno = dbo.c2_or.or_contno INNER JOIN dbo.mtp ON dbo.c2_or.");
            sb.Append(@"or_mtpcd = dbo.mtp.mtp_mtpcd INNER JOIN dbo.c2_pub ON dbo.c2_cont.cont_syscd = d");
            sb.Append(@"bo.c2_pub.pub_syscd AND dbo.c2_cont.cont_contno = dbo.c2_pub.pub_contno INNER JO");
            sb.Append(@"IN dbo.srspn ON dbo.c2_cont.cont_empno = dbo.srspn.srspn_empno INNER JOIN dbo.bo");
            sb.Append(@"okp ON dbo.c2_pub.pub_yyyymm = dbo.bookp.bkp_date AND dbo.c2_pub.pub_bkcd = dbo.");
            sb.Append(@"bookp.bkp_bkcd WHERE (dbo.c2_cont.cont_fgclosed = '0') AND (dbo.c2_cont.cont_fgc");
            sb.Append(@"ancel = '0') AND (dbo.c2_cont.cont_fgtemp = '0') ORDER BY dbo.c2_or.or_pubcnt, d");
            sb.Append(@"bo.c2_cont.cont_contno");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds, "c2_cont");
            return ds;

        }
    }
}