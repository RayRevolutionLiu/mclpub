<!-- footer: ���Ʃ� �X���~�Ȥ�޲z�t�� �s���� �P ���v�� -->
<Script language="C#" runat=server>
void Page_Load(object sender, EventArgs e)
{
	if (!Page.IsPostBack)
	{
		hylContactor.Attributes["onclick"]="JavaScript: window.open('http://140.96.18.6/kfapp/Mail/MailInterface.aspx?Reciever=" + System.Configuration.ConfigurationSettings.AppSettings["ContactorEmailAddress"] +
		"&Subject=" + System.Configuration.ConfigurationSettings.AppSettings["DefaultSubject"] +
		"&Body=" + System.Configuration.ConfigurationSettings.AppSettings["DefaultBody"] +
		"', '_new', 'Toolbar=No, Menubar=No, Width=600, Height=350, Top=80, Left=120')";
		hylContactor.Attributes["HREF"]="";
	}
}
</Script>
<%@ Control %>
<TABLE WIDTH=100%>
  <!-- �s���� -->
<TR>
    <TD WIDTH=100% align=center>
    	<FONT Size=2 COLOR=Teal>
    	<CENTER><HR COLOR="3366CC">    	    	
	<BR>��T����  ��T�޳N�A�Ȳջs�@<BR>
	�����s���H: <A HREF="" id="hylContactor" runat="server"><% Response.Write(System.Configuration.ConfigurationSettings.AppSettings["ContactorName"]); %></A>
	</CENTER>
	</FONT>
    </TD>
  </TR>
  
  <!-- ���v�� -->
  <TR>  
    <TD align=center>
    <FONT Size=2 COLOR=#808080>
	<SPAN CLASS="copyright">
		Copyright &copy 2002 �u�~�޳N��s�| �u�~���Ƭ�s��<BR>
	</SPAN>
     </TD>
  </TR>
</TABLE><br>