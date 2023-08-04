using AutoFiller_API;
using AutoFiller_APP.Entites;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AutoFiller_APP.Model.I693;

namespace AutoFiller_APP.Model
{
    public class CivilSurgeon_Preparer
    {
        public string _id { get; set; }
        public string _lastName { get; set; }
        public string _firstName { get; set; }
        public string _middleName { get; set; }
        public string _csid { get; set; }
        public string _organization { get; set; }
        public string _streetAddress { get; set; }
        public int _addressType { get; set; }
        public string _addressNumber { get; set; }
        public string _city { get; set; }
        public int _state { get; set; }
        public string _zip { get; set; }
        public string _mailingStreetAddress { get; set; }
        public int _mailingAddressType { get; set; }
        public string _mailingAddressNumber { get; set; }
        public string _mailingCity { get; set; }
        public int _mailingState { get; set; }
        public string _mailingZip { get; set; }
        public string _Phone { get; set; }
        public string _MobilePhone { get; set; }
        public string _Email { get; set; }

        public CivilSurgeon_Preparer()
        {

        }

        public CivilSurgeon_Preparer(
            string id,
            string lastName,
            string firstName,
            string organization,
            string Phone,
            string MobilePhone,
            string Email
            )
        {
            _id = id;
            _lastName = lastName;
            _firstName = firstName;
            _organization = organization;
            _Phone = Phone;
            _MobilePhone = MobilePhone;
            _Email = Email;
        }

        public CivilSurgeon_Preparer(
             string id,
             string lastName,
             string firstName,
             string middleName,
             string csid,
             string organization,
             string streetAddress,
             int addressType,
             string addressNumber,
             string city,
             int state,
             string zip,
             string mailingStreetAddress,
             int mailingAddressType,
             string mailingAddressNumber,
             string mailingCity,
             int mailingState,
             string mailingZip,
             string Phone,
             string MobilePhone,
             string Email)
        {
            _id = id;
            _lastName = lastName;
            _firstName = firstName;
            _middleName = middleName;
            _csid = csid;
            _organization = organization;
            _streetAddress = streetAddress;
            _addressType = addressType;
            _addressNumber = addressNumber;
            _city = city;
            _state = state;
            _zip = zip;
            _mailingStreetAddress = mailingStreetAddress;
            _mailingAddressType = mailingAddressType;
            _mailingAddressNumber = mailingAddressNumber;
            _mailingCity = mailingCity;
            _mailingState = mailingState;
            _mailingZip = mailingZip;
            _Phone = Phone;
            _MobilePhone = MobilePhone;
            _Email = Email;
        }

        public class Storage
        {

            public const string FILE_CIVIL_SURGEON = "./cs.json";
            public const string FILE_PREPARER = "./p.json";

            public static string GetDirectory(bool preparer)
            {
                if (preparer)
                    return FILE_PREPARER;
                else
                    return FILE_CIVIL_SURGEON;
            }

            static void Store(List<CivilSurgeon_Preparer> forms, bool preparer)
            {
                var f = File.CreateText(GetDirectory(preparer));
                f.WriteLine(JsonConvert.SerializeObject(forms));
                f.Close();

            }

            public static List<CivilSurgeon_Preparer> Get(bool preparer)
            {
                if (!File.Exists(GetDirectory(preparer)))
                    return new List<CivilSurgeon_Preparer>();
                var textContent = File.ReadAllText(GetDirectory(preparer));
                var content = JsonConvert.DeserializeObject<List<CivilSurgeon_Preparer>>(textContent);
                if (content == null)
                    return new List<CivilSurgeon_Preparer>();
                else
                    return content;
            }

            public static void Add(CivilSurgeon_Preparer entry, bool preparer)
            {
                if (entry._id != null)
                    Delete(entry._id, preparer);
                else
                    entry._id = Utility.GenerateSringToken();
                var content = Get(preparer);
                content.Add(entry);
                Store(content, preparer);
            }

            public static void Delete(string id, bool preparer)
            {
                var forms = Get(preparer);
                forms.RemoveAll(x => x._id == id);
                Store(forms, preparer);
            }
        }
    }
}
