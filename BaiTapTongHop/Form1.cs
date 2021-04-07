using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapTongHop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetCBB();
            cbbLopSH.SelectedIndex = 0;
            dataGridView1.DataSource = CSDL_OOP.Instance.GetALLSV();
        }

        public void SetCBB()
        {
            cbbLopSH.Items.Add(new CBBItems { Value = 0, Text = "All" });
            foreach(LopSH i in CSDL_OOP.Instance.GetAllLSH())
            {
                cbbLopSH.Items.Add(new CBBItems
                {
                    Value = i.ID_Lop,
                    Text = i.NameLop
                });
            }    
        }
   
        public void Show(int ID_Lop, string Name)
        {
            dataGridView1.DataSource = CSDL_OOP.Instance.GetListSV(ID_Lop, Name);
        }

        private void Showbutton_Click(object sender, EventArgs e)
        {           
            Show(((CBBItems)cbbLopSH.SelectedItem).Value, null);
        }

        private void Searchbutton_Click(object sender, EventArgs e)
        {
            Show(((CBBItems)cbbLopSH.SelectedItem).Value, txtSearch.Text);
        }

        private void Deletebutton_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = dataGridView1.SelectedRows;
            if(r.Count > 0)
            {
                List<string> dt = new List<string>();
                foreach (DataGridViewRow i in r)
                {
                    dt.Add(i.Cells["MSSV"].Value.ToString());
                    CSDL_OOP.Instance.DeleteSV(dt);
                }
                dataGridView1.DataSource = CSDL_OOP.Instance.GetListSV(((CBBItems)cbbLopSH.SelectedItem).Value, null);
                
                txtSearch.Text = "";
            }         
        }

        private void Addbutton_Click(object sender, EventArgs e)
        {
 
            Form2 f2 = new Form2(null);
            f2.d = new Form2.Mydel(Show);
            f2.Show();
        }
    }
}
