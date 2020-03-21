<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="frmAdminHome.aspx.cs" Inherits="diseasePrediction.Admin.frmAdminHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="panelAdminHome" runat="server">

 	<div class="about row">
			<h2>welcome to administrator home page</h2>
           </div>
            <table style="width: 75%; height: 124px;" align="center">
                <tr>
                    <td class="style2">
                        <strong>User Type</strong></td>
                    <td class="style4">
                        <asp:DropDownList ID="DropDownListType" runat="server">
                            <asp:ListItem>Select</asp:ListItem>
                            <asp:ListItem>Doctor</asp:ListItem>
                            <asp:ListItem>Receptionist</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" 
                            ControlToValidate="DropDownListType" ErrorMessage="*" Font-Size="X-Small" 
                            ForeColor="#FF3300" Operator="NotEqual" ToolTip="Select User Type" 
                            ValidationGroup="user" ValueToCompare="Select">Select User Type</asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <strong>UserId</strong></td>
                    <td class="style4">
                        <asp:TextBox ID="txtUserId" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtUserId" ErrorMessage="*" Font-Size="X-Small" 
                            ForeColor="#FF3300" ToolTip="Enter UserId" ValidationGroup="user">Enter UserId</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        &nbsp;</td>
                    <td class="style4">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                            ControlToValidate="txtUserId" CssClass="validation" Display="Dynamic" 
                            ErrorMessage="Only Alphabets and Numbers" ForeColor="#FF3300" 
                            ToolTip="Only Alphabets and Numbers" ValidationExpression="^[a-zA-Z0-9_.-]*$">Only Alphabets and Numbers</asp:RegularExpressionValidator>
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style2">
                        <strong>Password</strong></td>
                    <td class="style4">
                        <asp:TextBox ID="txtPassword" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtPassword" ErrorMessage="*" Font-Size="X-Small" 
                            ForeColor="#FF3300" ToolTip="Enter Password" ValidationGroup="user">Enter Password</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        &nbsp;</td>
                    <td class="style4">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                            ControlToValidate="txtPassword" CssClass="validation" Display="Dynamic" 
                            ErrorMessage="Password Must be 8 Characters including 1 Uppercase letter, 1 Special Character and Alphanumeric Characters." 
                            ForeColor="#FF3300" 
                            ToolTip="Password Must be 8 Characters including 1 Uppercase letter, 1 Special Character and Alphanumeric Characters." 
                            ValidationExpression="(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$">Password 
                                    Must be 8 Characters including 1 Uppercase letter, 1 Special Character and 
                                    Alphanumeric Characters.</asp:RegularExpressionValidator>
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style2">
                        <strong>EmailId</strong></td>
                    <td class="style4">
                        <asp:TextBox ID="txtEmailId" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="txtEmailId" ErrorMessage="*" Font-Size="X-Small" 
                            ForeColor="#FF3300" ToolTip="Enter EmailId" ValidationGroup="user">Enter EmailId</asp:RequiredFieldValidator>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style2">
                        &nbsp;</td>
                    <td class="style4">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ControlToValidate="txtEmailId" ErrorMessage="*" Font-Size="X-Small" 
                            ForeColor="#FF3300" ToolTip="Invalid EmailId" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                            ValidationGroup="user">Invalid EmailId</asp:RegularExpressionValidator>
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style2">
                        &nbsp;</td>
                    <td class="style4">
                        <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" 
                            Text="Submit" ValidationGroup="user" />
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
    <br />
           
   

        <br />

   
                        <h2 class="title" align="center"><span>View Existing Staffs</span></h2>
                            <table style="width:100%;" align="center">

                                <tr>
                                    <td>
                                        <asp:Table ID="tableStaffs" runat="server" HorizontalAlign="Center">
                                        </asp:Table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                                
   
 
   </asp:Panel>

</asp:Content>
