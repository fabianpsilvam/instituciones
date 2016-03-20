<%@ Page Title="" Language="C#" MasterPageFile="~/Instituciones.master" AutoEventWireup="true" CodeFile="Curso.aspx.cs" Inherits="Curso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">


    <div class="row">
              <div class="col-md-12">
                  <h2 class="page-head-line">Cursos</h2>
                  <h1 class="page-subhead-line">Agregar, modificar o eliminar las Cursos del Sistema. </h1>
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
                           Ingresar Curso
                        </div>
                        <div class="panel-body">
                                <div class="form-group">
                                    <label>Nombre</label>
                                    <asp:TextBox ID="txtNombreCurso" runat="server" class="form-control"></asp:TextBox>
<%--                                <input class="form-control" type="text">--%>
                                    <p class="help-block">Nombre del Curso.</p>
                                </div>

                                <div class="form-group">
                                    <label>Paralelo</label>
                                    <asp:DropDownList ID="cbParalelo" runat="server" class="form-control">
                                    </asp:DropDownList>
                                    <p class="help-block">Paralelo de la Curso</p>
                                </div>

                                <asp:Button ID="btnGuardarCurso" runat="server" Text="Guardar Curso" class="btn btn-info" OnClick="btnGuardarCurso_Click"/>
                                <asp:Button ID="btnEditarCurso" runat="server" Text="Editar Curso" class="btn btn-primary" OnClick="btnEditarCurso_Click"/>  
                                <asp:Button ID="btnEliminarCurso" runat="server" Text="Eliminar Curso" class="btn btn-danger" OnClick="btnEliminarCurso_Click"/>  
                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" class="btn btn-warning" OnClick="btnCancelar_Click"/>  
                                <asp:Label ID="lblCursoId" runat="server" Text="0" Visible="False"></asp:Label>
                                <asp:Label ID="lblInstitucionId" runat="server" Text="0" Visible="False"></asp:Label>
                            </div>
                        </div>
               </div>
               <div class="col-md-6">
                  <!--   Cursoes -->
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            Cursos Activas
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">

                                <asp:GridView class="table table-striped table-bordered table-hover" ID="gridCursos" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gridCursoes_SelectedIndexChanged">
                                    <Columns>
                                        <asp:BoundField DataField="CursoID" HeaderText="Id" />
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

