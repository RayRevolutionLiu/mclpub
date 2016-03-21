<%@ Page language="c#" Codebehind="RemailMod.aspx.cs" Src="RemailMod.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.RemailMod" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
<meta content="Microsoft Visual Studio 7.0" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content="JavaScript (ECMAScript)" name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema>
<LINK href="../UserControl/mrlpub.css" type=text/css rel=stylesheet >
  </HEAD>
<body>
		<!-- 頁首 Header --><kw:header id=Header runat="server">
		</kw:header>
<form id=RemailMod method=post runat="server">
<center>
<table>
  <tr>
    <td style="WIDTH: 627px" align=left><font 
      color=#333333 size=2><IMG height=10 src="images/header/right02.gif" width=10 border=0 > &nbsp;材料世界網廣告次系統<IMG height=10 src="images/header/right02.gif" width=10 border=0 > 補書處理 <IMG height=10 src="images/header/right02.gif" width=10 border=0 >&nbsp;補書查詢/修改/刪除 
</font></td></tr></table>
<TABLE style="WIDTH: 604px" cellSpacing=0 cellPadding=2 bgColor=#bfcff0>
  <tr bgColor=#214389>
    <td style="WIDTH: 550px" colSpan=4><font color=white 
      >訂戶資料</font> </td></tr>
  <TR>
    <TD style="WIDTH: 104px" align=right>合約編號： </TD>
    <td colSpan=3><asp:textbox id=tbxContNo runat="server" MaxLength="6" Width="100px"></asp:textbox></td></TR>
  <TR>
    <TD style="WIDTH: 104px" align=right>公司名稱： </TD>
    <td style="WIDTH: 232px"><asp:textbox id=tbxMfrNm runat="server" Width="204px"></asp:textbox></td>
    <TD style="WIDTH: 78px" align=right>統一編號： </TD>
    <td><asp:textbox id=tbxMfrNo runat="server" MaxLength="10" Width="99px"></asp:textbox></td></TR>
  <TR>
    <TD style="WIDTH: 104px" align=right>客戶編號： </TD>
    <td style="WIDTH: 232px"><asp:textbox id=tbxCustNo runat="server" MaxLength="6" Width="52px"></asp:textbox></td>
    <TD style="WIDTH: 78px" align=right>客戶姓名： </TD>
    <td><asp:textbox id=tbxCustName runat="server" Width="99px"></asp:textbox></td></TR>
  <TR>
    <TD style="WIDTH: 104px" align=right>簽約日期： </TD>
    <td colSpan=3><asp:textbox id=tbxSSDate runat="server" MaxLength="10" Width="82px"></asp:textbox><IMG class=ico title=日曆 onclick=pick_date(tbxSSDate.name) src="../images/calendar01.gif" > ～<asp:textbox id=tbxSEDate runat="server" MaxLength="10" Width="84px"></asp:textbox><IMG class=ico title=日曆 onclick=pick_date(tbxSEDate.name) src="../images/calendar01.gif" > </td></TR>
  <tr bgColor=#214389>
    <td style="WIDTH: 550px" colSpan=4><font color=white 
      >收件人資料</font> </td></tr>
  <TR>
    <TD style="WIDTH: 104px" align=right>收件人姓名： </TD>
    <td style="WIDTH: 232px"><asp:textbox id=tbxOrName runat="server" Width="99px"></asp:textbox></td>
    <TD style="WIDTH: 78px" align=right>收件人電話： </TD>
    <td><asp:textbox id=tbxOrTel runat="server" Width="99px"></asp:textbox></td></TR>
  <TR>
    <TD style="WIDTH: 104px" align=right>收件人地址： </TD>
    <td colSpan=3><asp:textbox id=tbxOrAddr runat="server" Width="431px"></asp:textbox></td></TR>
  <TR>
    <TD style="WIDTH: 104px" align=right>寄書狀態： </TD>
    <td colSpan=3><asp:radiobuttonlist id=rblSent runat="server" RepeatDirection="Horizontal">
<asp:ListItem Value="0" Selected="True">未寄出</asp:ListItem>
<asp:ListItem Value="1">已寄出</asp:ListItem>
<asp:ListItem Value="2">*不處理*</asp:ListItem>
							</asp:radiobuttonlist></td></TR></TABLE><asp:linkbutton id=lnbSearch runat="server" ForeColor="#C000C0">查詢</asp:linkbutton></center>
<DIV align=left><asp:datagrid id=dgdContOr runat="server" AllowPaging="True" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" BorderStyle="None" AutoGenerateColumns="False">
<FooterStyle ForeColor="#003399" BackColor="#99CCCC">
</FooterStyle>

<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399">
</HeaderStyle>

<PagerStyle HorizontalAlign="Left" ForeColor="#003399" Position="Top" BackColor="#99CCCC" Mode="NumericPages">
</PagerStyle>

<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999">
</SelectedItemStyle>

<ItemStyle ForeColor="#003399" BackColor="White">
</ItemStyle>

<Columns>
<asp:BoundColumn DataField="cont_contno" HeaderText="合約編號">
<ItemStyle Wrap="False">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="cont_conttp" HeaderText="合約類別">
<HeaderStyle Width="28px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="mfr_inm" HeaderText="公司名稱"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_sdate" HeaderText="合約起日"></asp:BoundColumn>
<asp:BoundColumn DataField="cont_edate" HeaderText="合約迄日"></asp:BoundColumn>
<asp:BoundColumn DataField="or_oritem" HeaderText="收件人序號">
<ItemStyle Width="10px">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="or_nm" HeaderText="收件人">
<ItemStyle Wrap="False">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="or_addr" HeaderText="收件人地址"></asp:BoundColumn>
<asp:BoundColumn DataField="or_tel" HeaderText="收件人電話"></asp:BoundColumn>
<asp:ButtonColumn Text="查詢" ButtonType="PushButton" CommandName="Select"></asp:ButtonColumn>
</Columns>
				</asp:datagrid><asp:label id=lblInfo Runat="server"></asp:label><asp:datagrid id=dgdRemail runat="server" CellPadding="4" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" BorderStyle="None" AutoGenerateColumns="False">
<FooterStyle ForeColor="#003399" BackColor="#99CCCC">
</FooterStyle>

<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399">
</HeaderStyle>

<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages">
</PagerStyle>

<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999">
</SelectedItemStyle>

<ItemStyle ForeColor="#003399" BackColor="White">
</ItemStyle>

<Columns>
<asp:ButtonColumn Text="刪除" ButtonType="PushButton" CommandName="Delete"></asp:ButtonColumn>
<asp:BoundColumn DataField="cont_contno" ReadOnly="True" HeaderText="合約編號">
<ItemStyle Wrap="False">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="cont_conttp" ReadOnly="True" HeaderText="合約類別"></asp:BoundColumn>
<asp:BoundColumn DataField="mfr_inm" ReadOnly="True" HeaderText="公司名稱"></asp:BoundColumn>
<asp:BoundColumn DataField="cust_nm" ReadOnly="True" HeaderText="訂戶姓名">
<ItemStyle Wrap="False">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="rm_mseq" ReadOnly="True" HeaderText="收件人序號">
<HeaderStyle Width="40px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="or_nm" ReadOnly="True" HeaderText="收件人"></asp:BoundColumn>
<asp:BoundColumn DataField="rm_seq" ReadOnly="True" HeaderText="補書序號">
<HeaderStyle Width="28px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="rm_cont" HeaderText="補書內容"></asp:BoundColumn>
<asp:TemplateColumn HeaderText="補書註記">
<ItemTemplate>
<asp:Label id=lblFgSent runat="server" Text='<%# GetFgSentName(DataBinder.Eval(Container.DataItem, "rm_fgsent")) %>'></asp:Label>
</ItemTemplate>

<EditItemTemplate>
<asp:DropDownList id=ddlFgSent runat="server" SelectedIndex='<%# GetSelectedIndex(DataBinder.Eval(Container.DataItem,"rm_fgsent")) %>'>
<asp:ListItem Value="Y" Selected="True">可寄出</asp:ListItem>
<asp:ListItem Value="N">目前不寄出</asp:ListItem>
<asp:ListItem Value="d">*不處理*</asp:ListItem>
</asp:DropDownList>
</EditItemTemplate>
</asp:TemplateColumn>
<asp:EditCommandColumn ButtonType="PushButton" UpdateText="儲存" CancelText="取消" EditText="修改"></asp:EditCommandColumn>
</Columns>
</asp:datagrid><FONT face=新細明體><BR></FONT><asp:label id=lblMessage runat="server" ForeColor="#C00000" Visible="False"></asp:label></DIV></form>
		<!-- 頁尾 Footer --><kw:footer id=Footer runat="server">
		</kw:footer>

<script language="javascript">
function delete_confirm(e){
	if(event.srcElement.type=="submit" && document.all(event.srcElement.name).value=="刪除")
	event.returnValue=confirm("確認刪除此筆資料?");
}
document.onclick=delete_confirm;

function pick_date(theField)
{
	var oParam = new Object();
	strFeature = "";
	strFeature += "dialogHeight:250px;dialogWidth:200px;center:yes;scroll:yes;status:no;help:no;";
	var vreturn = window.showModalDialog("calendar.asp", oParam, strFeature); 
	if(vreturn)
		window.document.all(theField).value=vreturn;
	return true;
}
</script>






	</body>
</HTML>
