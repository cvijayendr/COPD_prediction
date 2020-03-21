using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace diseasePrediction.Doctor
{
    public partial class _Dataset : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            diseasePrediction.JQueryUtils.RegisterTextBoxForDatePicker(Page, txtDate);

            loadDataset();

        }

        private void loadDataset()
        {
            try
            {
                DataTable tab = new DataTable();
                BLL obj = new BLL();

                int serialNo = 1;

                tab = obj.GetAllData();

                if (tab.Rows.Count > 0)
                {
                    tableDataset.Rows.Clear();

                    tableDataset.BorderStyle = BorderStyle.Double;
                    tableDataset.GridLines = GridLines.Both;
                    tableDataset.BorderColor = System.Drawing.Color.DarkGray;

                    TableRow mainrow = new TableRow();
                    mainrow.Height = 30;
                    mainrow.ForeColor = System.Drawing.Color.WhiteSmoke;
                    mainrow.BackColor = System.Drawing.Color.SteelBlue;

                    TableCell cell1 = new TableCell();
                    cell1.Text = "<b>SerialNo</b>";
                    mainrow.Controls.Add(cell1);

                    TableCell cell31 = new TableCell();
                    cell31.Text = "<b>Disease Type</b>";
                    mainrow.Controls.Add(cell31);

                    TableCell cell3 = new TableCell();
                    cell3.Text = "<b>Date</b>";
                    mainrow.Controls.Add(cell3);

                    TableCell cell41 = new TableCell();
                    cell41.Text = "<b>Data</b>";
                    mainrow.Controls.Add(cell41);

                    TableCell cell5 = new TableCell();
                    cell5.Text = "<b>Edit</b>";
                    mainrow.Controls.Add(cell5);

                    TableCell cell6 = new TableCell();
                    cell6.Text = "<b>Delete</b>";
                    mainrow.Controls.Add(cell6);

                    tableDataset.Controls.Add(mainrow);

                    for (int i = 0; i < tab.Rows.Count; i++)
                    {
                        TableRow row = new TableRow();

                        TableCell cellSerialNo = new TableCell();
                        cellSerialNo.Width = 50;
                        cellSerialNo.Text = serialNo + i + ".";
                        row.Controls.Add(cellSerialNo);

                        TableCell cellType = new TableCell();
                        cellType.Width = 200;
                        cellType.Text = "COPD";
                        row.Controls.Add(cellType);

                        TableCell cellDate = new TableCell();
                        cellDate.Width = 150;
                        string[] s = tab.Rows[i]["Date"].ToString().Split(' ');
                        cellDate.Text = s[0];
                        row.Controls.Add(cellDate);

                        TableCell cellTemp = new TableCell();
                        cellTemp.Width = 200;
                        cellTemp.Text = tab.Rows[i]["Data"].ToString();
                        row.Controls.Add(cellTemp);

                        TableCell cell_edit = new TableCell();
                        LinkButton lbtn_edit = new LinkButton();
                        lbtn_edit.ForeColor = System.Drawing.Color.Red;
                        lbtn_edit.Text = "Edit";
                        lbtn_edit.ID = "Edit~" + tab.Rows[i]["DataId"].ToString();
                        lbtn_edit.Click += new EventHandler(lbtn_edit_Click);
                        cell_edit.Controls.Add(lbtn_edit);
                        row.Controls.Add(cell_edit);

                        TableCell cell_delete = new TableCell();
                        LinkButton lbtn_delete = new LinkButton();
                        lbtn_delete.ForeColor = System.Drawing.Color.Red;
                        lbtn_delete.Text = "Delete";

                        lbtn_delete.ID = "Delete~" + tab.Rows[i]["DataId"].ToString();
                        lbtn_delete.OnClientClick = "return confirm('Are you sure want to delete this record?')";
                        lbtn_delete.Click += new EventHandler(lbtn_delete_Click);
                        cell_delete.Controls.Add(lbtn_delete);
                        row.Controls.Add(cell_delete);

                        tableDataset.Controls.Add(row);
                    }
                }
                else
                {
                    tableDataset.Rows.Clear();

                    TableHeaderRow rno = new TableHeaderRow();
                    TableHeaderCell cellno = new TableHeaderCell();
                    cellno.ForeColor = System.Drawing.Color.Red;
                    cellno.Text = "No Dataset Found";

                    rno.Controls.Add(cellno);
                    tableDataset.Controls.Add(rno);
                }
            }
            catch
            {

            }
        }

        //event to delete dataset
        void lbtn_delete_Click(object sender, EventArgs e)
        {
            BLL obj = new BLL();
            LinkButton lbtn = (LinkButton)sender;
            string[] s = lbtn.ID.ToString().Split('~');

            try
            {
                obj.DeleteData(int.Parse(s[1]));

                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Data Deleted Successfully!!!')</script>");
                loadDataset();

            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Server Error!!!')</script>");
            }
        }

        //click event to edit the staff details
        void lbtn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                BLL obj = new BLL();
                LinkButton lbtn = (LinkButton)sender;
                string[] s = lbtn.ID.ToString().Split('~');

                Session["datasetId"] = null;
                Session["datasetId"] = s[1];

                DataTable tab = new DataTable();
                tab = obj.GetDataById(int.Parse(s[1]));

                if (tab.Rows.Count > 0)
                {
                    txtDate.Text = tab.Rows[0]["Date"].ToString();
                    txtData.Text = tab.Rows[0]["Data"].ToString();                                      
                }



                btnSubmit.Text = "Update";
            }
            catch
            {

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            BLL obj = new BLL();

            if (btnSubmit.Text.Equals("Upload"))
            {
                try
                {
                    obj.InsertData(txtDate.Text, txtData.Text);

                    ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Data Added Successfully')</script>");
                    txtDate.Text = string.Empty;
                    txtData.Text = string.Empty;

                    loadDataset();
                }
                catch
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Server Error!')</script>");
                }
            }
            else if (btnSubmit.Text.Equals("Update"))
            {

                try
                {
                    obj.UpdateData(txtDate.Text, txtData.Text, int.Parse(Session["datasetId"].ToString()));

                    ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Data Updated Successfully')</script>");
                    txtDate.Text = string.Empty;
                    txtData.Text = string.Empty;

                    loadDataset();

                    btnSubmit.Text = "Upload";

                }
                catch
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Server Error!')</script>");
                }

            }

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtDate.Text = Calendar1.SelectedDate.ToShortDateString();
        }

    }
}