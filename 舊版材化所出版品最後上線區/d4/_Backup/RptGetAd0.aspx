<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="RptGetAd0.aspx.cs" Src="RptGetAd0.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.RptGetAd0" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
    <meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript (ECMAScript)">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
		<!-- CSS -->
		<LINK title="Style" href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
  </HEAD>
  <body>  
  <center>
			<!-- 頁首 Header -->
			<kw:header id="Header" runat="server"></kw:header>	
    <form id="RptGetAd0" method="post" runat="server"><FONT 
face=新細明體></FONT>
<TABLE dataFld=items id=tbItems align=left border=0>
  <TR>
    <TD align=middle><FONT color=#333333 size=2><IMG height=10 
      src="../images/header/right02.gif" width=10 border=0> 網路廣告次系統 <IMG 
      height=10 src="../images/header/right02.gif" width=10 border=0> 催稿處理 <IMG 
      height=10 src="../images/header/right02.gif" width=10 border=0> 催稿單</FONT> 
    </TD></TR>
    </TABLE>
   <p></p><FONT face=新細明體><BR><BR></FONT>
<TABLE style="WIDTH: 90%" cellSpacing="0" cellPadding="2" align="center" bgColor="#bfcff0">
					<tr bgColor="#214389">
						<td colSpan="2">
							<font color="white">查詢條件</font>
						</td>
					</tr>
					<TR>
						<TD>
							催稿年月：
							<asp:textbox id="tbxyyyymm" runat="server" MaxLength="7" Width="60px"></asp:textbox>
<asp:RequiredFieldValidator id=rfvyyyymm runat="server" Font-Size="XX-Small" ErrorMessage="請輸入催稿年月" Display="Dynamic" ControlToValidate="tbxyyyymm"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator id=revyyyymm runat="server" Font-Size="XX-Small" ErrorMessage="格式錯誤，應為yyyy/MM" Display="Dynamic" ControlToValidate="tbxyyyymm" ValidationExpression="[2][0-9]{3}/[0-1][0-9]"></asp:RegularExpressionValidator>
							
							<br>
							<font color="gray">(請輸入 6碼年月, 如2002年 1月, 請輸入 2002/01)</font>&nbsp;
							<br><FONT 
      face=新細明體>業務員：
<asp:dropdownlist id=ddlEmpNo runat="server"></asp:dropdownlist></FONT>
							<br> 
							<!-- 查詢按鈕 -->
							<asp:linkbutton id="lnbShow" runat="server">查詢</asp:linkbutton>&nbsp;&nbsp;
							<asp:linkbutton id="lnbClearAll" runat="server" CausesValidation="False">清除重查</asp:linkbutton>
							<br>
							<br>
							<!-- 查詢結果顯示 -->
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>
						</TD>
						<TD vAlign="top" align="left">
							<asp:label id="lblMemo" runat="server" ForeColor="DarkRed">* 請篩選資料, 然後按下 "查詢".<br><br>
							</asp:label>
						</TD>
					</TR>
					<TR>
						<TD align="middle" bgColor="#ffffff" colSpan="2">
							&nbsp;
						</TD>
					</TR>
				</TABLE>



     </form>
			<!-- 頁尾 Footer -->
			<kw:footer id="Footer" runat="server"></kw:footer>
</center>			
	</body>
</HTML>
