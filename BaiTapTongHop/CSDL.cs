using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapTongHop
{
    class CSDL
    {
        public DataTable DTSV { get; set; }
        public DataTable DTLSH { get; set; }
        private static CSDL _Instance;

        public static CSDL Instance
        {
            get
            {
                if(_Instance == null)
                {
                    _Instance =  new CSDL();
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }

        private CSDL()
        {
            DTSV = new DataTable();
            DTSV.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("MSSV", typeof(string)),
                new DataColumn("NameSV", typeof(string)),
                new DataColumn("Gender", typeof(bool)),
                new DataColumn("Birthday", typeof(DateTime)),
                new DataColumn("ClassID", typeof(int))
            });
            DataRow row = DTSV.NewRow();
            row["MSSV"] = "109";
            row["NameSV"] = "NVA";
            row["Gender"] = true;
            row["Birthday"] = DateTime.Now;
            row["ClassID"] = 2;
            DTSV.Rows.Add(row);

            DataRow row1 = DTSV.NewRow();
            row1["MSSV"] = "101";
            row1["NameSV"] = "NVB";
            row1["Gender"] = true;
            row1["Birthday"] = DateTime.Now;
            row1["ClassID"] = 1;
            DTSV.Rows.Add(row1);

            DataRow row2 = DTSV.NewRow();
            row2["MSSV"] = "108";
            row2["NameSV"] = "NTC";
            row2["Gender"] = false;
            row2["Birthday"] = DateTime.Now;
            row2["ClassID"] = 2;
            DTSV.Rows.Add(row2);

            DataRow row3 = DTSV.NewRow();
            row3["MSSV"] = "103";
            row3["NameSV"] = "NTD";
            row3["Gender"] = false;
            row3["Birthday"] = DateTime.Now;
            row3["ClassID"] = 1;
            DTSV.Rows.Add(row3);

            DTLSH = new DataTable();

            DTLSH.Columns.AddRange(new DataColumn[] {
                new DataColumn("ClassID" , typeof(int)),
                new DataColumn("ClassName",typeof(string))
            });

            DataRow row4 = DTLSH.NewRow();
            row4["ClassID"] = 1;
            row4["ClassName"] = "SH1";
            DTLSH.Rows.Add(row4);

            DataRow row5 = DTLSH.NewRow();
            row5["ClassID"] = 2;
            row5["ClassName"] = "SH2";
            DTLSH.Rows.Add(row5);
        }

        public void DeleteDataRow(string MSSV)
        {
            foreach (DataRow i in DTSV.Select())
            {
                if(i["MSSV"].ToString() == MSSV)
                {
                    DTSV.Rows.Remove(i);
                }    
            }
            DTSV.AcceptChanges();
        }
         public void AddDataRow(SV s)
        {
            DataRow row8 = DTSV.NewRow();
            row8["MSSV"] = s.MSSV;
            row8["NameSV"] = s.NameSV;
            row8["Gender"] = s.Gender;
            row8["Birthday"] = s.NS;
            row8["ClassID"] = s.ID_Lop;
            DTSV.Rows.Add(row8);
        }

         
    }
}
