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
    public partial class PreparerForm : Form
    {
        public string _id = null;
        string _conStr = Utility.GetServerString();
        public PreparerForm(CivilSurgeon_Preparer preparer)
        {
            InitializeComponent();
            if (preparer != null)
            {
                _id = preparer._id;
                _surgeonLastname.Text = preparer._lastName;
                _surgeonFirstname.Text = preparer._firstName;
                _surgeonOrg.Text = preparer._organization;
                _surgeonPhone.Text = preparer._Phone;
                _surgeonMobilePhone.Text = preparer._MobilePhone;
                _surgeonEmail.Text = preparer._Email;
            }

        }

        public bool SavePreparer()
        {
            try
            {
                var model = new CivilSurgeon_Preparer(
                    _id, _surgeonLastname.Text, _surgeonFirstname.Text,  _surgeonOrg.Text, _surgeonPhone.Text, _surgeonMobilePhone.Text, _surgeonEmail.Text);

                try
                {
                    String query = "";

                    if (model._id == null)
                    {
                        var FormId = Utility.GenerateSringToken();
                        model._id = FormId;
                        query = $"INSERT INTO [dbo].[Preparers]\r\n" +
                        $"([FormId]\r\n,[FormData]\r\n,[CreatedDate])\r\n" +
                        $"VALUES ('{FormId}', @FormData\r\n,'{DateTime.Now}')";
                    }
                    else
                    {
                        query = $"UPDATE [dbo].[Preparers]\r\nSET\r\n" +
                        $"[FormData]=@FormData\r\n,[LastUpdated]='{DateTime.Now}'\r\n" +
                        $"WHERE [FormId]='{model._id}'";
                    }

                    using (SqlConnection connection = new SqlConnection(_conStr))
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@FormData", JsonConvert.SerializeObject(model));

                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex) { }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void _saveButton_Click(object sender, EventArgs e)
        {
            if (SavePreparer())
            {
                //Main._instance.LoadCSP();
                PreparerList._instance.RefreshTable();
                this.Close();
            }
        }

        private void PreparerForm_Load(object sender, EventArgs e)
        {

        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
