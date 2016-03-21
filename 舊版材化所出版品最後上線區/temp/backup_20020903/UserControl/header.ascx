<!-- 表頭: MenuBar 區 Layer(36) -->

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
    bgcolor = "#000000"; 
    background = "/mrlpub/images/header/072700_1.jpg";  
    
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
Layer[3] =    new LayerSpecs(284,44,80,
            '<A HREF="/mrlpub/temp.aspx" class="header"> &nbsp; 目錄一</A> '
);

//4
Layer[4] =    new LayerSpecs(418,44,100,
            '<A HREF="#" onMouseOver="JavaM(34,4)" class="header"> &nbsp; 合約處理</A> &nbsp; &nbsp; &nbsp; &nbsp; '+arrow
);

//5
Layer[20] =    new LayerSpecs(517,44,113,
            '<A HREF="/mrlpub/d5/Book.aspx" class="header"> &nbsp; 書籍資料</A> ',
            '<A HREF="/mrlpub/d5/Bookp.aspx" class="header"> &nbsp; 書籍期別資料</A> ',
            //'<hr size="1" noshade color="#FFFFFF">',
            '<A HREF="/mrlpub/d5/Itp.aspx" class="header"> &nbsp; 領域代碼</A> ',
            '<A HREF="/mrlpub/d5/Btp.aspx" class="header"> &nbsp; 營業代碼</A> ',
            //'<A HREF="/mrlpub/d5/Rtp.aspx" class="header"> &nbsp; 閱讀代碼</A> ',
            '<A HREF="/mrlpub/d5/Mfr.aspx" class="header"> &nbsp; 廠商資料</A> ',
            '<A HREF="/mrlpub/d5/Cust.aspx" class="header"> &nbsp; 客戶資料</A> ',
            '<A HREF="/mrlpub/d5/Syscd.aspx" class="header"> &nbsp; 系統代碼</A> ',
            '<A HREF="/mrlpub/d5/Mailer.aspx" class="header"> &nbsp; 寄件人資料</A> ',
            '<A HREF="/mrlpub/d5/Mtp.aspx" class="header"> &nbsp; 郵寄類別</A> ',
            '<A HREF="/mrlpub/d5/Mltp.aspx" class="header"> &nbsp; 寄件人郵寄類別</A> ',
            '<A HREF="/mrlpub/d5/Proj.aspx" class="header"> &nbsp; 計劃代號</A> ',
            '<A HREF="/mrlpub/d5/Refm.aspx" class="header"> &nbsp; 轉SAP發票摘要檔</A> ',
            '<A HREF="/mrlpub/d5/Refd.aspx" class="header"> &nbsp; 轉SAP傳票摘要檔</A> ',
            '<A HREF="/mrlpub/d5/ores.aspx" class="header"> &nbsp; 訂單來源檔</A> ',
            '<A HREF="/mrlpub/d5/Pytp.aspx" class="header"> &nbsp; 付款方式</A> ',
            '<A HREF="/mrlpub/d5/Srspn.aspx" class="header"> &nbsp; 管理業務人員</A> ',
            '<A HREF="/mrlpub/d5/Search.aspx" class="header"> &nbsp; 資料搜尋</A> '
);

//6
Layer[32] =    new LayerSpecs(580,44,163,
            '<A HREF="/mrlpub/Temp.aspx" class="header"> &nbsp; 發票開立單轉SAP(會計中心)</A> ',
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
            '<A HREF="#" onMouseOver="JavaM(26,5,1)" class="header"> &nbsp; 一般訂單</A>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; '+arrow,
            '<A HREF="#" onMouseOver="JavaM(27,5,1)" class="header"> &nbsp; 推廣戶訂單</A>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  '+arrow,
            '<A HREF="#" onMouseOver="JavaM(28,5,1)" class="header"> &nbsp; 贈戶訂單</A>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  '+arrow,
            '<A HREF="#" onMouseOver="JavaM(29,5,1)" class="header"> &nbsp; 零售訂單</A>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  '+arrow,
            '<A HREF="/mrlpub/d1/OrderListFilter.aspx" onMouseOver="JavaM(5,1)" target=new  class="header"> &nbsp; 訂單明細表</A> ',
            '<A HREF="/mrlpub/temp.aspx" onMouseOver="JavaM(5,1)" class="header"> &nbsp; 訂閱明細彙整表</A> '
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
Layer[15] =    new LayerSpecs(142,134,138,
            '<A HREF="/mrlpub/d1/CreateIa.aspx" class="header"> &nbsp; 發票開立單(人工產生)</A> ',
            '<A HREF="#" target=new class="header"> &nbsp; 發票開立單修改</A> '
);

//繳款處理1-7
Layer[33] =    new LayerSpecs(142,152,138,
            '<A HREF="/mrlpub/d1/PayFilter.aspx?caller=" class="header"> &nbsp; 繳款登錄</A> ',
            '<A HREF="/mrlpub/d1/PayListFilter.aspx" target=new class="header"> &nbsp; 產生繳款清單</A> ',
            '<A HREF="/mrlpub/d1/PayListPrint.aspx" target=new class="header"> &nbsp; 列印繳款清單</A> ',
            '<A HREF="/mrlpub/d1/CardListFilter.aspx" target=new class="header"> &nbsp; 信用卡中心請款彙總表</A> '
);

//其他報表1-9
Layer[16] =    new LayerSpecs(142,188,110,
            '<A HREF="/mrlpub/temp.aspx" class="header"> &nbsp; 收入統計表</A> ',
            '<A HREF="/mrlpub/temp.aspx" class="header"> &nbsp; 雜誌印製份數統計</A> ',
            '<A HREF="/mrlpub/temp.aspx" class="header"> &nbsp; 雜誌客戶份數表</A> '
);


//2-1
Layer[7] =    new LayerSpecs(286,44,124,
            '<A HREF="#" onMouseOver="JavaM(30,7,2)" class="header"> &nbsp; 一般合約書</A> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; '+arrow,
            '<A HREF="#" onMouseOver="JavaM(31,7,2)" class="header"> &nbsp; 推廣合約書</A> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; '+arrow,
            '<A HREF="/mrlpub/d2/cont_list.aspx" onMouseOver="JavaM(7,2)" class="header"> &nbsp; 廣告合約書清單</A> ',
            '<A HREF="/mrlpub/d2/adamt_list.aspx" onMouseOver="JavaM(7,2)" class="header"> &nbsp; 廣告費用檢查清單</A> ',
            '<A HREF="#" onMouseOver="JavaM(19,7,2)" class="header"> &nbsp; 平面廣告標籤</A> &nbsp; &nbsp; &nbsp; &nbsp; '+arrow
);

//2-1-1
Layer[30] =    new LayerSpecs(411,44,80,
            '<A HREF="/mrlpub/d2/cont_new1.aspx?function1=new&conttp=01" class="header"> &nbsp; 新增合約書</A> ',
            '<A HREF="/mrlpub/d2/cont_main1.aspx?function1=mod&conttp=01" class="header"> &nbsp; 維護合約書</A> '
);

//2-1-2
Layer[31] =    new LayerSpecs(411,62,80,
            '<A HREF="/mrlpub/d2/cont_new1.aspx?function1=new&conttp=09" class="header"> &nbsp; 新增合約書</A> ',
            '<A HREF="/mrlpub/d2/cont_main1.aspx?function1=mod&conttp=09" class="header"> &nbsp; 維護合約書</A> '
);

//2-1-5
Layer[19] =    new LayerSpecs(411,116,80,
            '<A HREF="/mrlpub/d2/monthpub.aspx" class="header"> &nbsp; 當月刊登</A> ',
            '<A HREF="/mrlpub/d2/monthunpub.aspx" class="header"> &nbsp; 當月未刊登</A> '
);

//2-2
Layer[8] =    new LayerSpecs(286,62,80,
            '<A HREF="/mrlpub/d2/getad.aspx" class="header"> &nbsp; 催稿單</A> '
);

//2-3
Layer[9] =    new LayerSpecs(286,80,122,
            '<A HREF="/mrlpub/d2/adpub_act1.aspx?action=1" onMouseOver="JavaM(9,2)" class="header"> &nbsp; 廣告落版動作</A> ',
            '<A HREF="/mrlpub/d2/adpub_act1.aspx?action=2" onMouseOver="JavaM(9,2)" class="header"> &nbsp; 美編樣後修正</A> ',
            '<A HREF="#" onMouseOver="JavaM(25,9,2)" class="header"> &nbsp; 廣告落版資料維護</A> '+arrow,
            '<A HREF="/mrlpub/d2/adpub_form.aspx" onMouseOver="JavaM(9,2)" class="header"> &nbsp; 廣告落版單</A> ',
            '<A HREF="/mrlpub/d2/adpub_list.aspx" onMouseOver="JavaM(9,2)" class="header"> &nbsp; 廣告落版清單</A> ',
             '<A HREF="/mrlpub/d2/admade_stat.aspx" onMouseOver="JavaM(9,2)" class="header"> &nbsp; 廣告製稿統計表</A> '
);

//2-3-2
Layer[25] =    new LayerSpecs(409,116,100,
            '<A HREF="/mrlpub/d2/adpub_main11.aspx" class="header"> &nbsp; 由合約書進入</A> ',
            '<A HREF="/mrlpub/d2/adpub_main21.aspx" class="header"> &nbsp; 由年月落版進入</A> '
);

//2-4
Layer[10] =    new LayerSpecs(286,98,110,
            '<A HREF="/mrlpub/d2/invapply.aspx" class="header"> &nbsp; 發票開立申請單</A> ',
            '<A HREF="/mrlpub/d2/invapply_list.aspx" class="header"> &nbsp; 發票開立清單</A> ',
            '<A HREF="/mrlpub/d2/invapplyseq_list.aspx" class="header"> &nbsp; 發票開立清單編號</A> ',
            '<A HREF="/mrlpub/d2/invmail_list.aspx" class="header"> &nbsp; 發票郵寄清單</A> ',
            '<A HREF="/mrlpub/d2/invtranssap.aspx" class="header"> &nbsp; 發票轉 SAP 處理</A> '
);

//平面廣告次系統-繳款處理2-5
Layer[21] =    new LayerSpecs(286,116,80,
            '<A HREF="/mrlpub/d2/payment.aspx" class="header"> &nbsp; 繳款單</A> ',
            '<A HREF="/mrlpub/d2/payment_list.aspx" class="header"> &nbsp; 繳款清單</A> '
);

//平面廣告次系統-缺書處理2-6
Layer[22] =    new LayerSpecs(286,134,80,
           '<A HREF="/mrlpub/temp.aspx" class="header"> &nbsp; 缺書登錄</A> ',
            '<A HREF="/mrlpub/temp.aspx" class="header"> &nbsp; 缺書清單</A> ',
            '<A HREF="/mrlpub/d2/lostbk_label.aspx" class="header"> &nbsp; 缺書標籤</A> '
);

//平面廣告次系統-催款處理2-7
Layer[23] =    new LayerSpecs(286,152,80,
            '<A HREF="/mrlpub/d2/getpay.aspx" class="header"> &nbsp; 催款單</A> ',
            '<A HREF="/mrlpub/d2/getpay_list.aspx" class="header"> &nbsp; 催款清單</A> '
);

//平面廣告次系統-推廣戶處理2-8
Layer[17] =    new LayerSpecs(286,170,110,
	    '<A HREF="/mrlpub/d2/custdata_list.aspx" class="header"> &nbsp; 客戶基本資料清單</A> ',
            '<A HREF="/mrlpub/d2/adprom_list.aspx" class="header"> &nbsp; 廣告推廣戶清單</A> ',
            '<A HREF="/mrlpub/d2/adprom_label.aspx" class="header"> &nbsp; 廣告推廣戶標籤</A> '
);

//2-9
Layer[18] =    new LayerSpecs(286,188,100,
            '<A HREF="/mrlpub/d2/adincome_stat.aspx" class="header"> &nbsp; 廣告收入統計表</A> ',
            '<A HREF="/mrlpub/d2/ramt_stat.aspx" class="header"> &nbsp; 郵寄本數統計表</A> '
);

//2-10
Layer[24] =    new LayerSpecs(286,206,135,
            '<A HREF="/mrlpub/d2/adlprior.aspx" class="header"> &nbsp; 版面優先次序</A> ',
            '<A HREF="/mrlpub/d2/adcolor.aspx" class="header"> &nbsp; 廣告色彩</A> ',
            '<A HREF="/mrlpub/d2/adlayout.aspx" class="header"> &nbsp; 廣告版面</A> ',
            '<A HREF="/mrlpub/d2/adpgsize.aspx" class="header"> &nbsp; 廣告篇幅</A> ',
            '<A HREF="/mrlpub/d2/njtype.aspx" class="header"> &nbsp; 新稿製法</A> ',
            '<A HREF="/mrlpub/d2/or.aspx" class="header"> &nbsp; 雜誌收件人 (瀏覽)</A> ',
            '<A HREF="/mrlpub/d2/invmfr.aspx" class="header"> &nbsp; 發票廠商收件人 (瀏覽)</A> ',
            '<A HREF="/mrlpub/d2/lostbk.aspx" class="header"> &nbsp; 缺書 (瀏覽)</A> '
);

//4-1
Layer[34] =    new LayerSpecs(519,44,124,
            '<A HREF="#" onMouseOver="JavaM(35,34,4)" class="header"> &nbsp; 一般合約書</A> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; '+arrow
            //'<A HREF="#" onMouseOver="JavaM(31,7,2)" class="header"> &nbsp; 推廣合約書</A> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; '+arrow,
            //'<A HREF="/mrlpub/d2/cont_list.aspx" onMouseOver="JavaM(7,2)" class="header"> &nbsp; 廣告合約書清單</A> ',
            //'<A HREF="/mrlpub/d2/adamt_list.aspx" onMouseOver="JavaM(7,2)" class="header"> &nbsp; 廣告費用檢查清單</A> ',
            //'<A HREF="#" onMouseOver="JavaM(19,7,2)" class="header"> &nbsp; 平面廣告標籤</A> &nbsp; &nbsp; &nbsp; &nbsp; '+arrow
);

//4-1-1
Layer[35] =    new LayerSpecs(644,44,80,
            '<A HREF="/mrlpub/d4/querycont.aspx" class="header"> &nbsp; 新增合約書</A> '
           // '<A HREF="/mrlpub/d2/cont_main1.aspx?function1=mod&conttp=01" class="header"> &nbsp; 維護合約書</A> '
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