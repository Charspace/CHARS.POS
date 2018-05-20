using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CHARS.HR.COMMON;
using CHARS.HR.BOL;
using CHARS.HR.COMMON.General;
using CHARS.HR.COMMON.PL;
using CHARS.HR;
using CHARS.HR.COMMON.BLL;
using CHARS.HR.COMMON.BOL;

namespace CHARS.POS
{
    public partial class CharSpace : Form
    {
        public CharSpace()
        {
            InitializeComponent();
        }
        Utility mUtility = new Utility();
        CurrentConnection mCurretnConnection; //= new CurrentConnection(Application.StartupPath);
        LicenseBLL mLicenseBLL = new LicenseBLL(Application.StartupPath);
        ConnectionBLL mConnectionBLL = new ConnectionBLL(Application.StartupPath);
        LoginUserBLL mLoginUserBLL = new LoginUserBLL(Application.StartupPath);
        OrganizationBLL mOrganizationBLL = new OrganizationBLL(Application.StartupPath);
        User mUser = new User();
        ProLogin mLogin;//= new ProLogin();
        VenRegistration mRegistration;
        SetDBController mDBController;
        MasterBLL mMasterBLL = new MasterBLL();
        //Licensekey mLicensekey;
        //Organization mOrganization;
        public GlobalMember mGlobalMember = new GlobalMember();



        #region"Private Property"
        #endregion

        #region"Public Property"
        public void changePanel(Panel myPanel)
        {
            if (tlpHR.GetControlFromPosition(0, 0) != null) ((Panel)tlpHR.GetControlFromPosition(0, 0)).Dispose();
            {
                tlpHR.Controls.Add(myPanel, 0, 0);
                myPanel.Show();
                myPanel.Dock = DockStyle.Fill;
            }
            //tlpMHR.GetControlFromPosition(0, 1).location = new System.Drawing.Point(12, 12);
            // myPanel.Size = new Size(this.Width, this.Height);
        }
//testing tts
        public void changeTab(Panel myPanel, string myFormName)
        {
            //    //CREATE TAB PAGE
            //    System.Windows.Forms.TabPage newtab;
            //    newtab = new System.Windows.Forms.TabPage();
            //    //TAB PAGE PROPERTIES
            //    newtab.Location = new System.Drawing.Point(4, 22);
            //    newtab.Name = myFormName;
            //    newtab.Padding = new System.Windows.Forms.Padding(3);
            //    newtab.Size = new System.Drawing.Size(851, 343);
            //    newtab.TabIndex = 0;
            //    newtab.Text = myFormName;
            //    newtab.UseVisualStyleBackColor = true;

            //    //ADD TAB PAGE INTO TAB CONTROL
            //    this.tcHR.Controls.Add(newtab);
            //    this.tcHR.SelectedTab = newtab;

            //    newtab.Controls.Add(myPanel);            
            //    myPanel.Show();
            //    myPanel.Dock = DockStyle.Fill;            
        }

        #endregion

        #region"Private Method"
        #endregion

        #region"Public Method"
        private void bindGlobalConnection()
        {
            mGlobalMember.ServerName = mConnectionBLL.getDSConnection().Tables[0].Rows[0][3].ToString();
            mGlobalMember.DataBaseName = mConnectionBLL.getDSConnection().Tables[0].Rows[0][4].ToString();
            mGlobalMember.SQLUserName = mConnectionBLL.getDSConnection().Tables[0].Rows[0][5].ToString();
            mGlobalMember.SQLPassword = mConnectionBLL.getDSConnection().Tables[0].Rows[0][6].ToString();
        }
        private void bindGlobalLoginUser()
        {
            //ApplicationMember.mLoginID = mUser.UserID;
            //ApplicationMember.mUserLevel = mUser.UserLevel;
            //ApplicationMember.mLoginUserAsk =mUser.Ask;
            //mGlobalMember.LoginID = mLoginUserBLL.readLoginUser().UserID;
            //mGlobalMember.LoginDescription = mLoginUserBLL.readLoginUser().LoginDescription;
            //mGlobalMember.Pwd = mLoginUserBLL.readLoginUser().Pwd;
        }
        private void bindGlobalOrganization()
        {
            mGlobalMember.OrganizationName = mOrganizationBLL.readDSOrganization().Tables[0].Rows[0][2].ToString();
            mGlobalMember.OrganizationAddress = mOrganizationBLL.readDSOrganization().Tables[0].Rows[0][3].ToString();
            mGlobalMember.OrganiztionWeb = mOrganizationBLL.readDSOrganization().Tables[0].Rows[0][4].ToString();
            mGlobalMember.OrganiztionEmail = mOrganizationBLL.readDSOrganization().Tables[0].Rows[0][5].ToString();
            ApplicationMember.mOrganizationName = mOrganizationBLL.readDSOrganization().Tables[0].Rows[0][2].ToString();
        }
        private void bindGlobalPC()
        {

            mGlobalMember.ApplicationPatch = Application.StartupPath;
            mGlobalMember.ComputerName = System.Environment.MachineName;
            mGlobalMember.ComputerUser = Environment.UserName;
        }
        private void bindGlobalControl()
        {
            tlsSystemUser.Text = ApplicationMember.mLoginID;  //mGlobalMember.LoginID;
            tlsServerName.Text = mGlobalMember.ServerName;
            tlsDatabaseName.Text = mGlobalMember.DataBaseName;
            tlsComputerUser.Text = mGlobalMember.ComputerUser;
            tlsComputerName.Text = mGlobalMember.ComputerName;

            this.Width = mGlobalMember.WorkingWidth;
            this.Height = mGlobalMember.WokingHeigh;
        }

        #endregion

        #region"Private Event"
        private void CharSpace_Load(object sender, EventArgs e)
        {
            tmrMain.Start();
            ribbon.Tabs.Clear();
            ribbon.OrbDropDown.MenuItems.Clear();
            ribbon.QuickAcessToolbar.Items.Clear();
            //test

            //LicenseBLL mLicenseBLL = new LicenseBLL(Application.StartupPath);
            //ConnectionBLL mConnectionBLL = new ConnectionBLL(Application.StartupPath);
            //LoginUserBLL mLoginUserBLL = new LoginUserBLL(Application.StartupPath);
            //User mUser = new User();
            //ProLogin mLogin ;//= new ProLogin();
            //VenRegistration mRegistration;
            //SetDBController mDBController;
            //Licensekey mLicensekey;
            //mCurretnConnection = new CurrentConnection(Application.StartupPath);
            ApplicationMember.mApplicationPatch = Application.StartupPath;
            bindGlobalOrganization();
            if (mLicenseBLL.checkLicense())
            {
                loadRegister();
                #region "old"

                //if (mConnectionBLL.checkConnection())
                //{
                //    mCurretnConnection = new CurrentConnection(Application.StartupPath);
                //    bindGlobalConnection();
                //    bindGlobalOrganization();
                //    mLogin = new ProLogin(mLoginUserBLL.readLoginUser(), Application.StartupPath);
                //    mLogin.ShowDialog();                    
                //    if (mLogin.DialogResult == DialogResult.OK)
                //    {
                //        bindGlobalLoginUser();
                //        bindGlobalPC();
                //        bindGlobalControl();

                //        //DataTable L_menudtl = new DataTable();
                //        //L_menudtl = mMasterBLL.selectDataTable("SYS_MENU", "");//According user level                        
                //        //mUtility.loadMenu(ref ribbon, ref tcHR, L_menudtl);
                //        //mUtility.loadHome(ref tcHR);

                //        Dictionary<string, string> dic = new Dictionary<string, string>();
                //        dic.Add("@UserID", ApplicationMember.mLoginID);
                //        DataTable tbl = mMasterBLL.executeSelectProcedure("CS_SP_SELECT_USER_MENU", dic);
                //        mUtility.loadMenu(ref ribbon, ref tcHR, tbl);
                //        mUtility.loadHome(ref tcHR);
                //    }
                //    else
                //    {
                //        this.Dispose();
                //        this.Close();
                //    }
                //}
                //else
                //{
                //    mDBController = new SetDBController(Application.StartupPath,1);
                //    if (mDBController.ShowDialog() == DialogResult.OK)
                //    {
                //        MessageBox.Show("System will restart");
                //        Application.Restart();
                //    }
                //    else
                //    {
                //        //MessageBox.Show(mLogin.ShowDialog().ToString());
                //        //this.Close();
                //    }
                //}
                #endregion
            }
            else
            {
                mRegistration = new VenRegistration(Application.StartupPath, 1);
                mRegistration.ShowDialog();
                if (mRegistration.DialogResult == DialogResult.OK)
                {
                    loadRegister();
                    //MessageBox.Show("System will restart");
                    //Application.Restart();
                    ////loadGrid();
                    //MessageBox.Show("success");
                    //this.Close();
                    //Close();
                }
                if (mRegistration.DialogResult == DialogResult.Retry)
                {
                    loadTrail();
                }
                if (mRegistration.DialogResult == DialogResult.Cancel)
                {
                    this.Close();
                    //Close();
                }
            }
        }


        private void loadTrail()
        {
            try
            {
                #region "Trial"
                if (mConnectionBLL.checkConnection())
                {
                    mCurretnConnection = new CurrentConnection(Application.StartupPath);
                    bindGlobalConnection();
                    bindGlobalOrganization();
                    mLogin = new ProLogin(mLoginUserBLL.readLoginUser(), Application.StartupPath);
                    mLogin.ShowDialog();
                    if (mLogin.DialogResult == DialogResult.OK)
                    {
                        bindGlobalLoginUser();
                        bindGlobalPC();
                        bindGlobalControl();


                        Dictionary<string, string> dic = new Dictionary<string, string>();
                        dic.Add("@UserID", ApplicationMember.mLoginID);
                        DataTable tbl = mMasterBLL.executeSelectProcedure("CS_SP_SELECT_USER_MENU", dic);
                        mUtility.loadMenu(ref ribbon, ref tcHR, tbl);
                        mUtility.loadHome(ref tcHR);
                    }
                    else
                    {
                        this.Dispose();
                        this.Close();
                    }
                }
                else
                {
                    mDBController = new SetDBController(Application.StartupPath, 1);
                    if (mDBController.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("System will restart");
                        Application.Restart();
                    }
                    else
                    {
                        //MessageBox.Show(mLogin.ShowDialog().ToString());
                        //this.Close();
                    }
                }
                #endregion  
            }
            catch
            {
            }
        }
        private void loadRegister()
        {
            try
            {
                #region "Register"
                if (mConnectionBLL.checkConnection())
                {
                    mCurretnConnection = new CurrentConnection(Application.StartupPath);
                    bindGlobalConnection();
                    //bindGlobalOrganization();
                    mLogin = new ProLogin(mLoginUserBLL.readLoginUser(), Application.StartupPath);
                    mLogin.ShowDialog();
                    if (mLogin.DialogResult == DialogResult.OK)
                    {
                        bindGlobalLoginUser();
                        bindGlobalPC();
                        bindGlobalControl();
                        Dictionary<string, string> dic = new Dictionary<string, string>();
                        dic.Add("@UserID", ApplicationMember.mLoginID);
                        DataTable tbl = mMasterBLL.executeSelectProcedure("CS_SP_SELECT_USER_MENU", dic);
                        mUtility.loadMenu(ref ribbon, ref tcHR, tbl);
                        mUtility.loadHome(ref tcHR);
                    }
                    else
                    {
                        this.Dispose();
                        this.Close();
                    }
                }
                else
                {
                    mDBController = new SetDBController(Application.StartupPath, 1);
                    if (mDBController.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("System will restart");
                        Application.Restart();
                    }
                    else
                    {
                        //MessageBox.Show(mLogin.ShowDialog().ToString());
                        //this.Close();
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        protected void b_Click(object sender, EventArgs e)
        {
            //RibbonButton clicked = (RibbonButton)sender;
            //Assembly l_asm = null;
            //Object l_FormObj = new object();
            //string l_assemblyName = "CHARS.HR.PL.List";
            //l_assemblyName = Path.GetFileNameWithoutExtension("CHARS.HR.PL.List");
            //l_asm = Assembly.Load(l_assemblyName);
            //l_FormObj = l_asm.CreateInstance("CHARS.HR.PL.List.Lst" + clicked.Text, true);
            //Panel b = new Panel();
            //Form a = (Form)l_FormObj;
            //Control[] c = a.Controls.Find("pan", false);
            //foreach (Control ce in c)
            //{
            //    b = (Panel)ce;
            //}
            //// mUtility.newTab(ref tcHR, b, a.Text);   
        }



        private void rbtnMenuGroup_Click(object sender, EventArgs e)
        {
            //LstMenuGroup L_Lst = new LstMenuGroup();
            //mUtility.newTab(ref tcHR, L_Lst.pan, L_Lst.Text);
        }

        private void rbtnControlGroup_Click(object sender, EventArgs e)
        {
            //LstControlGroup L_Lst = new LstControlGroup();
            //mUtility.newTab(ref tcHR, L_Lst.pan, L_Lst.Text);     
        }

        private void rbtnEmployeeGroup_Click(object sender, EventArgs e)
        {
            //LstEmployeeGroup L_Lst = new LstEmployeeGroup();
            //mUtility.newTab(ref tcHR, L_Lst.pan, L_Lst.Text);
            ////changeTab(L_Lst.pan, L_Lst.Text);
            ////changePanel(L_Lst.pan);
        }

        private void rbtnUser_Click(object sender, EventArgs e)
        {
            //LstUser L_Lst = new LstUser();
            //mUtility.newTab(ref tcHR, L_Lst.pan, L_Lst.Text);
            ////changeTab(L_Lst.pan, L_Lst.Text);
            ////changePanel(L_Lst.pan);
        }

        private void rbtnLogin_Click(object sender, EventArgs e)
        {
            ProLogin L_Pro = new ProLogin();
            mLogin = new ProLogin(mLoginUserBLL.readLoginUser(), Application.StartupPath);
            mLogin.ShowDialog();
            if (mLogin.DialogResult == DialogResult.OK)
            {
                mUtility.closeAllTab(ref tcHR);
                bindGlobalLoginUser();
                bindGlobalPC();
                bindGlobalControl();
                MessageBox.Show("OK, mainfrom");
            }
            else
            {
                this.Dispose();
                this.Close();
            }
        }

        private void rbtnChangeConnection_Click(object sender, EventArgs e)
        {
            LstDBController L_Pro = new LstDBController();
            //mUtility.newTab(ref tcHR, L_Pro.pan, L_Pro.Text);
            //changeTab(L_Pro.pan, L_Pro.Text);
            //changePanel(L_Pro.pan); 
        }

        private void rbtnLogout_Click(object sender, EventArgs e)
        {

        }

        private void rbtnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void btnTabClose_Click(object sender, EventArgs e)
        {
            //mUtility.closeTab(ref tcHR, tcHR.SelectedTab);            
            //tcHR.Controls.Remove(tcHR.SelectedTab);
            mUtility.closeAllTab(ref tcHR);
        }

        private void rbtnType_Click(object sender, EventArgs e)
        {
            // LstLucyType L_Pro = new LstLucyType();
            //mUtility.newTab(ref tcHR, L_Pro.pan, L_Pro.Text);
        }

        private void rbtnPerson_Click(object sender, EventArgs e)
        {
            //LstPerson L_Pro = new LstPerson();
            //mUtility.newTab(ref tcHR, L_Pro.pan, L_Pro.Text);
        }

        private void rbtnCompetator_Click(object sender, EventArgs e)
        {
            //LstCompetator L_Pro = new LstCompetator();
            //mUtility.newTab(ref tcHR, L_Pro.pan, L_Pro.Text);
        }

        private void rbtnMaster_Click(object sender, EventArgs e)
        {
            //LstMaster L_Pro = new LstMaster();
            //mUtility.newTab(ref tcHR, L_Pro.pan, L_Pro.Text);
        }

        private void rbtnAgent_Click(object sender, EventArgs e)
        {
            //LstAgent L_Pro = new LstAgent();
            //mUtility.newTab(ref tcHR, L_Pro.pan, L_Pro.Text);
        }

        private void rbtnPlayer_Click(object sender, EventArgs e)
        {
            //LstPlayer L_Pro = new LstPlayer();
            //mUtility.newTab(ref tcHR, L_Pro.pan, L_Pro.Text);
        }

        private void rbtnList_Click(object sender, EventArgs e)
        {
            //LstList L_Pro = new LstList();
            //mUtility.newTab(ref tcHR, L_Pro.pan, L_Pro.Text);
        }

        private void rbtnSubmit_Click(object sender, EventArgs e)
        {
            //LstSubmit L_Pro = new LstSubmit();
            //mUtility.newTab(ref tcHR, L_Pro.pan, L_Pro.Text);
        }

        private void rbtnResult_Click(object sender, EventArgs e)
        {
            //LstResult L_Pro = new LstResult();
            //mUtility.newTab(ref tcHR, L_Pro.pan, L_Pro.Text);
        }

        private void rbtnGain_Click(object sender, EventArgs e)
        {
            //LstGain L_Pro = new LstGain();
            //mUtility.newTab(ref tcHR, L_Pro.pan, L_Pro.Text);
        }

        private void rbtnPeriod_Click(object sender, EventArgs e)
        {
            //LstPeriod L_Pro = new LstPeriod();
            //mUtility.newTab(ref tcHR, L_Pro.pan, L_Pro.Text);
        }

        private void ribbonButton10_Click(object sender, EventArgs e)
        {
            //LstPeriod L_Pro = new LstPeriod();
            //mUtility.newTab(ref tcHR, L_Pro.pan, L_Pro.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tcHR.Controls.Remove(tcHR.SelectedTab);
        }

        //private void tcHR_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        private void tmrMain_Tick(object sender, EventArgs e)
        {
            //this.Text = "CS (" + System.DateTime.Now.ToLongTimeString() + ")";
            tlsClock.Text = System.DateTime.Now.ToShortDateString() + " : " + System.DateTime.Now.ToLongTimeString();

        }


    }

}
