<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DownPage.aspx.cs" Inherits="mclpub.Art.DownPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>工研院材化所出版品系統</title>
<script type="text/javascript" src="js/jquery-1.4.2.min.js"></script>
<script type="text/javascript" src="js/superfish.js"></script>
<script type="text/javascript" src="js/jquery.bgiframe.min.js"></script>
<!--=============此套入其他js程式碼==============-->
<link rel="stylesheet" href="../jquery/development-bundle/themes/base/jquery.ui.all.css" />
<link rel="stylesheet" href="thickbox.css" /><!--秀圖片專用 --> 

<script src="../jquery/development-bundle/ui/jquery.ui.core.js"></script><!--sort專用 --> 
<script src="../jquery/development-bundle/ui/jquery.ui.widget.js"></script><!--sort專用 --> 
<script src="../jquery/development-bundle/ui/jquery.ui.mouse.js"></script><!--sort專用 --> 
<script src="../jquery/development-bundle/ui/jquery.ui.sortable.js"></script><!--sort專用 --> 
	
<script src="thickbox.js"></script><!--秀圖片專用 --> 

<style>
#sortable { list-style-type: none; margin: 0; padding: 0; }
#sortable li { margin: 3px 3px 3px 0; padding: 1px; float: left; width: 154px; height: 90px; font-size: 4em; text-align: center; }
</style>

<script type="text/javascript"> 
 
     $(document).ready(function(){ 
        $("ul.sf-menu").superfish({ 
            delay:     0            
        }); 
    }); 
 
</script>
<!--{* 解決ie6 menu下拉選單擋住的問題 *}-->
<script type="text/javascript" charset="utf-8">
            $(function() {
                $('.sf-menu li').bgiframe();
            });
</script>

<!--{* 雙色表單 *}-->
<script type="text/javascript">
$(document).ready(function(){
$(".stripeMe tr").mouseover(function() {$(this).addClass("over");}).mouseout(function() {$(this).removeClass("over");});
$(".stripeMe tr:even").addClass("alt");
});
</script>

<script>
	    $(function() {
	        $('#sortable').sortable();

	    });

</script>

<link href="css/style.css" rel="stylesheet" type="text/css" />
<link href="css/superfish.css" rel="stylesheet" type="text/css"  media="screen">



</head>
<body>
    <form id="form1" runat="server">
<table border="0" width="100%" cellspacing="0" cellpadding="0" summary="全局版面">
  <tr>
    <td valign="top" height="175">
    <div id="main">
    <div class="home"><a href="index.html" target="_self"><img src="images/btn_home.gif" border="0" /></a></div>
    <div id="headerinfo" class="font_black font_size13">

<table border="0" width="510" cellspacing="0" cellpadding="0" summary="header info">
  <tr>
    <td height="40">
    <span class="font_size18 font_bold">曾寶貞</span>&nbsp; 您好，請從以下主選單開始操作管理功能。
    </td>
  </tr>
</table>

    </div><!--{* headerinfo *}-->
	<div id="menu">
<ul class="sf-menu">
			<li class="current">

            <a href="#" target="_self"><img src="images/btn01_out.gif" border="0" onMouseOver="this.src='images/btn01_over.gif'" onMouseOut="this.src='images/btn01_out.gif'"></a>
            	<ul>
					<li><a href="page02.html" target="_self">訂戶管理</a></li>
                    <li><a href="page02-1.html" target="_self">材網訂戶</a></li>
                    <li><a href="page02-2.html" target="_self">工材訂戶</a></li>
                    <li><a href="page02-3.html" target="_self">廣告客戶</a></li>
				</ul>

            </li>
<!--{* 單一選項兩層次選單 start *}-->
    		<li class="current">
				<a href="#" target="_self"><img src="images/btn02_out.gif" border="0" onMouseOver="this.src='images/btn02_over.gif'" onMouseOut="this.src='images/btn02_out.gif'"></a>	
				<ul>
					<li>
                    <a href="page07-1.html" target="_self">材網廣告</a>
                    <!--{* 第三層次選單 start *}
                    <ul>
                    	<li><a href="#" target="_self">submenu</a></li>
                        <li><a href="#" target="_self">submenu</a></li>
                        <li><a href="#" target="_self">submenu</a></li>
                    </ul>
					{* 第三層次選單 end *}-->
                    </li>

                    <li><a href="page07-2.html" target="_self">工材廣告</a></li>
				</ul>
			</li>
<!--{* 單一選項兩層次選單 over *}-->            
            <li class="current">
				<a href="#" target="_self"><img src="images/btn03_out.gif" border="0" onMouseOver="this.src='images/btn03_over.gif'" onMouseOut="this.src='images/btn03_out.gif'"></a>	
				<ul>
					<li><a href="page08-1.html" target="_self">工材訂單</a></li>
                    <li><a href="page08-2.html" target="_self">材網訂單</a></li>

                    <li><a href="page08-3.html" target="_self">贈書訂單</a></li>
				</ul>
			</li>
            <li class="current">
				<a href="page09-1.html" target="_self"><img src="images/btn04_out.gif" border="0" onMouseOver="this.src='images/btn04_over.gif'" onMouseOut="this.src='images/btn04_out.gif'"></a>	
				
			</li>
            <li class="current">
				<a href="page05.html" target="_self"><img src="images/btn05_out.gif" border="0" onMouseOver="this.src='images/btn05_over.gif'" onMouseOut="this.src='images/btn05_out.gif'"></a>	
				<ul>

					<li><a href="#" target="_self">版面管理</a></li>
                    <li><a href="#" target="_self">落版管理</a></li>
				</ul>
			</li>
            <li class="current">
				<a href="page06.html" target="_self"><img src="images/btn06_out.gif" border="0" onMouseOver="this.src='images/btn06_over.gif'" onMouseOut="this.src='images/btn06_out.gif'"></a>	
				<ul>
					<li><a href="#" target="_self">發票管理</a></li>

                    <li><a href="#" target="_self">繳款</a></li>
                    <li><a href="#" target="_self">付款</a></li>
                    <li><a href="#" target="_self">SAP功能</a></li>
				</ul>
			</li>
            <li class="current">
				<a href="page07.html" target="_self"><img src="images/btn07_out.gif" border="0" onMouseOver="this.src='images/btn07_over.gif'" onMouseOut="this.src='images/btn07_out.gif'"></a>	
				<ul>

					<li><a href="#" target="_self">統計報表</a></li>
                    <li><a href="#" target="_self">統計匯出</a></li>
				</ul>
			</li>
            <li class="current">
				<a href="page08.html" target="_self"><img src="images/btn08_out.gif" border="0" onMouseOver="this.src='images/btn08_over.gif'" onMouseOut="this.src='images/btn08_out.gif'"></a>	
				<ul>
					<li><a href="#" target="_self">權限設定</a></li>

                    <li><a href="#" target="_self">參數設定</a></li>
                    <li><a href="#" target="_self">角色管理</a></li>
				</ul>
			</li>
</ul>
</div>	</div><!--{* main *}-->
    </td>
  </tr>

  <tr>
  	<td valign="top" class="font_size15 font_darkgray">
    <div id="basecontent">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;廣告落版落版管理 / 落版管理</span> 
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="4">落版管理</th>
  </tr>
  <tr>
    <td>
        <div id="sortcontent">
        <ul id="sortable">
	        <li class="ui-state-default" id="1"><a href="DownPageImages/14124566.png" class="thickbox"><asp:Image ID="Image1" runat="server" ImageUrl="~/Art/DownPageImages/14124566.png" Width="150px" Height="90px"/></a></li>
	        <li class="ui-state-default" id="2"><a href="DownPageImages/15.jpg" class="thickbox"><asp:Image ID="Image2" runat="server"  ImageUrl="~/Art/DownPageImages/15.jpg"  Width="150px" Height="90px"/></a></li>
	        <li class="ui-state-default" id="3"><a href="DownPageImages/35754_133897243296602_100000289826119_273753_1463124_n.jpg" class="thickbox"><asp:Image ID="Image3" runat="server" ImageUrl="~/Art/DownPageImages/35754_133897243296602_100000289826119_273753_1463124_n.jpg" Width="150px" Height="90px"/></a></li>
	        <li class="ui-state-default" id="4"><a href="DownPageImages/37312_407412654870_183954419870_4175923_6149111_n.jpg" class="thickbox"><asp:Image ID="Image4" runat="server" ImageUrl="~/Art/DownPageImages/37312_407412654870_183954419870_4175923_6149111_n.jpg"  Width="150px" Height="90px"/></a></li>
	        <li class="ui-state-default" id="5"><a href="DownPageImages/ATT00009.jpg" class="thickbox"><asp:Image ID="Image5" runat="server" ImageUrl="~/Art/DownPageImages/ATT00009.jpg"  Width="150px" Height="90px"/></a></li>
	        <li class="ui-state-default" id="6"><a href="DownPageImages/268479_10150258718338522_243782363521_7409448_955403_n.jpg" class="thickbox"><asp:Image ID="Image6" runat="server" ImageUrl="~/Art/DownPageImages/268479_10150258718338522_243782363521_7409448_955403_n.jpg"  Width="150px" Height="90px"/></a></li>
	        <li class="ui-state-default" id="7"><a href="DownPageImages/Jk063.jpg" class="thickbox"><asp:Image ID="Image7" runat="server" ImageUrl="~/Art/DownPageImages/Jk063.jpg"  Width="150px" Height="90px"/></a></li>
	        <li class="ui-state-default" id="8"><a href="DownPageImages/msnMSN.jpg" class="thickbox"><asp:Image ID="Image8" runat="server" ImageUrl="~/Art/DownPageImages/msnMSN.jpg"  Width="150px" Height="90px"/></a></li>
	        <li class="ui-state-default" id="9"><a href="DownPageImages/不刷牙的下場.jpg" class="thickbox"><asp:Image ID="Image9" runat="server" ImageUrl="~/Art/DownPageImages/不刷牙的下場.jpg"  Width="150px" Height="90px"/></a></li>
	        <li class="ui-state-default" id="10"><a href="DownPageImages/有梗.jpg" class="thickbox"><asp:Image ID="Image10" runat="server" ImageUrl="~/Art/DownPageImages/有梗.jpg"  Width="150px" Height="90px" /></a></li>
	        <li class="ui-state-default" id="11"><a href="DownPageImages/虎頭蜂.jpg" class="thickbox"><asp:Image ID="Image11" runat="server" ImageUrl="~/Art/DownPageImages/虎頭蜂.jpg"  Width="150px" Height="90px"/></a></li>
	        <li class="ui-state-default" id="12"><a href="DownPageImages/畫的不錯.jpg" class="thickbox"><asp:Image ID="Image12" runat="server" ImageUrl="~/Art/DownPageImages/畫的不錯.jpg"  Width="150px" Height="90px"/></a></li> 
        </ul>
        </div>   
    </td>
  </tr>
</table>
</span>
<center>
<button class=btn_mouseout onmouseover="this.className='btn_mouseover'"onmouseout="this.className='btn_mouseout'">新增</button>
<button class=btn_mouseout onmouseover="this.className='btn_mouseover'"onmouseout="this.className='btn_mouseout'">取消</button>
</center>
    </div><!--{* basecontent *}-->
    </td>
  </tr>

  <tr>
    <td valign="top" align="center" class="footer">
    <table border="0" cellspacing="0" cellpadding="0" class="font_size12 font_lightgray font_bold" style="padding-top:15px;">
  <tr>

    <td align="left">工業技術研究院材料與化工研究所出版品管理系統ITRI MCLPUBopyright © 2010 All Rights Reserved</td>
  </tr>
</table>

    </td>
  </tr>
</table>
    </form>
</body>
</html>
