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
    public partial class _NB : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _Prediction();
        }

        private void _Prediction()
        {
            try
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();

                BLL obj = new BLL();
                DataTable tabTestingDataset = new DataTable();
                tabTestingDataset = obj.GetTestingDataset();

                DataTable tabTrainingDataset = new DataTable();
                tabTrainingDataset = GetTrainingDataset();

                if (tabTestingDataset.Rows.Count > 0 && tabTrainingDataset.Rows.Count > 0)
                {
                    Table1.Rows.Clear();

                    Table1.BorderStyle = BorderStyle.Double;
                    Table1.GridLines = GridLines.Both;
                    Table1.BorderColor = System.Drawing.Color.DarkGray;

                    TableRow mainrow = new TableRow();
                    mainrow.Height = 30;
                    mainrow.ForeColor = System.Drawing.Color.WhiteSmoke;
                    mainrow.BackColor = System.Drawing.Color.SteelBlue;

                    TableCell cell2 = new TableCell();
                    cell2.Text = "<b>PatientName</b>";
                    mainrow.Controls.Add(cell2);

                    TableCell cell3 = new TableCell();
                    cell3.Text = "<b>Prediction</b>";
                    mainrow.Controls.Add(cell3);

                    Table1.Controls.Add(mainrow);

                    for (int i = 0; i < tabTestingDataset.Rows.Count; i++)
                    {
                        DataTable tabPat = new DataTable();
                        tabPat = obj.GetTestingDataById(int.Parse(tabTestingDataset.Rows[i]["PatientId"].ToString()));

                        string _Output = Naive_Bayes(int.Parse(tabTestingDataset.Rows[i]["PatientId"].ToString()));

                        TableRow row = new TableRow();

                        TableCell cellName = new TableCell();
                        cellName.Width = 150;
                        cellName.Text = tabPat.Rows[0]["Name"].ToString();
                        row.Controls.Add(cellName);

                        TableCell cellResult = new TableCell();
                        cellResult.Width = 150;
                        cellResult.Text = _Output;
                        row.Controls.Add(cellResult);

                        Table1.Controls.Add(row);
                    }

                    watch.Stop();
                    var elapsedMs = watch.ElapsedMilliseconds;
                    _timeNB = elapsedMs.ToString();

                   // ResultAnaly();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Testing/Training Dataset Not Found!!!')</script>");
                }
            }
            catch
            {

            }
        }

        double pi;
        int nc, n;
        double result;
        ArrayList output = new ArrayList();
        ArrayList mul = new ArrayList();
        double _outcomeCntNB = 0;
        double _outcomeCntKNN = 0;
        string _timeNB, _timeKNN;

        //function which contains the algorithm steps
        private string Naive_Bayes(int patId)
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

            //getting patient parameters
            DataTable tab = new DataTable();
            tab = obj.GetTestingDataById(patId);

            if (tab.Rows.Count > 0)
            {
                //storing current patient parameters into arraylist (classify)
                for (int i = 0; i < tab.Rows.Count; i++)
                {
                    //classify.Add(tab.Rows[0]["Name"].ToString());


                    classify.Add(tab.Rows[0]["AGE"].ToString());
                    classify.Add(tab.Rows[0]["GENDER"].ToString());
                    classify.Add(tab.Rows[0]["CP"].ToString());
                    classify.Add(tab.Rows[0]["TRESTBPS"].ToString());
                    classify.Add(tab.Rows[0]["CHOL"].ToString());

                    classify.Add(tab.Rows[0]["FBS"].ToString());
                    classify.Add(tab.Rows[0]["RESTECG"].ToString());
                    classify.Add(tab.Rows[0]["THALACH"].ToString());
                    classify.Add(tab.Rows[0]["EXANG"].ToString());
                    classify.Add(tab.Rows[0]["OLDPEAK"].ToString());

                    classify.Add(tab.Rows[0]["SLOPE"].ToString());
                    classify.Add(tab.Rows[0]["CA"].ToString());
                    classify.Add(tab.Rows[0]["THAL"].ToString());
                    classify.Add(tab.Rows[0]["AVGPR"].ToString());
                    classify.Add(tab.Rows[0]["ABGBTEMP"].ToString());                                      
                }

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


                        //DataTable tabActualData = new DataTable();
                        //tabActualData = obj.GetActualPatientDataById(patId);

                        //if (tabActualData.Rows[0]["Result"].ToString().Equals(s[y].ToString()))
                        //{
                        //    ++_outcomeCntNB;
                        //}

                        return _output;
                    }
                }
            }
            else
            {

            }

            return _output;
        }

        private void ResultAnaly()
        {
            BLL obj = new BLL();
            int _ActualCnt = obj.GetActualCnt();

            tableResults.Rows.Clear();

            tableResults.BorderStyle = BorderStyle.Double;
            tableResults.GridLines = GridLines.Both;
            tableResults.BorderColor = System.Drawing.Color.SteelBlue;

            TableRow mainrow = new TableRow();
            mainrow.Height = 30;
            mainrow.ForeColor = System.Drawing.Color.WhiteSmoke;
            mainrow.BackColor = System.Drawing.Color.SteelBlue;

            TableCell cellC = new TableCell();
            cellC.Text = "<b>Naive Bayes</b>";
            mainrow.Controls.Add(cellC);

            TableCell cellB = new TableCell();
            cellB.Text = "<b>Constraint</b>";
            mainrow.Controls.Add(cellB);

            tableResults.Controls.Add(mainrow);

            //1st row
            TableRow row1 = new TableRow();

            TableCell cellAcc = new TableCell();
            cellAcc.Text = "<b>Accuracy</b>";
            row1.Controls.Add(cellAcc);

            TableCell cellAccNB = new TableCell();
            cellAccNB.Font.Bold = true;
            //cal
            double _percentageNB = (_outcomeCntNB / _ActualCnt) * 100;
            cellAccNB.Text = _percentageNB.ToString() + " %";
            row1.Controls.Add(cellAccNB);

            tableResults.Controls.Add(row1);

            //2nd row           
            TableRow row2 = new TableRow();

            TableCell cellTime = new TableCell();
            cellTime.Text = "<b>Time (milli secs)</b>";
            row2.Controls.Add(cellTime);

            TableCell cellTimeNB = new TableCell();
            cellTimeNB.Font.Bold = true;
            cellTimeNB.Text = _timeNB;
            row2.Controls.Add(cellTimeNB);

            tableResults.Controls.Add(row2);

            //3rd row           
            TableRow row3 = new TableRow();

            TableCell cellCorrect = new TableCell();
            cellCorrect.Text = "<b>Correctly Classified</b>";
            row3.Controls.Add(cellCorrect);

            TableCell cellCorrectNB = new TableCell();
            cellCorrectNB.Font.Bold = true;
            cellCorrectNB.Text = _percentageNB.ToString() + " %";
            row3.Controls.Add(cellCorrectNB);

            tableResults.Controls.Add(row3);

            //4th row           
            TableRow row4 = new TableRow();

            TableCell cellInCorrect = new TableCell();
            cellInCorrect.Text = "<b>InCorrectly Classified</b>";
            row4.Controls.Add(cellInCorrect);

            TableCell cellInCorrectNB = new TableCell();
            cellInCorrectNB.Font.Bold = true;
            cellInCorrectNB.Text = (100 - _percentageNB).ToString() + " %";
            row4.Controls.Add(cellInCorrectNB);

            tableResults.Controls.Add(row4);

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