using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using COMP2007_S2016_MidTerm_200214586.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;

namespace COMP2007_S2016_MidTerm_200214586
{
    public partial class TodoList : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            // if loading the page for the first time, populate the grid
            if (!IsPostBack)
            {
                // Get the game data
                this.GetList();
            }
        }

        protected void GetList()
        {
            // connect to EF
            using (TodoConnection db = new TodoConnection())
            {
                // query the games Table for the football scores using EF and LINQ
                var Todos = (from allItems in db.Todos select allItems);

                // bind the result to the GridView
                ToDoGridView.DataSource = Todos.ToList();
                ToDoGridView.DataBind();
            }
        }


        protected void ToDoGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // store which row was clicked
            int selectedRow = e.RowIndex;

            // get the selected StudentID using the Grid's DataKey collection
            int itemID = Convert.ToInt32(ToDoGridView.DataKeys[selectedRow].Values["TodoID"]);

            using (TodoConnection db = new TodoConnection())
            {
                // create object of the Student class and store the query string inside of it
                var deletedItem = (from allItems in db.Todos
                                   where allItems.TodoID == itemID
                                   select allItems).FirstOrDefault();

                // remove the selected student from the db
                db.Todos.Remove(deletedItem);

                // save my changes back to the database
                db.SaveChanges();

                // refresh the grid
                this.GetList();
            }

        }
   

    }
}