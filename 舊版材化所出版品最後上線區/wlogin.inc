<%
   Dim userid, objLogin

   If Not Session("RegOk") = Nothing then
	userid = right(Request.ServerVariables("LOGON_USER"),6)
	Set objLogin = Server.CreateObject("SQLogin.MLogin")
	
	//' 到 application("sqlnts2") (寫在 global.asa中) 裡去做認證
 	objLogin.DSN = application("sqlnts2")
 	
 	//' 檢查是否有權限 (Syscode= 5A, 即 mrlpub 首頁)
 	objLogin.getcomper userid
 	objLogin.getrspn userid, "5A"
	Set objLogin = Nothing

	
	//' 定義變數名稱
	dim objConn, strConn
	dim objRS, strQuery

	//' Build Object Connection  建立物件連結之字串 objConn
	set objConn = Server.CreateObject("ADODB.Connection")
		
	//' 你可以用 way 1a or 1b or 2 去建立要連結資料庫之字串 strConn
	//' Way 2: 連到 SQL Server 資料庫, 使用 Web Application
	objConn.Open Application("mrlpub")

	//' Build String Query for connecting to table
	//' 建立要連到表格的字串 StrQuery, 可加上SQL條件 (如 Order By, where...)
	strQuery = "select * from srspn"
	strQuery = strQuery & " where srspn_empno=" & Session("EmpID")
	
	//' 結合以上字串條件做資料庫表格的連結
	set objRS = Server.CreateObject("ADODB.Recordset")
	objRS.Open strQuery, objConn
	//'Response.Write "objRS Empno= " & objRS("srspn_empno") & "<BR>" & vbCrlf
	
	if objRS.EOF then
		Session("syscode") = "5A"
		Session("atype") = "D"
	else
		Session("syscode") = "5A"
		Session("atype") = objRS("srspn_atype").value
	end if 
	

	//' login 不成功 => Redirect 到錯誤頁: uclpmd/login/login_error.asp
	if Session("SYSCODE") = "0" or Session("SYSCODE") = empty then
	//' login 不成功 => 轉址到錯誤頁, 並指定其Session("RegOk") = False 以禁止使用.
		Session("RegOk") = False
		//'Response.Redirect "/kfapp/mrlpub/login/login_error.asp"
 	else
		//' login 成功 => 轉址到系統首頁.
		Response.Redirect "/kfapp/mrlpub/default.aspx"
	end if

   //' 清除所有的連結變數 (Connections)
   objRS.close: set objRS=nothing
   objConn.Close: set objConn=nothing
   End If
%>