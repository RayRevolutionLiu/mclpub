using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;

namespace MRLPub.d1
{
	/// <summary>
	/// Summary description for LostListFilter.
	/// </summary>
	public class LostListFilter : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox tbxLostDate1;
		protected System.Web.UI.WebControls.Button btnPrintList;
		protected System.Web.UI.WebControls.Literal Literal1;
		protected System.Web.UI.WebControls.TextBox tbxLostDate2;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.CheckBox cbx1;
		protected System.Web.UI.WebControls.CheckBox cbx2;
		protected System.Web.UI.WebControls.TextBox tbxOrderDate1;
		protected System.Web.UI.WebControls.TextBox tbxOrderDate2;
		protected System.Web.UI.WebControls.DropDownList ddlSent;
	
		public LostListFilter()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires=0;
			if (!IsPostBack)
			{
				tbxLostDate1.Text=System.DateTime.Today.ToString("yyyy/MM/dd");
				tbxLostDate2.Text=System.DateTime.Today.ToString("yyyy/MM/dd");
				tbxOrderDate1.Text=System.DateTime.Today.ToString("yyyy/MM/dd");
				tbxOrderDate2.Text=System.DateTime.Today.ToString("yyyy/MM/dd");
			}
		}

		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}

		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.ddlSent.SelectedIndexChanged += new System.EventHandler(this.ddlSent_SelectedIndexChanged);
			this.btnPrintList.Click += new System.EventHandler(this.btnPrintList_Click);
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "srspn", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("srspn_id", "srspn_id"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_empno", "srspn_empno"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_tel", "srspn_tel"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_atype", "srspn_atype"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_orgcd", "srspn_orgcd"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_deptcd", "srspn_deptcd"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_date", "srspn_date"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_pwd", "srspn_pwd")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT srspn_id, srspn_empno, srspn_cname, srspn_tel, srspn_atype, srspn_orgcd, s" +
				"rspn_deptcd, srspn_date, srspn_pwd FROM dbo.srspn";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlConnection1
			// 
//			this.sqlConnection1.ConnectionString = "data source=ISCCOM1;initial catalog=mrlpub;password=db600;persist security info=T" +
//				"rue;user id=webuser;workstation id=03212-840695;packet size=4096";
			this.sqlConnection1.ConnectionString = ConfigurationSettings.AppSettings["mrlpub2"].ToString();
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnPrintList_Click(object sender, System.EventArgs e)
		{
			string reg=User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1);
			DataSet	ds1=new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "srspn");
			DataView dv1 = ds1.Tables["srspn"].DefaultView;
			dv1.RowFilter="srspn_empno = '"+reg+"'";
			if(dv1.Count>0)
			{
				string	cname=dv1[0].Row["srspn_cname"].ToString().Trim();
				string	strbuf="lost_list.aspx?cname="+cname+"&status="+ddlSent.SelectedItem.Value;					
				if(cbx1.Checked)
					strbuf+="&date="+tbxLostDate1.Text+"~"+tbxLostDate2.Text;
				else
					strbuf+="&date=";
				if(cbx2.Checked)
					strbuf+="&o_date="+tbxOrderDate1.Text+"~"+tbxOrderDate2.Text;
				else
					strbuf+="&o_date=";
				Literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\");</script>";
			}
		}

		private void ddlSent_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			if(ddlSent.SelectedItem.Value=="C")
			{
				cbx1.Enabled=true;
				tbxLostDate1.Enabled=true;
				tbxLostDate2.Enabled=true;
			}
			else
			{
				cbx1.Checked=false;
				cbx1.Enabled=false;
				tbxLostDate1.Enabled=false;
				tbxLostDate2.Enabled=false;
			}

		}
	}
}
