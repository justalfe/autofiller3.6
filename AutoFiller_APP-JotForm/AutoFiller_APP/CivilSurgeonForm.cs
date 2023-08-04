using AutoFiller_APP.Entites;
using AutoFiller_APP.Manager;
using AutoFiller_APP.Model;
using DocumentFormat.OpenXml.EMMA;
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
    public partial class CivilSurgeonForm : Form
    {
        public string _id = null;
        string _conStr = Utility.GetServerString();
        public CivilSurgeonForm(CivilSurgeon_Preparer surgeon)
        {
            InitializeComponent();

            foreach (var state in (I693.States[])Enum.GetValues(typeof(I693.States)))
            {
                _addressState.Items.Add(state.ToString());
                _mailingAddressState.Items.Add(state.ToString());
            }
            _addressType.Items.Add("APT");
            _addressType.Items.Add("STE");
            _addressType.Items.Add("FLR");

            _mailingAddressSubType.Items.Add("APT");
            _mailingAddressSubType.Items.Add("STE");
            _mailingAddressSubType.Items.Add("FLR");

            if (surgeon != null)
            {
                _id = surgeon._id;
                _surgeonLastname.Text = surgeon._lastName;
                _surgeonFirstname.Text = surgeon._firstName;
                _surgeonMiddlename.Text = surgeon._middleName;
                txt_csid.Text = surgeon._csid;
                _surgeonOrg.Text = surgeon._organization;

                _addressStreet.Text = surgeon._streetAddress;
                _addressType.SelectedIndex = surgeon._addressType;
                _addressNumber.Text = surgeon._addressNumber;
                _addressCity.Text = surgeon._city;
                _addressState.SelectedIndex = surgeon._state;
                _addressZip.Text = surgeon._zip;

                _mailingAddress.Text = surgeon._mailingStreetAddress;
                _mailingAddressSubType.SelectedIndex = surgeon._mailingAddressType;
                _mailingAddressNumber.Text = surgeon._mailingAddressNumber;
                _mailingAddressCity.Text = surgeon._mailingCity;
                _mailingAddressSubType.SelectedIndex = surgeon._mailingAddressType;
                _mailingZip.Text = surgeon._mailingZip;
                _mailingAddressState.SelectedIndex = surgeon._mailingState;

                _surgeonPhone.Text = surgeon._Phone;
                _surgeonMobilePhone.Text = surgeon._MobilePhone;
                _surgeonEmail.Text = surgeon._Email;
            }

        }

        public bool SaveSurgeon()
        {
            CivilSurgeon_Preparer csEntity = new CivilSurgeon_Preparer(
                _id,
                _surgeonLastname.Text,
                _surgeonFirstname.Text,
                _surgeonMiddlename.Text,
                txt_csid.Text,
                _surgeonOrg.Text,
                _addressStreet.Text,
                _addressType.SelectedIndex,
                _addressNumber.Text,
                _addressCity.Text,
                _addressState.SelectedIndex,
                _addressZip.Text,
                _mailingAddress.Text,
                _mailingAddressSubType.SelectedIndex,
                _mailingAddressNumber.Text,
                _mailingAddressCity.Text,
                _mailingAddressState.SelectedIndex,
                _mailingZip.Text,
                _surgeonPhone.Text,
                _surgeonMobilePhone.Text,
                _surgeonEmail.Text);

            int resultCount = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(_conStr))
                {
                    String query = "";

                    if (csEntity._id == null)
                    {
                        var FormId = Utility.GenerateSringToken();
                        csEntity._id = FormId;
                        query = $"INSERT INTO [dbo].[CivilSurgeons]\r\n" +
                        $"([FormId]\r\n,[FormData]\r\n,[CreatedDate])\r\n" +
                        $"VALUES ('{FormId}', @FormData\r\n,'{DateTime.Now}')";
                    }
                    else
                    {
                        query = $"UPDATE [dbo].[CivilSurgeons]\r\nSET\r\n" +
                                $"[FormData]=@FormData\r\n,[LastUpdated]='{DateTime.Now}'\r\n" +
                                $"WHERE [FormId]='{csEntity._id}'";
                    }
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FormData", JsonConvert.SerializeObject(csEntity));

                        connection.Open();
                        resultCount = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { }
            

            //using (var context = new AutoDBContext())
            //{
            //    if (!context.CivilSurgeons.Any(cs => cs.FormId.Equals(csEntity._id)))
            //    {
            //        var sergeon = new CivilSurgeon();
            //        sergeon.FormId = Utility.GenerateSringToken();
            //        csEntity._id = sergeon.FormId;
            //        sergeon.FormData = JsonConvert.SerializeObject(csEntity);
            //        sergeon.CreatedDate = DateTime.Now;
            //        context.CivilSurgeons.Add(sergeon);
            //        res = context.SaveChanges();
            //    }
            //    else
            //    {
            //        var sergeon = context.CivilSurgeons.Single(cs => cs.FormId.Equals(_id));
            //        if (sergeon != null)
            //        {
            //            sergeon.FormData = JsonConvert.SerializeObject(csEntity);
            //            sergeon.LastUpdated = DateTime.Now;
            //            res = context.SaveChanges();
            //        }
            //    }
            //}
            //END

            return (resultCount > 0);
        }

        private void _saveButton_Click(object sender, EventArgs e)
        {
            if (SaveSurgeon())
            {
                //Main._instance.LoadCSP();
                CivilSurgeonList._instance.RefreshTable();
                this.Close();
            }
        }
    }
}
