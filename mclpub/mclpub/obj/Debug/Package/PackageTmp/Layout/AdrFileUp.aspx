<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdrFileUp.aspx.cs" Inherits="mclpub.Layout.AdrFileUp" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .UrlClass
        {
            word-break:break-all;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;落版管理 / 網路廣告落版處理 / 美編上稿</span>
    <span class="stripeMe font_size13">
    <table id="Table1" cellspacing="0" cellpadding="2" width="100%" border="0">
        <tr>
            <th colspan="11">
                合約基本資料
            </th>
        </tr>
        <tr>
            <td>
                <table class="TableColor" id="Table14" cellspacing="0" cellpadding="2" width="100%"
                    border="1">
                    <tr>
                        <td>
                            合約編號
                        </td>
                        <td>
                            合約類別
                        </td>
                        <td>
                            簽約日期
                        </td>
                        <td>
                            合約起迄
                        </td>
                        <td>
                            刊登次數
                        </td>
                        <td>
                            贈送次數
                        </td>
                        <td>
                            合約金額
                        </td>
                        <td>
                            優惠折數
                        </td>
                        <td>
                            總製圖檔稿次數
                        </td>
                        <td>
                            總製網頁稿次數
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color:#ecebff" >
                            <asp:Label ID="lblContNo" runat="server" CssClass="NormalLabel"></asp:Label>
                        </td>
                        <td style="background-color: #ecebff">
                            <asp:Label ID="lblContTp" runat="server" CssClass="NormalLabel"></asp:Label>
                        </td>
                        <td style="background-color: #ecebff">
                            <asp:Label ID="lblSignDate" runat="server" CssClass="NormalLabel"></asp:Label>
                        </td>
                        <td style="background-color: #ecebff">
                            <asp:Label ID="lblSDate" runat="server" CssClass="NormalLabel"></asp:Label>～<asp:Label
                                ID="lblEDate" runat="server" CssClass="NormalLabel"></asp:Label>
                        </td>
                        <td style="background-color: #ecebff">
                            <asp:Label ID="lblPubTm" runat="server" CssClass="NormalLabel"></asp:Label>
                        </td>
                        <td style="background-color: #ecebff">
                            <asp:Label ID="lblFreeTm" runat="server" CssClass="NormalLabel"></asp:Label>
                        </td>
                        <td style="background-color: #ecebff">
                            <asp:Label ID="lblTotAmt" runat="server" CssClass="NormalLabel"></asp:Label>
                        </td>
                        <td style="background-color: #ecebff">
                            <asp:Label ID="lblDisc" runat="server" CssClass="NormalLabel"></asp:Label>
                        </td>
                        <td style="background-color: #ecebff">
                            <asp:Label ID="lblTotImgTm" runat="server" CssClass="NormalLabel"></asp:Label>
                        </td>
                        <td style="background-color: #ecebff">
                            <asp:Label ID="lblTotUrlTm" runat="server" CssClass="NormalLabel"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <br />
    <table id="Table2" cellspacing="0" cellpadding="2" width="100%" border="0">
        <tr>
            <th colspan="2">
                美編上稿
            </th>
        </tr>
        <tr>
            <td width="60%">
                <table class="TableColor" id="Table31" cellspacing="0" cellpadding="2" width="100%"
                    border="0">
                    <tr>
                        <td colspan="2">
                            <input id="DialogAddBtnUpload" type="button" value="現有廣告圖檔" class="btn_mouseout"
                                onmouseover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'" />
                            <input id="DialogAddBtn" type="button" value="上傳廣告圖檔" class="btn_mouseout" onmouseover="this.className='btn_mouseover'"
                                onmouseout="this.className='btn_mouseout'" />
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                    </tr>
                    <tr>
                        <td align="right" width="150px">
                            <asp:CheckBox ID="cbxImage" runat="server" Text="圖檔："></asp:CheckBox>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlImages" runat="server">
                            </asp:DropDownList>
                            <asp:Button ID="btnRefresh" runat="server" Text="更新圖檔資料" 
                                onclick="btnRefresh_Click"></asp:Button>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:CheckBox ID="cbxLink" runat="server" Text="網頁連結："></asp:CheckBox>
                        </td>
                        <td>
                            <asp:TextBox ID="tbxNavUrl" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:CheckBox ID="cbxAltText" runat="server" Text="廣告標語："></asp:CheckBox>
                        </td>
                        <td>
                            <asp:TextBox ID="tbxAltText" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblType1" runat="server">上稿方式 1：</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="tbxSDate" runat="server" Width="100px" CssClass="UniqueDate"></asp:TextBox>～
                            <asp:TextBox ID="tbxEDate" runat="server" Width="100px" CssClass="UniqueDate"></asp:TextBox>&nbsp;<asp:Button 
                                ID="btnDateSetImage" runat="server" Text="日期區間上稿" 
                                onclick="btnDateSetImage_Click" CausesValidation="false"></asp:Button>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label1" runat="server">上稿方式 2：</asp:Label>
                        </td>
                        <td>
                            <asp:Button ID="btnSetImage" runat="server" Text="勾選項目上稿" 
                                CausesValidation="false" onclick="btnSetImage_Click"></asp:Button>
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                <asp:Label ID="lblInfo" runat="server" ForeColor="#C00000"> 使用說明：<br>1.利用【現有廣告圖檔】先查詢所需圖檔是否已存在<br>
									2.如為新圖檔, 請利用【上傳廣告圖檔】將圖檔上傳<br>
									3.利用【更新圖檔資料】將上傳圖檔載入下拉式選單中<br>
									4.選擇圖檔及輸入網頁連結資料<br>
									5.利用【日期區間上稿】方式可一次將此區間的所有資料上稿<br>
									6.利用【勾選項目上稿】方式可隨意挑選欲上稿的日期 </asp:Label>
            </td>
        </tr>
    </table>
    <br />
       <table id="Table3" cellspacing="0" cellpadding="2" width="100%" border="0">
            <tr>
                <th>
                    廣告落版資料
                </th>
            </tr>
        </table>
       <asp:GridView ID="dgdAdr" runat="server" AutoGenerateColumns="False" CssClass="font_blacklink font_size12"
                        Width="100%" OnRowDataBound="dgdAdr_RowDataBound" 
        EnableModelValidation="True">
                        <Columns>
                            <asp:TemplateField HeaderStyle-Width="2%" HeaderText="刪除">
                                <HeaderTemplate>
                                    <asp:CheckBox ID="CheckAll" runat="server" onclick="javascript:SelectAllCheckboxes(this)"
                                        ToolTip="按一次全選，再按一次取消全選" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbxDelAdr" runat="server"></asp:CheckBox>
                                </ItemTemplate>

<HeaderStyle Width="2%"></HeaderStyle>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="3%">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnEdit" runat="server" Text="修改" CausesValidation="false" OnClick="btnEdit_Click"></asp:LinkButton>
                                    <asp:LinkButton ID="SubBtn" runat="server" Text="更新" CausesValidation="false" OnClick="SubBtn_Click"
                                        Visible="false"></asp:LinkButton><br />
                                    <asp:LinkButton ID="CancelBtn" runat="server" Text="取消" CausesValidation="false"
                                        Visible="false" OnClick="CancelBtn_Click"></asp:LinkButton>
                                </ItemTemplate>

<HeaderStyle Width="3%"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
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
                            <asp:BoundField DataField="adr_adcate" HeaderText="廣告頁面" />
                            <asp:BoundField DataField="adr_keyword" HeaderText="廣告位置" />
                            <asp:TemplateField HeaderText="廣告連結" HeaderStyle-Width="20%">
                                <ItemTemplate>
                                    <asp:Label ID="lblEnavurl" runat="server" Text='<%# Bind("adr_navurl") %>'></asp:Label>
                                    <asp:TextBox ID="tbxnavurl" runat="server" Text='<%# Bind("adr_navurl") %>' MaxLength="255"
                                        Width="250px" Visible="false"></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Width="20%"></HeaderStyle>
                                <ItemStyle CssClass="UrlClass" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="adr_impr" HeaderText="播放機率" />              
                            <asp:TemplateField HeaderText="備註">
                                <ItemTemplate>
                                    <asp:Label ID="lblEremark" runat="server" Text='<%# Bind("adr_remark") %>'></asp:Label>
                                    <asp:TextBox ID="tbxremark" runat="server" Text='<%# Bind("adr_remark") %>' Width="40px"
                                        MaxLength="50" Visible="false"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="廣告圖檔">
                                <ItemTemplate>
                                    <asp:Label ID="lblImgUrl" runat="server" Text='<%# Bind("adr_imgurl") %>'></asp:Label>
                                    <asp:DropDownList ID="ddlImgUrl" runat="server" Visible="false">
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="圖檔稿類別">
                                <ItemTemplate>
                                    <asp:Label ID="lblDraftTp" runat="server" Text='<%# Bind("adr_drafttp") %>'></asp:Label>
                                    <asp:DropDownList ID="ddlDraftTp" runat="server" Visible="false">
                                        <asp:ListItem Value="1">舊稿</asp:ListItem>
                                        <asp:ListItem Value="2">新稿</asp:ListItem>
                                        <asp:ListItem Value="3">改稿</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="網頁稿類別">
                                <ItemTemplate>
                                    <asp:Label ID="lblUrlTp" runat="server" Text='<%# Bind("adr_urltp") %>'></asp:Label>
                                    <asp:DropDownList ID="ddlUrlTp" runat="server" Visible="false">
                                        <asp:ListItem Value="1">舊稿</asp:ListItem>
                                        <asp:ListItem Value="2">新稿</asp:ListItem>
                                        <asp:ListItem Value="3">改稿</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="adr_adcate" HeaderText="adr_adcate" />
                            <asp:BoundField DataField="adr_keyword" HeaderText="adr_keyword" />
                        </Columns>
                        <EmptyDataRowStyle HorizontalAlign="Center" />
                        <EmptyDataTemplate>
                            查詢無結果
                        </EmptyDataTemplate>
                    </asp:GridView>
        <asp:Button ID="SaveAsBtn" runat="server" onclick="SaveAsBtn_Click" />
    </span>
    <div id="dialogUpload" style="text-align: left; display: none;" title="現有廣告圖檔">
        <asp:Label ID="lblImageInfo" runat="server"></asp:Label>
        <asp:DataList ID="dlImageList" runat="server" RepeatDirection="Horizontal" RepeatColumns="3"
            OnItemDataBound="dlImageList_ItemDataBound">
            <ItemTemplate>
                <table id="Table1" cellspacing="2" cellpadding="1" border="0">
                    <tr>
                        <td>
                            <asp:Image ID="imgAdrImage" runat="server" BorderWidth="0px" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "filename") %>'>
                            </asp:Image>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblFileName" runat="server" CssClass="NormalLabel" Text='<%# DataBinder.Eval(Container.DataItem, "filename") %>'>
                            </asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
    </div>
    <div id="dialog" style="text-align: left; display: none;" title="上傳廣告圖檔">
        <asp:FileUpload ID="FileUpload1" runat="server" />
<%--        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="FileUpload1" Display="Dynamic"
             ErrorMessage="目前只允許JPG、JPEG、BMP、GIF類的圖形上傳，請重新轉換檔案格式" ValidationExpression="^([a-zA-Z].*|[1-9].*)\.(JPG|jpg|bmp|GIF|gif|JPEG|jpeg|jpg|png|PNG)$"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FileUpload1"  
             ErrorMessage="路徑不可為空白" Display="Dynamic"></asp:RequiredFieldValidator>--%>
        <input id="btnUpload" type="button" value="上傳" class="btn_mouseout" onmouseover="this.className='btn_mouseover'"
            onmouseout="this.className='btn_mouseout'" onclick="CheckUsed()" />
    </div>
    <script type="text/javascript">
        function SelectAllCheckboxes(spanChk) {
            elm = document.forms[0];
            for (i = 0; i <= elm.length - 1; i++) {
                if (elm[i].type == "checkbox" && elm[i].id != spanChk.id && elm[i].id.indexOf("<% =dgdAdr.ClientID%>") != -1) {
                    if (elm.elements[i].checked != spanChk.checked)
                        elm.elements[i].click();
                }
            }
        }

        function GetUrl() {
            var url = window.location.toString();
            var str = "";
            var str_value = "";
            if (url.indexOf("?") != -1) {
                var ary = url.split("?")[1].split("&");
                for (var i in ary) {
                    str = ary[i].split("=")[0];
                    if (str == "NewContNo") {
                        str_value = decodeURI(ary[i].split("=")[1]);
                    }
                }
            }
            return str_value;
        }

        function CheckUsed() {
            var UploadFileURL = $("#<% =FileUpload1.ClientID%>");
            if (UploadFileURL.val() == "") {
                alert("請選擇要上傳之圖檔!");
                return false;
            }

            $.post("CheckImage.aspx", { filename: UploadFileURL.val() }, function (result) {
                //alert(result);
                if (result == "No!") {
                    alert('此檔案名稱已經存在 請重新命名!');
                }
                else if (result == "Ok!") {
                    alert('新增成功!');
                    document.getElementById("<% =SaveAsBtn.ClientID%>").click();
                    //window.location.href = "AdrFileUp.aspx?NewContNo=" + GetUrl();
                }
                else if (result == "Error!") {
                    alert('資料錯誤!');
                }
                else if (result == "Image!") {
                    alert('請選擇圖檔上傳!');
                }

            });
        }
    </script>
</asp:Content>
