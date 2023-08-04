using AutoFiller_API.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Dynamic;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;

namespace AutoFiller_APP.Model
{
    public class FormData
    {
        public int Id { get; set; }
        public DateTime created_date { get; set; }
        public DateTime updated_date { get; set; }
        public int answer { get; set; }
        public string extraData { get; set; }
        public string submit_id { get; set; }
        public string source { get; set; }
        public bool completed { get; set; }
        public string form_data { get; set; }

        public SubmitFormModel Convert2SubmitFormModel()
        {
            var form = new SubmitFormModel();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var d = jss.Deserialize<dynamic>(form_data);
            var data = d["_form"];

            // InformationAboutYou data part
            var data_InformationAboutYou = data["InformationAboutYou"];
            var temp_InformationAboutYou = new Informationaboutyou();
            temp_InformationAboutYou._lastname = data_InformationAboutYou["_lastname"];
            temp_InformationAboutYou._firstname = data_InformationAboutYou["_firstname"];
            temp_InformationAboutYou._middlename = data_InformationAboutYou["_middlename"];
            temp_InformationAboutYou._addressStreet = data_InformationAboutYou["_addressStreet"];
            temp_InformationAboutYou._addressType = data_InformationAboutYou["_addressType"];
            temp_InformationAboutYou._addressNumber = data_InformationAboutYou["_addressNumber"];
            temp_InformationAboutYou._addressCity = data_InformationAboutYou["_addressCity"];

            var _addressState = data_InformationAboutYou["_addressState"];

            if (Int32.TryParse(_addressState + "", out int j))
            {
                temp_InformationAboutYou._addressState = j;
            }
            else
            {
                temp_InformationAboutYou._addressState = data_InformationAboutYou["_addressState"];
            }
            temp_InformationAboutYou._addressZip = data_InformationAboutYou["_addressZip"];

            temp_InformationAboutYou._sex = data_InformationAboutYou["_sex"];
            temp_InformationAboutYou._birth = data_InformationAboutYou["_birth"];
            temp_InformationAboutYou._birthCity = data_InformationAboutYou["_birthCity"];
            temp_InformationAboutYou._birthCountry = data_InformationAboutYou["_birthCountry"];
            temp_InformationAboutYou._alienRegistrationNumber = data_InformationAboutYou["_alienRegistrationNumber"];
            temp_InformationAboutYou._uscis = data_InformationAboutYou["_uscis"];
            temp_InformationAboutYou.medicalExamReq = data_InformationAboutYou["medicalExamReq"];
            form.InformationAboutYou = temp_InformationAboutYou;

            // Applicant data part
            var data_Applicant = data["Applicant"];
            var temp_Applicant = new Applicant();
            temp_Applicant._appDaytimeTelephoneNumber = data_Applicant["_appDaytimeTelephoneNumber"];
            temp_Applicant._appMobileTelephoneNumber = data_Applicant["_appMobileTelephoneNumber"];
            temp_Applicant._appEmailAddress = data_Applicant["_appEmailAddress"];
            form.Applicant = temp_Applicant;

            // Interpreter data part
            var data_Interpreter = data["Interpreter"];
            var temp_Interpreter = new Interpreter();
            temp_Interpreter.InterpreterFamilyName = data_Interpreter["InterpreterFamilyName"];
            temp_Interpreter.InterpreterGivenName = data_Interpreter["InterpreterGivenName"];
            temp_Interpreter.InterpreterBusinessName = data_Interpreter["InterpreterBusinessName"];
            temp_Interpreter.InterpreterDaytimeTelephoneNumber = data_Interpreter["InterpreterDaytimeTelephoneNumber"];
            temp_Interpreter.InterpreterMobileTelephoneNumber = data_Interpreter["InterpreterMobileTelephoneNumber"];
            temp_Interpreter.InterpreterEmailAddress = data_Interpreter["InterpreterEmailAddress"];
            temp_Interpreter.InterpreterSignatureLanguages = data_Interpreter["InterpreterSignatureLanguages"];
            form.Interpreter = temp_Interpreter;

            // ApplicantID data part
            var data_ApplicantID = data["ApplicantID"];
            var temp_ApplicantID = new Applicantid();
            temp_ApplicantID.identification = data_ApplicantID["identification"];
            temp_ApplicantID.documentIdentificationNumber = data_ApplicantID["documentIdentificationNumber"];
            form.ApplicantID = temp_ApplicantID;

            // ApplicantID data part
            var interpreterExisting = data["InterpreterExisting"];
            var temp_InterpreterExisting = new InterpreterExisting();
            temp_InterpreterExisting._checkExisting = interpreterExisting["_checkExisting"];
            form.InterpreterExisting = temp_InterpreterExisting;

            return form;
        }
    }

    public class SubmitFormModel
    {
        public Informationaboutyou InformationAboutYou { get; set; }
        public Applicant Applicant { get; set; }
        public Interpreter Interpreter { get; set; }
        public Applicantid ApplicantID { get; set; }
        public InterpreterExisting InterpreterExisting { get; set; }
    }

    public class Informationaboutyou
    {
        public string _lastname { get; set; }
        public string _firstname { get; set; }
        public string _middlename { get; set; }
        //public string _inCareOfName { get; set; }
        public string _addressStreet { get; set; }
        public int _addressType { get; set; }
        public string _addressNumber { get; set; }
        public string _addressCity { get; set; }
        public int _addressState { get; set; }
        public string _addressZip { get; set; }
        public int _sex { get; set; }
        public string _birth { get; set; }
        public string _birthCity { get; set; }
        public string _birthCountry { get; set; }
        public string _alienRegistrationNumber { get; set; }
        public string _uscis { get; set; }
        public int medicalExamReq { get; set; }
    }

    public class Applicant
    {
        public string _appDaytimeTelephoneNumber { get; set; }
        public string _appMobileTelephoneNumber { get; set; }
        public string _appEmailAddress { get; set; }
    }

    public class Interpreter
    {
        public string InterpreterFamilyName { get; set; }
        public string InterpreterGivenName { get; set; }
        public string InterpreterBusinessName { get; set; }
        public string InterpreterDaytimeTelephoneNumber { get; set; }
        public string InterpreterMobileTelephoneNumber { get; set; }
        public string InterpreterEmailAddress { get; set; }
        public string InterpreterSignatureLanguages { get; set; }
    }

    public class Applicantid
    {
        public string identification { get; set; }
        public string documentIdentificationNumber { get; set; }
    }


    public class Howtoknow
    {
        public string how_hear { get; set; }
    }

    public class InterpreterExisting
    {
        public int _checkExisting { get; set; }
    }
}
