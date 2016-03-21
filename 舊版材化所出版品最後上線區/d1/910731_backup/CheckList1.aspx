<%@ Page language="c#" Codebehind="CheckList1.aspx.cs" src="CheckList1.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.CheckList1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>【材料所 出版品客戶管理系統】 訂單檢核表</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="CheckList1" method="post" runat="server">
			<FONT color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
				雜誌叢書訂閱次系統 <IMG height="10" src="images/header/right02.gif" width="10" border="0">
				訂單處理 <IMG height="10" src="images/header/right02.gif" width="10" border="0">訂單檢核表
			</FONT>
			<br>
			<asp:label id="Label1" runat="server">訂單登錄日期區間：</asp:label>
			<asp:textbox id="tbxDate1" runat="server" Width="82px"></asp:textbox>
			<IMG class="ico" title="日曆" onclick="pick_date(tbxDate1.name)" src="../images/calendar01.gif">
			～<asp:textbox id="tbxDate2" runat="server" Width="84px"></asp:textbox><IMG class="ico" title="日曆" onclick="pick_date(tbxDate2.name)" src="../images/calendar01.gif">
			<asp:Button id="Button1" runat="server" Text="查詢"></asp:Button>
			<INPUT onclick="doClose()" type="button" value="回首頁">
			<br>
			<asp:datagrid id="DataGrid1" runat="server" BorderStyle="None" BorderWidth="1px" BorderColor="#3366CC" BackColor="White" CellPadding="1" AutoGenerateColumns="False" Font-Size="8pt" Font-Names="新細明體">
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
				<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
				<SelectedItemStyle ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="Lavender"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<Columns>
					<asp:BoundColumn DataField="nostr" HeaderText="訂單編號"></asp:BoundColumn>
					<asp:BoundColumn DataField="o_mfrno" HeaderText="統一編號"></asp:BoundColumn>
					<asp:BoundColumn DataField="o_inm" HeaderText="發票收件人"></asp:BoundColumn>
					<asp:BoundColumn DataField="o_ijbti" HeaderText="稱謂"></asp:BoundColumn>
					<asp:BoundColumn DataField="o_iaddr" HeaderText="發票郵寄地址">
						<HeaderStyle Wrap="False">
						</HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="o_izip" HeaderText="郵遞區號"></asp:BoundColumn>
					<asp:BoundColumn DataField="o_itel" HeaderText="電話"></asp:BoundColumn>
					<asp:BoundColumn DataField="o_ifax" HeaderText="傳真"></asp:BoundColumn>
					<asp:BoundColumn DataField="o_icell" HeaderText="手機"></asp:BoundColumn>
					<asp:BoundColumn DataField="o_iemail" HeaderText="Email"></asp:BoundColumn>
					<asp:BoundColumn DataField="o_date" HeaderText="訂購日期"></asp:BoundColumn>
					<asp:BoundColumn DataField="o_empno" HeaderText="承辦人員"></asp:BoundColumn>
					<asp:BoundColumn DataField="o_invcd" HeaderText="發票類別"></asp:BoundColumn>
					<asp:BoundColumn DataField="o_taxtp" HeaderText="課稅別"></asp:BoundColumn>
					<asp:BoundColumn DataField="od_oditem" HeaderText="明細項次"></asp:BoundColumn>
					<asp:BoundColumn DataField="od_sdate" HeaderText="訂閱起時"></asp:BoundColumn>
					<asp:BoundColumn DataField="od_edate" HeaderText="訂閱迄時"></asp:BoundColumn>
					<asp:BoundColumn DataField="obtp_obtpnm" HeaderText="書籍名稱"></asp:BoundColumn>
					<asp:BoundColumn DataField="od_projno" HeaderText="計劃代號"></asp:BoundColumn>
					<asp:BoundColumn DataField="od_remark" HeaderText="備註"></asp:BoundColumn>
					<asp:BoundColumn DataField="od_amt" HeaderText="金額"></asp:BoundColumn>
					<asp:BoundColumn DataField="od_custtp" HeaderText="新續訂戶"></asp:BoundColumn>
					<asp:BoundColumn DataField="ra_mnt" HeaderText="數量"></asp:BoundColumn>
					<asp:BoundColumn DataField="mtp_nm" HeaderText="郵寄類別">
						<HeaderStyle Wrap="False">
						</HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="ra_oritem" HeaderText="序號"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_inm" HeaderText="公司名稱">
						<HeaderStyle Wrap="False">
						</HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="or_nm" HeaderText="雜誌收件人"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_jbti" HeaderText="稱謂"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_addr" HeaderText="雜誌郵寄地址">
						<HeaderStyle Wrap="False">
						</HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="or_zip" HeaderText="郵遞區號"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_tel" HeaderText="電話"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_fax" HeaderText="傳真"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_cell" HeaderText="手機"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_email" HeaderText="Email"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
			<asp:Label id="Label3" runat="server" ForeColor="#C04000" Font-Size="X-Small">說明1：<br>此檢核表列示之訂單是尚未產生發票開立單之資料, <br>已產生發票開立單之訂單資料不會在此列示</asp:Label>
			<br>
			<asp:Label id="Label2" runat="server" ForeColor="#C04000" Font-Size="X-Small">說明2：<br>發票類別---2:二聯  3:三聯  4:其他<br>課稅別---1:應稅  2:零稅  3:免稅<br>新續訂戶---0:新訂戶  1:續訂戶</asp:Label>
		</form>
		<script language="javascript">
function pick_date(theField){
	var oParam = new Object();
	strFeature = "";
	strFeature += "dialogHeight:250px;dialogWidth:200px;center:yes;scroll:yes;status:no;help:no;";
	var vreturn = window.showModalDialog("calendar.asp", oParam, strFeature); 
	if(vreturn)
		window.document.all(theField).value=vreturn;
	return true;
}
function doClose()
{
	window.close();
}
	</script>
	</body>
</HTML>
