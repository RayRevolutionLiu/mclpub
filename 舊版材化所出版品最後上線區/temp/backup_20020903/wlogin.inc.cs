<%
			string SysCode = "5A";
			string userid = User.Identity.Name.Substring(User.Identity.Name.LastIndexOf('/')+1, 6);
			object objLogin = (SQLogin.MLogin)Server.CreateObject("SQLogin.MLogin");
			//SQLogin.MLogin objLogin = new SQLogin.MLogin();
			objLogin.DSN = System.Configuration.ConfigurationSettings.AppSettings["sqlnts2"].ToString();
			objLogin.getcomper(userid);
			objLogin.getrspn(userid, SysCode);
			objLogin = null;
			
			string strDSN = System.Configuration.ConfigurationSettings.AppSettings["mrlpub"];
			OleDb.OleDbConnection cnn = new OleDb.OleDbConnection(strDSN);
			string strSelectCommand = "SELECT * FROM srspn";
			strSelectCommand += " WHERE srspn+empno=" + Session["EmpID"];
			OleDb.OleDbCommand cmd = new OleDb.OleDbCommand(strSelectCommand, cnn);
			cmd.Connection.Open();
			OleDb.OleDbDataReader dr;
			cmd.ExecuteReader(dr);

			Session.Add("syscode", SysCode);
			if (!dr.Read())
			{
				Session.Add("atype", D);
			}
			else
			{
				Session.Add("atype", dr["srspn_atype"].ToString());
			}

			if (Session["SYSCODE"].ToString() == "0" || Session["SYSCODE"].ToString() == null)
			{
				Session["RegOK"] = false;
			}
			else
			{
				Response.Redirect("/kfapp/mrlpub/default.aspx");
			}
%>