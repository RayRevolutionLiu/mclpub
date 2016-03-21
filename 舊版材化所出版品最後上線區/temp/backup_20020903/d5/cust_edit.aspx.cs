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
	/// Summary description for edit.
	/// </summary>
	public class cust_edit : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator3;
		protected System.Web.UI.WebControls.TextBox mfr_regdate;
		protected System.Web.UI.WebControls.TextBox mfr_fax;
		protected System.Web.UI.WebControls.TextBox mfr_tel;
		protected System.Web.UI.WebControls.TextBox mfr_respjbti;
		protected System.Web.UI.WebControls.TextBox mfr_respnm;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator4;
		protected System.Web.UI.WebControls.TextBox mfr_izip;
		protected System.Web.UI.WebControls.TextBox mfr_iaddr;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.TextBox mfr_inm;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator6;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.TextBox mfr_mfrno;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator7;
		protected System.Web.UI.WebControls.TextBox Textbox10;
		protected System.Web.UI.WebControls.TextBox Textbox11;
		protected System.Web.UI.WebControls.TextBox Textbox12;
		protected System.Web.UI.WebControls.TextBox Textbox13;
		protected System.Web.UI.WebControls.TextBox Textbox14;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator8;
		protected System.Web.UI.WebControls.TextBox Textbox15;
		protected System.Web.UI.WebControls.TextBox Textbox16;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator3;
		protected System.Web.UI.WebControls.TextBox Textbox17;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator9;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator4;
		protected System.Web.UI.WebControls.TextBox Textbox18;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button btnGoMain;
		protected System.Web.UI.WebControls.Button btnReturnHome;
		protected System.Web.UI.WebControls.TextBox cust_custno;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator1;
		protected System.Web.UI.WebControls.TextBox cust_nm;
		protected System.Web.UI.WebControls.TextBox cust_jbti;
		protected System.Web.UI.WebControls.DropDownList ddlcust_inm;
		protected System.Web.UI.WebControls.TextBox cust_tel;
		protected System.Web.UI.WebControls.TextBox cust_fax;
		protected System.Web.UI.WebControls.TextBox cust_cell;
		protected System.Web.UI.WebControls.TextBox cust_email;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator3;
		protected System.Web.UI.WebControls.TextBox cust_regdate;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator2;
		protected System.Web.UI.WebControls.TextBox cust_oldcustno;
		DateTime	TodayDate;
		protected System.Web.UI.WebControls.CheckBoxList cblcust_itpcd;
		protected System.Web.UI.WebControls.CheckBoxList cblcust_btpcd;
		protected System.Web.UI.WebControls.CheckBoxList cblcust_rtpcd;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.Label cust_mfrno;
		protected System.Web.UI.WebControls.Label cust_moddate;
		private static string global_custno;
	
		public cust_edit()
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
						
			string strConn = System.Configuration.ConfigurationSettings.AppSettings["mrlpub1"].ToString();
			SqlConnection myConn=new SqlConnection(strConn);
			SqlDataAdapter cmd1=new SqlDataAdapter("select * from mfr order by mfr_inm",myConn);

			DataSet ds1 = new DataSet();
			cmd1.Fill(ds1, "mfr");
			DataView dv1 = ds1.Tables["mfr"].DefaultView;

			this.ddlcust_inm.DataTextField = "mfr_inm";
			this.ddlcust_inm.DataValueField = "mfr_mfrno";			
			this.ddlcust_inm.DataSource = dv1;
			this.ddlcust_inm.DataBind();

			string strConn2 = System.Configuration.ConfigurationSettings.AppSettings["mrlpub3"].ToString();
			SqlConnection myConn2=new SqlConnection(strConn2);
			SqlDataAdapter cmd=new SqlDataAdapter("select * from cust where cust_custid='" + id + "'",myConn2);
		
			DataSet ds = new DataSet();
			cmd.Fill(ds, "cust");
			DataView dv = ds.Tables["cust"].DefaultView;
			
			if (dv.Count <= 0)
			{
				Response.Redirect("nodata.aspx");
			}
			
			string custno = dv[0]["cust_custno"].ToString();
			string nm = dv[0]["cust_nm"].ToString();
			string jbti = dv[0]["cust_jbti"].ToString();
			string mfrno = dv[0]["cust_mfrno"].ToString();
			string tel = dv[0]["cust_tel"].ToString();
			string fax = dv[0]["cust_fax"].ToString();
			string cell = dv[0]["cust_cell"].ToString();
			string email = dv[0]["cust_email"].ToString();
			string regdate = dv[0]["cust_regdate"].ToString();
			//string moddate = dv[0]["cust_moddate"].ToString();
			string oldcustno = dv[0]["cust_oldcustno"].ToString();
			string itpcd = dv[0]["cust_itpcd"].ToString();
			string btpcd = dv[0]["cust_btpcd"].ToString();
			string rtpcd = dv[0]["cust_rtpcd"].ToString();
			
			cust_custno.Text=custno.Trim();
			cust_nm.Text=nm.Trim();
			cust_jbti.Text=jbti.Trim();
			
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
			cust_cell.Text=cell.Trim();
			cust_email.Text=email.Trim();
			cust_regdate.Text=regdate.Trim();
			//cust_moddate.Text=moddate.Trim();
			cust_oldcustno.Text=oldcustno.Trim();
			//cust_itpcd.Text=itpcd.Trim();
			//cust_btpcd.Text=btpcd.Trim();
			//cust_rtpcd.Text=rtpcd.Trim();

			TodayDate = System.DateTime.Today;
			this.cust_moddate.Text = TodayDate.ToString("yyyyMMdd");

			SqlDataAdapter cmd0=new SqlDataAdapter("select * from itp",myConn);

			DataSet ds0 = new DataSet();
			cmd0.Fill(ds0, "itp");
			DataView dv0 = ds0.Tables["itp"].DefaultView;

			this.cblcust_itpcd.DataTextField = "itp_nm";
			this.cblcust_itpcd.DataValueField = "itp_itpcd";
			this.cblcust_itpcd.DataSource = dv0;
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

			if (itpcd.Length>0)
			{
				int j;
				for(int i=0; i<itpcd.Length;i+=2)
				{
					j=int.Parse(itpcd.Substring(i,2))-1;
					cblcust_itpcd.Items[j].Selected = true;
				}
			}

			if (btpcd.Length>0)
			{
				int j;
				for(int i=0; i<btpcd.Length;i+=2)
				{
					j=int.Parse(btpcd.Substring(i,2))-1;
					cblcust_btpcd.Items[j].Selected = true;
				}
			}

			if (rtpcd.Length>0)
			{
				int j;
				for(int i=0; i<rtpcd.Length;i+=2)
				{
					j=int.Parse(rtpcd.Substring(i,2))-1;
					cblcust_rtpcd.Items[j].Selected = true;
				}
			}

			global_custno = custno.Trim();
		}

		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.ddlcust_inm.SelectedIndexChanged += new System.EventHandler(this.ddlcust_inm_SelectedIndexChanged);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnReturnHome.Click += new System.EventHandler(this.btnReturnHome_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			string id = Request.QueryString["ID"].ToString();

			string strConn = System.Configuration.ConfigurationSettings.AppSettings["mrlpub3"].ToString();
			SqlConnection myConn=new SqlConnection(strConn);
			string SQL = "select * from cust";
			SqlDataAdapter myCommand = new SqlDataAdapter(SQL,myConn);

			DataSet ds = new DataSet();
			myCommand.Fill(ds,"Title");

			DataView dv = ds.Tables["Title"].DefaultView;
			dv.RowFilter = "cust_custno = '" + cust_custno.Text.Trim() +"'";


			if (dv.Count > 0 && cust_custno.Text != global_custno)
			{
				Label1.Text="此筆資料已經存在!";
			}

			else
			{
				SqlDataAdapter cmd=new SqlDataAdapter
					("update cust set cust_custno=@cust_custno,cust_nm=@cust_nm,cust_jbti=@cust_jbti,cust_mfrno=@cust_mfrno,cust_tel=@cust_tel,cust_fax=@cust_fax,cust_cell=@cust_cell,cust_email=@cust_email,cust_regdate=@cust_regdate,cust_moddate=@cust_moddate,cust_oldcustno=@cust_oldcustno,cust_itpcd=@cust_itpcd,cust_btpcd=@cust_btpcd,cust_rtpcd=@cust_rtpcd where cust_custid=@cust_custid",myConn);
		
				cmd.SelectCommand.Parameters.Add("@cust_custid",SqlDbType.Int,4).Value=id;
				cmd.SelectCommand.Parameters.Add("@cust_custno",SqlDbType.Char,6).Value=cust_custno.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@cust_nm",SqlDbType.Char,30).Value=cust_nm.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@cust_jbti",SqlDbType.VarChar,12).Value=cust_jbti.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@cust_mfrno",SqlDbType.Char,10).Value=cust_mfrno.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@cust_tel",SqlDbType.VarChar,30).Value=cust_tel.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@cust_fax",SqlDbType.VarChar,30).Value=cust_fax.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@cust_cell",SqlDbType.VarChar,30).Value=cust_cell.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@cust_email",SqlDbType.VarChar,80).Value=cust_email.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@cust_regdate",SqlDbType.Char,8).Value=cust_regdate.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@cust_moddate",SqlDbType.Char,8).Value=cust_moddate.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@cust_oldcustno",SqlDbType.Char,5).Value=cust_oldcustno.Text.Trim();
				
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

				DataSet ds1 = new DataSet();
				cmd.Fill(ds1,"Title");

				Response.Redirect("cust.aspx?ID=edit_ok");
			}
		}

		private void btnReturnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("cust.aspx");
		}

		private void ddlcust_inm_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string id = ddlcust_inm.SelectedItem.Value.ToString();
			
			string strConn = System.Configuration.ConfigurationSettings.AppSettings["mrlpub1"].ToString();
			SqlConnection myConn=new SqlConnection(strConn);
			SqlDataAdapter cmd=new SqlDataAdapter("select * from mfr where mfr_mfrno = '" + id + "'",myConn);

			DataSet ds = new DataSet();
			cmd.Fill(ds, "mfr");
			DataView dv = ds.Tables["mfr"].DefaultView;

			string mfrno = dv[0]["mfr_mfrno"].ToString();
			//string tel = dv[0]["mfr_tel"].ToString();
			//string fax = dv[0]["mfr_fax"].ToString();

			this.cust_mfrno.Text = mfrno;
			//this.cust_tel.Text = tel;
			//this.cust_fax.Text = fax;
		}
	}
}
