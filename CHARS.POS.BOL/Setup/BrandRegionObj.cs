using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHARS.POS.BOL.Setup
{
    public class BrandRegionObj
    {
        public BrandRegionObj()
        {
            setDefaultValue();
        }
        #region"Private Property"
        private string mAsk;
        private string mTS;
        private string mUD;
        private string mBrandRegionName;
        private string mBrandRegionDes;
        private string mBrandRegionStatus;
        private string mDisplaySequence;
        private string mDisplayStatus;
        private string mBrandRegionRemark;

        #endregion
        #region"Public Property"
        public string Ask
        {
            get { return mAsk; }
            set { mAsk = value; }
        }
        public string TS
        {
            get { return mTS; }
            set { mTS = value; }
        }
        public string UD
        {
            get { return mUD; }
            set { mUD = value; }
        }
        public string BrandRegionName
        {
            get { return mBrandRegionName; }
            set { mBrandRegionName = value; }
        }
        public string BrandRegionDes
        {
            get { return mBrandRegionDes; }
            set { mBrandRegionDes = value; }
        }
        public string BrandRegionStatus
        {
            get { return mBrandRegionStatus; }
            set { mBrandRegionStatus = value; }
        }
        public string DisplaySequence
        {
            get { return mDisplaySequence; }
            set { mDisplaySequence = value; }
        }
        public string DisplayStatus
        {
            get { return mDisplayStatus; }
            set { mDisplayStatus = value; }
        }
        public string BrandRegionRemark
        {
            get { return mBrandRegionRemark; }
            set { mBrandRegionRemark = value; }
        }
        #endregion
        #region"Default Property"
        public void setDefaultValue()
        {
            Ask = "0";
            TS = "";
            UD = "";
            mBrandRegionName = "";
            mBrandRegionDes = "";
            mBrandRegionStatus = "0";
            mDisplaySequence = "0";
            mDisplayStatus = "0";
            mBrandRegionRemark = "";

        }
        #endregion
    }
}

