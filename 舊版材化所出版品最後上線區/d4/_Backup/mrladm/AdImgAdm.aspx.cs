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
	/// Summary description for AdImgAdm.
	/// </summary>
	public class AdImgAdm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.WebControls.Image imgImageFile;
		protected System.Web.UI.WebControls.Label lblFileName;
		protected System.Web.UI.WebControls.DataGrid dgdXmlFile;
	
		public AdImgAdm()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				SearchXmlFiles();
				//tbxXml.Visible = false;
				imgImageFile.Visible = false;
				lblFileName.Visible = false;
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
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.dgdXmlFile.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdXmlFile_PageIndexChanged);
			this.dgdXmlFile.SelectedIndexChanged += new System.EventHandler(this.dgdXmlFile_SelectedIndexChanged);
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
			string[] ary = System.IO.Directory.GetFiles(Server.MapPath("..") + "\\AdImages");

			DataTable dt = new DataTable("IMGFILE");
			dt.Columns.Add("fullpath");

			//Response.Write(ary.Length.ToString());
			for (int i=0;i<ary.Length;i++)
			{
				DataRow dr = dt.NewRow();
				dr["fullpath"] = ary[i];
				dt.Rows.Add(dr);
			}

			DataView dv = dt.DefaultView;
			dv.Sort = "fullpath";

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
			//���m���A
			dgdXmlFile.SelectedIndex = -1;
			//tbxXml.Text = "";
			//tbxXml.Visible = false;
			imgImageFile.ImageUrl = "";
			imgImageFile.Visible = false;
			lblFileName.Visible = false;

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
			string strFullPathFile = Server.MapPath("..") + "\\AdImages\\" + FileName;
			
			if (!System.IO.File.Exists(strFullPathFile))
			{
				AlertMsg("���ɮ�:" + strFullPathFile + "�w�g���s�b�C");
				return;
			}

			try
			{
				System.IO.File.Delete(strFullPathFile);
				//���\�N���γq���F
			}
			catch(Exception ex)
			{
				Response.Write(ex.Message);
				AlertMsg("�ɮ�:" + strFullPathFile + "�R�����ѡA�гq���p���H");
			}
		}

		private void dgdXmlFile_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string strFullPathFile = "~/d4/AdImages/" + ((Label)dgdXmlFile.SelectedItem.Cells[0].FindControl("lblFileName")).Text.Trim();
			//			Response.Write(strFullPathFile);
			// //DataSet ds = new DataSet();
			// //ds.ReadXml(strFullPathFile, System.Data.XmlReadMode.Auto);
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
			// //tbxXml.Text = ds.GetXml();
			// //tbxXml.Visible = true;
			imgImageFile.ImageUrl = strFullPathFile;
			imgImageFile.Visible = true;
			lblFileName.Text = dgdXmlFile.SelectedItem.Cells[1].Text.Trim();
			lblFileName.Visible = true;
		}

		private void dgdXmlFile_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgdXmlFile.CurrentPageIndex = e.NewPageIndex;
			SearchXmlFiles();
			imgImageFile.Visible = false;
			lblFileName.Visible = false;
		}

	}
}
