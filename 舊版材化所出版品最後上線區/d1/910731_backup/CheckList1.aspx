<%@ Page language="c#" Codebehind="CheckList1.aspx.cs" src="CheckList1.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.CheckList1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�i���Ʃ� �X���~�Ȥ�޲z�t�Ρj �q���ˮ֪�</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="CheckList1" method="post" runat="server">
			<FONT color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
				���x�O�ѭq�\���t�� <IMG height="10" src="images/header/right02.gif" width="10" border="0">
				�q��B�z <IMG height="10" src="images/header/right02.gif" width="10" border="0">�q���ˮ֪�
			</FONT>
			<br>
			<asp:label id="Label1" runat="server">�q��n������϶��G</asp:label>
			<asp:textbox id="tbxDate1" runat="server" Width="82px"></asp:textbox>
			<IMG class="ico" title="���" onclick="pick_date(tbxDate1.name)" src="../images/calendar01.gif">
			��<asp:textbox id="tbxDate2" runat="server" Width="84px"></asp:textbox><IMG class="ico" title="���" onclick="pick_date(tbxDate2.name)" src="../images/calendar01.gif">
			<asp:Button id="Button1" runat="server" Text="�d��"></asp:Button>
			<INPUT onclick="doClose()" type="button" value="�^����">
			<br>
			<asp:datagrid id="DataGrid1" runat="server" BorderStyle="None" BorderWidth="1px" BorderColor="#3366CC" BackColor="White" CellPadding="1" AutoGenerateColumns="False" Font-Size="8pt" Font-Names="�s�ө���">
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
				<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
				<SelectedItemStyle ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="Lavender"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<Columns>
					<asp:BoundColumn DataField="nostr" HeaderText="�q��s��"></asp:BoundColumn>
					<asp:BoundColumn DataField="o_mfrno" HeaderText="�Τ@�s��"></asp:BoundColumn>
					<asp:BoundColumn DataField="o_inm" HeaderText="�o������H"></asp:BoundColumn>
					<asp:BoundColumn DataField="o_ijbti" HeaderText="�ٿ�"></asp:BoundColumn>
					<asp:BoundColumn DataField="o_iaddr" HeaderText="�o���l�H�a�}">
						<HeaderStyle Wrap="False">
						</HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="o_izip" HeaderText="�l���ϸ�"></asp:BoundColumn>
					<asp:BoundColumn DataField="o_itel" HeaderText="�q��"></asp:BoundColumn>
					<asp:BoundColumn DataField="o_ifax" HeaderText="�ǯu"></asp:BoundColumn>
					<asp:BoundColumn DataField="o_icell" HeaderText="���"></asp:BoundColumn>
					<asp:BoundColumn DataField="o_iemail" HeaderText="Email"></asp:BoundColumn>
					<asp:BoundColumn DataField="o_date" HeaderText="�q�ʤ��"></asp:BoundColumn>
					<asp:BoundColumn DataField="o_empno" HeaderText="�ӿ�H��"></asp:BoundColumn>
					<asp:BoundColumn DataField="o_invcd" HeaderText="�o�����O"></asp:BoundColumn>
					<asp:BoundColumn DataField="o_taxtp" HeaderText="�ҵ|�O"></asp:BoundColumn>
					<asp:BoundColumn DataField="od_oditem" HeaderText="���Ӷ���"></asp:BoundColumn>
					<asp:BoundColumn DataField="od_sdate" HeaderText="�q�\�_��"></asp:BoundColumn>
					<asp:BoundColumn DataField="od_edate" HeaderText="�q�\����"></asp:BoundColumn>
					<asp:BoundColumn DataField="obtp_obtpnm" HeaderText="���y�W��"></asp:BoundColumn>
					<asp:BoundColumn DataField="od_projno" HeaderText="�p���N��"></asp:BoundColumn>
					<asp:BoundColumn DataField="od_remark" HeaderText="�Ƶ�"></asp:BoundColumn>
					<asp:BoundColumn DataField="od_amt" HeaderText="���B"></asp:BoundColumn>
					<asp:BoundColumn DataField="od_custtp" HeaderText="�s��q��"></asp:BoundColumn>
					<asp:BoundColumn DataField="ra_mnt" HeaderText="�ƶq"></asp:BoundColumn>
					<asp:BoundColumn DataField="mtp_nm" HeaderText="�l�H���O">
						<HeaderStyle Wrap="False">
						</HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="ra_oritem" HeaderText="�Ǹ�"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_inm" HeaderText="���q�W��">
						<HeaderStyle Wrap="False">
						</HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="or_nm" HeaderText="���x����H"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_jbti" HeaderText="�ٿ�"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_addr" HeaderText="���x�l�H�a�}">
						<HeaderStyle Wrap="False">
						</HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="or_zip" HeaderText="�l���ϸ�"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_tel" HeaderText="�q��"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_fax" HeaderText="�ǯu"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_cell" HeaderText="���"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_email" HeaderText="Email"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
			<asp:Label id="Label3" runat="server" ForeColor="#C04000" Font-Size="X-Small">����1�G<br>���ˮ֪�C�ܤ��q��O�|�����͵o���}�߳椧���, <br>�w���͵o���}�߳椧�q���Ƥ��|�b���C��</asp:Label>
			<br>
			<asp:Label id="Label2" runat="server" ForeColor="#C04000" Font-Size="X-Small">����2�G<br>�o�����O---2:�G�p  3:�T�p  4:��L<br>�ҵ|�O---1:���|  2:�s�|  3:�K�|<br>�s��q��---0:�s�q��  1:��q��</asp:Label>
		</form>
		<script language="javascript">
function pick_date(theField){
	var oParam = new Object();
	strFeature = "";
	strFeature += "dialogHeight:250px;dialogWidth:200px;center:yes;scroll:yes;status:no;help:no;";
	var vreturn = window.showModalDialog("calendar.asp", oParam, strFeature); 
	if(vreturn)
		window.document.all(theField).value=vreturn;
	return true;
}
function doClose()
{
	window.close();
}
	</script>
	</body>
</HTML>
