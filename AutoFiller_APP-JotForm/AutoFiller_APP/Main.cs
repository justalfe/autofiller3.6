using AutoFiller_APP.Entites;
using AutoFiller_APP.Manager;
using AutoFiller_APP.Model;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using JotForm;

namespace AutoFiller_APP
{
    public partial class Main : Form
    {
        public static Main _instance;
        public List<FormData> _forms = new List<FormData>();                
        public CivilSurgeon_Preparer _selectedSurgeon = null;
        public CivilSurgeon_Preparer _selectedPreparer = null;
        public Main()
        {
            InitializeComponent();
            _instance = this;

            
            _forms = APIManager.GetForms();

            if (_forms.Count > 0)
            {
                APIManager.SavePatients(_forms);
            }

            var Civil_ID = Properties.Settings.Default.Civil_ID;
            var Preparer_ID = Properties.Settings.Default.Preparer_ID;

            var civilData = APIManager.GetCivilSurgeon(Civil_ID);
            Main._instance._selectedSurgeon = civilData;

            var preparerData = APIManager.GetPreparerData(Preparer_ID);
            Main._instance._selectedPreparer = preparerData;

            RefreshSelectedSurgeonPreparer();
            DisplayForms();
        }

        private void _refresh_Click(object sender, EventArgs e)
        {
            var filter_data = cmbFilter.Text;
            var status = cmbSatus.Text;

            _forms = APIManager.GetForms(filter_data, dtFrom.Value.ToString("yyyy-MM-dd"), dtTo.Value.ToString("yyyy-MM-dd"), txtLastname.Text, txtFirstName.Text, txtAlienNumber.Text, txtUSCISNumber.Text, txtPhone.Text, dtpBirth.Value.ToString("yyyy-MM-dd"), chkBirth.Checked, status);

            if (_forms.Count > 0)
            {
                APIManager.SavePatients(_forms);
            }

            DisplayForms();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (APIManager.CheckServer())
                MessageBox.Show("Connected");
            else
                MessageBox.Show(Utility.Constants.UNABLE_TO_RETRIEVE_DATA);
        }
        public void DisplayForms()
        {
            _existingForms.Rows.Clear();
            foreach (var form in _forms)
            {
                var _form = form.Convert2SubmitFormModel();
                _existingForms.Rows.Add(form.Id, _form.InformationAboutYou._lastname, _form.InformationAboutYou._firstname, _form.InformationAboutYou._alienRegistrationNumber, _form.InformationAboutYou._uscis, form.created_date, form.source,form.completed);
            }
            _existingForms.Sort(_existingForms.Columns["Date"], ListSortDirection.Descending);
            _existingForms.Columns["Date"].HeaderCell.SortGlyphDirection = SortOrder.Descending;
            lblFilterCnt.Text = "Total Result : " + _forms.Count;
        }

        private void _existingForms_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            var formWindow = new I693Form(_forms.Where(x => x.Id == (int)_existingForms.Rows[e.RowIndex].Cells["ID"].Value).FirstOrDefault());
            formWindow.Show();
        }

        private void _existingForms_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
                return;
            if (_existingForms.SelectedRows.Count == 0)
                return;
            if (_existingForms.SelectedRows[0].Index <= -1)
                return;
            var formToDelete = _forms.Where(x => x.Id == (int)_existingForms.Rows[_existingForms.SelectedRows[0].Index].Cells["ID"].Value).FirstOrDefault();
            if (formToDelete == null)
                return;
            var result = APIManager.DeleteForm(formToDelete.Id);
            if (!result)
                MessageBox.Show(Utility.Constants.UNABLE_TO_DELETE);
            else
            {
                _forms = APIManager.GetForms();
                DisplayForms();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var surgeonList = new CivilSurgeonList();
            surgeonList.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            var preparerList = new PreparerList();
            preparerList.Show();
        }
        public void RefreshSelectedSurgeonPreparer()
        {
            if (_selectedSurgeon != null)
                _selectedCivilSurgeonPreview.Text = "Selected: " + _selectedSurgeon._firstName + " " + _selectedSurgeon._lastName + " " + _selectedSurgeon._organization;
            else
                _selectedCivilSurgeonPreview.Text = "Selected: None";

            if (_selectedPreparer != null)
                _selectedPreparerPreview.Text = "Selected: " + _selectedPreparer._firstName + " " + _selectedPreparer._lastName + " " + _selectedPreparer._organization;
            else
                _selectedPreparerPreview.Text = "Selected: None";
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            var statistics = new StatisticsForm();
            statistics.Show();
        }

        private void ExportData_Click(object sender, EventArgs e)
        {
            var exportsExcel = new ExportForm();
            exportsExcel.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var dbConfigForm = new DbConfigForm();
            dbConfigForm.Show();
        }

        private void _existingForms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //We make DataGridCheckBoxColumn commit changes with single click
            //use index of logout column
            if (e.ColumnIndex == 7 && e.RowIndex >= 0)
            {
                var ID = int.Parse(_existingForms.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                ////Check the value of cell
                if ((bool)this._existingForms.CurrentCell.Value == true)
                {
                    this._existingForms.CurrentCell.Value = false;
                    APIManager.UpdateFormComplete(ID, false);
                }
                else
                {
                    //Use index of TimeOut column
                    //this._existingForms.Rows[e.RowIndex].Cells[3].Value = DBNull.Value;
                    this._existingForms.CurrentCell.Value = true;
                    APIManager.UpdateFormComplete(ID, true);
                    //Set other columns values
                }
            }
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbFilter.Text == "Custom date range") {
                grbDateRange.Visible = true;
            }
            else
            {
                grbDateRange.Visible = false;
            }
        }

        private void btnImportJotformData_Click(object sender, EventArgs e)
        {
            var server_setting = Utility.GetConfigData();

            if(server_setting.jotform_api_key == null || server_setting.jotform_api_key == "")
            {
                MessageBox.Show("Please set Jotform API key in Setting form.");
                return;
            }
            if (server_setting.jotform_id == 0)
            {
                MessageBox.Show("Please set Jotform ID in Setting form.");
                return;
            }

            var jotformAPIClient = new APIClient(server_setting.jotform_api_key);
            jotformAPIClient.baseURL = server_setting.jotform_url ;

            var created_date = APIManager.GetLastJotformCreatedDate();
            Dictionary<string, string> filter = new Dictionary<string, string>();
            if(created_date!=null)filter.Add("created_at:gt", created_date);
            var submissions = jotformAPIClient.getFormSubmissons(server_setting.jotform_id, 0, 1000, filter);
            
            var import = APIManager.ImportJotformData(submissions);
            if (import)
            {
                _forms = APIManager.GetForms();
                if (_forms.Count > 0)
                {
                    APIManager.SavePatients(_forms);
                }

                DisplayForms();

                MessageBox.Show("We imported jotform Data successfully!");
            }
            else
            {
            }
        }

        private void btnFilterOption_Click(object sender, EventArgs e)
        {
            if(grbFilter.Visible)
            {
                grbFilter.Visible = false;
                this.Width -= 240;
            }
            else
            {
                grbFilter.Visible = true;
                this.Width += 240;
            }
        }
    }
}
