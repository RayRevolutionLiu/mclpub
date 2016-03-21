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
// SQL
using System.Data.SqlClient;
namespace MRLPub.d2
{
	/// <summary>
	/// Summary description for adlayout_addnew.
	/// </summary>
	public class adlayout_addnew : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox ltp_ltpcd;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox ltp_nm;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.Button btnReturnHome;
	
		public adlayout_addnew()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				String strConn="server=isccom1;database=mrlpub;uid=webuser;pwd=db600";
				SqlConnection myConn=new SqlConnection(strConn);
				
				//起始值為末值加一
				SqlDataAdapter cmd=new SqlDataAdapter("select count(*) as CountNo,max(ltp_ltpcd) as MaxCountNo from c2_ltp",myConn);

				string strAssignedNewCode = "";
				//string strAssignedNewCode = Convert.ToString(System.DateTime.Today.Year-1911);
				DataSet ds = new DataSet();
				cmd.Fill(ds, "c2_ltp");
				DataView dv = ds.Tables["c2_ltp"].DefaultView;

				if (dv.Count > 0 && dv[0]["CountNo"].ToString() != "0")
				{
					if (Convert.ToInt32((Convert.ToInt32(dv[0]["MaxCountNo"])+1)) < 10)
					{
						strAssignedNewCode = Convert.ToString("0"+(Convert.ToInt32(dv[0]["MaxCountNo"])+1));
					}
					else
					{
						strAssignedNewCode = Convert.ToString((Convert.ToInt32(dv[0]["MaxCountNo"])+1));
					}
				}
				else
				{
					strAssignedNewCode += "01"; 
				}

				ltp_ltpcd.Text = strAssignedNewCode;

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
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnReturnHome.Click += new System.EventHandler(this.btnReturnHome_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			String strConn="server=isccom1;database=mrlpub;uid=webuser;pwd=db600";
			SqlConnection myConn=new SqlConnection(strConn);
			string SQL = "select * from c2_ltp";
			SqlDataAdapter myCommand = new SqlDataAdapter(SQL,myConn);

			DataSet ds1 = new DataSet();
			myCommand.Fill(ds1,"c2_ltp");

			DataView dv = ds1.Tables["c2_ltp"].DefaultView;
			dv.RowFilter = "ltp_ltpcd = '" + ltp_ltpcd.Text.Trim() +"'";

			if (dv.Count > 0)
			{
				Label1.Text="此筆資料已經存在!";
			}
			
			else
			{
				SqlDataAdapter cmd=new SqlDataAdapter("insert into c2_ltp(ltp_ltpcd,ltp_nm) values(@ltp_ltpcd,@ltp_nm)",myConn);
		
				//cmd.SelectCommand.Parameters.Add("@ltp_ltpid",SqlDbType.Int,4).Value = ltp_ltpid.Text;
				cmd.SelectCommand.Parameters.Add("@ltp_ltpcd",SqlDbType.Char,2).Value = ltp_ltpcd.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@ltp_nm",SqlDbType.Char,10).Value = ltp_nm.Text.Trim();
						
				DataSet ds = new DataSet();
				cmd.Fill(ds,"c2_ltp");

				Response.Redirect("adlayout.aspx");
			}
			
		}


		private void btnReturnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("adlayout.aspx");
		}


	}
}
