<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/Doctor.Master" AutoEventWireup="true" CodeBehind="_NB.aspx.cs" Inherits="diseasePrediction.Doctor._NB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="panelAdminAccount" runat="server">
  <div class="about row">
			<h2>COPD prediction using Naive Bayes Algorithm</h2>
           </div>
            <table style="width:100%;" align="center">
                <tr>
                    <td>
                        <h3 align="center">
                            Result Analysis</h3>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Table ID="tableResults" runat="server" HorizontalAlign="Center">
                        </asp:Table>
                    </td>
                </tr>
            </table>
            <br />

            <table style="width:100%;" align="center">
                <tr>
                    <td>
                        <asp:Table ID="Table1" runat="server" HorizontalAlign="Center">
                        </asp:Table>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
                     
   <br />
   </asp:Panel>
</asp:Content>
