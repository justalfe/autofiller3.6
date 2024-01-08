using AutoFiller_API.Model;
using AutoFiller_APP.Manager;
using AutoFiller_APP.Model;
using DocumentFormat.OpenXml.EMMA;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace AutoFiller_APP
{
    public partial class I693Form : Form
    {
        public SubmitFormModel _sourceForm = new SubmitFormModel();
        public FormData _formData = new FormData();
        public I693Form(FormData form)
        {
            InitializeComponent();
            _formData = form;
            _sourceForm = form.Convert2SubmitFormModel();
            foreach (var state in (I693.States[])Enum.GetValues(typeof(I693.States)))
            {
                _addressState.Items.Add(state.ToString());
            }
            _addressType.Items.Add("APT");
            _addressType.Items.Add("STE");
            _addressType.Items.Add("FLR");
            _addressType.Items.Add("");

            _sex.Items.Add("Male");
            _sex.Items.Add("Female");

            var answer = APIManager.GetReferredBy(form.answer, form.extraData);
            lblRefere.Text = answer;

            _lastname.Text = _sourceForm.InformationAboutYou._lastname;
            _firstname.Text = _sourceForm.InformationAboutYou._firstname;

            _middlename.Text = _sourceForm.InformationAboutYou._middlename;
            _addressStreet.Text = _sourceForm.InformationAboutYou._addressStreet;
            _addressType.SelectedIndex = (int)_sourceForm.InformationAboutYou._addressType;
            _addressNumber.Text = _sourceForm.InformationAboutYou._addressNumber;
            _addressCity.Text = _sourceForm.InformationAboutYou._addressCity;
            _addressState.SelectedIndex = _sourceForm.InformationAboutYou._addressState;
            _addressZip.Text = _sourceForm.InformationAboutYou._addressZip;

            _sex.SelectedIndex = (int)_sourceForm.InformationAboutYou._sex;
            _birth.Value = DateTime.Parse(_sourceForm.InformationAboutYou._birth);
            _birthCity.Text = _sourceForm.InformationAboutYou._birthCity;
            _birthCountry.Text = _sourceForm.InformationAboutYou._birthCountry;
            _alienRegistrationNumber.Text = _sourceForm.InformationAboutYou._alienRegistrationNumber;
            _uscis.Text = _sourceForm.InformationAboutYou._uscis;
            chkMedicalExam.Checked = _sourceForm.InformationAboutYou.medicalExamReq == 0? false:true;


            _applicantPhoneNumber.Text = _sourceForm.Applicant._appDaytimeTelephoneNumber;
            _applicantMobileNumber.Text = _sourceForm.Applicant._appMobileTelephoneNumber;
            _applicantEmail.Text = _sourceForm.Applicant._appEmailAddress;


            _applicantIdentificationType.Text = _sourceForm.ApplicantID.identification;
            _applicantIdentificationNumber.Text = _sourceForm.ApplicantID.documentIdentificationNumber;

            if(_sourceForm.InterpreterExisting._checkExisting == 0)
            {
                chkInterpreterExisting.Checked = true;
                _interpreterLastName.Text = _sourceForm.Interpreter.InterpreterFamilyName;
                _interpreterName.Text = _sourceForm.Interpreter.InterpreterGivenName;
                _interpreterOrganization.Text = _sourceForm.Interpreter.InterpreterBusinessName;
                _interpreterPhone.Text = _sourceForm.Interpreter.InterpreterDaytimeTelephoneNumber;
                _interpreterMobilePhone.Text = _sourceForm.Interpreter.InterpreterMobileTelephoneNumber;
                _interpreterEmail.Text = _sourceForm.Interpreter.InterpreterEmailAddress;
                txtInterpreterLan.Text = _sourceForm.Interpreter.InterpreterSignatureLanguages;
            }
            else
            {
                gbxInterpreter.Hide();
            }

        }

        private void _exportButton_Click(object sender, EventArgs e)
        {
            var fileDialog = new SaveFileDialog();
            fileDialog.FileName = _lastname.Text.Replace(" ", "") + ".pdf";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                var fileSplit = fileDialog.FileName.Split('.');
                if (fileSplit[fileSplit.Length - 1].ToLower() != "pdf")
                    fileDialog.FileName += ".pdf";

                PDFManager.ExportPDF(_formData,
                fileDialog.FileName, Main._instance._selectedSurgeon, Main._instance._selectedPreparer);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DymoManager.Print(_firstname.Text, _lastname.Text, _birth.Value);
        }

        private void chkInterpreterExisting_CheckedChanged(object sender, EventArgs e)
        {
            if(chkInterpreterExisting.Checked)
            {
                gbxInterpreter.Show();
            }
            else
            {
                gbxInterpreter.Hide();
            }
        }

        private void btnUpdateForm_Click(object sender, EventArgs e)
        {
            _sourceForm.InformationAboutYou._lastname = _lastname.Text;
            _sourceForm.InformationAboutYou._firstname = _firstname.Text;
            _sourceForm.InformationAboutYou._middlename = _middlename.Text;
            _sourceForm.InformationAboutYou._addressStreet = _addressStreet.Text;
            _sourceForm.InformationAboutYou._addressType = _addressType.SelectedIndex;
            _sourceForm.InformationAboutYou._addressNumber = _addressNumber.Text;
            _sourceForm.InformationAboutYou._addressCity = _addressCity.Text;
            _sourceForm.InformationAboutYou._addressState = _addressState.SelectedIndex;
            _sourceForm.InformationAboutYou._addressZip = _addressZip.Text;
            _sourceForm.InformationAboutYou._sex = _sex.SelectedIndex;
            _sourceForm.InformationAboutYou._birth = _birth.Value.ToShortDateString();
            _sourceForm.InformationAboutYou._birthCity = _birthCity.Text;
            _sourceForm.InformationAboutYou._birthCountry = _birthCountry.Text;
            _sourceForm.InformationAboutYou._alienRegistrationNumber = _alienRegistrationNumber.Text;
            _sourceForm.InformationAboutYou._uscis = _uscis.Text;
            _sourceForm.InformationAboutYou.medicalExamReq = chkMedicalExam.Checked ? 1 : 0;
            _sourceForm.Applicant._appDaytimeTelephoneNumber = _applicantPhoneNumber.Text;
            _sourceForm.Applicant._appMobileTelephoneNumber = _applicantMobileNumber.Text;
            _sourceForm.Applicant._appEmailAddress = _applicantEmail.Text;
            _sourceForm.ApplicantID.identification = _applicantIdentificationType.Text;
            _sourceForm.ApplicantID.documentIdentificationNumber = _applicantIdentificationNumber.Text;
            _sourceForm.InterpreterExisting._checkExisting = chkInterpreterExisting.Checked ? 0 : 1;
            _sourceForm.Interpreter.InterpreterFamilyName = _interpreterLastName.Text;
            _sourceForm.Interpreter.InterpreterGivenName = _interpreterName.Text;
            _sourceForm.Interpreter.InterpreterBusinessName = _interpreterOrganization.Text;
            _sourceForm.Interpreter.InterpreterDaytimeTelephoneNumber = _interpreterPhone.Text;
            _sourceForm.Interpreter.InterpreterMobileTelephoneNumber = _interpreterMobilePhone.Text;
            _sourceForm.Interpreter.InterpreterEmailAddress = _interpreterEmail.Text;
            _sourceForm.Interpreter.InterpreterSignatureLanguages = txtInterpreterLan.Text;

            var form_data_json = new JavaScriptSerializer().Serialize(_sourceForm);

            var form_data = "{\"_form\":" + form_data_json + "}";

            _formData.form_data = form_data;

            var result = APIManager.UpdateFormData(_formData);
            if (result)
            {
                MessageBox.Show("Successfully updated");
            }
            else
            {
                MessageBox.Show("Failed to update");
            }
            

        }
    }
}
