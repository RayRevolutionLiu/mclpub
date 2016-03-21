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
using System.Text;

namespace MRLPub.d4.WorkingProcess
{
	/// <summary>
	/// Summary description for ContCheckList.
	/// </summary>
	public class ContChkList : MRLPub.d4.Pages.Page
	{
		protected System.Web.UI.WebControls.Label lblContNo;
		protected System.Web.UI.WebControls.TextBox tbxContNo;
		protected System.Web.UI.WebControls.Label lblyyyymmdd;
		protected System.Web.UI.WebControls.TextBox tbxSDate;
		protected System.Web.UI.WebControls.TextBox tbxEDate;
		protected System.Web.UI.WebControls.DataList DataList1;
		protected System.Web.UI.WebControls.Label lblRecordCount;
		protected System.Web.UI.WebControls.CheckBox cbxContNo;
		protected System.Web.UI.WebControls.CheckBox cbxDate;
		protected System.Web.UI.WebControls.CheckBox cbxEmpData;
		protected System.Web.UI.WebControls.DropDownList ddlEmpData;
		protected System.Web.UI.WebControls.DropDownList ddlClosed;
		protected System.Web.UI.WebControls.CheckBox cbxClosed;
		protected System.Web.UI.WebControls.Button btnGo;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				Session.Remove("RPTCONTLIST");
				Bind_ddlEmpData();
			}
			//加入script的部分
			if (!IsClientScriptBlockRegistered("JSCALENDAR"))
			{
				System.IO.TextReader tr = System.IO.File.OpenText(Server.MapPath(".") + "\\ClientScripts\\jsCalendar.js");
				string script = tr.ReadToEnd();
				RegisterClientScriptBlock("JSCALENDAR", script);
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
			this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region 連結員工資料
		private void Bind_ddlEmpData()
		{
			Srspns srspn = new Srspns();
			DataSet ds = srspn.GetSrspns();
			DataView dv = ds.Tables[0].DefaultView;

			this.ddlEmpData.DataTextField = "srspn_cname";
			this.ddlEmpData.DataValueField = "srspn_empno";
			this.ddlEmpData.DataSource = dv;
			this.ddlEmpData.DataBind();

			ddlEmpData.SelectedIndex = -1;
			if (ddlEmpData.Items.FindByValue(WhoAmI.EmpNo) != null)
				ddlEmpData.Items.FindByValue(WhoAmI.EmpNo).Selected = true;
			else
				ddlEmpData.SelectedIndex = 0;
		}
		#endregion

		#region 產生檢核表
		private void btnGo_Click(object sender, System.EventArgs e)
		{
			this.lblRecordCount.Text = "";
			Contracts cont = new Contracts();
			DataSet ds1 = cont.GetContract();
			DataView dv1 = ds1.Tables[0].DefaultView;
			string strFilter = GetFilter();
			dv1.RowFilter=strFilter;
			// 若有資料, 則顯示相關資料; 否則給予錯誤訊息
			if(dv1.Count > 0)
			{
				// 顯示 DataList1 
				this.DataList1.Visible = true;
				
				//Response.Write("有 " + dv1.Count + " 筆資料");
				//				this.lblRecordCount.Text = "查詢結果：共有 " + dv1.Count + " 筆資料!";
				DataList1.DataSource=dv1;
				DataList1.DataBind();
				
				// 特別欄位之輸出格式轉換
				for(int i=0; i<DataList1.Items.Count; i++)
				{
					
					// 抓出 發票廠商收件人 dgdNewInvMfr			
					// 使用 DataSet 方法, 並指定使用的 table 名稱
					string contno = ((Label)DataList1.Items[i].FindControl("lblContno")).Text.Trim();
					InvMfrs im = new InvMfrs();
					DataSet ds2 = im.GetInvMfr(contno);
					DataView dv2 = ds2.Tables[0].DefaultView;
					if (dv2.Count>0)
					{
						((DataGrid)DataList1.Items[i].FindControl("dgdNewInvMfr")).DataSource = dv2;
						((DataGrid)DataList1.Items[i].FindControl("dgdNewInvMfr")).DataBind();
						
						
						// 特別欄位之輸出格式轉換 - 變更發票類別等的格式
						int j;
						for(j=0; j< ((DataGrid)DataList1.Items[i].FindControl("dgdNewInvMfr")).Items.Count ; j++)
						{
							// 院所內註記
							string fgitri = ((DataGrid)DataList1.Items[i].FindControl("dgdNewInvMfr")).Items[j].Cells[12].Text.ToString().Trim();
							if(fgitri == "")
								((DataGrid)DataList1.Items[i].FindControl("dgdNewInvMfr")).Items[j].Cells[12].Text = "否";
							else
							{
								if(fgitri == "06")
									((DataGrid)DataList1.Items[i].FindControl("dgdNewInvMfr")).Items[j].Cells[12].Text = "<font color='Red'>所內</font>";
								if(fgitri == "07")
									((DataGrid)DataList1.Items[i].FindControl("dgdNewInvMfr")).Items[j].Cells[12].Text = "<font color='Red'>院內</font>";
							}
						}					
					}
								
															
					// 抓出 雜誌收件人 DataGrid2
					// 使用 DataSet 方法, 並指定使用的 table 名稱
					FreeBooks fbk1 = new FreeBooks();
					DataSet ds3 = fbk1.GetOrByContNo(contno);
					DataView dv3 = ds3.Tables[0].DefaultView;
					if (dv3.Count>0)
					{
						((DataGrid)DataList1.Items[i].FindControl("dgdNewOr")).DataSource = dv3;
						((DataGrid)DataList1.Items[i].FindControl("dgdNewOr")).DataBind();
						
						int j;
						for(j=0; j< ((DataGrid)DataList1.Items[i].FindControl("dgdNewOr")).Items.Count ; j++)
						{							
							// 海外郵寄註記
							string fgmosea = ((DataGrid)DataList1.Items[i].FindControl("dgdNewOr")).Items[j].Cells[9].Text.ToString().Trim();
							//Response.Write("fgmosea = " + fgmosea + "<br>");
							if(fgmosea == "1")
								((DataGrid)DataList1.Items[i].FindControl("dgdNewOr")).Items[j].Cells[9].Text = "是";
							else
								((DataGrid)DataList1.Items[i].FindControl("dgdNewOr")).Items[j].Cells[9].Text = "否";
							
						}
					}

					FreeBooks fbk2 = new FreeBooks();
					DataSet ds4 = fbk2.GetFbkOrByContNo(contno);
					DataView dv4 = ds4.Tables[0].DefaultView;
					if (dv4.Count>0)
					{
						((DataGrid)DataList1.Items[i].FindControl("dgdNewFreeBk")).DataSource = dv4;
						((DataGrid)DataList1.Items[i].FindControl("dgdNewFreeBk")).DataBind();
					}

					//應用產業及材料特性				
					AtpMtps ams1 = new AtpMtps();
					DataSet ds5 = ams1.GetAtpMtps_Display(contno, "1");
					DataView dv5 = ds5.Tables[0].DefaultView;
					if (dv5.Count>0)
					{
						DataTable dt = new DataTable();
						DataColumn c1 = new DataColumn("cls2_cname", typeof(System.String));
						dt.Columns.Add(c1);
						DataColumn c2 = new DataColumn("cls3_cname", typeof(System.String));
						dt.Columns.Add(c2);
						DataRow dr;
						
						string	strcls2, strcls3;
						strcls2=strcls3="";
						for(int idx=0; idx<dv5.Count; idx++)
						{
							if(dv5[idx].Row["cls2_cname"].ToString()!=strcls2)
							{
								if (idx>0)
								{
									dr=dt.NewRow();
									dr["cls2_cname"]=strcls2;
									dr["cls3_cname"]=strcls3;
									dt.Rows.Add(dr);
								}
								strcls2=dv5[idx].Row["cls2_cname"].ToString();
								strcls3=dv5[idx].Row["cls3_cname"].ToString();
							}
							else
							{
								strcls3=strcls3+";"+dv5[idx].Row["cls3_cname"].ToString();
							}
						}
						//最後一次
						dr=dt.NewRow();
						dr["cls2_cname"]=strcls2;
						dr["cls3_cname"]=strcls3;
						dt.Rows.Add(dr);
						((DataGrid)DataList1.Items[i].FindControl("dgdAtpMatp1")).DataSource = dt;
						((DataGrid)DataList1.Items[i].FindControl("dgdAtpMatp1")).DataBind();
					}
					AtpMtps ams2 = new AtpMtps();
					DataSet ds6 = ams2.GetAtpMtps_Display(contno, "2");
					DataView dv6 = ds6.Tables[0].DefaultView;
			
					if (dv6.Count>0)
					{
						DataTable dt = new DataTable();
						DataColumn c1 = new DataColumn("cls2_cname", typeof(System.String));
						dt.Columns.Add(c1);
						DataColumn c2 = new DataColumn("cls3_cname", typeof(System.String));
						dt.Columns.Add(c2);
						DataRow dr;
						
						string	strcls2, strcls3;
						strcls2=strcls3="";
						for(int idx=0; idx<dv6.Count; idx++)
						{
							if(dv6[idx].Row["cls2_cname"].ToString()!=strcls2)
							{
								if (idx>0)
								{
									dr=dt.NewRow();
									dr["cls2_cname"]=strcls2;
									dr["cls3_cname"]=strcls3;
									dt.Rows.Add(dr);
								}
								strcls2=dv6[idx].Row["cls2_cname"].ToString();
								strcls3=dv6[idx].Row["cls3_cname"].ToString();
							}
							else
							{
								strcls3=strcls3+";"+dv6[idx].Row["cls3_cname"].ToString();
							}
						}
						//最後一次
						dr=dt.NewRow();
						dr["cls2_cname"]=strcls2;
						dr["cls3_cname"]=strcls3;
						dt.Rows.Add(dr);
						((DataGrid)DataList1.Items[i].FindControl("dgdAtpMatp2")).DataSource = dt;
						((DataGrid)DataList1.Items[i].FindControl("dgdAtpMatp2")).DataBind();
					}
				}
			}
			else
			{
				this.lblRecordCount.Text = "查無資料, 請重新輸入查詢條件!";
				
				// 隱藏 DataList1 
				this.DataList1.Visible = false;
			}
		}
		#endregion

		#region 產生Query條件
		private string GetFilter()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("(1=1)");
			//已結案
			if(cbxClosed.Checked)
			sb.Append(" AND (cont_fgclosed='" + ddlClosed.SelectedItem.Value.Trim() + "')");
			//合約編號
			if (cbxContNo.Checked)
			{
				sb.Append(" AND (cont_contno='" + tbxContNo.Text.Trim() + "')");
			}

			//簽約日期
			DateTime sdate;
			DateTime edate;
			if (cbxDate.Checked)
			{
				if (tbxSDate.Text.Trim() != "" && tbxEDate.Text.Trim() != "")
				{
					try
					{
						sdate = DateTime.ParseExact(tbxSDate.Text.Trim(), "yyyy/MM/dd", null);
					}
					catch
					{
						jsAlertMsg("INVALIDSDATE", "區段起始日期格式錯誤，請重新輸入");
						return "";
					}

					try
					{
						edate = DateTime.ParseExact(tbxEDate.Text.Trim(), "yyyy/MM/dd", null);
					}
					catch
					{
						jsAlertMsg("INVALIDEDATE", "區段結束日期格式錯誤，請重新輸入");
						return "";
					}
				
					sb.Append(" AND ('" + sdate.ToString("yyyyMMdd") + "'<=cont_signdate AND cont_signdate<='" + edate.ToString("yyyyMMdd") + "')");
				}
				else if (tbxSDate.Text.Trim() != "")
				{
					try
					{
						sdate = DateTime.ParseExact(tbxSDate.Text.Trim(), "yyyy/MM/dd", null);
					}
					catch
					{
						jsAlertMsg("INVALIDSDATE", "區段起始日期格式錯誤，請重新輸入");
						return "";
					}

					sb.Append(" AND ('" + sdate.ToString("yyyyMMdd") + "'<=cont_signdate)");
				}
				else if (tbxEDate.Text.Trim() != "")
				{
					try
					{
						edate = DateTime.ParseExact(tbxEDate.Text.Trim(), "yyyy/MM/dd", null);
					}
					catch
					{
						jsAlertMsg("INVALIDEDATE", "區段結束日期格式錯誤，請重新輸入");
						return "";
					}

					sb.Append(" AND (cont_signdate<='" + edate.ToString("yyyyMMdd") + "')");
				}
				else
				{
					//do nothing here
				}
			}
			//承辦業務員
			if (cbxEmpData.Checked)
			{
				sb.Append(" AND (" + "cont_empno='" + ddlEmpData.SelectedItem.Value.Trim() + "')");
			}
			return sb.ToString();
		}
		#endregion
	}
}
