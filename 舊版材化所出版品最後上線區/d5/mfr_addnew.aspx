<%@ Page language="c#" Src="mfr_addnew.aspx.cs" Codebehind="mfr_addnew.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d5.mfr_addnew" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>廠商資料維護</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function pick_date(theField)
		{
			var oParam = new Object();
			strFeature = "";
			strFeature += "dialogHeight:250px;dialogWidth:200px;center:yes;scroll:yes;status:no;help:no;";
			var vReturn = window.showModalDialog("calendar.asp", oParam, strFeature); 
			if(vReturn)
				window.document.all(theField).value=vReturn;
				return true;
		}
		</script>
	</HEAD>
	<body>
		<form id="mfr_addnew" method="post" runat="server">
			<P><FONT face="新細明體">
					<TABLE id="tbItems" cellSpacing="0" cellPadding="0" width="100%" bgColor="#e7ebff" border="0">
						<TR>
							<TD align="left" width="100%"><FONT color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">&nbsp;共同檔案
									<IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 廠商資料維護
									<IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 新增廠商資料
								</FONT>
							</TD>
						</TR>
					</TABLE>
			</P>
			<TABLE cellSpacing="1" cellPadding="3" width="90%" bgColor="#bfcff0" border="0">
				<TR bgColor="#214389">
					<TD colSpan="4"><FONT color="#ffffff">新增廠商資料</FONT>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 99px">
						<P align="right"><FONT color="red">* </FONT>資料類別:
						</P>
					</TD>
					<TD style="WIDTH: 345px"><asp:dropdownlist id="ddlmfr_type" runat="server" AutoPostBack="True">
							<asp:ListItem Value="A">廠商 - 統一編號</asp:ListItem>
							<asp:ListItem Value="B">姓名 - 身份證字號</asp:ListItem>
							<asp:ListItem Value="C">廠商 - 資料編號</asp:ListItem>
						</asp:dropdownlist><FONT color="#696969">(註:國外廠商請選擇 "廠商 - 資料編號")</FONT></TD>
					<TD colSpan="3">
						<P align="right"><FONT color="#ff0000">* </FONT><FONT color="#8b4513">為必填欄位&nbsp;</FONT><FONT color="#8b4513">&nbsp;</FONT>
						</P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 99px">
						<P align="right"><FONT color="red">* </FONT>
							<asp:label id="lblmfr_mfrno" runat="server">廠商統一編號</asp:label>:
						</P>
					</TD>
					<TD style="WIDTH: 345px"><asp:textbox id="mfr_mfrno" runat="server" Width="75px" MaxLength="10"></asp:textbox>
						<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" Display="Dynamic" ErrorMessage="請輸入八位數字!" ControlToValidate="mfr_mfrno" ValidationExpression="[0-9]{8}"></asp:RegularExpressionValidator><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" Display="Dynamic" ErrorMessage="必填欄位!" ControlToValidate="mfr_mfrno"></asp:requiredfieldvalidator><asp:label id="Label1" runat="server" ForeColor="Red"></asp:label></TD>
					<TD colSpan="3">
						<P align="right"></P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 99px">
						<P align="right"><FONT color="red">* </FONT>
							<asp:label id="lblmfr_inm" runat="server">發票抬頭</asp:label>:
						</P>
					</TD>
					<TD colSpan="3"><asp:textbox id="mfr_inm" runat="server" Width="270px" MaxLength="50"></asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" Display="Dynamic" ErrorMessage="必填欄位!" ControlToValidate="mfr_inm"></asp:requiredfieldvalidator></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 99px">
						<P align="right">發票地址:
						</P>
					</TD>
					<TD colSpan="3"><asp:textbox id="mfr_iaddr" runat="server" Width="370px" MaxLength="120"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 99px">
						<P align="right">廠商郵遞區號:
						</P>
					</TD>
					<TD colSpan="3"><asp:textbox id="mfr_izip" runat="server" Width="42px" MaxLength="5"></asp:textbox><asp:regularexpressionvalidator id="Regularexpressionvalidator5" runat="server" Display="Dynamic" ErrorMessage="只能填寫數字!" ControlToValidate="mfr_izip" ValidationExpression="[0-9]{1,5}"></asp:regularexpressionvalidator>&nbsp;&nbsp;<A href="http://www.post.gov.tw/0-6-1.htm" target="_blank">郵遞區號查詢</A>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 99px">
						<P align="right">公司負責人姓名:
						</P>
					</TD>
					<TD style="WIDTH: 345px"><asp:textbox id="mfr_respnm" runat="server" MaxLength="30"></asp:textbox></TD>
					<TD style="WIDTH: 1px">
						<P align="right"></P>
					</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 99px">
						<P align="right">公司負責人職稱:
						</P>
					</TD>
					<TD style="WIDTH: 345px"><asp:textbox id="mfr_respjbti" runat="server" Width="100px" MaxLength="12"></asp:textbox><FONT color="#696969">(註:若無職稱時請輸入"先生"或"小姐")</FONT>
					</TD>
					<TD style="WIDTH: 1px"></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 99px">
						<P align="right">&nbsp;公司聯絡電話:
						</P>
					</TD>
					<TD style="WIDTH: 345px"><asp:textbox id="mfr_tel" runat="server" MaxLength="30"></asp:textbox><FONT color="#696969">(範例:03-1234567#123)</FONT>
					</TD>
					<TD style="WIDTH: 1px">
						<P align="right"></P>
					</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 99px">
						<P align="right">公司傳真號碼:
						</P>
					</TD>
					<TD style="WIDTH: 345px"><asp:textbox id="mfr_fax" runat="server" MaxLength="30"></asp:textbox><FONT color="#696969">(範例:03-1234567#123)</FONT>
					</TD>
					<TD style="WIDTH: 1px"></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 99px">
						<P align="right">註冊日期:
						</P>
					</TD>
					<TD style="WIDTH: 356px" colSpan="2"><asp:textbox id="mfr_regdate" runat="server" Width="60px"></asp:textbox>
					<IMG class="ico" title="日曆" onclick="pick_date(mfr_regdate.name)" src="../images/calendar01.gif">
						<FONT color="#696969">(範例:20020101)</FONT>
						<asp:regularexpressionvalidator id="Regularexpressionvalidator2" runat="server" Display="Dynamic" ErrorMessage="請依範例格式輸入!" ControlToValidate="mfr_regdate" ValidationExpression="[0-9]{8}"></asp:regularexpressionvalidator></TD>
					<TD>
						<P align="right"></P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 99px"><FONT size="2"></FONT></TD>
					<TD style="WIDTH: 345px">
						<P align="right"><FONT size="2"></FONT></P>
					</TD>
					<TD style="WIDTH: 1px">
						<P align="right"></P>
					</TD>
					<TD>
						<P align="right"><asp:button id="btnAddNew" runat="server" Height="24px" Text="確定新增"></asp:button><asp:button id="btnReturnHome" runat="server" Height="24px" Text="放棄新增" CausesValidation="False"></asp:button></P>
					</TD>
				</TR>
			</TABLE>
			</FONT><FONT size="2"><BR>
			</FONT>
		</form>
	</body>
</HTML>
