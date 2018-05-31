using System;
using System.Collections.Generic;
using System.Text;

namespace CHARS.HR.PL
{
    class LuckyMasterEnum
    {
        public enum ColoumnsWidth
        {
            code = 50,
            codeLong = 70,
            description = 150,
            descriptionLong = 180,
            date = 68,
            amount = 40
        }
        public enum ResultType
        {
            Draw= 1,
            Vote=0            
        }
        public enum ComissionType
        {
            times = 1,
            percent = 0
        }
        public enum PassType
        {
            times = 1,
            percent = 0
        }
        public enum VoteeType
        {
            Body = 1,
            GoTotal = 2,
            Maung=3
        }
        public enum VoteeState
        {

            MainCompetator = 1,
            SecondCompetator = 2,
            GoTotalUp = 3,
            GoTotalDown=4
      
        }
    }
}
