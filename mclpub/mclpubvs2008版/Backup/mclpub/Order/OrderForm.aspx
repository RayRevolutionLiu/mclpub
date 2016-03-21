<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderForm.aspx.cs" Inherits="mclpub.Order.OrderForm"  MasterPageFile="~/MasterPage.Master"%>

<asp:Content id="Content1" ContentPlaceholderID="ContentPlaceHolder1" runat="server">

    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;訂單管理 / 雜誌叢書訂單處理 / <asp:Label ID="lblTitle" runat="server"></asp:Label> / 步驟三:新增訂單</span> 
    <span class="stripeMe">
    <br />
				<div align="center" width="100%"><asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></div>
				<table dataFld="訂單" id="Maintable" dataSrc="#DSO0" cellSpacing="0" cellPadding="0" width="100%" class="font_blacklink font_size13">
					<tr>
						<th colSpan="4">
							訂戶資料
						</th>
					</tr>
					<tr>
						<td style="WIDth: 114px" align="right">
							訂戶編號：
						</td>
						<td style="WIDth: 192px">
							<FONT color="#0000ff">&nbsp;&nbsp; </FONT>
							<asp:label id="lblInvoiceid" ForeColor="Maroon" Runat="server"></asp:label>
							<FONT color="#0000ff">&nbsp;[</FONT><font color="red">*</font><font color="blue">為必填欄位]</font> <input id="hiddenID" type="hidden" runat="server">
							<INPUT id="hiddenFgoi" style="WIDth: 20px; HEIGHT: 22px" type="hidden" size="4" runat="server">
							<INPUT id="hiddenFgoe" style="WIDth: 20px; HEIGHT: 22px" type="hidden" size="4" runat="server">
							<input id="hiddenPreXml" type="hidden" runat="server"> <input id="hiddenBook" runat="server" type="hidden">
						</td>
						<td style="WIDth: 108px" align="right">
							訂戶姓名：
						</td>
						<td style="WIDth: 192px">
							<FONT face="新細明體">&nbsp;&nbsp; </FONT>
							<asp:label id="lblName" ForeColor="Maroon" Runat="server"></asp:label>
						</td>
					</tr>
					<tr>
						<td style="WIDth: 114px" align="right">
							公司名稱：
						</td>
						<td style="WIDth: 192px" colSpan="3">
							<FONT face="新細明體">&nbsp;&nbsp; </FONT>
							<asp:label id="lblCoName" ForeColor="Maroon" Runat="server"></asp:label>
							<INPUT id="hiddenCoName" style="WIDth: 20px; HEIGHT: 22px" type="hidden" size="4" name="hiddenCoName" runat="server">
							<INPUT id="hiddenCoAddr" style="WIDth: 20px; HEIGHT: 22px" type="hidden" size="4" runat="server">
						</td>
					</tr>
					<tr bgColor="#214389">
						<th colSpan="4">
							訂單及發票資料
						</th>
					</tr>
					<tr>
						<td style="WIDth: 114px" align="right">
							訂單流水號：
						</td>
						<td style="WIDth: 246px">
							&nbsp;&nbsp;
							<asp:label id="lblOrderNo" runat="server" ForeColor="Maroon"></asp:label>
							<input id="hiddenOrderNo" type="hidden" runat="server">
						</td>
						<td style="WIDth: 105px" align="right">
							訂單來源：
						</td>
						<td style="WIDth: 235px">
							&nbsp;&nbsp; <SELECT dataFld="訂單來源" id="ddlOrderRes" name="ddlOrderRes" runat="server"></SELECT>
						</td>
					</tr>
					<tr>
						<td style="WIDth: 114px" align="right">
							訂購日期：
						</td>
						<td style="WIDth: 246px">
							&nbsp;&nbsp; <input id="tbxOrderDate" type="text" size="9" name="tbxOrderDate" runat="server" onclick="SelectDates(this)">
							<INPUT id="hiddenDate" style="WIDth: 20px; HEIGHT: 22px" type="hidden" size="4" name="hiddenDate" runat="server">
						</td>
						<td style="WIDth: 105px" align="right">
							訂購類別：
						</td>
						<td style="WIDth: 257px">
							&nbsp;&nbsp;
							<asp:textbox id="tbxOrderType1" runat="server" Width="38px" ReadOnly="true"></asp:textbox>
							<SELECT dataFld="訂購類別" id="ddlOrderType2" name="ddlOrderType2" runat="server"></SELECT>
							<input id="hiddenType1" style="WIDth: 88px; HEIGHT: 22px" type="hidden" size="9" runat="server">
						</td>
					</tr>
					<tr>
						<td style="WIDth: 114px" align="right">
							發票類別：
						</td>
						<td style="WIDth: 246px">
							<input dataFld="發票類別" type="radio" value="2" name="rblInvcd">二聯 <input dataFld="發票類別" type="radio" value="3" name="rblInvcd">三聯
							<input dataFld="發票類別" type="radio" value="4" name="rblInvcd">其他
						</td>
						<td style="WIDth: 105px" align="right">
							課稅別：
						</td>
						<td style="WIDth: 257px">
							<input dataFld="發票課稅別" type="radio" value="1" name="rblTaxtp">應稅5% <input dataFld="發票課稅別" type="radio" value="2" name="rblTaxtp">零稅
							<input dataFld="發票課稅別" type="radio" value="3" name="rblTaxtp">免稅
						</td>
					</tr>
					<tr>
						<td style="WIDth: 114px" align="right">
							付款方式：
						</td>
						<td>
							&nbsp;&nbsp; <SELECT dataFld="付款方式" id="ddlPayType" name="ddlPayType" runat="server"></SELECT>
						</td>
						<td style="WIDth: 108px" align="right">
							預開發票：
						</td>
						<td>
							<input dataFld="預開發票" type="radio" value="0" name="rbl1">否<input dataFld="預開發票" type="radio" value="1" name="rbl1">
						是
						<tr>
						<td style="WIDth: 114px" align="right">
							統一編號：
						</td>
						<td style="WIDth: 246px">
							<FONT face="新細明體">&nbsp;&nbsp; </FONT>
							<asp:textbox id="tbxMfrno" runat="server" Width="100px" ReadOnly MaxLength="10"></asp:textbox>
						</td>
						<td style="WIDth: 105px" align="right">
							電話：
						</td>
						<td style="WIDth: 257px">
							<font color="red">*</font>
							<asp:textbox id="tbxTel" runat="server" Width="100px" MaxLength="30"></asp:textbox>
						</td>
					</tr>
					<tr>
						<td style="WIDth: 114px" align="right">
							發票收件人姓名：
						</td>
						<td style="WIDth: 246px">
							<font color="red">*</font>
							<asp:textbox id="tbxInvoiceName" runat="server" MaxLength="30"></asp:textbox>
						</td>
						<td style="WIDth: 105px" align="right">
							傳真：
						</td>
						<td style="WIDth: 257px">
							<FONT face="新細明體">&nbsp;&nbsp; </FONT>
							<asp:textbox id="tbxFax" runat="server" Width="100px" MaxLength="30"></asp:textbox>
						</td>
					</tr>
					<tr>
						<td style="WIDth: 114px" align="right">
							發票收件人職稱：
						</td>
						<td style="WIDth: 246px">
							<input id="Radio1" dataFld="發票收件人職稱" onafterupdate="doChange()" type="radio" value="先生" name="rblJob" runat="server">先生
							<input id="Radio2" dataFld="發票收件人職稱" onafterupdate="doChange()" type="radio" value="小姐" name="rblJob" runat="server">小姐
							<input id="Radio3" dataFld="發票收件人職稱" onafterupdate="doChange()" type="radio" value="其他" name="rblJob" runat="server">其他
							<asp:textbox id="tbxInvoiceJob" runat="server" Width="82px" MaxLength="12"></asp:textbox>
						</td>
						<td style="WIDth: 105px" align="right">
							手機：
						</td>
						<td style="WIDth: 257px">
							<FONT face="新細明體">&nbsp;&nbsp; </FONT>
							<asp:textbox id="tbxCell" runat="server" Width="100px" MaxLength="30"></asp:textbox>
						</td>
					</tr>
					<tr>
						<td style="WIDth: 114px" align="right">
							發票收件人Email：
						</td>
						<td style="WIDth: 590px" colSpan="3">
							<FONT face="新細明體">&nbsp;&nbsp; </FONT>
							<asp:textbox id="tbxEmail" runat="server" Width="450px"></asp:textbox>
						</td>
					</tr>
					<tr>
						<td style="WIDth: 114px" align="right">
							郵遞區號：
						</td>
						<td style="WIDth: 590px" colSpan="3">
							<font color="red">*</font>
							<asp:textbox id="tbxPostCode" runat="server" Width="39px" MaxLength="5"></asp:textbox>
						</td>
					</tr>
					<tr>
						<td style="WIDth: 114px" align="right">
							發票郵寄地址：
						</td>
						<td style="WIDth: 590px" colSpan="3">
							<font color="red">*</font>
							<asp:textbox id="tbxAddress" runat="server" Width="450px" Height="24px"></asp:textbox>
							&nbsp;</td>
					</tr>
					<tr>
						<td style="WIDth: 114px" align="right">
							承辦業務員：
						</td>
						<td style="WIDth: 590px" colSpan="3">
							&nbsp;&nbsp;<SELECT dataFld="承辦人員" id="ddlSpn" name="ddlSpn" runat="server"></SELECT>
						</td>
					</tr>
					<tr>
						<th colSpan="4">
							收件人資料
						</th>
					</tr>
					<tr>
						<td style="WIDth: 114px" align="right">
							收件人：
						</td>
						<td style="WIDth: 590px" colSpan="3">
							<IMG class="ico" title="新增/修改收件人" onclick="doGetrec()"  src="<%=ResolveUrl("~/Art/images/btn_search.gif")%>" border="0">
							<INPUT id="hiddenRec" type="hidden" name="hiddenRec" runat="server"><LABEL id="lblRec" style="COLOR: maroon"></LABEL>
						    </td>
					</tr>
				</table>
				<table dataFld="訂單明細" id="table1" dataSrc="#DSO0" cellSpacing="0" border="0" width="100%" class="font_blacklink font_size13">
					<tr>
						<td>
							<table dataFld="明細表" id="tbItems" dataSrc="#DSO0" cellSpacing="0" cellPadding="0" border="0" width="100%" class="font_blacklink font_size13">
								<thead>
									<tr>
										<th colSpan="11">
											訂單明細資料
										</th>
									</tr>
									<tr>
										<td>
											功能
										</td>
										<td>
											項次
										</td>
										<td>
											書籍類別
										</td>
										<td>
											訂戶別
										</td>
										<td>
											訂閱起時
										</td>
										<td>
											訂閱訖時
										</td>
										<td>
											金額
										</td>
										<td>
											總數量
										</td>
										<td>
											收件人
										</td>
										<td>
											備註
										</td>
									</tr>
								</thead>
								<tr>
									<td>
										<IMG class="ico" title="新增資料" onclick="doAddNew(this)"  src="<%=ResolveUrl("~/Art/images/btn_search.gif")%>" border="0"><FONT face="新細明體">&nbsp;</FONT><IMG class="ico" title="刪除資料" onclick="doDelete(this)"  src="<%=ResolveUrl("~/Art/images/cut.gif")%>" border="0">&nbsp;
									</td>
									<td>
										<INPUT dataFld="項次" id="tbxId" style="WIDth: 20px; HEIGHT: 22px" readOnly type="text" maxLength="1" size="1" value="1" name="tt1">
									</td>
									<td>
										<SELECT dataFld="書籍類別" id="ddlBookType"  onafterupdate="doSelectBook(this)" name="ddlBookType" runat="server">
											<OPTION selected>
											</OPTION>
										</SELECT><input dataFld="計劃代號" id="hiddenProj" style="WIDth: 27px; HEIGHT: 22px" type="hidden" size="1" runat="server"><INPUT dataFld="成本中心" id="hiddenCostctr" style="WIDth: 20px; HEIGHT: 22px" type="hidden" size="7" name="hiddenCostctr" runat="server">
									</td>
									<td>
										<SELECT dataFld="新舊訂戶" id="ddlCust" name="ddlCust" runat="server">
											<OPTION value="新訂戶" selected>
												新訂</OPTION>
											<OPTION value="續訂戶">
												續訂</OPTION></SELECT>
									</td>
									<td>
										<INPUT dataFld="訂閱起時" id="tbxStartdate" type="text" maxLength="10" size="6" name="tt4" style="width:80px" readonly="readonly">
										<IMG class="ico" title="日曆" onclick="pick_dateStart(this)" src="<%=ResolveUrl("~/jquery/development-bundle/demos/datepicker/images/calendar.gif")%>">
									</td>
									<td>
										<INPUT dataFld="訂閱訖時" id="tbxEndDate" type="text" maxLength="10" size="6" name="tt5" style="width:80px" readonly="readonly">
										<IMG class="ico" title="日曆" onclick="pick_dateEnd(this)" src="<%=ResolveUrl("~/jquery/development-bundle/demos/datepicker/images/calendar.gif")%>">
									</td>
									<td>
										<INPUT dataFld="金額" id="tbxAmt" style="WIDth: 41px; HEIGHT: 22px; TEXT-ALIGN: right" type="text" maxLength="6" size="1" name="tt6">
									</td>
									<td style="WIDth: 37px">
										<INPUT dataFld="總數量" id="tbxCount" style="WIDth: 32px; HEIGHT: 22px; TEXT-ALIGN: right" readOnly type="text" maxLength="4" size="1" name="tt7">
									</td>
									<td style="WIDth: 149px">
										&nbsp; <IMG class="ico" title="收件人詳細資料" onclick="doSelectrec(this)" src="<%=ResolveUrl("~/Art/images/btn_search.gif")%>" border="0">
										<LABEL id="lblRec1" style="COLOR: maroon"></LABEL>
									</td>
									<td>
										<INPUT dataFld="備註" id="tbxRemark" style="WIDth: 50px; HEIGHT: 22px" type="text" maxLength="30" size="3" name="tt7">
									</td>
								</tr>
							</table>
						</td>
					</tr>
				</table>
				<div width="100%" align="center">
				<input id="btnSave" onclick="doSubmit()" type="button" value="儲存訂單" name="btnSave"  class="btn_mouseout" onmouseover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'">
				<input id="btnCancel" onclick="javascript:window.location.href='../Default.aspx'" type="button" value="取消回首頁" name="btnCancel"  class="btn_mouseout" onmouseover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'"></div>
</span>

<script>
    function SelectDates(selfTBx) {
        $(function() {
        $("#<% =tbxOrderDate.ClientID%>").datepicker(
{
    showButtonPanel: true,
    autoSize: true,
    changeYear: true,
    changeMonth: true,
    dateFormat: 'yy/mm/dd',
    dayNamesMin: ['日', '一', '二', '三', '四', '五', '六'],
    monthNamesShort: ['1', '2', '3', '4', '5', '6', '7', '8', '9', '10', '11', '12'],
    nextText: "下一月",
    prevText: "上一月",
    closeText: "關閉",
    currentText: "今天"
});
        });
        if (a == true) {
            window.document.getElementById("<% =tbxAddress.ClientID%>").focus();
            window.document.getElementById(selfTBx.id.toString()).focus();
            a = false;
            }
        }
</script>

<%--<script>
    function SelectDatesStart(obj) {
        var idx = obj.recordNumber - 1;
        window.document.getElementById("Text1").value = idx;
        alert(idx);
        $(function() {
            $(".UniqueDateStart").datepicker(
{
    showButtonPanel: true,
    autoSize: true,
    changeYear: true,
    changeMonth: true,
    dateFormat: 'yy/mm/dd',
    dayNamesMin: ['日', '一', '二', '三', '四', '五', '六'],
    monthNamesShort: ['1', '2', '3', '4', '5', '6', '7', '8', '9', '10', '11', '12'],
    nextText: "下一月",
    prevText: "上一月",
    closeText: "關閉",
    currentText: "今天",
    onSelect: function(dateText, inst) {
        //    window.document.getElementById("Text1").value = dateText;
        xmlItems.childNodes.item(window.document.getElementById("Text1").value).selectSingleNode("訂閱起時").text = dateText;
        if (window.document.getElementById("Text1").value == "0") {
            window.document.getElementById("Text2").value = dateText;
        }
        else {
            xmlItems.childNodes.item(0).selectSingleNode("訂閱起時").text = window.document.getElementById("Text2").value;
        }
        //$(".UniqueDateStart").val("");
    }

});
        });

//        window.document.getElementById("<% =tbxAddress.ClientID%>").focus();//因為要FOCUS兩次日曆才會出來應稿的
//        window.document.getElementById(obj.id.toString()).focus();

    }
    
</script>

<script>
    function SelectDatesEnd(obj) {
        var idx = obj.recordNumber - 1;
        window.document.getElementById("Hidden1").value = idx;
        //alert(idx);
        $(function() {
        $(".UniqueDateEnd").datepicker(
{
    showButtonPanel: true,
    autoSize: true,
    changeYear: true,
    changeMonth: true,
    dateFormat: 'yy/mm/dd',
    dayNamesMin: ['日', '一', '二', '三', '四', '五', '六'],
    monthNamesShort: ['1', '2', '3', '4', '5', '6', '7', '8', '9', '10', '11', '12'],
    nextText: "下一月",
    prevText: "上一月",
    closeText: "關閉",
    currentText: "今天",
    onSelect: function(dateText, inst) {
        //    window.document.getElementById("Text1").value = dateText;
    xmlItems.childNodes.item(window.document.getElementById("Hidden1").value).selectSingleNode("訂閱訖時").text = dateText;
    if (window.document.getElementById("Hidden1").value == "0") {
        window.document.getElementById("Hidden2").value = dateText;
        }
        else {
            xmlItems.childNodes.item(0).selectSingleNode("訂閱訖時").text = window.document.getElementById("Hidden2").value;
        }
        //$(".UniqueDateStart").val("");
    }

});
        });

        window.document.getElementById("<% =tbxAddress.ClientID%>").focus(); //因為要FOCUS兩次日曆才會出來應稿的
        window.document.getElementById(obj.id.toString()).focus();
    }
    
</script>--%>

<script language="javascript">
    var a = true; //For IE9
    var strbuf = "";
DSO0.XMLDocument.async = false;
DSO1.XMLDocument.async = false; 
DSOX.XMLDocument.async = false;

var xmlDoc0 = DSO0.XMLDocument;
xmlDoc0.load("EmptyOrder.xml");
//xmlDoc0.loadXML("<root><收件人資料><收件人明細><序號></序號><姓名></姓名><公司名稱></公司名稱></收件人明細></收件人資料></root>");

//alert(xmlDoc0.childNodes.length);
//document.all("textarea1").value=xmlDoc0.xml;
//alert(xmlDoc0.xml);
//var xmlOwner = xmlDoc0.selectSingleNode("/root/訂戶");
var xmlReceivers = xmlDoc0.selectSingleNode("/root/收件人資料");
//var xmlRecItem = xmlDoc0.selectSingleNode("/root/投遞資料");
//alert('aaa'+document.getElementById("<% =hiddenCoName.ClientID%>").value+'bbb');
//alert(xmlReceivers.childNodes.length);
xmlReceivers.childNodes.item(0).selectSingleNode("公司名稱").text = document.all("<% =hiddenCoName.ClientID%>").value;
xmlReceivers.childNodes.item(0).selectSingleNode("地址").text = document.all("<% =tbxAddress.ClientID%>").value;
xmlReceivers.childNodes.item(0).selectSingleNode("姓名").text = document.all("<% =tbxInvoiceName.ClientID%>").value;
xmlReceivers.childNodes.item(0).selectSingleNode("職稱").text = document.all("<% =tbxInvoiceJob.ClientID%>").value;
xmlReceivers.childNodes.item(0).selectSingleNode("郵遞區號").text = document.all("<% =tbxPostCode.ClientID%>").value;
xmlReceivers.childNodes.item(0).selectSingleNode("電話").text = document.all("<% =tbxTel.ClientID%>").value;
xmlReceivers.childNodes.item(0).selectSingleNode("序號").text = "01";

var xmlItems = xmlDoc0.selectSingleNode("/root/訂單明細");
var xmlHeader = xmlDoc0.selectSingleNode("/root/訂單");
var xmlMain = xmlDoc0.selectSingleNode("/root");
//document.all("textarea1").value=xmlMain.xml;
var xmlEmptyItem = DSO1.XMLDocument;
xmlEmptyItem.load("EmptyList.xml");
var xmlDocX = DSOX.XMLDocument;
xmlDocX.loadXML(document.all("<% =hiddenBook.ClientID%>").value);
//alert(document.all("<% =hiddenBook.ClientID%>").value);
//alert(xmlDocX.selectSingleNode("/NewDataSet/Table").childNodes.length);

var ItemBook=xmlDocX.selectSingleNode("書籍資料");
//alert(xmlItems.xml);
if ((document.all("<% =tbxInvoiceJob.ClientID%>").value == "小姐") || (document.all("<% =tbxInvoiceJob.ClientID%>").value == "先生"))
    xmlHeader.selectSingleNode("發票收件人職稱").text = window.document.all("<% =tbxInvoiceJob.ClientID%>").value;
else
    xmlHeader.selectSingleNode("發票收件人職稱").text = "其他";
//xmlHeader.selectSingleNode("訂購日期").text=window.document.all("hiddenDate").value;

//window.document.getElementById("<% =tbxOrderDate.ClientID%>").focus();
//window.document.getElementById("<% =tbxAddress.ClientID%>").focus();
</script>

<script language="javascript">
function doChange(){
	if(xmlHeader.selectSingleNode("發票收件人職稱").text=="其他")
	    document.all("<% =tbxInvoiceJob.ClientID%>").value = "";
	else
	    document.all("<% =tbxInvoiceJob.ClientID%>").value = xmlHeader.selectSingleNode("發票收件人職稱").text;
}

function doAddNew(obj)
{
	var idx = xmlItems.childNodes.length;
	var newNode = xmlEmptyItem.documentElement.cloneNode(true);
	xmlItems.appendChild(newNode);
	var	j1=String(idx+1);
	if(j1.length==1){
		j1="0"+j1;
		xmlItems.childNodes.item(idx).selectSingleNode("項次").text=j1;
	}
	else
		xmlItems.childNodes.item(idx).selectSingleNode("項次").text=idx+1;
}
function doDelete(obj){
    var idxtmp = obj.parentNode.parentNode.parentNode.getElementsByTagName("td")[1].firstChild.value;
    var idx = parseInt(idxtmp) - 1;
	var oldNode = xmlItems.childNodes.item(idx);
	if(xmlItems.childNodes.length > 1){
		oldNode.parentNode.removeChild(oldNode);
		for(i=0; i<xmlItems.childNodes.length;i++){
			j1=String(i+1);
			if(j1.length==1){
				j1="0"+j1;
				xmlItems.childNodes.item(i).selectSingleNode("項次").text=j1;
			}
			else
				xmlItems.childNodes.item(i).selectSingleNode("項次").text=i+1;
		}
	}
}


function doSelectBook(obj) {
    var idxtmp = obj.parentNode.parentNode.parentNode.getElementsByTagName("td")[1].firstChild.value;
    var idx = parseInt(idxtmp) - 1;
    //alert(convertidx);
    BookType = xmlItems.childNodes.item(idx).selectSingleNode("書籍類別").text;

    //alert(xmlItems.getElement);
    //BookType = xmlItems.childNodes.item(idx).selectSingleNode("書籍類別").text;
	
	if(xmlHeader.selectSingleNode("付款方式").text=="06")
		PayType="06";
	else
	    PayType = "";
	//alert(ItemBook.childNodes.length);
	for(i=0; i<ItemBook.childNodes.length; i++){
	    if ((ItemBook.childNodes.item(i).selectSingleNode("obtp_otp1cd").text == document.all("<% =hiddenType1.ClientID%>").value) && (ItemBook.childNodes.item(i).selectSingleNode("fgitri").text == PayType)
			&&(ItemBook.childNodes.item(i).selectSingleNode("obtp_obtpcd").text==BookType)){
			strbuf=ItemBook.childNodes.item(i).selectSingleNode("nostr").text;
			break;
		}
	}
	xmlItems.childNodes.item(idx).selectSingleNode("計劃代號").text=strbuf.substr(2, 10);
	xmlItems.childNodes.item(idx).selectSingleNode("成本中心").text=strbuf.substr(12, 7);
	if(BookType=="01"){
	    if (window.document.all("<% =hiddenFgoi.ClientID%>").value == "0")
			xmlItems.childNodes.item(idx).selectSingleNode("新舊訂戶").text="新訂戶";
		else
			xmlItems.childNodes.item(idx).selectSingleNode("新舊訂戶").text="續訂戶";
	}
	else if(BookType=="02"){
	if (window.document.all("<% =hiddenFgoe.ClientID%>").value == "0")
			xmlItems.childNodes.item(idx).selectSingleNode("新舊訂戶").text="新訂戶";
		else
			xmlItems.childNodes.item(idx).selectSingleNode("新舊訂戶").text="續訂戶";
	}
	//window.document.all("textarea1").value=xmlItems.xml;

}

function doGetrec()
{
    var myObject = new Object();
    if (document.all("<% =hiddenRec.ClientID%>").value == "") {
		myObject.flag=false;
		alert("沒有歷史資料, 請自行輸入資料");
	}
	else{
	    myObject.flag=true;
	    myObject.prexmldata = document.all("<% =hiddenRec.ClientID%>").value;
	}
    myObject.xmldata=xmlReceivers.xml;
    myObject.CoName = document.all("<% =hiddenCoName.ClientID%>").value;
    myObject.Name = document.all("<% =tbxInvoiceName.ClientID%>").value;
    myObject.Address = document.all("<% =tbxAddress.ClientID%>").value;
    myObject.PostCode = document.all("<% =tbxPostCode.ClientID%>").value;
    myObject.Job = document.all("<% =tbxInvoiceJob.ClientID%>").value;
    myObject.Tel = document.all("<% =tbxTel.ClientID%>").value;
    vreturn=window.showModalDialog("RecForm.aspx", myObject, "dialogHeight:400px;dialogWidth:800px;center:yes;scroll:yes;status:no;help:no;"); 
//    alert(myObject.result.xml);
	if(vreturn){
		xmlReceivers.parentNode.replaceChild(myObject.result, xmlReceivers);
		xmlReceivers = xmlDoc0.selectSingleNode("/root/收件人資料");
		strbuf="";
		for(i=0; i<xmlReceivers.childNodes.length; i++){
			strbuf+=xmlReceivers.childNodes.item(i).selectSingleNode("姓名").text+",";	//<姓名>為第二欄
		}
		document.all("lblRec").innerText=strbuf;
	}
}
function doSelectrec(obj)
{
    var idxtmp = obj.parentNode.parentNode.parentNode.getElementsByTagName("td")[1].firstChild.value;
    var idx = parseInt(idxtmp) - 1;
    var myObject = new Object();
    var Items=xmlItems.childNodes.item(idx).selectSingleNode("投遞資料");
//    alert(Items.xml);
//    myObject.CoName=document.all("hiddenCoName").value;
	myObject.prexmldata=xmlReceivers;
    myObject.xmldata=xmlItems.childNodes.item(idx).selectSingleNode("投遞資料");
    vreturn=window.showModalDialog("SetrecForm.aspx", myObject, "dialogHeight:500px;dialogWidth:530px;"); 
    if(vreturn){
		Items.parentNode.replaceChild(myObject.result, Items);
		Items=xmlItems.childNodes.item(idx).selectSingleNode("投遞資料");
		var	amt=0;
		strbuf="";
		for(i=0; i<Items.childNodes.length; i++){
			amt=amt+parseInt(Items.childNodes.item(i).selectSingleNode("郵寄數量").text);	//<姓名>為第二欄
			strbuf+=Items.childNodes.item(i).selectSingleNode("姓名").text+",";	//<姓名>為第二欄
		}
		xmlItems.childNodes.item(idx).selectSingleNode("總數量").text=String(amt);
		event.srcElement.parentElement.children("lblRec1").innerText=strbuf;
	}
}

function pick_date(theField){
	var oParam = new Object();
	strFeature = "";
	strFeature += "dialogHeight:250px;dialogWidth:200px;center:yes;scroll:yes;status:no;help:no;";
	var vreturn = window.showModalDialog("calendar.asp", oParam, strFeature); 
	if(vreturn)
		window.document.all(theField).value=vreturn;
	return true;
}
function pick_dateStart(obj){
    var idxtmp = obj.parentNode.parentNode.parentNode.getElementsByTagName("td")[1].firstChild.value;
    var idx = parseInt(idxtmp) - 1;
	var oParam = new Object();
	strFeature = "";
	strFeature += "dialogHeight:250px;dialogWidth:200px;center:yes;scroll:yes;status:no;help:no;";
	var vreturn = window.showModalDialog("Calendar.htm", oParam, strFeature); 
	if(vreturn)
		xmlItems.childNodes.item(idx).selectSingleNode("訂閱起時").text=vreturn;
	return true;
}
function pick_dateEnd(obj){
    var idxtmp = obj.parentNode.parentNode.parentNode.getElementsByTagName("td")[1].firstChild.value;
    var idx = parseInt(idxtmp) - 1;
	var oParam = new Object();
	strFeature = "";
	strFeature += "dialogHeight:250px;dialogWidth:200px;center:yes;scroll:yes;status:no;help:no;";
	var vreturn = window.showModalDialog("Calendar.htm", oParam, strFeature); 
	if(vreturn)
		xmlItems.childNodes.item(idx).selectSingleNode("訂閱訖時").text=vreturn;
	return true;
}
function doSubmit()
{
	//判斷是零售or訂閱訂單
	var OrderFlag=false;
	if (window.document.all("<% =hiddenType1.ClientID%>").value == "01") {
		for(i=0; i<xmlItems.childNodes.length; i++){
			booktype = xmlItems.childNodes.item(i).selectSingleNode("書籍類別").text;
			if((booktype == "01")||(booktype == "02")){
				OrderFlag=true;
			}
		}
		if(OrderFlag)
			SaveProc();
		else
			alert("沒有訂閱明細, 此為純零售訂單, 請至零售訂單新增資料.");
	}
	else
		SaveProc();
}
function SaveProc()
{
//	alert("SaveProc[]");
	xmlHeader.selectSingleNode("系統代碼").text="C1";
	xmlHeader.selectSingleNode("訂戶編號").text = window.document.all("<% =hiddenID.ClientID%>").value;
	xmlHeader.selectSingleNode("訂單流水號").text = window.document.all("<% =hiddenOrderNo.ClientID%>").value;
	xmlHeader.selectSingleNode("訂購類別一").text = window.document.all("<% =hiddenType1.ClientID%>").value;
	if (window.document.all("<% =hiddenType1.ClientID%>").value == "09")
		xmlHeader.selectSingleNode("訂購類別二").text="00";
	else
	    xmlHeader.selectSingleNode("訂購類別二").text = window.document.all("<% =ddlOrderType2.ClientID%>").value;
	xmlHeader.selectSingleNode("統一編號").text = window.document.all("<% =tbxMfrno.ClientID%>").value;
	if (window.document.all("<% =tbxInvoiceName.ClientID%>").value == "") {
		alert("發票收件人姓名不可空白");
		document.all("<% =tbxInvoiceName.ClientID%>").focus();
		return;
	}
	if (window.document.all("<% =tbxTel.ClientID%>").value == "") {
		alert("發票收件人電話不可空白");
		document.all("<% =tbxTel.ClientID%>").focus();
		return;
	}
	if (window.document.all("<% =tbxAddress.ClientID%>").value == "") {
		alert("發票收件人地址不可空白");
		document.all("<% =tbxAddress.ClientID%>").focus();
		return;
	}
	if (window.document.all("<% =tbxPostCode.ClientID%>").value == "") {
		alert("發票收件人郵遞區號不可空白");
		document.all("<% =tbxPostCode.ClientID%>").focus();
		return;
    }
    if (window.document.all("<% =ddlSpn.ClientID%>").value == "") {
    alert("請選擇承辦業務員");
    document.all("<% =ddlSpn.ClientID%>").focus();
    return;
    }
	xmlHeader.selectSingleNode("發票收件人姓名").text = window.document.all("<% =tbxInvoiceName.ClientID%>").value;
	if(xmlHeader.selectSingleNode("發票收件人職稱").text=="其他")
	    xmlHeader.selectSingleNode("發票收件人職稱").text = window.document.all("<% =tbxInvoiceJob.ClientID%>").value;
	xmlHeader.selectSingleNode("發票收件人地址").text = window.document.all("<% =tbxAddress.ClientID%>").value;
	xmlHeader.selectSingleNode("發票收件人郵遞區號").text = window.document.all("<% =tbxPostCode.ClientID%>").value;
	xmlHeader.selectSingleNode("發票收件人電話").text = window.document.all("<% =tbxTel.ClientID%>").value;
	xmlHeader.selectSingleNode("發票收件人傳真").text = window.document.all("<% =tbxFax.ClientID%>").value;
	xmlHeader.selectSingleNode("發票收件人手機").text = window.document.all("<% =tbxCell.ClientID%>").value;
	xmlHeader.selectSingleNode("發票收件人Email").text = window.document.all("<% =tbxEmail.ClientID%>").value;
	xmlHeader.selectSingleNode("訂購日期").text = window.document.all("<% =tbxOrderDate.ClientID%>").value;


	//xmlHeader.selectSingleNode("承辦人員").text = window.document.all("<% =ddlSpn.ClientID%>").value;


	//  在這邊把xmlDoc0.xml的資料傳給存檔程式
	var xmlHTTP = false;
	if (window.XMLHttpRequest) { // 如果是 Mozilla, Safari,...
	    xmlHTTP = new XMLHttpRequest();
	} else if (window.ActiveXObject) { // 如果是 IE
	    try {
	        // IE 又分成新版和舊版的，其處理方式也不同
	        // 新版的 IE，目前 IE 9 OK
	        xmlHTTP = new ActiveXObject("Msxml2.XMLHTTP");
	    } catch (e) {
	        try {
	            // 舊版的 IE
	            xmlHTTP = new ActiveXObject("Microsoft.XMLHTTP");
	        } catch (e) { }
	    }
	}

	//alert(xmlDoc0.selectSingleNode("/root").childNodes.item(0).text);
	//window.document.getElementById("aaaaaa1").value = xmlDoc0.loadXML();
	//var xmlHTTP = new ActiveXObject("MSXML2.XMLHTTP.3.0");
	xmlHTTP.open("post", "SaveOrder.aspx", false);
	//xmlHTTP.setRequestHeader("Content-Type", "application/x-www-form-urlencoded;charset=UTF-8"); 
	xmlHTTP.send(xmlDoc0);
	//alert(xmlHTTP.responseText);
//	document.all("aaaaaa1").value = xmlHTTP.responseText;
//	alert(xmlHTTP.responseText);
	//alert(xmlDoc0.xml);
	
	
	
    var myObject = new Object();
    strbuf = "C1" + document.all("<% =hiddenID.ClientID%>").value + document.all("<% =hiddenType1.ClientID%>").value + document.all("<% =hiddenOrderNo.ClientID%>").value;
    xmlHeader.selectSingleNode("訂戶編號").text = window.document.all("<% =hiddenID.ClientID%>").value;
    xmlHeader.selectSingleNode("訂單流水號").text = window.document.all("<% =hiddenOrderNo.ClientID%>").value;
    xmlHeader.selectSingleNode("訂購類別一").text = window.document.all("<% =hiddenType1.ClientID%>").value;

	if(xmlHTTP.statusText=="OK"){
//		alert("新增訂單成功");
//		if(window.confirm("新增訂單成功,要進行繳款處理?"))
//			window.location.href="http://140.96.18.18/mrlpub/d1/PayFilter.aspx?caller=order";
//			window.location.href="http://140.96.18.18/mrlpub/d1/PayTypeForm.aspx?caller=order&id="+window.document.all("hiddenOrderNo").value;
//		else{

			if(window.confirm("要繼續新增或修改訂單?")){
			    if (window.document.all("<% =hiddenType1.ClientID%>").value == "01")
			        window.location.href = "SearchCustOrder.aspx?type=01";
	else if (window.document.all("<% =hiddenType1.ClientID%>").value == "09")
	    window.location.href = "SearchCustOrder.aspx?type=09";
			}
			else
			    window.location.href = "../default.aspx";
			    
			    
//		}
	}
//	else if(xmlHTTP.statusText=="Error1")
//		alert("新增發票開立單檔失敗!!"+xmlHTTP.responseText);
	else if(xmlHTTP.statusText=="Error2")
		alert("新增訂單失敗!!"+xmlHTTP.responseText);
	else
		alert(xmlHTTP.responseText);
	var xmlHTTP = null;
}

</script>

</asp:Content>
