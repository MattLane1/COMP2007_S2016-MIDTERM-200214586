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
    public partial class TodoDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            //Redirect to user page
            Response.Redirect("~/TodoList.aspx");
        }

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