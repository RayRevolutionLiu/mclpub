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

namespace MRLPub.d2
{
	/// <summary>
	/// Summary description for Label.
	/// </summary>
	public class Labeltest : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataList DataList1;
	
		public Labeltest()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				//
				DataTable	TestTable=new DataTable();
				DataRow	dr;
				TestTable.Columns.Add(new DataColumn("�l���ϸ�", typeof(string)));
				TestTable.Columns.Add(new DataColumn("�m�W", typeof(string)));
				TestTable.Columns.Add(new DataColumn("���q�W��", typeof(string)));
				TestTable.Columns.Add(new DataColumn("�a�}", typeof(string)));
				TestTable.Columns.Add(new DataColumn("�q�\�_��", typeof(string)));
				TestTable.Columns.Add(new DataColumn("�q��s��", typeof(string)));
				TestTable.Columns.Add(new DataColumn("�ɮѤ��e", typeof(string)));
				for(int i=0; i<20; i++)
				{
					dr=TestTable.NewRow();
					dr[0]="10"+i.ToString();
					dr[1]="���W�R"+i.ToString();
					dr[2]="�u��|"+i.ToString();
					dr[3]="�s�˥����_���G�q321��"+i.ToString();
					dr[4]="2001/08/01~2002/07/31";
					dr[5]="90XXXXXXX";
					dr[6]="�u�~�������x170��";
					TestTable.Rows.Add(dr);
				}
				DataList1.DataSource=new DataView(TestTable);
				DataList1.DataBind();
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
