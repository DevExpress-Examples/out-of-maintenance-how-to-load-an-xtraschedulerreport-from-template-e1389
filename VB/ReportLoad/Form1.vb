Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraScheduler.Reporting
Imports DevExpress.XtraReports.UI


Namespace ReportLoad
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub btnReportLoad_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReportLoad.Click
'#Region "#reportcreation"
			' Create a new Scheduler Storage
			Dim storage As New SchedulerStorage()
			' Load schedule data into the storage
			DataHelper.FillStorageData(storage)
			' Create a new report
			Dim report As New XtraSchedulerReport()
			' Load the report template
			report.LoadLayout(DataHelper.GetTemplate())
			' Specify the print adapter which provides data for the report
			If report.SchedulerAdapter IsNot Nothing Then
				report.SchedulerAdapter.SetSourceObject(storage)
			Else
				report.SchedulerAdapter = New SchedulerStoragePrintAdapter(storage)
			End If
			' Specify the time inteval for the report and set the required options
			report.SchedulerAdapter.TimeInterval = New TimeInterval(New DateTime(2010, 07, 12), New DateTime(2010, 08, 01))
			report.SchedulerAdapter.FirstDayOfWeek = DevExpress.XtraScheduler.FirstDayOfWeek.Saturday
			report.PrintColorSchema = PrintColorSchema.FullColor
			' Implement appointment filtering
			AddHandler report.SchedulerAdapter.ValidateAppointments, AddressOf SchedulerAdapter_ValidateAppointments
			' Preview the report
			Dim rpt As New ReportPrintTool(report)
			rpt.ShowPreviewDialog()
'#End Region ' #reportcreation
		End Sub

		Private Sub SchedulerAdapter_ValidateAppointments(ByVal sender As Object, ByVal e As AppointmentsValidationEventArgs)
			Dim count As Integer = e.Appointments.Count
			Dim result As New AppointmentBaseCollection()
			For i As Integer = 0 To count - 1
				Dim apt As Appointment = e.Appointments(i)
				' Add recurring appointments to the resulting collection
				If apt.IsRecurring Then
					result.Add(apt)
				End If
			Next i
			e.Appointments.Clear()
			e.Appointments.AddRange(result)
		End Sub

	End Class
End Namespace