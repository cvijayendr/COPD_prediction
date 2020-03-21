<%@ Page Title="" Language="C#" MasterPageFile="~/Patient/Patient.Master" AutoEventWireup="true" CodeBehind="frmPatientHome.aspx.cs" Inherits="diseasePrediction.Patient.frmPatientHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style9
        {
            width: 144px;
        }
        .style10
        {
            width: 33px;
        }
        .style12
        {
            width: 146px;
        }
        .style13
        {
            font-size: large;
            text-decoration: underline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="panelAdminHome" runat="server">
 <div class="about row">
			<h2>view treatment details</h2>
           </div>

           <asp:Table ID="tableTreatment" runat="server" HorizontalAlign="Center">
                        </asp:Table>
          <br />

   </asp:Panel>
</asp:Content>
