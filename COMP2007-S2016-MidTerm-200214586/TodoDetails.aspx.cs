//Using namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//Using for connect to EF
using COMP2007_S2016_MidTerm_200214586.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;

/**
 * @author: Matthew Lane
 * @date: June 23th, 2016
 * @page: This page allows adding a new toDo note or editing a current one 
 */
namespace COMP2007_S2016_MidTerm_200214586
{
    public partial class TodoDetails : System.Web.UI.Page
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
         /*
            // get the id from the URL
            int itemID = Convert.ToInt32(Request.QueryString["Id"]);

            if (itemID != 0)
            {
                //Connect to the DB and get the users info
                using (TodoConnection db = new TodoConnection())
                {
                    var updatedToDo = (from toDo in db.Todos
                                       where toDo.TodoID == itemID
                                       select toDo).FirstOrDefault();

                    if (updatedToDo != null)
                    {
                        TodoNameTextBox.Text = updatedToDo.TodoName;
                        NotesTextBox.Text = updatedToDo.TodoNotes;
                    }
                }
            }
            */
        }

        /**
        * <summary>
        * This method is called when the cancel button is pressed, it redirects back to the main page
        * </summary>
        * 
        * @method CancelButton_Click
        * @param {object} sender
        * @param {GridViewPageEventArgs} e
        * @returns {void}
        */
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            //Redirect to user page
            Response.Redirect("~/TodoList.aspx");
        }

        /**
        * <summary>
        * This method is called when the save button is pressed, it edits a user, or creates a new one
        * </summary>
        * 
        * @method SaveButton_Click
        * @param {object} sender
        * @param {GridViewPageEventArgs} e
        * @returns {void}
        */
        protected void SaveButton_Click(object sender, EventArgs e)
        {
            //Connect to the database 
            using (TodoConnection db = new TodoConnection())
            {
                // use the Student model to create a new student object and save a new record
                Todo toDo = new Todo();

                // get the id from the URL
                int itemID = Convert.ToInt32(Request.QueryString["Id"]);

                if (Request.QueryString.Count > 0) // our URL has this GameID in it (edit mode)
                {
                   
                    // get the current student from EF DB
                    toDo = (from toBeDone in db.Todos
                            where toBeDone.TodoID == itemID
                            select toBeDone).FirstOrDefault();
                }

                toDo.TodoName = TodoNameTextBox.Text;
                toDo.TodoNotes = NotesTextBox.Text;


                // use LINQ to ADO.NET to add / insert new student into the database
                if (itemID == 0)
                {
                    db.Todos.Add(toDo);
                }

                // save our changes - also updates and inserts
                db.SaveChanges();

                // Redirect back to the updated students page
                Response.Redirect("~/TodoList.aspx");
            }
        }
    }
}