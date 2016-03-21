<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="mclpub._Default" MasterPageFile="~/MasterPage.Master" %>

    <asp:Content id="Content1" ContentPlaceholderID="ContentPlaceHolder1" runat="server">

        <span class="font_red font_size12">*為必填欄位</span>    
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">廠商資料</th>
  </tr>

  <tr>
    <td align="right" width="90" class="font_bold">公司名稱:</td>
    <td>
    <Input type="text" size="40" />&nbsp;<input type="image" src="<%=ResolveUrl("~/Art/images/btn_view.gif")%>" />&nbsp;
    <span class="font_size12">請輸入關鍵值然後按查詢以取得統一編號</span>
    </td>
  </tr>
  <tr>

    <td align="right" class="font_red font_bold">*統一編號:</td>
    <td>
    <Input type="text" size="40" />&nbsp;<input type="image" src="<%=ResolveUrl("~/Art/images/btn_view.gif")%>" />
    <span class="font_size12">如確定輸入正確之統一編號,即可跳過查詢功能繼續輸入以下資料</span>
    </td>
  </tr>
</table>
</span>
<br />

<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="4">新訂戶資料</th>
  </tr>
  <tr>
    <td align="right" width="90" class="font_bold">訂戶編號:</td>
    <td>003879</td>

    <td align="right" width="90" class="font_bold">登錄日期:</td>
    <td>
    <Input type="text" size="20" />&nbsp;<input type="image" src="<%=ResolveUrl("~/Art/images/btn_data.gif")%>" />&nbsp;
    </td>
  </tr>
  <tr>
    <td align="right" class="font_red font_bold">*姓名:</td>
    <td>

    <Input type="text" size="30" />
    </td>
    <td align="right" width="90" class="font_bold">手機號碼:</td>
    <td>
    <Input type="text" size="30" />
    </td>
  </tr>
  <tr>

    <td align="right" class="font_red font_bold">*聯絡電話:</td>
    <td>
    <Input type="text" size="30" />
    </td>
    <td align="right" width="90" class="font_bold">傳真號碼:</td>
    <td>
    <Input type="text" size="30" />
    </td>

  </tr>
  <tr>
    <td align="right" class="font_bold">職稱:</td>
    <td colspan="3">
    <input type="radio" />&nbsp;先生&nbsp;&nbsp;<input type="radio" />&nbsp;小姐&nbsp;&nbsp;<input type="radio" />&nbsp;自訂&nbsp;&nbsp;<Input type="text" size="20" />
    </td>
  </tr>

  <tr>
    <td align="right" class="font_bold">Email:</td>
    <td colspan="3">
    <Input type="text" size="100" />
    </td>
  </tr>
  <tr>
    <td align="right" class="font_bold">營業項目:</td>

    <td colspan="3">
    <input type="checkbox" />銷售&nbsp;<input type="checkbox" />製造&nbsp;<input type="checkbox" />學校/研究機構/社團&nbsp;<input type="checkbox" />其他&nbsp;
    </td>
  </tr>
  <tr>
    <td align="right" class="font_bold">專業領域:</td>

    <td colspan="3">
    <span class="stripMenone">
    <table border="0" width="100%" cellspacing="0" cellpadding="0" class="font_size13">
  <tr>
    <td width="15%"><input type="checkbox" />半導體</td>
    <td width="15%"><input type="checkbox" />電子/電機</td>
    <td width="15%"><input type="checkbox" />平面顯示器</td>

    <td width="15%"><input type="checkbox" />光電產業</td>
    <td width="15%"><input type="checkbox" />無線通訊</td>
    <td width="15%"><input type="checkbox" />交通運輸</td>
  </tr>
  <tr>
    <td width="15%"><input type="checkbox" />建材</td>
    <td width="15%"><input type="checkbox" />金屬產業</td>

    <td width="15%"><input type="checkbox" />化學/化工</td>
    <td width="15%"><input type="checkbox" />運動/休閒</td>
    <td width="15%"><input type="checkbox" />電池產業</td>
    <td width="15%"><input type="checkbox" />資訊產業</td>
  </tr>
   <tr>
    <td width="15%"><input type="checkbox" />機械</td>

    <td width="15%"><input type="checkbox" />生技/醫療</td>
    <td width="15%"><input type="checkbox" />傳統產業之奈米化學</td>
    <td width="15%"><input type="checkbox" />其他</td>
    <td width="15%">&nbsp;</td>
    <td width="15%">&nbsp;</td>
  </tr>
</table>
    </span>

    
    </td>
  </tr>
</table>
</span>
<center>
<button class=btn_mouseout onmouseover="this.className='btn_mouseover'"onmouseout="this.className='btn_mouseout'">新增</button>
<button class=btn_mouseout onmouseover="this.className='btn_mouseover'"onmouseout="this.className='btn_mouseout'">取消</button>	
</center>
    </asp:Content>