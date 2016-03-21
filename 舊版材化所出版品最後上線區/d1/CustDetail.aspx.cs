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
using System.Configuration;

namespace MRLPub.d1
{
	/// <summary>
	/// Summary description for CustDetail.
	/// </summary>
	public class CustDetail : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgdOrder;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.DataGrid dgdCust;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Web.UI.WebControls.Literal literal1;
		protected System.Web.UI.WebControls.Button btnNew;
		protected System.Web.UI.WebControls.Label lblCaption;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Web.UI.WebControls.DataGrid DataGrid2;
		protected System.Data.SqlClient.SqlCommand sqlCancelOrder;
		protected System.Data.SqlClient.SqlCommand sqlDeleteTemp;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.Button btnClose;
	
		public CustDetail()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			Response.Expires=0;
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				//
				// Evals true first time browser hits the page
				//
				DataSet ds2 = new DataSet();
				this.sqlDataAdapter1.Fill(ds2, "c1_od");
				DataView dv2 = ds2.Tables["c1_od"].DefaultView;
				dv2.RowFilter="od_otp1cd='"+Context.Request.QueryString["type1"]+"'";
				if(dv2.Count==0)
				{
					if(Context.Request.QueryString["type1"]=="01")
						lblMessage.Text="�S���q�\���v�q��";
					else if(Context.Request.QueryString["type1"]=="02")
						lblMessage.Text="�S���ؾ\���v�q��";
					else if(Context.Request.QueryString["type1"]=="03")
						lblMessage.Text="�S�����s���v�q��";
					else if(Context.Request.QueryString["type1"]=="09")
						lblMessage.Text="�S���s����v�q��";
					btnNew.Visible=true;
				}
				else
				{
					if(Context.Request.QueryString["function1"]=="new")
					{
						lblCaption.Text="��:���[�ԲӸ��]�i�ݨ즹�q�檺��l���, ��[�T�w]�Y�N���q���ƥN�J�s�W�q��e��";
						dgdOrder.DataSource=dv2;
						dgdOrder.DataBind();
					}
					else if(Context.Request.QueryString["function1"]=="mod")
					{
						lblCaption.Text="��:���[���P�q��]�Y�N���q����P, ��[�ק�q��]�Y�i�J�q��ק�e��";
						DataGrid2.DataSource=dv2;
						DataGrid2.DataBind();
					}
					lblMessage.Text=dv2.Count.ToString()+"���q����";
					lblCaption.Visible=true;
				}
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
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlCancelOrder = new System.Data.SqlClient.SqlCommand();
			this.sqlDeleteTemp = new System.Data.SqlClient.SqlCommand();
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
			this.dgdOrder.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdOrder_ItemCommand);
			this.dgdOrder.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdOrder_PageIndexChanged);
			this.DataGrid2.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid2_ItemCommand);
			this.DataGrid2.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid2_PageIndexChanged);
			this.DataGrid2.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid2_DeleteCommand);
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.tmp_cust1.od_syscd, dbo.tmp_cust1.od_custno, dbo.tmp_cust1.od_otp1cd, dbo.tmp_cust1.od_otp1seq, dbo.tmp_cust1.begin_end, dbo.tmp_cust1.otp_otp1nm, dbo.tmp_cust1.otp_otp2nm, dbo.tmp_cust1.obtp_obtpnm, dbo.tmp_cust1.ra_oditem, dbo.tmp_cust1.ra_oritem, dbo.c1_or.or_nm, dbo.c1_or.or_custno, dbo.c1_or.or_oritem, dbo.c1_or.or_otp1cd, dbo.c1_or.or_otp1seq, dbo.c1_or.or_syscd FROM dbo.tmp_cust1 INNER JOIN dbo.c1_or ON dbo.tmp_cust1.od_syscd = dbo.c1_or.or_syscd AND dbo.tmp_cust1.od_custno = dbo.c1_or.or_custno AND dbo.tmp_cust1.od_otp1cd = dbo.c1_or.or_otp1cd AND dbo.tmp_cust1.od_otp1seq = dbo.c1_or.or_otp1seq AND dbo.tmp_cust1.ra_oritem = dbo.c1_or.or_oritem";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "tmp_cust1", new System.Data.Common.DataColumnMapping[] {
																																																				   new System.Data.Common.DataColumnMapping("od_syscd", "od_syscd"),
																																																				   new System.Data.Common.DataColumnMapping("od_custno", "od_custno"),
																																																				   new System.Data.Common.DataColumnMapping("od_otp1cd", "od_otp1cd"),
																																																				   new System.Data.Common.DataColumnMapping("od_otp1seq", "od_otp1seq"),
																																																				   new System.Data.Common.DataColumnMapping("begin_end", "begin_end"),
																																																				   new System.Data.Common.DataColumnMapping("otp_otp1nm", "otp_otp1nm"),
																																																				   new System.Data.Common.DataColumnMapping("otp_otp2nm", "otp_otp2nm"),
																																																				   new System.Data.Common.DataColumnMapping("obtp_obtpnm", "obtp_obtpnm"),
																																																				   new System.Data.Common.DataColumnMapping("ra_oditem", "ra_oditem"),
																																																				   new System.Data.Common.DataColumnMapping("ra_oritem", "ra_oritem"),
																																																				   new System.Data.Common.DataColumnMapping("or_nm", "or_nm"),
																																																				   new System.Data.Common.DataColumnMapping("or_custno", "or_custno"),
																																																				   new System.Data.Common.DataColumnMapping("or_oritem", "or_oritem"),
																																																				   new System.Data.Common.DataColumnMapping("or_otp1cd", "or_otp1cd"),
																																																				   new System.Data.Common.DataColumnMapping("or_otp1seq", "or_otp1seq"),
																																																				   new System.Data.Common.DataColumnMapping("or_syscd", "or_syscd")})});
			// 
			// sqlCancelOrder
			// 
			this.sqlCancelOrder.CommandText = "dbo.sp_c1_cancel_order";
			this.sqlCancelOrder.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCancelOrder.Connection = this.sqlConnection1;
			this.sqlCancelOrder.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCancelOrder.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCancelOrder.Parameters.Add(new System.Data.SqlClient.SqlParameter("@custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCancelOrder.Parameters.Add(new System.Data.SqlClient.SqlParameter("@otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCancelOrder.Parameters.Add(new System.Data.SqlClient.SqlParameter("@otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlDeleteTemp
			// 
			this.sqlDeleteTemp.CommandText = "DELETE FROM dbo.tmp_cust1 WHERE (od_syscd = @od_syscd) AND (od_custno = @od_custn" +
				"o) AND (od_otp1cd = @od_otp1cd) AND (od_otp1seq = @od_otp1seq)";
			this.sqlDeleteTemp.Connection = this.sqlConnection1;
			this.sqlDeleteTemp.Parameters.Add(new System.Data.SqlClient.SqlParameter("@od_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "od_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlDeleteTemp.Parameters.Add(new System.Data.SqlClient.SqlParameter("@od_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "od_custno", System.Data.DataRowVersion.Current, null));
			this.sqlDeleteTemp.Parameters.Add(new System.Data.SqlClient.SqlParameter("@od_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "od_otp1cd", System.Data.DataRowVersion.Current, null));
			this.sqlDeleteTemp.Parameters.Add(new System.Data.SqlClient.SqlParameter("@od_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "od_otp1seq", System.Data.DataRowVersion.Current, null));
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void dgdOrder_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string	strbuf;
			dgdOrder.SelectedIndex=e.Item.ItemIndex;
			//			Response.Write(DataGrid1.SelectedItem.Cells[2].Text);
			if(e.CommandName=="Detail")
			{
				strbuf="ShowOrder.aspx?id="+Context.Request.QueryString["id"]+"&type1="+Context.Request.QueryString["type1"]+"&seq="+dgdOrder.SelectedItem.Cells[0].Text.Trim();
				literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\",null,\"height=500,width=750,status=no,scrollbars=yes,toolbar=no,menubar=no,\");</script>";
			}
			else if(e.CommandName=="OK")
			{
				//				Response.Write(dgdOrder.SelectedItem.Cells[0].Text.Trim());
				if(Context.Request.QueryString["function1"]=="new")
				{
					if(Context.Request.QueryString["type1"]=="01")
						Response.Redirect("OrderForm.aspx?id="+Context.Request.QueryString["id"]+"&type1="+Context.Request.QueryString["type1"]+"&seq="+dgdOrder.SelectedItem.Cells[0].Text.Trim());
					else if(Context.Request.QueryString["type1"]=="02")
						Response.Redirect("FreeForm.aspx?id="+Context.Request.QueryString["id"]+"&type1="+Context.Request.QueryString["type1"]+"&seq="+dgdOrder.SelectedItem.Cells[0].Text.Trim());
					else if(Context.Request.QueryString["type1"]=="03")
						Response.Redirect("FreeForm.aspx?id="+Context.Request.QueryString["id"]+"&type1="+Context.Request.QueryString["type1"]+"&seq="+dgdOrder.SelectedItem.Cells[0].Text.Trim());
					else if(Context.Request.QueryString["type1"]=="09")
						Response.Redirect("OrderForm.aspx?id="+Context.Request.QueryString["id"]+"&type1="+Context.Request.QueryString["type1"]+"&seq="+dgdOrder.SelectedItem.Cells[0].Text.Trim());
				}
//				else if(Context.Request.QueryString["function1"]=="mod")
//				{
//					if(Context.Request.QueryString["type1"]=="01")
//						Response.Redirect("OrderFM.aspx?id="+Context.Request.QueryString["id"]+"&type1="+Context.Request.QueryString["type1"]+"&seq="+dgdOrder.SelectedItem.Cells[0].Text.Trim());
//					else if(Context.Request.QueryString["type1"]=="02")
//						Response.Redirect("FreeFM.aspx?id="+Context.Request.QueryString["id"]+"&type1="+Context.Request.QueryString["type1"]+"&seq="+dgdOrder.SelectedItem.Cells[0].Text.Trim());
//					else if(Context.Request.QueryString["type1"]=="03")
//						Response.Redirect("FreeFM.aspx?id="+Context.Request.QueryString["id"]+"&type1="+Context.Request.QueryString["type1"]+"&seq="+dgdOrder.SelectedItem.Cells[0].Text.Trim());
//					else if(Context.Request.QueryString["type1"]=="09")
//						Response.Redirect("OrderFM.aspx?id="+Context.Request.QueryString["id"]+"&type1="+Context.Request.QueryString["type1"]+"&seq="+dgdOrder.SelectedItem.Cells[0].Text.Trim());
//				}
			}

		}

		private void btnNew_Click(object sender, System.EventArgs e)
		{
			if(Context.Request.QueryString["type1"]=="01")
				Response.Redirect("OrderForm.aspx?id="+Context.Request.QueryString["id"]+"&type1="+Context.Request.QueryString["type1"]+"&seq1=000");
			else if(Context.Request.QueryString["type1"]=="02")
				Response.Redirect("FreeForm.aspx?id="+Context.Request.QueryString["id"]+"&type1="+Context.Request.QueryString["type1"]+"&seq1=000");
			else if(Context.Request.QueryString["type1"]=="03")
				Response.Redirect("FreeForm.aspx?id="+Context.Request.QueryString["id"]+"&type1="+Context.Request.QueryString["type1"]+"&seq1=000");
			else if(Context.Request.QueryString["type1"]=="09")
				Response.Redirect("OrderForm.aspx?id="+Context.Request.QueryString["id"]+"&type1="+Context.Request.QueryString["type1"]+"&seq1=000");


		}

		private void dgdOrder_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgdOrder.CurrentPageIndex=e.NewPageIndex;
			DataSet ds2 = new DataSet();
//			this.sqlDataAdapter2.Fill(ds2, "c1_order");
//			DataView dv2 = ds2.Tables["c1_order"].DefaultView;
			this.sqlDataAdapter1.Fill(ds2, "c1_od");
			DataView dv2 = ds2.Tables["c1_od"].DefaultView;
			dv2.RowFilter="od_otp1cd='"+Context.Request.QueryString["type1"]+"'";
			if(dv2.Count==0)
			{
				lblMessage.Text="�S�����v�q��";
				btnNew.Visible=true;
			}
			else
			{
				lblMessage.Text=dv2.Count.ToString()+"���q����";
				dgdOrder.DataSource=dv2;
				dgdOrder.DataBind();
			}
		}

		private void DataGrid2_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
//			this.sqlCancelCom.Parameters["@o_status"].Value="9";
//			this.sqlCancelCom.Parameters["@o_syscd"].Value="C1";
//			this.sqlCancelCom.Parameters["@o_custno"].Value=Context.Request.QueryString["id"];
//			this.sqlCancelCom.Parameters["@o_otp1cd"].Value=Context.Request.QueryString["type1"];
//			this.sqlCancelCom.Parameters["@o_otp1seq"].Value=DataGrid2.SelectedItem.Cells[1].Text.Trim();
//			this.sqlCancelCom.Connection.Open();
//			this.sqlCancelCom.ExecuteNonQuery();
//			this.sqlCancelCom.Connection.Close();
			//���� sp_c1_cancel_order
			this.sqlCancelOrder.Parameters["@syscd"].Value="C1";
			this.sqlCancelOrder.Parameters["@custno"].Value=Context.Request.QueryString["id"];
			this.sqlCancelOrder.Parameters["@otp1cd"].Value=Context.Request.QueryString["type1"];
			this.sqlCancelOrder.Parameters["@otp1seq"].Value=DataGrid2.SelectedItem.Cells[1].Text.Trim();
			this.sqlCancelOrder.Connection.Open();
			SqlDataReader myReader=this.sqlCancelOrder.ExecuteReader();
			myReader.Read();
			myReader.Close();
			this.sqlCancelOrder.Connection.Close();
			//delete temp_cust1
			this.sqlDeleteTemp.Parameters["@od_syscd"].Value="C1";
			this.sqlDeleteTemp.Parameters["@od_custno"].Value=Context.Request.QueryString["id"];
			this.sqlDeleteTemp.Parameters["@od_otp1cd"].Value=Context.Request.QueryString["type1"];
			this.sqlDeleteTemp.Parameters["@od_otp1seq"].Value=DataGrid2.SelectedItem.Cells[1].Text.Trim();
			this.sqlDeleteTemp.Connection.Open();
			this.sqlDeleteTemp.ExecuteNonQuery();
			this.sqlDeleteTemp.Connection.Close();
			DataSet ds2 = new DataSet();
			this.sqlDataAdapter1.Fill(ds2, "c1_od");
			DataView dv2 = ds2.Tables["c1_od"].DefaultView;
			dv2.RowFilter="od_otp1cd='"+Context.Request.QueryString["type1"]+"'";
			lblMessage.Text=dv2.Count.ToString()+"���q����";
			DataGrid2.DataSource=dv2;
			DataGrid2.DataBind();
			DataGrid2.SelectedIndex=-1;
		}

		private void DataGrid2_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGrid2.SelectedIndex=e.Item.ItemIndex;
			if(e.CommandName=="OK")
			{
				if(Context.Request.QueryString["function1"]=="mod")
				{
					if(Context.Request.QueryString["type1"]=="01")
						Response.Redirect("OrderFM.aspx?id="+Context.Request.QueryString["id"]+"&type1="+Context.Request.QueryString["type1"]+"&seq="+DataGrid2.SelectedItem.Cells[1].Text.Trim());
					else if(Context.Request.QueryString["type1"]=="02")
						Response.Redirect("FreeFM.aspx?id="+Context.Request.QueryString["id"]+"&type1="+Context.Request.QueryString["type1"]+"&seq="+DataGrid2.SelectedItem.Cells[1].Text.Trim());
					else if(Context.Request.QueryString["type1"]=="03")
						Response.Redirect("FreeFM.aspx?id="+Context.Request.QueryString["id"]+"&type1="+Context.Request.QueryString["type1"]+"&seq="+DataGrid2.SelectedItem.Cells[1].Text.Trim());
					else if(Context.Request.QueryString["type1"]=="09")
						Response.Redirect("OrderFM.aspx?id="+Context.Request.QueryString["id"]+"&type1="+Context.Request.QueryString["type1"]+"&seq="+DataGrid2.SelectedItem.Cells[1].Text.Trim());
				}
//				Response.Write(DataGrid2.SelectedItem.Cells[1].Text.Trim());
			}

		}

		private void DataGrid2_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid2.CurrentPageIndex=e.NewPageIndex;
			DataSet ds2 = new DataSet();
//			this.sqlDataAdapter2.Fill(ds2, "c1_order");
//			DataView dv2 = ds2.Tables["c1_order"].DefaultView;
			this.sqlDataAdapter1.Fill(ds2, "c1_od");
			DataView dv2 = ds2.Tables["c1_od"].DefaultView;
			dv2.RowFilter="od_otp1cd='"+Context.Request.QueryString["type1"]+"'";
			if(dv2.Count==0)
			{
				lblMessage.Text="�S�����v�q��";
				btnNew.Visible=true;
			}
			else
			{
				lblMessage.Text=dv2.Count.ToString()+"���q����";
				DataGrid2.DataSource=dv2;
				DataGrid2.DataBind();
			}

		}

	}
}
