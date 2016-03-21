using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace MRLPub.d5
{
	/// <summary>
	/// Summary description for mfr_addnew.
	/// </summary>
	public class mfr_addnew : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox mfr_inm;
		protected System.Web.UI.WebControls.TextBox mfr_respjbti;
		protected System.Web.UI.WebControls.TextBox mfr_iaddr;
		protected System.Web.UI.WebControls.TextBox mfr_mfrno;
		protected System.Web.UI.WebControls.TextBox mfr_regdate;
		protected System.Web.UI.WebControls.TextBox mfr_tel;
		protected System.Web.UI.WebControls.TextBox mfr_fax;
		protected System.Web.UI.WebControls.TextBox mfr_izip;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator5;
		protected System.Web.UI.WebControls.TextBox mfr_respnm;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button btnReturnHome;
		protected System.Web.UI.WebControls.DropDownList ddlmfr_type;
		protected System.Web.UI.WebControls.Label lblmfr_mfrno;
		protected System.Web.UI.WebControls.Label lblmfr_inm;
		protected System.Web.UI.WebControls.Button btnAddNew;
		DateTime TodayDate;
	
		public mfr_addnew()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				TodayDate = System.DateTime.Today;
				this.mfr_regdate.Text = TodayDate.ToString("yyyyMMdd");
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
			this.ddlmfr_type.SelectedIndexChanged += new System.EventHandler(this.ddlmfr_type_SelectedIndexChanged);
			this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
			this.btnReturnHome.Click += new System.EventHandler(this.btnReturnHome_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		
		private void btnAddNew_Click(object sender, System.EventArgs e)
		{
			string strConn = System.Configuration.ConfigurationSettings.AppSettings["mrlpub1"].ToString();
			SqlConnection myConn=new SqlConnection(strConn);
			string SQL = "select * from mfr";
			SqlDataAdapter myCommand = new SqlDataAdapter(SQL,myConn);

			DataSet ds1 = new DataSet();
			myCommand.Fill(ds1,"Title");

			DataView dv = ds1.Tables["Title"].DefaultView;
			dv.RowFilter = "mfr_mfrno = '" + mfr_mfrno.Text.Trim() +"'";

			//DataGrid1.DataSource = dv;
			//DataGrid1.DataBind();

			if (dv.Count > 0)
			{
				Label1.Text="此筆資料已經存在!";
			}
			
			else
			{
				SqlDataAdapter cmd=new SqlDataAdapter
					("insert into mfr(mfr_mfrno,mfr_inm,mfr_iaddr,mfr_izip,mfr_respnm,mfr_respjbti,mfr_tel,mfr_fax,mfr_regdate) values(@mfr_mfrno,@mfr_inm,@mfr_iaddr,@mfr_izip,@mfr_respnm,@mfr_respjbti,@mfr_tel,@mfr_fax,@mfr_regdate)",myConn);
		
				//cmd.SelectCommand.Parameters.Add("@mfr_mfrid",SqlDbType.Int,4).Value=mfr_mfrid.Text;
				cmd.SelectCommand.Parameters.Add("@mfr_mfrno",SqlDbType.Char,10).Value=mfr_mfrno.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@mfr_inm",SqlDbType.Char,50).Value=mfr_inm.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@mfr_iaddr",SqlDbType.Char,1000).Value=mfr_iaddr.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@mfr_izip",SqlDbType.Char,5).Value=mfr_izip.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@mfr_respnm",SqlDbType.Char,30).Value=mfr_respnm.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@mfr_respjbti",SqlDbType.VarChar,12).Value=mfr_respjbti.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@mfr_tel",SqlDbType.VarChar,30).Value=mfr_tel.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@mfr_fax",SqlDbType.VarChar,30).Value=mfr_fax.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@mfr_regdate",SqlDbType.Char,8).Value=mfr_regdate.Text.Trim();
			
				DataSet ds = new DataSet();
				cmd.Fill(ds,"Title");
			
				Response.Redirect("mfr.aspx?ID=addnew_ok");
			}
		}

		private void btnReturnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("mfr.aspx");
		}

		private void ddlmfr_type_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string id = ddlmfr_type.SelectedItem.Value.ToString();

			if (id=="A")
			{
				this.lblmfr_mfrno.Text= "統一發票編號";
				this.mfr_mfrno.Text = "";
				this.mfr_mfrno.ReadOnly = false;
				this.mfr_mfrno.BackColor=System.Drawing.Color.White;
				this.lblmfr_inm.Text = "發票抬頭";
			}

			if (id=="B")
			{
				this.lblmfr_mfrno.Text = "身份證字號";
				this.mfr_mfrno.Text = "";
				this.mfr_mfrno.ReadOnly = false;
				this.mfr_mfrno.BackColor=System.Drawing.Color.White;
				this.lblmfr_inm.Text = "姓名";
			}

			if (id=="C")
			{
				this.lblmfr_mfrno.Text = "資料編號";

				//編號起始值為末值加一
				string strConn = System.Configuration.ConfigurationSettings.AppSettings["mrlpub1"].ToString();
				SqlConnection myConn=new SqlConnection(strConn);
				SqlDataAdapter cmd0=new SqlDataAdapter("select count(*) as C1,max(mfr_mfrno) as MaxCountNo from mfr where mfr_mfrno like '%AA%'",myConn);

				string strAssignedContNo = "";
				
				DataSet ds0 = new DataSet();
				cmd0.Fill(ds0, "mfr");
				DataView dv0 = ds0.Tables["mfr"].DefaultView;
				
				if (dv0.Count > 0 && dv0[0]["C1"].ToString() != "0")
				{
					string MaxCountNo = dv0[0]["MaxCountNo"].ToString().Trim();
					string MaxCountNoInt = MaxCountNo.Substring(2,5);

					strAssignedContNo = Convert.ToString(Convert.ToInt32(MaxCountNoInt)+1);

					int ZeroLength = 5 - strAssignedContNo.Length;
					
					for (int i=0; i<ZeroLength; i++)
					{
						strAssignedContNo = "0" + strAssignedContNo;
					}
					strAssignedContNo = "AA" + strAssignedContNo;
				}
				
				else
				{
					strAssignedContNo += "AA00001"; 
				}

				this.mfr_mfrno.Text = strAssignedContNo;
				this.mfr_mfrno.ReadOnly = true;
				this.mfr_mfrno.BackColor=System.Drawing.Color.Gainsboro;
				
				this.lblmfr_inm.Text = "姓名";
			}
		}
	}
}
