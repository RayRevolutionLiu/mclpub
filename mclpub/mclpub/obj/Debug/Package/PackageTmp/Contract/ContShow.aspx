<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContShow.aspx.cs" Inherits="mclpub.Contract.ContShow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>材料所出版品客戶管理系統</title>
    <script language="javascript">
        function doSelectMfr(win_width, win_height, URL) {
            var iTop = (window.screen.availHeight - 30 - win_height) / 2;  //視窗的垂直位置;
            var iLeft = (window.screen.availWidth - 10 - win_width) / 2;   //視窗的水平位置;
            var features = "width=" + win_width + ",height=" + win_height + ",top=" + iTop + ",left=" + iLeft + ",location=no,status=no";
            var vReturn = window.open(URL, "Poping", features);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <span class="stripeMe">
        <table id="tblX" cellspacing="0" cellpadding="0" width="100%" border="0" class="font_blacklink font_size13">
         <tr>
            <th>
                廠商及客戶資料
            </th>
         </tr>
         <tr>
                            <td>
                                <!--廠商及客戶資料 -->
                                <table cellspacing="0" cellpadding="2" width="100%" border="0">
                                    <tr>
                                        <td align="right" width="25%">
                                            公司名稱(統編)：
                                        </td>
                                        <td width="30%">
                                            <asp:Label ID="lblMfrNm" runat="server">公司名稱</asp:Label>(
                                            <asp:Label ID="lblMfrNo" runat="server">00000000</asp:Label>&nbsp; )
                                        </td>
                                        <td align="right" width="15%">
                                            詳細資料：
                                        </td>
                                        <td width="30%">
                                            <img onclick="doSelectMfr('450','300','mfr_detail.aspx?mfrno=<% Response.Write(lblMfrNo.Text); %>');"
                                                alt="廠商詳細資料" src="<%=ResolveUrl("~/Art/images/btn_search.gif")%>" name="imgMfrDetail">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            公司負責人姓名(職稱)：
                                        </td>
                                        <td>
                                            <asp:Label ID="lblRespData" runat="server">負責人(職稱)</asp:Label>
                                        </td>
                                        <td align="right">
                                            公司電話(傳真)：
                                        </td>
                                        <td>
                                            <asp:Label ID="lblMfrTelFax" runat="server">00-00000000(Fax: 00-00000000)</asp:Label>
                                        </td>
                                        <tr>
                                            <td align="right">
                                                客戶姓名(編號)：
                                            </td>
                                            <td>
                                                <asp:Label ID="lblCustNm" runat="server">客戶姓名</asp:Label>(
                                                <asp:Label ID="lblCustNo" runat="server">000000</asp:Label>&nbsp; )
                                            </td>
                                            <td align="right">
                                                詳細資料：
                                            </td>
                                            <td>
                                                <img onclick="doSelectMfr('450','450','cust_detail.aspx?custno=<% Response.Write(lblCustNo.Text); %>');"
                                                    alt="客戶詳細資料" src="<%=ResolveUrl("~/Art/images/btn_search.gif")%>" border="0"
                                                    name="imgCustDetail">
                                            </td>
                                        </tr>
                                </table>
                            </td>
                        </tr>
         <tr>
                            <th>
                                合約書基本資料
                            </th>
                        </tr>
         <tr>
                            <td>
                                <!--合約書基本資料-->
                                <table cellspacing="0" cellpadding="2" width="100%" border="0">
                                    <tr>
                                        <td align="right" width="25%">
                                            簽約日期：
                                        </td>
                                        <td width="30%">
                                            <asp:Label ID="lblSignDate" runat="server" ></asp:Label>
                                        </td>
                                        <td align="right" width="15%">
                                            合約編號：
                                        </td>
                                        <td width="30%">
                                            <asp:Label ID="lblContNo" runat="server">000000</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            合約類別：
                                        </td>
                                        <td>
                                            <asp:Label ID="lblContTp" runat="server" ></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            合約起迄日：
                                        </td>
                                        <td>
                                            <asp:Label ID="lblSDate" runat="server" ></asp:Label>&nbsp;～
                                            <asp:Label ID="lblEDate" runat="server" ></asp:Label><asp:Label
                                                ID="lblDayCount" runat="server"></asp:Label>
                                        </td>
                                        <td align="right">
                                            承辦業務員：
                                        </td>
                                        <td>
                                            <asp:Label ID="lblEmpDate" runat="server" ></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            一次付清註記：
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPayOnce" runat="server" ></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            合約備註：
                                        </td>
                                        <td colspan="3">
                                            <asp:Label ID="lblRemark" runat="server" ></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
         <tr>
                            <th>
                                合約書細節
                            </th>
                        </tr>
         <tr>
                            <td>
                                <!--合約書細節-->
                                <table cellspacing="0" cellpadding="2" width="100%" border="0">
                                    <tr>
                                        <td align="right" width="25%">
                                            刊登次數：
                                        </td>
                                        <td width="30%">
                                            <asp:Label ID="lblPubTm" runat="server" ></asp:Label><asp:Label
                                                ID="lblUnPubTm" runat="server" Visible="False"></asp:Label>
                                        </td>
                                        <td align="right" width="15%">
                                            合約總金額：
                                        </td>
                                        <td width="30%">
                                            <asp:Label ID="lblTotAmt" runat="server" ></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            贈送次數：
                                        </td>
                                        <td>
                                            <asp:Label ID="lblFreeTm" runat="server" ></asp:Label>
                                        </td>
                                        <td align="right">
                                            優惠折數：
                                        </td>
                                        <td>
                                            <asp:Label ID="lblDisc" runat="server" ></asp:Label>(例: 0.8表示八折)
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            總製圖檔稿次數：
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotImgTm" runat="server" ></asp:Label><asp:Label
                                                ID="lblUnImgTm" runat="server" Visible="False"></asp:Label>
                                        </td>
                                        <td align="right">
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            總製網頁稿次數：
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTotUrlTm" runat="server" ></asp:Label><asp:Label
                                                ID="lblUnUrlTm" runat="server" Visible="False"></asp:Label>
                                        </td>
                                        <td align="right">
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
         <tr>
                            <th>
                                廣告聯絡人資料
                            </td>
                        </tr>
         <tr>
                            <td>
                                <!--廣告聯絡人資料-->
                                <table cellspacing="0" cellpadding="2" width="100%" border="0">
                                    <tr>
                                        <td align="right" width="25%">
                                            廣告聯絡人姓名：
                                        </td>
                                        <td width="30%">
                                            <asp:Label ID="lblAuNm" runat="server" ></asp:Label>
                                        </td>
                                        <td align="right" width="15%">
                                            &nbsp;
                                        </td>
                                        <td width="30%">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            電話：
                                        </td>
                                        <td>
                                            <asp:Label ID="lblAuTel" runat="server" ></asp:Label>
                                        </td>
                                        <td align="right">
                                            傳真：
                                        </td>
                                        <td>
                                            <asp:Label ID="lblAuFax" runat="server" ></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            手機：
                                        </td>
                                        <td>
                                            <asp:Label ID="lblAuCell" runat="server" ></asp:Label>
                                        </td>
                                        <td align="right">
                                            Email：
                                        </td>
                                        <td>
                                            <asp:Label ID="lblAuEmail" runat="server" ></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
         <tr>
                            <td align="center">
                                <input onclick="javascript:window.close();" type="button" value="關閉" name="btnClose"
                                    class="btn_mouseout" onmouseover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'">
                            </td>
                        </tr>
        </table>
    </span>
    </form>
</body>
</html>
