<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/Doctor.Master" AutoEventWireup="true" CodeBehind="RiskPatterns.aspx.cs" Inherits="diseasePrediction.Doctor.RiskPatterns" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:Panel ID="Panel1" runat="server">
   <div class="about row">
			<h2>risk patterns prediction using apriori algorithm</h2>
           </div>



          

             <asp:Table ID="Table4" runat="server" HorizontalAlign="Center">
    </asp:Table>
    <br />
            </div>

             <asp:Panel ID="Panel2" runat="server" Visible="False" Width="721px">
        <h2>
            <span>PATTERNS DETAILS</span> !!!</h2>
        <table style="width: 75%;">
            <tr>
                <td style="width: 351px" valign="top">
                    <strong>Distinct Items</strong></td>
                <td>
                    <strong>Dataset</strong></td>
            </tr>
            <tr>
                <td style="width: 351px" valign="top">
                    <asp:ListBox ID="lv_Items" runat="server" Height="175px" Width="211px">
                    </asp:ListBox>
                </td>
                <td style="width: 151px">
                    <asp:ListBox ID="lv_Transactions" runat="server" Height="175px" Width="324px">
                    </asp:ListBox>
                </td>
            </tr>
        </table>
        <table style="width: 75%;">
            <tr>
                <td>
                    <strong>Frequent Item Set (L)</strong></td>
                <td>
                    <strong>Final Output [displaying patterns]</strong></td>
            </tr>
            <tr>
                <td>
                    <asp:ListBox ID="ListBox1" runat="server" Height="161px" Width="211px">
                    </asp:ListBox>
                </td>
                <td>
                    <asp:ListBox ID="ListBox2" runat="server" Height="161px" Width="324px">
                    </asp:ListBox>
                </td>
            </tr>
        </table>
        <br />
    </asp:Panel>



   
    </asp:Panel>


</asp:Content>
