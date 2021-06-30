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
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
            this.Load += new EventHandler(MainForm_Load);
            //btnShowAddress.Click += new EventHandler(btnShowAddress_Click);
            btnDelete.Click += new EventHandler(OperateUser_Click);
            btnInsert.Click += new EventHandler(OperateUser_Click);
            btnUpdate.Click += new EventHandler(OperateUser_Click);
        }

        //void btnShowAddress_Click(object sender, EventArgs e) {
        //    int id = GetSelectedIndex();
        //    if (id == -1) {
        //        return;
        //    }
        //    AddressInfo address = DbProvider.Provider.GetAddressById(id);
        //    txtCountry.Text = address.Country;
        //    txtCity.Text = address.City;
        //    txtStreet.Text = address.Street;
        //    txtHouse.Text = address.HouseNumber.ToString();
        //}

        void OperateUser_Click(object sender, EventArgs e) {
            OperationType operation = (OperationType)Enum.Parse(typeof(OperationType), (sender as Button).Tag.ToString());
            int id = GetSelectedIndex();
            if (operation == OperationType.DELETE && id != -1) {
                DialogResult result = MessageBox.Show("Вы уверены?", "Alert Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes) {
                    DbProvider.Provider.OperateUser(new StudentInfo { UserId = id /*, Address = new AddressInfo { UserId = id } */}, OperationType.DELETE);
                    UpdateUsersView();
                    //ResetAddressView();
                }
            }
            else {
                using (EditForm editForm = new EditForm(id, operation)) {
                    editForm.StartPosition = FormStartPosition.Manual;
                    editForm.Location = this.Location + 
                        SystemInformation.CaptionButtonSize + 
                        SystemInformation.FrameBorderSize;
                    if (editForm.ShowDialog() == DialogResult.OK) {
                        UpdateUsersView();
                    }
                }
            }
        }

        void MainForm_Load(object sender, EventArgs e) {
            UpdateUsersView();
        }

        void UpdateUsersView() {
            StudentInfo[] students = DbProvider.Provider.GetUsers();
            var displayUsers = students.Select(u => new {
                Идентификатор = u.UserId,
                Имя = u.FirstName,
                Отчество = u.SecondName,
                Фамилия = u.LastName,
                Дата = u.Bth,
                Группа = u.Grp,
            });
            studentGridView.DataSource = null;
            studentGridView.DataSource = displayUsers.ToArray();
        }

        //void ResetAddressView()
        //{
        //    foreach (TextBox tb in addressGroupBox.Controls.OfType<TextBox>())
        //    {
        //        tb.Clear();
        //    }
        //}

    int GetSelectedIndex() {
            if (studentGridView.SelectedRows.Count == 0) {
                return -1;
            }
            int index = 0;
            if (int.TryParse(studentGridView.SelectedRows[0].Cells[0].Value.ToString(), out index)) {
                return index;
            }
            return -1;
        }

        private void btnChek_Click(object sender, EventArgs e)
        {
            studentGridView.ClearSelection();
            for (int i = 1; i < studentGridView.Rows.Count; i++)
            {
                DataGridViewCell selectedCell = studentGridView[0, i];
                int max = int.Parse(studentGridView[0, i].Value.ToString());
                lbChek.Text = max.ToString();
            }
        }
         
    }
    
}
