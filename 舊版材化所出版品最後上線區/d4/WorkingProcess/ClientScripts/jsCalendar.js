<script Language="JavaScript">
function pick_date(theField, theField1, theField2)
{
	// ñ�����
	var oParam = new Object();
	strFeature = "";
	strFeature += "dialogHeight:250px;dialogWidth:200px;center:yes;scroll:yes;status:no;help:no;";
	var vreturn = window.showModalDialog("calendar.asp", oParam, strFeature); 
	//alert("vreturn= " + vreturn);
	
	// �X���_��
	
	var vreturn1 = vreturn;
	//alert("vreturn1= " + vreturn1);
	
	// �X������

	//var vreturn2 = vreturn;
	//alert("vreturn2= " + vreturn2);
	
	window.document.all(theField).value=vreturn;
	window.document.all(theField1).value=vreturn1;
	//window.document.all(theField2).value=vreturn2;
	//return true;
}

function pick_date_single(theField)
{
	var oParam = new Object();
	strFeature = "";
	strFeature += "dialogHeight:250px;dialogWidth:200px;center:yes;scroll:yes;status:no;help:no;";
	var vreturn = window.showModalDialog("calendar.asp", oParam, strFeature); 
	if(vreturn)
		window.document.all(theField).value=vreturn;
	return true;
}
</script>