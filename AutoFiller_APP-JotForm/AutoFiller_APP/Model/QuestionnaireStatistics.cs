using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AutoFiller_API.Model
{
    public class QuestionnaireStatistics
    {
        public const string STATISTICS_DIRECTORY = "./statistics/";
        public int _googleCount=0;
        public int _facebookCount=0;
        public int _yelpCount=0;
        public int _lawyerCount=0;
        public int _tvCount=0;
        public int _newspaperCount=0;
        public int _radioCount=0;
        public int _bingCount=0;
        public int _otherCount = 0;
        public string _other = "";
        public string _lawyer = "";
        public DateTime _dateTime = DateTime.Now;
    }
}