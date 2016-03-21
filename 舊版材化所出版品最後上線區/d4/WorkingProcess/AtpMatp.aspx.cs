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
	/// Summary description for AtpMatp.
	/// </summary>
	public class AtpMatp : MRLPub.d4.Pages.Page
	{
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidSelected;
		protected System.Web.UI.WebControls.DropDownList ddlClass1;
		protected System.Web.UI.WebControls.DataList dlClass22;
		protected System.Web.UI.WebControls.Button btnSave1;
		protected System.Web.UI.WebControls.DataList dlClass21;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				string contno, classid;

				if (Request.QueryString["NewContNo"] == null || Request.QueryString["NewContNo"] == "")
				{
					throw new Exception("�L�X���s��");
				}
				else
				{
					contno = Request.QueryString["NewContNo"];
				}
				classid = Request.QueryString["ClassId"];
				ddlClass1.Items.FindByValue(classid).Selected=true;
				ddlClass1.Enabled=false;

				//�ˬd�A�p�GPage��l�ƮɡA�o�Ӹ�Ʀs�b�A�N�O�ݦs�Ȧs�b�A�N��ݦs��ƲM��
				if (Session["ATPMTPS"] != null)
				{
					Session.Remove("ATPMTPS");
				}

				InitData();

				LoadAtpMtps(contno);
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
			this.ddlClass1.SelectedIndexChanged += new System.EventHandler(this.ddlClass1_SelectedIndexChanged);
			this.btnSave1.Click += new System.EventHandler(this.btnSave_Click);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.dlClass21.SelectedIndexChanged += new System.EventHandler(this.dlClass21_SelectedIndexChanged);
			this.dlClass22.SelectedIndexChanged += new System.EventHandler(this.dlClass22_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region ��l�����O�ﶵ
		private void InitData()
		{
			Bing_dlClass21();
			Bing_dlClass22();
			//�w�]������β��~
			if (ddlClass1.SelectedItem.Value == "1")
			{
				dlClass21.Visible = true;
				dlClass22.Visible = false;
			}
			else
			{
				dlClass21.Visible = false;
				dlClass22.Visible = true;
			}
			//			Bind_Class2_1();
//			Bind_Class3_1(1, 1);
//			Bind_Class2_2();
//			Bind_Class3_2(1, 2);
		}
		#endregion

		#region �s�����β��~Class2
		private void Bing_dlClass21()
		{
			AtpMtps ams = new AtpMtps();
			DataSet ds = ams.GetClass2(1);
			DataView dv = ds.Tables[0].DefaultView;
			
			dlClass21.DataSource = dv;
			dlClass21.DataBind();

			Bind_cblClass321();
		}
		#endregion

		#region �s�����β��~Class3
		private void Bind_cblClass321()
		{
			AtpMtps ams = new AtpMtps();

			for (int i=0; i<dlClass21.Items.Count; i++)
			{
				int cls2id = 1;
				if (dlClass21.Items[i].FindControl("tbxClass21") != null)
					cls2id = Convert.ToInt32(((TextBox)dlClass21.Items[i].FindControl("tbxClass21")).Text);
				else
				{
					Response.Write("no cls2id...");
				}
				DataSet ds = ams.GetClass3(1, cls2id);
				DataView dv = ds.Tables[0].DefaultView;

				if (dlClass21.Items[i].FindControl("cblClass321") != null)
				{
					((CheckBoxList)dlClass21.Items[i].FindControl("cblClass321")).DataSource = dv;
					((CheckBoxList)dlClass21.Items[i].FindControl("cblClass321")).DataTextField = "cls3_cname";
					((CheckBoxList)dlClass21.Items[i].FindControl("cblClass321")).DataValueField = "cls3_cls123id";
					((CheckBoxList)dlClass21.Items[i].FindControl("cblClass321")).DataBind();
				}
				else
				{
					Response.Write("no control found");
				}
			}

		}
		#endregion

		#region �s�����ƯS��Class2
		private void Bing_dlClass22()
		{
			AtpMtps ams = new AtpMtps();
			DataSet ds = ams.GetClass2(2);
			DataView dv = ds.Tables[0].DefaultView;
			
			dlClass22.DataSource = dv;
			dlClass22.DataBind();

			Bind_cblClass322();
		}
		#endregion

		#region �s�����ƯS��Class3
		private void Bind_cblClass322()
		{
			AtpMtps ams = new AtpMtps();

			for (int i=0; i<dlClass22.Items.Count; i++)
			{
				int cls2id = 1;
				if (dlClass22.Items[i].FindControl("tbxClass22") != null)
					cls2id = Convert.ToInt32(((TextBox)dlClass22.Items[i].FindControl("tbxClass22")).Text);
				else
				{
					Response.Write("no cls2id...");
				}
				DataSet ds = ams.GetClass3(2, cls2id);
				DataView dv = ds.Tables[0].DefaultView;

				if (dlClass22.Items[i].FindControl("cblClass322") != null)
				{
					((CheckBoxList)dlClass22.Items[i].FindControl("cblClass322")).DataSource = dv;
					((CheckBoxList)dlClass22.Items[i].FindControl("cblClass322")).DataTextField = "cls3_cname";
					((CheckBoxList)dlClass22.Items[i].FindControl("cblClass322")).DataValueField = "cls3_cls123id";
					((CheckBoxList)dlClass22.Items[i].FindControl("cblClass322")).DataBind();
				}
				else
				{
					Response.Write("no control found");
				}
			}

		}
		#endregion

		#region �������β��~�Χ��ƯS��
		private void ddlClass1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (ddlClass1.SelectedItem.Value == "1")
			{
				dlClass21.Visible = true;
				dlClass22.Visible = false;
			}
			else
			{
				dlClass21.Visible = false;
				dlClass22.Visible = true;
			}
		}
		#endregion

		#region �x�s ���β��~�P���ƯS��
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			//�򥻤W�X���s���p�G������N���F
			string contno="999999";

			if (Request.QueryString["NewContNo"] != null && Request.QueryString["NewContNo"] != "")
			{
				contno = Request.QueryString["NewContNo"];
			}



			//���β��~�P���ƯS��
			ArrayList ary = new ArrayList();

			CheckBoxList cbl1;
			for (int i=0; i<dlClass21.Items.Count; i++)
			{
				cbl1 = (CheckBoxList)dlClass21.Items[i].FindControl("cblClass321");
				foreach(ListItem item in cbl1.Items)
				{
					if (item.Selected) ary.Add(item.Value);
				}
			}

			CheckBoxList cbl2;
			for (int j=0; j<dlClass22.Items.Count; j++)
			{
				cbl2 = (CheckBoxList)dlClass22.Items[j].FindControl("cblClass322");
				foreach(ListItem item in cbl2.Items)
				{
					if (item.Selected) ary.Add(item.Value);
				}
			}

			string[] selstrs = (string[])ary.ToArray(typeof(string));
			//�H�W�Φ�Value Array

//			Check��
//			string selstr = "";
//
//			for (int k=0; k<selstrs.Length; k++)
//			{
//				selstr += selstrs.GetValue(k).ToString();
//				selstr += ";";
//			}
//
//			Response.Write("t=" + selstrs.Length.ToString() + "<br>");
//			Response.Write("v=" + selstr);


			string itemvalue;
			int cls1id, cls2id, cls3id;
			ArrayList amary = new ArrayList();
			for (int k=0; k<selstrs.Length; k++)
			{
				itemvalue = selstrs.GetValue(k).ToString();
				cls1id = Convert.ToInt32(itemvalue.Substring(0, 2));
				cls2id = Convert.ToInt32(itemvalue.Substring(2, 2));
				cls3id = Convert.ToInt32(itemvalue.Substring(4, 2));
				AMEntry ame = new AMEntry(contno, cls1id, cls2id, cls3id);
				amary.Add(ame);
			}

//			��X�ˬd
//			for(int x=0; x<amary.Count; x++)
//			{
//				Response.Write(((AMEntry)amary[x]).Cls1Id.ToString() + ":" + ((AMEntry)amary[x]).Cls2Id.ToString() + ":" + ((AMEntry)amary[x]).Cls3Id.ToString() + "<br>");
//			}

			AtpMtps ams = new AtpMtps();
			bool returnv=ams.SaveAtpMtps(contno, amary.ToArray());
			if(returnv)
			{
				jsAlertMsg("SAVECUSSESS", "���β��~�B���ƯS�ʵ�����x�s���\");
				//�[�Jscript������
				if (!IsClientScriptBlockRegistered("JSCALENDAR"))
				{
					System.IO.TextReader tr = System.IO.File.OpenText(Server.MapPath(".") + "\\ClientScripts\\jsCloseForm.js");
					string script = tr.ReadToEnd();
					RegisterClientScriptBlock("JSCALENDAR", script);
				}
			}
		}
		#endregion

		#region �Ĥ@�����J���O���
		private void LoadAtpMtps(string contno)
		{


			//���β��~�P���ƯS��
			AtpMtps ams = new AtpMtps();
			DataSet ds = ams.GetAtpMtps(contno);
			DataView dv = ds.Tables[0].DefaultView;

//			ArrayList ary = new ArrayList();
//
//			for (int i=0; i<dv.Count; i++)
//			{
//				AMEntry ame = new AMEntry(contno, Convert.ToInt32(dv[i]["cls_cls1id"]), Convert.ToInt32(dv[i]["cls_cls2id"]), Convert.ToInt32(dv[i]["cls_cls3id"]));
//				ary.Add(ame);
//			}
//
//			Session.Add("ATPMTPS", ary);

			//Match UI�PData
			for(int i=0; i<dv.Count; i++)	//���C��DataView�̭�������ˬd�@��
			{
				for (int j=0; j<dlClass21.Items.Count; j++)	//���DataList�̭����C�@��CheckBoxList
				{
					for (int k=0; k<((CheckBoxList)dlClass21.Items[j].FindControl("cblClass321")).Items.Count; k++)	//���CheckBoxList�̭����C�@��ListItem
					{
						if (dv[i]["cls_cls123id"].ToString()==((CheckBoxList)dlClass21.Items[j].FindControl("cblClass321")).Items[k].Value)
						{
							((CheckBoxList)dlClass21.Items[j].FindControl("cblClass321")).Items[k].Selected = true;
						}
					}
				}

				for (int j=0; j<dlClass22.Items.Count; j++)	//���DataList�̭����C�@��CheckBoxList
				{
					for (int k=0; k<((CheckBoxList)dlClass22.Items[j].FindControl("cblClass322")).Items.Count; k++)	//���CheckBoxList�̭����C�@��ListItem
					{
						if (dv[i]["cls_cls123id"].ToString()==((CheckBoxList)dlClass22.Items[j].FindControl("cblClass322")).Items[k].Value)
						{
							((CheckBoxList)dlClass22.Items[j].FindControl("cblClass322")).Items[k].Selected = true;
						}
					}
				}
			}
		}
		#endregion

		private void dlClass21_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			CheckBoxList cbl1;
			cbl1 = (CheckBoxList)dlClass21.SelectedItem.FindControl("cblClass321");
			foreach(ListItem item in cbl1.Items)
			{
				item.Selected=true;
			}
		}

		private void dlClass22_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			CheckBoxList cbl2;
			cbl2 = (CheckBoxList)dlClass22.SelectedItem.FindControl("cblClass322");
			foreach(ListItem item in cbl2.Items)
			{
				item.Selected=true;
			}
		}

	}
}
