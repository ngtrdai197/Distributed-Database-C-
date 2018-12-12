using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace TTN_PT
{
    public partial class INDIEMTHEOMON : DevExpress.XtraReports.UI.XtraReport
    {
        public INDIEMTHEOMON(string tenlop,string tenmonhoc,int lanthi)
        {
            InitializeComponent();
            sp_8TableAdapter1.Connection.ConnectionString = Program.connstr;
            sp_8TableAdapter1.Fill(ttN_DS1.sp_8,tenlop,tenmonhoc,lanthi);          
            
        }

    }
}
