using System;
using System.Collections.Generic;
using System.Text;
//using CrystalDecisions.CrystalReports.Engine;
using CHARS.HR.COMMON.PL;
using System.Data;

namespace CHARS.HR.Digit.General
{
    public class Report
    {
    //    static public void viewReport(DataSet aDataSet, String aReportpatch)
    //    {
    //        try
    //        {    
    //            ReportDocument l_rpt = new ReportDocument();
    //            l_rpt.Load(aReportpatch + "\\Report\\Crystal\\rptCommonPreview.rpt" );
    //            DataSet ds = new DataSet();
    //            ds = changeDstFormat(aDataSet);
    //            l_rpt.SetDataSource(ds);
    //            showReport(l_rpt);
    //        }
    //        catch (Exception ex)
    //        {
    //            throw;
    //        }
    //    }
    //    static public void viewReport(DataSet aDataSet, String aReportpatch,string aCrystalRptName)
    //    {
    //        try
    //        {
    //            ReportDocument l_rpt = new ReportDocument();
    //            l_rpt.Load(aReportpatch + "\\Report\\Crystal\\" + aCrystalRptName);
    //            //DataSet ds = new DataSet();
    //            //ds = changeDstFormat(aDataSet);
    //            l_rpt.SetDataSource(aDataSet);
    //            showReport(l_rpt);
    //        }
    //        catch (Exception ex)
    //        {
    //            throw;
    //        }
    //    }
    //    public static DataSet changeDstFormat(DataSet adst)
    //    {
    //        int rowcount = 0;
    //        try {
    //            #region Remove Columns
    //            //DataTable l_tbl = new DataTable();               
    //            adst.Tables["data"].AcceptChanges();
    //            if (adst.Tables["data"].Columns.Contains("Ask"))
    //            {
    //                adst.Tables["data"].Columns.Remove("Ask");
    //            }
    //            if (adst.Tables["data"].Columns.Contains("TS"))
    //            {
    //                adst.Tables["data"].Columns.Remove("TS");
    //            }
    //            if (adst.Tables["data"].Columns.Contains("UD"))
    //            {
    //                adst.Tables["data"].Columns.Remove("UD");
    //            }
    //            #endregion


    //            DataSet dst = new DataSet();
    //            dst.Tables.Add("Commonpreview");
    //            dst.Tables["Commonpreview"].Columns.Add("Sr",typeof(int));
    //            dst.Tables["Commonpreview"].Columns.Add("ColumnName",typeof(string));
    //            dst.Tables["Commonpreview"].Columns.Add("Description",typeof(string));
    //            dst.Tables["Commonpreview"].Columns.Add("ColumnIndex");            


    //            //dst.Tables["Commonpreview"].Columns.
    //            for (int i = 0; i < adst.Tables["data"].Rows.Count; i++)
    //            {
    //                for (int j = 0; j < adst.Tables["data"].Columns.Count; j++)
    //                {
    //                    dst.Tables["Commonpreview"].Rows.Add(i);
    //                    dst.Tables["Commonpreview"].Rows[rowcount][0] = Convert.ToInt32(i + 1);                     
    //                    dst.Tables["Commonpreview"].Rows[rowcount][1] = adst.Tables["data"].Columns[j].ColumnName.ToString();
    //                    dst.Tables["Commonpreview"].Rows[rowcount][2] = adst.Tables["data"].Rows[i][j].ToString();
    //                    //dst.Tables["Commonpreview"].Rows[rowcount][3] = j;
    //                    rowcount++;
    //                    //a = adst.Tables["data"].Rows[i][j].ToString();
    //                }
    //            }
    //            return dst;
    //        }
    //        catch (Exception ex)
    //        {
    //            throw;
    //        }
    //   }


    //    static public void showReport(CrystalDecisions.CrystalReports.Engine.ReportDocument l_rpt)
    //    {
    //        //frmReport l_frmReport = new frmReport();
    //        //l_frmReport.rptViewer.ReportSource = l_rpt;
    //        //l_frmReport.rptViewer.ShowFirstPage();
    //        //l_frmReport.rptViewer.Refresh();
    //        //l_frmReport.Show();
    //    }

    }
}
