<%@ Page language="c#" Codebehind="cal.aspx.cs" Src="cal.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.cal" responseencoding="big5" %>
<HTML>
	<HEAD>
		<script language="javascript">
<!--
function back_date(qsField){
	ret=window.opener.document.all(qsField).value="" + window.document.all("lbText").value;
	return ret;
}
//-->
		</script>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P align="center">
				<asp:calendar id="cal11" runat="server" selecteddaystyle-forecolor="Black" nextprevformat="FullMonth" othermonthdaystyle-backcolor="Transparent" weekenddaystyle-forecolor="Red" dayheaderstyle-wrap="False" selecteddaystyle-backcolor="PaleGreen" selecteddaystyle-font-bold="True" titlestyle-backcolor="SteelBlue" titlestyle-forecolor="White" othermonthdaystyle-forecolor="Silver" dayheaderstyle-backcolor="LightSkyBlue" CellPadding="0" Font-Size="XX-Small"></asp:calendar>
			</P>
			<P align="center">
				<asp:label id="lbText" runat="server"></asp:label>
				&nbsp;&nbsp; <A id="linkconfirm" onclick='javascript:back_date("<% Response.Write(Context.Request.QueryString["field_name"]); %>");window.close();' href="#" name="linkconfirm">
				½T©w
			</P>
		</form>
		</A>
	</body>
</HTML>
