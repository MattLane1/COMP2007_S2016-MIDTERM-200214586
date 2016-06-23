//Using namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/**
 * @author: Matthew Lane
 * @date: June 20th, 2016
 * @page: This page is the landing screen for the website
 */
namespace COMP2007_S2016_MidTerm_200214586
{
    public partial class Default : System.Web.UI.Page
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

        }
    }
}