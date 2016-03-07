<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="auto-style6" style="text-align: center">&nbsp;</td>
            <td class="auto-style8" colspan="3" style="text-align: center">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6" style="text-align: center"></td>
            <td class="auto-style8" colspan="3" style="text-align: center"></td>
        </tr>
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style4" colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style7">
                <asp:Label ID="Label1" runat="server" CssClass="labelsLeft" Font-Size="X-Large" Text="Renovación"></asp:Label>
            </td>
            <td class="auto-style4" colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style4" colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style7">
                <asp:Label ID="Label2" runat="server" class="labels" Text="Número de Solicitud:"></asp:Label>
            </td>
            <td class="auto-style4" colspan="2">
                <asp:TextBox ID="txtCertificado" runat="server" CssClass="twitterStyleTextbox" MaxLength="200" Width="290px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style7">
                <asp:Label ID="Label6" runat="server" class="labels" Text="Cédula"></asp:Label>
            </td>
            <td class="auto-style4" colspan="2">
                <asp:TextBox ID="txtCedula" runat="server" CssClass="twitterStyleTextbox" MaxLength="100" Width="290px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style7">
                <asp:Label ID="Label7" runat="server" class="labels" Text="Password"></asp:Label>
            </td>
            <td class="auto-style4" colspan="2">
                <asp:TextBox ID="txtPassword" runat="server" CssClass="twitterStyleTextbox" MaxLength="100" TextMode="Password" Width="290px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style4" colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style7">
                <asp:Label ID="lblCliente" runat="server" Text="0" Visible="False"></asp:Label>
                <asp:Label ID="lblCertificado" runat="server" Text="0" Visible="False"></asp:Label>
                <asp:Label ID="lblSolicitud" runat="server" Text="0" Visible="False"></asp:Label>
            </td>
            <td class="auto-style1" colspan="2">
                <asp:Label ID="lblMensaje" runat="server" class="labels" ForeColor="#FF3300"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style9">
                <asp:Button ID="btnRenovarCertificado" runat="server" CssClass="roundCornerGreen" OnClick="btnDescargarCertificado_Click" Text="Renovar Certificado" />
            </td>
            <td class="auto-style1">
                <asp:Button ID="btnCancelar" runat="server" CssClass="roundCornerBlue" OnClick="btnCancelar_Click" Text="Cancelar/Borrar" />
            </td>
        </tr>
    </table>
</asp:Content>

