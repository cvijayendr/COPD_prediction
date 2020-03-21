using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace diseasePrediction.Doctor
{
    public partial class frmDoctorHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["StaffId"] == null)
            {
                Session.Abandon();
                Response.Redirect("~/frmLogin.aspx");
            }
            else
            {
                LoadTestingDataset();
            }
        }

        //function to load all patients
        private void LoadTestingDataset()
        {
            DataTable tab = new DataTable();
            BLL obj = new BLL();

            tab = obj.GetTestingDataset();

            if (tab.Rows.Count > 0)
            {
                tablePatients.Rows.Clear();

                tablePatients.BorderStyle = BorderStyle.Double;
                tablePatients.GridLines = GridLines.Both;
                tablePatients.BorderColor = System.Drawing.Color.DarkGray;

                TableRow mainrow = new TableRow();
                mainrow.Height = 30;
                mainrow.ForeColor = System.Drawing.Color.WhiteSmoke;
                mainrow.BackColor = System.Drawing.Color.SteelBlue;

                TableCell cell2 = new TableCell();
                cell2.Text = "<b>Name</b>";
                mainrow.Controls.Add(cell2);

                TableCell cell3 = new TableCell();
                cell3.Text = "<b>Age</b>";
                mainrow.Controls.Add(cell3);

                TableCell cell4 = new TableCell();
                cell4.Text = "<b>GENDER</b>";
                mainrow.Controls.Add(cell4);

                TableCell cell5 = new TableCell();
                cell5.Text = "<b>CP</b>";
                mainrow.Controls.Add(cell5);

                TableCell cell6 = new TableCell();
                cell6.Text = "<b>TRESTBPS</b>";
                mainrow.Controls.Add(cell6);

                TableCell cell7 = new TableCell();
                cell7.Text = "<b>CHOL</b>";
                mainrow.Controls.Add(cell7);

                TableCell cell8 = new TableCell();
                cell8.Text = "<b>FBS</b>";
                mainrow.Controls.Add(cell8);

                TableCell cell9 = new TableCell();
                cell9.Text = "<b>RESTECG</b>";
                mainrow.Controls.Add(cell9);

                TableCell cell10 = new TableCell();
                cell10.Text = "<b>THALACH</b>";
                mainrow.Controls.Add(cell10);

                TableCell cell101 = new TableCell();
                cell101.Text = "<b>EXANG</b>";
                mainrow.Controls.Add(cell101);

                TableCell cell1011 = new TableCell();
                cell1011.Text = "<b>OLDPEAK</b>";
                mainrow.Controls.Add(cell1011);

                TableCell cell1012 = new TableCell();
                cell1012.Text = "<b>SLOPE</b>";
                mainrow.Controls.Add(cell1012);

                TableCell cell1013 = new TableCell();
                cell1013.Text = "<b>CA</b>";
                mainrow.Controls.Add(cell1013);

                TableCell cell1014 = new TableCell();
                cell1014.Text = "<b>THAL</b>";
                mainrow.Controls.Add(cell1014);

                TableCell cell1015 = new TableCell();
                cell1015.Text = "<b>AVGPR</b>";
                mainrow.Controls.Add(cell1015);

                TableCell cell1016 = new TableCell();
                cell1016.Text = "<b>ABGBTEMP</b>";
                mainrow.Controls.Add(cell1016);


                //TableCell cell10113 = new TableCell();
                //cell10113.Text = "<b>Result</b>";
                //mainrow.Controls.Add(cell10113);

                TableCell cell11 = new TableCell();
                cell11.Text = "<b>Edit</b>";
                mainrow.Controls.Add(cell11);

                TableCell cell12 = new TableCell();
                cell12.Text = "<b>Delete</b>";
                mainrow.Controls.Add(cell12);

                tablePatients.Controls.Add(mainrow);

                for (int i = 0; i < tab.Rows.Count; i++)
                {
                    TableRow row = new TableRow();

                    TableCell cellName = new TableCell();
                    cellName.Text = tab.Rows[i]["Name"].ToString();
                    row.Controls.Add(cellName);

                    TableCell cellAge = new TableCell();
                    cellAge.Text = tab.Rows[i]["AGE"].ToString();
                    row.Controls.Add(cellAge);

                    TableCell cellGENDER = new TableCell();
                    cellGENDER.Text = tab.Rows[i]["GENDER"].ToString();
                    row.Controls.Add(cellGENDER);

                    TableCell cellCP = new TableCell();
                    cellCP.Text = tab.Rows[i]["CP"].ToString();
                    row.Controls.Add(cellCP);

                    TableCell cellTRESTBPS = new TableCell();
                    cellTRESTBPS.Text = tab.Rows[i]["TRESTBPS"].ToString();
                    row.Controls.Add(cellTRESTBPS);

                    TableCell cellCHOL = new TableCell();
                    cellCHOL.Text = tab.Rows[i]["CHOL"].ToString();
                    row.Controls.Add(cellCHOL);

                    TableCell cellFBS = new TableCell();
                    cellFBS.Text = tab.Rows[i]["FBS"].ToString();
                    row.Controls.Add(cellFBS);

                    TableCell cellRESTECG = new TableCell();
                    cellRESTECG.Text = tab.Rows[i]["RESTECG"].ToString();
                    row.Controls.Add(cellRESTECG);

                    TableCell cellTHALACH = new TableCell();
                    cellTHALACH.Text = tab.Rows[i]["THALACH"].ToString();
                    row.Controls.Add(cellTHALACH);

                    TableCell cellEXANG = new TableCell();
                    cellEXANG.Text = tab.Rows[i]["EXANG"].ToString();
                    row.Controls.Add(cellEXANG);

                    TableCell cellOLDPEAK = new TableCell();
                    cellOLDPEAK.Text = tab.Rows[i]["OLDPEAK"].ToString();
                    row.Controls.Add(cellOLDPEAK);

                    TableCell cellSLOPE = new TableCell();
                    cellSLOPE.Text = tab.Rows[i]["SLOPE"].ToString();
                    row.Controls.Add(cellSLOPE);

                    TableCell cellCA = new TableCell();
                    cellCA.Text = tab.Rows[i]["CA"].ToString();
                    row.Controls.Add(cellCA);

                    TableCell cellTHAL = new TableCell();
                    cellTHAL.Text = tab.Rows[i]["THAL"].ToString();
                    row.Controls.Add(cellTHAL);

                    TableCell cellAVGPR = new TableCell();
                    cellAVGPR.Text = tab.Rows[i]["AVGPR"].ToString();
                    row.Controls.Add(cellAVGPR);

                    TableCell cellABGBTEMP = new TableCell();
                    cellABGBTEMP.Text = tab.Rows[i]["ABGBTEMP"].ToString();
                    row.Controls.Add(cellABGBTEMP);
                    
                    //TableCell cellResult = new TableCell();
                    //cellResult.Text = tab.Rows[i]["Result"].ToString();
                    //row.Controls.Add(cellResult);





                    TableCell cell_edit = new TableCell();
                    LinkButton lbtn_edit = new LinkButton();
                    lbtn_edit.ForeColor = System.Drawing.Color.SteelBlue;
                    lbtn_edit.Text = "Edit";
                    lbtn_edit.Font.Bold = true;
                    lbtn_edit.ID = "Edit~" + tab.Rows[i]["PatientId"].ToString();
                    lbtn_edit.Click += new EventHandler(lbtn_edit_Click);
                    cell_edit.Controls.Add(lbtn_edit);
                    row.Controls.Add(cell_edit);

                    TableCell cell_delete = new TableCell();
                    LinkButton lbtn_delete = new LinkButton();
                    lbtn_delete.ForeColor = System.Drawing.Color.SteelBlue;
                    lbtn_delete.Text = "Delete";
                    lbtn_delete.Font.Bold = true;
                    lbtn_delete.ID = "Delete~" + tab.Rows[i]["PatientId"].ToString();
                    lbtn_delete.OnClientClick = "return confirm('Are you sure want to delete this record?')";
                    lbtn_delete.Click += new EventHandler(lbtn_delete_Click);
                    cell_delete.Controls.Add(lbtn_delete);
                    row.Controls.Add(cell_delete);

                    tablePatients.Controls.Add(row);
                }
            }
            else
            {
                tablePatients.Rows.Clear();
                tablePatients.GridLines = GridLines.None;
                tablePatients.BorderStyle = BorderStyle.None;

                TableHeaderRow rno = new TableHeaderRow();
                TableHeaderCell cellno = new TableHeaderCell();
                cellno.ForeColor = System.Drawing.Color.Red;
                cellno.Text = "No Testing Dataset Found!!!";

                rno.Controls.Add(cellno);
                tablePatients.Controls.Add(rno);
            }
        }

        //event to delete patient
        void lbtn_delete_Click(object sender, EventArgs e)
        {
            BLL obj = new BLL();
            LinkButton lbtn = (LinkButton)sender;
            string[] s = lbtn.ID.ToString().Split('~');

            try
            {
                obj.DeleteTestingData(int.Parse(s[1].ToString()));

                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Data Deleted Successfully!!!')</script>");
                LoadTestingDataset();

            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Server Error!!!')</script>");
            }
        }

        //click event to edit the patient details
        void lbtn_edit_Click(object sender, EventArgs e)
        {
            BLL obj = new BLL();
            LinkButton lbtn = (LinkButton)sender;
            string[] s = lbtn.ID.ToString().Split('~');

            Session["Id"] = null;
            Session["Id"] = s[1];

            DataTable tab = new DataTable();
            tab = obj.GetTestingDataById(int.Parse(s[1]));

            if (tab.Rows.Count > 0)
            {
                txtPatientName.Text = tab.Rows[0]["Name"].ToString();

                txtAge.Text = tab.Rows[0]["AGE"].ToString();
                txtGENDER.Text = tab.Rows[0]["GENDER"].ToString();
                txtCP.Text = tab.Rows[0]["CP"].ToString();
                txtTRESTBPS.Text = tab.Rows[0]["TRESTBPS"].ToString();
                txtCHOL.Text = tab.Rows[0]["CHOL"].ToString();
                txtFBS.Text = tab.Rows[0]["FBS"].ToString();

                txtRESTECG.Text = tab.Rows[0]["RESTECG"].ToString();
                txtTHALACH.Text = tab.Rows[0]["THALACH"].ToString();
                txtEXANG.Text = tab.Rows[0]["EXANG"].ToString();
                txtOLDPEAK.Text = tab.Rows[0]["OLDPEAK"].ToString();
                txtSLOPE.Text = tab.Rows[0]["SLOPE"].ToString();
                txtCA.Text = tab.Rows[0]["CA"].ToString();
                txtTHAL.Text = tab.Rows[0]["THAL"].ToString();

                txtAVGPR.Text = tab.Rows[0]["AVGPR"].ToString();
                txtABGBTEMP.Text = tab.Rows[0]["ABGBTEMP"].ToString();

                //txtResult.Text = tab.Rows[0]["Result"].ToString();   

                //txtResult.Text = tab.Rows[0]["Result"].ToString();
            }

            btnSubmit.Text = "Update";
        }

        //function to clear the textbox contents
        private void ClearTxtboxes()
        {
            txtABGBTEMP.Text = txtAge.Text = txtAVGPR.Text = txtCA.Text = txtCHOL.Text = txtCP.Text =
             txtEXANG.Text = txtFBS.Text = txtGENDER.Text = txtOLDPEAK.Text = txtPatientName.Text = txtRESTECG.Text =
             txtSLOPE.Text = txtTHAL.Text = txtTHALACH.Text = txtTRESTBPS.Text = string.Empty;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            BLL obj = new BLL();

            if (btnSubmit.Text.Equals("Submit"))
            {
                try
                {
                    obj.InsertTestingData(txtPatientName.Text, int.Parse(txtAge.Text), double.Parse(txtGENDER.Text),
                        double.Parse(txtCP.Text), double.Parse(txtTRESTBPS.Text), double.Parse(txtCHOL.Text), double.Parse(txtFBS.Text),
                        double.Parse(txtRESTECG.Text), double.Parse(txtTHALACH.Text), double.Parse(txtEXANG.Text), double.Parse(txtOLDPEAK.Text),
                        double.Parse(txtSLOPE.Text), double.Parse(txtCA.Text), double.Parse(txtTHAL.Text), double.Parse(txtAVGPR.Text),
                        double.Parse(txtABGBTEMP.Text));

                    ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Data Added Successfully!!!')</script>");
                    ClearTxtboxes();
                    LoadTestingDataset();
                }
                catch
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Server Error!')</script>");
                }
            }
            else if (btnSubmit.Text.Equals("Update"))
            {

                obj.UpdateTestingData(txtPatientName.Text, int.Parse(txtAge.Text), double.Parse(txtGENDER.Text),
                        double.Parse(txtCP.Text), double.Parse(txtTRESTBPS.Text), double.Parse(txtCHOL.Text), double.Parse(txtFBS.Text),
                        double.Parse(txtRESTECG.Text), double.Parse(txtTHALACH.Text), double.Parse(txtEXANG.Text), double.Parse(txtOLDPEAK.Text),
                        double.Parse(txtSLOPE.Text), double.Parse(txtCA.Text), double.Parse(txtTHAL.Text), double.Parse(txtAVGPR.Text),
                        double.Parse(txtABGBTEMP.Text), int.Parse(Session["Id"].ToString()));


                btnSubmit.Text = "Submit";
                ClearTxtboxes();
                LoadTestingDataset();
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<script>alert('Data Updated Successfully!!!')</script>");
            }
        }
               
    }
}