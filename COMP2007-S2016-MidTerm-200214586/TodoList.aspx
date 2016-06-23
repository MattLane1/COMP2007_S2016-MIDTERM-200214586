<%@ Page Title="Todo List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodoList.aspx.cs" Inherits="COMP2007_S2016_MidTerm_200214586.TodoList" %>

<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-offset-2 col-md-8"></div>
            <h1>Games List</h1>
            <a href="ToDoDetails.aspx" class="btn btn-success btn-sm"><i class="fa fa-plus"></i>Add Game </a>

        </div>
    </div>
    <h4>To Do List</h4>

    <div>
        <label for="PageSizeDropDownList">Records per Page: </label>
        <asp:DropDownList ID="PageSizeDropDownList" runat="server"
            AutoPostBack="true" CssClass="btn btn-default bt-sm dropdown-toggle"
            OnSelectedIndexChanged="PageSizeDropDownList_SelectedIndexChanged">
            <asp:ListItem Text="3" Value="3" />
            <asp:ListItem Text="5" Value="5" />
            <asp:ListItem Text="10" Value="10" />
            <asp:ListItem Text="All" Value="10000" />
        </asp:DropDownList>
    </div>

    <asp:GridView runat="server" CssClass="table table-bordered table-striped table-hover" ID="ToDoGridView" DataKeyNames="TodoID" OnRowDeleting="ToDoGridView_RowDeleting"
        AutoGenerateColumns="false" AllowPaging="true" PageSize="3"
        OnPageIndexChanging="ToDoGridView_PageIndexChanging" AllowSorting="true" OnSorting="ToDoGridView_Sorting"
        OnRowDataBound="ToDoGridView_RowDataBound" PagerStyle-CssClass="pagination-ys">
        <Columns>
            <asp:BoundField runat="Server" DataField="TodoID" HeaderText="To do ID" Visible="true" />
            <asp:BoundField runat="Server" DataField="TodoName" HeaderText="To do Name" Visible="true" />
            <asp:BoundField runat="Server" DataField="TodoNotes" HeaderText="To do Notes" Visible="true" />
            <asp:BoundField runat="Server" DataField="Completed" HeaderText="Completed to do items" Visible="true" />

            <asp:HyperLinkField HeaderText="Edit" Text="<i class='fa fa-pencil-square-o fa-lg'></i> Edit" NavigateUrl="~/TodoDetails.aspx"
                DataNavigateUrlFields="TodoID" DataNavigateUrlFormatString="TodoDetails.aspx?Id={0}"
                ControlStyle-CssClass="btn btn-primary btn-sm" />

            <asp:CommandField HeaderText="Delete" DeleteText="Delete" ShowDeleteButton="true" ButtonType="Link"
                ControlStyle-CssClass="btn btn-danger btn-sm" />


        </Columns>
    </asp:GridView>

</asp:Content>


