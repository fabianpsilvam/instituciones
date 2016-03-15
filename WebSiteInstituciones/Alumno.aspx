<%@ Page Title="" Language="C#" MasterPageFile="~/Instituciones.master" AutoEventWireup="true" CodeFile="Alumno.aspx.cs" Inherits="Alumno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">


    <div class="row">
                  <div class="col-md-12">                     
         <div class="panel panel-default">
            <div class="panel-heading">
                  Alumnos
            </div>
            <div class="panel-body">
                <asp:Panel ID="pnlSucess" runat="server" class="chat-widget-left">
                    <asp:Label ID="lblSucess" runat="server" Text=""></asp:Label>
                </asp:Panel>

                <asp:Panel ID="pnlError" runat="server" class="chat-widget-right">
                    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                </asp:Panel>

                <div id="wizard">
                    <h2>Alumno</h2>
                        <section>
                    
                 <%--                <div class="row">
              <div class="col-md-12">
                  <h2 class="page-head-line">Profesores</h2>
                  <h1 class="page-subhead-line">Agregar, modificar o eliminar las Profesores del Sistema. </h1>
              </div>
           </div>--%>
                <!-- /. ROW  -->
           <div class="row">
               <%--                                <input class="form-control" type="text">--%>
            <div class="col-md-12">
               <div class="panel panel-info">
                        <div class="panel-heading">
                           Ingresar Alumno
                        </div>
                        <div class="panel-body">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Nombre</label>
                                        <asp:TextBox ID="txtNombreAlumno" runat="server" class="form-control"></asp:TextBox>
                                        <p class="help-block">Nombre del Alumno</p>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Apellido</label>
                                        <asp:TextBox ID="txtApellidoAlumno" runat="server" class="form-control"></asp:TextBox>
                                        <p class="help-block">Apellido del Alumno</p>
                                    </div>
                                </div>

                            <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Cedula</label>
                                        <asp:TextBox ID="txtCedulaAlumno" runat="server" class="form-control" onkeypress='validate(event)'></asp:TextBox>
                                        <p class="help-block">Cedula del Alumno</p>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Genero</label>
                                        <asp:DropDownList ID="cbGenero" runat="server" class="form-control">
                                            <asp:ListItem Value="M">Masculino</asp:ListItem>
                                            <asp:ListItem Value="F">Femenino</asp:ListItem>
                                        </asp:DropDownList>                                        
                                        <p class="help-block">Genero del Alumno</p>
                                    </div>
                                </div>
                                <asp:Label ID="lblInstitucionId" runat="server" Text="0" Visible="false"></asp:Label>

                                <div class="col-md-6">
                                    <div class="form-group">
                                        <div id='datetimepicker1'>
                                            <label>Fecha de Nacimiento</label>
                                            <asp:TextBox ID="txtFechaNacimientoAlumno" runat="server" class="form-control" type="date"></asp:TextBox>
                                        <p class="help-block">Fecha de Nacimiento</p>
                                        </div>
                                    </div>
                                 </div>

                            </div>
                        </div>
               </div>
        </div>

                </section>

                <h2>Tutor</h2>
                <section>
                    
                    <div class="panel panel-info">
                        <div class="panel-heading">
                           Ingresar Tutor
                        </div>
                        <div class="panel-body">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Nombre</label>
                                        <asp:TextBox ID="txtNombreTutor" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Apellido</label>
                                        <asp:TextBox ID="txtApellidoTutor" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                </div>

                            <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Cedula</label>
                                         <asp:TextBox ID="txtCedulaTutor" runat="server" class="form-control" onkeypress='validate(event)'></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Genero</label>
                                        <asp:DropDownList ID="cdGenero" runat="server" class="form-control">
                                            <asp:ListItem Value="M">Masculino</asp:ListItem>
                                            <asp:ListItem Value="F">Femenino</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <asp:Label ID="Label1" runat="server" Text="0" Visible="false"></asp:Label>

                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Usuario</label>
                                        <asp:TextBox ID="txtUsuarioTutor" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Clave</label>
                                        <asp:TextBox ID="txtClaveTutor" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="form-group">
                                        <div id='datetimepicker1'>
                                            <label>Fecha de Nacimiento</label>
                                            <asp:TextBox ID="txtFechaNacimientoTutor" runat="server" class="form-control" type="date"></asp:TextBox>
                                        </div>
                                    </div>
                                 </div>

                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Perfil</label>
                                        <asp:DropDownList ID="cbPerfil" runat="server" class="form-control">
                                            <asp:ListItem Value="1">Normal</asp:ListItem>
                                            <asp:ListItem Value="2">Administrador</asp:ListItem>
                                        </asp:DropDownList>
                                        <p class="help-block">Perfil de Usuario</p>
                                    </div>
                                </div>

                            </div>
                        </div>

                </section>
            </div>


                
               <div class="col-md-12">
                    <asp:Button ID="btnGuardarAlumno" runat="server" Text="Guardar Alumno" class="btn btn-info" OnClick="btnGuardarAlumno_Click"/>
                    <asp:Button ID="btnEditarAlumno" runat="server" Text="Editar Alumno" class="btn btn-primary" OnClick="btnEditarAlumno_Click"/>
                    <asp:Button ID="btnEliminarAlumno" runat="server" Text="Eliminar Alumno" class="btn btn-danger" OnClick="btnEliminarProfesor_Click"/>
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" class="btn btn-warning" OnClick="btnCancelar_Click"/>
                    <asp:Label ID="lblProfesorId" runat="server" Text="0" Visible="False"></asp:Label>
                    <asp:Label ID="lblUsuarioId" runat="server" Text="0" Visible="False"></asp:Label>
                </div>

               <div class="col-md-12">
                  <!--   Profesores -->
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            Profesores Activos
                        </div>
                        <div class="panel-body">
                            <div class="table-responsive">

                                <asp:GridView class="table table-striped table-bordered table-hover" ID="gridAlumnos" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gridAlumnos_SelectedIndexChanged">
                                    <Columns>
                                        <asp:BoundField DataField="PROFESORID" HeaderText="Id" />
                                        <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" />
                                        <asp:BoundField DataField="APELLIDO" HeaderText="apellido"/>
                                        <asp:BoundField DataField="CEDULA" HeaderText="Descripcion"/>
                                    </Columns>
                                </asp:GridView>

                            </div>
                        </div>
                    </div>
                     <!-- End  Kitchen Sink -->
                </div>
                             
                        </div>
                    </div>
                 </div>
                </div>


</asp:Content>

