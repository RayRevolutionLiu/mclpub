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
	/// Summary description for invapply.
	/// </summary>
	public class invapply : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lbl_imn;
		protected System.Web.UI.WebControls.Label lbl_tel;
		protected System.Web.UI.WebControls.Label lbl_rtel;
		protected System.Web.UI.WebControls.Label lbl_rzip;
		protected System.Web.UI.WebControls.Label lbl_raddr;
		protected System.Web.UI.WebControls.Label lbl_cname;
		protected System.Web.UI.WebControls.Label lbl_deptcd;
		protected System.Web.UI.WebControls.Label lbl_deptnm;
		protected System.Web.UI.WebControls.Label lbl_iano;
		protected System.Web.UI.WebControls.Label lbl_contno;
		protected System.Web.UI.WebControls.Label lbl_projno;
		protected System.Web.UI.WebControls.Label lbl_projyr;
		protected System.Web.UI.WebControls.Label lbl_orgcd;
		protected System.Web.UI.WebControls.Label lbl_mfrno;
		protected System.Web.UI.WebControls.Label lbl_projno2;
		protected System.Web.UI.WebControls.Label lbl_projno1;
		protected System.Web.UI.WebControls.Label lbl_uprice1;
		protected System.Web.UI.WebControls.Label lbl_uprice2;
		protected System.Web.UI.WebControls.Label lbl_amt1;
		protected System.Web.UI.WebControls.Label lbl_amt2;
		protected System.Web.UI.WebControls.Label lbl_unit1;
		protected System.Web.UI.WebControls.Label lbl_unit2;
		protected System.Web.UI.WebControls.Label lbl_desc1;
		protected System.Web.UI.WebControls.Label lbl_desc2;
		protected System.Web.UI.WebControls.Label lbl_iasdate;
		protected System.Web.UI.WebControls.Label lbl_invno;
		protected System.Web.UI.WebControls.RadioButtonList rab_invtpcd;
		protected System.Web.UI.WebControls.Label lbl_remark;
		protected System.Web.UI.WebControls.RadioButtonList Radiobuttonlist1;
		protected System.Web.UI.WebControls.Label lbl_pyat;
		protected System.Web.UI.WebControls.Label lbl_ivat;
		protected System.Web.UI.WebControls.Label lbl_txat;
		protected System.Web.UI.WebControls.Label lbl_item2;
		protected System.Web.UI.WebControls.Label lbl_rnm;
		protected System.Web.UI.WebControls.Label lbl_rjbti;
		protected System.Web.UI.WebControls.Label lbl_item1;
	
		public invapply()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				//
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
