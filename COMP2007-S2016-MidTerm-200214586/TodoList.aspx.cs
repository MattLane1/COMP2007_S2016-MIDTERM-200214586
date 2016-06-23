//Using namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//Usings needed for EF
using COMP2007_S2016_MidTerm_200214586.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;

/**
 * @author: Matthew Lane
 * @date: June 20th, 2016
 * @page: This page holds the gridview for the main list of todo's
 */

namespace COMP2007_S2016_MidTerm_200214586
{
    public partial class TodoList : System.Web.UI.Page
    {
        /**
        * <summary>
        * This method is called when the page is displayed, if it is the first time, it gets the users info
        * If user info exists, then it populats the edit controls with it
        * </summary>
        * 
        * @method Page_Load
        * @param {object} sender
        * @param {GridViewPageEventArgs} e
        * @returns {void}
        */
        protected void Page_Load(object sender, EventArgs e)
        {
            // if loading the page for the first time, populate the grid
            if (!IsPostBack)
            {
                // Get the game data
                this.GetList();
            }
        }

        /**
          * <summary>
          * This method gets the information about the current, or selected, user
          * </summary>
          * 
          * @method GetList
          * @returns {void}
          */
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

        /**
        * <summary>
        * This method is called when a user deletes a toDo item
        * </summary>
        * 
        * @method SaveButton_Click
        * @param {object} sender
        * @param {GridViewPageEventArgs} e
        * @returns {void}
        */
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

        protected void ToDoGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Set the new page number
            ToDoGridView.PageIndex = e.NewPageIndex;

            // Refresh the grid
            this.GetList();
        }

        protected void ToDoGridView_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void ToDoGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void PageSizeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set the new Page size
            ToDoGridView.PageSize = Convert.ToInt32(PageSizeDropDownList.SelectedValue);

            this.GetList();
        }
    }
}