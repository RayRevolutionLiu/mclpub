<!-- 表頭: MenuBar 區 ... 已到Layer(60) -->

<%@ Control %>
<html>
<HEAD>

<SCRIPT LANGUAGE="JavaScript" TYPE="text/javascript">
<!--
No3 = (parseInt(navigator.appVersion) > 3) ? 1:0;
layer = (document.all && No3) ? "document.all['L'+menu].style" : (document.layers && No3) ? "document.layers['L'+menu]" : 0;
var timer;

function JavaM() { if(layer) {
    if(timer) clearTimeout(timer);
    for(menu=0; menu<Layer.length; menu++) { if(Layer[menu]) { eval(layer).visibility = "hidden"; } }
    for(i=0; i<arguments.length; i++) { menu=arguments[i]; eval(layer).visibility = "visible"; }
} }
function Hide() { timer = setTimeout("JavaM()", 500); }
//-->
</SCRIPT>

</HEAD>


<BODY topmargin="0" leftmargin="0">
<table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse; border-width: 0" bordercolor="#29498C" bgcolor="29284A" width="100%" id="AutoNumber1">
  <tr>
    <td width="100%" style="border-style: none; border-width: medium">
    <img border="0" src="/mrlpub/images/header/Logo0.jpg" height="30"></td>
  </tr>
</table>

<TABLE WIDTH="100%" BORDER=1 CELLPADDING=3 CELLSPACING=0 height="18" style="border-collapse: collapse" bordercolor="#d6e0fe" ><TR>
<TD width="56" align="center" height="12" onMouseOver="this.style.background='#1A3264';" onMouseOut="this.style.background='#3366CC';" bgcolor="#3366CC" nowrap><A HREF="/mrlpub/" class="header">
系統首頁</A></TD>
<TD bgcolor="#3366CC" width="117" align="center" height="12" onMouseOver="this.style.background='#1A3264';" onMouseOut="this.style.background='#3366CC';" nowrap><A HREF="#" onMouseOver="JavaM(1)" onMouseOut="Hide(1)" class="header">
雜誌叢書訂閱次系統</A></TD>
<TD bgcolor="#3366CC" width="92" align="center" height="12" onMouseOver="this.style.background='#1A3264';" onMouseOut="this.style.background='#3366CC';" nowrap><A HREF="#" onMouseOver="JavaM(2)" onMouseOut="Hide(2)" class="header">
平面廣告次系統</A></TD>
<TD bgcolor="#3366CC" width="127" align="center" height="12" onMouseOver="this.style.background='#1A3264';" onMouseOut="this.style.background='#3366CC';" nowrap><A HREF="#" onMouseOver="JavaM(3)" onMouseOut="Hide(3)" class="header">
材料世界網收費次系統</A></TD>
<TD bgcolor="#3366CC" width="92" align="center" height="12" onMouseOver="this.style.background='#1A3264';" onMouseOut="this.style.background='#3366CC';" nowrap><A HREF="#" onMouseOver="JavaM(4)" onMouseOut="Hide(4)" class="header">
網路廣告次系統</A></TD>
<TD bgcolor="#3366CC" width="56" align="center" height="12" onMouseOver="this.style.background='#1A3264';" onMouseOut="this.style.background='#3366CC';" nowrap><A HREF="#" onMouseOver="JavaM(20)" onMouseOut="Hide(20)" class="header">
共用檔案</A></TD>
<TD bgcolor="#3366CC" width="52" align="center" height="12" onMouseOver="this.style.background='#1A3264';" onMouseOut="this.style.background='#3366CC';" nowrap><A HREF="#" onMouseOver="JavaM(32)" onMouseOut="Hide(32)" class="header">
SAP轉檔</A></TD>
<TD bgcolor="#3366CC" width="52" align="center" height="12" onMouseOver="this.style.background='#1A3264';" onMouseOut="this.style.background='#3366CC';" nowrap><A HREF="#" onMouseOver="JavaM(36)" onMouseOut="Hide(36)" class="header">
特殊需求</A></TD>
<TD bgcolor="#3366CC" align="center" height="12" nowrap>　</TD>
</TR></TABLE>
</SPAN>


<SCRIPT LANGUAGE="JavaScript">
<!--
//////////////////////////////////////////////////////

    hovercolor = "#1A3264";
    //bgcolor = "#000000";
    //background = "/mrlpub/images/header/072700_1.jpg";
    bgcolor = "#3366CC";
    background = "";

    menu_border = 1;
    border_color = "white";

    arrow_pic = "/mrlpub/images/header/right02.gif";

//////////////////////////////////////////////////////


if(document.all) { if(!background) { background=bgcolor; } else { background = "url("+background+")"; } }

function LayerSpecs(Left,Top,Width) { if(No3) {
    if(document.all) { Top+=7; Left+=2; Width-=6; }
    this.left = Left;
    this.top = Top;
    this.info = "";
    T=0;
    for(i=3; i<arguments.length; i++) {
        if(document.all) { this.info += "<TR><TD WIDTH="+Width+" onMouseOver='this.bgColor=\""+hovercolor+"\"' onMouseOut='this.bgColor=\"\"'>"+arguments[i]+"</TD></TR>"; }
        else { this.info += "<LAYER onMouseOver='this.bgColor=\""+hovercolor+"\"' onMouseOut='this.bgColor=\""+bgcolor+"\"' WIDTH="+Width+" POSITION=RELATIVE TOP="+T+">&nbsp;"+arguments[i]+"</LAYER>"; }
        T+=20;
    }
} }

Layer = new Array();
arrow = "<IMG SRC='"+arrow_pic+"' BORDER=0 ALT=''>";


//////////////////////////////////////////////

//1
Layer[1] =    new LayerSpecs(61,44,80,
            '<A HREF="#" onMouseOver="JavaM(12,1)" class="header"> &nbsp; 訂戶資料</A> &nbsp; '+arrow,
            '<A HREF="#" onMouseOver="JavaM(5,1)" class="header"> &nbsp; 訂單處理</A> &nbsp; '+arrow,
            '<A HREF="#" onMouseOver="JavaM(13,1)" class="header"> &nbsp; 補書處理</A> &nbsp; '+arrow,
            '<A HREF="#" onMouseOver="JavaM(14,1)" class="header"> &nbsp; 缺書處理</A> &nbsp; '+arrow,
            '<A HREF="#" onMouseOver="JavaM(6,1)" class="header"> &nbsp; 標籤處理</A> &nbsp; '+arrow,
            '<A HREF="#" onMouseOver="JavaM(15,1)" class="header"> &nbsp; 發票處理</A>  &nbsp; '+arrow,
            '<A HREF="#" onMouseOver="JavaM(33,1)" class="header"> &nbsp; 繳款處理</A>  &nbsp; '+arrow,
	     '<A HREF="/mrlpub/temp.aspx" onMouseOver="JavaM(1)" class="header"> &nbsp; 催款處理</A> ',
            '<A HREF="#" onMouseOver="JavaM(16,1)" class="header"> &nbsp; 其他報表</A> &nbsp; '+arrow,
	     '<A HREF="/mrlpub/temp.aspx" onMouseOver="JavaM(1)" class="header"> &nbsp; 資料搜尋</A> '
);

//2
Layer[2] =    new LayerSpecs(185,44,100,
            '<A HREF="#" onMouseOver="JavaM(7,2)" class="header"> &nbsp; 合約處理</A> &nbsp; &nbsp; &nbsp; &nbsp; '+arrow,
            '<A HREF="#" onMouseOver="JavaM(8,2)" class="header"> &nbsp; 催稿處理</A> &nbsp; &nbsp; &nbsp; &nbsp; '+arrow,
            '<A HREF="#" onMouseOver="JavaM(9,2)" class="header"> &nbsp; 落版處理</A> &nbsp; &nbsp; &nbsp; &nbsp; '+arrow,
            '<A HREF="#" onMouseOver="JavaM(10,2)" class="header"> &nbsp; 發票處理</A> &nbsp; &nbsp; &nbsp; &nbsp; '+arrow,
            '<A HREF="#" onMouseOver="JavaM(21,2)" class="header"> &nbsp; 繳款處理</A> &nbsp; &nbsp; &nbsp; &nbsp; '+arrow,
            '<A HREF="#" onMouseOver="JavaM(22,2)" class="header"> &nbsp; 缺書處理</A> &nbsp; &nbsp; &nbsp; &nbsp; '+arrow,
	     '<A HREF="#" onMouseOver="JavaM(23,2)" class="header"> &nbsp; 催款處理</A> &nbsp; &nbsp; &nbsp; &nbsp; '+arrow,
	     '<A HREF="#" onMouseOver="JavaM(17,2)" class="header"> &nbsp; 推廣戶處理</A> &nbsp; &nbsp; '+arrow,
	     '<A HREF="#" onMouseOver="JavaM(18,2)" class="header"> &nbsp; 統計表</A> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; '+arrow,
	     '<A HREF="#" onMouseOver="JavaM(24,2)" class="header"> &nbsp; 相關維護區</A> &nbsp; &nbsp; '+arrow,
	     '<A HREF="/mrlpub/d2/Search.aspx" onMouseOver="JavaM(2)" class="header"> &nbsp; 資料搜尋</A> '
);

//3
Layer[3] =    new LayerSpecs(284,44,100,
            '<A HREF="#" onMouseOver="JavaM(43,3)" class="header"> &nbsp; 會員資料</A> &nbsp; &nbsp; &nbsp; &nbsp; '+arrow,
            '<A HREF="#" onMouseOver="JavaM(44,3)" class="header"> &nbsp; 申請單處理</A> &nbsp; &nbsp; '+arrow,
            '<A HREF="#" onMouseOver="JavaM(45,3)" class="header"> &nbsp; 贈書處理</A> &nbsp; &nbsp; &nbsp; &nbsp; '+arrow,
            '<A HREF="#" onMouseOver="JavaM(46,3)" class="header"> &nbsp; 補書處理</A> &nbsp; &nbsp; &nbsp; &nbsp; '+arrow,
            '<A HREF="#" onMouseOver="JavaM(47,3)" class="header"> &nbsp; 缺書處理</A> &nbsp; &nbsp; &nbsp; &nbsp; '+arrow,
            '<A HREF="#" onMouseOver="JavaM(48,3)" class="header"> &nbsp; 標籤處理</A> &nbsp; &nbsp; &nbsp; &nbsp; '+arrow,
            '<A HREF="#" onMouseOver="JavaM(49,3)" class="header"> &nbsp; 發票處理</A>  &nbsp; &nbsp; &nbsp; &nbsp; '+arrow,
            '<A HREF="#" onMouseOver="JavaM(50,3)" class="header"> &nbsp; 繳款處理</A>  &nbsp; &nbsp; &nbsp; &nbsp; '+arrow,
	     '<A HREF="/mrlpub/temp.aspx" onMouseOver="JavaM(3)" class="header"> &nbsp; 催款處理</A> ',
            '<A HREF="#" onMouseOver="JavaM(51,3)" class="header"> &nbsp; 其他報表</A> &nbsp; &nbsp; &nbsp; &nbsp; '+arrow,
	     '<A HREF="/mrlpub/temp.aspx" onMouseOver="JavaM(3)" class="header"> &nbsp; 資料搜尋</A> '
);

//4
Layer[4] =    new LayerSpecs(418,44,100,
            '<A HREF="#" onMouseOver="JavaM(34,4)" class="header"> &nbsp; 合約處理</A> &nbsp; &nbsp; &nbsp; &nbsp; '+arrow,
            '<A HREF="#" onMouseOver="JavaM(56,4)" class="header"> &nbsp; 催稿處理</A> &nbsp; &nbsp; &nbsp; &nbsp; '+arrow,
            '<A HREF="#" onMouseOver="JavaM(37,4)" class="header"> &nbsp; 落版處理</A> &nbsp; &nbsp; &nbsp; &nbsp; '+arrow,
            '<A HREF="#" onMouseOver="JavaM(52,4)" class="header"> &nbsp; 發票處理</A> &nbsp; &nbsp; &nbsp; &nbsp; '+arrow,
            '<A HREF="#" onMouseOver="JavaM(57,4)" class="header"> &nbsp; 繳款處理</A> &nbsp; &nbsp; &nbsp; &nbsp; '+arrow,
            '<A HREF="#" onMouseOver="JavaM(53,4)" class="header"> &nbsp; 補書處理</A> &nbsp; &nbsp; &nbsp; &nbsp; '+arrow,
            '<A HREF="#" onMouseOver="JavaM(59,4)" class="header"> &nbsp; 缺書處理</A> &nbsp; &nbsp; &nbsp; &nbsp; '+arrow,
            '<A HREF="#" onMouseOver="JavaM(60,4)" class="header"> &nbsp; 標籤處理</A> &nbsp; &nbsp; &nbsp; &nbsp; '+arrow,
	    '<A HREF="#" onMouseOver="JavaM(58,4)" class="header"> &nbsp; 推廣戶處理</A> &nbsp; &nbsp; '+arrow
);

//5
Layer[20] =    new LayerSpecs(517,44,113,
            '<A HREF="/mrlpub/d5/book.aspx" class="header"> &nbsp; 書籍資料</A> ',
            '<A HREF="/mrlpub/d5/bookp.aspx" class="header"> &nbsp; 書籍期別資料</A> ',
            //'<hr size="1" noshade color="#FFFFFF">',
            '<A HREF="/mrlpub/d5/itp.aspx" class="header"> &nbsp; 領域代碼</A> ',
            '<A HREF="/mrlpub/d5/btp.aspx" class="header"> &nbsp; 營業代碼</A> ',
            //'<A HREF="/mrlpub/d5/rtp.aspx" class="header"> &nbsp; 閱讀代碼</A> ',
            '<A HREF="/mrlpub/d5/mfr.aspx" class="header"> &nbsp; 廠商資料</A> ',
            '<A HREF="/mrlpub/d5/cust.aspx" class="header"> &nbsp; 客戶資料</A> ',
            '<A HREF="/mrlpub/d5/custdata_list.aspx" class="header"> &nbsp; 客戶基本資料清單</A> ',
            '<A HREF="/mrlpub/d5/syscd.aspx" class="header"> &nbsp; 系統代碼</A> ',
            '<A HREF="/mrlpub/d5/mailer.aspx" class="header"> &nbsp; 寄件人資料</A> ',
            '<A HREF="/mrlpub/d5/mtp.aspx" class="header"> &nbsp; 郵寄類別</A> ',
            '<A HREF="/mrlpub/d5/mltp.aspx" class="header"> &nbsp; 寄件人郵寄類別</A> ',
            '<A HREF="/mrlpub/d5/proj.aspx" class="header"> &nbsp; 計劃代號</A> ',
            '<A HREF="/mrlpub/d5/refm.aspx" class="header"> &nbsp; 轉SAP發票摘要檔</A> ',
            '<A HREF="/mrlpub/d5/refd.aspx" class="header"> &nbsp; 轉SAP傳票摘要檔</A> ',
            '<A HREF="/mrlpub/d5/ores.aspx" class="header"> &nbsp; 訂單來源檔</A> ',
            '<A HREF="/mrlpub/d5/otp.aspx" class="header"> &nbsp; 訂購類別檔</A> ',
            '<A HREF="/mrlpub/d5/pytp.aspx" class="header"> &nbsp; 付款方式</A> ',
            '<A HREF="/mrlpub/d5/srspn.aspx" class="header"> &nbsp; 管理業務人員</A> ',
            '<A HREF="/mrlpub/d5/search.aspx" class="header"> &nbsp; 資料搜尋</A> '
);

//6
Layer[32] =    new LayerSpecs(580,44,163,
            '<A HREF="/mrlpub/d6/sap.aspx" class="header"> &nbsp; 發票開立單轉SAP(會計中心)</A> ',
            '<A HREF="/mrlpub/d6/GetInvno.aspx" class="header"> &nbsp; 發票號碼取回</A> '
);

//7
Layer[36] =    new LayerSpecs(639,44,167,
            '<A HREF="/mrlpub/d1/S_SearchCust1.aspx" class="header"> &nbsp; 新增舊訂單( 不新增 ia 及 py )</A> '
);


//訂戶資料1-1
Layer[12] =    new LayerSpecs(142,44,90,
            '<A HREF="/mrlpub/d1/NewCust.aspx?mfrno=" class="header"> &nbsp; 新增訂戶</A> ',
            '<A HREF="/mrlpub/d1/ModifyCust.aspx?id=" class="header"> &nbsp; 修改訂戶資料</A> ',
            '<A HREF="/mrlpub/d1/CustListFilter.aspx" target=new class="header"> &nbsp; 訂戶明細表</A> '
);

//1-2
Layer[5] =    new LayerSpecs(142,62,100,
            '<A HREF="#" onMouseOver="JavaM(26,5,1)" class="header"> &nbsp; 訂閱訂單</A>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; '+arrow,
            '<A HREF="#" onMouseOver="JavaM(27,5,1)" class="header"> &nbsp; 推廣戶訂單</A>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  '+arrow,
            '<A HREF="#" onMouseOver="JavaM(28,5,1)" class="header"> &nbsp; 贈戶訂單</A>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  '+arrow,
            '<A HREF="#" onMouseOver="JavaM(29,5,1)" class="header"> &nbsp; 零售訂單</A>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  '+arrow,
            '<A HREF="/mrlpub/d1/CheckList1.aspx" onMouseOver="JavaM(5,1)" target=new  class="header"> &nbsp; 訂單檢核表</A> ',
            '<A HREF="/mrlpub/d1/OrderListFilter.aspx" onMouseOver="JavaM(5,1)" target=new  class="header"> &nbsp; 訂單明細表</A> '
);


//1-2-1
Layer[26] =    new LayerSpecs(243,62,90,
            '<A HREF="/mrlpub/d1/searchcust1.aspx?type1=01&function1=new" class="header"> &nbsp; 新增訂單</A> ',
            '<A HREF="/mrlpub/d1/searchcust1.aspx?type1=01&function1=mod" class="header"> &nbsp; 註銷/修改訂單</A> '
);

//1-2-2
Layer[27] =    new LayerSpecs(243,80,90,
            '<A HREF="/mrlpub/d1/searchcust1.aspx?type1=03&function1=new" class="header"> &nbsp; 新增訂單</A> ',
            '<A HREF="/mrlpub/d1/searchcust1.aspx?type1=03&function1=mod" class="header"> &nbsp; 註銷/修改訂單</A> '
);

//1-2-3
Layer[28] =    new LayerSpecs(243,98,90,
            '<A HREF="/mrlpub/d1/BulkOrder.aspx" class="header"> &nbsp; 整批作業</A> ',
            '<A HREF="/mrlpub/d1/searchcust1.aspx?type1=02&function1=new" class="header"> &nbsp; 新增訂單</A> ',
            '<A HREF="/mrlpub/d1/searchcust1.aspx?type1=02&function1=mod" class="header"> &nbsp; 註銷/修改訂單</A> '
);

//1-2-4
Layer[29] =    new LayerSpecs(243,116,90,
            '<A HREF="/mrlpub/d1/searchcust1.aspx?type1=09&function1=new" class="header"> &nbsp; 新增訂單</A> ',
            '<A HREF="/mrlpub/d1/searchcust1.aspx?type1=09&function1=mod" class="header"> &nbsp; 註銷/修改訂單</A> '
);

//補書處理1-3
Layer[13] =    new LayerSpecs(142,80,105,
            '<A HREF="/mrlpub/d1/RemailSearch.aspx?function1=new" class="header"> &nbsp; 補書登錄</A> ',
            '<A HREF="/mrlpub/d1/RemailSearch.aspx?function1=mod" class="header"> &nbsp; 補書單修改/刪除</A> ',
            '<A HREF="/mrlpub/d1/RmListFilter.aspx" target=new class="header"> &nbsp; 補書清單</A> '
);

//缺書處理1-4
Layer[14] =    new LayerSpecs(142,98,105,
            '<A HREF="/mrlpub/d1/LostSearch.aspx?function1=new" class="header"> &nbsp; 缺書登錄</A> ',
            '<A HREF="/mrlpub/d1/LostSearch.aspx?function1=mod" class="header"> &nbsp; 缺書單修改/刪除</A> ',
            '<A HREF="/mrlpub/d1/LostListFilter.aspx" target=new class="header"> &nbsp; 缺書清單</A> '
);

//標籤處理1-5
Layer[6] =    new LayerSpecs(142,116,90,
            '<A HREF="/mrlpub/d1/search_label.aspx" target=new class="header"> &nbsp; 大宗標籤</A> ',
            '<A HREF="/mrlpub/d1/RmLabelFilter.aspx" target=new class="header"> &nbsp; 補書標籤</A> ',
            '<A HREF="/mrlpub/d1/LstLabelFilter.aspx" target=new class="header"> &nbsp; 缺書標籤</A> ',
            '<A HREF="/mrlpub/d1/apprisefilter.aspx" target=new class="header"> &nbsp; 續訂通知標籤</A> '
);

//發票處理1-6
Layer[15] =    new LayerSpecs(142,134,150,
            '<A HREF="/mrlpub/d1/CreateIa.aspx" class="header"> &nbsp; 發票開立單產生</A> ',
            '<A HREF="/mrlpub/d1/CheckList3.aspx" target=new class="header"> &nbsp; 發票開立單檢核表</A> ',
            '<A HREF="/mrlpub/d1/RecoveryIa.aspx" class="header"> &nbsp; 發票開立單回復(Recovery)</A> ',
            '<A HREF="/mrlpub/d1/DeleteIa.aspx" class="header"> &nbsp; 註銷發票(未繳款之發票)</A> ',
            '<A HREF="/mrlpub/d1/SpecialFM.aspx" class="header"> &nbsp; 已繳款之發票退回處理</A> '
);

//繳款處理1-7
Layer[33] =    new LayerSpecs(142,152,138,
            '<A HREF="/mrlpub/d1/PayFilter.aspx" class="header"> &nbsp; 新增繳款單</A> ',
            '<A HREF="/mrlpub/d1/PayFMFilter.aspx" class="header"> &nbsp; 修改繳款單</A> ',            	    '<A HREF="/mrlpub/d1/PayDelete.aspx" class="header"> &nbsp; 刪除繳款單</A> ',
            '<A HREF="/mrlpub/d1/CheckList7.aspx" target=new class="header"> &nbsp; 繳款單檢核表</A> ',
            '<A HREF="/mrlpub/d1/PayListFilter.aspx" target=new class="header"> &nbsp; 繳款清單產生</A> ',
            '<A HREF="/mrlpub/d1/RecoveryPayList.aspx" class="header"> &nbsp; 繳款清單回復(Recovery)</A> ',
            '<A HREF="/mrlpub/d1/PayListPrint.aspx" target=new class="header"> &nbsp; 列印繳款清單</A> ',
            '<A HREF="/mrlpub/d1/CardListFilter.aspx" target=new class="header"> &nbsp; 信用卡中心請款彙總表</A> '
);


//其他報表1-9
Layer[16] =    new LayerSpecs(142,188,110,
            '<A HREF="/mrlpub/d1/IncomeFilter.aspx" target=new class="header"> &nbsp; 收入統計表</A> ',
            '<A HREF="/mrlpub/d1/BookMntFilter.aspx" target=new class="header"> &nbsp; 雜誌印製份數統計</A> ',
            '<A HREF="/mrlpub/d1/CustMntFilter.aspx" target=new class="header"> &nbsp; 雜誌客戶份數表</A> '
);


//2-1
Layer[7] =    new LayerSpecs(286,44,134,
            '<A HREF="#" onMouseOver="JavaM(30,7,2)" class="header"> &nbsp; 合約書</A> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; '+arrow,
            '<A HREF="#" onMouseOver="JavaM(31,7,2)" class="header"> &nbsp; 落版</A> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; '+arrow,
            '<A HREF="/mrlpub/d2/cont_list.aspx" onMouseOver="JavaM(7,2)" class="header"> &nbsp; 合約書清單</A> ',
            '<A HREF="/mrlpub/d2/adamt_list.aspx" onMouseOver="JavaM(7,2)" class="header"> &nbsp; 廣告費用檢查清單</A> ',
            '<A HREF="#" onMouseOver="JavaM(19,7,2)" class="header"> &nbsp; 平面廣告標籤</A> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; '+arrow,
            '<A HREF="/mrlpub/d2/contfm_chk1.aspx" onMouseOver="JavaM(7,2)" class="header"> &nbsp; 合約書錯誤資料清單</A> '
);

//2-1-1
Layer[30] =    new LayerSpecs(421,44,118,
            '<A HREF="/mrlpub/d2/cont_new1.aspx?function1=new" class="header"> &nbsp; 新增合約書</A> ',
            '<A HREF="/mrlpub/d2/cont_main1.aspx?function1=mod" class="header"> &nbsp; 維護合約書</A> ',
            '<A HREF="/mrlpub/d2/contfm_chklist.aspx" class="header"> &nbsp; 合約書檢核表</A> ',
            '<A HREF="/mrlpub/d2/contfm_closedshow.aspx" class="header"> &nbsp; 顯示已結案合約書</A> ',
            '<A HREF="/mrlpub/d2/contfm_cancel.aspx" class="header"> &nbsp; 註銷合約書</A> ',
            '<A HREF="/mrlpub/d2/contfm_cancelshow.aspx" class="header"> &nbsp; 顯示已註銷合約書</A> '
);

//2-1-2
Layer[31] =    new LayerSpecs(421,62,141,
            '<A HREF="#" onMouseOver="JavaM(25,31,7,2)" class="header"> &nbsp; 新增/維護/顯示落版</A> &nbsp; &nbsp; '+arrow,
            '<A HREF="/mrlpub/d2/pubfm_chklist.aspx" onMouseOver="JavaM(31,7,2)" class="header"> &nbsp; 落版檢核表</A> ',
            '<A HREF="/mrlpub/d2/contpubfm_search.aspx" onMouseOver="JavaM(31,7,2)" class="header"> &nbsp; 顯示合約及落版資料</A> '
);

//2-1-2-1
Layer[25] =    new LayerSpecs(563,62,104,
            '<A HREF="/mrlpub/d2/pub_new1.aspx" class="header"> &nbsp; 由合約書進入</A> ',
            '<A HREF="/mrlpub/d2/pub_new2.aspx" class="header"> &nbsp; 由年月落版進入</A> '
);

//2-1-5
Layer[19] =    new LayerSpecs(421,116,80,
            '<A HREF="/mrlpub/d2/PubFm_label_search.aspx" class="header"> &nbsp; 當月刊登</A> ',
            '<A HREF="/mrlpub/d2/PubFm_label_search2.aspx" class="header"> &nbsp; 當月未刊登</A> '
);

//2-2
Layer[8] =    new LayerSpecs(286,62,80,
            '<A HREF="/mrlpub/d2/getad.aspx" class="header"> &nbsp; 催稿單</A> '
);

//2-3
Layer[9] =    new LayerSpecs(286,80,112,
            '<A HREF="/mrlpub/d2/adpub_act1.aspx?action=1" onMouseOver="JavaM(9,2)" class="header"> &nbsp; 廣告排版動作</A> ',
            '<A HREF="/mrlpub/d2/adpub_act1.aspx?action=2" onMouseOver="JavaM(9,2)" class="header"> &nbsp; 美編樣後修正</A> ',
            //'<A HREF="#" onMouseOver="JavaM(25,9,2)" class="header"> &nbsp; 廣告落版資料維護</A> '+arrow,
            '<A HREF="/mrlpub/d2/adpub_form.aspx" onMouseOver="JavaM(9,2)" class="header"> &nbsp; 廣告落版單</A> ',
            '<A HREF="/mrlpub/d2/adpub_list.aspx" onMouseOver="JavaM(9,2)" class="header"> &nbsp; 廣告落版清單</A> ',
             '<A HREF="/mrlpub/d2/admade_stat.aspx" onMouseOver="JavaM(9,2)" class="header"> &nbsp; 廣告製稿統計表</A> '
);

//2-4
Layer[10] =    new LayerSpecs(286,98,171,
            '<A HREF="#" onMouseOver="JavaM(38,10,2)" class="header"> &nbsp; 發票開立單產生</A> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; '+arrow,
            '<A HREF="#" onMouseOver="JavaM(39,10,2)" class="header"> &nbsp; 發票開立單檢核表</A> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; '+arrow,
            '<A HREF="#" onMouseOver="JavaM(40,10,2)" class="header"> &nbsp; 發票開立單回復(Recovery) </A> &nbsp; '+arrow
            //'<A HREF="#" onMouseOver="JavaM(41,10,2)" class="header"> &nbsp; 註銷發票</A> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; '+arrow,
            //'<A HREF="#" onMouseOver="JavaM(42,10,2)" class="header"> &nbsp; 已繳款之發票退回處理</A> &nbsp; &nbsp; &nbsp; &nbsp; '+arrow
);

//2-4-1
Layer[38] =    new LayerSpecs(458,98,80,
            '<A HREF="/mrlpub/d2/iaFm1_Add.aspx" class="header"> &nbsp; 一次付款</A> ',
            '<A HREF="/mrlpub/d2/iaFm2_Addia.aspx" class="header"> &nbsp; 大批月結</A> '
);

//2-4-2
Layer[39] =    new LayerSpecs(458,116,150,
            '<A HREF="/mrlpub/d2/iaFm1_Chklist_query.aspx" class="header"> &nbsp; 一次付款</A> ',
            '<A HREF="/mrlpub/d2/iaFm1_Chklist2.aspx" class="header"> &nbsp; 一次付款(當月刊登清單)</A> ',
            '<A HREF="/mrlpub/d2/iaFm2_Chklist_ia.aspx?bkcd=&yyyymm=&sort=&action=1&iabseq=" class="header"> &nbsp; 大批月結</A> '
);

//2-4-3
Layer[40] =    new LayerSpecs(458,134,80,
            '<A HREF="/mrlpub/d2/iaFm1_Rec.aspx" class="header"> &nbsp; 一次付款</A> ',
            '<A HREF="/mrlpub/d2/iaFm2_RecAll.aspx" class="header"> &nbsp; 大批月結</A> '
);

//2-4-4
Layer[41] =    new LayerSpecs(458,152,80,
            //'<A HREF="/mrlpub/d2/iaFm1_delete.aspx" class="header"> &nbsp; 一次付款</A> ',
            '<A HREF="/mrlpub/d2/iaFm2_delete.aspx" class="header"> &nbsp; 大批月結</A> '
);

//2-4-5
Layer[42] =    new LayerSpecs(458,170,80,
            //'<A HREF="/mrlpub/d2/iaFm1_special.aspx" class="header"> &nbsp; 一次付款</A> ',
            '<A HREF="/mrlpub/d2/iaFm2_special.aspx" class="header"> &nbsp; 大批月結</A> '
);

//平面廣告次系統-繳款處理2-5
Layer[21] =    new LayerSpecs(286,116,138,
            '<A HREF="/mrlpub/d1/PayFilter.aspx?caller=" class="header"> &nbsp; 新增繳款單</A> ',
            '<A HREF="/mrlpub/d1/PayFMFilter.aspx" class="header"> &nbsp; 修改繳款單</A> ',
            '<A HREF="/mrlpub/d1/PayDelete.aspx" class="header"> &nbsp; 刪除繳款單</A> ',
            '<A HREF="/mrlpub/d1/CheckList7.aspx" target=new class="header"> &nbsp; 繳款單檢核表</A> ',
            '<A HREF="/mrlpub/d1/PayListFilter.aspx" target=new class="header"> &nbsp; 繳款清單產生</A> ',
            '<A HREF="/mrlpub/d1/RecoveryPayList.aspx" class="header"> &nbsp; 繳款清單回復(Recovery)</A> ',
            '<A HREF="/mrlpub/d1/PayListPrint.aspx" target=new class="header"> &nbsp; 列印繳款清單</A> '
);

//平面廣告次系統-缺書處理2-6
Layer[22] =    new LayerSpecs(286,134,110,
           '<A HREF="/mrlpub/d2/lostbk_search.aspx?function1=new" class="header"> &nbsp; 缺書登錄</A> ',
            '<A HREF="/mrlpub/d2/lostbk_search.aspx?function1=mod" class="header"> &nbsp; 缺書單修改/刪除</A> ',
            '<A HREF="/mrlpub/d2/lostbk_list.aspx" class="header"> &nbsp; 缺書清單</A> ',
            '<A HREF="/mrlpub/d2/lostbk_label_filter.aspx" class="header"> &nbsp; 缺書標籤</A> '
);

//平面廣告次系統-催款處理2-7
Layer[23] =    new LayerSpecs(286,152,80,
            '<A HREF="/mrlpub/d2/getpay.aspx" class="header"> &nbsp; 催款單</A> ',
            '<A HREF="/mrlpub/d2/getpay_list.aspx" class="header"> &nbsp; 催款清單</A> '
);

//平面廣告次系統-推廣戶處理2-8
Layer[17] =    new LayerSpecs(286,170,115,
	    '<A HREF="/mrlpub/d2/custdata_list.aspx" class="header"> &nbsp; 客戶基本資料清單</A> ',
            '<A HREF="/mrlpub/d2/adprom_list.aspx" class="header"> &nbsp; 廣告推廣戶清單</A> ',
            '<A HREF="/mrlpub/d2/adprom_label.aspx" class="header"> &nbsp; 廣告推廣戶標籤</A> '
);

//2-9
Layer[18] =    new LayerSpecs(286,188,115,
            '<A HREF="/mrlpub/d2/adincome_stat.aspx" onMouseOver="JavaM(18,2)" class="header"> &nbsp; 廣告收入統計表</A> ',
            '<A HREF="#" onMouseOver="JavaM(54,18,2)" class="header"> &nbsp; 郵寄本數統計表</A> &nbsp; '+arrow ,
            '<A HREF="#" onMouseOver="JavaM(55,18,2)" class="header"> &nbsp; 印製份數統計表</A> &nbsp; '+arrow
);

//2-9-1
Layer[54] =    new LayerSpecs(402,206,80,
            '<A HREF="/mrlpub/d2/orcounts_stat_search1.aspx" class="header"> &nbsp; 當月刊登</A> ',
            '<A HREF="/mrlpub/d2/orcounts_stat_search2.aspx" class="header"> &nbsp; 當月未刊登</A> '
);

//2-9-2
Layer[55] =    new LayerSpecs(402,224,80,
            '<A HREF="/mrlpub/d2/ormtpcounts_stat_search1.aspx" class="header"> &nbsp; 當月刊登</A> ',
            '<A HREF="/mrlpub/d2/ormtpcounts_stat_search2.aspx" class="header"> &nbsp; 當月未刊登</A> '
);

//2-10
Layer[24] =    new LayerSpecs(286,206,140,
            '<A HREF="/mrlpub/d2/adlprior.aspx" class="header"> &nbsp; 版面優先次序</A> ',
            '<A HREF="/mrlpub/d2/pgno.aspx" class="header"> &nbsp; 內頁起始頁碼</A> ',
            '<A HREF="/mrlpub/d2/adcolor.aspx" class="header"> &nbsp; 廣告色彩</A> ',
            '<A HREF="/mrlpub/d2/adlayout.aspx" class="header"> &nbsp; 廣告版面</A> ',
            '<A HREF="/mrlpub/d2/adpgsize.aspx" class="header"> &nbsp; 廣告篇幅</A> ',
            '<A HREF="/mrlpub/d2/njtype.aspx" class="header"> &nbsp; 新稿製法</A> ',
            '<A HREF="/mrlpub/d2/or.aspx" class="header"> &nbsp; 雜誌收件人 (瀏覽)</A> ',
            '<A HREF="/mrlpub/d2/invmfr.aspx" class="header"> &nbsp; 發票廠商收件人 (瀏覽)</A> ',
            '<A HREF="/mrlpub/d2/lostbk.aspx" class="header"> &nbsp; 缺書 (瀏覽)</A> '
);

//////////////////////////////////////////////////////////////////////

//3-1
Layer[43] =    new LayerSpecs(385,44,90,
            '<A HREF="#" class="header"> &nbsp; 取回會員資料</A> ',
            '<A HREF="#" class="header"> &nbsp; 會員清單</A> ',
            '<A HREF="#" target=new class="header"> &nbsp; 會員查詢</A> '
);

//3-2
Layer[44] =    new LayerSpecs(385,62,105,
            '<A HREF="#" class="header"> &nbsp; 申請單登錄</A> ',
            '<A HREF="#" class="header"> &nbsp; 申請單修改/刪除</A> ',
            '<A HREF="#" target=new class="header"> &nbsp; 申請單檢核表</A> ',
            '<A HREF="#" target=new class="header"> &nbsp; 申請單明細表</A> '
);

//贈書處理3-3
Layer[45] =    new LayerSpecs(385,80,105,
            '<A HREF="#" class="header"> &nbsp; 贈書登錄</A> ',
            '<A HREF="#" class="header"> &nbsp; 贈書單修改/刪除</A> ',
            '<A HREF="#" target=new class="header"> &nbsp; 贈書清單</A> '
);

//補書處理3-4
Layer[46] =    new LayerSpecs(385,98,105,
            '<A HREF="#" class="header"> &nbsp; 補書登錄</A> ',
            '<A HREF="#" class="header"> &nbsp; 補書單修改/刪除</A> ',
            '<A HREF="#" target=new class="header"> &nbsp; 補書清單</A> '
);

//缺書處理3-5
Layer[47] =    new LayerSpecs(385,116,105,
            '<A HREF="#" class="header"> &nbsp; 缺書登錄</A> ',
            '<A HREF="#" class="header"> &nbsp; 缺書單修改/刪除</A> ',
            '<A HREF="#" class="header"> &nbsp; 缺書清單</A> '
);

//標籤處理3-6
Layer[48] =    new LayerSpecs(385,134,90,
            '<A HREF="#" class="header"> &nbsp; 大宗標籤</A> ',
            '<A HREF="#" class="header"> &nbsp; 補書標籤</A> ',
            '<A HREF="#" class="header"> &nbsp; 缺書標籤</A> '
);

//發票處理3-7
Layer[49] =    new LayerSpecs(385,152,150,
            '<A HREF="#" class="header"> &nbsp; 發票開立單產生</A> ',
            '<A HREF="#" class="header"> &nbsp; 發票開立單檢核表</A> ',
            '<A HREF="#" class="header"> &nbsp; 發票開立單回復(Recovery)</A> ',
            '<A HREF="#" class="header"> &nbsp; 註銷發票(未繳款之發票)</A> ',
            '<A HREF="#" class="header"> &nbsp; 已繳款之發票退回處理</A> '
);

//繳款處理3-8
Layer[50] =    new LayerSpecs(385,170,138,
            '<A HREF="#" class="header"> &nbsp; 新增繳款單</A> ',
            '<A HREF="#" class="header"> &nbsp; 修改繳款單</A> ',
            '<A HREF="#" class="header"> &nbsp; 刪除繳款單</A> ',
            '<A HREF="#" class="header"> &nbsp; 繳款單檢核表</A> ',
            '<A HREF="#" class="header"> &nbsp; 繳款清單產生</A> ',
            '<A HREF="#" class="header"> &nbsp; 繳款清單回復(Recovery)</A> ',
            '<A HREF="#" class="header"> &nbsp; 列印繳款清單</A> ',
            '<A HREF="#" class="header"> &nbsp; 信用卡中心請款彙總表</A> '
);


//其他報表3-10
Layer[51] =    new LayerSpecs(385,206,110,
            '<A HREF="#" class="header"> &nbsp; 收入統計表</A> ',
            '<A HREF="#" class="header"> &nbsp; 雜誌印製份數統計</A> ',
            '<A HREF="#" class="header"> &nbsp; 雜誌客戶份數表</A> '
);

//////////////////////////////////////////////////////////////////////

//4-1
Layer[34] =    new LayerSpecs(519,44,80,
            '<A HREF="#" onMouseOver="JavaM(35,34,4)" class="header"> &nbsp; 合約書</A> &nbsp; &nbsp; &nbsp; '+arrow
);

//4-1-1
Layer[35] =    new LayerSpecs(600,44,100,
            '<A HREF="/mrlpub/d4/querycont.aspx?conttp=01" class="header"> &nbsp; 新增合約書</A> ',
            '<A HREF="/mrlpub/d4/querycust.aspx" class="header"> &nbsp; 維護合約書</A> ',
            '<A HREF="/mrlpub/d4/contchecklist.aspx"" class="header"> &nbsp; 合約書檢核表</A> ',
            '<A HREF="/mrlpub/d4/contquerycancel.aspx"" class="header"> &nbsp; 已註銷合約處理</A> '
);

//4-2
Layer[56] =    new LayerSpecs(519,62,80,
            '<A HREF="/mrlpub/d4/rptgetad0.aspx" onMouseOver="JavaM(56,4)" class="header"> &nbsp; 催稿單</A> '
);

//4-3
Layer[37] =    new LayerSpecs(519,80,110,
            '<A HREF="/mrlpub/d4/AdQueryCont.aspx" onMouseOver="JavaM(37,4)" class="header"> &nbsp; 美編落版</A> ',
            '<A HREF="/mrlpub/d4/AdCheckList.aspx" onMouseOver="JavaM(37,4)" class="header"> &nbsp; 廣告落版檢核表</A> ',
            '<A HREF="/mrlpub/d4/RptAdList0.aspx" onMouseOver="JavaM(37,4)" class="header"> &nbsp; 網廣落版清單</A> ',
            '<A HREF="/mrlpub/d4/mrladm/AdGenXmlFile.aspx" onMouseOver="JavaM(37,4)" class="header"> &nbsp; *產生落版檔</A> ',
            '<A HREF="/mrlpub/d4/mrladm/AdViewAd.aspx" onMouseOver="JavaM(37,4)" class="header"> &nbsp; *落版狀態查詢</A> ',
            '<A HREF="/mrlpub/d4/mrladm/AdShowXmlFiles.aspx" onMouseOver="JavaM(37,4)" class="header"> &nbsp; *清除落版檔</A> ',
            '<A HREF="/mrlpub/d4/AdQueryOldData.aspx" onMouseOver="JavaM(37,4)" class="header"> &nbsp; *廣告檔案查詢</A> ',
            '<A HREF="/mrlpub/d4/mrladm/AdImgAdm.aspx" onMouseOver="JavaM(37,4)" class="header"> &nbsp; *廣告圖檔管理</A> '
);

//4-4
Layer[52] = new LayerSpecs(519,98,155,
	'<A HREF="/mrlpub/d4/IA1QueryInv.aspx" onMouseOver="JavaM(52,4)" class="header"> &nbsp; 一次付款</A> ',
	'<A HREF="/mrlpub/d4/IABQueryInv.aspx" onMouseOver="JavaM(52,4)" class="header"> &nbsp; 大批月結</A> ',
	'<A HREF="/mrlpub/d4/IA1CheckList.aspx" onMouseOver="JavaM(52,4)" class="header"> &nbsp; 發票開立檢核表（一次）</A> ',
	'<A HREF="/mrlpub/d4/IABCheckList.aspx" onMouseOver="JavaM(52,4)" class="header"> &nbsp; 發票開立檢核表（大批）</A> ',
	'<A HREF="/mrlpub/d4/IA1Recovery.aspx" onMouseOver="JavaM(52,4)" class="header"> &nbsp; 發票開立單回復(一次)</A> ',
	'<A HREF="/mrlpub/d4/IABRecovery.aspx" onMouseOver="JavaM(52,4)" class="header"> &nbsp; 發票開立單回復(大批)</A> '
);

//4-5
Layer[57] =    new LayerSpecs(519,116,138,
            '<A HREF="/mrlpub/d1/PayFilter.aspx?caller=" class="header"> &nbsp; 新增繳款單</A> ',
            '<A HREF="/mrlpub/d1/PayFMFilter.aspx" class="header"> &nbsp; 修改繳款單</A> ',
            '<A HREF="/mrlpub/d1/PayDelete.aspx" class="header"> &nbsp; 刪除繳款單</A> ',
            '<A HREF="/mrlpub/d1/CheckList7.aspx" target=new class="header"> &nbsp; 繳款單檢核表</A> ',
            '<A HREF="/mrlpub/d1/PayListFilter.aspx" target=new class="header"> &nbsp; 繳款清單產生</A> ',
            '<A HREF="/mrlpub/d1/RecoveryPayList.aspx" class="header"> &nbsp; 繳款清單回復(Recovery)</A> ',
            '<A HREF="/mrlpub/d1/PayListPrint.aspx" target=new class="header"> &nbsp; 列印繳款清單</A> '
);

//4-6
Layer[53] =    new LayerSpecs(519,134,80,
            '<A HREF="/mrlpub/d4/RemailAdd.aspx" onMouseOver="JavaM(53,4)" class="header"> &nbsp; 補書登錄</A> ',
            '<A HREF="/mrlpub/d4/RemailMod.aspx" onMouseOver="JavaM(53,4)" class="header"> &nbsp; 補書修改</A> ',
            '<A HREF="/mrlpub/d4/RptRemailList0.aspx" onMouseOver="JavaM(53,4)" class="header"> &nbsp; 補書清單</A> '
);

//4-7
Layer[59] =    new LayerSpecs(519,152,80,
            '<A HREF="/mrlpub/d4/LostAdd.aspx" onMouseOver="JavaM(59,4)" class="header"> &nbsp; 缺書登錄</A> ',
            '<A HREF="/mrlpub/d4/LostMod.aspx" onMouseOver="JavaM(59,4)" class="header"> &nbsp; 缺書修改</A> ',
            '<A HREF="/mrlpub/d4/RptLostList0.aspx" onMouseOver="JavaM(59,4)" class="header"> &nbsp; 缺書清單</A> '
);

//4-8
Layer[60] =    new LayerSpecs(519,170,90,
            '<A HREF="/mrlpub/d4/LabelBatch.aspx" target=new class="header"> &nbsp; 大宗標籤</A> ',
            '<A HREF="/mrlpub/d4/LabelRemail.aspx" target=new class="header"> &nbsp; 補書標籤</A> ',
            '<A HREF="/mrlpub/d4/LabelLost.aspx" target=new class="header"> &nbsp; 缺書標籤</A> ',
            '<A HREF="/mrlpub/d4/LabelPromote.aspx" target=new class="header"> &nbsp; 推廣戶標籤</A> '
);

//4-9
Layer[58] =    new LayerSpecs(519,188,115,
	    '<A HREF="/mrlpub/d2/custdata_list.aspx" class="header"> &nbsp; 客戶基本資料清單</A> ',
            '<A HREF="/mrlpub/d2/adprom_list.aspx" class="header"> &nbsp; 廣告推廣戶清單</A> ',
            '<A HREF="/mrlpub/d2/adprom_label.aspx" class="header"> &nbsp; 廣告推廣戶標籤</A> '
);

//test
Layer[11] =    new LayerSpecs(185,45,80,
            '<A HREF="" class="header">子目錄八</A> ',
            '<A HREF="" class="header">連結網頁</A> ',
            '<A HREF="" class="header">連結網頁</A> ',
            '<A HREF="" class="header">連結網頁</A> '
);


////////////////////////////////////////////////////////////////

j = (Layer[0]) ? 0:1;

for(i=j; i<Layer.length; i++) {
    if(document.all && No3) { document.write("<SPAN onMouseOver='clearTimeout(timer)' onMouseOut='Hide("+i+")' ID='L"+i+"' STYLE='position:absolute; visibility:hidden; background:"+background+"; top:"+Layer[i].top+"; left:"+Layer[i].left+";'><TABLE STYLE='border:solid "+menu_border+" "+border_color+"'>"+Layer[i].info+"</TABLE></SPAN>"); }
    else if(document.layers && No3) { document.write("<LAYER onMouseOver='clearTimeout(timer)' onMouseOut='Hide("+i+")' ID='L"+i+"' POSITION=ABSOLUTE VISIBILITY=HIDDEN BGCOLOR='"+bgcolor+"' BACKGROUND='"+background+"' TOP="+Layer[i].top+" LEFT="+Layer[i].left+">"+Layer[i].info+"</LAYER>"); }
}

if(document.layers) { document.layers["menubar"].style.visibility = "hidden"; }
else if(document.layers) { document.layers["menubar"].visibility = "visible"; }

// -->
</SCRIPT>

</body>
</html>