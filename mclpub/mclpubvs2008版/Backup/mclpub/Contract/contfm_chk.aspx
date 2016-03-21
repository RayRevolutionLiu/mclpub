<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="contfm_chk.aspx.cs" Inherits="mclpub.Contract.contfm_chk"  MasterPageFile="~/MasterPage.Master" MaintainScrollPositionOnPostback="true"%>
<%@ Register Src="../UserControl/Pager.ascx" TagName="UCPager" TagPrefix="uc3" %>

<asp:Content id="Content1" ContentPlaceholderID="ContentPlaceHolder1" runat="server">
<span class="font_size12 font_darkblue font_bold">�ثe��m:&nbsp;�X���޲z / �����s�i�X���� / �X���ѿ��~��ƲM��</span>
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">�d�߱���</th>
  </tr>
  <tr>
    <td align="right" width="30%" class="font_bold">
        <asp:Label ID="lblSignDate" runat="server">�п�ܱz�n�d�ߪ����ءG</asp:Label>
      </td>
    <td>
        <asp:DropDownList ID="ddlFilter" runat="server">
            <asp:ListItem Value="1">�m�M�¦��ƬҬ���</asp:ListItem>
            <asp:ListItem Value="2">�ӿ�~�ȭ���Ƥ�����</asp:ListItem>
        </asp:DropDownList>
      </td>
  </tr>
  <tr>
    <td align="right" colspan="2">
        <asp:Button ID="btnQuery" runat="server" Text="�d��" onclick="btnQuery_Click" />
        <asp:Button id="btnClearAll" runat="server" Text="�M�����d" 
            onclick="btnClearAll_Click"></asp:Button>
        </td>
  </tr>
</table>
</span>

<span class="font_size13 font_bold font_gray">
<ol>
	<li>�п�ܬd�ߪ����صM����U�d��</li>
    <li>�d�߸�Ƶ��G��,���U<span class="font_darkblue">�u�T�w�ק�v</span>�i�ק�ӦX�������</li>
    <li>�d�X��ƫ�,���U<span class="font_darkblue">�u��ܦX�����v�v</span>�i�d�ݦX�����v����</li>
</ol>
</span>
<br />
<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
<tr>
	<td class="font_size18 font_bold"><img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />�j�M���G</td>
    <td align="right"></td>
</tr>
</table>

<span class="stripeMe">
    <asp:GridView ID="GridView1" runat="server" Width="99%" AutoGenerateColumns="false" OnRowDataBound="GridView1OnRowDataBound" CssClass="font_blacklink font_size13" AllowPaging="true" PagerSettings-Visible="false"
     AllowSorting="true" OnSorting="GVEdit_Sorting">
    <Columns>
    <asp:BoundField DataField="cont_contno" HeaderText="�X���s��" />
    <asp:BoundField DataField="cont_conttp" HeaderText="�X�����O" />
    <asp:BoundField DataField="bk_nm" HeaderText="���y���O" />
    <asp:BoundField DataField="cont_sdate" HeaderText="�X���_��" />
    <asp:BoundField DataField="cont_edate" HeaderText="�X������" />
    <asp:BoundField DataField="cont_signdate" HeaderText="ñ�����" SortExpression="cont_signdate" />
    <asp:BoundField DataField="mfr_inm" HeaderText="���q�W��" />
    <asp:BoundField DataField="cont_aunm" HeaderText="�s�i�p���H�m�W" />
    <asp:BoundField DataField="cont_autel" HeaderText="�s�i�p���H�q��" />
    <asp:BoundField DataField="cont_fgpayonce" HeaderText="�@���I�M" />
    <asp:BoundField DataField="cont_fgclosed" HeaderText="�w����" />
    <asp:BoundField DataField="cont_disc" HeaderText="�u�f���" />
    <asp:BoundField DataField="cont_clrtm" HeaderText="�m�⦸��" />
    <asp:BoundField DataField="cont_getclrtm" HeaderText="�M�⦸��" />
    <asp:BoundField DataField="cont_menotm" HeaderText="�¥զ���" />
    <asp:BoundField DataField="cont_fgpubed" HeaderText="�w����" />
    <asp:BoundField DataField="cont_fgcancel" HeaderText="�w���P" />
    <asp:BoundField DataField="srspn_cname" HeaderText="�~�ȭ�" />
    <asp:TemplateField HeaderStyle-Width="5%">
    <ItemTemplate>
        <asp:HyperLink ID="HyperLink1" runat="server">��ܦX�����v</asp:HyperLink>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderStyle-Width="5%">
    <ItemTemplate>
        <asp:Button ID="Button2" runat="server" Text="�ק�" />
    </ItemTemplate>
    </asp:TemplateField>
    <asp:BoundField DataField="cont_custno" HeaderText="�Ȥ�s��" />
    </Columns>
    <EmptyDataRowStyle HorizontalAlign="Center" />
    <EmptyDataTemplate>
    �d�ߵL���G
    </EmptyDataTemplate>
    </asp:GridView>
</span>
<div class="pager font_size13">
 <uc3:ucpager id="UCPager1" runat="server" />  
 </div> 
</asp:Content>
