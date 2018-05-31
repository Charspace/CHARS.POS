namespace CHARS.POS.Setup
{
    partial class SetBrand
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblBrandName = new System.Windows.Forms.Label();
            this.txtBrandCode = new System.Windows.Forms.TextBox();
            this.lblBranddes = new System.Windows.Forms.Label();
            this.txtBrandDes = new System.Windows.Forms.TextBox();
            this.cboBrandType = new System.Windows.Forms.ComboBox();
            this.lblBrandtype = new System.Windows.Forms.Label();
            this.cboBrandStatus = new System.Windows.Forms.ComboBox();
            this.lblBrandStatus = new System.Windows.Forms.Label();
            this.cboBrandRegion = new System.Windows.Forms.ComboBox();
            this.LblBrandRegion = new System.Windows.Forms.Label();
            this.pan.SuspendLayout();
            this.grbEntry.SuspendLayout();
            this.grbEntryData.SuspendLayout();
            this.grbControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorproviderbase)).BeginInit();
            this.SuspendLayout();
            // 
            // pan
            // 
            this.pan.Location = new System.Drawing.Point(8, 22);
            this.pan.Size = new System.Drawing.Size(357, 230);
            // 
            // grbEntry
            // 
            this.grbEntry.Size = new System.Drawing.Size(349, 223);
            // 
            // grbEntryData
            // 
            this.grbEntryData.Controls.Add(this.cboBrandRegion);
            this.grbEntryData.Controls.Add(this.LblBrandRegion);
            this.grbEntryData.Controls.Add(this.cboBrandStatus);
            this.grbEntryData.Controls.Add(this.lblBrandStatus);
            this.grbEntryData.Controls.Add(this.cboBrandType);
            this.grbEntryData.Controls.Add(this.lblBrandtype);
            this.grbEntryData.Controls.Add(this.lblBrandName);
            this.grbEntryData.Controls.Add(this.txtBrandCode);
            this.grbEntryData.Controls.Add(this.lblBranddes);
            this.grbEntryData.Controls.Add(this.txtBrandDes);
            this.grbEntryData.Size = new System.Drawing.Size(338, 160);
            // 
            // grbControl
            // 
            this.grbControl.Location = new System.Drawing.Point(0, 178);
            this.grbControl.Size = new System.Drawing.Size(344, 40);
            // 
            // btnDelete
            // 
            this.toolTipbase.SetToolTip(this.btnDelete, "Click to delete");
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.toolTipbase.SetToolTip(this.btnNew, "Click to prepare new item");
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.toolTipbase.SetToolTip(this.btnSave, "Click to save");
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(259, 10);
            this.toolTipbase.SetToolTip(this.btnClose, "Click to close");
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.Size = new System.Drawing.Size(0, 16);
            this.lblHeader.Text = "";
            // 
            // lblBrandName
            // 
            this.lblBrandName.AutoSize = true;
            this.lblBrandName.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrandName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBrandName.Location = new System.Drawing.Point(33, 19);
            this.lblBrandName.Name = "lblBrandName";
            this.lblBrandName.Size = new System.Drawing.Size(64, 15);
            this.lblBrandName.TabIndex = 127;
            this.lblBrandName.Text = "Brand Code";
            // 
            // txtBrandCode
            // 
            this.txtBrandCode.BackColor = System.Drawing.Color.AliceBlue;
            this.txtBrandCode.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBrandCode.Location = new System.Drawing.Point(101, 16);
            this.txtBrandCode.Name = "txtBrandCode";
            this.txtBrandCode.Size = new System.Drawing.Size(166, 21);
            this.txtBrandCode.TabIndex = 124;
            // 
            // lblBranddes
            // 
            this.lblBranddes.AutoSize = true;
            this.lblBranddes.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBranddes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBranddes.Location = new System.Drawing.Point(1, 47);
            this.lblBranddes.Name = "lblBranddes";
            this.lblBranddes.Size = new System.Drawing.Size(96, 15);
            this.lblBranddes.TabIndex = 126;
            this.lblBranddes.Text = "Brand Description";
            // 
            // txtBrandDes
            // 
            this.txtBrandDes.BackColor = System.Drawing.Color.AliceBlue;
            this.txtBrandDes.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBrandDes.Location = new System.Drawing.Point(101, 43);
            this.txtBrandDes.Name = "txtBrandDes";
            this.txtBrandDes.Size = new System.Drawing.Size(166, 21);
            this.txtBrandDes.TabIndex = 125;
            // 
            // cboBrandType
            // 
            this.cboBrandType.BackColor = System.Drawing.Color.AliceBlue;
            this.cboBrandType.FormattingEnabled = true;
            this.cboBrandType.Location = new System.Drawing.Point(102, 97);
            this.cboBrandType.Name = "cboBrandType";
            this.cboBrandType.Size = new System.Drawing.Size(166, 23);
            this.cboBrandType.TabIndex = 151;
            // 
            // lblBrandtype
            // 
            this.lblBrandtype.AutoSize = true;
            this.lblBrandtype.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrandtype.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBrandtype.Location = new System.Drawing.Point(33, 100);
            this.lblBrandtype.Name = "lblBrandtype";
            this.lblBrandtype.Size = new System.Drawing.Size(65, 15);
            this.lblBrandtype.TabIndex = 152;
            this.lblBrandtype.Text = "Brand Type";
            // 
            // cboBrandStatus
            // 
            this.cboBrandStatus.BackColor = System.Drawing.Color.AliceBlue;
            this.cboBrandStatus.FormattingEnabled = true;
            this.cboBrandStatus.Location = new System.Drawing.Point(102, 124);
            this.cboBrandStatus.Name = "cboBrandStatus";
            this.cboBrandStatus.Size = new System.Drawing.Size(166, 23);
            this.cboBrandStatus.TabIndex = 153;
            // 
            // lblBrandStatus
            // 
            this.lblBrandStatus.AutoSize = true;
            this.lblBrandStatus.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrandStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBrandStatus.Location = new System.Drawing.Point(29, 127);
            this.lblBrandStatus.Name = "lblBrandStatus";
            this.lblBrandStatus.Size = new System.Drawing.Size(69, 15);
            this.lblBrandStatus.TabIndex = 154;
            this.lblBrandStatus.Text = "Brand Status";
            // 
            // cboBrandRegion
            // 
            this.cboBrandRegion.BackColor = System.Drawing.Color.AliceBlue;
            this.cboBrandRegion.FormattingEnabled = true;
            this.cboBrandRegion.Location = new System.Drawing.Point(102, 70);
            this.cboBrandRegion.Name = "cboBrandRegion";
            this.cboBrandRegion.Size = new System.Drawing.Size(166, 23);
            this.cboBrandRegion.TabIndex = 155;
            // 
            // LblBrandRegion
            // 
            this.LblBrandRegion.AutoSize = true;
            this.LblBrandRegion.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBrandRegion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LblBrandRegion.Location = new System.Drawing.Point(30, 73);
            this.LblBrandRegion.Name = "LblBrandRegion";
            this.LblBrandRegion.Size = new System.Drawing.Size(68, 15);
            this.LblBrandRegion.TabIndex = 156;
            this.LblBrandRegion.Text = "Brand region";
            // 
            // SetBrand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 259);
            this.Name = "SetBrand";
            this.Text = "SetBrand";
            this.toolTipbase.SetToolTip(this, "Drap to move to desired location");
            this.pan.ResumeLayout(false);
            this.grbEntry.ResumeLayout(false);
            this.grbEntryData.ResumeLayout(false);
            this.grbEntryData.PerformLayout();
            this.grbControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorproviderbase)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboBrandRegion;
        public System.Windows.Forms.Label LblBrandRegion;
        private System.Windows.Forms.ComboBox cboBrandStatus;
        public System.Windows.Forms.Label lblBrandStatus;
        private System.Windows.Forms.ComboBox cboBrandType;
        public System.Windows.Forms.Label lblBrandtype;
        public System.Windows.Forms.Label lblBrandName;
        public System.Windows.Forms.TextBox txtBrandCode;
        public System.Windows.Forms.Label lblBranddes;
        public System.Windows.Forms.TextBox txtBrandDes;
    }
}