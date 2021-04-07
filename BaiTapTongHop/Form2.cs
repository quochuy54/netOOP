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
    public partial class Form2 : Form
    {

        public delegate void Mydel(int s, string sv);
        public Mydel d { get; set; }
        public Form2(string m)
        {
            InitializeComponent();
            string MSSV = m;
            SetCBB();
        }

        public void SetCBB()
        {
            cbbLopSHForm2.Items.Add(new CBBItems { Value = 0, Text = "All" });
            foreach (LopSH i in CSDL_OOP.Instance.GetAllLSH())
            {
                cbbLopSHForm2.Items.Add(new CBBItems
                {
                    Value = i.ID_Lop,
                    Text = i.NameLop
                });
            }
        }

        public void AddSV()
        { 
            string MSSV1 = txtMSSV.Text;
            string Name1 = txtName.Text;
            bool Gender1 = rbM.Checked;
            DateTime BD1 = dateTimePicker1.Value;
            int CLassID1 = ((CBBItems)cbbLopSHForm2.SelectedItem).Value;
            SV sv = new SV();
            sv.MSSV = MSSV1;
            sv.MSSV = Name1;
            sv.Gender = Gender1;
            sv.NS = BD1;
            sv.ID_Lop = CLassID1;
            CSDL_OOP.Instance.AddSVCSDLOOP(sv);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(CSDL_OOP.Instance.Excute(MSSV))
            AddSV();

            d(0, null);
        }
    }
}
