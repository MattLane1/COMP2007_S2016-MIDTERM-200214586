<%@ Page Title="Todo Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodoDetails.aspx.cs" Inherits="COMP2007_S2016_MidTerm_200214586.TodoDetails" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">

            <div class="col-md-offset-4 col-md-4">

                <div class="form-group">
                    <label class="control-label" for="TodoNameTextBox">To Do:</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="TodoNameTextBox" placeholder="Todo" required="true" TabIndex="0"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label class="control-label" for="NotesTextBox">Notes:</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="NotesTextBox" placeholder="Notes" required="true" TabIndex="0"></asp:TextBox>
                </div>

                <div class="text-right">
                    <asp:CheckBox Text="Completed" ID="CompletedCheck" runat="server" />
                </div>

                <div class="text-right">
                    <asp:Button Text="Cancel" ID="CancelButton" runat="server" CssClass="btn btn-warning" OnClick="CancelButton_Click" UseSubmitBehavior="false" CausesValidation="false" TabIndex="0" />
                    <asp:Button Text="Save" ID="SaveButton" runat="server" CssClass="btn btn-primary" OnClick="SaveButton_Click" TabIndex="0" />
                </div>

            </div>

        </div>
    </div>
</asp:Content>
