<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlaneCont_2.aspx.cs" Inherits="mclpub.Contract.PlaneCont_2"  MasterPageFile="~/MasterPage.Master"%>

<asp:Content id="Content1" ContentPlaceholderID="ContentPlaceHolder1" runat="server">

<span class="font_size12 font_darkblue font_bold">�ثe��m:&nbsp;�X���޲z / �����s�i�X���� �B�J�G:�D�X�ӫȤ᪺���v�X���Ѹ��</span>

<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
<tr>
	<td align="right"><asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></td>
    <td align="right">
    <asp:Button ID="AddNewCont" runat="server" Text="�s�W�ťզX����" 
            onclick="AddNewCont_Click"/>
    <asp:Button ID="BackBtn" runat="server" Text="�^�d�ߵe��" onclick="BackBtn_Click" />
    </td>
</tr>
</table>
<span class="font_size13 font_bold font_gray">
<ol>
	<li>�w���ת��X���A�N�����\ "�ק�"�A�u���˵�����(��ܦX�����v)�I</li>
	<li>��� [��ܦX�����v] �i�˵��X���Ѫ���l���, �� [�s�W/�ק�] �Y�i�i�J[�s�W/�ק�]�e��</li>
</ol>
</span>
<span class="stripeMe">
<asp:GridView ID="PCGV2" runat="server" AutoGenerateColumns="false" Width="99%" CssClass="font_blacklink font_size13" OnRowDataBound="PCGV2OnRowDataBound">
<Columns>
    <asp:BoundField DataField="cont_contno" HeaderText="�X���s��" />
    <asp:BoundField DataField="cont_conttp" HeaderText="�X�����O" />
    <asp:BoundField DataField="bk_nm" HeaderText="���y���O" />
    <asp:BoundField DataField="cont_signdate" HeaderText="ñ�����" />
    <asp:BoundField DataField="cont_sdate" HeaderText="�X���_��" />
    <asp:BoundField DataField="cont_edate" HeaderText="�X������" />
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
    <asp:TemplateField HeaderStyle-Width="5%">
    <ItemTemplate>
        <asp:Button ID="Button1" runat="server" Text="�s�W" />
    </ItemTemplate>
    </asp:TemplateField>  
</Columns>
<EmptyDataRowStyle HorizontalAlign="Center" />
<EmptyDataTemplate>
�d�ߵL���G
</EmptyDataTemplate>
</asp:GridView>
</span>
</asp:Content>


