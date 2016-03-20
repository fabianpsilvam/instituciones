<%@ Page Title="" Language="C#" MasterPageFile="~/Instituciones.master" AutoEventWireup="true" CodeFile="Materia.aspx.cs" Inherits="Materia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">


    <div class="row">
              <div class="col-md-12">
                  <h2 class="page-head-line">Materias</h2>
                  <h1 class="page-subhead-line">Agregar, modificar o eliminar las Materias del Sistema. </h1>
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
                           Ingresar Materia
                        </div>
                        <div class="panel-body">
                                <div class="form-group">
                                    <label>Nombre</label>
                                    <asp:TextBox ID="txtNombreMateria" runat="server" class="form-control"></asp:TextBox>
<%--                                <input class="form-control" type="text">--%>
                                    <p class="help-block">Nombre de la Materia.</p>
                                </div>

                                <div class="form-group">
                                    <label>Puntos</label>
                                    <asp:TextBox ID="txtPuntos" runat="server" class="form-control"></asp:TextBox>
                                    <p class="help-block">Puntos de la Materia</p>
                                </div>

                                <div class="form-group">
                                    <label>Periodo</label>
                                    <asp:DropDownList ID="cbPeriodo" runat="server" class="form-control">
                                    </asp:DropDownList>
                                    <p class="help-block">Periodo de la Materia</p>
                                </div>

                                <asp:Button ID="btnGuardarMateria" runat="server" Text="Guardar Materia" class="btn btn-info" OnClick="btnGuardarMateria_Click"/>
                                <asp:Button ID="btnEditarMateria" runat="server" Text="Editar Materia" class="btn btn-primary" OnClick="btnEditarMateria_Click"/>  
                                <asp:Button ID="btnEliminarMateria" runat="server" Text="Eliminar Materia" class="btn btn-danger" OnClick="btnEliminarMateria_Click"/>  
                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" class="btn btn-warning" OnClick="btnCancelar_Click"/>  
                                <asp:Label ID="lblMateriaId" runat="server" Text="0" Visible="False"></asp:Label>
                                <asp:Label ID="lblInstitucionId" runat="server" Text="0" Visible="False"></asp:Label>
                            </div>
                        </div>
               </div>
               <div class="col-md-6">
                  <!--   Materiaes -->
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            Materias Activas
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">

                                <asp:GridView class="table table-striped table-bordered table-hover" ID="gridMaterias" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gridMateriaes_SelectedIndexChanged">
                                    <Columns>
                                        <asp:BoundField DataField="MATERIAID" HeaderText="Id" />
                                        <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" />
                                        <asp:BoundField DataField="PUNTOS" HeaderText="Puntos" />
                                    </Columns>
                                </asp:GridView>

                            </div>
                        </div>
                    </div>
                     <!-- End  Kitchen Sink -->
                </div>

        </div>


</asp:Content>

