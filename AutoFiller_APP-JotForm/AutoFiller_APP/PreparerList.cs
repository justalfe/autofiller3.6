using AutoFiller_APP.Entites;
using AutoFiller_APP.Manager;
using AutoFiller_APP.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoFiller_APP
{
    public partial class PreparerList : Form
    {
        public static PreparerList _instance;
        string _conStr = Utility.GetServerString();
        public PreparerList()
        {
            InitializeComponent();
            _instance = this;
            _preparerData.Columns.Add("UniqueId", "Unique Id");
            _preparerData.Columns["UniqueId"].Visible = false;
            _preparerData.Columns.Add("Last Name", "Last Name");
            _preparerData.Columns.Add("First Name", "First Name");
            _preparerData.Columns.Add("Organization", "Organization");
            RefreshTable();
            RefreshSelected();
        }

        private void _surgeonData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (_preparerData.SelectedCells.Count == 0)
                return;

            var selectedId = _preparerData.SelectedCells[0].Value.ToString();

            var civilData = APIManager.GetPreparerData(selectedId);
            var csf = new PreparerForm(civilData);
            csf.Visible = true;
        }

        private void _deleteButton_Click(object sender, EventArgs e)
        {
            if (_preparerData.SelectedCells.Count == 0)
            {
                MessageBox.Show(Utility.Constants.NO_ENTRY_SELECTED);
                return;
            }

            var _id = _preparerData.SelectedCells[0].Value.ToString();
            using (SqlConnection connection = new SqlConnection(_conStr))
            {
                String query = $"DELETE FROM [dbo].[Preparers] WHERE [FormId]='{_id}'";
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
            _preparerData.Rows.Clear();

            using (SqlConnection connection = new SqlConnection(_conStr))
            {
                String query = "SELECT * FROM [dbo].[Preparers]";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        var Id = dr[0].ToString();
                        var FormId = dr[1].ToString();
                        var FormData = dr[2].ToString();

                        PreparerExportModel model = JsonConvert.DeserializeObject<PreparerExportModel>(FormData);
                        _preparerData.Rows.Add(model._id, model._lastName, model._firstName, model._organization);
                    }
                    dr.Close();
                    ((IDisposable)dr).Dispose();
                }
            }
        }

        private void _selectButton_Click(object sender, EventArgs e)
        {
            if (_preparerData.SelectedCells.Count == 0)
            {
                MessageBox.Show(Utility.Constants.NO_ENTRY_SELECTED);
                return;
            }
            var selectedId = _preparerData.CurrentRow.Cells[0].Value.ToString();
            var civilData = APIManager.GetPreparerData(selectedId);
            Main._instance._selectedPreparer = civilData;
            Properties.Settings.Default.Preparer_ID= selectedId;
            Properties.Settings.Default.Save();
            RefreshSelected();
            this.Close();
        }

        private void _unselectButton_Click(object sender, EventArgs e)
        {
            Main._instance._selectedPreparer = null;
            Properties.Settings.Default.Preparer_ID = null;
            Properties.Settings.Default.Save();
            RefreshSelected();
            this.Close();
        }

        public void RefreshSelected()
        {
            Main._instance.RefreshSelectedSurgeonPreparer();
            if (Main._instance._selectedPreparer != null)
                _selectedCivilSurgeonPreview.Text = "Selected: " + Main._instance._selectedPreparer._firstName + " " + Main._instance._selectedPreparer._lastName + " " + Main._instance._selectedPreparer._organization;
            else
                _selectedCivilSurgeonPreview.Text = "Selected: None";
        }

        private void _addCivilSurgeonButton_Click(object sender, EventArgs e)
        {
            var csf = new PreparerForm(null);
            csf.Visible = true;
        }
    }
}
