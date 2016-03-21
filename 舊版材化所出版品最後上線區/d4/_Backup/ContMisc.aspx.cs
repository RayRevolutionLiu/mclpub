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

namespace MRLPub.d4
{
	/// <summary>
	/// Summary description for ContMisc.
	/// </summary>
	public class ContMisc : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox tbxCCont;
		protected System.Web.UI.WebControls.TextBox tbxCsDate;
		protected System.Data.SqlClient.SqlConnection sqlCnnMRLPub;
		protected System.Data.SqlClient.SqlDataAdapter sqlDaCategory;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDaClass;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Button btnClose;
		protected System.Web.UI.WebControls.CheckBoxList cblClass1;
		protected System.Web.UI.WebControls.DropDownList ddlCategory1;
		protected System.Web.UI.WebControls.Button btnAdd1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidSelected;
		protected System.Web.UI.WebControls.Button btnAdd2;
		protected System.Web.UI.WebControls.CheckBoxList cblClass2;
		protected System.Web.UI.WebControls.DropDownList ddlCategory2;
		protected System.Data.SqlClient.SqlCommand sqlCmdInsClassD;
		protected System.Data.SqlClient.SqlDataAdapter sqlDaClassD;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvCsDate;
		protected System.Web.UI.WebControls.RegularExpressionValidator revCsDate;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvCsDate2;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvCsDate3;
		protected System.Web.UI.WebControls.TextBox tbxPdCont;
	
		public ContMisc()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				InitData();
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
			System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;

			this.sqlDaClass = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlCnnMRLPub = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDaCategory = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDaClassD = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlCmdInsClassD = new System.Data.SqlClient.SqlCommand();
			this.ddlCategory1.SelectedIndexChanged += new System.EventHandler(this.ddlCategory_SelectedIndexChanged);
			this.btnAdd1.Click += new System.EventHandler(this.btnAdd1_Click);
			this.ddlCategory2.SelectedIndexChanged += new System.EventHandler(this.ddlCategory2_SelectedIndexChanged);
			this.btnAdd2.Click += new System.EventHandler(this.btnAdd2_Click);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// sqlDaClass
			// 
			this.sqlDaClass.SelectCommand = this.sqlSelectCommand2;
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT cls_dom, cls_cat, cls_id, cls_cname, CONVERT (char(1), cls_dom) + \'_\' + RT" +
				"RIM(CONVERT (char(2), cls_cat)) + \'_\' + RTRIM(CONVERT (char(2), cls_id)) AS cls_" +
				"value FROM dbo.c4_class ORDER BY cls_dom, cls_cat, cls_id";
			this.sqlSelectCommand2.Connection = this.sqlCnnMRLPub;
			// 
			// sqlCnnMRLPub
			// 
			this.sqlCnnMRLPub.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "SELECT RTRIM(CONVERT (CHAR(1), clsd_domain)) + RTRIM(CONVERT (CHAR(2), clsd_categ" +
				"ory)) + RTRIM(CONVERT (CHAR(2), clsd_class)) AS clsd_value, clsd_contno, clsd_ca" +
				"tegory, clsd_class, clsd_domain FROM dbo.c4_classd";
			this.sqlSelectCommand3.Connection = this.sqlCnnMRLPub;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT cat_dom, cat_id, cat_cname FROM dbo.c4_category";
			this.sqlSelectCommand1.Connection = this.sqlCnnMRLPub;
			// 
			// sqlDaCategory
			// 
			this.sqlDaCategory.SelectCommand = this.sqlSelectCommand1;
			// 
			// sqlDaClassD
			// 
			this.sqlDaClassD.SelectCommand = this.sqlSelectCommand3;
			// 
			// sqlCmdInsClassD
			// 
			this.sqlCmdInsClassD.Connection = this.sqlCnnMRLPub;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void AlertMsg(string strMsg)
		{
			if (strMsg != null && strMsg != "")
			{
				LiteralControl litAlert = new LiteralControl();
				litAlert.Text = "<script language=javascript>alert(\"" + strMsg +"\");</script>";
				Page.Controls.Add(litAlert);
			}
		}

		private void InitData()
		{
			Bind_ddlCategory_1();
			Bind_cblClass1("1", "1");
			Bind_ddlCategory_2();
			Bind_cblClass2("2", "1");
		
			//帶回已存資料 
			//Fill_cblClasses();
		}

		private void BindOldClassd()
		{
			string ContNo = Request.QueryString["ContNo"].Trim();			
			DataSet ds = new DataSet();
			this.sqlDaClassD.Fill(ds, "CLSD");
			DataView dv = ds.Tables["CLSD"].DefaultView;
			dv.RowFilter = "clsd_contno='" + ContNo + "'";

			string OldClassdValue = "";

			for (int i=0; i<dv.Count; i++)
			{
				if (OldClassdValue.Trim().Length>0)
					OldClassdValue += ",";
				OldClassdValue += dv[i]["clsd_value"].ToString().Trim();				
			}

			string[] SelectedClass = OldClassdValue.Split(new char[]{','});

			if (SelectedClass==null) return;

			if (SelectedClass.Length<=0) return;

			//回復先前的選擇
			for(int i=0; i<SelectedClass.Length; i++)
			{
				//Response.Write(SelectedClass.GetValue(i).ToString()+"#");
				for (int j=0; j<cblClass1.Items.Count; j++)
				{
					if (SelectedClass.GetValue(i).ToString()==cblClass1.Items[j].Value)
					{
						this.cblClass1.Items[j].Selected = true;
					}
				}
			}

			for(int i=0; i<SelectedClass.Length; i++)
			{
				//Response.Write(SelectedClass.GetValue(i).ToString()+"#");
				for (int j=0; j<cblClass2.Items.Count; j++)
				{
					if (SelectedClass.GetValue(i).ToString()==cblClass2.Items[j].Value)
					{
						this.cblClass2.Items[j].Selected = true;
					}
				}
			}
		}

//		private void Bind_Domain()
//		{
//			//目前這個不做
//			//直接寫死
//		}

		private void Bind_ddlCategory_1()
		{
			DataSet ds = new DataSet();
			this.sqlDaCategory.Fill(ds, "CAT");
			DataView dv = ds.Tables["CAT"].DefaultView;
			dv.RowFilter = "cat_dom=1";
			this.ddlCategory1.DataSource = dv;
			this.ddlCategory1.DataTextField = "cat_cname";
			this.ddlCategory1.DataValueField = "cat_id";
			this.ddlCategory1.DataBind();
		}

		private void Bind_ddlCategory_2()
		{
			DataSet ds = new DataSet();
			this.sqlDaCategory.Fill(ds, "CAT");
			DataView dv = ds.Tables["CAT"].DefaultView;
			dv.RowFilter = "cat_dom=2";
			this.ddlCategory2.DataSource = dv;
			this.ddlCategory2.DataTextField = "cat_cname";
			this.ddlCategory2.DataValueField = "cat_id";
			this.ddlCategory2.DataBind();
		}

		private void Bind_cblClass1(string strDomain, string strCategory)
		{
			DataSet ds = new DataSet();
			this.sqlDaClass.Fill(ds, "CLS");
			DataView dv = ds.Tables["CLS"].DefaultView;
			dv.RowFilter = "cls_dom="+strDomain+" AND cls_cat="+strCategory;
			this.cblClass1.DataSource = dv;
			this.cblClass1.DataTextField = "cls_cname";
			this.cblClass1.DataValueField = "cls_value";
			this.cblClass1.DataBind();
		}

		private void Bind_cblClass2(string strDomain, string strCategory)
		{
			DataSet ds = new DataSet();
			this.sqlDaClass.Fill(ds, "CLS");
			DataView dv = ds.Tables["CLS"].DefaultView;
			dv.RowFilter = "cls_dom="+strDomain+" AND cls_cat="+strCategory;
			this.cblClass2.DataSource = dv;
			this.cblClass2.DataTextField = "cls_cname";
			this.cblClass2.DataValueField = "cls_value";
			this.cblClass2.DataBind();
		}

		private void ddlCategory_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Bind_cblClass1("1", this.ddlCategory1.SelectedItem.Value.Trim());

			string[] SelectedClass = ParseSelectedValue();

			if (SelectedClass==null) return;

			//回復先前的選擇
			for(int i=0; i<SelectedClass.Length; i++)
			{
				//Response.Write(SelectedClass.GetValue(i).ToString()+"#");
				for (int j=0; j<cblClass1.Items.Count; j++)
				{
					if (SelectedClass.GetValue(i).ToString()==cblClass1.Items[j].Value)
					{
						this.cblClass1.Items[j].Selected = true;
					}
				}
			}
		}

		private void btnAdd1_Click(object sender, System.EventArgs e)
		{
			string[] SelectedValue = ParseSelectedValue();

			for (int i=0; i<cblClass1.Items.Count; i++)
			{
				if (cblClass1.Items[i].Selected)
				{
					bool fgDuplicate = false;
					//檢查有沒有重複
					for(int j=0; j<SelectedValue.Length ;j++)
					{
						string strValue = SelectedValue.GetValue(j).ToString().Trim();
						if (strValue.Trim() == cblClass1.Items[i].Value.Trim())
						{
							fgDuplicate=true;
							break;
						}
					}

					if (!fgDuplicate)
					{
						if (hidSelected.Value.Trim().Length>0)
							hidSelected.Value += ",";
						hidSelected.Value += cblClass1.Items[i].Value;
					}
				}
			}
		}

		private void ddlCategory2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Bind_cblClass2("2", this.ddlCategory2.SelectedItem.Value.Trim());

			string[] SelectedClass = ParseSelectedValue();

			if (SelectedClass==null) return;

			//回復先前的選擇
			for(int i=0; i<SelectedClass.Length; i++)
			{
				//Response.Write(SelectedClass.GetValue(i).ToString()+"#");
				for (int j=0; j<cblClass2.Items.Count; j++)
				{
					if (SelectedClass.GetValue(i).ToString()==cblClass2.Items[j].Value)
					{
						this.cblClass2.Items[j].Selected = true;
					}
				}
			}
		}

		private void btnAdd2_Click(object sender, System.EventArgs e)
		{
			string[] SelectedValue = ParseSelectedValue();

			for (int i=0; i<cblClass2.Items.Count; i++)
			{
				if (cblClass2.Items[i].Selected)
				{
					bool fgDuplicate = false;
					//檢查有沒有重複
					for(int j=0; j<SelectedValue.Length ;j++)
					{
						string strValue = SelectedValue.GetValue(j).ToString().Trim();
						if (strValue.Trim() == cblClass2.Items[i].Value.Trim())
						{
							fgDuplicate=true;
							break;
						}
					}

					if (!fgDuplicate)
					{
						if (hidSelected.Value.Trim().Length>0)
							hidSelected.Value += ",";
						hidSelected.Value += cblClass2.Items[i].Value;
					}
				}
			}
		}

		private string[] ParseSelectedValue()
		{
			string[] SelectedValue = hidSelected.Value.Split(new char[]{','});
			if (SelectedValue.Length<=0)
			{
//				Response.Write("No SelectedValue");
				return null;
			}
			else
			{
//				Response.Write(hidSelected.Value +"##<br>");
//				for(int i=0; i<SelectedValue.Length; i++)
//				{
//					Response.Write(SelectedValue.GetValue(i).ToString().Trim() + "<br>");
//				}
//				Response.Write(SelectedValue.Length.ToString());
				return SelectedValue;
			}
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			string[] SelectedValue = ParseSelectedValue();
			string strValue;
			string strCommandText;
			string ContNo = Request.QueryString["ContNo"].Trim();

			this.sqlCmdInsClassD.Connection.Open();
			System.Data.SqlClient.SqlTransaction myTrans = this.sqlCmdInsClassD.Connection.BeginTransaction();
			this.sqlCmdInsClassD.Transaction = myTrans;

			try
			{
				string CsDate = DateTime.ParseExact(this.tbxCsDate.Text.Trim(), "yyyy/MM/dd", null).ToString("yyyyMMdd");
				//修改合約的一些資料
				this.sqlCmdInsClassD.CommandText = "UPDATE c4_cont SET cont_ccont=@ccont, cont_pdcont=@pdcont, cont_csdate=@csdate WHERE cont_contno=@contno";
				this.sqlCmdInsClassD.Parameters.Add("@ccont", SqlDbType.VarChar, 50);
				this.sqlCmdInsClassD.Parameters.Add("@pdcont", SqlDbType.Text, 3000);
				this.sqlCmdInsClassD.Parameters.Add("@csdate", SqlDbType.Char, 8);
				this.sqlCmdInsClassD.Parameters.Add("@contno", SqlDbType.Char, 6);
				this.sqlCmdInsClassD.Parameters["@ccont"].Value = this.tbxCCont.Text.Trim();
				this.sqlCmdInsClassD.Parameters["@pdcont"].Value = this.tbxPdCont.Text.Trim();
				this.sqlCmdInsClassD.Parameters["@csdate"].Value = CsDate;
				this.sqlCmdInsClassD.Parameters["@contno"].Value = ContNo;
				this.sqlCmdInsClassD.ExecuteNonQuery();

				//先全刪了，再新增回去
				this.sqlCmdInsClassD.CommandText = "DELETE FROM c4_classd WHERE clsd_contno="+ContNo;
				this.sqlCmdInsClassD.ExecuteNonQuery();

				for(int i=0; i<SelectedValue.Length; i++)
				{
					strValue = SelectedValue.GetValue(i).ToString().Trim();
					string[] FieldValue = strValue.Split(new char[]{'_'});

					if (FieldValue.Length<=0) continue;

					strCommandText = "INSERT INTO c4_classd VALUES "+
						"('" + ContNo +
						"', " + FieldValue.GetValue(0).ToString().Trim() +
						", " + FieldValue.GetValue(1).ToString().Trim() +
						", " + FieldValue.GetValue(2).ToString().Trim() + ")";
					//Response.Write(strCommandText+"<br>");
					this.sqlCmdInsClassD.CommandText = strCommandText;
					this.sqlCmdInsClassD.ExecuteNonQuery();
				}

				myTrans.Commit();
				AlertMsg("儲存成功");
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				myTrans.Rollback();
				AlertMsg("儲存失敗，請通知聯絡人");
			}

			this.sqlCmdInsClassD.Connection.Close();
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			string strScript = "<script language=javascript>";
			strScript += "window.opener.document.forms(0).submit();";
			strScript += "window.close();";
//			strScript += "if (myaction == \"Mod\")";
//			strScript += "{";
//			strScript += 	"window.opener.ContModify.submit();";
//			strScript += "}";
//			strScript += "else";
//			strScript += "{";
//			strScript += 	"window.opener.NewCont.submit();";
//			strScript += "}";
//			strScript += "window.close();";
			strScript += "</script>";
			Response.Write(strScript);
		}
	}
}
