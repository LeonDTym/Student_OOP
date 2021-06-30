using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using WindowsFormsApp1.Models;
using WindowsFormsApp1.Common;

namespace WindowsFormsApp1.Forms {
    public partial class EditForm : Form {
        int _id;
        OperationType _operation;
        public EditForm(int id, OperationType operation ) {
            InitializeComponent();
            btnOk.Click += new EventHandler(btnOk_Click);

            _id = id;
            _operation = operation;

            this.Load += new EventHandler(EditForm_Load);
        }

        void btnOk_Click(object sender, EventArgs e) {
            //Тут проверить на корректность все текстовые поля!!!
            //AddressInfo address = new AddressInfo {
            //    UserId = int.Parse(txtUserId.Text),
            //    Country=txtCountry.Text,
            //    City=txtCity.Text,
            //    Street=txtStreet.Text,
            //    HouseNumber=int.Parse(txtHouse.Text)
            //};
            StudentInfo student = new StudentInfo {
                UserId=int.Parse(txtUserId.Text),
                FirstName=txtFName.Text,
                SecondName=txtSName.Text,
                LastName=txtLName.Text,
                Bth=txtDate.Text,
                Grp=txtGroup.Text,
                //Address=address
                
            };
            
            DbProvider.Provider.OperateUser(student, _operation);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        void EditForm_Load(object sender, EventArgs e) {
            if (_operation == OperationType.UPDATE & _id != -1) {
                StudentInfo user = DbProvider.Provider.GetUserById(_id);
                FillUser(user);
            }
        }
        void FillUser(StudentInfo student) {
            txtUserId.Text = student.UserId.ToString();
            txtFName.Text = student.FirstName;
            txtSName.Text = student.SecondName;
            txtLName.Text = student.LastName;
            txtDate.Text = student.Bth;
            txtGroup.Text = student.Grp;
            //txtCountry.Text = user.Address.Country;
            //txtCity.Text = user.Address.City;
            //txtStreet.Text = user.Address.Street;
            //txtHouse.Text = user.Address.HouseNumber.ToString();
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            txtDate.Text = dateTimePicker1.Value.ToString("dd-MM-yyyy");
        }

    }
}
