<%@ Page Title="" Language="C#" MasterPageFile="~/Receptionist/Receptionist.Master" AutoEventWireup="true" CodeBehind="frmReceptionistAccount.aspx.cs" Inherits="diseasePrediction.Receptionist.frmReceptionistAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="panelAdminAccount" runat="server">
 <div class="mainfram">
 <div class="about row">
			<h2>receptionist update password</h2>
           </div>

           <table style="width: 85%; height: 124px;">
               
                <tr>
                    <td class="style2">
                        &nbsp;</td>
                    <td class="style4">
                        &nbsp;</td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style2">
                        <strong>Old Password</strong></td>
                    <td class="style4">
                        <asp:TextBox ID="txtOldPassword" runat="server" Width="200px" 
                            TextMode="Password"></asp:TextBox>
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtOldPassword" ErrorMessage="*" Font-Size="X-Small" 
                            ForeColor="#FF3300" ToolTip="Enter OldPassword" ValidationGroup="user">Enter OldPassword</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        &nbsp;</td>
                    <td class="style4">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                            ControlToValidate="txtOldPassword" CssClass="validation" Display="Dynamic" 
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
                        <strong>New Password</strong></td>
                    <td class="style4">
                        <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" 
                            Width="200px"></asp:TextBox>
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtNewPassword" ErrorMessage="*" Font-Size="X-Small" 
                            ForeColor="#FF3300" ToolTip="Enter New Password" ValidationGroup="user">Enter New Password</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        &nbsp;</td>
                    <td class="style4">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                            ControlToValidate="txtNewPassword" CssClass="validation" Display="Dynamic" 
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
                        <strong>Confirm</strong></td>
                    <td class="style4">
                        <asp:TextBox ID="txtConfirm" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="txtConfirm" ErrorMessage="*" Font-Size="X-Small" 
                            ForeColor="#FF3300" ToolTip="Enter Confirm Password" ValidationGroup="user">Enter Confirm Password</asp:RequiredFieldValidator>
                        &nbsp;<asp:CompareValidator ID="CompareValidator1" runat="server" 
                            ControlToCompare="txtNewPassword" ControlToValidate="txtConfirm" 
                            ErrorMessage="*" Font-Size="X-Small" ForeColor="#FF3300" ToolTip="Mismatch" 
                            ValidationGroup="user">Mismatch</asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        &nbsp;</td>
                    <td class="style4">
                        &nbsp;</td>
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
                            Text="Change Password" ValidationGroup="user" />
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        <br />
         
   </div>
 
 
   </asp:Panel>

</asp:Content>
