<%@ LANGUAGE="VBSCRIPT" %>
<HTML>
<HEAD>
<TITLE>ASP 變數</TITLE>
<META http-equiv="Content-Language" Content="zh-tw">
<META http-equiv="Content-Type" Content="text/html" Charset="BIG5">
<META NAME="GENERATOR" Content="Ultra Editor v8.0">
<META NAME="Programmer" Content="ISC-SB100">

<!-- CSS -->
<LINK REL="stylesheet" TYPE="text/css" HREF="css/content.css">
</HEAD>

 
<BODY background=images/back1.jpg>
<!-- Place Content Here -->

<%
   Response.Write "<font size=+1 color=blue>Session Variables:</font><br>"
   Response.Write "<table border=1>"
   Response.Write "<TR><TH>Variables</TH><TH>Value</TH></TR>"
   for each var in session.contents
      Response.Write "<TR bgcolor=#E6F3F1><TD nowrap>" & var & "</TD>"
      Response.write "<TD nowrap>" & session.contents(var) & "</TD></TR>"
   next
   Response.Write "</TABLE>"
   Response.Write "<P>"
   Response.Write "<font size=+1 color=blue>Application Variables:</font><br>"
   Response.Write "<table border=1>"
   Response.Write "<TR><TH>Variables</TH><TH>Value</TH></TR>"
   for each var in application.contents
      Response.Write "<TR bgcolor=#E6F3F1><TD nowrap>" & var & "</TD>"
      Response.write "<TD nowrap>" & application.contents(var) & "</TD></TR>"
   next
   Response.Write "</TABLE>"
%>

</BODY>
</HTML>