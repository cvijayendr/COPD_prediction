<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/Doctor.Master" AutoEventWireup="true" CodeBehind="IndividualPrediction.aspx.cs" Inherits="diseasePrediction.Doctor.IndividualPrediction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="panelAdminHome" runat="server">
 <div class="about row">
			<h2>single patient prediction using Naive bayes</h2>
           </div>
           
            <table style="width: 70%; height: 124px;" align="center">
                <tr>
                    <td class="style2">
                        &nbsp;</td>
                    <td class="style4">
                        &nbsp;</td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style2">
                        <strong>Name</strong></td>
                    <td class="style4">
                        <asp:TextBox ID="txtPatientName" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ControlToValidate="txtPatientName" ErrorMessage="*" Font-Size="X-Small" 
                            ForeColor="#FF3300" ToolTip="Enter PatientName" ValidationGroup="user">Enter PatientName</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                            ControlToValidate="txtPatientName" ErrorMessage="Only Alphabets" 
                            Font-Size="X-Small" ForeColor="Red" ToolTip="Only Alphabets" 
                            ValidationExpression="^[a-zA-Z ]*$" ValidationGroup="user"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <strong>Age</strong></td>
                    <td class="style4">
                        <asp:TextBox ID="txtAge" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                            ControlToValidate="txtAge" ErrorMessage="*" Font-Size="X-Small" 
                            ForeColor="#FF3300" ToolTip="Enter Age" ValidationGroup="user">Enter Age</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" 
                            ControlToValidate="txtAge" ErrorMessage="Only Numbers" Font-Size="X-Small" 
                            ForeColor="Red" ToolTip="Only Numbers" 
                            ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                            ValidationGroup="user"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <strong>GENDER</strong></td>
                    <td class="style4">
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem Value="1">Male</asp:ListItem>
                            <asp:ListItem Value="0">Female</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style2">
                        <strong>CP</strong></td>
                    <td class="style4">
                        <asp:TextBox ID="txtCP" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                            ControlToValidate="txtCP" ErrorMessage="*" Font-Size="X-Small" 
                            ForeColor="#FF3300" ToolTip="Enter CP" ValidationGroup="user">Enter CP</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" 
                            ControlToValidate="txtCP" ErrorMessage="Only Numbers" Font-Size="X-Small" 
                            ForeColor="Red" ToolTip="Only Numbers" 
                            ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                            ValidationGroup="user"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <strong>TRESTBPS</strong></td>
                    <td class="style4">
                        <asp:TextBox ID="txtTRESTBPS" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtTRESTBPS" ErrorMessage="*" Font-Size="X-Small" 
                            ForeColor="#FF3300" ToolTip="Enter TRESTBPS" ValidationGroup="user">Enter TRESTBPS</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" 
                            ControlToValidate="txtTRESTBPS" ErrorMessage="Only Numbers" Font-Size="X-Small" 
                            ForeColor="Red" ToolTip="Only Numbers" 
                            ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                            ValidationGroup="user"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <strong>CHOL</strong></td>
                    <td class="style4">
                        <asp:TextBox ID="txtCHOL" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                            ControlToValidate="txtCHOL" ErrorMessage="*" Font-Size="X-Small" 
                            ForeColor="#FF3300" ToolTip="Enter CHOL" ValidationGroup="user">Enter CHOL</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" 
                            ControlToValidate="txtCHOL" ErrorMessage="Only Numbers" Font-Size="X-Small" 
                            ForeColor="Red" ToolTip="Only Numbers" 
                            ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                            ValidationGroup="user"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <strong>FBS</strong></td>
                    <td class="style1">
                        <asp:TextBox ID="txtFBS" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td class="style1">
                        &nbsp;</td>
                    <td class="style1">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                            ControlToValidate="txtFBS" ErrorMessage="*" Font-Size="X-Small" 
                            ForeColor="#FF3300" ToolTip="Enter FBS" ValidationGroup="user">Enter FBS</asp:RequiredFieldValidator>
                    </td>
                    <td class="style1">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator10" 
                            runat="server" ControlToValidate="txtFBS" ErrorMessage="Only Numbers" 
                            Font-Size="X-Small" ForeColor="Red" ToolTip="Only Numbers" 
                            ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                            ValidationGroup="user"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <strong>RESTECG</strong></td>
                    <td class="style4">
                        <asp:TextBox ID="txtRESTECG" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="txtRESTECG" ErrorMessage="*" Font-Size="X-Small" 
                            ForeColor="#FF3300" ToolTip="Enter RESTECG" ValidationGroup="user">Enter RESTECG</asp:RequiredFieldValidator>
                        &nbsp;</td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator11" 
                            runat="server" ControlToValidate="txtRESTECG" ErrorMessage="Only Numbers" 
                            Font-Size="X-Small" ForeColor="Red" ToolTip="Only Numbers" 
                            ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                            ValidationGroup="user"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <strong>THALACH</strong></td>
                    <td class="style4">
                        <asp:TextBox ID="txtTHALACH" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtTHALACH" ErrorMessage="*" Font-Size="X-Small" 
                            ForeColor="#FF3300" ToolTip="Enter THALACH" ValidationGroup="user">Enter THALACH</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator12" 
                            runat="server" ControlToValidate="txtTHALACH" ErrorMessage="Only Numbers" 
                            Font-Size="X-Small" ForeColor="Red" ToolTip="Only Numbers" 
                            ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                            ValidationGroup="user"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                       <strong> EXANG</strong></td>
                    <td class="style4">
                        <asp:TextBox ID="txtEXANG" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                            ControlToValidate="txtEXANG" ErrorMessage="*" Font-Size="X-Small" 
                            ForeColor="#FF3300" ToolTip="Enter EXANG" ValidationGroup="user">Enter EXANG</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator13" 
                            runat="server" ControlToValidate="txtEXANG" ErrorMessage="Only Numbers" 
                            Font-Size="X-Small" ForeColor="Red" ToolTip="Only Numbers" 
                            ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                            ValidationGroup="user"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <strong>OLDPEAK</strong></td>
                    <td class="style4">
                        <asp:TextBox ID="txtOLDPEAK" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                            ControlToValidate="txtOLDPEAK" ErrorMessage="*" Font-Size="X-Small" 
                            ForeColor="#FF3300" ToolTip="Enter OLDPEAK" ValidationGroup="user">Enter OLDPEAK</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator14" 
                            runat="server" ControlToValidate="txtOLDPEAK" ErrorMessage="Only Numbers" 
                            Font-Size="X-Small" ForeColor="Red" ToolTip="Only Numbers" 
                            ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                            ValidationGroup="user"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <strong> SLOPE</strong></td>
                    <td class="style4">
                        <asp:TextBox ID="txtSLOPE" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                            ControlToValidate="txtSLOPE" ErrorMessage="*" Font-Size="X-Small" 
                            ForeColor="#FF3300" ToolTip="Enter SLOPE" ValidationGroup="user">Enter SLOPE</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator15" 
                            runat="server" ControlToValidate="txtSLOPE" ErrorMessage="Only Numbers" 
                            Font-Size="X-Small" ForeColor="Red" ToolTip="Only Numbers" 
                            ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                            ValidationGroup="user"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                 <tr>
                    <td class="style2">
                        <strong> CA</strong></td>
                    <td class="style4">
                        <asp:TextBox ID="txtCA" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                            ControlToValidate="txtCA" ErrorMessage="*" Font-Size="X-Small" 
                            ForeColor="#FF3300" ToolTip="Enter CA" ValidationGroup="user">Enter CA</asp:RequiredFieldValidator>
                    </td>
                     <td>
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator16" 
                             runat="server" ControlToValidate="txtCA" ErrorMessage="Only Numbers" 
                             Font-Size="X-Small" ForeColor="Red" ToolTip="Only Numbers" 
                             ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                             ValidationGroup="user"></asp:RegularExpressionValidator>
                     </td>
                </tr>
                <tr>
                    <td class="style2">
                        <strong> THAL</strong></td>
                    <td class="style4">
                        <asp:TextBox ID="txtTHAL" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" 
                            ControlToValidate="txtTHAL" ErrorMessage="*" Font-Size="X-Small" 
                            ForeColor="#FF3300" ToolTip="Enter THAL" ValidationGroup="user">Enter THAL</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator17" 
                            runat="server" ControlToValidate="txtTHAL" ErrorMessage="Only Numbers" 
                            Font-Size="X-Small" ForeColor="Red" ToolTip="Only Numbers" 
                            ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                            ValidationGroup="user"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <strong>AVGPR</strong></td>
                    <td class="style4">
                        <asp:TextBox ID="txtAVGPR" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" 
                            ControlToValidate="txtAVGPR" ErrorMessage="*" Font-Size="X-Small" 
                            ForeColor="#FF3300" ToolTip="Enter AVGPR" ValidationGroup="user">Enter AVGPR</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator18" 
                            runat="server" ControlToValidate="txtAVGPR" ErrorMessage="Only Numbers" 
                            Font-Size="X-Small" ForeColor="Red" ToolTip="Only Numbers" 
                            ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                            ValidationGroup="user"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <strong> ABGBTEMP</strong></td>
                    <td class="style4">
                        <asp:TextBox ID="txtABGBTEMP" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" 
                            ControlToValidate="txtABGBTEMP" ErrorMessage="*" Font-Size="X-Small" 
                            ForeColor="#FF3300" ToolTip="Enter ABGBTEMP" ValidationGroup="user">Enter ABGBTEMP</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator19" 
                            runat="server" ControlToValidate="txtABGBTEMP" ErrorMessage="Only Numbers" 
                            Font-Size="X-Small" ForeColor="Red" ToolTip="Only Numbers" 
                            ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                            ValidationGroup="user"></asp:RegularExpressionValidator>
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
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style2">
                        &nbsp;</td>
                    <td class="style4">
                        <asp:Button ID="btnSubmit" runat="server" Height="50px" 
                            onclick="btnSubmit_Click" Text="Predict" ValidationGroup="user" Width="100px" />
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
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
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style2">
                        &nbsp;</td>
                    <td class="style4">
                        <h2 class="title">
                            <asp:Label ID="lblResult" runat="server"></asp:Label>
                        </h2>
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
    <br />
           
   


   
   </asp:Panel>


</asp:Content>
