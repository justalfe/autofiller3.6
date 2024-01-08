using AutoFiller_APP.Entites;
using AutoFiller_APP.Manager;
using AutoFiller_APP.Model;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace AutoFiller_APP
{
    public partial class ExportForm : Form
    {
        public static string _conStr = Utility.GetServerString();
        public ExportForm()
        {
            InitializeComponent();
        }
        private void ExportPatientData_Click(object sender, EventArgs e)
        {
            var patients = new List<FormData>();
            using (SqlConnection connection = new SqlConnection(_conStr))
            {
                String query = "SELECT * FROM dbo.Patients";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();

                    var data = new FormData();
                    while (dr.Read())
                    {
                        var formData = dr[2].ToString();
                        var patient = APIManager.Convert2Patient(formData);
                        if (patient.created_date >= startDateBox.Value && patient.created_date < endDateBox.Value)
                        {
                            patients.Add(patient);
                        }
                    }
                    dr.Close();
                    ((IDisposable)dr).Dispose();
                }
            }

            if (patients.Count > 0)
            {
                try
                {
                    //saving file in location 
                    using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
                    {
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            var properties = typeof(PatientExportModel).GetProperties();
                            DataTable dt = new DataTable("PatientDataTable");

                            if (chkName.Checked)
                            {
                                dt.Columns.Add(new DataColumn("First Name"));
                                dt.Columns.Add(new DataColumn("Middle Name"));
                                dt.Columns.Add(new DataColumn("Last Name"));
                            }
                            dt.Columns.Add(new DataColumn("Address Type"));
                            dt.Columns.Add(new DataColumn("Street"));
                            if (chkCity.Checked)
                            {
                                dt.Columns.Add(new DataColumn("City"));
                            }
                            if (chkState.Checked)
                            {
                                dt.Columns.Add(new DataColumn("State"));
                            }
                            dt.Columns.Add(new DataColumn("Zip"));
                            if (chkDob.Checked)
                            {
                                dt.Columns.Add(new DataColumn("Birth"));
                            }
                            if (chkCountryOfBirth.Checked)
                            {
                                dt.Columns.Add(new DataColumn("Birth City"));
                                dt.Columns.Add(new DataColumn("Birth Country"));
                            }
                            dt.Columns.Add(new DataColumn("Sex"));
                            dt.Columns.Add(new DataColumn("Alien Registration Number"));
                            dt.Columns.Add(new DataColumn("Uscis"));
                            if (chkPhone.Checked)
                            {
                                dt.Columns.Add(new DataColumn("Phone Number"));
                                dt.Columns.Add(new DataColumn("Mobile Number"));
                            }
                            if (chkEmail.Checked)
                            {
                                dt.Columns.Add(new DataColumn("Email"));
                            }
                            dt.Columns.Add(new DataColumn("Interpreter First Name"));
                            dt.Columns.Add(new DataColumn("Interpreter Last Name"));
                            dt.Columns.Add(new DataColumn("Interpreter Phone Number"));
                            dt.Columns.Add(new DataColumn("Interpreter Mobile Number"));
                            dt.Columns.Add(new DataColumn("Interpreter Email"));
                            dt.Columns.Add(new DataColumn("Interpreter Language"));
                            if (chkReferred.Checked)
                            {
                                dt.Columns.Add(new DataColumn("Referred By"));
                            }

                            foreach (var patient in patients)
                            {
                                DataRow newRow = dt.NewRow();
                                var item = patient.submit_form_model;
                                if (chkName.Checked)
                                {
                                    newRow["First Name"] = item.InformationAboutYou._firstname;
                                    newRow["Middle Name"] = item.InformationAboutYou._middlename;
                                    newRow["Last Name"] = item.InformationAboutYou._lastname;
                                }
                                newRow["Address Type"] = APIManager.GetAddressTypeString(item.InformationAboutYou._addressType);
                                newRow["Street"] = item.InformationAboutYou._addressStreet;

                                if (chkCity.Checked)
                                {
                                    newRow["City"] = item.InformationAboutYou._addressCity;
                                }
                                if (chkState.Checked)
                                {
                                    newRow["State"] = Enum.GetName(typeof(PatientExportModel.States), item.InformationAboutYou._addressState); 
                                }
                                newRow["Zip"] = item.InformationAboutYou._addressZip;
                                if (chkDob.Checked)
                                {
                                    newRow["Birth"] = item.InformationAboutYou._birth;
                                }
                                if (chkCountryOfBirth.Checked)
                                {
                                    newRow["Birth City"] = item.InformationAboutYou._birthCity;
                                    newRow["Birth Country"] = item.InformationAboutYou._birthCountry;
                                }
                                newRow["Sex"] = item.InformationAboutYou._sex == 0?"Male":"Female";
                                newRow["Alien Registration Number"] = item.InformationAboutYou._alienRegistrationNumber;
                                newRow["Uscis"] = item.InformationAboutYou._uscis;

                                if (chkPhone.Checked)
                                {
                                    newRow["Phone Number"] = item.Applicant._appDaytimeTelephoneNumber;
                                    newRow["Mobile Number"] = item.Applicant._appMobileTelephoneNumber;
                                }
                                if (chkEmail.Checked)
                                {
                                    newRow["Email"] = item.Applicant._appEmailAddress;
                                }
                                newRow["Interpreter First Name"] = item.Interpreter.InterpreterFamilyName;
                                newRow["Interpreter Last Name"] = item.Interpreter.InterpreterGivenName;
                                newRow["Interpreter Phone Number"] = item.Interpreter.InterpreterDaytimeTelephoneNumber;
                                newRow["Interpreter Mobile Number"] = item.Interpreter.InterpreterMobileTelephoneNumber;
                                newRow["Interpreter Email"] = item.Interpreter.InterpreterEmailAddress;
                                newRow["Interpreter Language"] = item.Interpreter.InterpreterSignatureLanguages;


                                if (chkReferred.Checked)
                                {
                                    var answer = APIManager.GetReferredBy(patient.answer, patient.extraData);
                                    newRow["Referred By"] = answer;
                                }
                                dt.Rows.Add(newRow);
                            }

                            using (XLWorkbook workbook = new XLWorkbook())
                            {
                                workbook.Worksheets.Add(dt, "PatientsSheet");
                                workbook.SaveAs(sfd.FileName);
                                MessageBox.Show("Patients exported successfully.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception occured in export process.");
                }

            }
            else
            {
                MessageBox.Show("Records not found!");
            }

        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if(chkAll.Checked)
            {
                chkName.Checked = true;
                chkDob.Checked = true;
                chkCountryOfBirth.Checked = true;
                chkCity.Checked = true;
                chkState.Checked = true;
                chkPhone.Checked = true;
                chkEmail.Checked = true;
                chkReferred.Checked = true;
            }
            else
            {
                chkName.Checked = false;
                chkDob.Checked = false;
                chkCountryOfBirth.Checked = false;
                chkCity.Checked = false;
                chkState.Checked = false;
                chkPhone.Checked = false;
                chkEmail.Checked = false;
                chkReferred.Checked = false;
            }
        }
    }
}



