using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CHARS.HR.COMMON.PL;
using CHARS.POS.Setup;
using CHARS.HR.COMMON.General;
using CHARS.HR.COMMON.BLL;
using CHARS.POS.BOL.Setup;


namespace CHARS.POS.List
{
    public partial class LstBrand : LstBase
    {
        public LstBrand()
        {
            InitializeComponent();
            loadGrid();
            //setToolTip();           
        }
        Utility mUtility = new Utility();
        MasterBLL mMasterBLL = new MasterBLL();
        BrandObj mBrandObj = new BrandObj();
        BrandRegionObj mBrandRegionObj = new BrandRegionObj();
        BrandStatusObj mBrandStatusObj = new BrandStatusObj();
        BranTypeObj mBranTypeObj = new BranTypeObj();
        //AgentToolTip mAgentToolTip = new AgentToolTip();
        //PersonObj mPersonObj = new PersonObj();
        int l_rowindex = 0;
        #region"Private Method"

        private void prepareFilter()
        {

        }
        private void setToolTip()
        {
            try
            {
                //this.dgvBrand.Columns[0].ToolTipText = mAgentToolTip.Ask.ToString();
                //this.dgvBrand.Columns[1].ToolTipText = mAgentToolTip.PersonAsk.ToString();
                //this.dgvBrand.Columns[2].ToolTipText = mAgentToolTip.AgentCode.ToString();
                //this.dgvBrand.Columns[3].ToolTipText = mAgentToolTip.AgentDescription.ToString();
                //this.dgvBrand.Columns[4].ToolTipText = mAgentToolTip.AgentPhone.ToString();
                //this.dgvBrand.Columns[5].ToolTipText = mAgentToolTip.AgentAddress.ToString();
                //this.dgvBrand.Columns[6].ToolTipText = mAgentToolTip.AgentEmail.ToString();
                //this.dgvBrand.Columns[7].ToolTipText = mAgentToolTip.AgentRemark.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        
        private void sequenceGridviewcolumn()
        {
            //this.dgvPerson.Columns[0].Visible = false;
        }
        private void loadGrid()
        {
            try
            {
                DataTable mm = new DataTable();
                //dgvBrand.DataSource = mMasterBLL.selectDataTable("Agent", "");
                dgvBrand.DataSource = mMasterBLL.selectDataTable("POS_Brand", "");
                mUtility.setDataGridColumn(ref dgvBrand);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region"Private Event"
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                SetBrand L_SetBrand = new SetBrand();
                L_SetBrand.ShowDialog();
                if (L_SetBrand.DialogResult == DialogResult.Cancel)
                {
                    loadGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvBrand.Rows.Count > 0)
                {
                    l_rowindex = dgvBrand.CurrentRow.Index;                    
                    if (dgvBrand.CurrentRow.Cells[0].Value != null)
                    {
                        //Convert.ToString(dgvBrand.CurrentRow.Cells[0].Value);
                        //pan.BackColor = Color.AliceBlue;
                        // SetBrand L_SetAgent = new SetBrand((long)dgvBrand.CurrentRow.Cells[dgvtxaskey.Index].Value);
                        SetBrand L_SetBrand = new SetBrand(Convert.ToString(dgvBrand.CurrentRow.Cells[0].Value));
                        L_SetBrand.ShowDialog();
                        if (L_SetBrand.DialogResult == DialogResult.Cancel)
                        {
                            loadGrid();
                        }
                        dgvBrand.Rows[l_rowindex].Selected = true;
                        //dgvBrand.CurrentCell = dgvBrand.Rows[l_rowindex].Cells[0];
                        //dgvBrand.CurrentRow. = l_rowindex;
                        //pan.BackColor = System.Drawing.SystemColors.Control;
                        // this.textBox1.BackColor = System.Drawing.SystemColors.Control;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //GeneralUtility.ShowErrorMsg(ex);
            }

        }

        private void butFind_Click(object sender, EventArgs e)
        {
            try
            {
                loadGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvPerson_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnEdit_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }



        private void dgvBrand_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((int)e.ColumnIndex == dgvBrand.Columns[5].Index) //Brand region
            {
                if (e.Value != null)
                {
                    mBrandRegionObj.Ask = Convert.ToString(e.Value);
                    e.Value = ((BrandRegionObj)mMasterBLL.selectObjbyAskobj("POS_Brand_Region", mBrandRegionObj)).BrandRegionName;
                }
            }
            if ((int)e.ColumnIndex == dgvBrand.Columns[6].Index) //brand type
            {
                if (e.Value != null)
                {
                    mBranTypeObj.Ask = Convert.ToString(e.Value);
                    e.Value = ((BranTypeObj)mMasterBLL.selectObjbyAskobj("POS_Brand_Type", mBranTypeObj)).BrandTypeName;
                }
            }
            if ((int)e.ColumnIndex == dgvBrand.Columns[7].Index) //Brand status
            {
                if (e.Value != null)
                {
                    mBrandStatusObj.Ask = Convert.ToString(e.Value);
                    e.Value = ((BrandStatusObj)mMasterBLL.selectObjbyAskobj("POS_Brand_Status", mBrandStatusObj)).BrandStatusName;
                }
            }
           
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            try
            {
                //this.Opacity = this.Opacity = 0.1;               
                FindBase L_FindBase = new FindBase("POS_Brand", new BrandObj());
                L_FindBase.ShowDialog();
                if (L_FindBase.DialogResult == DialogResult.OK)
                {
                    loadGrid();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }


        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                FindBase L_FindBase = new FindBase("POS_Brand", new BrandObj());
                L_FindBase.ShowDialog();
                if (L_FindBase.DialogResult == DialogResult.OK)
                {
                    BrandObj mSysMenuGroup = (BrandObj)L_FindBase.DynObject;

                    //string data = Utility.getPropertyValue2(periodObj);
                    dgvBrand.DataSource = mMasterBLL.searchData("POS_Brand", mSysMenuGroup);

                }

                //loadGrid();
                //hideGridviewcolumn();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadGrid();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable l_ExcelTable = (DataTable)dgvBrand.DataSource;
                #region Remove Columns
                //l_tbl = l_Table.Copy();
                //l_tbl.AcceptChanges();

                ////l_tbl.Columns.Remove("Ask");
                ////l_tbl.Columns.Remove("TS");
                ////l_tbl.Columns.Remove("UD");
                ////l_tbl.Columns.Remove("UDdd");
                //if (l_tbl.Columns.Contains("Ask"))
                //{
                //    l_tbl.Columns.Remove("Ask");
                //}

                #endregion
                #region Change Header
                //l_tbl.Columns["EmployeeID"].ColumnName = "ID";
                //l_tbl.Columns["EmpName"].ColumnName = "Name";
                //l_tbl.Columns["T1"].ColumnName = "Income Tax No.";
                //l_tbl.Columns["N4"].ColumnName = "Categorys";
                //l_tbl.Columns["N3"].ColumnName = "No. of Children";
                //l_tbl.Columns["N10"].ColumnName = "No. of Parent";
                //l_tbl.Columns["T3"].ColumnName = "Effective Date";
                //l_tbl.Columns["MaritalStatus"].ColumnName = "Marital Status";

                //foreach (DataRow dtrow in l_tbl.Rows)
                //{
                //    dtrow.BeginEdit();
                //    if (dtrow["Categorys"].ToString() != "0")
                //    {
                //        dtrow["Category"] = Enum.GetName(typeof(PMEnum.IncomeTaxPCBCategory), dtrow["Categorys"]).Replace("_", " ");
                //    }
                //    if (dtrow["Effective Date"].ToString() != "0")
                //    {
                //        dtrow["Effective Date"] = GeneralUtility.StringToDate(dtrow["Effective Date"].ToString());
                //    }
                //    dtrow.EndEdit();
                //}
                //l_tbl.Columns.Remove("Categorys");
                #endregion
                #region Arrange Columns
                //// yyt 06-02-2013 set order of columns 
                //l_tbl.Columns["ID"].SetOrdinal(0);
                //l_tbl.Columns["Name"].SetOrdinal(1);
                //l_tbl.Columns["Income Tax No."].SetOrdinal(2);
                //l_tbl.Columns["Marital Status"].SetOrdinal(2);
                //l_tbl.Columns["Category"].SetOrdinal(3);
                //l_tbl.Columns["No. Of Parent"].SetOrdinal(4);
                //l_tbl.Columns["No. Of Children"].SetOrdinal(5);
                //l_tbl.Columns["Effective Date"].SetOrdinal(6);
                #endregion

                if (l_ExcelTable.Rows.Count <= 0)
                {
                    MessageBox.Show("There is no data to export");
                    return;
                }
                else
                {
                    ExcelUtil excel = new ExcelUtil();
                    excel.exportToExcel(l_ExcelTable, dgvBrand);
                }
                #region Write data
                //SaveFileDialog l_save = new SaveFileDialog();
                //l_save.FileName = System.Windows.Forms.Application.StartupPath + "\\" + "EmployeeIncomeTax.xls";
                //l_save.Filter = "xls files (*.xls)|*.xls|xlsx files (*.xlsx)|*.xlsx";
                //if (l_save.ShowDialog() == DialogResult.OK)
                //{

                //    System.IO.FileInfo l_Finfo = new System.IO.FileInfo(l_save.FileName);
                //    if (l_Finfo.Exists)
                //    {
                //        System.IO.File.Delete(l_save.FileName);

                //    }       
                //    //System.Diagnostics.Process.Start(l_save.FileName);                   

                //}


                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            try
            {
                mBrandObj.Ask = dgvBrand.CurrentRow.Cells[0].Value.ToString();
                HisBase L_HisBase = new HisBase("POS_Brand_History", mBrandObj);
                L_HisBase.ShowDialog();
                if (L_HisBase.DialogResult == DialogResult.OK)
                {
                    L_HisBase.Close();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelBase L_ExcelBase = new ExcelBase();
                L_ExcelBase.ShowDialog();
                if (L_ExcelBase.DialogResult == DialogResult.OK)
                {
                    L_ExcelBase.Close();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable l_Table = (DataTable)dgvBrand.DataSource;
                DataTable l_PreviewData = new DataTable();
                l_PreviewData = l_Table.Copy();
                ds.Tables.Add(l_PreviewData);
                ds.Tables[0].TableName = "data";
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show("There is no data to preview");
                    return;
                }
                else
                {
                    CHARS.HR.COMMON.General.Report.viewReport(ds, Application.StartupPath);                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
