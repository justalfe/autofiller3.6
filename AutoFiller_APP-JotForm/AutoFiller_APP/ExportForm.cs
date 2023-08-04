using AutoFiller_APP.Entites;
using AutoFiller_APP.Model;
using ClosedXML.Excel;
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

            List<ItemGender> items = new List<ItemGender>();
            items.Add(new ItemGender() { Text = "Select Gender", Value = "Select Gender" });
            items.Add(new ItemGender() { Text = "Male", Value = "Male" });
            items.Add(new ItemGender() { Text = "Female", Value = "Female" });

            cmbGender.DataSource = items;
            cmbGender.DisplayMember = "Text";
            cmbGender.ValueMember = "Value";

        }

        private void ExportSCExcel_Click(object sender, EventArgs e)
        {
            var surgeons = new List<CivilSurgeonsExportModel>();
            using (SqlConnection connection = new SqlConnection(_conStr))
            {
                String query = "SELECT * FROM dbo.CivilSurgeons";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        var formData = dr[2].ToString();

                        var surgeon = JsonConvert.DeserializeObject<CivilSurgeonsExportModel>(formData);
                        surgeons.Add(surgeon);
                    }
                    dr.Close();
                    ((IDisposable)dr).Dispose();
                }
            }

            if (surgeons.Count > 0)
            {
                try
                {
                    //saving file in location 
                    using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
                    {
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            DataTable dt = new DataTable("SurgeonGrid");
                            dt.Columns.AddRange(new DataColumn[25] {
                                            new DataColumn("Id"),
                                            new DataColumn("First name"),
                                            new DataColumn("Middle Name"),
                                            new DataColumn("Last Name"),
                                            new DataColumn("Organization"),
                                            new DataColumn("Street Address"),
                                            new DataColumn("Address Type"),
                                            new DataColumn("Address Number"),
                                            new DataColumn("City"),
                                            new DataColumn("State"),
                                            new DataColumn("Zip"),
                                            new DataColumn("Province"),
                                            new DataColumn("Postal Code"),
                                            new DataColumn("Country"),
                                            new DataColumn("Mailing Street Address"),
                                            new DataColumn("Mailing Address Type"),
                                            new DataColumn("Mailing Address Number"),
                                            new DataColumn("Mailing City"),
                                            new DataColumn("Mailing State"),
                                            new DataColumn("Mailing Zip"),
                                            new DataColumn("Phone"),
                                            new DataColumn("Mobile Phone"),
                                            new DataColumn("Email"),
                                            new DataColumn("Preparer Statement A"),
                                            new DataColumn("Preparer Extatement Extends")
                         });


                            foreach (var item in surgeons)
                            {
                                dt.Rows.Add(
                                    item._id,
                                    item._firstName,
                                    item._middleName,
                                    item._lastName,
                                    item._organization,
                                    item._streetAddress,
                                    item._addressType,
                                    item._addressNumber,
                                    item._city,
                                    item._state,
                                    item._zip,
                                    item._mailingStreetAddress,
                                    item._mailingAddressType,
                                    item._mailingAddressNumber,
                                    item._mailingCity,
                                    item._mailingState,
                                    item._mailingZip,
                                    item._Phone,
                                    item._MobilePhone,
                                    item._Email,
                                    item._preparerStatementA,
                                    item._preparerExtatementExtends);
                            }


                            using (XLWorkbook workbook = new XLWorkbook())
                            {
                                workbook.Worksheets.Add(dt, "CivilSurgeons");
                                workbook.SaveAs(sfd.FileName);
                                MessageBox.Show("Civil Surgeon data exported successfully.");
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception occured in export process.");
                }
            }

        }

        private void ExportPrpExcel_Click(object sender, EventArgs e)
        {

            var preparerModel = new List<PreparerExportModel>();
            using (SqlConnection connection = new SqlConnection(_conStr))
            {
                String query = "SELECT * FROM dbo.Preparers";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        var formData = dr[2].ToString();

                        var preparer = JsonConvert.DeserializeObject<PreparerExportModel>(formData);
                        preparerModel.Add(preparer);
                    }
                    dr.Close();
                    ((IDisposable)dr).Dispose();
                }
            }


            if (preparerModel.Count > 0)
            {
                try
                {
                    //saving file in location 
                    using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
                    {
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            DataTable dt = new DataTable("PreparerTable");
                            dt.Columns.AddRange(new DataColumn[25] {
                                            new DataColumn("Id"),
                                            new DataColumn("First Name"),
                                            new DataColumn("Middle Name"),
                                            new DataColumn("Last Name"),
                                            new DataColumn("Organization"),
                                            new DataColumn("Street Address"),
                                            new DataColumn("Address Type"),
                                            new DataColumn("Address Number"),
                                            new DataColumn("City"),
                                            new DataColumn("State"),
                                            new DataColumn("Zip"),
                                            new DataColumn("Province"),
                                            new DataColumn("PostalCode"),
                                            new DataColumn("Country"),
                                            new DataColumn("Mailing Street Address"),
                                            new DataColumn("Mailing Address Type"),
                                            new DataColumn("Mailing Address Number"),
                                            new DataColumn("Mailing City"),
                                            new DataColumn("Mailing State"),
                                            new DataColumn("Mailing Zip"),
                                            new DataColumn("Phone"),
                                            new DataColumn("Mobile Phone"),
                                            new DataColumn("Email"),
                                            new DataColumn("Preparer Statement A"),
                                            new DataColumn("Preparer Extatement Extends")
                         });


                            foreach (var item in preparerModel)
                            {
                                dt.Rows.Add(item._id, item._lastName, item._firstName,
                                    item._organization,
                                    item._Phone,
                                    item._MobilePhone,
                                    item._Email
                                );
                            }


                            using (XLWorkbook workbook = new XLWorkbook())
                            {
                                workbook.Worksheets.Add(dt, "Preparers");
                                workbook.SaveAs(sfd.FileName);
                                MessageBox.Show("Preparers data exported successfully.");
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception occured in export process.");
                }
            }
        }

        private void ExportPatientData_Click(object sender, EventArgs e)
        {
            var patients = new List<PatientExportModel>();
            using (SqlConnection connection = new SqlConnection(_conStr))
            {
                String query = "SELECT * FROM dbo.Patients";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        var formData = dr[2].ToString();

                        var preparer = JsonConvert.DeserializeObject<PatientExportModel>(formData);
                        patients.Add(preparer);
                    }
                    dr.Close();
                    ((IDisposable)dr).Dispose();
                }
            }


            var gender = string.IsNullOrEmpty(cmbGender?.SelectedValue?.ToString()) || cmbGender.SelectedValue.ToString().Equals("Select Gender") ? "" : cmbGender.SelectedValue.ToString();


            var patientModel =
                      patients.PatientFilters(AllCheckBox.Checked, startDateBox.Value, endDateBox.Value, gender, txtAddress.Text, txtPhone.Text, txtEmail.Text);


            if (patientModel.Count > 0)
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
                            dt.Columns.AddRange(new DataColumn[42] {
                                            new DataColumn("UniqueId"),
                                            new DataColumn("Applicant First Name"),
                                            new DataColumn("Applicant Middle Name"),
                                            new DataColumn("Applicant Last Name"),
                                            new DataColumn("Applicant Address Type"),
                                            new DataColumn("Applicant Street"),
                                            new DataColumn("Applicant City"),
                                            new DataColumn("Applicant State"),
                                            new DataColumn("Applicant Zip"),
                                            new DataColumn("Applicant Birth"),
                                            new DataColumn("Applicant Birth City"),
                                            new DataColumn("Applicant Birth Country"),
                                            new DataColumn("Applicant Sex"),
                                            new DataColumn("Applicant Alien Registration Number"),
                                            new DataColumn("Applicant Uscis"),
                                            new DataColumn("Applicant Statement 1aORb"),
                                            new DataColumn("Applicant Statetemnt 1bfield"),
                                            new DataColumn("Applicant Phone Number"),
                                            new DataColumn("Applicant Mobile Phone"),
                                            new DataColumn("Applicant Email"),
                                            new DataColumn("Applicant Signature"),
                                            new DataColumn("Applicant Date Of Signature"),
                                            new DataColumn("Applicant Identification Type "),
                                            new DataColumn("Applicant Identification Number"),
                                            new DataColumn("Interpreter First Name"),
                                            new DataColumn("Interpreter Last Name"),
                                            new DataColumn("Interpreter Organization"),
                                            new DataColumn("Interpreter Street Address"),
                                            new DataColumn("Interpreter Address Type"),
                                            new DataColumn("Interpreter Address Number"),
                                            new DataColumn("Interpreter City"),
                                            new DataColumn("Interpreter State"),
                                            new DataColumn("Interpreter Zip"),
                                            new DataColumn("Interpreter Province"),
                                            new DataColumn("Interpreter Postal Code"),
                                            new DataColumn("Interpreter Country"),
                                            new DataColumn("Interpreter Phone"),
                                            new DataColumn("Interpreter Mobile Phone"),
                                            new DataColumn("Interpreter Email"),
                                            new DataColumn("Interpreter Language"),
                                            new DataColumn("Interpreter Signature"),
                                            new DataColumn("Interpreter Signature Date")
                         });

                            foreach (var item in patientModel)
                            {
                                dt.Rows.Add(item._uniqueId,
                                    item._firstname,
                                    item._middlename,
                                    item._lastname,
                                    item._addressType,
                                    item._addressStreet,
                                    item._addressCity,
                                    item._addressState,
                                    item._addressZip,
                                    item._birth,
                                    item._birthCity,
                                    item._birthCountry,
                                    item._sex,
                                    item._alienRegistrationNumber,
                                    item._uscis,
                                    item._applicantIdentificationType,
                                    item._applicantIdentificationNumber,
                                    item._interpreterName,
                                    item._interpreterLastName,
                                    item._interpreterOrganization,
                                    item._interpreterStreetAddress,
                                    item._interpreterAddressType,
                                    item._interpreterAddressNumber,
                                    item._interpreterCity,
                                    item._interpreterState,
                                    item._interpreterZip,
                                    item._interpreterProvince,
                                    item._interpreterPostalCode,
                                    item._interpreterCountry,
                                    item._interpreterPhone,
                                    item._interpreterMobilePhone,
                                    item._interpreterEmail,
                                    item._interpreterLanguage,
                                    item._interpreterSignature,
                                    item._interpreterSignatureDate
                                    );
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

        private void AllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            startDateBox.Enabled = (!AllCheckBox.Checked);
            endDateBox.Enabled = (!AllCheckBox.Checked);
        }

    }
}



