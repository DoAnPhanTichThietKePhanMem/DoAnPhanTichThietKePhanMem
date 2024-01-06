using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Common
{
    public class GeneralModel
    {
        //public const string baseURL = "https://localhost:44317/";
        public const string baseURL = "http://52.147.195.180:8092/";
        
        public class ResponeseMessage
        {
            public bool isSuccess { get; set; }
            public int status { get; set; }
            public string message { get; set; }
            public object data { get; set; }
        }
        public class StudentVM
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Username { get; set; }
            public int Gender { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string Address { get; set; }
            public string Email { get; set; }
        }

        public class ReportVM
        {
            public int STT { get; set; }
            public int? ClassID { get; set; }
            public string ClassName { get; set; }
            public int? SiSo { get; set; }
            public int SoLuongDat { get; set; }
            public double TiLeDat { get; set; }
        }
    }
}
