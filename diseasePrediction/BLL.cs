using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using diseasePrediction.DataLayerTableAdapters;
using System.Data;

namespace diseasePrediction
{
    public class BLL
    {
        tblUsersTableAdapter userObj = new tblUsersTableAdapter();
        tblParametersTableAdapter parameterObj = new tblParametersTableAdapter();
        tblTrainingDatasetTableAdapter datasetObj = new tblTrainingDatasetTableAdapter();
        tblTestingDatasetTableAdapter testingObj = new tblTestingDatasetTableAdapter();
        tblActualDatasetTableAdapter actualObj = new tblActualDatasetTableAdapter();
        tblTreatmentTableAdapter treatmentObj = new tblTreatmentTableAdapter();

        tblDataTableAdapter dataObj = new tblDataTableAdapter();

        //login module

        //function to check the user login id and password(admin,doctor/rece)
        public DataTable CheckUserLogin(string userId, string password)
        {
            return userObj.CheckUserLogin(userId, password);
        }

        //User change Password
        public void UpdateUserPassword(string password, string userId)
        {
            userObj.UpdateUserPassword(password, userId);
        }

        //User management

        //function to insert new User
        public void InsertUser(string userId, string password, string userType, string emailId)
        {
            userObj.InsertUser(userId, password, userType, emailId);
        }

        //function to delete the user
        public void DeleteUser(string userId)
        {
            userObj.DeleteUser(userId);
        }

        //function to get other users(doc and rece)
        public DataTable GetOtherUsers()
        {
            return userObj.GetOtherUsers();
        }

        //function to retrive all users based on type
        public DataTable GetUsersByType(string userType)
        {
            return userObj.GetUsersByUserType(userType);
        }

        //function to check the userid
        public bool CheckUserId(string userId)
        {
            int cnt = int.Parse(userObj.CheckUserId(userId).ToString());

            if (cnt == 1)

                return false;

            return true;
        }


        //function to get the user by id
        public DataTable GetUserById(string userId)
        {
            return userObj.GetUserById(userId);
        }

        //function to update the user
        public void UpdateUser(string userId, string password, string type, string emailId, string UId)
        {
            userObj.UpdateUser(userId, password, type, emailId, UId);
        }

      
        //manage parameters

        //function to check the parameter
        public bool CheckParameter(string parameter)
        {
            int cnt = int.Parse(parameterObj.CheckParameter(parameter).ToString());

            if (cnt == 1)

                return false;

            return true;
        }

        //function to insert new parameter
        public void InsertParameter(string parameter)
        {
            parameterObj.InsertParameter(parameter);
        }

        //function to update parameter
        public void UpdateParameter(string parameter, int parameterId)
        {
            parameterObj.UpdateParameter(parameter, parameterId);
        }

        //function to delete parameter
        public void DeleteParameter(int parameterId)
        {
            parameterObj.DeleteParameter(parameterId);
        }

        //function to get the parameter based on id
        public DataTable GetParameterById(int parameterId)
        {
            return parameterObj.GetParameterById(parameterId);
        }

        //function to retrive all parameters
        public DataTable GetAllParameters()
        {
            return parameterObj.GetData();
        }

        //manage dataset

        //function to get all training dataset
        public DataTable GetTrainingDataset()
        {
            return datasetObj.GetData();
        }

       //function to insert training data
        public void InsertTrainingData(string name, int Age, double GENDER, double CP, double TRESTBPS, double CHOL, double FBS,
                                        double RESTECG, double THALACH, double EXANG, double OLDPEAK, double SLOPE,
                                        double CA, double THAL, double AVGPR, double ABGBTEMP,
                                         int Result)
        {
            datasetObj.InsertTrainingData(name, Age, GENDER, CP, TRESTBPS, CHOL, FBS, RESTECG, THALACH, EXANG, OLDPEAK, SLOPE,
                                          CA, THAL, AVGPR, ABGBTEMP, Result);
        }

        //function to update training data
        public void UpdateTrainingData(string name, int Age, double GENDER, double CP, double TRESTBPS, double CHOL, double FBS,
                                        double RESTECG, double THALACH, double EXANG, double OLDPEAK, double SLOPE,
                                        double CA, double THAL, double AVGPR, double ABGBTEMP,
                                         int Result, int datasetId)
        {
            datasetObj.UpdateTrainingData(name, Age, GENDER, CP, TRESTBPS, CHOL, FBS, RESTECG, THALACH, EXANG, OLDPEAK, SLOPE,
                                          CA, THAL, AVGPR, ABGBTEMP, Result, datasetId);
        }

        //function to delete training data
        public void DeleteTrainingData(int datasetId)
        {
            datasetObj.DeleteTrainingData(datasetId);
        }

        //function to fetch training data by id
        public DataTable GetTrainingDataById(int Id)
        {
            return datasetObj.GetTrainingDataById(Id);
        }

        //manage testing dataset

        //function to get all testing dataset
        public DataTable GetTestingDataset()
        {
            return testingObj.GetData();
        }

        //function to insert testing data
        public void InsertTestingData(string name, int Age, double GENDER, double CP, double TRESTBPS, double CHOL, double FBS,
                                        double RESTECG, double THALACH, double EXANG, double OLDPEAK, double SLOPE,
                                        double CA, double THAL, double AVGPR, double ABGBTEMP)
        {
            testingObj.InsertTestingData(name, Age, GENDER, CP, TRESTBPS, CHOL, FBS, RESTECG, THALACH, EXANG, OLDPEAK, SLOPE,
                                          CA, THAL, AVGPR, ABGBTEMP);
        }

        //function to update testing data
        public void UpdateTestingData(string name, int Age, double GENDER, double CP, double TRESTBPS, double CHOL, double FBS,
                                        double RESTECG, double THALACH, double EXANG, double OLDPEAK, double SLOPE,
                                        double CA, double THAL, double AVGPR, double ABGBTEMP,
                                        int datasetId)
        {
            testingObj.UpdateTestingData(name, Age, GENDER, CP, TRESTBPS, CHOL, FBS, RESTECG, THALACH, EXANG, OLDPEAK, SLOPE,
                                          CA, THAL, AVGPR, ABGBTEMP, datasetId);
        }

        //function to delete the testing data
        public void DeleteTestingData(int testingDataId)
        {
            testingObj.DeleteTestingData(testingDataId);
        }

        //function to fetch testing data by id
        public DataTable GetTestingDataById(int Id)
        {
            return testingObj.GetTestingDataById(Id);
        }


        //function to fetch GetActualPatientDataById
        public DataTable GetActualPatientDataById(int patId)
        {
           return actualObj.GetActualPatientDataById(patId);
        }

        //function to get actual cnt
        public int GetActualCnt()
        {
            return (int)actualObj.GetActualCnt();
        }

        //function to retirve all treatmentdetails
        public DataTable GetAllTreatments()
        {
            return treatmentObj.GetData();
        }

        //function to insert the treatment details
        public void InsertTreatment(string treatment, DateTime date)
        {
            treatmentObj.InsertTreatment(treatment, date);
        }

        //function to delete the treatment details
        public void DeleteTreatment(int treatmentId)
        {
            treatmentObj.DeleteTreatment(treatmentId);
        }

        //function to get the treatment details by Ids
        public DataTable GetTreatmentByid(int treatmentId)
        {
            return treatmentObj.GetTreatmentById(treatmentId);
        }

        //function to update the treatment details
        public void UpdateTreatment(string treatment, DateTime date, int treatmentId)
        {
            treatmentObj.UpdateTreatment(treatment, date, treatmentId);
        }

        public bool CheckPatientLogin(int userId, int pwd)
        {
            int cnt = int.Parse(testingObj.CheckPatientLogin(userId, pwd).ToString());

            if (cnt == 1)

                return true;

            return false;
        }


        public DataTable GetDistinctAGE()
        {
            return datasetObj.GetDistinctAge();
        }

        public DataTable GetDistinctGENDER()
        {
            return datasetObj.GetDistinctGender();
        }

        public DataTable GetDistinctCP()
        {
            return datasetObj.GetDistinctCP();
        }

        public DataTable GetDistinctTRESTBPS()
        {
            return datasetObj.GetDistinctTRESTBPS();
        }

        public DataTable GetDistinctCHOL()
        {
            return datasetObj.GetDistinctCHOL();
        }

        public DataTable GetDistinctFBS()
        {
            return datasetObj.GetDistinctFBS();
        }
        public DataTable GetDistinctRESTECG()
        {
            return datasetObj.GetDistinctRESTECG();
        }
        public DataTable GetDistinctTHALACH()
        {
            return datasetObj.GetDistinctTHALACH();
        }
        public DataTable GetDistinctEXANG()
        {
            return datasetObj.GetDistinctEXANG();
        }
        public DataTable GetDistinctOLDPEAK()
        {
            return datasetObj.GetDistinctOLDPEAK();
        }
        public DataTable GetDistinctSLOPE()
        {
            return datasetObj.GetDistinctSLOPE();
        }
        public DataTable GetDistinctCA()
        {
            return datasetObj.GetDistinctCA();
        }
        public DataTable GetDistinctTHAL()
        {
            return datasetObj.GetDistinctTHAL();
        }
        public DataTable GetDistinctAVGPR()
        {
            return datasetObj.GetDistinctAVGPR();
        }
        public DataTable GetDistinctABGBTEMP()
        {
            return datasetObj.GetDistinctABGBTEMP();
        }

        //get count
        public int GetCountAGE(int value)
        {
            return (int)datasetObj.GetCountAge(value);
        }

        public int GetCountGENDER(double value)
        {
            return (int)datasetObj.GetCountGENDER(value);
        }

        public int GetCountCP(double value)
        {
            return (int)datasetObj.GetCountCP(value);
        }

        public int GetCountTRESTBPS(double value)
        {
            return (int)datasetObj.GetCountTRESTBPS(value);
        }

        public int GetCountCHOL(double value)
        {
            return (int)datasetObj.GetCountCHOL(value);
        }

        public int GetCountFBS(double value)
        {
            return (int)datasetObj.GetCountFBS(value);
        }

        public int GetCountRESTECG(double value)
        {
            return (int)datasetObj.GetCountRESTECG(value);
        }

        public int GetCountTHALACH(double value)
        {
            return (int)datasetObj.GetCountTHALACH(value);
        }

        public int GetCountEXANG(double value)
        {
            return (int)datasetObj.GetCountEXANG(value);
        }

        public int GetCountOLDPEAK(double value)
        {
            return (int)datasetObj.GetCountOLDPEAK(value);
        }

        public int GetCountSLOPE(double value)
        {
            return (int)datasetObj.GetCountSLOPE(value);
        }

        public int GetCountCA(double value)
        {
            return (int)datasetObj.GetCountCA(value);
        }
        public int GetCountTHAL(double value)
        {
            return (int)datasetObj.GetCountTHAL(value);
        }
        public int GetCountAVGPR(double value)
        {
            return (int)datasetObj.GetCountAVGPR(value);
        }

        public int GetCountABGBTEMP(double value)
        {
            return (int)datasetObj.GetCountABGBTEMP(value);
        }


        public void DeleteData(int datasetId)
        {
            dataObj.DeleteData(datasetId);
        }
               

        public DataTable GetAllData()
        {
            return dataObj.GetData();
        }

        //function to insert the data
        public void InsertData(string date, string data)
        {
            dataObj.InsertData(date, data);
        }

        //function to update data
        public void UpdateData(string date, string data, int dataId)
        {
            dataObj.UpdateData(date, data, dataId);
        }

        //function to get data by Id
        public DataTable GetDataById(int dataId)
        {
            return dataObj.GetDataById(dataId);
        }

       

       
    }
}