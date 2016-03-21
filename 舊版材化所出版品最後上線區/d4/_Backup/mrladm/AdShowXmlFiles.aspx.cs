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

namespace MRLPub.d4.mrladm
{
	/// <summary>
	/// Summary description for AdShowXmlFiles.
	/// </summary>
	public class AdShowXmlFiles : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.WebControls.TextBox tbxXml;
		protected System.Web.UI.WebControls.DataGrid dgdXmlFile;
	
		public AdShowXmlFiles()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				SearchXmlFiles();
				tbxXml.Visible = false;
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
			this.dgdXmlFile.SelectedIndexChanged += new System.EventHandler(this.dgdXmlFile_SelectedIndexChanged);
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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

		private void SearchXmlFiles()
		{
			string[] ary = System.IO.Directory.GetFiles(Server.MapPath("..") + "\\XmlFiles", "*.xml");

			DataTable dt = new DataTable("XMLFILE");
			dt.Columns.Add("fullpath");

			//Response.Write(ary.Length.ToString());
			for (int i=0;i<ary.Length;i++)
			{
				DataRow dr = dt.NewRow();
				dr["fullpath"] = ary[i];
				dt.Rows.Add(dr);
			}

			DataView dv = dt.DefaultView;

			dgdXmlFile.DataSource = dv;
			dgdXmlFile.DataBind();
		}

		protected object GetFileName(object fullpath)
		{
			string strReturn = "";
			if (fullpath.ToString().Trim() != "")
			{
				strReturn = fullpath.ToString().Trim().Substring(fullpath.ToString().Trim().LastIndexOf("\\")+1);
			}
			return strReturn;
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			//重置狀態
			dgdXmlFile.SelectedIndex = -1;
			tbxXml.Text = "";
			tbxXml.Visible = false;

			for (int i=0; i<dgdXmlFile.Items.Count; i++)
			{
				if ( ((CheckBox)dgdXmlFile.Items[i].Cells[0].FindControl("cbxSelXmlFile")).Checked )
				{
					DelXmlFile(((Label)dgdXmlFile.Items[i].Cells[0].FindControl("lblFileName")).Text.Trim());
				}
			}

			SearchXmlFiles();
		}

		private void DelXmlFile(string FileName)
		{
			string strFullPathFile = Server.MapPath("..") + "\\XmlFiles\\" + FileName;
			
			if (!System.IO.File.Exists(strFullPathFile))
			{
				AlertMsg("該檔案:" + strFullPathFile + "已經不存在。");
				return;
			}

			try
			{
				System.IO.File.Delete(strFullPathFile);
				//成功就不用通知了
			}
			catch(Exception ex)
			{
				AlertMsg("檔案:" + strFullPathFile + "刪除失敗，請通知聯絡人");
			}
		}

		/// <summary>
		/// 注意在這邊c4_adr中的欄位imgurl、navurl、keyword、impr、alttext都不可以是空值或null，
		/// 不然播出會錯誤。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dgdXmlFile_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string strFullPathFile = Server.MapPath("..") + "\\XmlFiles\\" + ((Label)dgdXmlFile.SelectedItem.Cells[0].FindControl("lblFileName")).Text.Trim();
//			Response.Write(strFullPathFile);
			DataSet ds = new DataSet();
			ds.ReadXml(strFullPathFile, System.Data.XmlReadMode.Auto);
//			Response.Write(ds.Tables.Count.ToString()+":"+ds.Tables[0].Rows.Count.ToString()+":"+ds.Tables[0].Columns.Count.ToString());
//			for(int i=0; i<ds.Tables.Count; i++)
//			{
//				Response.Write("<br>" + i.ToString() + ":" + ds.Tables[i].TableName);
//			}
//			
//			if (ds.Tables["Ad"] == null) Response.Write("table is null");
//			else
//			{
//				for (int i=0; i<ds.Tables["Ad"].Rows.Count; i++)
//				{
//					for (int j=0; j<ds.Tables["Ad"].Columns.Count; j++)
//					{
//						Response.Write(ds.Tables["Ad"].Rows[i][j].ToString() + ":" );
//					}
//					Response.Write("<br>");
//				}
//			}
//			//DataGrid1.DataSource = ds;
//			//DataGrid1.DataBind();
			tbxXml.Text = ds.GetXml();
			tbxXml.Visible = true;
		}
	}
}
