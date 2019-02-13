﻿<%@ Page Language="C#" Inherits="VIEW.Pages.FuncionarioLista" %>
<!DOCTYPE html>
<html>
    <head runat="server">
        <title>Lista Pai</title>
        <link type="text/css" rel="stylesheet" href="../Content/bootstrap.css" />
        <style>
            .posicaoButton{
                margin-top: 20px;
            }
        </style>
        
    </head>
    <body>
        <div class="container">
          <!-- #include file ="../menu.inc" -->
          
            <form id="principal" runat="server" class="form-horizontal">
                
                <div class="form-group">
                   <div class="col-lg-10">
                    <div class="input-group">
                      <asp:Textbox runat="server" id="codigoRegistro" autocomplete="off" placeholder="Digite o codigo do Funcionario..." CssClass="form-control"/>
                      <span class="input-group-btn">
                        <asp:Button UseSubmitBehavior="false" runat="server" id="btnPesquisar" Text="Pesquisar" CssClass="btn btn-default" OnClick="btnPesquisarFuncionario"/>
                      </span>
                    </div>
                  </div>
                </div>
                <div class="form-group">
                   <div class="col-lg-10">
                    <asp:GridView runat="server"   AutoGenerateColumns="false" id="gridListaFuncionario" CssClass="table table-bordered table-hover">
                    <Columns>
                        <asp:BoundField DataField="codigoRegistro" HeaderText="Registro" />
                        <asp:BoundField DataField="nome" HeaderText="Funcionario">
                        <ItemStyle Width="60%"> </ItemStyle>
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
                        </div>
                  </div>
            </form> 
            
          
        </div> 
        <script src="../Scripts/jquery-1.9.1.js"></script>
        <script src="../Scripts/bootstrap.js"></script>
    </body>
</html>