﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eCommerceDBModel;

public partial class ProfileMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (eCommerceDBEntities context = new eCommerceDBEntities())
        {
            if (Session["CustomerID"] != null)
            {
                //Getting user info based on session variable
                int id = (int)Session["CustomerID"];
                Customer cust = context.Customers.Where(i => i.CustomerID == id).FirstOrDefault();

                if (cust.UserType == "admin")
                {
                    Panel1.Visible = true;
                }
            }
            else
            {
                Response.Redirect("~/Home.aspx");
            }

        }
    }
}
