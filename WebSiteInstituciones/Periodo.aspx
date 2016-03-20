<%@ Page Title="" Language="C#" MasterPageFile="~/Instituciones.master" AutoEventWireup="true" CodeFile="Periodo.aspx.cs" Inherits="Periodo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">


    <div class="row">
              <div class="col-md-12">
                  <h2 class="page-head-line">Periodo</h2>
                  <h1 class="page-subhead-line">Agregar, modificar o eliminar las Periodos del Sistema. </h1>
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
                           Ingresar Periodo
                        </div>
                        <div class="panel-body">
                                <div class="form-group">
                                    <label>Nombre</label>
                                    <asp:TextBox ID="txtNombrePeriodo" runat="server" class="form-control"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <div id='datetimepicker1'>
                                        <label>Fecha de Inicio</label>
                                        <asp:TextBox ID="txtFechaInicio" runat="server" class="form-control" type="date"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div id='datetimepicker2'>
                                        <label>Fecha de Fin</label>
                                        <asp:TextBox ID="txtFechaFin" runat="server" class="form-control" type="date"></asp:TextBox>
                                    </div>
                                </div>

                                <asp:Button ID="btnGuardarPeriodo" runat="server" Text="Guardar Periodo" class="btn btn-info" OnClick="btnGuardarPeriodo_Click"/>
                                <asp:Button ID="btnEditarPeriodo" runat="server" Text="Editar Periodo" class="btn btn-primary" OnClick="btnEditarPeriodo_Click"/>  
                                <asp:Button ID="btnEliminarPeriodo" runat="server" Text="Eliminar Periodo" class="btn btn-danger" OnClick="btnEliminarPeriodo_Click"/>  
                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" class="btn btn-warning" OnClick="btnCancelar_Click"/>  
                                <asp:Label ID="lblPeriodoId" runat="server" Text="0" Visible="False"></asp:Label>
                                <asp:Label ID="lblInstitucionId" runat="server" Text="0" Visible="False"></asp:Label>
                            </div>
                        </div>
               </div>
               <div class="col-md-6">
                  <!--   Periodoes -->
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            Periodos Activos
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">

                                <asp:GridView class="table table-striped table-bordered table-hover" ID="gridPeriodos" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gridPeriodos_SelectedIndexChanged">
                                    <Columns>
                                        <asp:BoundField DataField="PERIDODOID" HeaderText="Id" />
                                        <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" />
                                        <asp:BoundField DataField="FECHAINICIO" HeaderText="F. Inicio" />
                                        <asp:BoundField DataField="FECHAFIN" HeaderText="F. Fin" />
                                    </Columns>
                                </asp:GridView>

                            </div>
                        </div>
                    </div>
                     <!-- End  Kitchen Sink -->
                </div>

        </div>



</asp:Content>

