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
	public class cust_addnew : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator3;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator6;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator7;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator8;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator9;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator5;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox cust_custno;
		protected System.Web.UI.WebControls.TextBox cust_jbti;
		protected System.Web.UI.WebControls.TextBox cust_tel;
		protected System.Web.UI.WebControls.TextBox cust_fax;
		protected System.Web.UI.WebControls.TextBox cust_cell;
		protected System.Web.UI.WebControls.TextBox cust_regdate;
		protected System.Web.UI.WebControls.TextBox cust_email;
		protected System.Web.UI.WebControls.TextBox cust_oldcustno;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator10;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator11;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator12;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator13;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator1;
		protected System.Web.UI.WebControls.TextBox cust_nm;
		protected System.Web.UI.WebControls.Button btnAddNew;
		protected System.Web.UI.WebControls.DropDownList ddlcust_inm;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator3;
		protected System.Web.UI.WebControls.Button btnReturnHome;
		protected System.Web.UI.WebControls.CheckBoxList cblcust_btpcd;
		protected System.Web.UI.WebControls.CheckBoxList cblcust_rtpcd;
		protected System.Web.UI.WebControls.CheckBoxList cblcust_itpcd;
		protected System.Web.UI.WebControls.Label cust_mfrno;
		protected System.Web.UI.WebControls.Label cust_moddate;
		protected System.Web.UI.WebControls.Button btnRePick;
		protected System.Web.UI.WebControls.DropDownList ddlEmpNo;
		DateTime	TodayDate;
	
		public cust_addnew()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
				InitData();
		}

		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}

		private void InitData()
		{
			string id = Request.QueryString["ID"].ToString();
						
			string strConn3 = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
			SqlConnection myConn3=new SqlConnection(strConn3);
			
			//編號起始值為末值加一
			SqlDataAdapter cmd0=new SqlDataAdapter("select count(*) as C1,max(cust_custno) as MaxCountNo from cust",myConn3);

			string strAssignedContNo = "";
			DataSet ds0 = new DataSet();
			cmd0.Fill(ds0, "cust");
			DataView dv0 = ds0.Tables["cust"].DefaultView;
			
			if (dv0.Count <= 0)
			{
				Response.Redirect("nodata.aspx");
			}

			if (dv0.Count > 0 && dv0[0]["C1"].ToString() != "0")
			{
				if (Convert.ToInt32((Convert.ToInt32(dv0[0]["MaxCountNo"])+1)) < 10)
				{
					strAssignedContNo = Convert.ToString("00000"+(Convert.ToInt32(dv0[0]["MaxCountNo"])+1));
				}
				else if (Convert.ToInt32((Convert.ToInt32(dv0[0]["MaxCountNo"])+1)) < 100)
				{
					strAssignedContNo = Convert.ToString("0000"+(Convert.ToInt32(dv0[0]["MaxCountNo"])+1));
				}
				else if (Convert.ToInt32((Convert.ToInt32(dv0[0]["MaxCountNo"])+1)) < 1000)
				{
					strAssignedContNo = Convert.ToString("000"+(Convert.ToInt32(dv0[0]["MaxCountNo"])+1));
				}
				else if (Convert.ToInt32((Convert.ToInt32(dv0[0]["MaxCountNo"])+1)) < 10000)
				{
					strAssignedContNo = Convert.ToString("00"+(Convert.ToInt32(dv0[0]["MaxCountNo"])+1));
				}
				else if (Convert.ToInt32((Convert.ToInt32(dv0[0]["MaxCountNo"])+1)) < 100000)
				{
					strAssignedContNo = Convert.ToString("0"+(Convert.ToInt32(dv0[0]["MaxCountNo"])+1));
				}
				else
				{
					strAssignedContNo = Convert.ToString((Convert.ToInt32(dv0[0]["MaxCountNo"])+1));
				}
			}
			else
			{
				strAssignedContNo += "000001"; 
			}

			cust_custno.Text=strAssignedContNo;
			
			string strConn = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
			SqlConnection myConn=new SqlConnection(strConn);

			SqlDataAdapter cmd1=new SqlDataAdapter("select * from mfr order by mfr_inm",myConn);

			DataSet ds1 = new DataSet();
			cmd1.Fill(ds1, "mfr");
			DataView dv1 = ds1.Tables["mfr"].DefaultView;

			this.ddlcust_inm.DataTextField = "mfr_inm";
			this.ddlcust_inm.DataValueField = "mfr_mfrno";			
			this.ddlcust_inm.DataSource = dv1;
			this.ddlcust_inm.DataBind();

			SqlDataAdapter cmd=new SqlDataAdapter("select * from mfr where mfr_mfrno='" + id + "'",myConn);
		
			DataSet ds = new DataSet();
			cmd.Fill(ds, "mfr");
			DataView dv = ds.Tables["mfr"].DefaultView;
			
			if (dv.Count <= 0)
			{
				Response.Redirect("nodata.aspx");
			}
			
			string mfrno = dv[0]["mfr_mfrno"].ToString();
			string tel = dv[0]["mfr_tel"].ToString();
			string fax = dv[0]["mfr_fax"].ToString();
			
			for(int i=0;i<ddlcust_inm.Items.Count;i++)
			{
				if (ddlcust_inm.Items[i].Value == mfrno)
				{
					ddlcust_inm.SelectedIndex = i;
				}
			}
			
			cust_mfrno.Text=mfrno.Trim();
			cust_tel.Text=tel.Trim();
			cust_fax.Text=fax.Trim();

			TodayDate = System.DateTime.Today;
			this.cust_regdate.Text = TodayDate.ToString("yyyyMMdd");
			this.cust_moddate.Text = TodayDate.ToString("yyyyMMdd");
			
			SqlDataAdapter cmd4=new SqlDataAdapter("select * from itp",myConn);

			DataSet ds4 = new DataSet();
			cmd4.Fill(ds4, "itp");
			DataView dv4 = ds4.Tables["itp"].DefaultView;

			this.cblcust_itpcd.DataTextField = "itp_nm";
			this.cblcust_itpcd.DataValueField = "itp_itpcd";
			this.cblcust_itpcd.DataSource = dv4;
			this.cblcust_itpcd.DataBind();

			SqlDataAdapter cmd2=new SqlDataAdapter("select * from btp",myConn);

			DataSet ds2 = new DataSet();
			cmd2.Fill(ds2, "btp");
			DataView dv2 = ds2.Tables["btp"].DefaultView;

			this.cblcust_btpcd.DataTextField = "btp_nm";
			this.cblcust_btpcd.DataValueField = "btp_btpcd";
			this.cblcust_btpcd.DataSource = dv2;
			this.cblcust_btpcd.DataBind();

			SqlDataAdapter cmd3=new SqlDataAdapter("select * from itp",myConn);

			DataSet ds3 = new DataSet();
			cmd3.Fill(ds3, "itp");
			DataView dv3 = ds3.Tables["itp"].DefaultView;

			this.cblcust_rtpcd.DataTextField = "itp_nm";
			this.cblcust_rtpcd.DataValueField = "itp_itpcd";
			this.cblcust_rtpcd.DataSource = dv3;
			this.cblcust_rtpcd.DataBind();

			//業務人員
			SqlDataAdapter da = new SqlDataAdapter("select * from srspn where srspn_atype in ('B','C','D')",System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"]);	
			DataSet ds_emp= new DataSet();	
			da.Fill(ds_emp, "srspn");
			ddlEmpNo.DataSource=ds_emp;
			ddlEmpNo.DataTextField="srspn_cname";
			ddlEmpNo.DataValueField="srspn_empno";
			ddlEmpNo.DataBind();
		}

		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.ddlcust_inm.SelectedIndexChanged += new System.EventHandler(this.ddlcust_inm_SelectedIndexChanged);
			this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
			this.btnRePick.Click += new System.EventHandler(this.btnRePick_Click);
			this.btnReturnHome.Click += new System.EventHandler(this.btnReturnHome_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		
		private void btnAddNew_Click(object sender, System.EventArgs e)
		{
			string strConn = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
			SqlConnection myConn=new SqlConnection(strConn);
			string SQL = "select * from cust";
			SqlDataAdapter myCommand = new SqlDataAdapter(SQL,myConn);

			DataSet ds1 = new DataSet();
			myCommand.Fill(ds1,"Title");

			DataView dv = ds1.Tables["Title"].DefaultView;
			dv.RowFilter = "cust_custno = '" + cust_custno.Text.Trim() +"'";

			//DataGrid1.DataSource = dv;
			//DataGrid1.DataBind();

			if (dv.Count > 0)
			{
				Label1.Text="此筆資料已經存在!";
			}
			
			else
			{
				SqlDataAdapter cmd=new SqlDataAdapter
					("insert into cust(cust_custno,cust_nm,cust_jbti,cust_mfrno,cust_tel,cust_fax,cust_cell,cust_email,cust_regdate,cust_moddate,cust_oldcustno,cust_itpcd,cust_rtpcd,cust_btpcd,cust_srspn_empno) values(@cust_custno,@cust_nm,@cust_jbti,@cust_mfrno,@cust_tel,@cust_fax,@cust_cell,@cust_email,@cust_regdate,@cust_moddate,@cust_oldcustno,@cust_itpcd,@cust_rtpcd,@cust_btpcd,@cust_srspn_empno)",myConn);
		
				cmd.SelectCommand.Parameters.Add("@cust_custno",SqlDbType.Char,6).Value=cust_custno.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@cust_nm",SqlDbType.Char,30).Value=cust_nm.Text;
				cmd.SelectCommand.Parameters.Add("@cust_jbti",SqlDbType.VarChar,12).Value=cust_jbti.Text;
				cmd.SelectCommand.Parameters.Add("@cust_mfrno",SqlDbType.Char,10).Value=cust_mfrno.Text;
				cmd.SelectCommand.Parameters.Add("@cust_tel",SqlDbType.VarChar,30).Value=cust_tel.Text;
				cmd.SelectCommand.Parameters.Add("@cust_fax",SqlDbType.VarChar,30).Value=cust_fax.Text;
				cmd.SelectCommand.Parameters.Add("@cust_cell",SqlDbType.VarChar,30).Value=cust_cell.Text;
				cmd.SelectCommand.Parameters.Add("@cust_email",SqlDbType.VarChar,80).Value=cust_email.Text;
				cmd.SelectCommand.Parameters.Add("@cust_regdate",SqlDbType.Char,8).Value=cust_regdate.Text;
				cmd.SelectCommand.Parameters.Add("@cust_moddate",SqlDbType.Char,8).Value=cust_moddate.Text;
				cmd.SelectCommand.Parameters.Add("@cust_oldcustno",SqlDbType.Char,5).Value=cust_oldcustno.Text;
				cmd.SelectCommand.Parameters.Add("@cust_srspn_empno",SqlDbType.Char,7).Value=ddlEmpNo.SelectedValue;

				string stritpcd = "";
				for (int i=0; i<this.cblcust_itpcd.Items.Count; i++)
				{
					if (this.cblcust_itpcd.Items[i].Selected)
					{
						stritpcd += this.cblcust_itpcd.Items[i].Value;
					}
				}
				cmd.SelectCommand.Parameters.Add("@cust_itpcd",SqlDbType.VarChar,50).Value=stritpcd;
				
				string strbtpcd = "";
				for (int i=0; i<this.cblcust_btpcd.Items.Count; i++)
				{
					if (this.cblcust_btpcd.Items[i].Selected)
					{
						strbtpcd += this.cblcust_btpcd.Items[i].Value;
					}
				}
				cmd.SelectCommand.Parameters.Add("@cust_btpcd",SqlDbType.VarChar,30).Value=strbtpcd;
				
				string strrtpcd = "";
				for (int i=0; i<this.cblcust_rtpcd.Items.Count; i++)
				{
					if (this.cblcust_rtpcd.Items[i].Selected)
					{
						strrtpcd += this.cblcust_rtpcd.Items[i].Value;
					}
				}
				cmd.SelectCommand.Parameters.Add("@cust_rtpcd",SqlDbType.VarChar,50).Value=strrtpcd;
			
				DataSet ds = new DataSet();
				cmd.Fill(ds,"Title");
				
//				LiteralControl litSus = new LiteralControl();
//				litSus.Text = "<script>alert(\"success!\");window.history.back;</script>";
//				Page.Controls.Add(litSus);
				
				Response.Redirect("cust.aspx?ID=addnew_ok");
			}
		}

		private void ddlcust_inm_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string id = ddlcust_inm.SelectedItem.Value.ToString();
			
			string strConn = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
			SqlConnection myConn=new SqlConnection(strConn);
			SqlDataAdapter cmd=new SqlDataAdapter("select * from mfr where mfr_mfrno = '" + id + "'",myConn);

			DataSet ds = new DataSet();
			cmd.Fill(ds, "mfr");
			DataView dv = ds.Tables["mfr"].DefaultView;

			string mfrno = dv[0]["mfr_mfrno"].ToString();
			string tel = dv[0]["mfr_tel"].ToString();
			string fax = dv[0]["mfr_fax"].ToString();

			this.cust_mfrno.Text = mfrno;
			this.cust_tel.Text = tel;
			this.cust_fax.Text = fax;
		}

		private void btnReturnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("cust.aspx");
		}

		private void btnRePick_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("cust_add.aspx");
		}
	}
}
