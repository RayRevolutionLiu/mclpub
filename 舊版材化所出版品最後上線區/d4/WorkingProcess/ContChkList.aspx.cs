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
			//�[�Jscript������
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

		#region �s�����u���
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

		#region �����ˮ֪�
		private void btnGo_Click(object sender, System.EventArgs e)
		{
			this.lblRecordCount.Text = "";
			Contracts cont = new Contracts();
			DataSet ds1 = cont.GetContract();
			DataView dv1 = ds1.Tables[0].DefaultView;
			string strFilter = GetFilter();
			dv1.RowFilter=strFilter;
			// �Y�����, �h��ܬ������; �_�h�������~�T��
			if(dv1.Count > 0)
			{
				// ��� DataList1 
				this.DataList1.Visible = true;
				
				//Response.Write("�� " + dv1.Count + " �����");
				//				this.lblRecordCount.Text = "�d�ߵ��G�G�@�� " + dv1.Count + " �����!";
				DataList1.DataSource=dv1;
				DataList1.DataBind();
				
				// �S�O��줧��X�榡�ഫ
				for(int i=0; i<DataList1.Items.Count; i++)
				{
					
					// ��X �o���t�Ӧ���H dgdNewInvMfr			
					// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
					string contno = ((Label)DataList1.Items[i].FindControl("lblContno")).Text.Trim();
					InvMfrs im = new InvMfrs();
					DataSet ds2 = im.GetInvMfr(contno);
					DataView dv2 = ds2.Tables[0].DefaultView;
					if (dv2.Count>0)
					{
						((DataGrid)DataList1.Items[i].FindControl("dgdNewInvMfr")).DataSource = dv2;
						((DataGrid)DataList1.Items[i].FindControl("dgdNewInvMfr")).DataBind();
						
						
						// �S�O��줧��X�榡�ഫ - �ܧ�o�����O�����榡
						int j;
						for(j=0; j< ((DataGrid)DataList1.Items[i].FindControl("dgdNewInvMfr")).Items.Count ; j++)
						{
							// �|�Ҥ����O
							string fgitri = ((DataGrid)DataList1.Items[i].FindControl("dgdNewInvMfr")).Items[j].Cells[12].Text.ToString().Trim();
							if(fgitri == "")
								((DataGrid)DataList1.Items[i].FindControl("dgdNewInvMfr")).Items[j].Cells[12].Text = "�_";
							else
							{
								if(fgitri == "06")
									((DataGrid)DataList1.Items[i].FindControl("dgdNewInvMfr")).Items[j].Cells[12].Text = "<font color='Red'>�Ҥ�</font>";
								if(fgitri == "07")
									((DataGrid)DataList1.Items[i].FindControl("dgdNewInvMfr")).Items[j].Cells[12].Text = "<font color='Red'>�|��</font>";
							}
						}					
					}
								
															
					// ��X ���x����H DataGrid2
					// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
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
							// ���~�l�H���O
							string fgmosea = ((DataGrid)DataList1.Items[i].FindControl("dgdNewOr")).Items[j].Cells[9].Text.ToString().Trim();
							//Response.Write("fgmosea = " + fgmosea + "<br>");
							if(fgmosea == "1")
								((DataGrid)DataList1.Items[i].FindControl("dgdNewOr")).Items[j].Cells[9].Text = "�O";
							else
								((DataGrid)DataList1.Items[i].FindControl("dgdNewOr")).Items[j].Cells[9].Text = "�_";
							
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

					//���β��~�Χ��ƯS��				
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
						//�̫�@��
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
						//�̫�@��
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
				this.lblRecordCount.Text = "�d�L���, �Э��s��J�d�߱���!";
				
				// ���� DataList1 
				this.DataList1.Visible = false;
			}
		}
		#endregion

		#region ����Query����
		private string GetFilter()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("(1=1)");
			//�w����
			if(cbxClosed.Checked)
			sb.Append(" AND (cont_fgclosed='" + ddlClosed.SelectedItem.Value.Trim() + "')");
			//�X���s��
			if (cbxContNo.Checked)
			{
				sb.Append(" AND (cont_contno='" + tbxContNo.Text.Trim() + "')");
			}

			//ñ�����
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
						jsAlertMsg("INVALIDSDATE", "�Ϭq�_�l����榡���~�A�Э��s��J");
						return "";
					}

					try
					{
						edate = DateTime.ParseExact(tbxEDate.Text.Trim(), "yyyy/MM/dd", null);
					}
					catch
					{
						jsAlertMsg("INVALIDEDATE", "�Ϭq��������榡���~�A�Э��s��J");
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
						jsAlertMsg("INVALIDSDATE", "�Ϭq�_�l����榡���~�A�Э��s��J");
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
						jsAlertMsg("INVALIDEDATE", "�Ϭq��������榡���~�A�Э��s��J");
						return "";
					}

					sb.Append(" AND (cont_signdate<='" + edate.ToString("yyyyMMdd") + "')");
				}
				else
				{
					//do nothing here
				}
			}
			//�ӿ�~�ȭ�
			if (cbxEmpData.Checked)
			{
				sb.Append(" AND (" + "cont_empno='" + ddlEmpData.SelectedItem.Value.Trim() + "')");
			}
			return sb.ToString();
		}
		#endregion
	}
}
