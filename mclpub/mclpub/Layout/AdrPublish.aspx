<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdrPublish.aspx.cs" Inherits="mclpub.Layout.AdrPublish" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function datedifferent(diffType) {
            var str1 = $('#<% =tbxSDate.ClientID%>').val();
            var str2 = $('#<% =tbxEDate.ClientID%>').val();

            if (compareDate(str1, str2) == true) {
                alert("起始日期不應大於結束日期");
            }
            else if (str1 == "" || str2 == "") {

                alert("起始日期與結束日期皆不得空白");
            }
            else {
                diffType = diffType.toLowerCase();
                var sTime = new Date(str1);      //开始时间  
                var eTime = new Date(str2);  //结束时间  
                //作为除数的数字  

                var divNum = 1;
                switch (diffType) {
                    case "second":
                        divNum = 1000;
                        break;
                    case "minute":
                        divNum = 1000 * 60;
                        break;
                    case "hour":
                        divNum = 1000 * 3600;
                        break;
                    case "day":
                        divNum = 1000 * 3600 * 24;
                        break;
                    default:
                        break;
                }
                $(".CountDateDiff").val(parseInt((eTime.getTime() - sTime.getTime()) / parseInt(divNum)));
                //alert(parseInt((eTime.getTime() - sTime.getTime()) / parseInt(divNum)));
                //return parseInt((eTime.getTime() - sTime.getTime()) / parseInt(divNum));
            }
        }
        function compareDate(d1, d2) { // 时间比较的方法，如果d1时间比d2时间大，则返回true   
            return Date.parse(d1.replace(/-/g, "/")) > Date.parse(d2.replace(/-/g, "/"))
        }


        function SelectAllCheckboxes(spanChk) {
            elm = document.forms[0];
            for (i = 0; i <= elm.length - 1; i++) {
                if (elm[i].type == "checkbox" && elm[i].id != spanChk.id) {
                    if (elm.elements[i].checked != spanChk.checked)
                        elm.elements[i].click();
                }
            }
        } 
   
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;落版管理 / 網路廣告落版處理 / 落版資料維護</span>
    <span class="stripeMe font_size13">
    <table id="Table1" border="0" cellpadding="2" cellspacing="0"  width="100%">
        <tr>
            <th colspan="11">
                合約基本資料</th>
        </tr>
        <tr>
            <td>
                <table id="Table11" border="1" cellpadding="2" cellspacing="0" width="100%">
                    <tr>
                        <td>
                            合約編號</td>
                        <td>
                            合約類別</td>
                        <td>
                            簽約日期</td>
                        <td>
                            合約起迄</td>
                        <td>
                            廠商名稱</td>
                        <td>
                            客戶名稱</td>
                        <td>
                            刊登次數</td>
                        <td>
                            贈送次數</td>
                        <td>
                            合約金額</td>
                        <td>
                            優惠折數</td>
                        <td>
                            顯示合約</td>
                    </tr>
                    <tr>
                        <td style="background-color: #ecebff">
                            <asp:Label ID="lblContNo" runat="server" ></asp:Label>
                        </td>
                        <td style="background-color: #ecebff">
                            <asp:Label ID="lblContTp" runat="server" ></asp:Label>
                        </td>
                        <td style="background-color: #ecebff">
                            <asp:Label ID="lblSignDate" runat="server" ></asp:Label>
                        </td>
                        <td style="background-color: #ecebff">
                            <asp:Label ID="lblSDate" runat="server" ></asp:Label>
                            ～<asp:Label ID="lblEDate" runat="server" ></asp:Label>
                        </td>
                        <td style="background-color: #ecebff">
                            <asp:Label ID="lblMfrNm" runat="server" ></asp:Label>
                        </td>
                        <td style="background-color: #ecebff">
                            <asp:Label ID="lblCustNm" runat="server" ></asp:Label>
                        </td>
                        <td style="background-color: #ecebff">
                            <asp:Label ID="lblPubTm" runat="server" ></asp:Label>
                        </td>
                        <td style="background-color: #ecebff">
                            <asp:Label ID="lblFreeTm" runat="server" ></asp:Label>
                        </td>
                        <td style="background-color: #ecebff">
                            <asp:Label ID="lblTotAmt" runat="server" ></asp:Label>
                        </td>
                        <td style="background-color: #ecebff">
                            <asp:Label ID="lblDisc" runat="server" ></asp:Label>
                        </td>
                        <td style="background-color: #ecebff">
                            <img alt="詳細" border="0" name="imgShowCont" src="<%=ResolveUrl("~/Art/images/btn_data.gif")%>"
                                onclick="doDetail('680','730','../Contract/ContShow.aspx?ContNo=<% Response.Write(lblContNo.Text); %>');" />
                        </td>
                    </tr>
                </table>
                <table id="Table2" border="1" cellpadding="2" cellspacing="0" 
                    class="TableColor" width="100%">
                    <tr class="TableColor">
                        <td>
                            總刊登次數</td>
                        <td>
                            已刊登次數</td>
                        <td>
                            剩餘刊登次數</td>
                        <td>
                            總製圖檔稿次數</td>
                        <td>
                            剩餘製圖檔稿次數</td>
                        <td>
                            總製網頁稿次數</td>
                        <td>
                            剩餘製網頁稿次數</td>
                        <td>
                            首頁落版總次數</td>
                        <td colspan="2">
                            內頁落版總次數</td>
                    </tr>
                    <tr>
                        <td style="background-color: #ecebff">
                            <asp:Label ID="lbl_PubTm" runat="server" ></asp:Label>
                        </td>
                        <td style="background-color: #ecebff">
                            <asp:Label ID="lbl_PubedTm" runat="server" ></asp:Label>
                        </td>
                        <td style="background-color: #ecebff">
                            <asp:Label ID="lbl_RestTm" runat="server"  
                                ForeColor="Red"></asp:Label>
                        </td>
                        <td style="background-color: #ecebff">
                            <asp:Label ID="lbl_TotImgTm" runat="server" ></asp:Label>
                        </td>
                        <td style="background-color: #ecebff">
                            <asp:Label ID="lbl_RestImgTm" runat="server"  
                                ForeColor="Red"></asp:Label>
                        </td>
                        <td style="background-color: #ecebff">
                            <asp:Label ID="lbl_TotUrlTm" runat="server" ></asp:Label>
                        </td>
                        <td style="background-color: #ecebff">
                            <asp:Label ID="lbl_RestUrlTm" runat="server"  
                                ForeColor="Red"></asp:Label>
                        </td>
                        <td style="background-color: #ecebff">
                            <asp:Label ID="lblTotMtm" runat="server" ></asp:Label>
                        </td>
                        <td colspan="2" style="background-color: #ecebff">
                            <asp:Label ID="lblTotItm" runat="server" ></asp:Label>
                        </td>
<%--                        <td style="background-color: #ecebff">
                            <asp:Label ID="lblTotNtm" runat="server" ></asp:Label>
                        </td>--%>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

    <table id="Table3" cellspacing="0" cellpadding="2" width="100%" border="0">
            <tr>
                <th>
                    發票廠商收件人資料<img onclick='doOpenInvMfr(<% Response.Write("\""+lblContNo.Text+"\""); %>, "", "")'
                        alt="新增/修改" src="<%=ResolveUrl("~/Art/images/btn_data.gif")%>">
                </th>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="dgdNewInvMfr1" runat="server" AutoGenerateColumns="false"
                        CssClass="font_blacklink font_size13" Width="100%" AllowPaging="true" 
                        PagerSettings-Visible="false">
                    <Columns>
                        <asp:BoundField DataField="im_imseq" HeaderText="序號" />
                        <asp:BoundField DataField="im_mfrno" HeaderText="廠商統編" />
                        <asp:BoundField DataField="im_nm" HeaderText="收件人姓名" />
                        <asp:BoundField DataField="im_jbti" HeaderText="稱謂" />
                        <asp:BoundField DataField="im_zip" HeaderText="郵遞區號" />
                        <asp:BoundField DataField="im_addr" HeaderText="地址" />
                        <asp:BoundField DataField="im_tel" HeaderText="電話" />
                        <asp:BoundField DataField="im_fax" HeaderText="傳真" />
                        <asp:BoundField DataField="im_cell" HeaderText="手機" />
                        <asp:BoundField DataField="im_email" HeaderText="Email" />
                        <asp:BoundField DataField="invcd" HeaderText="發票類別" />
                        <asp:BoundField DataField="taxtp" HeaderText="發票課稅別" />
                        <asp:BoundField DataField="im_fgitri" HeaderText="院所內註記" />
                    </Columns>
                        <EmptyDataRowStyle HorizontalAlign="Center" />
                        <EmptyDataTemplate>
                            查詢無結果
                        </EmptyDataTemplate>
                    </asp:GridView>
                </td>
            </tr>
        </table>

    <table id="Table4" cellspacing="1" cellpadding="1" width="100%" border="0">
                <tr>
                    <th colspan="4">
                        廣告資料
                    </th>
                </tr>
                <tr>
                    <td align="right">
                        廣告起訖日期
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="tbxSDate" runat="server" Width="83px" CssClass="UniqueDate"></asp:TextBox>~
                        <asp:TextBox ID="tbxEDate" runat="server" Width="88px" CssClass="UniqueDate"></asp:TextBox>&nbsp;共<asp:TextBox ID="tbxCountDay" runat="server" Width="39px" ReadOnly="True" ForeColor="Red" CssClass="CountDateDiff">0</asp:TextBox>天
                        <input id="btnCount" type="button" value="計算天數" onclick="datedifferent('day')" class="btn_mouseout"
                            onmouseover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'" /></td>
                </tr>
                <tr>
                    <td align="right">
                        廣告標語
                    </td>
                    <td>
                        <asp:TextBox ID="tbxAltText" runat="server"></asp:TextBox>
                    </td>
                    <td align="right">
                        發票廠商
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlInvMfr" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        廣告頁面
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlAdCate" runat="server">
                            <asp:ListItem Value="M" Selected="True">首頁</asp:ListItem>
                            <asp:ListItem Value="I">內頁</asp:ListItem>
                            <asp:ListItem Value="N">奈米</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                        廣告位置
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlKeyword" runat="server">
                            <asp:ListItem Value="h1" Selected="True">右一</asp:ListItem>
                            <asp:ListItem Value="h2">右二</asp:ListItem>
                            <asp:ListItem Value="h3">右三</asp:ListItem>
                            <asp:ListItem Value="h4">右四</asp:ListItem>
                            <asp:ListItem Value="w1">右文一</asp:ListItem>
                            <asp:ListItem Value="w2">右文二</asp:ListItem>
                            <asp:ListItem Value="w3">右文三</asp:ListItem>
                            <asp:ListItem Value="w4">右文四</asp:ListItem>
                            <asp:ListItem Value="w5">右文五</asp:ListItem>
                            <asp:ListItem Value="w6">右文六</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        播放方式
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rblFgFixAd" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                            <asp:ListItem Value="0" Selected="True">輪播</asp:ListItem>
                            <asp:ListItem Value="1">定播</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td align="right">
                        播放機率
                    </td>
                    <td>
                        <asp:TextBox ID="tbxImpr" runat="server" MaxLength="2" Width="40px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        圖稿類別?
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rblImgTp" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1" Selected="True">舊稿</asp:ListItem>
                            <asp:ListItem Value="2">新稿</asp:ListItem>
                            <asp:ListItem Value="3">改稿</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td align="right">
                        URL類別?
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rblUrlTp" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1" Selected="True">舊稿</asp:ListItem>
                            <asp:ListItem Value="2">新稿</asp:ListItem>
                            <asp:ListItem Value="3">改稿</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        廣告價格
                    </td>
                    <td>
                        <asp:TextBox ID="tbxAdAmt" runat="server"></asp:TextBox>
                    </td>
                    <td align="right">
                        廣告連結
                    </td>
                    <td>
                        <asp:TextBox ID="tbxNavUrl" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        換稿費用
                    </td>
                    <td>
                        <asp:TextBox ID="tbxChgAmt" runat="server"></asp:TextBox>
                    </td>
                    <td align="right">
                        備註
                    </td>
                    <td>
                        <asp:TextBox ID="tbxRemark" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        設計價格
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="tbxDesAmt" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        落版金額
                    </td>
                    <td>
                        <asp:TextBox ID="tbxInvAmt" runat="server" CssClass="ReadOnlyTextBox" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td colspan="2">
                        <asp:Button ID="bthAddAdr" runat="server" Text="新增落版資料" 
                            onclick="bthAddAdr_Click"></asp:Button>
                    </td>
                </tr>
        </table>

    <table  id="Table5" cellspacing="0" cellpadding="2" width="100%" border="0">
            <tr>
                <th colspan="6">
                    已落版資料
                </th>
            </tr>
            <tr>
                <td>
                    <table id="Table6" cellspacing="1" cellpadding="1" border="1">
                        <tr>
                            <td class="TableColor" width="100">
                                廣告總金額
                            </td>
                            <td align="left" width="80" style="background-color: #ecebff">
                                <asp:Label ID="lblTotAdAmt" runat="server"></asp:Label>
                            </td>
                            <td class="TableColor" width="100">
                                設計總金額
                            </td>
                            <td align="left" width="80" style="background-color: #ecebff">
                                <asp:Label ID="lblTotDesAmt" runat="server"></asp:Label>
                            </td>
                            <td class="TableColor" width="100">
                                換稿總金額
                            </td>
                            <td align="left" width="80" style="background-color: #ecebff">
                                <asp:Label ID="lblTotChgAmt" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="TableColor">
                                已落版總金額
                            </td>
                            <td style="background-color: #ecebff">
                                <asp:Label ID="lblTotPubedAmt" runat="server" CssClass="NormalLabel"></asp:Label>
                            </td>
                            <td colspan="4">
                                <font face="新細明體">
                                    <asp:Label ID="lblHint" runat="server">已落版總金額=廣告總金額+設計總金額+換稿總金額，合約金額僅包含廣告金額部分</asp:Label></font>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnDelSeltedAdr" runat="server" Text="刪除選擇項目" 
                        onclick="btnDelSeltedAdr_Click"></asp:Button>
                    <input id="hiddenAdrImpr" type="hidden" runat="server">
                </td>
            </tr>
        </table>
        <asp:GridView ID="dgdAdr" runat="server" AutoGenerateColumns="false" CssClass="font_blacklink font_size12"
            Width="100%" OnRowDataBound="dgdAdr_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderStyle-Width="2%" HeaderText="刪除">
                    <HeaderTemplate>
                        <asp:CheckBox ID="CheckAll" runat="server" onclick="javascript:SelectAllCheckboxes(this)"
                            ToolTip="按一次全選，再按一次取消全選" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="cbxDelAdr" runat="server"></asp:CheckBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="3%" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnEdit" runat="server" Text="修改" CausesValidation="false" OnClick="btnEdit_Click"></asp:LinkButton>
                        <asp:LinkButton ID="SubBtn" runat="server" Text="更新" CausesValidation="false" OnClick="SubBtn_Click"
                            Visible="false"></asp:LinkButton><br />
                        <asp:LinkButton ID="CancelBtn" runat="server" Text="取消" CausesValidation="false"
                            Visible="false" OnClick="CancelBtn_Click"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="adr_seq" HeaderText="序號" />
                <asp:BoundField DataField="adr_addate" HeaderText="播出日期" />
                <asp:TemplateField HeaderText="廣告標語">
                    <ItemTemplate>
                        <asp:Label ID="lblEAlttext" runat="server" Text='<%# Bind("adr_alttext") %>'></asp:Label>
                        <asp:TextBox ID="tbxalttext" runat="server" Text='<%# Bind("adr_alttext") %>' MaxLength="30"
                            Width="60px" Visible="false"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="廣告頁面">
                    <ItemTemplate>
                        <asp:Label ID="lblEAdCate" runat="server" Text='<%# Bind("adr_adcate") %>'></asp:Label>
                        <asp:DropDownList ID="ddlEAdCate" runat="server" Visible="false" Font-Size="Smaller" Width="50px">
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="廣告位置">
                    <ItemTemplate>
                        <asp:Label ID="lblEKeyword" runat="server" Text='<%# Bind("adr_keyword") %>'></asp:Label>
                        <asp:DropDownList ID="ddlEKeyword" runat="server" Visible="false" Font-Size="Smaller"
                            Width="50px">
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="廣告連結" HeaderStyle-Width="20%">
                    <ItemTemplate>
                        <asp:Label ID="lblEnavurl" runat="server" Text='<%# Bind("adr_navurl") %>'></asp:Label>
                        <asp:TextBox ID="tbxnavurl" runat="server" Text='<%# Bind("adr_navurl") %>' MaxLength="255"
                            Width="250px" Visible="false"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="播放機率">
                    <ItemTemplate>
                        <asp:Label ID="lblEimpr" runat="server" Text='<%# Bind("adr_impr") %>'></asp:Label>
                        <asp:TextBox ID="tbximpr" runat="server" Text='<%# Bind("adr_impr") %>' Width="15px"
                            MaxLength="3" Visible="false"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="廣告價格">
                    <ItemTemplate>
                        <asp:Label ID="lblEadamt" runat="server" Text='<%# Bind("adr_adamt") %>'></asp:Label>
                        <asp:TextBox ID="tbxadamt" runat="server" Text='<%# Bind("adr_adamt") %>' Width="30px"
                            MaxLength="6" Visible="false"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="設計價格">
                    <ItemTemplate>
                        <asp:Label ID="lblEdesamt" runat="server" Text='<%# Bind("adr_desamt") %>'></asp:Label>
                        <asp:TextBox ID="tbxdesamt" runat="server" Text='<%# Bind("adr_desamt") %>' Width="30px"
                            MaxLength="6" Visible="false"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="換稿費用">
                    <ItemTemplate>
                        <asp:Label ID="lblEchgamt" runat="server" Text='<%# Bind("adr_chgamt") %>'></asp:Label>
                        <asp:TextBox ID="tbxchgamt" runat="server" Text='<%# Bind("adr_chgamt") %>' Width="30px"
                            MaxLength="6" Visible="false"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="落版金額">
                    <ItemTemplate>
                        <asp:Label ID="adr_invamt" runat="server" Text='<%# Bind("adr_invamt") %>'></asp:Label>
                        <asp:Label ID="adr_invamtNew" runat="server" Text='<%# Bind("adr_invamt") %>' Visible="false"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="發票廠商">
                    <ItemTemplate>
                        <asp:Label ID="lblInvMfr" runat="server" Text='<%# Bind("adr_imseq") %>'></asp:Label>
                        <asp:DropDownList ID="ddlEInvMfr" runat="server" Visible="false">
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="備註">
                    <ItemTemplate>
                        <asp:Label ID="lblEremark" runat="server" Text='<%# Bind("adr_remark") %>'></asp:Label>
                        <asp:TextBox ID="tbxremark" runat="server" Text='<%# Bind("adr_remark") %>' Width="50px"
                            MaxLength="50" Visible="false"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="adr_adcate" HeaderText="adr_adcate" />
                <asp:BoundField DataField="adr_keyword" HeaderText="adr_keyword" />
                <asp:BoundField DataField="adr_imseq" HeaderText="adr_imseq" />
                <asp:BoundField DataField="adr_fginved" HeaderText="發票註記" />
                <asp:BoundField DataField="" HeaderText="發票註記" />
            </Columns>
            <EmptyDataRowStyle HorizontalAlign="Center" />
            <EmptyDataTemplate>
                查詢無結果
            </EmptyDataTemplate>
        </asp:GridView>
    </span>
</asp:Content>
