SELECT         c4_cont.cont_contno, c4_cont.cont_conttp, c4_cont.cont_sdate, 
                          c4_cont.cont_edate, c4_cont.cont_empno, c4_cont.cont_mfrno, mfr_2.mfr_inm, 
                          c4_cont.cont_custno, c4_adr.adr_seq, c4_adr.adr_addate, c4_adr.adr_adcate, 
                          c4_adr.adr_keyword, c4_adr.adr_alttext, c4_adr.adr_imgurl, c4_adr.adr_impr, 
                          c4_adr.adr_navurl, c4_adr.adr_drafttp, c4_adr.adr_urltp, c4_adr.adr_imseq, 
                          invmfr.im_mfrno, mfr_1.mfr_inm AS EXPR1, invmfr.im_nm, c4_adr.adr_invamt, 
                          c4_adr.adr_adamt, c4_adr.adr_desamt, c4_adr.adr_chgamt, c4_adr.adr_remark, 
                          srspn.srspn_cname
FROM             srspn INNER JOIN
                          c4_cont ON srspn.srspn_empno = c4_cont.cont_empno RIGHT OUTER JOIN
                          invmfr RIGHT OUTER JOIN
                          c4_adr ON invmfr.im_syscd = c4_adr.adr_syscd AND 
                          invmfr.im_contno = c4_adr.adr_contno AND 
                          invmfr.im_imseq = c4_adr.adr_imseq ON 
                          c4_cont.cont_syscd = c4_adr.adr_syscd AND 
                          c4_cont.cont_contno = c4_adr.adr_contno LEFT OUTER JOIN
                          mfr mfr_1 ON invmfr.im_mfrno = mfr_1.mfr_mfrno LEFT OUTER JOIN
                          mfr mfr_2 ON c4_cont.cont_mfrno = mfr_2.mfr_mfrno
WHERE         (c4_cont.cont_syscd = 'C4') AND (c4_cont.cont_conttp = '01') AND 
                          (c4_cont.cont_fgcancel = '0') AND (c4_cont.cont_fgtemp = '0') AND 
                          (c4_cont.cont_fgclosed = '0') AND (c4_adr.adr_addate <= '20030715') AND 
                          (c4_adr.adr_fginved <> '1') AND (c4_adr.adr_invamt > 0)
ORDER BY  c4_cont.cont_empno, c4_cont.cont_contno, invmfr.im_mfrno, c4_adr.adr_addate