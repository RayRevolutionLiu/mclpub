<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Pager.ascx.cs" Inherits="mclpub.UserControl.Pager" %>

 <script language="javascript" type="text/javascript">
<!--

function check_page_size()
{
    
    var thisobj=document.getElementById ('<%=txt_page.ClientID %>');
    if (isNaN(thisobj.value)||parseFloat(thisobj.value)<=0)
    {
       alert(" Please Key Numerical");
       thisobj.value="10";
       return false;
    }
    if (parseFloat(thisobj.value)>100)
    {
       alert("Sorry,the number of max is 100");
       thisobj.value="100";
       return false;
    }
    if (thisobj.value=="")
    {
       thisobj.value="10";
       return false;
    }
}


//-->
    </script>
<!--由於Main.css裡面有一行針對「#Content table」做了「border-bottom: 5px solid #000;」，但是在此不希望有底線-->
<table border="0" cellpadding="0" cellspacing="0" width="100%" style ="border-bottom:0px;" runat ="server" id="table_pager">
    <tbody>
        <tr>
            <td >
                
                <asp:LinkButton ID="lbtn_first" runat="server" OnClick="lbtn_first_Click">首頁</asp:LinkButton>
                <asp:LinkButton ID="lbtn_pre10page" runat="server" Text="|<" OnClick="lbtn_pre10page_Click" />
                <asp:LinkButton ID="lbtn_prepage" runat="server" Text="<" OnClick="lbtn_prepage_Click" />
                <asp:Repeater ID="rep_page" runat="server" OnItemDataBound="rep_page_ItemDataBound">
                <ItemTemplate >
                    <asp:LinkButton ID="lbtn_page" runat="server" CommandArgument ='<%#Eval("page") %>'  OnClick="lbtn_page_Click"><%#Eval("page")%></asp:LinkButton>
                </ItemTemplate>
                </asp:Repeater>
                <asp:LinkButton ID="lbtn_nextpage" runat="server" Text=">" OnClick="lbtn_nextpage_Click" />
                 <asp:LinkButton ID="lbtn_next10page" runat="server" Text=">|" OnClick="lbtn_next10page_Click" />
                <asp:LinkButton ID="lbtn_last" runat="server" OnClick="lbtn_last_Click">最末頁</asp:LinkButton>
            
                &nbsp;共
                    <asp:Label ID="lbl_pagecount"
                        runat="server" Text="0"></asp:Label>&nbsp;頁&nbsp;，
                        共&nbsp;<asp:Label ID="lbl_datacount" runat="server" Text="0"></asp:Label>&nbsp;筆
                        &nbsp;<asp:TextBox
                            ID="txt_page" runat="server" Width ="20" ></asp:TextBox>&nbsp;<asp:LinkButton ID="lbtn_go1" runat="server" OnClick="lbtn_go1_Click" OnClientClick ="return check_page_size();">Go</asp:LinkButton>
           
                移至第 
                <asp:DropDownList ID="ddl_gopage" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_gopage_SelectedIndexChanged">
                </asp:DropDownList>&nbsp;頁
          
            </td>
        </tr>
    </tbody>
</table>
