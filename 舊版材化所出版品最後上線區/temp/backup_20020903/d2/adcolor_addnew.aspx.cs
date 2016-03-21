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
	/// Summary description for adcolor_addnew.
	/// </summary>
	public class adcolor_addnew : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox clr_clrcd;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox clr_nm;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.Button btnReturnHome;
	
		public adcolor_addnew()
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
				SqlDataAdapter cmd=new SqlDataAdapter("select count(*) as CountNo,max(clr_clrcd) as MaxCountNo from c2_clr",myConn);

				string strAssignedNewCode = "";
				//string strAssignedContNo = Convert.ToString(System.DateTime.Today.Year-1911);
				DataSet ds = new DataSet();
				cmd.Fill(ds, "c2_clr");
				DataView dv = ds.Tables["c2_clr"].DefaultView;

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

				clr_clrcd.Text = strAssignedNewCode;

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
			string SQL = "select * from c2_clr";
			SqlDataAdapter myCommand = new SqlDataAdapter(SQL,myConn);

			DataSet ds1 = new DataSet();
			myCommand.Fill(ds1,"c2_clr");

			DataView dv = ds1.Tables["c2_clr"].DefaultView;
			dv.RowFilter = "clr_clrcd = '" + clr_clrcd.Text.Trim() +"'";

			if (dv.Count > 0)
			{
				Label1.Text="此筆資料已經存在!";
			}
			
			else
			{
				SqlDataAdapter cmd=new SqlDataAdapter("insert into c2_clr(clr_clrcd,clr_nm) values(@clr_clrcd,@clr_nm)",myConn);
		
				//cmd.SelectCommand.Parameters.Add("@clr_clrid",SqlDbType.Int,4).Value = clr_clrid.Text;
				cmd.SelectCommand.Parameters.Add("@clr_clrcd",SqlDbType.Char,2).Value = clr_clrcd.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@clr_nm",SqlDbType.Char,10).Value = clr_nm.Text.Trim();
						
				DataSet ds = new DataSet();
				cmd.Fill(ds,"c2_clr");

				Response.Redirect("adcolor.aspx");
			}
			
		}


		private void btnReturnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("adcolor.aspx");
		}


	}
}
