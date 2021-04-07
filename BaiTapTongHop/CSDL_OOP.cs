using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapTongHop
{
    class CSDL_OOP
    {
        private static CSDL_OOP _Instance;
        public static CSDL_OOP Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new CSDL_OOP();
                return _Instance;
            }
            private set
            {

            }
        }

        private CSDL_OOP() { }

        public List<SV> GetALLSV()
        {
            List<SV> l = new List<SV>();
            
            foreach (DataRow i in CSDL.Instance.DTSV.Rows)
            {
                l.Add(new SV
                {
                    MSSV = i["MSSV"].ToString(),
                    NameSV = i["NameSV"].ToString(),
                    Gender = Convert.ToBoolean(i["Gender"]),
                    NS = (DateTime)i["Birthday"],
                    ID_Lop = Convert.ToInt32(i["ClassID"])

                });
            }
            return l;
        }

        public List<LopSH> GetAllLSH()
        {
            List<LopSH> data = new List<LopSH>();
            foreach(DataRow i in CSDL.Instance.DTLSH.Rows)
            {
                data.Add(new LopSH { ID_Lop = Convert.ToInt32(i["ClassID"]),
                NameLop = i["ClassName"].ToString()
                });
            }
            return data;
        }
        public List<SV> GetListSV(int ID_Lop, string Name)
        {
            List<SV> dt = new List<SV>();
               
            foreach(SV i in GetALLSV())
            {
                if (ID_Lop == 0)
                {
                    if (Name == null)
                         
                    {
                        return GetALLSV();
                    }
                    else if (i.NameSV.Contains(Name) == true)
                    {
                        dt.Add(i);
                    }
                }
                else if (i.ID_Lop == ID_Lop)
                {
                    if (Name == null)

                    {
                        dt.Add(i);
                    }
                    else if(i.NameSV.Contains(Name) == true)
                    {
                        dt.Add(i);
                    }
                }            
            }    
            return dt;
        }

        public void DeleteSV(List<string> MSSV)
        {
            foreach(string i in MSSV)
            {
                CSDL.Instance.DeleteDataRow(i);
            }    
        }

        public void AddSVCSDLOOP(SV sv)
        {          
              CSDL.Instance.AddDataRow(sv);       
        }

        public bool Excute(string MSSV)
        {
            bool check = true;
            foreach (SV i in GetALLSV())
            {
                if(i.MSSV == MSSV)
                {
                    check = false;
                }    
            }
            return check;
        }
    }
}
