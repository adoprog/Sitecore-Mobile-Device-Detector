/* *********************************************************************
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0.
 * 
 * If a copy of the MPL was not distributed with this file, You can obtain
 * one at http://mozilla.org/MPL/2.0/.
 * 
 * This Source Code Form is “Incompatible With Secondary Licenses”, as
 * defined by the Mozilla Public License, v. 2.0.
 * ********************************************************************* */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FiftyOne_Mobile_Default : System.Web.UI.Page
{
    protected string GetPropertyLinkHTML(string propertyName)
    {
        return String.Format(
            @"<a href=""http://51degrees.com/Resources/Property-Dictionary#{0}"">{0}</a>", 
            propertyName);
    }

    protected string GetPropertyHTML(string propertyName)
    {
        var value = Request.Browser[propertyName];
        if (String.IsNullOrEmpty(value))
            value = @"<a href=""http://51degrees.com/Products/Device-Detection"">Upgrade</a>";
        return value;
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}