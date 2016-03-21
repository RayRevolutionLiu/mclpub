1/29/2003 updated
-----------------
*PubFm.aspx

Fix Bug:
1. 修改 sqlDataAdapter7
2. modify InitialData()  顯示下拉式選單 舊稿書類的 DB 值  LineNo 245~247
3. modify LoadContData() LoadContData(); 的位置  LineNo 298
4. modify LoadContData() LoadBkcdProjCost(); 的位置  LineNo 539
5. modify LoadBkcdProjCost() 變更下拉式選單 舊稿書類/改稿書類  LineNo 626~641, 670~674
6. modify ddlIMSeq_SelectedIndexChanged()  變更下拉式選單 舊稿書類/改稿書類 LineNo 3390~3394
7. modify ddlOrigBookCode_SelectedIndexChanged()  若變更下拉式選單 舊稿書類  LineNo 3400~3405
8. modify ddlChgBookCode_SelectedIndexChanged()  若變更下拉式選單 舊稿書類  LineNo 3409~3413
9. 修改 sqlDataAdapter1, 修改 DataGrid1, 加入 '院所內註記' 之顯示

*InvMfr.aspx

Add 檢查機制



2/25/2003 updated
----------------------
平面廣告次系統  統計表  廣告收入統計表

adincome_stat.aspx
1. 修改文字字眼: 2. 查詢結果包含已結案/已註銷的資料.
2. 移除”檢查包含已結案/已註銷”
   修改 sqlDataAdapter2

adincome_stat2.aspx
1. Disabled:
	sqlcmd1 = sqlcmd1 & " WHERE (c2_cont.cont_fgclosed = '0') "
	sqlcmd1 = sqlcmd1 & " AND (c2_cont.cont_fgcancel = '0') "
	及
	sqlcmd2 = sqlcmd2 & " WHERE (c2_cont.cont_fgclosed = '0') "
	sqlcmd2 = sqlcmd2 & " AND (c2_cont.cont_fgcancel = '0') "



3/3/2003 updated
-----------------
*adincome_stat.aspx
*adincome_stat2.aspx

問題: User 反應:篩選條件不須合約結案或註銷註記
Fix Big: 
修改 .cs 之 sqlDataAdapter2 
CountPubData() 移除 Where 條件: 
"AND (dbo.c2_cont.cont_fgclosed = '0') AND (dbo.c2_cont.cont_fgcancel = '0')"


3/6/2003 updated
-----------------
*ContPubFm_search.aspx

Fix Big:
1. ShowPub() 加入 清除訊息文字: this.literal1.Text = "";


*iaFm1_Addia.aspx

問題: User 反應: 一次付款之產生時, 發廠收件人資料前後不一致.
Fix Big:
1. 3/6/2003 在 GetContIM() 裡加入下一條件, 以免抓出的 im_nm 不正確
   rowfilterstr1 = rowfilterstr1 + " AND im_contno = '" + strContNo + "'";



3/10/2003 updated
-----------------
*iaFm1_Recia.aspx

問題: User 反應: 一次付款之發票回復無效!  (廠商 冶聯 contno=000326)
Fix Big:
1. 修改 Itridpa DB 之 sp_c2_delete_1_ia 名稱及內容
   為 sp_c2_delete_ia_1
2. 修改 .cs 之 btnRecia_Click()
   修改 sqlCommand1 ~ sqlCommand3 由舊的 update 改為 Transaction 確認更新.



3/11/2003 updated
-----------------
InvMfrForm.aspx

問題: User 游惠茹 反應: 
維護合約書處之 "維護 發票廠商收件人" 時,
再儲存成功後, 發票類別應為 "三聯", 卻為 "二聯".
且有錯誤訊息畫面, 如之前附件檔!

測試資料:
-----------
廠商: 億研堂
合約編號: 000271
發廠收件人: 01 李建樹

Fix Bug:
1. 修改 DataGrid1_ItemCommand 之 Line 752 ~ 821
2. 修改 DataGrid2_ItemCommand 之 Line 920, 942, 964
3. 修改 ModifyDB() 之 Line 1257 : 移除 this.ddlIMInvtp.ClearSelection();



3/14/2003 updated
-----------------
問題: User 康靜怡 回應: C2註銷及結案篩選 (見 Email)

Fix Bug:
1. 已修正以下程式(移除已結案及已註銷合約之篩選條件), 請檢視:
	2.1.4 平面廣告次系統 合約處理 廣告費用檢查清單 
	2.3.1 平面廣告次系統 落版處理 廣告排版動作 
	2.3.2 平面廣告次系統 落版處理 美編樣後修正 
	2.3.3 平面廣告次系統 落版處理 廣告落版單
	*2.3.4 平面廣告次系統 落版處理 廣告落版清單 
	2.3.5 平面廣告次系統 落版處理 廣告製稿統計表 
	
	說明一: * 表示您附件沒提及要做修正, 由我提及須已修正!
	說明二: 2.9.1 廣告收入統計表 --- 已於 2/26 做相同的修正了.

2. 修改 2.9.1 廣告收入統計表 畫面篩選條件之說明文字.
3. 修改 2.2 催稿單 表頭位置之說明文字: 廣告處理 => 催稿處理
4. 修改 所有報表程式之連結: 由 localhost 改寫死至 http://isccom2/mrlpub/...
	修改21個程式
	2.1.3 合約處理 合約書清單  cont_list.aspx
	2.1.4 合約處理 廣告費用檢查清單  adamt_list.aspx
	2.1.5 合約處理  平面廣告標籤 當月刊登  PubFm_label_search.aspx
	      合約處理  平面廣告標籤 當月未刊登  PubFm_label_search2.aspx
	2.1.6 合約處理 廣告費用檢查清單  adamt_list.aspx
	2.2   催稿處理  催稿單  getad.aspx
	      * 發現 bug: exec sp_c2_getad_1 '0', '01'
	                  Server: Msg 536, Level 16, State 3, Procedure sp_c2_getad_2, Line 32
			  Invalid length parameter passed to the substring function.
	2.3.3 落版處理  廣告落版單  adpub_form.aspx
	2.3.4 落版處理  廣告落版清單  adpub_list.aspx
	2.3.5 落版處理  廣告製稿統計表  admade_stat.aspx
	2.4.2.1 發票處理  發票開立單檢核表 - 一次付款  iaFm1_Chklist_query.aspx
	2.4.2.2 發票處理  發票開立單檢核表 - 一次付款  iaFm1_Chklist2.aspx
	2.4.2.3 發票處理  發票開立單檢核表 - 大批月結  iaFm2_Chklist_ia.aspx
	2.6.3 缺書處理  缺書清單  lostbk_list.aspx
	2.6.4 缺書處理  缺書標籤  lostbk_label_filter.aspx  Data?
	2.8.1 推廣戶處理  廣告推廣戶清單  adprom_list.aspx
	2.8.2 推廣戶處理  廣告推廣戶清單  adprom_list.aspx
	2.8.3 推廣戶處理  廣告推廣戶標籤  adprom_label.aspx  
	


3/19/2003 updated
-----------------
問題: User 康靜宜 反應 催稿單裡的已確定刊登月份之部份資料有誤.

Fix Bug:
1. 修改 sp_c2_getad_2 Line 32 @i_len 處, 加 if 判斷式



4/9/2003 updated
-----------------
問題: User 高惠娟 反應 無法新增合約書.

Fix Bug:
1. 修改 ContFm_Add.aspx  Line 813~869 -- 加入檢查 strSignDate, strStartDate, strEndDate



6/6/2003 updated
-----------------
問題: User 康靜宜 反應 
Fix Bug:
1. 修改 iaFm2_list2.aspx  Line 161, 221 -- 移除 (Where...) AND (dbo.c2_cont.cont_fgclosed = '0') 條件



6/11/2003 updated
-----------------
問題: User 游惠茹 反應 鴻安 & 東宇公司在新增合約書成功後, 無法開啟合約書/落版畫面.
	=> 發現資料庫：合約迄日只有 2003, 並非 200307
Fix Bug:
1. 修改 cont_main2.aspx.cs  Line 103-171 Page_Load() -- 加入檢查日期的格式
2. 修改 cont_new2.aspx.cs  Line 103-171 Page_Load() -- 加入檢查日期的格式
3. 修改 ContFm_modify.aspx.cs  Line 386~456 LoadOldCont() -- 加入檢查日期的格式
4. 修改 pub_new1.aspx.cs  Line 134~174 ShowPub() --  加入檢查日期的格式
5. 修改 PubFm.aspx.cs  Line 407~463 LoadContData() -- 加入檢查日期的格式
6. 修改 ContFm_closedshow.aspx.cs  Line 128~171 ShowCont() -- 加入檢查日期的格式
7. 修改 ContFm_show.aspx.cs  Line 389~431 LoadOldCont() -- 加入檢查日期的格式
8. 修改 ContPubFm_show.aspx.cs  Line 401~443 LoadOldCont() -- 加入檢查日期的格式
9. 修改 ContPubFm_search.aspx.cs  Line 137~180 ShowPub() -- 加入檢查日期的格式
10. 修改 ContFm_cancelshow.aspx.cs  Line 131~174 ShowCont() -- 加入檢查日期的格式
11. 修改 ContFm_cancel.aspx.cs  Line 149~193 ShowCont() -- 加入檢查日期的格式
12. 修改 ContFm_chkl.aspx.cs  Line 130~200 BindGrid1() -- 加入檢查日期的格式
13. 修改 ContFm_modify.aspx  Line 245~246 ShowCont() -- 加入檢查日期的格式 revSDate, revEDate
14. 修改 ContFm_Add.aspx  Line 248~249 ShowCont() -- 加入檢查日期的格式 revSDate, revEDate



6/24/2003 updated
-----------------
問題: User 康靜宜 反應 廣告排版動作 步驟二 (adpub_act2.aspx), 按下 "重排頁次" 按鈕後.
當新頁次超過100時, 沒有排在 99之後, 而排在9之後; 解決: SrcPageNo & DesPageNo 加 parseInt()

Fix Bug:
1. 修改 adpub_act2.aspx  Line 1054, 1059, 1034~1038



//2003 updated
-----------------




//2003 updated
-----------------

