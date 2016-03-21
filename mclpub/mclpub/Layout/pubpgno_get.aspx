<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pubpgno_get.aspx.cs" Inherits="mclpub.Layout.pubpgno_get" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查詢舊稿資料</title>
</head>
<body style="background-image:none">
		<!-- 頁首 Header -->
		<!-- Run at Server Form -->
		<form id="bookp_get" method="post" target="_self" runat="server">
			<!-- 操作說明 -->
			<font color="blue" size="2">操作說明：<br />
            預設資料為 <font color="darkred">該廠商 第一筆之已落版(寫回)之資料</font></font><br />
			<FONT color="blue" size="2">請按下<span class="font_darkblue">選取</span>按鈕, 
				來確認挑選"!按下關閉視窗,則會傳回<span class="font_red">紅色標示之資料</span></FONT>
			<br />
            <asp:Label ID="lblMessage" runat="server" ForeColor="IndianRed"></asp:Label>
            <span class="stripeMe">
			<!-- DataGrid 開始 -->
			<asp:datagrid id="DataGrid1" runat="server" PageSize="12"  BorderStyle="None" 
                AutoGenerateColumns="False" UseAccessibleHeader="true"
            CssClass="font_blacklink font_size13" Font-Size="X-Small" 
                onitemcommand="DataGrid1_ItemCommand" 
                onpageindexchanged="DataGrid1_PageIndexChanged" Width="95%" 
                onitemdatabound="DataGrid1_ItemDataBound">
				<Columns>
					<asp:BoundColumn Visible="False" DataField="pub_syscd" ReadOnly="True" HeaderText="系統代碼"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_contno" HeaderText="當期合約書編號"
                        ></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_custno" HeaderText="客戶編號"
                        ></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_yyyymm" HeaderText="刊登年月"
                        ></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_pubseq" HeaderText="落版序號" 
                        ></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_pno" HeaderText="當期書籍期別"
                        ></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_pgno" HeaderText="當期刊登頁碼"
                        ></asp:BoundColumn>
                    <asp:TemplateColumn>
                        <ItemTemplate>
                            <asp:LinkButton ID="lkbtnSelect" runat="server" Text="選取"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateColumn>
				</Columns>
			</asp:datagrid>
            </span>
			<br />
			<!-- 關閉視窗按鈕 -->
            <div style="text-align:right; width:95%">
			<INPUT id="btn_close" onclick="doGetPgNo('','')" type="button" value="關閉視窗" name="btn_close"  class="btn_mouseout" onmouseover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'">
            </div>
            <br />
			<asp:label id="lblMfrNo" runat="server" ForeColor="IndianRed" Font-Size="X-Small"></asp:label>
			<br>
			<asp:label id="lblGetPageNo" runat="server" ForeColor="Red" Font-Size="X-Small" Visible="false"></asp:label>
			<INPUT id="hiddenMfrNo" type="hidden" size="7" name="hiddenOldContNo" runat="server">
			<INPUT id="hiddenBookPNo" type="hidden" size="6" name="hiddenBookPNo" runat="server">
			<INPUT id="hiddenPageNo" type="hidden" size="4" name="hiddenPageNo" runat="server">
		</form>
		<!-- 頁尾 Footer -->
		<!-- Javascript -->
	</body>
        		<SCRIPT language="javascript">
		<!--
        		    // 自前一頁, 抓 MyObject
        		    var oMyObject = window.dialogArguments;

        		    // 自前一頁, 抓出其相關資料
        		    //alert("oMyObject.bkcd= " + oMyObject.bkcd);
        		    //alert("oMyObject.ym= " + oMyObject.ym);
		
		-->
		</SCRIPT>
    		<script language="javascript">
		<!--
    		    // <IMG class="ico" title="刊登頁碼參考資料" ...> 按鈕的 coding: 依刊登年月顯示其書籍期別
    		    function doGetPgNo(STRbkpno, STRpgno) {
    		        //alert(bkpno);
    		        //return;
    		        if (STRbkpno != null && STRpgno != null & STRbkpno != "" && STRpgno != "") {
    		            oMyObject.bkpno = STRbkpno;
    		            oMyObject.pgno = STRpgno;
    		        }
    		        else {
    		            // 傳回值並關閉視窗
    		            oMyObject.bkpno = document.all("hiddenBookPNo").value;
    		            oMyObject.pgno = document.all("hiddenPageNo").value;
    		        }
    		        //alert("oMyObject.bkpno= " + oMyObject.bkpno);
    		        //alert("oMyObject.pgno= " + oMyObject.pgno);

    		        window.returnValue = true;
    		        window.close();
    		    }
		//-->
            </script>
</html>
