<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/Doctor.Master" AutoEventWireup="true" CodeBehind="_Dataset.aspx.cs" Inherits="diseasePrediction.Doctor._Dataset" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="panelAdminAccount" runat="server">
  <div class="about row">
			<h2>risk patterns dataset</h2>
           </div>

            <table style="width: 60%;" align="center">
                <tr>
                    <td>
                        <b>Select Date</b></td>
                    <td>
                        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" 
                            BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" 
                            ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" 
                            onselectionchanged="Calendar1_SelectionChanged" Width="350px">
                            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" 
                                VerticalAlign="Bottom" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                            <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" 
                                Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                            <TodayDayStyle BackColor="#CCCCCC" />
                        </asp:Calendar>
                    </td>
                    <td>
                        &nbsp;&nbsp;</td>
                </tr>
         <tr>
             <td>
                 &nbsp;</td>
             <td>
                 <asp:TextBox ID="txtDate" runat="server" Width="200px"></asp:TextBox>
             </td>
             <td>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                     ControlToValidate="txtDate" CssClass="validation" ErrorMessage="*" 
                     ToolTip="Enter Date" ValidationGroup="a">Enter Date</asp:RequiredFieldValidator>
             </td>
         </tr>
       
                <tr>
                    <td>
                        <b>Enter Data</b></td>
                    <td>
                        <asp:TextBox ID="txtData" runat="server" Height="150px" TextMode="MultiLine" 
                            Width="250px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtData" CssClass="validation" ErrorMessage="*" 
                            ToolTip="Enter Data" ValidationGroup="a">Enter Data</asp:RequiredFieldValidator>
                    </td>
                </tr>
       
         <tr>
             <td>
                 &nbsp;</td>
             <td>
                 <span>
                 <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" 
                     Text="Upload" ValidationGroup="a" />
                 </span>
             </td>
             <td>
                 &nbsp;</td>
         </tr>
     </table>
     <br />
                            <div>
						   		  <h2 align="center"><span>View</span> Dataset!!!</h2>
                                  <br />
						  </div>

                            <div>
						   		<span>
                                       <asp:Table ID="tableDataset" runat="server" HorizontalAlign="Center">
                                       </asp:Table>  </span>
						  </div>

  				<br />
            </asp:Panel>

</asp:Content>
