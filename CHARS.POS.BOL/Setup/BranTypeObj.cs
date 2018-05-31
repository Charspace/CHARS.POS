using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHARS.POS.BOL.Setup
{
    public class BranTypeObj
    {
        public BranTypeObj()
        {
            setDefaultValue();
        }
        #region"Private Property"
        private string mAsk;
        private string mTS;
        private string mUD;
        private string mBrandTypeName;
        private string mBrandTypeDes;
        private string mBrandTypeStatus;
        private string mDisplaySequence;
        private string mDisplayStatus;
        private string mBrandTypeRemark;

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
        public string BrandTypeName
        {
            get { return mBrandTypeName; }
            set { mBrandTypeName = value; }
        }
        public string BrandTypeDes
        {
            get { return mBrandTypeDes; }
            set { mBrandTypeDes = value; }
        }
        public string BrandTypeStatus
        {
            get { return mBrandTypeStatus; }
            set { mBrandTypeStatus = value; }
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
        public string BrandTypeRemark
        {
            get { return mBrandTypeRemark; }
            set { mBrandTypeRemark = value; }
        }
        #endregion
        #region"Default Property"
        public void setDefaultValue()
        {
            Ask = "0";
            TS = "";
            UD = "";
            mBrandTypeName = "";
            mBrandTypeDes = "";
            mBrandTypeStatus = "0";
            mDisplaySequence = "0";
            mDisplayStatus = "0";
            mBrandTypeRemark = "";

        }
        #endregion
    }
}

