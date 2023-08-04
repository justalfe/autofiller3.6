using AutoFiller_APP.Entites;
using AutoFiller_APP.Manager;
using AutoFiller_APP.Model;
using DocumentFormat.OpenXml.Office2010.Excel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace AutoFiller_APP
{
    public partial class CivilSurgeonList : Form
    {
        public static CivilSurgeonList _instance;
        string _conStr = Utility.GetServerString();
        public CivilSurgeonList()
        {
            InitializeComponent();
            _instance = this;
            _surgeonData.Columns.Add("UniqueId", "Unique Id");
            _surgeonData.Columns["UniqueId"].Visible = false;
            _surgeonData.Columns.Add("First Name", "First Name");
            _surgeonData.Columns.Add("Middle Name", "Middle Name");
            _surgeonData.Columns.Add("Last Name", "Last Name");
            _surgeonData.Columns.Add("Organization", "Organization");
            RefreshTable();
            RefreshSelected();
        }

        private void _addCivilSurgeonButton_Click(object sender, EventArgs e)
        {
            var csf = new CivilSurgeonForm(null);
            csf.Visible = true;
        }

        private void _surgeonData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (_surgeonData.SelectedCells.Count == 0)
                return;

            var selectedId = _surgeonData.SelectedCells[0].Value.ToString();

            var civilData = APIManager.GetCivilSurgeon(selectedId);
            var csf = new CivilSurgeonForm(civilData);
            csf.Visible = true;
        }

        private void _deleteButton_Click(object sender, EventArgs e)
        {
            if (_surgeonData.SelectedCells.Count == 0)
            {
                MessageBox.Show(Utility.Constants.NO_ENTRY_SELECTED);
                return;
            }

            var _id = _surgeonData.SelectedCells[0].Value.ToString();

            using (SqlConnection connection = new SqlConnection(_conStr))
            {
                String query = $"DELETE FROM [dbo].[CivilSurgeons] WHERE [FormId]='{_id}'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    RefreshTable();
                }
            }
        }

        public void RefreshTable()
        {
            _surgeonData.Rows.Clear();

            using (SqlConnection connection = new SqlConnection(_conStr))
            {
                String query = "SELECT * FROM [dbo].[CivilSurgeons]";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        var Id = dr[0].ToString();
                        var FormId = dr[1].ToString();
                        var FormData = dr[2].ToString();

                        CivilSurgeonsExportModel model = JsonConvert.DeserializeObject<CivilSurgeonsExportModel>(FormData);
                        _surgeonData.Rows.Add(model._id, model._firstName, model._middleName, model._lastName, model._organization);
                    }
                    dr.Close();
                    ((IDisposable)dr).Dispose();
                }
            }
        }

        private void _selectButton_Click(object sender, EventArgs e)
        {
            if (_surgeonData.SelectedCells.Count == 0)
            {
                MessageBox.Show(Utility.Constants.NO_ENTRY_SELECTED);
                return;
            }
            var selectedId = _surgeonData.CurrentRow.Cells[0].Value.ToString();

            var civilData = APIManager.GetCivilSurgeon(selectedId);
            Main._instance._selectedSurgeon = civilData;
            Properties.Settings.Default.Civil_ID = selectedId;
            Properties.Settings.Default.Save();
            RefreshSelected();
            this.Close();
        }

        private void _unselectButton_Click(object sender, EventArgs e)
        {
            Main._instance._selectedSurgeon = null;
            Properties.Settings.Default.Civil_ID = null;
            Properties.Settings.Default.Save();
            RefreshSelected();
            this.Close();
        }

        public void RefreshSelected()
        {
            Main._instance.RefreshSelectedSurgeonPreparer();
            if (Main._instance._selectedSurgeon != null)
                _selectedCivilSurgeonPreview.Text = "Selected: " + Main._instance._selectedSurgeon._firstName + " " + Main._instance._selectedSurgeon._lastName + " " + Main._instance._selectedSurgeon._organization;
            else
                _selectedCivilSurgeonPreview.Text = "Selected: None";
        }
    }
}
