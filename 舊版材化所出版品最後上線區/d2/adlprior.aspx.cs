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
// SqlConnection
using System.Data.SqlClient;
// WebApplication Virables - Web.config
using System.Configuration;

namespace MRLPub.d2
{
	/// <summary>
	/// Summary description for adlprior.
	/// </summary>
	public class adlprior : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.TextBox tbxQString;
		protected System.Web.UI.WebControls.DropDownList ddlQueryField;
		protected System.Web.UI.WebControls.Button Query;
		protected System.Web.UI.WebControls.Button btnShowAll;
		protected System.Web.UI.WebControls.Button btnAddNew;
		protected System.Web.UI.WebControls.Button btnReturnHome;
		protected System.Web.UI.WebControls.Label lblResult;
		protected System.Web.UI.WebControls.Label lblNum;
		protected System.Web.UI.WebControls.Label lblState;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;

		public adlprior()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				// ���w ddlQueryField ���w�]�ﶵ
				this.ddlQueryField.SelectedIndex = 00;
				BindGrid();
			}

		}

		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}


		public void BindGrid()
		{
//			//Kevin: �z�L SqlDataAdapter �q��Ʈw��Ū�����
//			//string DSN = "Data Source=isccom2;Initial Catalog=mrlpub;User ID=webuser;Password=db600";
//			//SqlConnection myConnection = new SqlConnection(DSN);
//			string strConn="Data Source=isccom2;database=mrlpub;uid=webuser;pwd=db600";
//			//string strConn = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
//			SqlConnection myConnection = new SqlConnection(strConn);
//
//			string SQL = " SELECT         dbo.c2_lprior.lp_lpid, dbo.c2_lprior.lp_bkcd, dbo.c2_lprior.lp_priorseq, ";
//			SQL = SQL + " dbo.book.bk_nm, dbo.c2_ltp.ltp_nm, dbo.c2_clr.clr_nm, dbo.c2_pgsize.pgs_nm, ";
//			SQL = SQL + " dbo.c2_lprior.lp_ltpcd, dbo.c2_lprior.lp_clrcd, dbo.c2_lprior.lp_pgscd, ";
//			SQL = SQL + " COUNT(dbo.c2_pub.pub_contno) AS PubCounts ";
//			SQL = SQL + " FROM             dbo.c2_lprior INNER JOIN ";
//			SQL = SQL + " dbo.book ON dbo.c2_lprior.lp_bkcd = dbo.book.bk_bkcd INNER JOIN " ;
//			SQL = SQL + " dbo.c2_clr ON dbo.c2_lprior.lp_clrcd = dbo.c2_clr.clr_clrcd INNER JOIN ";
//			SQL = SQL + " dbo.c2_ltp ON dbo.c2_lprior.lp_ltpcd = dbo.c2_ltp.ltp_ltpcd INNER JOIN ";
//			SQL = SQL + " dbo.c2_pgsize ON ";
//			SQL = SQL + " dbo.c2_lprior.lp_pgscd = dbo.c2_pgsize.pgs_pgscd LEFT OUTER JOIN ";
//			SQL = SQL + " dbo.c2_pub ON dbo.c2_ltp.ltp_ltpcd = dbo.c2_pub.pub_ltpcd AND ";
//			SQL = SQL + " dbo.c2_clr.clr_clrcd = dbo.c2_pub.pub_clrcd AND ";
//			SQL = SQL + " dbo.c2_pgsize.pgs_pgscd = dbo.c2_pub.pub_pgscd ";
//			SQL = SQL + " GROUP BY  dbo.c2_lprior.lp_lpid, dbo.c2_lprior.lp_bkcd, dbo.c2_lprior.lp_priorseq, ";
//			SQL = SQL + " dbo.book.bk_nm, dbo.c2_ltp.ltp_nm, dbo.c2_clr.clr_nm, dbo.c2_pgsize.pgs_nm, ";
//			SQL = SQL + " dbo.c2_lprior.lp_ltpcd, dbo.c2_lprior.lp_clrcd, dbo.c2_lprior.lp_pgscd ";
//			SqlDataAdapter myCommand = new SqlDataAdapter(SQL,myConnection);
//
//			DataSet ds = new DataSet();
//			myCommand.Fill(ds,"c2_lprior");
//
//			DataView dv = ds.Tables["c2_lprior"].DefaultView;
//
//			lblResult.Text = "";
//			lblNum.Text = dv.Count.ToString();

			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "c2_lprior");
			DataView dv1 = ds1.Tables["c2_lprior"].DefaultView;

			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� 1=1 and ��L rowfilter ����
			string rowfilterstr1 = "1=1";
			if(this.tbxQString.Text !=null && this.tbxQString.Text.ToString().Trim() != "")
			{
				if(this.ddlQueryField.SelectedIndex == 0)
				{
					rowfilterstr1 = rowfilterstr1 + " AND bk_nm like '%" + this.tbxQString.Text.ToString().Trim() + "%' ";
				}
				else if(this.ddlQueryField.SelectedIndex == 1)
				{
					rowfilterstr1 = rowfilterstr1 + " AND lp_priorseq like '%" + this.tbxQString.Text.ToString() + "%' ";
				}
				else if(this.ddlQueryField.SelectedIndex == 2)
				{
					rowfilterstr1 = rowfilterstr1 + " AND ltp_nm like '%" + this.tbxQString.Text.ToString() + "%' ";
				}
				else if(this.ddlQueryField.SelectedIndex == 3)
				{
					rowfilterstr1 = rowfilterstr1 + " AND clr_nm like '%" + this.tbxQString.Text.ToString() + "%' ";
				}
				else if(this.ddlQueryField.SelectedIndex == 4)
				{
					rowfilterstr1 = rowfilterstr1 + " AND pgs_nm like '%" + this.tbxQString.Text.ToString() + "%' ";
				}
			}
			else
			{
				rowfilterstr1 = rowfilterstr1;
			}
			dv1.RowFilter = rowfilterstr1;

			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
			//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");

			// �Y�j�M���G�� "�䤣��" ���B�z
			if (dv1.Count > 0)
			{
				DataGrid1.DataSource = dv1;
				DataGrid1.DataBind();

				//dv1.RowFilter = ddlQueryField.SelectedItem.Value + " LIKE '%" + tbxQString.Text.Trim() +"%'";
				lblResult.Text = "�j�M���G...";
				lblNum.Text = dv1.Count.ToString();
				lblState.Text = "";
			}
			else
			{
			}


			// �ˬd�� �s�W�έק�^�Ӯ�, �������T�{�T��
			if (Request.QueryString["ID"] != null)
			{
				string id = Request.QueryString["action"].ToString();
				if (id == "addnew_ok")
				{
					lblState.Text = " ... ��Ʒs�W���\ !";
				}
				if (id == "edit_ok")
				{
					lblState.Text = " ... ��ƭק令�\ !";
				}
			}

			// ��_ ddlQueryField ���w�]�ﶵ
			//this.ddlQueryField.SelectedIndex = 00;
		}


		private void DataGrid1_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName == "Delete")
			{
				// �ˬd��ƶ��O�_�w�Q�ϥ�, �Y�O, �N�����\�R��
				DataGrid1.SelectedIndex=e.Item.ItemIndex;

				// ��X �s�i������줧��
				string strbkcd = e.Item.Cells[6].Text.ToString();
				string strltpcd = e.Item.Cells[7].Text.ToString();
				string strclrcd = e.Item.Cells[8].Text.ToString();
				string strpgscd = e.Item.Cells[9].Text.ToString();
				//Response.Write("strbkcd= "+ strbkcd + "<BR>");
				//Response.Write("strltpcd= "+ strltpcd + "<BR>");
				//Response.Write("strclrcd= "+ strclrcd + "<BR>");
				//Response.Write("strpgscd= "+ strpgscd + "<BR>");


				// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
				DataSet ds1 = new DataSet();
				this.sqlDataAdapter1.Fill(ds1, "c2_pub");
				DataView dv1 = ds1.Tables["c2_pub"].DefaultView;

				// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
				// �] Row Filter: default �� 1=1 and ��L rowfilter ����
				string rowfilterstr1 = "1=1";
				rowfilterstr1 = rowfilterstr1 + " AND lp_bkcd='" + strbkcd + "'";
				rowfilterstr1 = rowfilterstr1 + " AND lp_ltpcd='" + strltpcd + "'";
				rowfilterstr1 = rowfilterstr1 + " AND lp_clrcd='" + strclrcd + "'";
				rowfilterstr1 = rowfilterstr1 + " AND lp_pgscd='" + strpgscd + "'";
				dv1.RowFilter = rowfilterstr1;

				// �ˬd�ÿ�X �̫� Row Filter �����G
				//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
				//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");


				// �Y�j�M���G�� "�䤣��" ���B�z
				if (dv1.Count > 0)
				{
					int intPubCounts = Convert.ToInt16(dv1[0]["PubCounts"].ToString().Trim());
					//Response.Write("intPubCounts= "+ intPubCounts + "<BR>");

					// �Y �w�ϥΤ��������� > 0, ��ܤw��������ƨϥΦ��u������, �G���i�R��
					if (intPubCounts > 0)
					{
						// �H Javascript �� window.close() �ӧi���T��
						LiteralControl litAlert1 = new LiteralControl();
						litAlert1.Text = "<script language=javascript>alert(\"�R���L�ġG������Ƥw�Q�ϥ�, �N�����\�R���I\");</script>";
						Page.Controls.Add(litAlert1);
					}
					// �i��R��
					else
					{
						// ��X ���w��m���ƪ��u������ ��
						string CurrentBookCode = e.Item.Cells[6].Text.ToString();
						string CurrentPriorSeq = e.Item.Cells[2].Text.ToString();
						int intCurrentPriorSeq = Convert.ToInt16(CurrentPriorSeq);
						//Response.Write("CurrentBookCode= " + CurrentBookCode + "<br>");
						//Response.Write("CurrentPriorSeq= " + CurrentPriorSeq + "<br>");
						//Response.Write("intCurrentPriorSeq= " + intCurrentPriorSeq + "<br>");

						// �����R�� ���w��m
						string strConn="Data Source=isccom2;database=mrlpub;uid=webuser;pwd=db600";
						//string strConn = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
						SqlConnection myConn=new SqlConnection(strConn);
						SqlDataAdapter cmd=new SqlDataAdapter("delete from c2_lprior where lp_lpid=@lp_lpid",myConn);

						cmd.SelectCommand.Parameters.Add("@lp_lpid",SqlDbType.Int,4).Value=e.Item.Cells[0].Text;

						cmd.SelectCommand.Connection.Open();
						cmd.SelectCommand.ExecuteNonQuery();
						cmd.SelectCommand.Connection.Close();

						DataGrid1.CurrentPageIndex=0;
						BindGrid();


						// ��X�ثe�̤j�� MaxLPSeq, �n��K��X���ᵧ�Ƥ��v����
						// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
						DataSet ds2 = new DataSet();
						// �� sqlDataAdapter1 �L�o���� - ���w Parameters
						this.sqlDataAdapter2.SelectCommand.Parameters["@bkcd"].Value = CurrentBookCode;
						this.sqlDataAdapter2.Fill(ds2, "c2_lprior");
						DataView dv2 = ds2.Tables["c2_lprior"].DefaultView;

						// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
						// �] Row Filter: default �� 1=1 and ��L rowfilter ����
						string rowfilterstr2 = "1=1";
						dv2.RowFilter = rowfilterstr2;

						// �ˬd�ÿ�X �̫� Row Filter �����G
						//Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
						//Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");

						// �Y�j�M���G�� "�䤣��" ���B�z
						string MaxLPSeq = "01";
						int intMaxLPSeq = Convert.ToInt16(MaxLPSeq);
						if (dv2.Count > 0)
						{
							MaxLPSeq = dv2[0]["MaxSeq"].ToString();
							intMaxLPSeq = Convert.ToInt16(MaxLPSeq);
							int intNextLPSeq = intCurrentPriorSeq+1;
							//Response.Write("intMaxLPSeq= " + intMaxLPSeq + "<br>");
							//Response.Write("intNextLPSeq= " + intNextLPSeq + "<br>");

							for(int i=intNextLPSeq; i<=intMaxLPSeq; i++)
							{
								//Response.Write("i= " + i + ", ");
								string stri = Convert.ToString(i);
								if(stri.Length < 2)
									stri = "0" + stri;
								//Response.Write("stri= " + stri + "<br>");

								// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
								DataSet ds3 = new DataSet();
								this.sqlDataAdapter3.Fill(ds3, "c2_lprior");
								DataView dv3 = ds3.Tables["c2_lprior"].DefaultView;

								// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
								// �] Row Filter: default �� 1=1 and ��L rowfilter ����
								string rowfilterstr3 = "1=1";
								rowfilterstr3 = rowfilterstr3 + " AND lp_bkcd=" + CurrentBookCode;
								rowfilterstr3 = rowfilterstr3 + " AND lp_priorseq=" + stri;
								dv3.RowFilter = rowfilterstr3;

								// �ˬd�ÿ�X �̫� Row Filter �����G
								//Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
								//Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");

								if(dv3.Count > 0)
								{
									// ��X ���ᵧ�Ƥ������� - ���y�N�X, �s�i�����N�X, �s�i��m�N�X, �s�i�g�T�N�X
									string iBookCode = dv3[0]["lp_bkcd"].ToString();
									string iLayoutTypeCode = dv3[0]["lp_ltpcd"].ToString();
									string iColorCode = dv3[0]["lp_clrcd"].ToString();
									string iPageSizeCode = dv3[0]["lp_pgscd"].ToString();
									//Response.Write("iBookCode= " + iBookCode + ", ");
									//Response.Write("iLPSeq= " + stri + ", ");
									//Response.Write("iLayoutTypeCode= " + iLayoutTypeCode + ", ");
									//Response.Write("iColorCode= " + iColorCode + ", ");
									//Response.Write("iPageSizeCode= " + iPageSizeCode + "<br>");

									int intNewLPSeq = i-1;
									string strNewLPSeq = Convert.ToString(intNewLPSeq);
									if(strNewLPSeq.Length < 2)
										strNewLPSeq = "0" + strNewLPSeq;
									//Response.Write("strNewLPSeq= " + strNewLPSeq + "<br>");

									// �����s�ʧ@
									//string strConn9="server=isccom2;database=mrlpub;uid=webuser;pwd=db600";
									string strConn9 = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
									SqlConnection myConn9=new SqlConnection(strConn9);

									SqlDataAdapter cmd9=new SqlDataAdapter("UPDATE c2_lprior SET lp_priorseq = '" + strNewLPSeq + "' WHERE (lp_bkcd = @lp_bkcd) AND (lp_ltpcd = @lp_ltpcd) AND (lp_clrcd = @lp_clrcd) AND (lp_pgscd = @lp_pgscd)",myConn9);
									//Response.Write("iLPSeq= " + stri + "<br>");
									//Response.Write("cmd9= UPDATE c2_lprior SET lp_priorseq = '" + strNewLPSeq + "' WHERE (lp_bkcd = " + iBookCode + ") AND (lp_ltpcd = " + iLayoutTypeCode + ") AND (lp_clrcd = " + iColorCode+ ") AND (lp_pgscd = " + iPageSizeCode + ")<br><br>");

									//cmd9.SelectCommand.Parameters.Add("@lp_lpid",SqlDbType.Int,4).Value = id;
									cmd9.SelectCommand.Parameters.Add("@lp_bkcd",SqlDbType.Char,2).Value = iBookCode;
									cmd9.SelectCommand.Parameters.Add("@lp_priorseq",SqlDbType.Char,2).Value = CurrentPriorSeq;
									cmd9.SelectCommand.Parameters.Add("@lp_ltpcd",SqlDbType.Char,2).Value = iLayoutTypeCode;
									cmd9.SelectCommand.Parameters.Add("@lp_clrcd",SqlDbType.Char,2).Value = iColorCode;
									cmd9.SelectCommand.Parameters.Add("@lp_pgscd",SqlDbType.Char,2).Value = iPageSizeCode;

									DataSet ds9 = new DataSet();
									cmd9.Fill(ds9,"c2_lprior");
								}
							}
						}
						else
						{
							MaxLPSeq = MaxLPSeq;
						}
						//Response.Write("MaxLPSeq= " + MaxLPSeq + "<br>");


						DataGrid1.CurrentPageIndex=0;
						BindGrid();

						this.lblState.Text = " ... ��ƧR�����\ !";
					}
				}
				// �i��R��
				else
				{
					this.lblState.Text = "�d�L�������, �L�k�R��!";
				}

			// ���� if(e.CommandName == "Delete")
			}
		}


		// �ק���s
		private void DataGrid1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// ��X�e���W����
			string id = DataGrid1.SelectedItem.Cells[0].Text.ToString();
			string strbkcd = DataGrid1.SelectedItem.Cells[6].Text.ToString();
			string strpriorseq = DataGrid1.SelectedItem.Cells[2].Text.ToString();
			string strltpcd = DataGrid1.SelectedItem.Cells[7].Text.ToString();
			string strclrcd = DataGrid1.SelectedItem.Cells[8].Text.ToString();
			string strpgscd = DataGrid1.SelectedItem.Cells[9].Text.ToString();
			int intPubCounts = Convert.ToInt32(DataGrid1.SelectedItem.Cells[10].Text.ToString());
			//Response.Write("strbkcd= "+ strbkcd + "<BR>");
			//Response.Write("strpriorseq= "+ strpriorseq + "<BR>");
			//Response.Write("strltpcd= "+ strltpcd + "<BR>");
			//Response.Write("strclrcd= "+ strclrcd + "<BR>");
			//Response.Write("strpgscd= "+ strpgscd + "<BR>");
			//Response.Write("intPubCounts= "+ intPubCounts + "<BR>");

			// �Y �w�ϥΤ��������� > 0, ��ܤw��������ƨϥΦ��u������, �G���i�ק�
			if(intPubCounts > 0)
			{
				// �H Javascript �� window.close() �ӧi���T��
				LiteralControl litAlert1 = new LiteralControl();
				litAlert1.Text = "<script language=javascript>alert(\"�ק�L�ġG������Ƥw�Q�ϥ�, �N�����\�ק�I\");</script>";
				Page.Controls.Add(litAlert1);

				//Response.Redirect("adlprior_edit.aspx?ID=" + id);
			}
			else
			{
				Response.Redirect("adlprior_edit.aspx?ID=" + id);
			}
		}


		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			BindGrid();

			lblState.Text = "";
		}


		private void Query_Click(object sender, System.EventArgs e)
		{
			DataGrid1.CurrentPageIndex=0;
			DataGrid1.EditItemIndex=-1;
			BindGrid();

			lblState.Text = "";
		}


		private void btnShowAll_Click(object sender, System.EventArgs e)
		{
			tbxQString.Text="";
			DataGrid1.CurrentPageIndex=0;
			BindGrid();

			lblState.Text = "";
		}


		private void btnAddNew_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("adlprior_addnew.aspx?function=");
		}


		private void btnReturnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("../default.aspx");
		}


		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid1.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_DeleteCommand);
			this.DataGrid1.SelectedIndexChanged += new System.EventHandler(this.DataGrid1_SelectedIndexChanged);
			this.Query.Click += new System.EventHandler(this.Query_Click);
			this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
			this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
			this.btnReturnHome.Click += new System.EventHandler(this.btnReturnHome_Click);
			//
			// sqlDataAdapter3
			//
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_lprior", new System.Data.Common.DataColumnMapping[] {
																																																				   new System.Data.Common.DataColumnMapping("lp_bkcd", "lp_bkcd"),
																																																				   new System.Data.Common.DataColumnMapping("lp_priorseq", "lp_priorseq"),
																																																				   new System.Data.Common.DataColumnMapping("lp_clrcd", "lp_clrcd"),
																																																				   new System.Data.Common.DataColumnMapping("lp_ltpcd", "lp_ltpcd"),
																																																				   new System.Data.Common.DataColumnMapping("lp_pgscd", "lp_pgscd")})});
			//
			// sqlDataAdapter2
			//
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_lprior", new System.Data.Common.DataColumnMapping[] {
																																																				   new System.Data.Common.DataColumnMapping("lp_bkcd", "lp_bkcd"),
																																																				   new System.Data.Common.DataColumnMapping("MaxSeq", "MaxSeq")})});
			//
			// sqlDataAdapter1
			//
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_lprior", new System.Data.Common.DataColumnMapping[] {
																																																				   new System.Data.Common.DataColumnMapping("lp_bkcd", "lp_bkcd"),
																																																				   new System.Data.Common.DataColumnMapping("lp_priorseq", "lp_priorseq"),
																																																				   new System.Data.Common.DataColumnMapping("lp_ltpcd", "lp_ltpcd"),
																																																				   new System.Data.Common.DataColumnMapping("lp_clrcd", "lp_clrcd"),
																																																				   new System.Data.Common.DataColumnMapping("lp_pgscd", "lp_pgscd"),
																																																				   new System.Data.Common.DataColumnMapping("PubCounts", "PubCounts"),
																																																				   new System.Data.Common.DataColumnMapping("lp_lpid", "lp_lpid"),
																																																				   new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																				   new System.Data.Common.DataColumnMapping("ltp_nm", "ltp_nm"),
																																																				   new System.Data.Common.DataColumnMapping("clr_nm", "clr_nm"),
																																																				   new System.Data.Common.DataColumnMapping("pgs_nm", "pgs_nm")})});
			//
			// sqlSelectCommand1
			//
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.c2_lprior.lp_bkcd, dbo.c2_lprior.lp_priorseq, dbo.c2_lprior.lp_ltpcd, dbo.c2_lprior.lp_clrcd, dbo.c2_lprior.lp_pgscd, COUNT(dbo.c2_pub.pub_contno) AS PubCounts, dbo.c2_lprior.lp_lpid, dbo.book.bk_nm, dbo.c2_ltp.ltp_nm, dbo.c2_clr.clr_nm, dbo.c2_pgsize.pgs_nm FROM dbo.c2_lprior INNER JOIN dbo.book ON dbo.c2_lprior.lp_bkcd = dbo.book.bk_bkcd INNER JOIN dbo.c2_ltp ON dbo.c2_lprior.lp_ltpcd = dbo.c2_ltp.ltp_ltpcd INNER JOIN dbo.c2_clr ON dbo.c2_lprior.lp_clrcd = dbo.c2_clr.clr_clrcd INNER JOIN dbo.c2_pgsize ON dbo.c2_lprior.lp_pgscd = dbo.c2_pgsize.pgs_pgscd LEFT OUTER JOIN dbo.c2_pub ON dbo.c2_lprior.lp_clrcd = dbo.c2_pub.pub_clrcd AND dbo.c2_lprior.lp_ltpcd = dbo.c2_pub.pub_ltpcd AND dbo.c2_lprior.lp_pgscd = dbo.c2_pub.pub_pgscd AND dbo.c2_lprior.lp_bkcd = dbo.c2_pub.pub_bkcd GROUP BY dbo.c2_lprior.lp_bkcd, dbo.c2_lprior.lp_priorseq, dbo.c2_lprior.lp_ltpcd, dbo.c2_lprior.lp_clrcd, dbo.c2_lprior.lp_pgscd, dbo.c2_lprior.lp_lpid, dbo.book.bk_nm, dbo.c2_ltp.ltp_nm, dbo.c2_clr.clr_nm, dbo.c2_pgsize.pgs_nm ORDER BY dbo.c2_lprior.lp_bkcd, dbo.c2_lprior.lp_priorseq";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			//
			// sqlConnection1
			//
//			this.sqlConnection1.ConnectionString = "data source=ISCCOM2;initial catalog=mrlpub;password=db600;persist security info=T" +
//				"rue;user id=webuser;workstation id=17-0890711-01;packet size=4096";
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			//
			// sqlSelectCommand2
			//
			this.sqlSelectCommand2.CommandText = "SELECT lp_bkcd, MAX(lp_priorseq) AS MaxSeq FROM dbo.c2_lprior WHERE (lp_bkcd = @b" +
				"kcd) GROUP BY lp_bkcd";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@bkcd", System.Data.SqlDbType.VarChar, 2, "lp_bkcd"));
			//
			// sqlSelectCommand3
			//
			this.sqlSelectCommand3.CommandText = "SELECT lp_bkcd, lp_priorseq, lp_clrcd, lp_ltpcd, lp_pgscd FROM dbo.c2_lprior";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion



	}
}
