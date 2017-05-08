using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace BountifulHarvestWeb
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            foreach (var c in this.outputGridView.Columns)
            {
                table.Columns.Add(c.ToString());
            }
            var row = table.NewRow();
            row["First Name"] = "Jakob";
            row["M. I."] = "M.";
            row["Last Name"] = "Olechiw";
            row["Date of Birth"] = "01/01/2017";
            row["Gender"] = "Male";
            table.Rows.Add(row);

            outputGridView.DataSource = table;
            outputGridView.DataBind();
        }
    }
}