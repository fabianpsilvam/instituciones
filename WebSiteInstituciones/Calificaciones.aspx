<%@ Page Title="" Language="C#" MasterPageFile="~/Instituciones.master" AutoEventWireup="true" CodeFile="Calificaciones.aspx.cs" Inherits="Calificaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">


    <div class="row">
              <div class="col-md-12">
                  <h2 class="page-subhead-line">Calificaciones</h2>
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
                           Ingresar Calificaciones
                        </div>
                        <div class="panel-body">
                                
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Curso</label>
                                        <asp:DropDownList ID="cbCurso" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="cbCurso_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Paralelo</label>
                                        <asp:DropDownList ID="cbParalelo" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="cbParalelo_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Materia</label>
                                        <asp:DropDownList ID="cbMateria" runat="server" class="form-control">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Periodo</label>
                                        <asp:DropDownList ID="cbPeriodo" runat="server" class="form-control">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label>Alumno</label>
                                        <asp:TextBox ID="txtAlumno" runat="server" class="form-control">
                                        </asp:TextBox>
                                    </div>
                                </div>
                                
                        <asp:Button ID="btnBuscarCalificacion" runat="server" Text="Buscar" class="btn btn-info" OnClick="btnBuscarCalificacion_Click"/>
                            </div>
                        </div>
                
                </div>
               <div class="col-md-12">
                  <!--   Calificaciones -->
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            Calificar
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">

                                <asp:GridView class="table table-striped table-bordered table-hover" ID="gridCalificaciones" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gridCalificaciones_SelectedIndexChanged">
                                    <Columns>
                                        <asp:BoundField DataField="CALIFICACIONID" HeaderText="Id" />
                                        <asp:BoundField DataField="NOMBRELARGO" HeaderText="Alumno" />
                                        <asp:BoundField DataField="NOMBREMATERIA" HeaderText="Materia" />

                                        <asp:TemplateField HeaderText="Parcial 1" ItemStyle-Width="10">
                                            <ItemTemplate>
                                                <asp:TextBox Width="30" style="text-align:center" ID="txtParcial1" runat="server" Text='<%# Eval("PARCIAL1") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Parcial 2" ItemStyle-Width="10">
                                            <ItemTemplate>
                                                <asp:TextBox Width="30" style="text-align:center" ID="txtParcial2" runat="server" Text='<%# Eval("PARCIAL2") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Parcial 3" ItemStyle-Width="10">
                                            <ItemTemplate>
                                                <asp:TextBox Width="30" style="text-align:center" ID="txtParcial3" runat="server" Text='<%# Eval("PARCIAL3") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="VALOR" HeaderText="Promedio" />

                                        <asp:TemplateField HeaderText="Observacion" ItemStyle-Width="10">
                                            <ItemTemplate>
                                                <asp:TextBox Width="100" style="text-align:center" ID="txtObservacion" runat="server" Text='<%# Eval("OBSERVACION") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        
                                    </Columns>
                                    
                                </asp:GridView>

                            </div>
                        </div>
                    </div>
                     <!-- End  Kitchen Sink -->
                </div>
                <div class="col-md-12">
                    <asp:Button ID="btnGuardarCalificaciones" runat="server" Text="Guardar Califiaciones" class="btn btn-info" OnClick="btnGuardarCalificacion_Click"/>
                    <asp:Label ID="lblCalificacionId" runat="server" Text="0" Visible="False"></asp:Label>
                    <asp:Label ID="lblUsuarioId" runat="server" Text="0" Visible="False"></asp:Label>
                    <asp:Label ID="lblInstitucionId" runat="server" Text="0" Visible="false"></asp:Label>
                </div>

        </div>


</asp:Content>

