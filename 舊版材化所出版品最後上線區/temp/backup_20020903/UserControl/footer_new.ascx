<!-- footer: 材料所 出版品客戶管理系統 連結區 與 版權區 -->
<Script language="C#" runat=server>
void Page_Load(object sender, EventArgs e)
{
	if (!Page.IsPostBack)
	{
		hylContactor.Attributes["onclick"]="JavaScript: window.open('/mrlpub/Mail/MailInterface.aspx?Reciever=" + System.Configuration.ConfigurationSettings.AppSettings["ContactorEmailAddress"] +
		"&Subject=" + System.Configuration.ConfigurationSettings.AppSettings["DefaultSubject"] +
		"&Body=" + System.Configuration.ConfigurationSettings.AppSettings["DefaultBody"] +
		"', '_new', 'Toolbar=No, Menubar=No, Width=600, Height=350, Top=80, Left=120')";
		hylContactor.Attributes["HREF"]="";
	}
}
</Script>
<%@ Control %>
<TABLE WIDTH=100%>
  <!-- 連結區 -->
<TR>
    <TD WIDTH=100% align=center>
    	<FONT Size=2 COLOR=#0076EC>
    	<CENTER><BR><HR COLOR="3366CC">    	    	
	<BR>資訊中心  資訊技術服務組製作<BR>
	網頁連絡人: <A HREF="" id="hylContactor" runat="server"><% Response.Write(System.Configuration.ConfigurationSettings.AppSettings["ContactorName"]); %></A>
	</CENTER>
	</FONT>
    </TD>
  </TR>
  
  <!-- 版權區 -->
  <TR>  
    <TD align=center>
    <FONT Size=2 COLOR=#808080>
	<SPAN CLASS="copyright">
		Copyright &copy 2001 工業技術研究院 工業材料研究所<BR>
	</SPAN>
     </TD>
  </TR>
</TABLE><br>