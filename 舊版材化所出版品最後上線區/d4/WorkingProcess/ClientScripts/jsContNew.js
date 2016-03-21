<script language="JavaScript">
function doOpenFreeBk(custno, new_contno, old_contno)
{
	window.open("FreeBook.aspx?Act=New&CustNo=" + custno + "&NewContNo=" + new_contno + "&OldContNo=" + old_contno , "Poping", "toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=800,height=600", false);
}

function doOpenMisc(new_contno, classid)
{
	window.open("AtpMatp.aspx?NewContNo="+new_contno+"&ClassId="+classid, "Poping", "toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=800,height=600", false);
}

function doOpenInvMfr(new_contno, old_contno, mfrno)
{
	window.open("InvMfr.aspx?NewContNo="+new_contno+"&OldContNo=" + old_contno+"&mfrno="+mfrno, "Poping", "toolbar=no,menubar=no,scrollbars=yes,resizable=yes,width=800,height=600", false);
}
</script>
