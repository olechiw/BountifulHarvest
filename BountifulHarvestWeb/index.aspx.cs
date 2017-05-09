using System;
using System.Data;
using System.Web.UI;

namespace BountifulHarvestWeb
{
    public partial class index : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var table = new DataTable();
            foreach (object c in outputGridView.Columns)
                table.Columns.Add(c.ToString());
            DataRow row = table.NewRow();
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