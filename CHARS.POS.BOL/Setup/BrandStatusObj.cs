using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHARS.POS.BOL.Setup
{
    public class BrandStatusObj
    {
        public BrandStatusObj()
        {
            setDefaultValue();
        }
        #region"Private Property"
        private string mAsk;
        private string mTS;
        private string mUD;
        private string mBrandStatusName;
        private string mBrandStatusDes;
        private string mBrandStatusStatus;
        private string mDisplaySequence;
        private string mDisplayStatus;
        private string mBrandStatusRemark;

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
        public string BrandStatusName
        {
            get { return mBrandStatusName; }
            set { mBrandStatusName = value; }
        }
        public string BrandStatusDes
        {
            get { return mBrandStatusDes; }
            set { mBrandStatusDes = value; }
        }
        public string BrandRegionStatus
        {
            get { return mBrandStatusStatus; }
            set { mBrandStatusStatus = value; }
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
            get { return mBrandStatusRemark; }
            set { mBrandStatusRemark = value; }
        }
        #endregion
        #region"Default Property"
        public void setDefaultValue()
        {
            Ask = "0";
            TS = "";
            UD = "";
            mBrandStatusName = "";
            mBrandStatusDes = "";
            mBrandStatusStatus = "0";
            mDisplaySequence = "0";
            mDisplayStatus = "0";
            mBrandStatusRemark = "";

        }
        #endregion
    }
}

