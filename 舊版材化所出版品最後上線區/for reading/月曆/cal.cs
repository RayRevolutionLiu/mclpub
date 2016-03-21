namespace ActMsg
{
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

    /// <summary>
    ///    Summary description for cal1.
    /// </summary>
    public class cal : System.Web.UI.Page
    {
		protected System.Web.UI.WebControls.Label lbText;
		protected System.Web.UI.WebControls.Calendar cal11;
	
	public cal()
	{
	    Page.Init += new System.EventHandler(Page_Init);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //
                // Evals true first time browser hits the page
                //
				lbText.Text = DateTime.Today.Format("yyyy/MM/dd", null);
				lbText.SetAttribute("value", DateTime.Today.Format("yyyy/MM/dd", null));
				cal11.SelectedDate = DateTime.Today;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP+ Windows Form Designer.
            //
            InitializeComponent();
        }

        /// <summary>
        ///    Required method for Designer support - do not modify
        ///    the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
		{
			cal11.SelectionChanged += new System.EventHandler (this.cal11_SelectionChanged);
			this.Load += new System.EventHandler (this.Page_Load);
		}

		protected void cal11_SelectionChanged (object sender, System.EventArgs e)
		{
			lbText.Text = cal11.SelectedDate.Format("yyyy/MM/dd", null);
			lbText.SetAttribute("value", cal11.SelectedDate.Format("yyyy/MM/dd", null));
		}
    }
}