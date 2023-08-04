using AutoFiller_APP.Entites;
using AutoFiller_APP.Model;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Bibliography;
using DYMO.Common;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoFiller_APP.Manager
{
    class PDFManager
    {
        //public const string SOURCE_PDF_FILE = "./resources/i693d.pdf";
        //public const string SOURCE_PDF_FILE = "./resources/i-693.pdf";
        //public const string OUTPUT_PDF_FILE = "./out.pdf";

        public static void ExportPDF(FormData formData, string _destinationFile, CivilSurgeon_Preparer surgeon, CivilSurgeon_Preparer preparer)
        {
            var source = formData.Convert2SubmitFormModel();
            try
            {
                var path = Application.StartupPath + @"\resources\i693d.pdf";

                PdfReader pdfReader = new PdfReader(path);
                PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(_destinationFile, FileMode.Create), '\0', true);
                AcroFields pdfFormFields = pdfStamper.AcroFields;


                var keys = pdfFormFields.Fields.Keys.Cast<string>().ToList();

                var create_date = formData.created_date.ToString("MM/dd/yyyy");
                create_date = create_date.Replace('-', '/');

                // ===== Page 4 Date of First Examination =====
                pdfFormFields.SetField("form1[0].#subform[3].Pt6Line2_DateoExam[0]", create_date);

                // ===== page 6 Date Blood Same Drawn =====
                pdfFormFields.SetField("form1[0].#subform[5].Pt8Line1A1_QFDate[0]", create_date);

                // ===== Page 7 Date Nontreponemal Test collected =====
                pdfFormFields.SetField("form1[0].#subform[6].Pt8Line1B1b_DateNontrepoemaltest[0]", create_date);



                //part1 data

                pdfFormFields.SetField("form1[0].#subform[0].Pt1Line1a_FamilyName[0]", source.InformationAboutYou._lastname.ToUpper());
                pdfFormFields.SetField("form1[0].#subform[0].Pt1Line1b_GivenName[0]", source.InformationAboutYou._firstname.ToUpper());
                pdfFormFields.SetField("form1[0].#subform[0].Pt1Line1c_MiddleName[0]", source.InformationAboutYou._middlename.ToUpper());

                //pdfFormFields.SetField("form1[0].#subform[0].Pt1Line2_StreetNumberName[1]", source.InformationAboutYou._inCareOfName.ToUpper());
                pdfFormFields.SetField("form1[0].#subform[0].Pt1Line2_StreetNumberName[0]", source.InformationAboutYou._addressStreet.ToUpper());

                switch (source.InformationAboutYou._addressType)
                {
                    case 0:
                        pdfFormFields.SetField("form1[0].#subform[0].Pt1Line2_Unit", " APT ");
                        break;
                    case 1:
                        pdfFormFields.SetField("form1[0].#subform[0].Pt1Line2_Unit", " STE ");
                        break;
                    case 2:
                        pdfFormFields.SetField("form1[0].#subform[0].Pt1Line2_Unit", " FLR ");
                        break;
                }
                pdfFormFields.SetField("form1[0].#subform[0].Pt1Line2_AptSteFlrNumber[0]", source.InformationAboutYou._addressNumber.ToUpper());
                pdfFormFields.SetField("form1[0].#subform[0].P1Line2_CityOrTown[0]", source.InformationAboutYou._addressCity.ToUpper());
                pdfFormFields.SetField("form1[0].#subform[0].P1Line2_State", Enum.GetName(typeof(PatientExportModel.States), source.InformationAboutYou._addressState));
                pdfFormFields.SetField("form1[0].#subform[0].P1Line2_ZipCode[0]", source.InformationAboutYou._addressZip.ToUpper());

                switch (source.InformationAboutYou._sex)
                {
                    case 0:
                        pdfFormFields.SetField("form1[0].#subform[0].Pt1Line3_Gender", "M");
                        break;
                    case 1:
                        pdfFormFields.SetField("form1[0].#subform[0].Pt1Line3_Gender", "F");
                        break;
                }

                var dateTime = DateTime.Parse(source.InformationAboutYou._birth);
                var _birth = dateTime.ToString("MM/dd/yyyy");
                _birth = _birth.Replace('-', '/');

                pdfFormFields.SetField("form1[0].#subform[0].Pt1Line3_DateOfBirth[0]", _birth);
                pdfFormFields.SetField("form1[0].#subform[0].Pt1Line3_CityTownVillageofBirth[0]", source.InformationAboutYou._birthCity.ToUpper());
                pdfFormFields.SetField("form1[0].#subform[0].Pt1Line3_CountryofBirth[0]", source.InformationAboutYou._birthCountry.ToUpper());
                pdfFormFields.SetField("form1[0].#subform[0].#area[0].Pt1Line3e_AlienNumber[0]", source.InformationAboutYou._alienRegistrationNumber.ToUpper());
                pdfFormFields.SetField("form1[0].#subform[0].Pt1Line3f_USCISOnlineAcctNumber[0]", source.InformationAboutYou._uscis.ToUpper());
                if (source.InformationAboutYou.medicalExamReq == 1)
                {
                    pdfFormFields.SetField("form1[0].#subform[0].Pt1_Line4_ImmMedExamReq", "A");
                }

                //part2 data
                pdfFormFields.SetField("form1[0].#subform[1].Pt2Line3_DaytimePhone[0]", source.Applicant._appDaytimeTelephoneNumber.ToUpper());
                pdfFormFields.SetField("form1[0].#subform[1].Pt2Line4_Mobilephone[0]", source.Applicant._appMobileTelephoneNumber.ToUpper());
                pdfFormFields.SetField("form1[0].#subform[1].Pt2Line5_EmailAddress[0]", source.Applicant._appEmailAddress.ToUpper());

                if (source.InterpreterExisting._checkExisting == 0)
                {
                    //part3 data
                    pdfFormFields.SetField("form1[0].#subform[1].Pt3Line1_InterpreterFamilyName[0]", source.Interpreter.InterpreterFamilyName.ToUpper());
                    pdfFormFields.SetField("form1[0].#subform[1].Pt3Line1_InterpreterGivenName[0]", source.Interpreter.InterpreterGivenName.ToUpper());
                    pdfFormFields.SetField("form1[0].#subform[1].Pt3Line2_NameofBusinessorOrgName[0]", source.Interpreter.InterpreterBusinessName.ToUpper());
                    pdfFormFields.SetField("form1[0].#subform[1].Pt3Line4_DaytimePhone[0]", source.Interpreter.InterpreterDaytimeTelephoneNumber.ToUpper());
                    pdfFormFields.SetField("form1[0].#subform[1].Pt3Line5_MobilePhone[0]", source.Interpreter.InterpreterMobileTelephoneNumber.ToUpper());
                    pdfFormFields.SetField("form1[0].#subform[1].Pt3Line6_EmailAddress[0]", source.Interpreter.InterpreterEmailAddress.ToUpper());
                    pdfFormFields.SetField("form1[0].#subform[2].Pt3Line_NameOfLanguage[0]", source.Interpreter.InterpreterSignatureLanguages.ToUpper());
                }
                //part4 preparer

                if (preparer != null)
                {
                    if (preparer._lastName!=null) pdfFormFields.SetField("form1[0].#subform[2].Pt4Line1_PreparerFamilyName[0]", preparer._lastName.ToUpper());
                    if (preparer._firstName != null) pdfFormFields.SetField("form1[0].#subform[2].Pt4Line1_PreparerGivenName[0]", preparer._firstName.ToUpper());
                    if (preparer._organization != null) pdfFormFields.SetField("form1[0].#subform[2].Pt4Line2_PreparerNameofBusinessorOrgName[0]", preparer._organization.ToUpper());
                    if (preparer._Phone != null) pdfFormFields.SetField("form1[0].#subform[2].Pt4Line3_DaytimePhone[0]", preparer._Phone.ToUpper());
                    if (preparer._MobilePhone != null) pdfFormFields.SetField("form1[0].#subform[2].Pt4Line4_MobilePhone[0]", preparer._MobilePhone.ToUpper());
                    if (preparer._Email != null) pdfFormFields.SetField("form1[0].#subform[2].Pt4Line5_EmailAddress[0]", preparer._Email.ToUpper());
                }

                //part5 data
                pdfFormFields.SetField("form1[0].#subform[2].Pt5Line1_ApplicantFormOfID[0]", source.ApplicantID.identification.ToUpper());
                pdfFormFields.SetField("form1[0].#subform[2].Pt5Line2_IDNumber[0]", source.ApplicantID.documentIdentificationNumber.ToUpper());

                //part 7 surgeon
                if (surgeon != null)
                {
                    if (surgeon._lastName != null) pdfFormFields.SetField("form1[0].#subform[3].Pt7Line1_FamilyName[0]", surgeon._lastName.ToUpper());
                    if (surgeon._firstName != null) pdfFormFields.SetField("form1[0].#subform[3].Pt7Line1_GivenName[0]", surgeon._firstName.ToUpper());
                    if (surgeon._middleName != null) pdfFormFields.SetField("form1[0].#subform[3].Pt7Line1_MiddleName[0]", surgeon._middleName.ToUpper());
                    if (surgeon._csid != null) pdfFormFields.SetField("form1[0].#subform[3].Pt7Line1_CivilSurgeonID[0]", surgeon._csid.ToUpper());
                    if (surgeon._organization != null) pdfFormFields.SetField("form1[0].#subform[3].Pt7Line2_MedPracticeName[0]", surgeon._organization.ToUpper());
                    if (surgeon._streetAddress != null) pdfFormFields.SetField("form1[0].#subform[3].Pt7Line3_StreetNumberName[0]", surgeon._streetAddress.ToUpper());

                    switch (surgeon._addressType)
                    {
                        case 0:
                            pdfFormFields.SetField("form1[0].#subform[3].Pt7Line3_Unit", " APT ");
                            break;
                        case 1:
                            pdfFormFields.SetField("form1[0].#subform[3].Pt7Line3_Unit", " STE ");
                            break;
                        case 2:
                            pdfFormFields.SetField("form1[0].#subform[3].Pt7Line3_Unit", " FLR ");
                            break;
                    }

                    if (surgeon._addressNumber != null) pdfFormFields.SetField("form1[0].#subform[3].Pt7Line3_AptSteFlrNumber[0]", surgeon._addressNumber.ToUpper());
                    if (surgeon._city != null) pdfFormFields.SetField("form1[0].#subform[3].Pt7Line3_CityOrTown[0]", surgeon._city);
                    if (surgeon._state >= 0) pdfFormFields.SetField("form1[0].#subform[3].Pt7Line3_State[0]", Enum.GetName(typeof(PatientExportModel.States), surgeon._state));
                    if (surgeon._zip != null) pdfFormFields.SetField("form1[0].#subform[3].Pt7Line3_ZipCode[0]", surgeon._zip.ToUpper());
                    if (surgeon._mailingStreetAddress != null) pdfFormFields.SetField("form1[0].#subform[3].Pt7Line4_StreetNumberName[0]", surgeon._mailingStreetAddress.ToUpper());
                    switch (surgeon._mailingAddressType)
                    {
                        case 0:
                            pdfFormFields.SetField("form1[0].#subform[3].Pt7Line4_Unit", " APT ");
                            break;
                        case 1:
                            pdfFormFields.SetField("form1[0].#subform[3].Pt7Line4_Unit", " STE ");
                            break;
                        case 2:
                            pdfFormFields.SetField("form1[0].#subform[3].Pt7Line4_Unit", " FLR ");
                            break;
                    }
                    if (surgeon._mailingAddressNumber != null) pdfFormFields.SetField("form1[0].#subform[3].Pt7Line4_AptSteFlrNumber[0]", surgeon._mailingAddressNumber.ToUpper());
                    if (surgeon._mailingCity != null) pdfFormFields.SetField("form1[0].#subform[3].Pt7Line4_CityOrTown[0]", surgeon._mailingCity.ToUpper());
                    if (surgeon._mailingState >= 0) pdfFormFields.SetField("form1[0].#subform[3].Pt7Line4_State[0]", Enum.GetName(typeof(PatientExportModel.States), surgeon._mailingState));
                    if (surgeon._mailingZip != null) pdfFormFields.SetField("form1[0].#subform[3].Pt7Line4_ZipCode[0]", surgeon._mailingZip.ToUpper());
                    if (surgeon._Phone != null) pdfFormFields.SetField("form1[0].#subform[3].Pt7Line5_DaytimePhone[0]", surgeon._Phone.ToUpper());
                    if (surgeon._MobilePhone != null) pdfFormFields.SetField("form1[0].#subform[3].Pt7Line6_MobilePhone[0]", surgeon._MobilePhone.ToUpper());
                    if (surgeon._Email != null) pdfFormFields.SetField("form1[0].#subform[3].Pt7Line7_EmailAddress[0]", surgeon._Email.ToUpper());
                }

                pdfStamper.FormFlattening = false;
                pdfStamper.Close();

                System.Diagnostics.Process.Start(_destinationFile);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public static void UpdateEntries(string key, List<string> allKeys, AcroFields fields, string content)
        {
            var entries = allKeys.Where(x => x.Contains(key));
            foreach (var entry in entries)
                fields.SetField(entry, content);
        }

        public static string GetDateStringFormat(DateTime t)
        {
            return string.Format("{0}/{1}/{2}", t.Month.ToString("00"), t.Day.ToString("00"), t.Year);
        }
    }
}
