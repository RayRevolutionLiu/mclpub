<HTML>
	<HEAD>
		<meta http-equiv="Content-Language" content="zh-tw">
		<meta http-equiv="Content-Type" content="text/html; charset=big5">
		<title>日曆</title>
        <STYLE>
			INPUT { FONT-SIZE: 12px; WIDTH: 20px; FONT-FAMILY: Tahoma; } Table.calendar { 
			BACKGROUND-COLOR: #E2EAFC; FONT-SIZE: 12px; FONT-FAMILY:Tahoma; HEIGHT: 20px; 
			WIDTH: 160px; } TR { TEXT-ALIGN: center; }
		</STYLE>
	</HEAD>
	<body TOPMARGIN="0" LEFTMARGIN="0" MARGINWIDTH="0" MARGINHEIGHT="0">
		<form id="form1" name="form1">
			<table border='0' cellspacing="1" cellpadding="0" align='center' width="163" style="position: absolute; left: 15; top: 11" height="160">
				<tr>
					<td>
						<table border='0px' cellpadding="2px" cellspacing="2" id="alldate" onclick="doSelectDate()" onmouseover="doMouseOver()" onmouseout="doMouseOut()" class="calendar">
							<tr align="center">
								<td colspan='7'>
									<span style="font-weight:900" id="yearmonth"></span>
                                    　
								</td>
							</tr>
							<tr align="center">
								<td>
									日
								</td>
								<td>
									一
								</td>
								<td>
									二
								</td>
								<td>
									三
								</td>
								<td>
									四
								</td>
								<td>
									五
								</td>
								<td>
									六
								</td>
							</tr>
							<tr align="center">
								<td>
								</td>
								<td>
								</td>
								<td>
								</td>
								<td>
								</td>
								<td>
								</td>
								<td>
								</td>
								<td>
								</td>
							</tr>
							<tr align="center">
								<td>
								</td>
								<td>
								</td>
								<td>
								</td>
								<td>
								</td>
								<td>
								</td>
								<td>
								</td>
								<td>
								</td>
							</tr>
							<tr align="center">
								<td>
								</td>
								<td>
								</td>
								<td>
								</td>
								<td>
								</td>
								<td>
								</td>
								<td>
								</td>
								<td>
								</td>
							</tr>
							<tr align="center">
								<td>
								</td>
								<td>
								</td>
								<td>
								</td>
								<td>
								</td>
								<td>
								</td>
								<td>
								</td>
								<td>
								</td>
							</tr>
							<tr align="center">
								<td>
								</td>
								<td>
								</td>
								<td>
								</td>
								<td>
								</td>
								<td>
								</td>
								<td>
								</td>
								<td>
								</td>
							</tr>
							<tr align="center">
								<td>
								</td>
								<td>
								</td>
								<td>
								</td>
								<td>
								</td>
								<td>
								</td>
								<td>
								</td>
								<td>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td height="40">
						<input type='button' name='b1' value='<<' style="width:26" onclick='prevYear();'>
						<input type='button' name='b1' value='<' style="width:26" onclick='prevMonth();'> 
						<input type='button' name='b1' value='O' style="width:26" onclick='GoToday();'>
						<input type='button' name='b1' value='>' style="width:26" onclick='nextMonth();'> 
						<input type='button' name='b1' value='>>' style="width:26" onclick='nextYear();'> 
					</td>
				</tr>
			</table>
		</form>
		<SCRIPT LANGUAGE="JavaScript">
var year, month, FirstDate, LastDate, Today, Now;

year = <%=year(now())%>;
month = <%=month(now())%>;
Now = new Date(year, month-1, <%=day(now())%>);
init();


function init()
{
	FirstDate = (new Date(year, month-1, 1)).getDay();
	LastDate = (new Date(year, month, 1-1)).getDate();
	yearmonth.innerText = year + "/" + month;
	
	for (var i=8, j=1; i < 50; i++)
	{
		if ( (i >= FirstDate+8) && (i < LastDate+8+FirstDate))
		{
			alldate.cells.item(i).innerText = j;
			j=j+1;
		}
		else
		{
			alldate.cells.item(i).innerHTML = "&nbsp;";
		}
	}
	
}

function GoToday()
{
	year = Now.getFullYear();
	month = Now.getMonth()+1;
	init();
}

function fillDate()
{
	if(ooo == 1){theURL+="2002/6/21"}
	else if(ooo == 2){theURL+="2003/3/21"}
	else if(ooo == 3){theURL+="2003/9/21"}
	else if(ooo == 4){theURL+="2004/6/21"}
	window.location.href = theURL;
}

function prevYear()
{
	year = year - 1;
	init();
}

function nextYear()
{
	year = year + 1;
	init();
}

function nextMonth()
{
	if(month < 12)
	{
		month = month + 1;
	}
	else
	{
		month = 1;
		year = year + 1;
	}
	init();
}

function prevMonth()
{
	if(month > 1)
	{
		month = month - 1;
	}
	else
	{
		month = 12;
		year = year - 1;
	}
	init();
}

function convertDate(thisDate)
{
	thisDate = new Date(thisDate)
	if(!isNaN(thisDate))
	{
		var theYear = thisDate.getFullYear();
		var theMonth = thisDate.getMonth()+1;
		var theDate = thisDate.getDate();
		theYear = String((theYear/10000 + 1/100000)).substring(2,6)
		theMonth = String((theMonth/100 + 1/1000)).substring(2,4)
		theDate = String((theDate/100 + 1/1000)).substring(2,4)
		return (theYear + "/" + theMonth + "/" + theDate);
	}
}

function doMouseOver()
{
	var obj = window.event.srcElement;
	if(obj.tagName == "TD")
	{
		obj.style.backgroundColor = "#8dadf1";
	}
}

function doMouseOut()
{
	var obj = window.event.srcElement;
	if(obj.tagName == "TD")
	{
		obj.style.backgroundColor = "#E2EAFC";
	}
}

function doSelectDate(theDate)
{
	var obj = window.event.srcElement;
	if(obj.tagName == "TD")
	{
		var theRow = obj.parentElement.rowIndex-2;
		var theCell = obj.cellIndex;
		var pos = theRow*7+theCell;
		if((pos >= FirstDate) && (pos < LastDate+FirstDate))
		{
			window.returnValue = convertDate(new Date(year, month-1, pos-FirstDate+1));
			window.close();
		}
	}
}
		</SCRIPT>
	</body>
</HTML>
