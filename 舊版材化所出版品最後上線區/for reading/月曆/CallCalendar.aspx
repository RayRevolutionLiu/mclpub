...............




<html>
<script language=javascript>
<!--
function pick_date(theField){
	ret=window.open("cal.aspx?field_name="+ theField, "Poping", "toolbar=no,menubar=no,width=320,height=200", false);
	return true;
}
//-->
</script>


<body>
<form id=Form1 method=post runat="server">

..............


開始日期<asp:TextBox id="Start_Date" runat="server" />
<image src="image.gif" onclick='javascript:pick_date("Start_Date");return false;'>

...................


</form>
	
  </body></html>