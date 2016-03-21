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
using MRLPub.d4.Configurations;
using MRLPub.d4.DataTypes;
using System.IO;

namespace MRLPub.d4.WorkingProcess
{
	/// <summary>
	/// Summary description for AdrXmlManage.
	/// </summary>
	public class AdrXmlManage : MRLPub.d4.Pages.Page
	{
		protected System.Web.UI.WebControls.Label lblxml;
		protected System.Web.UI.WebControls.DataGrid dgdXml;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				Bind_dgdXml();
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.dgdXml.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdAdr_DeleteCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region 連結檔案資料
		private void Bind_dgdXml()
		{
			string path = Server.MapPath("..\\XmlFiles");
			string[] xmlfiles = Directory.GetFiles(path);
			
			DataTable dt = new DataTable();
			DataColumn dc = new DataColumn("filename");
			dt.Columns.Add(dc);

			for(int i=0; i<xmlfiles.Length; i++)
			{
				DataRow dr = dt.NewRow();
				string rawFileName = xmlfiles.GetValue(i).ToString();
				string strbuf = rawFileName.Substring(rawFileName.LastIndexOf("\\")+1);
				DateTime fileday = DateTime.Parse(strbuf.Substring(0,4)+"/"+strbuf.Substring(4,2)+"/"+strbuf.Substring(6,2));
				if(fileday>=DateTime.Today)
				{
					dr["filename"] = strbuf;
					//dr["filename"] = rawFileName.Substring(rawFileName.LastIndexOf("\\")+1);
					dt.Rows.Add(dr);
				}
			}

			DataView dv = dt.DefaultView;
			dv.Sort = "filename ASC";

			dgdXml.DataSource = dv;
			dgdXml.DataBind();

			if (dv.Count>0)
			{
				dgdXml.Visible = true;
				lblxml.Text = "現有 "+dv.Count.ToString()+" 筆可維護的xml檔案";
			}
			else
			{
				dgdXml.Visible = false;
				lblxml.Text = "目前無可維護的xml檔案";
			}

		}
		#endregion

		#region 刪除xml檔案
		private void dgdAdr_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string filename = e.Item.Cells[1].Text.Trim();
			
			DateTime target;
			try
			{
				target = DateTime.ParseExact(filename.Substring(0, 8), "yyyyMMdd", null);
			}
			catch
			{
				jsAlertMsg("INVALIDFILE", "刪除的檔案名稱錯誤，或許系統有些問題...");
				return;
			}

			string filepath = Server.MapPath("..") + "\\XmlFiles\\" + target.ToString("yyyyMMdd") + ".xml";

			if ( !File.Exists(filepath) )
			{
				jsAlertMsg("FILENOTEXIST", "該檔案不存在");
			}
			else
			{
				try
				{
					File.Delete(filepath);
					Advertisements adr = new Advertisements();
					adr.SubstractXmlFileLog(target.ToString("yyyyMMdd"));
				}
				catch
				{
					jsAlertMsg("DELETEFAILED", "檔案刪除失敗，請通知聯絡人");
				}
			}

			Bind_dgdXml();
		}
		#endregion
	}
}
