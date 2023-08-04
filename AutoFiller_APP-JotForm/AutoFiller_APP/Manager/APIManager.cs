using AutoFiller_API;
using AutoFiller_API.Model;
using AutoFiller_APP.Entites;
using AutoFiller_APP.Model;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2010.Excel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using Org.BouncyCastle.Ocsp;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static ClosedXML.Excel.XLPredefinedFormat;

namespace AutoFiller_APP.Manager
{
    class APIManager
    {
        public static string _conStr = Utility.GetServerString();
        public static bool CheckServer()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_conStr))
                {
                    connection.Open();
                    MessageBox.Show("You have been successfully connected to the database!");
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return false;
        }
        public static bool DeleteForm(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_conStr))
                {
                    String query = "INSERT INTO dbo.form ([created_date]\r\n,[updated_date]\r\n,[form_data]) VALUES (@created_date,@updated_date,@form_data)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        // Check Error
                        if (result < 0)
                        {
                            Console.WriteLine("Error inserting data into Database!");
                        }
                    }
                }

            }
            catch
            {
                MessageBox.Show(Utility.Constants.UNABLE_TO_DELETE);
            }
            return false;
        }

        public static CivilSurgeon_Preparer GetPreparerData(string selectedId)
        {
            var civilData = new CivilSurgeon_Preparer();
            using (SqlConnection connection = new SqlConnection(_conStr))
            {
                String query = $"SELECT * FROM [dbo].[Preparers] WHERE [FormId]='{selectedId}'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        var Id = dr[0].ToString();
                        var FormId = dr[1].ToString();
                        var FormData = dr[2].ToString();
                        civilData = JsonConvert.DeserializeObject<CivilSurgeon_Preparer>(FormData);
                    }
                    dr.Close();
                    ((IDisposable)dr).Dispose();
                }
            }
            return civilData;
        }

        public static CivilSurgeon_Preparer GetCivilSurgeon(string selectedId)
        {
            var civilData = new CivilSurgeon_Preparer();

            using (SqlConnection connection = new SqlConnection(_conStr))
            {
                String query = $"SELECT * FROM [dbo].[CivilSurgeons] WHERE [FormId]='{selectedId}'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        var Id = dr[0].ToString();
                        var FormId = dr[1].ToString();
                        var FormData = dr[2].ToString();

                        civilData = JsonConvert.DeserializeObject<CivilSurgeon_Preparer>(FormData);
                    }
                    dr.Close();
                    ((IDisposable)dr).Dispose();
                }
            }
            return civilData;
        }
        public static void UpdateFormComplete(int ID, bool completed)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_conStr))
                {
                    String query = $"UPDATE dbo.form\r\nSET [completed]='{completed}'\r\nWHERE [Id]='{ID}'";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        // Check Error
                        if (result < 0)
                        {
                            Console.WriteLine("Error inserting data into Database!");
                        }
                    }
                }

            }
            catch
            {
                MessageBox.Show("We can not set to COMPLETED");
            }
        }

        public static List<FormData> GetForms(string filter_data = null, string from = null, string to = null)
        {
            String query = "SELECT * FROM dbo.form";
            var now = System.DateTime.Now;

            switch (filter_data)
            {
                case "Last 7 days":
                    query += $" WHERE [created_date] >= '{now.AddDays(-7).ToString("yyyy-MM-dd")}'";
                    break;
                case "Last 30 days":
                    query += $" WHERE [created_date] >= '{now.AddDays(-30).ToString("yyyy-MM-dd")}'";
                    break;
                case "Last year":
                    query += $" WHERE [created_date] >= '{now.AddYears(-1).ToString("yyyy-MM-dd")}'";
                    break;
                case "Completed":
                    query += $" WHERE [completed] = '1'";
                    break;
                case "Not Completed":
                    query += $" WHERE [completed] = '0'";
                    break;
                case "Custom date range":
                    query += $" WHERE [created_date] >= '{from}' AND [created_date] < '{to}'";
                    break;
            }
            

            var forms = new List<FormData>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_conStr))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        SqlDataReader dr = command.ExecuteReader();
                        while (dr.Read())
                        {
                            var form = new FormData();
                            form.Id = int.Parse(dr[0].ToString());
                            form.created_date = System.DateTime.Parse(dr[1].ToString());
                            form.updated_date = System.DateTime.Parse(dr[2].ToString());
                            form.form_data = dr[3].ToString();
                            form.answer = int.Parse(dr[4].ToString());
                            form.extraData = dr[5].ToString();
                            form.completed = bool.Parse(dr[6].ToString());
                            form.submit_id = dr[7].ToString();
                            form.source = dr[8].ToString();
                            forms.Add(form);
                        }
                        dr.Close();
                        ((IDisposable)dr).Dispose();
                    }
                }
            }
            catch
            {
                MessageBox.Show(Utility.Constants.UNABLE_TO_RETRIEVE_DATA);
            }

            return forms;
        }

        public static string GetLastJotformCreatedDate()
        {
            string create_date = null;
            using (SqlConnection connection = new SqlConnection(_conStr))
            {
                String query = $"SELECT [created_date] FROM [AutoFiller_APP_DB].[dbo].[form] WHERE [source]='jotform' ORDER BY [created_date] DESC offset 0 rows fetch next 1 rows only";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        create_date = dr[0].ToString();
                    }
                    dr.Close();
                    ((IDisposable)dr).Dispose();
                }
            }
            return create_date;
        }
        public static bool ImportJotformData(JObject submissions)
        {
            var contents = submissions["content"];
            var content = Utility.GetStates();
            var states = JsonConvert.DeserializeObject<List<USState>>(content);

            foreach (var item in contents)
            {
                var submit_id = item["id"].ToString();
                var created_at = item["created_at"].ToString();
                var updated_at = item["updated_at"].ToString();

                var answers = item["answers"];
                var _firstname = answers["6"]["answer"]["first"].ToString();
                var _lastname = answers["6"]["answer"]["last"].ToString();
                var _middlename = answers["6"]["answer"]["middle"] != null? answers["6"]["answer"]["middle"].ToString():"";

                var _addressType_str = answers["55"]["answer"]!=null?answers["55"]["answer"].ToString():"";
                int _addressType = 3;
                switch (_addressType_str)
                {
                    case "APT":
                        _addressType= 0;
                        break;
                    case "STE":
                        _addressType = 1;
                        break;
                    case "FLR":
                        _addressType = 2;
                        break;
                }

                var _addressStreet = answers["56"]["answer"]!=null ? answers["56"]["answer"].ToString():"";
                var _addressNumber = answers["57"]["answer"]!=null?answers["57"]["answer"].ToString():"";
                var _addressCity = answers["58"]["answer"]!=null? answers["58"]["answer"].ToString():"";
                var _addressState = answers["59"]["answer"]!=null? answers["59"]["answer"].ToString():"";
                var _addressZip = answers["60"]["answer"]!=null? answers["60"]["answer"].ToString():"";

                var _sex = answers["11"]["answer"].ToString() == "Male"? 0:1;
                var _birth = answers["15"]["answer"]["datetime"].ToString();
                var _birthCity = answers["16"]["answer"].ToString();
                var _birthCountry = answers["17"]["answer"].ToString();

                var _alienRegistrationNumber = answers["18"]["answer"]!=null?answers["18"]["answer"].ToString():"";
                var _uscis = answers["19"]["answer"] != null? answers["19"]["answer"].ToString():"";
                var medicalExamReq = answers["61"]["answer"] != null? 1:0;

                var _appDaytimeTelephoneNumber = answers["23"]["answer"]["full"] != null ? answers["23"]["answer"]["full"].ToString() : "";
                _appDaytimeTelephoneNumber = Utility.GetNumbers(_appDaytimeTelephoneNumber);
                var _appMobileTelephoneNumber = answers["25"]["answer"]!= null ? answers["25"]["answer"].ToString() : "";
                _appMobileTelephoneNumber = Utility.GetNumbers(_appMobileTelephoneNumber);
                var _appEmailAddress = answers["26"]["answer"] != null ? answers["26"]["answer"].ToString() : "";

                var _checkExisting = answers["29"]["answer"].ToString() == "NO" ? 1 : 0;

                var InterpreterFullName = answers["44"]["answer"];
                var InterpreterGivenName = InterpreterFullName != null && InterpreterFullName["first"] !=null ? InterpreterFullName["first"].ToString() : "";
                var InterpreterFamilyName = InterpreterFullName != null && InterpreterFullName["last"] !=null ? InterpreterFullName["last"].ToString() : "";
                var InterpreterBusinessName = answers["45"]["answer"] != null ? answers["45"]["answer"].ToString() : "";
                var InterpreterDaytimeTelephoneNumber = answers["46"]["answer"] != null ? answers["46"]["answer"].ToString() : "";
                InterpreterDaytimeTelephoneNumber = Utility.GetNumbers(InterpreterDaytimeTelephoneNumber);
                var InterpreterMobileTelephoneNumber = answers["47"]["answer"] != null ? answers["47"]["answer"].ToString() : "";
                InterpreterMobileTelephoneNumber = Utility.GetNumbers(InterpreterMobileTelephoneNumber);
                var InterpreterEmailAddress = answers["49"]["answer"] != null ? answers["49"]["answer"].ToString() : "";
                var InterpreterSignatureLanguages = answers["50"]["answer"] != null ? answers["50"]["answer"].ToString() : "";

                var identification = answers["31"]["answer"] != null ? answers["31"]["answer"].ToString() : "";
                var documentIdentificationNumber = answers["32"]["answer"] != null ? answers["32"]["answer"].ToString() : "";

                var _answer = answers["35"]["answer"] != null ? answers["35"]["answer"].ToString() : "";
                var other = answers["53"]["answer"] != null ? answers["53"]["answer"].ToString() : "";
                var lawyerName = answers["52"]["answer"] != null ? answers["52"]["answer"].ToString() : "";

                

                
                var form = new SubmitFormModel();

                // InformationAboutYou data part

                var temp_InformationAboutYou = new Informationaboutyou();
                temp_InformationAboutYou._lastname = _lastname;
                temp_InformationAboutYou._firstname = _firstname;
                temp_InformationAboutYou._middlename = _middlename;
                
                temp_InformationAboutYou._addressStreet = _addressStreet;
                temp_InformationAboutYou._addressType = _addressType;
                temp_InformationAboutYou._addressNumber = _addressNumber;
                temp_InformationAboutYou._addressCity = _addressCity;

                var state = states.Find(em => em.name.Contains(_addressState));
                var state_enum = Enum.Parse(typeof(PatientExportModel.States), state.abbreviation);
                temp_InformationAboutYou._addressState = (int)state_enum;

                temp_InformationAboutYou._addressZip = _addressZip;

                temp_InformationAboutYou._sex = _sex;
                temp_InformationAboutYou._birth = _birth;
                temp_InformationAboutYou._birthCity = _birthCity;
                temp_InformationAboutYou._birthCountry = _birthCountry;
                temp_InformationAboutYou._alienRegistrationNumber = _alienRegistrationNumber;
                temp_InformationAboutYou._uscis = _uscis;
                temp_InformationAboutYou.medicalExamReq = medicalExamReq;
                form.InformationAboutYou = temp_InformationAboutYou;

                // Applicant data part
                var temp_Applicant = new Applicant();
                temp_Applicant._appDaytimeTelephoneNumber = _appDaytimeTelephoneNumber;
                temp_Applicant._appMobileTelephoneNumber = _appMobileTelephoneNumber;
                temp_Applicant._appEmailAddress = _appEmailAddress;
                form.Applicant = temp_Applicant;

                // Interpreter data part
                var temp_Interpreter = new Interpreter();
                temp_Interpreter.InterpreterFamilyName = InterpreterFamilyName;
                temp_Interpreter.InterpreterGivenName = InterpreterGivenName;
                temp_Interpreter.InterpreterBusinessName = InterpreterBusinessName;
                temp_Interpreter.InterpreterDaytimeTelephoneNumber = InterpreterDaytimeTelephoneNumber;
                temp_Interpreter.InterpreterMobileTelephoneNumber = InterpreterMobileTelephoneNumber;
                temp_Interpreter.InterpreterEmailAddress = InterpreterEmailAddress;
                temp_Interpreter.InterpreterSignatureLanguages = InterpreterSignatureLanguages;
                form.Interpreter = temp_Interpreter;

                // ApplicantID data part
                var temp_ApplicantID = new Applicantid();
                temp_ApplicantID.identification = identification;
                temp_ApplicantID.documentIdentificationNumber = documentIdentificationNumber;
                form.ApplicantID = temp_ApplicantID;

                // ApplicantID data part
                var temp_InterpreterExisting = new InterpreterExisting();
                temp_InterpreterExisting._checkExisting = _checkExisting;
                form.InterpreterExisting = temp_InterpreterExisting;

                try
                {
                    var form_data_json = new JavaScriptSerializer().Serialize(form);

                    var form_data = "{\"_form\":" + form_data_json + "}";

                    var _answer_val = (int)Enum.Parse(typeof(QuestionnaireResponse.Marketing_Source), _answer); 
                    var _extraData = _answer_val == 3? lawyerName:other;

                    using (SqlConnection connection = new SqlConnection(_conStr))
                    {
                        String query = "INSERT INTO dbo.form ([created_date]\r\n,[updated_date]\r\n," +
                            "[form_data]\r\n," +
                            "[answer]\r\n," +
                            "[submit_id]\r\n," +
                            "[source]\r\n," +
                            $"[extraData]) VALUES (@created_date,@updated_date,@form_data, '{_answer_val}','{submit_id}','jotform', '{_extraData}')";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@created_date", created_at);
                            command.Parameters.AddWithValue("@updated_date", updated_at);
                            command.Parameters.AddWithValue("@form_data", form_data);
                            connection.Open();
                            int result = command.ExecuteNonQuery();

                            // Check Error
                            if (result < 0)
                                Console.WriteLine("Error inserting data into Database!");
                        }
                    }
                }
                catch (Exception e)
                {

                }
            }
            return true;
        }

        public static bool SavePatients(List<FormData> items)
        {
            int resultCount = 0;
            foreach (var item in items)
            {
                var patient = new Patient();
                patient.UniqueId = item.Id;
                patient.I693Data = JsonConvert.SerializeObject(item);
                patient.CreatedDate = System.DateTime.Now;
                resultCount += SavePatientData(patient, item.Id);
            }

            if (resultCount > 0)
                return true;

            return false;
        }

        private static int SavePatientData(Patient model, int uniqueId)
        {
            int resultCount = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(_conStr))
                {
                    String query = $"IF NOT EXISTS (SELECT * FROM [dbo].[Patients] WHERE [UniqueId]='{uniqueId}') INSERT INTO [dbo].[Patients]\r\n([UniqueId]\r\n,[I693Data]\r\n,[CreatedDate])\r\n" +
                        $"VALUES ('{uniqueId}', @I693Data\r\n,'{model.CreatedDate}')";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@I693Data", model.I693Data);

                        connection.Open();
                        resultCount = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { }
            return resultCount;
        }     

        public static QuestionnaireStatistics GetStatistics(System.DateTime dt)
        {
            var qs = new QuestionnaireStatistics();
            qs._dateTime = dt;
            try
            {
                using (SqlConnection connection = new SqlConnection(_conStr))
                {
                    String query = $"SELECT [answer], count([answer]) as answer_cnt, STRING_AGG([extraData],'|') as extraData\r\n" +
                        $"FROM [AutoFiller_APP_DB].[dbo].[form]\r\n  WHERE [created_date] <= '{dt}'\r\n  GROUP BY [answer]";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        SqlDataReader dr = command.ExecuteReader();
                        while (dr.Read())
                        {
                            var answer = Convert.ToInt16(dr[0].ToString());
                            var answer_cnt = Convert.ToInt16(dr[1].ToString());
                            var extraData = dr[2].ToString();

                            switch ((int)answer)
                            {
                                case 0:
                                    qs._googleCount = answer_cnt;
                                    break;
                                case 1:
                                    qs._facebookCount = answer_cnt;
                                    break;
                                case 2:
                                    qs._yelpCount = answer_cnt;
                                    break;
                                case 3:
                                    qs._lawyerCount = answer_cnt;
                                    qs._lawyer = extraData;
                                    break;
                                case 4:
                                    qs._tvCount = answer_cnt;
                                    break;
                                case 5:
                                    qs._newspaperCount = answer_cnt;
                                    break;
                                case 6:
                                    qs._radioCount = answer_cnt;
                                    break;
                                case 7:
                                    qs._bingCount = answer_cnt;
                                    break;
                                case 8:
                                    qs._otherCount = answer_cnt;
                                    qs._other = extraData;
                                    break;
                            }
                        }
                        dr.Close();
                        ((IDisposable)dr).Dispose();
                    }
                }
                return qs;
            }
            catch
            {
            }
            MessageBox.Show(Utility.Constants.UNABLE_TO_RETRIEVE_DATA);
            return null;
        }

        public static List<System.DateTime> GetExistingStatistics()
        {
            var dates = new List<System.DateTime>();
            try
            {

                using (SqlConnection connection = new SqlConnection(_conStr))
                {
                    String query = "SELECT * FROM [dbo].[form]";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        SqlDataReader dr = command.ExecuteReader();
                        while (dr.Read())
                        {
                            var Id = dr[0].ToString();
                            var created_date = System.DateTime.Parse(dr[1].ToString());
                            dates.Add(created_date);
                        }
                        dr.Close();
                        ((IDisposable)dr).Dispose();
                    }
                }
                return dates;
            }
            catch (Exception e)
            {
            }
            MessageBox.Show(Utility.Constants.UNABLE_TO_RETRIEVE_DATA);
            return null;
        }

        public static bool UpdateFormData(FormData form)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_conStr))
                {
                    String query = "UPDATE dbo.form SET " +
                        $"[form_data]='{form.form_data}'\r\n" +
                        $"WHERE [Id]='{form.Id}'";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        // Check Error
                        if (result < 0)
                            return false;
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}
