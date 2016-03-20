<%@ Page Title="" Language="C#" MasterPageFile="~/Instituciones.master" AutoEventWireup="true" CodeFile="Notificacion.aspx.cs" Inherits="Administrar_Notificacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

         <div class="row">
              <div class="col-md-12">
                  <h2 class="page-head-line">Notificaciones</h2>
                  <h1 class="page-subhead-line">Agregar, modificar o eliminar las Notificaciones del Sistema. </h1>
              </div>
           </div>
                <!-- /. ROW  -->
           <div class="row">
               <%--                                <input class="form-control" type="text">--%>
            <div class="col-md-12">
                <asp:Panel ID="pnlSucess" runat="server" class="chat-widget-left">
                    <asp:Label ID="lblSucess" runat="server" Text=""></asp:Label>
                </asp:Panel>

                <asp:Panel ID="pnlError" runat="server" class="chat-widget-right">
                    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                </asp:Panel>

               <div class="panel panel-info">
                        <div class="panel-heading">
                           Ingresar Notificación
                        </div>
                        <div class="panel-body">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Nombre</label>
                                        <asp:TextBox ID="txtNombreNotificacion" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Institución: </label>
                                        <asp:Label ID="txtInstitucion" runat="server" Text=""  class="form-control"></asp:Label>
                                            <asp:Label ID="lblInstitucionId" runat="server" Text="0" Visible="false"></asp:Label>
                                            <asp:Label ID="lblArchivoId" runat="server" Text="0" Visible="false"></asp:Label>
                                    </div>
                                 </div>

                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Descripcion</label>
                                        <asp:TextBox ID="txtDescripcionNotificacion" runat="server" class="form-control" Rows="2" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                 </div>

                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Archivo</label>
                                        <asp:FileUpload ID="upFileNotificacion" runat="server"/>
                                        <asp:Label ID="lblArchivo" runat="server"></asp:Label>
                                    </div>
                                 </div>

                                <div class="col-md-12">
                                    <asp:Button ID="btnGuardarNotificacion" runat="server" Text="Guardar Notificación" class="btn btn-info" OnClick="btnGuardarNotificacion_Click"/>
                                    <asp:Button ID="btnEditarNotificacion" runat="server" Text="Editar Notificación" class="btn btn-primary" OnClick="btnEditarNotificacion_Click"/>
                                    <asp:Button ID="btnEliminarNotificacion" runat="server" Text="Eliminar Notificación" class="btn btn-danger" OnClick="btnEliminarNotificacion_Click"/>
                                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" class="btn btn-warning" OnClick="btnCancelar_Click"/>
                                    <asp:Label ID="lblNotificacionId" runat="server" Text="0" Visible="False"></asp:Label>
                                </div>

                            </div>
                        </div>
               </div>
               <div class="col-md-12">
                  <!--   Notificaciones -->
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            Notificaciones Activas
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">

                                <asp:GridView class="table table-striped table-bordered table-hover" ID="gridNotificaciones" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gridNotificaciones_SelectedIndexChanged">
                                    <Columns>
                                        <asp:BoundField DataField="NOTIFICACIONID" HeaderText="Id" />
                                        <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" />
                                        <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripcion"/>
                                        <asp:BoundField DataField="ARCHIVO.NOMBRE" HeaderText="Archivo"/>
                                    </Columns>
                                </asp:GridView>

                            </div>
                        </div>
                    </div>
                     <!-- End  Kitchen Sink -->
                </div>



        </div>
</asp:Content>

