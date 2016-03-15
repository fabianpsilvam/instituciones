<%@ Page Title="" Language="C#" MasterPageFile="~/Instituciones.master" AutoEventWireup="true" CodeFile="Actividad.aspx.cs" Inherits="Administrar_Actividad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

    <div class="row">
              <div class="col-md-12">
                  <h2 class="page-head-line">Actividades</h2>
                  <h1 class="page-subhead-line">Agregar, modificar o eliminar las Actividades del Sistema. </h1>
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
                           Ingresar Actividad
                        </div>
                        <div class="panel-body">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Nombre</label>
                                        <asp:TextBox ID="txtNombreActividad" runat="server" class="form-control"></asp:TextBox>
                                        <p class="help-block">Nombre de la Actividad.</p>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Institución: </label>
                                        <asp:Label ID="txtInstitucion" runat="server" Text=""  class="form-control"></asp:Label>
                                        <p class="help-block">
                                            <asp:Label ID="lblInstitucionId" runat="server" Text="0" Visible="true"></asp:Label>
                                            Institución.</p>
                                    </div>
                                 </div>

                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Descripcion</label>
                                        <asp:TextBox ID="txtDescripcionActividad" runat="server" class="form-control" Rows="2" TextMode="MultiLine"></asp:TextBox>
                                        <p class="help-block">Descripción de la Actividad.</p>
                                    </div>
                                 </div>

                                <div class="col-md-12">
                                    <asp:Button ID="btnGuardarActividad" runat="server" Text="Guardar Actividad" class="btn btn-info" OnClick="btnGuardarActividad_Click"/>
                                    <asp:Button ID="btnEditarActividad" runat="server" Text="Editar Actividad" class="btn btn-primary" OnClick="btnEditarActividad_Click"/>
                                    <asp:Button ID="btnEliminarActividad" runat="server" Text="Eliminar Actividad" class="btn btn-danger" OnClick="btnEliminarActividad_Click"/>
                                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" class="btn btn-warning" OnClick="btnCancelar_Click"/>
                                    <asp:Label ID="lblActividadId" runat="server" Text="0" Visible="False"></asp:Label>
                                </div>

                            </div>
                        </div>
               </div>
               <div class="col-md-12">
                  <!--   Actividades -->
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            Actividades Activas
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">

                                <asp:GridView class="table table-striped table-bordered table-hover" ID="gridActividades" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gridActividades_SelectedIndexChanged">
                                    <Columns>
                                        <asp:BoundField DataField="ACTIVIDADID" HeaderText="Id" />
                                        <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" />
                                        <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripcion"/>
                                    </Columns>
                                </asp:GridView>

                            </div>
                        </div>
                    </div>
                     <!-- End  Kitchen Sink -->
                </div>

        </div>



</asp:Content>

