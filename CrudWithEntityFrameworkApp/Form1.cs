using CrudWithEntityFrameworkApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudWithEntityFrameworkApp
{
    public partial class Form1 : Form
    {
        Detail MyDetail = new Detail();
        public Form1()
        {
            InitializeComponent();
            PopGridView();
        }

        private void PopGridView()
        {
            using (MyModel myModelEntities = new MyModel())
            {
                dgvDataView.DataSource = myModelEntities.Details.ToList();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MyDetail.Fname = txtBxFirstName.Text;
            MyDetail.Lname = txtBxLastName.Text;            
            Int32.TryParse(txtBxAge.Text, out int age);
            MyDetail.Age = age;
            MyDetail.Address = txtBxAddress.Text;
            MyDetail.Dob = Convert.ToDateTime(dtPickerDob.Text);

            using (MyModel myModelEntities = new MyModel())
            {
                if (MyDetail.Id == 0)
                {
                    myModelEntities.Details.Add(MyDetail);
                }
                else
                {
                    myModelEntities.Entry(MyDetail).State = System.Data.Entity.EntityState.Modified;
                    MyDetail.Id = 0;
                }

                myModelEntities.SaveChanges();
            }

            PopGridView();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            MyDetail.Fname = txtBxFirstName.Text;
            MyDetail.Lname = txtBxLastName.Text;
            Int32.TryParse(txtBxAge.Text, out int age);
            MyDetail.Age = age;
            MyDetail.Address = txtBxAddress.Text;
            MyDetail.Dob = Convert.ToDateTime(dtPickerDob.Text);

            using (MyModel myModelEntities = new MyModel())
            {
                myModelEntities.Entry(MyDetail).State = System.Data.Entity.EntityState.Modified;
                myModelEntities.SaveChanges();
            }

            PopGridView();
        }

        private void dgvDataView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dgvDataView.CurrentRow.Cells[0].Value);
            using (MyModel myModelEntities = new MyModel())
            {
                MyDetail = myModelEntities.Details.FirstOrDefault(x => x.Id == id);
            }

            txtBxFirstName.Text = MyDetail.Fname;
            txtBxLastName.Text = MyDetail.Lname;
            txtBxAge.Text = MyDetail.Age.ToString();
            txtBxAddress.Text = MyDetail.Address;
            dtPickerDob.Text = MyDetail.Dob.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MyDetail.Id != 0)
            {
                using (MyModel myModelEntities = new MyModel())
                {
                    myModelEntities.Entry(MyDetail).State = System.Data.Entity.EntityState.Deleted;
                    myModelEntities.SaveChanges();
                }
            }

            MyDetail = new Detail();
            txtBxFirstName.Text = string.Empty;
            txtBxLastName.Text = string.Empty;
            txtBxAge.Text = string.Empty;
            txtBxAddress.Text = string.Empty;
            dtPickerDob.Text = string.Empty;

            PopGridView();
        }
    }
}
