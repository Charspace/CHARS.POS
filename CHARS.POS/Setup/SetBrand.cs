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
using CHARS.HR.COMMON.General;
using CHARS.HR.COMMON.BLL;
using CHARS.POS.BOL.Setup;


namespace CHARS.POS.Setup
{
    public partial class SetBrand : SetBase
    {

        public SetBrand()
        {
            InitializeComponent();
            clearUI();
            loadReference();
            setSampledata();
            setToolTip();
            saveState = true;
            controlUI();
        }
        public SetBrand(string aASK)
        {
            InitializeComponent();
            clearUI();
            loadReference();
            setToolTip();
            bindForm(aASK);
            saveState = false;
            controlUI();

        }

        Utility mUtility = new Utility();
        MasterBLL mMasterBLL = new MasterBLL();
        BrandObj mBrandObj = new BrandObj();
        //AgentToolTip mAgentToolTip = new AgentToolTip();
        //AgentSample mAgentSample = new AgentSample();
        private bool saveState = true;

        //reference 
        //PersonObj mPersonObj = new PersonObj();


        #region"Private Method"
        public void bindForm(string aAsk)
        {
            try
            {
                mBrandObj = new BrandObj();
                mBrandObj.Ask = aAsk;
                DataTable l_databale = new DataTable();
                l_databale = mMasterBLL.Findby("POS_Brand", mBrandObj);
                mBrandObj.Ask = Convert.ToString(l_databale.Rows[0][0]);
                mBrandObj.BrandName = Convert.ToString(l_databale.Rows[0][3]);
                mBrandObj.BrandDes = l_databale.Rows[0][4].ToString();
                mBrandObj.BrandRegion = l_databale.Rows[0][5].ToString();
                mBrandObj.BrandType = l_databale.Rows[0][6].ToString();                
                mBrandObj.BrandStatus = l_databale.Rows[0][7].ToString();                
                bindUI();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void loadReference()
        {
            loadBrandRegion();
            loadBrandType();
            loadBrandStatus();
        }
        private void loadBrandRegion()
        {
            cboBrandRegion.DisplayMember = "Brand Region Name";
            cboBrandRegion.ValueMember = "ASK";
            cboBrandRegion.DataSource = mMasterBLL.selectDataTable("POS_Brand_Region", "");
        }
        private void loadBrandType()
        {
            cboBrandType.DisplayMember = "Brand Type Name";
            cboBrandType.ValueMember = "ASK";
            cboBrandType.DataSource = mMasterBLL.selectDataTable("POS_Brand_Type", "");
        }
        private void loadBrandStatus()
        {
            cboBrandStatus.DisplayMember = "Brand Status Name";
            cboBrandStatus.ValueMember = "ASK";
            cboBrandStatus.DataSource = mMasterBLL.selectDataTable("POS_Brand_Status", "");
        }
        private bool isValid()
        {

            try
            {
                bool valid = true;
                errorproviderbase.Clear();
                if (txtBrandCode.TextLength == 0 || txtBrandCode.Text.Trim() == "")
                {
                    valid = mUtility.setInvalidTextbox(errorproviderbase, txtBrandCode);
                }
                else
                {
                    mUtility.setValidTextbox(errorproviderbase, txtBrandCode);
                }
                if (txtBrandDes.TextLength == 0 || txtBrandDes.Text.Trim() == "")
                {
                    valid = mUtility.setInvalidTextbox(errorproviderbase, txtBrandDes);
                }
                else
                {
                    mUtility.setValidTextbox(errorproviderbase, txtBrandDes);
                }              

                if (cboBrandRegion.SelectedValue == null || cboBrandRegion.Text.Trim() == "")
                {
                    valid = mUtility.setInvalidComboBox(errorproviderbase, cboBrandRegion);
                }
                else
                {
                    mUtility.setValidComboBox(errorproviderbase, cboBrandRegion);
                }

                if (cboBrandType.SelectedValue == null || cboBrandType.Text.Trim() == "")
                {
                    valid = mUtility.setInvalidComboBox(errorproviderbase, cboBrandType);
                }
                else
                {
                    mUtility.setValidComboBox(errorproviderbase, cboBrandType);
                }
                if (cboBrandStatus.SelectedValue == null || cboBrandStatus.Text.Trim() == "")
                {
                    valid = mUtility.setInvalidComboBox(errorproviderbase, cboBrandStatus);
                }
                else
                {
                    mUtility.setValidComboBox(errorproviderbase, cboBrandStatus);
                }                
                return valid;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        private void bindLObj()
        {
            try
            {
                if (mBrandObj.Ask == "0")
                {
                    mBrandObj.Ask = mUtility.getAsk();
                }
                mBrandObj.BrandName = txtBrandCode.Text.Trim();
                mBrandObj.BrandDes = txtBrandDes.Text.Trim();
                mBrandObj.BrandRegion = Convert.ToString(cboBrandRegion.SelectedValue);
                mBrandObj.BrandType = Convert.ToString(cboBrandType.SelectedValue);
                mBrandObj.BrandStatus = Convert.ToString(cboBrandStatus.SelectedValue);            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void clearUI()
        {
            try
            {
                mUtility.clearTextBox(txtBrandCode, txtBrandDes);
                mUtility.clearComboBox(cboBrandRegion, cboBrandType, cboBrandStatus);
                //mUtility.clearRichTextBox(rtxtAgentAddress, rtxtAgentRemark);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void bindUI()
        {
            try
            {                
                txtBrandCode.Text = mBrandObj.BrandName;
                txtBrandDes.Text = mBrandObj.BrandDes;
                cboBrandRegion.SelectedValue = mBrandObj.BrandRegion;
                cboBrandType.SelectedValue = mBrandObj.BrandType;
                cboBrandStatus.SelectedValue = mBrandObj.BrandStatus;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void setToolTip()
        {
            try
            {                
                toolTipbase.SetToolTip(txtBrandCode, mBrandObj.BrandName);
                toolTipbase.SetToolTip(txtBrandDes, mBrandObj.BrandDes);
                toolTipbase.SetToolTip(cboBrandRegion, mBrandObj.BrandRegion);
                toolTipbase.SetToolTip(cboBrandType, mBrandObj.BrandType);
                toolTipbase.SetToolTip(cboBrandStatus, mBrandObj.BrandStatus);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void setSampledata()
        {
            try
            {
                //mUtility.setComboBoxSampleData(cboPerson, mAgentSample.PersonAsk);
                //mUtility.setTextBoxSampleData(txtAgentCode, mAgentSample.AgentCode);
                //mUtility.setTextBoxSampleData(txtAgentDescription, mAgentSample.AgentDescription);
                //mUtility.setTextBoxSampleData(txtAgentPhone, mAgentSample.AgentPhone);
                //mUtility.setRichTextBoxSampleData(rtxtAgentAddress, mAgentSample.AgentAddress);
                //mUtility.setTextBoxSampleData(txtAgentEmail, mAgentSample.AgentEmail);
                //mUtility.setRichTextBoxSampleData(rtxtAgentRemark, mAgentSample.AgentRemark);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void controlUI()
        {
            try
            {
                if (saveState)
                {
                    mUtility.visibleButton(false, btnDelete);
                }
                else
                {
                    mUtility.visibleButton(true, btnDelete);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region"Private Event"
        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                mBrandObj = new BrandObj();
                clearUI();
                loadReference();
                setSampledata();
                setToolTip();
                saveState = true;
                controlUI(); ;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (isValid())
                {
                    bindLObj();
                    if (saveState)
                    {
                        ////Save sample
                        //if (mMasterBLL.saveObj("POS_Brand", mBrandObj))
                        //{
                        //    MessageBox.Show("Save Completely");
                        //    saveState = false;
                        //}
                        //Save with history
                        if (mMasterBLL.saveObjHis("POS_Brand", mBrandObj))
                        {
                            MessageBox.Show("Save Completely");
                            saveState = false;
                        }
                    }
                    else
                    {
                        ////update sample
                        //if (mMasterBLL.updateObj("POS_Brand", mBrandObj))
                        //{
                        //    MessageBox.Show("update Completely");
                        //}
                        //update with history
                        if (mMasterBLL.updateObjHis("POS_Brand", mBrandObj))
                        {
                            MessageBox.Show("update Completely");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bindLObj();
                    if (mMasterBLL.deleteObj("POS_Brand", mBrandObj, 1))
                    {
                        clearUI();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    





        //private void txtAgentPhone_Enter(object sender, EventArgs e)
        //{
        //    mUtility.enterTextbox(txtAgentPhone, mAgentSample.AgentPhone);
        //}

        //private void txtAgentEmail_Enter(object sender, EventArgs e)
        //{
        //    mUtility.enterTextbox(txtAgentEmail, mAgentSample.AgentEmail);
        //}

        //private void rtxtAgentAddress_Enter(object sender, EventArgs e)
        //{
        //    mUtility.enterRichTextbox(rtxtAgentAddress, mAgentSample.AgentAddress);
        //}

        //private void rtxtAgentRemark_Enter(object sender, EventArgs e)
        //{
        //    mUtility.enterRichTextbox(rtxtAgentRemark, mAgentSample.AgentRemark);
        //}
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {

        }
    }
}