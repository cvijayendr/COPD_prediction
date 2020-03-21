using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

namespace diseasePrediction.Doctor
{
    public partial class IndividualPrediction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            BLL obj = new BLL();

            try
            {
                Naive_Bayes();

                obj.InsertTestingData(txtPatientName.Text, int.Parse(txtAge.Text), double.Parse(DropDownList1.SelectedValue),
                        double.Parse(txtCP.Text), double.Parse(txtTRESTBPS.Text), double.Parse(txtCHOL.Text), double.Parse(txtFBS.Text),
                        double.Parse(txtRESTECG.Text), double.Parse(txtTHALACH.Text), double.Parse(txtEXANG.Text), double.Parse(txtOLDPEAK.Text),
                        double.Parse(txtSLOPE.Text), double.Parse(txtCA.Text), double.Parse(txtTHAL.Text), double.Parse(txtAVGPR.Text),
                        double.Parse(txtABGBTEMP.Text));

                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('Data Added Successfully!!!')</script>");
                ClearTxtboxes();
            }
            catch
            {

            }
        }

        private void ClearTxtboxes()
        {
            txtABGBTEMP.Text = txtAge.Text = txtAVGPR.Text = txtCA.Text = txtCHOL.Text = txtCP.Text =
             txtEXANG.Text = txtFBS.Text = txtOLDPEAK.Text = txtPatientName.Text = txtRESTECG.Text =
             txtSLOPE.Text = txtTHAL.Text = txtTHALACH.Text = txtTRESTBPS.Text = string.Empty;
            DropDownList1.SelectedIndex = 0;
        }

      
        double pi;
        int nc, n;
        double result;
        ArrayList output = new ArrayList();
        ArrayList mul = new ArrayList();
       
        //function which contains the algorithm steps
        private void Naive_Bayes()
        {
            BLL obj = new BLL();
            ArrayList s = new ArrayList();
            string _output = null;

            //get possible outcomes
            s.Add("0");
            s.Add("1");
            s.Add("2");
            s.Add("3");
            s.Add("4");

            ArrayList parameters = new ArrayList();
            DataTable tabParameter = new DataTable();

            tabParameter = obj.GetAllParameters();
                        
            //value of m and p
            int m = tabParameter.Rows.Count;
            double numer = 1.0;
            double dino = double.Parse(s.Count.ToString());
            double p = numer / dino;

            if (tabParameter.Rows.Count > 0)
            {
                //storing parameter names into arraylist (parameters)
                for (int i = 0; i < tabParameter.Rows.Count; i++)
                {
                    parameters.Add(tabParameter.Rows[i]["Parameter"].ToString());
                }
            }

            ArrayList classify = new ArrayList();


            //classify.Add(tab.Rows[0]["Name"].ToString());

           
                    classify.Add(txtAge.Text);

                    classify.Add(DropDownList1.SelectedValue);
               
                    classify.Add(txtCP.Text);
               
                    classify.Add(txtTRESTBPS.Text);
                
                    classify.Add(txtCHOL.Text);
                
                    classify.Add(txtFBS.Text);
               
                    classify.Add(txtRESTECG.Text);
                
                    classify.Add(txtTHALACH.Text);
                
                    classify.Add(txtEXANG.Text);
                
                    classify.Add(txtOLDPEAK.Text);
                
                    classify.Add(txtSLOPE.Text);
                
                    classify.Add(txtCA.Text);
               
                    classify.Add(txtTHAL.Text);
                
                    classify.Add(txtAVGPR.Text);
               
                    classify.Add(txtABGBTEMP.Text);
                        
        

                                              


            //fetching training dataset
            DataTable tabTrainingSet = new DataTable();
            tabTrainingSet = GetTrainingDataset();

            output.Clear();


            for (int i = 0; i < s.Count; i++)
            {
                mul.Clear();

                for (int j = 0; j < parameters.Count; j++)
                {
                    n = 0;
                    nc = 0;

                    for (int d = 0; d < tabTrainingSet.Rows.Count; d++)
                    {
                        if (tabTrainingSet.Rows[d][j + 1].ToString().Equals(classify[j]))
                        {
                            ++n;

                            if (tabTrainingSet.Rows[d][m + 1].ToString().Equals(s[i]))

                                ++nc;
                        }
                    }

                    double x = m * p;
                    double y = n + m;
                    double z = nc + x;

                    pi = z / y;
                    mul.Add(Math.Abs(pi));
                }

                double mulres = 1.0;

                for (int z = 0; z < mul.Count; z++)
                {
                    mulres *= double.Parse(mul[z].ToString());
                }

                result = mulres * p;
                output.Add(Math.Abs(result));
            }

            //prediction
            ArrayList list1 = new ArrayList();

            for (int x = 0; x < s.Count; x++)
            {
                list1.Add(output[x]);
            }

            list1.Sort();
            list1.Reverse();

            for (int y = 0; y < s.Count; y++)
            {
                if (output[y].Equals(list1[0]))
                {
                    _output = s[y].ToString();

                    if (_output.Equals("0"))
                    {
                        _output = "NO";
                    }
                    else if (_output.Equals("1"))
                    {
                        _output = "STAGE 1";
                    }
                    else if (_output.Equals("2"))
                    {
                        _output = "STAGE 2";
                    }
                    else if (_output.Equals("3"))
                    {
                        _output = "STAGE 3";
                    }
                    else if (_output.Equals("4"))
                    {
                        _output = "STAGE 4";
                    }

                    lblResult.Text = "Output: " + _output;

                    //DataTable tabActualData = new DataTable();
                    //tabActualData = obj.GetActualPatientDataById(patId);

                    //if (tabActualData.Rows[0]["Result"].ToString().Equals(s[y].ToString()))
                    //{
                    //    ++_outcomeCntNB;
                    //}
                    
                }
            }
          
        }

        //function to load training data set
        public DataTable GetTrainingDataset()
        {
            BLL obj = new BLL();

            DataTable tabNewAttributes = new DataTable();
            DataTable tabAttributes = new DataTable();

            tabAttributes = obj.GetAllParameters();

            if (tabAttributes.Rows.Count > 0)
            {
                tabNewAttributes.Columns.Add("PatientId");

                for (int i = 0; i < tabAttributes.Rows.Count; i++)
                {
                    tabNewAttributes.Columns.Add(tabAttributes.Rows[i]["Parameter"].ToString());
                }

                tabNewAttributes.Columns.Add("Result");
            }

            DataTable tab = new DataTable();
            tab = obj.GetTrainingDataset();

            if (tab.Rows.Count > 0)
            {
                for (int i = 0; i < tab.Rows.Count; i++)
                {
                    DataRow row = tabNewAttributes.NewRow();

                    row[tabNewAttributes.Columns[0].ToString()] = tab.Rows[i]["PatientId"].ToString();



                    row[tabNewAttributes.Columns[1].ToString()] = tab.Rows[i]["AGE"].ToString();
                    row[tabNewAttributes.Columns[2].ToString()] = tab.Rows[i]["GENDER"].ToString();
                    row[tabNewAttributes.Columns[3].ToString()] = tab.Rows[i]["CP"].ToString();
                    row[tabNewAttributes.Columns[4].ToString()] = tab.Rows[i]["TRESTBPS"].ToString();
                    row[tabNewAttributes.Columns[5].ToString()] = tab.Rows[i]["CHOL"].ToString();

                    row[tabNewAttributes.Columns[6].ToString()] = tab.Rows[i]["FBS"].ToString();
                    row[tabNewAttributes.Columns[7].ToString()] = tab.Rows[i]["RESTECG"].ToString();
                    row[tabNewAttributes.Columns[8].ToString()] = tab.Rows[i]["THALACH"].ToString();
                    row[tabNewAttributes.Columns[9].ToString()] = tab.Rows[i]["EXANG"].ToString();
                    row[tabNewAttributes.Columns[10].ToString()] = tab.Rows[i]["OLDPEAK"].ToString();

                    row[tabNewAttributes.Columns[11].ToString()] = tab.Rows[i]["SLOPE"].ToString();
                    row[tabNewAttributes.Columns[12].ToString()] = tab.Rows[i]["CA"].ToString();
                    row[tabNewAttributes.Columns[13].ToString()] = tab.Rows[i]["THAL"].ToString();
                    row[tabNewAttributes.Columns[14].ToString()] = tab.Rows[i]["AVGPR"].ToString();
                    row[tabNewAttributes.Columns[15].ToString()] = tab.Rows[i]["ABGBTEMP"].ToString();

                    row[tabNewAttributes.Columns[16].ToString()] = tab.Rows[i]["Result"].ToString();

                    tabNewAttributes.Rows.Add(row);


                }
            }

            return tabNewAttributes;
        }



    }
}