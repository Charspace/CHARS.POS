using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHARS.POS.BOL.Setup
{
    public class BrandObj
    {
        public BrandObj()
        {
            setDefaultValue();
        }
        #region"Private Property"
        private string mAsk;
        private string mTS;
        private string mUD;
        private string mBrandName;
        private string mBrandDes;
        private string mBrandRegion;
        private string mBrandType;
        private string mBrandStatus;

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
        public string BrandName
        {
            get { return mBrandName; }
            set { mBrandName = value; }
        }
        public string BrandDes
        {
            get { return mBrandDes; }
            set { mBrandDes = value; }
        }
        public string BrandRegion
        {
            get { return mBrandRegion; }
            set { mBrandRegion = value; }
        }
        public string BrandType
        {
            get { return mBrandType; }
            set { mBrandType = value; }
        }
        public string BrandStatus
        {
            get { return mBrandStatus; }
            set { mBrandStatus = value; }
        }
      
        #endregion
        #region"Default Property"
        public void setDefaultValue()
        {
            Ask = "0";
            TS = "";
            UD = "";
            BrandName = "";
            BrandDes = "";
            BrandRegion = "";
            BrandType = "";
            BrandStatus = "";
            
        }
        #endregion
    }
}

