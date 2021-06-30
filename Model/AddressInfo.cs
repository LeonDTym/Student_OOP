using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace WindowsFormsApp1.Models {
    public class AddressInfo {
        public int UserId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }

        public static readonly AddressInfo Empty;
        static AddressInfo() {
            Empty = new AddressInfo();
        }
    }
}
