<%@ Page Title="" Language="C#" MasterPageFile="~/Instituciones.master" AutoEventWireup="true" CodeFile="Institucion.aspx.cs" Inherits="Institution" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
           <div class="row">
              <div class="col-md-12">
                  <h2 class="page-head-line">Instituciones</h2>
                  <h1 class="page-subhead-line">Agregar, modificar o eliminar las Instituciones del Sistema. </h1>
              </div>
           </div>
                <!-- /. ROW  -->
           <div class="row">
            <%--<div class="col-md-6 col-sm-6 col-xs-12">--%>
            <div class="col-md-6">

                
                <asp:Panel ID="pnlSucess" runat="server" class="chat-widget-left">
                    <asp:Label ID="lblSucess" runat="server" Text=""></asp:Label>
                </asp:Panel>

                <asp:Panel ID="pnlError" runat="server" class="chat-widget-right">
                    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                </asp:Panel>


               <div class="panel panel-info">
                        <div class="panel-heading">
                           Ingresar Institución
                        </div>
                        <div class="panel-body">
                                <div class="form-group">
                                    <label>Nombre</label>
                                    <asp:TextBox ID="txtNombreInstitucion" runat="server" class="form-control"></asp:TextBox>
<%--                                <input class="form-control" type="text">--%>
                                    <p class="help-block">Nombre de la Institución.</p>
                                </div>
                                <asp:Button ID="btnGuardarInstitucion" runat="server" Text="Guardar Institución" class="btn btn-info" OnClick="btnGuardarInstitucion_Click"/>  


                                <asp:Button ID="btnEditarInstitucion" runat="server" Text="Editar Institución" class="btn btn-primary" OnClick="btnEditarInstitucion_Click"/>  
                                <asp:Button ID="btnEliminarInstitucion" runat="server" Text="Eliminar Institución" class="btn btn-danger" OnClick="btnEliminarInstitucion_Click"/>  
                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" class="btn btn-warning" OnClick="btnCancelar_Click"/>  
                                <%--<button type="submit" class="btn btn-info">Guardar Institución </button>--%>
                                <asp:Label ID="lblInstitucionId" runat="server" Text="0" Visible="False"></asp:Label>
                                <asp:Label ID="lblInstitucionIdLogeado" runat="server" Text="0" Visible="False"></asp:Label>
                            </div>
                        </div>
               </div>
               <div class="col-md-6">
                  <!--   Instituciones -->
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            Instituciones Activas
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">

                                <asp:GridView class="table table-striped table-bordered table-hover" ID="gridInstituciones" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gridInstituciones_SelectedIndexChanged">
                                    <Columns>
                                        <asp:BoundField DataField="INSTITUCIONID" HeaderText="Id" />
                                        <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" />
                                    </Columns>
                                </asp:GridView>

                            </div>
                        </div>
                    </div>
                     <!-- End  Kitchen Sink -->
                </div>

        </div>
</asp:Content>

