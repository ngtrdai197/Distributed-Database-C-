using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTN_PT.Models
{
    class CauHoi
    {
        public int CauHoiId { get; set; }
        public string MaMH { get; set; }
        public string TrinhDo { get; set; }
        public string NoiDung { get; set; }
        public string DA_A { get; set; }
        public string DA_B { get; set; }
        public string DA_C { get; set; }
        public string DA_D { get; set; }
        public string DAP_AN { get; set; }
        public string MaGV { get; set; }

        public CauHoi()
        {

        }
        public CauHoi(int cauhoiid, string mamh, string da_a, 
            string da_b, string da_c, string da_d, 
            string dap_an, string magv)

        {
            CauHoiId = cauhoiid;
            MaMH = mamh;
            DA_A = da_a;
            DA_B = da_b;
            DA_C = da_c;
            DA_D = da_d;
            DAP_AN = dap_an;
            MaGV = magv;
        }
    }
}
