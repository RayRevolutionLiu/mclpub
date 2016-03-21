<%@Import Namespace="System.Data"%>
<%@Import Namespace="System.Data.SqlClient"%>

<html>
<head>
<script language=C# runat=server>

void Page_Load(Object sender, EventArgs e)
 {
	//Response.Write(User.Identity.Name+"!!!");
	if (! Page.IsPostBack)
	{
	
	string loginID =  Session["empid"].ToString();//User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1);
	
	
	SqlConnection cn = new SqlConnection((String) ConfigurationSettings.AppSettings["mrlpub1"]);
	SqlDataAdapter cmd = new SqlDataAdapter("select * from srspn where srspn_empno='"+loginID+"'", cn);
	DataSet myDS = new DataSet();
	cmd.Fill(myDS, "Use");

	if (0==myDS.Tables["Use"].Rows.Count) {
		Message.Text="找不到此使用者帳號["+loginID+"],請重新輸入";
		Response.Write(loginID);
		return;
	}
		
	//if (UserPassword.Text!=myDS.Tables["Use"].Rows[0]["Password"].ToString()) {
		//Message.Text="密碼錯誤["+UserPassword.Text+"],請重新輸入";
		//return;
	//}
		
	// Create a ticket
		FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(loginID, false,1800);
		FormsAuthentication.RedirectFromLoginPage(loginID,false);
	}
}
	

</script>
</head>

<body>
<form method=post runat=server>
<table>
	<tr>
		<td>UserID: </td>
		<td><asp:textbox id=UserID runat=server/></td>
	</tr>
	<tr>
		<td>Password: </td>
		<td><asp:textbox textmode=password id=UserPassword runat=server/></td>
	</tr>
</table>
<br>
<asp:Label id="Message" ForeColor="red" runat=server />
</form>
</body>
</html>