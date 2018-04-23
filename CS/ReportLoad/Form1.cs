using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Reporting;
using DevExpress.XtraReports.UI;


namespace ReportLoad {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btnReportLoad_Click(object sender, EventArgs e) {
#region #reportcreation
            // Create a new Scheduler Storage
            SchedulerStorage storage = new SchedulerStorage();
            // Load schedule data into the storage
            DataHelper.FillStorageData(storage);
            // Create a new report
            XtraSchedulerReport report = new XtraSchedulerReport();
            // Load the report template
            report.LoadLayout(DataHelper.GetTemplate());
            // Specify the print adapter which provides data for the report
            if(report.SchedulerAdapter != null)
                report.SchedulerAdapter.SetSourceObject(storage);
            else
                report.SchedulerAdapter = new SchedulerStoragePrintAdapter(storage);
            // Specify the time inteval for the report and set the required options
            report.SchedulerAdapter.TimeInterval = new TimeInterval(new DateTime(2008, 07, 12), new DateTime(2008, 08, 01));
            report.SchedulerAdapter.FirstDayOfWeek = DevExpress.XtraScheduler.FirstDayOfWeek.Saturday;
            report.PrintColorSchema = PrintColorSchema.FullColor;
            // Implement appointment filtering
            report.SchedulerAdapter.ValidateAppointments += new AppointmentsValidationEventHandler(SchedulerAdapter_ValidateAppointments);
            // Preview the report
            ReportPrintTool rpt = new ReportPrintTool(report);
            rpt.ShowPreviewDialog();
#endregion #reportcreation
        }

        void SchedulerAdapter_ValidateAppointments(object sender, AppointmentsValidationEventArgs e)
        {
            int count = e.Appointments.Count;
            AppointmentBaseCollection result = new AppointmentBaseCollection();
            for(int i = 0; i < count; i++) {
                Appointment apt = e.Appointments[i];
                // Add recurring appointments to the resulting collection
                if(apt.IsRecurring)
                    result.Add(apt);
            }
            e.Appointments.Clear();
            e.Appointments.AddRange(result);
        }

        }
    }