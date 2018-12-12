using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace TTN_PT
{
    public partial class DANGKITHIcs : DevExpress.XtraReports.UI.XtraReport
    {
        public DANGKITHIcs()
        {
            InitializeComponent();
            sp_9TableAdapter3.Connection.ConnectionString = Program.connstr;
            DateTime dt = Convert.ToDateTime("10/10/2018");
            DateTime dt1 = Convert.ToDateTime("11/11/2018");
            sp_9TableAdapter3.Fill(ttN_DS3.sp_9, dt, dt1);
            int rowCount = (this.PageHeight - this.Margins.Top - this.Margins.Bottom);


        }

    }
}
