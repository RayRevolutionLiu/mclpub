1/29/2003 updated
-----------------
*PubFm.aspx

Fix Bug:
1. �ק� sqlDataAdapter7
2. modify InitialData()  ��ܤU�Ԧ���� �½Z������ DB ��  LineNo 245~247
3. modify LoadContData() LoadContData(); ����m  LineNo 298
4. modify LoadContData() LoadBkcdProjCost(); ����m  LineNo 539
5. modify LoadBkcdProjCost() �ܧ�U�Ԧ���� �½Z����/��Z����  LineNo 626~641, 670~674
6. modify ddlIMSeq_SelectedIndexChanged()  �ܧ�U�Ԧ���� �½Z����/��Z���� LineNo 3390~3394
7. modify ddlOrigBookCode_SelectedIndexChanged()  �Y�ܧ�U�Ԧ���� �½Z����  LineNo 3400~3405
8. modify ddlChgBookCode_SelectedIndexChanged()  �Y�ܧ�U�Ԧ���� �½Z����  LineNo 3409~3413
9. �ק� sqlDataAdapter1, �ק� DataGrid1, �[�J '�|�Ҥ����O' �����

*InvMfr.aspx

Add �ˬd����



2/25/2003 updated
----------------------
�����s�i���t��  �έp��  �s�i���J�έp��

adincome_stat.aspx
1. �ק��r�r��: 2. �d�ߵ��G�]�t�w����/�w���P�����.
2. �������ˬd�]�t�w����/�w���P��
   �ק� sqlDataAdapter2

adincome_stat2.aspx
1. Disabled:
	sqlcmd1 = sqlcmd1 & " WHERE (c2_cont.cont_fgclosed = '0') "
	sqlcmd1 = sqlcmd1 & " AND (c2_cont.cont_fgcancel = '0') "
	��
	sqlcmd2 = sqlcmd2 & " WHERE (c2_cont.cont_fgclosed = '0') "
	sqlcmd2 = sqlcmd2 & " AND (c2_cont.cont_fgcancel = '0') "



3/3/2003 updated
-----------------
*adincome_stat.aspx
*adincome_stat2.aspx

���D: User ����:�z����󤣶��X�����שε��P���O
Fix Big: 
�ק� .cs �� sqlDataAdapter2 
CountPubData() ���� Where ����: 
"AND (dbo.c2_cont.cont_fgclosed = '0') AND (dbo.c2_cont.cont_fgcancel = '0')"


3/6/2003 updated
-----------------
*ContPubFm_search.aspx

Fix Big:
1. ShowPub() �[�J �M���T����r: this.literal1.Text = "";


*iaFm1_Addia.aspx

���D: User ����: �@���I�ڤ����ͮ�, �o�t����H��ƫe�ᤣ�@�P.
Fix Big:
1. 3/6/2003 �b GetContIM() �̥[�J�U�@����, �H�K��X�� im_nm �����T
   rowfilterstr1 = rowfilterstr1 + " AND im_contno = '" + strContNo + "'";



3/10/2003 updated
-----------------
*iaFm1_Recia.aspx

���D: User ����: �@���I�ڤ��o���^�_�L��!  (�t�� �M�p contno=000326)
Fix Big:
1. �ק� Itridpa DB �� sp_c2_delete_1_ia �W�٤Τ��e
   �� sp_c2_delete_ia_1
2. �ק� .cs �� btnRecia_Click()
   �ק� sqlCommand1 ~ sqlCommand3 ���ª� update �אּ Transaction �T�{��s.



3/11/2003 updated
-----------------
InvMfrForm.aspx

���D: User ��f�� ����: 
���@�X���ѳB�� "���@ �o���t�Ӧ���H" ��,
�A�x�s���\��, �o�����O���� "�T�p", �o�� "�G�p".
�B�����~�T���e��, �p���e������!

���ո��:
-----------
�t��: �����
�X���s��: 000271
�o�t����H: 01 ���ؾ�

Fix Bug:
1. �ק� DataGrid1_ItemCommand �� Line 752 ~ 821
2. �ק� DataGrid2_ItemCommand �� Line 920, 942, 964
3. �ק� ModifyDB() �� Line 1257 : ���� this.ddlIMInvtp.ClearSelection();



3/14/2003 updated
-----------------
���D: User �d�R�� �^��: C2���P�ε��׿z�� (�� Email)

Fix Bug:
1. �w�ץ��H�U�{��(�����w���פΤw���P�X�����z�����), ���˵�:
	2.1.4 �����s�i���t�� �X���B�z �s�i�O���ˬd�M�� 
	2.3.1 �����s�i���t�� �����B�z �s�i�ƪ��ʧ@ 
	2.3.2 �����s�i���t�� �����B�z ���s�˫�ץ� 
	2.3.3 �����s�i���t�� �����B�z �s�i������
	*2.3.4 �����s�i���t�� �����B�z �s�i�����M�� 
	2.3.5 �����s�i���t�� �����B�z �s�i�s�Z�έp�� 
	
	�����@: * ��ܱz����S���έn���ץ�, �ѧڴ��ζ��w�ץ�!
	�����G: 2.9.1 �s�i���J�έp�� --- �w�� 2/26 ���ۦP���ץ��F.

2. �ק� 2.9.1 �s�i���J�έp�� �e���z����󤧻�����r.
3. �ק� 2.2 �ʽZ�� ���Y��m��������r: �s�i�B�z => �ʽZ�B�z
4. �ק� �Ҧ�����{�����s��: �� localhost ��g���� http://isccom2/mrlpub/...
	�ק�21�ӵ{��
	2.1.3 �X���B�z �X���ѲM��  cont_list.aspx
	2.1.4 �X���B�z �s�i�O���ˬd�M��  adamt_list.aspx
	2.1.5 �X���B�z  �����s�i���� ���Z�n  PubFm_label_search.aspx
	      �X���B�z  �����s�i���� ��를�Z�n  PubFm_label_search2.aspx
	2.1.6 �X���B�z �s�i�O���ˬd�M��  adamt_list.aspx
	2.2   �ʽZ�B�z  �ʽZ��  getad.aspx
	      * �o�{ bug: exec sp_c2_getad_1 '0', '01'
	                  Server: Msg 536, Level 16, State 3, Procedure sp_c2_getad_2, Line 32
			  Invalid length parameter passed to the substring function.
	2.3.3 �����B�z  �s�i������  adpub_form.aspx
	2.3.4 �����B�z  �s�i�����M��  adpub_list.aspx
	2.3.5 �����B�z  �s�i�s�Z�έp��  admade_stat.aspx
	2.4.2.1 �o���B�z  �o���}�߳��ˮ֪� - �@���I��  iaFm1_Chklist_query.aspx
	2.4.2.2 �o���B�z  �o���}�߳��ˮ֪� - �@���I��  iaFm1_Chklist2.aspx
	2.4.2.3 �o���B�z  �o���}�߳��ˮ֪� - �j��뵲  iaFm2_Chklist_ia.aspx
	2.6.3 �ʮѳB�z  �ʮѲM��  lostbk_list.aspx
	2.6.4 �ʮѳB�z  �ʮѼ���  lostbk_label_filter.aspx  Data?
	2.8.1 ���s��B�z  �s�i���s��M��  adprom_list.aspx
	2.8.2 ���s��B�z  �s�i���s��M��  adprom_list.aspx
	2.8.3 ���s��B�z  �s�i���s�����  adprom_label.aspx  
	


3/19/2003 updated
-----------------
���D: User �d�R�y ���� �ʽZ��̪��w�T�w�Z�n�����������Ʀ��~.

Fix Bug:
1. �ק� sp_c2_getad_2 Line 32 @i_len �B, �[ if �P�_��



4/9/2003 updated
-----------------
���D: User ���f�S ���� �L�k�s�W�X����.

Fix Bug:
1. �ק� ContFm_Add.aspx  Line 813~869 -- �[�J�ˬd strSignDate, strStartDate, strEndDate



6/6/2003 updated
-----------------
���D: User �d�R�y ���� 
Fix Bug:
1. �ק� iaFm2_list2.aspx  Line 161, 221 -- ���� (Where...) AND (dbo.c2_cont.cont_fgclosed = '0') ����



6/11/2003 updated
-----------------
���D: User ��f�� ���� �E�w & �F�t���q�b�s�W�X���Ѧ��\��, �L�k�}�ҦX����/�����e��.
	=> �o�{��Ʈw�G�X������u�� 2003, �ëD 200307
Fix Bug:
1. �ק� cont_main2.aspx.cs  Line 103-171 Page_Load() -- �[�J�ˬd������榡
2. �ק� cont_new2.aspx.cs  Line 103-171 Page_Load() -- �[�J�ˬd������榡
3. �ק� ContFm_modify.aspx.cs  Line 386~456 LoadOldCont() -- �[�J�ˬd������榡
4. �ק� pub_new1.aspx.cs  Line 134~174 ShowPub() --  �[�J�ˬd������榡
5. �ק� PubFm.aspx.cs  Line 407~463 LoadContData() -- �[�J�ˬd������榡
6. �ק� ContFm_closedshow.aspx.cs  Line 128~171 ShowCont() -- �[�J�ˬd������榡
7. �ק� ContFm_show.aspx.cs  Line 389~431 LoadOldCont() -- �[�J�ˬd������榡
8. �ק� ContPubFm_show.aspx.cs  Line 401~443 LoadOldCont() -- �[�J�ˬd������榡
9. �ק� ContPubFm_search.aspx.cs  Line 137~180 ShowPub() -- �[�J�ˬd������榡
10. �ק� ContFm_cancelshow.aspx.cs  Line 131~174 ShowCont() -- �[�J�ˬd������榡
11. �ק� ContFm_cancel.aspx.cs  Line 149~193 ShowCont() -- �[�J�ˬd������榡
12. �ק� ContFm_chkl.aspx.cs  Line 130~200 BindGrid1() -- �[�J�ˬd������榡
13. �ק� ContFm_modify.aspx  Line 245~246 ShowCont() -- �[�J�ˬd������榡 revSDate, revEDate
14. �ק� ContFm_Add.aspx  Line 248~249 ShowCont() -- �[�J�ˬd������榡 revSDate, revEDate



6/24/2003 updated
-----------------
���D: User �d�R�y ���� �s�i�ƪ��ʧ@ �B�J�G (adpub_act2.aspx), ���U "���ƭ���" ���s��.
��s�����W�L100��, �S���Ʀb 99����, �ӱƦb9����; �ѨM: SrcPageNo & DesPageNo �[ parseInt()

Fix Bug:
1. �ק� adpub_act2.aspx  Line 1054, 1059, 1034~1038



//2003 updated
-----------------




//2003 updated
-----------------

