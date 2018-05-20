namespace CHARS.POS.BOL
{
    class stock
    {

        public stock()
        {
            setDefaultValue();
        }
        

        #region "private member"
        private string mAsk;
        private string mTS;
        private string mUD;
        private string mCode;
        private string mDescription;
        private string mLibrary;
        private string mCategory;
        private string mSubCategory;
        private string mWriter;
        private string mPublisher;
        private string mPublishDate;
        private string mPublishTimes;
        private string mDonator;
        private string mDinationDate;
        private string mBookValue;
        private string mBookStatus;
        private string mRentDuration;
        private string mRemark;
        private string mBookBarCode;
        private string mBookImage;
        private string mBookQR;
        private string mTranDate;
        //private byte[] mPicture;
        #endregion
        #region "public member"
        [DataMember]
        public string Ask
        {
            get { return mAsk; }
            set { mAsk = value; }
        }
        [DataMember]
        public string TS
        {
            get { return mTS; }
            set { mTS = value; }
        }
        [DataMember]
        public string UD
        {
            get { return mUD; }
            set { mUD = value; }
        }
        [DataMember]
        public string Code
        {
            get { return mCode; }
            set { mCode = value; }
        }
        [DataMember]
        public string Description
        {
            get { return mDescription; }
            set { mDescription = value; }
        }
        [DataMember]
        public string Library
        {
            get { return mLibrary; }
            set { mLibrary = value; }
        }
        [DataMember]
        public string Category
        {
            get { return mCategory; }
            set { mCategory = value; }
        }
        [DataMember]
        public string SubCategory
        {
            get { return mSubCategory; }
            set { mSubCategory = value; }
        }
        [DataMember]
        public string Writer
        {
            get { return mWriter; }
            set { mWriter = value; }
        }
        [DataMember]
        public string Publisher
        {
            get { return mPublisher; }
            set { mPublisher = value; }
        }
        [DataMember]
        public string PublishDate
        {
            get { return mPublishDate; }
            set { mPublishDate = value; }

        }
        [DataMember]
        public string PublishTimes
        {
            get { return mPublishTimes; }
            set { mPublishTimes = value; }

        }
        [DataMember]
        public string Donator
        {
            get { return mDonator; }
            set { mDonator = value; }
        }
        [DataMember]
        public string DonationDate
        {
            get { return mDinationDate; }
            set { mDinationDate = value; }
        }
        [DataMember]
        public string BookValue
        {
            get { return mBookValue; }
            set { mBookValue = value; }
        }
        [DataMember]
        public string BookStatus
        {
            get { return mBookStatus; }
            set { mBookStatus = value; }
        }

        [DataMember]
        public string RentDuration
        {
            get { return mRentDuration; }
            set { mRentDuration = value; }
        }
        [DataMember]
        public string Remark
        {
            get { return mRemark; }
            set { mRemark = value; }
        }

        [DataMember]
        public string BookBarCode
        {
            get { return mBookBarCode; }
            set { mBookBarCode = value; }
        }
        [DataMember]
        public string BookImage
        {
            get { return mBookImage; }
            set { mBookImage = value; }
        }
        [DataMember]
        public string BookQR
        {
            get { return mBookQR; }
            set { mBookQR = value; }
        }
        [DataMember]
        public string TranDate
        {
            get { return mTranDate; }
            set { mTranDate = value; }
        }

        #endregion


        #region"Default Property"
        public void setDefaultValue()
        {
            mAsk = "0";
            mTS = "0";
            mUD = "0";
            mCode = "";
            mDescription = "";
            mLibrary = "0";
            mCategory = "0";
            mSubCategory = "0";
            mWriter = "0";
            mPublisher = "0";
            mPublishDate = "0";
            mPublishTimes = "";
            mDonator = "";
            mDinationDate = "";
            mBookValue = "0";
            mBookStatus = "0";
            mRentDuration = "0";
            mRemark = "";
            mBookBarCode = "";
            mBookImage = "";
            mBookQR = "";
            mTranDate = "";
        }
        #endregion
    }
}
