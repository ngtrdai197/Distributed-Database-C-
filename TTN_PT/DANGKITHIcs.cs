using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace TTN_PT
{
    public partial class DANGKITHIcs : DevExpress.XtraReports.UI.XtraReport
    {
        public DANGKITHIcs(DateTime tungay,DateTime denngay)
        {
            InitializeComponent();
            sp_9TableAdapter3.Connection.ConnectionString = Program.connstr;
           
            sp_9TableAdapter3.Fill(ttN_DS3.sp_9, tungay,denngay);
            
        }

    }
}
