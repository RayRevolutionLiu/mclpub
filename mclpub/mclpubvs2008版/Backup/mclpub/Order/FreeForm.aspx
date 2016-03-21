<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FreeForm.aspx.cs" Inherits="mclpub.Order.FreeForm" MasterPageFile="~/MasterPage.Master"%>

<asp:Content id="Content1" ContentPlaceholderID="ContentPlaceHolder1" runat="server">
<span class="stripeMe">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;訂單管理 / 雜誌叢書訂單處理 / <asp:Label ID="lblTitle" runat="server"></asp:Label> / 步驟三:修改訂單</span> 
				<TABLE dataFld="訂單" id="MainTable" dataSrc="#DSO0" cellSpacing="0" cellPadding="0" width="100%" class="font_blacklink font_size13">
					<tr>
						<th colSpan="4">
							訂戶資料
						</th>
					</tr>
					<tr>
						<td style="WIDTH: 108px" align="right">
							訂戶編號：
						</td>
						<td style="WIDTH: 192px">
							<FONT color="#0000ff">&nbsp;&nbsp; </FONT>
							<asp:label id="lblInvoiceid" Runat="server" ForeColor="Maroon"></asp:label>
							<FONT color="#0000ff"></FONT><input id="hiddenID" type="hidden" name="hiddenID" runat="server">
							<INPUT id="hiddenMfrno" style="WIDTH: 20px; HEIGHT: 22px" type="hidden" size="4" name="hiddenFgoi" runat="server">
							<input id="hiddenPreXml" type="hidden" name="hiddenPreXml" runat="server"> <input id="hiddenBook" type="hidden" name="hiddenBook" runat="server">
						</td>
						<td style="WIDTH: 108px" align="right">
							訂戶姓名：
						</td>
						<td style="WIDTH: 192px">
							<FONT face="新細明體">&nbsp;&nbsp; </FONT>
							<asp:label id="lblName" Runat="server" ForeColor="Maroon"></asp:label>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 108px" align="right">
							公司名稱：
						</td>
						<td style="WIDTH: 192px" colSpan="3">
							<FONT face="新細明體">&nbsp;&nbsp; </FONT>
							<asp:label id="lblCoName" Runat="server" ForeColor="Maroon"></asp:label>
							<INPUT id="hiddenCoName" style="WIDTH: 20px; HEIGHT: 22px" type="hidden" size="4" name="hiddenCoName" runat="server">
							<INPUT id="hiddenCoAddress" style="WIDTH: 20px; HEIGHT: 22px" type="hidden" size="4" name="hiddenCoAddress" runat="server">
						</td>
					</tr>
					</tr>
					<tr>
						<th colSpan="4">
							<font color="white">訂單資料</font>
						</th>
					</tr>
					<tr>
						<td style="WIDTH: 108px" align="right" bgColor="#bfcff0">
							訂單流水號：
						</td>
						<td style="WIDTH: 246px">
							&nbsp;&nbsp;
							<asp:label id="lblOrderNo" runat="server" ForeColor="Maroon"></asp:label>
							<input id="hiddenOrderNo" type="hidden" name="hiddenOrderNo" runat="server">
						</td>
						<td style="WIDTH: 105px" align="right" bgColor="#bfcff0">
							訂單來源：
						</td>
						<td style="WIDTH: 235px">
							&nbsp;&nbsp; <SELECT dataFld="訂單來源" id="ddlOrderRes" name="ddlOrderRes" runat="server"></SELECT>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 108px" align="right" bgColor="#bfcff0">
							訂購日期：
						</td>
						<td style="WIDTH: 246px">
							&nbsp;&nbsp; <input id="tbxOrderDate" type="text" size="9" name="tbxOrderDate" runat="server" onclick="SelectDates(this)">&nbsp;
							<INPUT id="hiddenDate" style="WIDTH: 20px; HEIGHT: 22px" type="hidden" size="4" name="hiddenDate" runat="server">
						</td>
						<td style="WIDTH: 105px" align="right" bgColor="#bfcff0">
							訂購類別：
						</td>
						<td style="WIDTH: 257px">
							&nbsp;&nbsp;
							<asp:textbox id="tbxOrderType1" runat="server" ReadOnly="true" Width="38px"></asp:textbox>
							<SELECT dataFld="訂購類別" id="ddlOrderType2" name="ddlOrderType2" runat="server"></SELECT>
							<input id="hiddenType1" style="WIDTH: 88px; HEIGHT: 22px" type="hidden" size="9" name="hiddenType1" runat="server">
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 114px" align="right" bgColor="#bfcff0">
							承辦業務員：
						</td>
						<td style="WIDTH: 590px" colSpan="3">
							&nbsp;&nbsp; <SELECT dataFld="承辦人員" id="ddlSpn" name="ddlSpn" runat="server"></SELECT>
						</td>
					</tr>
					<tr>
						<th colSpan="4">
							收件人資料
						</th>
					</tr>
					<tr>
						<td style="WIDTH: 108px" align="right" bgColor="#bfcff0">
							收件人：
						</td>
						<td style="WIDTH: 590px" colSpan="3">
							<IMG class="ico" title="新增/修改收件人" onclick="doGetRec()"  src="<%=ResolveUrl("~/Art/images/btn_search.gif")%>" border="0">
							<INPUT id="hiddenRec" type="hidden" name="hiddenRec" runat="server"><LABEL id="lblRec" style="COLOR: maroon"></LABEL>
						</td>
					</tr>
				</TABLE>
				<TABLE dataFld="訂單明細" id="Table1" dataSrc="#DSO0" cellSpacing="0" border="0" width="100%" class="font_blacklink font_size13">
					<tr>
						<td>
							<TABLE dataFld="明細表" id="tbItems" dataSrc="#DSO0" cellSpacing="0" cellPadding="0" border="0" width="100%" class="font_blacklink font_size13">
								<THEAD>
									<tr>
										<th colSpan="10">
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
											計劃代號
										</td>
										<td>
											訂閱起時
										</td>
										<td>
											訂閱訖時
										</td>
										<td>
											總數量
										</td>
										<td>
											收件人
										</td>
									</tr>
								</THEAD>
								<tr>
									<td>
										<img border="0" class="ico" onclick="doAddNew(this)" 
                                            src='<%=ResolveUrl("~/Art/images/btn_search.gif")%>' title="新增資料" /> <img 
                                            border="0" class="ico" onclick="doDelete(this)" 
                                            src='<%=ResolveUrl("~/Art/images/cut.gif")%>' title="刪除資料" />&nbsp;
									</td>
									<td>
										<INPUT dataFld="項次" id="tbxId" style="WIDTH: 20px; HEIGHT: 22px" readOnly type="text" maxLength="1" size="1" value="1" name="tt1">
									</td>
									<td>
										<SELECT dataFld="書籍類別" id="ddlBookType" onafterupdate="doSelectBook(this)" name="ddlBookType" runat="server">
											<OPTION selected>
											</OPTION>
										</SELECT>
									</td>
									<td>
										<INPUT dataFld="計劃代號" id="tbxProj" style="WIDTH: 85px; HEIGHT: 22px" readOnly type="text" maxLength="10" size="7" name="tt3">
										<INPUT dataFld="成本中心" id="hiddenCostctr" style="WIDTH: 20px; HEIGHT: 22px" type="hidden" size="7" name="hiddenCostctr" runat="server">
									</td>
									<td>
										<INPUT dataFld="訂閱起時" id="tbxStartdate" style="WIDTH: 80px; HEIGHT: 22px" type="text" maxLength="10" size="6" name="tt4">
										<img class="ico" onclick="pick_dateStart(this)" 
                                            src='<%=ResolveUrl("~/jquery/development-bundle/demos/datepicker/images/calendar.gif")%>' 
                                            title="日曆" />
									</td>
									<td>
										<INPUT dataFld="訂閱訖時" id="tbxEndDate" style="WIDTH: 80px; HEIGHT: 22px" type="text" maxLength="10" size="6" name="tt5">
										<img class="ico" onclick="pick_dateEnd(this)" 
                                            src='<%=ResolveUrl("~/jquery/development-bundle/demos/datepicker/images/calendar.gif")%>' 
                                            title="日曆" />
									</td>
									<td>
										<INPUT dataFld="總數量" id="tbxCount" style="WIDTH: 32px; HEIGHT: 22px" readOnly type="text" maxLength="4" size="1" name="tt7">
									</td>
									<td>
										&nbsp; <IMG class="ico" title="收件人詳細資料" onclick="doSelectRec(this)" src="<%=ResolveUrl("~/Art/images/btn_search.gif")%>" border="0">
									</td>
								</tr>
							</TABLE>
						</td>
					</tr>
				</TABLE>
				<div width="100%" align="center">
				<input id="btnSave" onclick="doSubmit()" type="button" value="儲存訂單" class="btn_mouseout" onmouseover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'">
				<input id="btnCancel" onclick='javascritp:window.location.href="../default.aspx"' type="button" value="取消回首頁" class="btn_mouseout" onmouseover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'">
				</div>
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
            window.document.getElementById("<% =tbxOrderType1.ClientID%>").focus();
            window.document.getElementById(selfTBx.id.toString()).focus();
            a = false;
            }
        }
</script>

		<script language="javascript">
		    var a = true; //For IE9
		    var strbuf = "";
		    DSO0.XMLDocument.async = false;
		    DSO1.XMLDocument.async = false;
		    DSOX.XMLDocument.async = false;

		    var xmlDoc0 = DSO0.XMLDocument;
		    xmlDoc0.load("EmptyOrder.xml");
		    //alert(xmlDoc0.xml);
		    //var xmlOwner = xmlDoc0.selectSingleNode("/root/訂戶");
		    var xmlReceivers = xmlDoc0.selectSingleNode("/root/收件人資料");
		    xmlReceivers.childNodes.item(0).selectSingleNode("公司名稱").text = document.all("<% =hiddenCoName.ClientID%>").value;
		    xmlReceivers.childNodes.item(0).selectSingleNode("地址").text = document.all("<% =hiddenCoAddress.ClientID%>").value;
		    xmlReceivers.childNodes.item(0).selectSingleNode("序號").text = "01";
		    var xmlRecItem = xmlDoc0.selectSingleNode("/root/投遞資料");
		    var xmlItems = xmlDoc0.selectSingleNode("/root/訂單明細");
		    var xmlHeader = xmlDoc0.selectSingleNode("/root/訂單");
		    var xmlMain = xmlDoc0.selectSingleNode("/root");
		    var xmlEmptyItem = DSO1.XMLDocument;
		    xmlEmptyItem.load("EmptyList.xml");
		    var xmlDocX = DSOX.XMLDocument;
		    xmlDocX.loadXML(document.all("<% =hiddenBook.ClientID%>").value);
		    var ItemBook = xmlDocX.selectSingleNode("書籍資料");
		    //xmlHeader.selectSingleNode("訂戶編號").text=window.document.all("hiddenId").value;
		    //xmlHeader.selectSingleNode("訂購日期").text=window.document.all("hiddenDate").value;
		</script>
		<script language="javascript">
		    function doAddNew(obj) {
		        //	var idx=obj.parentElement.parentElement.rowIndex-1;
		        //	var idx = obj.recordNumber-1;
		        var idx = xmlItems.childNodes.length;
		        //	xmlEmptyItem.documentElement.childNodes.item(0).text=idx;
		        var newNode = xmlEmptyItem.documentElement.cloneNode(true);
		        //	newNode.selectSingleNode("項次").text=idx;
		        //	xmlItems.insertBefore(newNode, xmlItems.childNodes.item(idx).nextSibling);
		        xmlItems.appendChild(newNode);
		        var j1 = String(idx + 1);
		        if (j1.length == 1) {
		            j1 = "0" + j1;
		            xmlItems.childNodes.item(idx).selectSingleNode("項次").text = j1;
		        }
		        else
		            xmlItems.childNodes.item(idx).selectSingleNode("項次").text = idx + 1;
		    }
		    function doDelete(obj) {
		        var idxtmp = obj.parentNode.parentNode.parentNode.getElementsByTagName("td")[1].firstChild.value;
		        var idx = parseInt(idxtmp) - 1;
		        var oldNode = xmlItems.childNodes.item(idx);
		        if (xmlItems.childNodes.length > 1) {
		            oldNode.parentNode.removeChild(oldNode);
		            for (i = 0; i < xmlItems.childNodes.length; i++) {
		                j1 = String(i + 1);
		                if (j1.length == 1) {
		                    j1 = "0" + j1;
		                    xmlItems.childNodes.item(i).selectSingleNode("項次").text = j1;
		                }
		                else
		                    xmlItems.childNodes.item(i).selectSingleNode("項次").text = i + 1;
		            }
		        }
		    }

		    function doSelectBook(obj) {
		        var idxtmp = obj.parentNode.parentNode.parentNode.getElementsByTagName("td")[1].firstChild.value;
		        var idx = parseInt(idxtmp) - 1;
		        BookType = xmlItems.childNodes.item(idx).selectSingleNode("書籍類別").text;
		        for (i = 0; i < ItemBook.childNodes.length; i++) {
		            if ((ItemBook.childNodes.item(i).selectSingleNode("obtp_otp1cd").text == document.all("<% =hiddenType1.ClientID%>").value) && (ItemBook.childNodes.item(i).selectSingleNode("fgitri").text == "")
			&& (ItemBook.childNodes.item(i).selectSingleNode("obtp_obtpcd").text == BookType)) {
		                strbuf = ItemBook.childNodes.item(i).selectSingleNode("nostr").text;
		                break;
		            }
		        }
		        //	strbuf = xmlItems.childNodes.item(idx).selectSingleNode("書籍類別").text;
		        //	xmlItems.childNodes.item(idx).selectSingleNode("書籍類別").text=strbuf.substr(0, 2);
		        xmlItems.childNodes.item(idx).selectSingleNode("計劃代號").text = strbuf.substr(2, 10);
		        xmlItems.childNodes.item(idx).selectSingleNode("成本中心").text = strbuf.substr(12, 7);

		    }

		    function doGetRec() {
		        var myObject = new Object();
		        //    myObject.id=id;
		        //    myObject.type1=type;
		        //    myObject.seq=seq;
		        //alert(document.all("hiddenRec").value);
		        if (document.all("<% =hiddenRec.ClientID%>").value == "") {
		            myObject.flag = false;
		            alert("沒有歷史資料, 請自行輸入資料");
		        }
		        else {
		            myObject.flag = true;
		            myObject.prexmldata = document.all("<% =hiddenRec.ClientID%>").value;
		        }
		        myObject.CoName = document.all("<% =hiddenCoName.ClientID%>").value;
		        myObject.CoAddress = document.all("<% =hiddenCoAddress.ClientID%>").value;
		        myObject.xmldata = xmlReceivers.xml;
		        //    alert(myObject.xmldata.xml);
		        //	strbuf="RecForm.aspx?id="+id+"&type1="+type+"&seq="+seq;
		        vreturn = window.showModalDialog("RecForm.aspx", myObject, "dialogHeight:450px;dialogWidth:800px;center:yes;scroll:yes;status:no;help:no;");
		        //    alert(myObject.result.xml);
		        if (vreturn) {
		            xmlReceivers.parentNode.replaceChild(myObject.result, xmlReceivers);
		            xmlReceivers = xmlDoc0.selectSingleNode("/root/收件人資料");
		            strbuf = "";
		            for (i = 0; i < xmlReceivers.childNodes.length; i++) {
		                //			strbuf+=xmlReceivers.childNodes.item(i).childNodes.item(1).text+",";	//<姓名>為第二欄
		                strbuf += xmlReceivers.childNodes.item(i).selectSingleNode("姓名").text + ","; //<姓名>為第二欄
		            }
		            document.all("lblRec").innerText = strbuf;
		        }
		    }
		    function doSelectRec(obj) {
		        var idxtmp = obj.parentNode.parentNode.parentNode.getElementsByTagName("td")[1].firstChild.value;
		        var idx = parseInt(idxtmp) - 1;
		        var myObject = new Object();
		        var Items = xmlItems.childNodes.item(idx).selectSingleNode("投遞資料");
		        myObject.prexmldata = xmlReceivers;
		        myObject.xmldata = xmlItems.childNodes.item(idx).selectSingleNode("投遞資料");
		        vreturn = window.showModalDialog("SetRecForm.aspx", myObject, "dialogHeight:500px;dialogWidth:750px;");
		        if (vreturn) {
		            Items.parentNode.replaceChild(myObject.result, Items);
		            Items = xmlItems.childNodes.item(idx).selectSingleNode("投遞資料");
		            var amt = 0;
		            for (i = 0; i < Items.childNodes.length; i++) {
		                amt = amt + parseInt(Items.childNodes.item(i).selectSingleNode("郵寄數量").text); //<姓名>為第二欄
		            }
		            xmlItems.childNodes.item(idx).selectSingleNode("總數量").text = String(amt);
		        }
		        //	document.all("textarea1").value=xmlItems.xml;
		    }

		    function pick_dateStart(obj) {
		        var idxtmp = obj.parentNode.parentNode.parentNode.getElementsByTagName("td")[1].firstChild.value;
		        var idx = parseInt(idxtmp) - 1;
		        var oParam = new Object();
		        strFeature = "";
		        strFeature += "dialogHeight:250px;dialogWidth:200px;center:yes;scroll:yes;status:no;help:no;";
		        var vreturn = window.showModalDialog("Calendar.htm", oParam, strFeature);
		        if (vreturn) {
		            xmlItems.childNodes.item(idx).selectSingleNode("訂閱起時").text = vreturn;
		            if (window.document.all("<% =hiddenType1.ClientID%>").value == "02") {
		                year = (parseInt(vreturn.substr(0, 4)) + 1).toString();
		                day = (parseInt(vreturn.substr(8, 2)) - 1).toString();
		                if (day = "0")
		                    day = "01";
		                if (day.length == 1)
		                    day = "0" + day;
		                month = vreturn.substr(5, 2);

		                //		LastDate = new Date(year+1, month, day-1);
		                if (month == "01")
		                    xmlItems.childNodes.item(idx).selectSingleNode("訂閱訖時").text = parseInt(year - 1).toString() + "/" + "12/31";
		                else {
		                    xmlItems.childNodes.item(idx).selectSingleNode("訂閱訖時").text = year + "/" + month + "/" + day;
		                }
		            }
		            else if (window.document.all("<% =hiddenType1.ClientID%>").value == "03")
		                xmlItems.childNodes.item(idx).selectSingleNode("訂閱訖時").text = "9999/01/01";
		        }
		        return true;
		    }
		    function pick_dateEnd(obj) {
		        var idxtmp = obj.parentNode.parentNode.parentNode.getElementsByTagName("td")[1].firstChild.value;
		        var idx = parseInt(idxtmp) - 1;
		        var oParam = new Object();
		        strFeature = "";
		        strFeature += "dialogHeight:250px;dialogWidth:200px;center:yes;scroll:yes;status:no;help:no;";
		        var vreturn = window.showModalDialog("Calendar.htm", oParam, strFeature);
		        if (vreturn)
		            xmlItems.childNodes.item(idx).selectSingleNode("訂閱訖時").text = vreturn;
		        return true;
		    }
		    function doSubmit() {
		        xmlHeader.selectSingleNode("系統代碼").text = "C1";
		        xmlHeader.selectSingleNode("訂戶編號").text = window.document.all("<% =hiddenID.ClientID%>").value;
		        xmlHeader.selectSingleNode("訂單流水號").text = window.document.all("<% =hiddenOrderNo.ClientID%>").value;
		        xmlHeader.selectSingleNode("訂購類別一").text = window.document.all("<% =hiddenType1.ClientID%>").value;
		        xmlHeader.selectSingleNode("訂購類別二").text = window.document.all("<% =ddlOrderType2.ClientID%>").value;
		        xmlHeader.selectSingleNode("預開發票").text = "0";
		        //	xmlHeader.selectSingleNode("承辦人員").text="840695";
		        xmlHeader.selectSingleNode("統一編號").text = window.document.all("<% =hiddenMfrno.ClientID%>").value;
		        xmlHeader.selectSingleNode("訂購日期").text = window.document.all("<% =tbxOrderDate.ClientID%>").value;

		        if (window.document.all("<% =ddlSpn.ClientID%>").value == "") {
		            alert("請選擇承辦業務員");
		            document.all("<% =ddlSpn.ClientID%>").focus();
		            return;
		        }
		        /*	document.all("tbxOrderDate").value=document.all("tbxOrderDate").value.replace("/", "");
		        document.all("tbxOrderDate").value=document.all("tbxOrderDate").value.replace("/", "");
		        xmlHeader.selectSingleNode("訂購日期").text=window.document.all("tbxOrderDate").value;
		        document.all("tbxStartDate").value=document.all("tbxStartDate").value.replace("/", "");
		        document.all("tbxStartDate").value=document.all("tbxStartDate").value.replace("/", "");
		        xmlItems.selectSingleNode("訂閱起時").text=window.document.all("tbxStartDate").value;
		        document.all("tbxEndDate").value=document.all("tbxEndDate").value.replace("/", "");
		        document.all("tbxEndDate").value=document.all("tbxEndDate").value.replace("/", "");
		        xmlItems.selectSingleNode("訂閱訖時").text=window.document.all("tbxEndDate").value;*/

		        //  在這邊把xmlDoc0.xml的資料傳給存檔程式
		        //	document.all("textarea1").value=xmlMain.xml;
		        var xmlHTTP = new ActiveXObject("MSXML2.XMLHTTP.3.0");
		        xmlHTTP.Open("post", "SaveOrder.aspx", false);
		        //	xmlHTTP.Open("post", "訂單.aspx", false);
		        xmlHTTP.Send(xmlDoc0);
		        if (xmlHTTP.statusText == "OK") {
		            //		alert("新增訂單成功");
		            if (window.confirm("新增訂單成功,要繼續新增訂單?")) {
		                if (window.document.all("<% =hiddenType1.ClientID%>").value == "02")
		                //				window.location.href="http://140.96.18.18/mrlpub/d1/SearchCust1.aspx?type1=02";
		                    window.location.href = "SearchCustOrder.aspx?type=02"; //20050519修改
		                else if (window.document.all("<% =hiddenType1.ClientID%>").value == "03")
		                //				window.location.href="http://140.96.18.18/mrlpub/d1/SearchCust1.aspx?type1=03";
		                    window.location.href = "SearchCustOrder.aspx?type=03"; //20050519修改
		            }
		            else
		                window.location.href = "../default.aspx";
		        }
		        else
		            alert(xmlHTTP.responseText);
		        var xmlHTTP = null;
		    }
	</script>
	
</asp:Content>


