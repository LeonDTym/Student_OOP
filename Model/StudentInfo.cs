using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace WindowsFormsApp1.Models {
    public class StudentInfo {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string Bth { get; set; }
        public string Grp { get; set; }

        //public AddressInfo Address { get; set; }

        public static readonly StudentInfo Empty;
        static StudentInfo() {
            Empty = new StudentInfo();
            //Empty.Address = AddressInfo.Empty;
        }
    }
}
