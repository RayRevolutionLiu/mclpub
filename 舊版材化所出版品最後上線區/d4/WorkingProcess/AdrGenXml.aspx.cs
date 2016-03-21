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
using MRLPub.d4.Configurations;
using MRLPub.d4.DataTypes;

namespace MRLPub.d4.WorkingProcess
{
	/// <summary>
	/// Summary description for AdrGenXml.
	/// </summary>
	public class AdrGenXml : MRLPub.d4.Pages.Page
	{
		protected System.Web.UI.WebControls.Calendar calDates;
		protected System.Web.UI.WebControls.RegularExpressionValidator rdvAdDate;
		protected System.Web.UI.WebControls.Button btnQueryPublish;
		protected System.Web.UI.WebControls.Panel pnlAdr;
		protected System.Web.UI.WebControls.DataGrid dgdAdr;
		protected System.Web.UI.WebControls.Button btnGenXml;
		protected System.Web.UI.WebControls.TextBox tbxSelDate;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.TextBox tbxAdDate;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				//只給我自己看這個資料:>
				if (this.WhoAmI.EmpNo.Trim() != "900103")
				{
					TextBox1.Visible = false;
				}
				pnlAdr.Visible = false;
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
			this.btnQueryPublish.Click += new System.EventHandler(this.btnQueryPublish_Click);
			this.calDates.SelectionChanged += new System.EventHandler(this.calDates_SelectionChanged);
			this.btnGenXml.Click += new System.EventHandler(this.btnGenXml_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region 選定日期
		private void calDates_SelectionChanged(object sender, System.EventArgs e)
		{
			tbxAdDate.Text = calDates.SelectedDate.ToString("yyyy/MM/dd");
			
			//一選定就把落版藏起來
			pnlAdr.Visible = false;
		}
		#endregion

		#region 帶入廣告落版上稿資料
		private void btnQueryPublish_Click(object sender, System.EventArgs e)
		{
			if (tbxAdDate.Text.Trim() == "")
			{
				jsAlertMsg("EMPTYDATE", "查詢日期不可為空值");
				return;
			}			

			DateTime addate;
			try
			{
				addate = DateTime.ParseExact(tbxAdDate.Text.Trim(), "yyyy/MM/dd", null);
			}
			catch
			{
				jsAlertMsg("DATECONVERSIONFAIL", "輸入的年月日不合理，請重新輸入");
				return;
			}

			//OK了就可以開始查詢
			Advertisements adr = new Advertisements();
			DataSet ds = adr.GetAdrPublishFileUp(addate.ToString("yyyyMMdd"));
			DataView dv = ds.Tables[0].DefaultView;
			dv.Sort = "sort_adcate DESC, sort_keyword ASC";

			if (dv.Count>0)
			{
				pnlAdr.Visible = true;
				dgdAdr.DataSource = dv;
				dgdAdr.DataBind();
			}
			else
			{
				pnlAdr.Visible = false;
				jsAlertMsg("NOADR", "該日尚無廣告落版");
			}

			//設定button文字
			btnGenXml.Text = "產生" + tbxAdDate.Text + "的廣告播出檔";
			
			//隱藏值，為了避免user又跑去textbox輸入日期..but..not gen檔案
			tbxSelDate.Text = tbxAdDate.Text;
		}
		#endregion

		#region 產生xml檔案
		private void btnGenXml_Click(object sender, System.EventArgs e)
		{
			string path = Server.MapPath("..\\XmlFiles") + "\\";
			string filename = DateTime.ParseExact(tbxSelDate.Text, "yyyy/MM/dd", null).ToString("yyyyMMdd") + ".xml";
			DateTime addate;
			try
			{
				addate = DateTime.ParseExact(tbxSelDate.Text.Trim(), "yyyy/MM/dd", null);
			}
			catch
			{
				jsAlertMsg("PARSEDATEFAIL", "轉換日期格式失敗，請通知聯絡人");
				return;
			}

			Advertisements adr = new Advertisements();
			DataSet ds = adr.GetAdrXmlData(addate.ToString("yyyyMMdd"));

			//為了保險起見，再設定一次
			ds.DataSetName = "Advertisements";
			ds.Tables[0].TableName = "Ad";

			TextBox1.Text = ds.GetXml();

			//寫出XML
			string filepath = Server.MapPath("..") + "\\XmlFiles\\" + addate.ToString("yyyyMMdd") + ".xml";

			if (System.IO.File.Exists(filepath))
			{
				jsAlertMsg("FILEEXIST", "檔案已經存在，請到xml檔案維護(刪除)後，再產生一次");
				return;
			}

			try
			{
				ds.WriteXml(filepath);
				jsAlertMsg("GENXMLSUCCESS", addate.ToString("yyyyMMdd") +".xml 產生成功");
			}
			catch(Exception ex)
			{
				jsAlertMsg("GENXMLFAILED", "產生xml檔案時發生錯誤，請通知聯絡人");
			}
			pnlAdr.Visible = false;

			adr.UpdateXmlFileLog(addate.ToString("yyyyMMdd"));
		}
		#endregion
	}
}
