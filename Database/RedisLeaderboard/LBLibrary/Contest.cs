using System;

namespace LBLibrary
{
    public class Contest
    {
        #region Category Enumerations

        #region enum LeaderBoards

        public enum LeaderBoards
        {
            HighScore,
            ByAssisted,
            ByBand,
            ByMode,
            ByPower,
            ByOverLay,
        }

        #endregion

        #region enum ContestName

        public enum ContestName
        {
            CQ160CW,
            CQ160SSB,
            CQWPXCW,
            CQWPXRTTY,
            CQWPXSSB,
            CQVHF,
            CQWWCW,
            CQWWRTTY,
            CQWWSSB
        };

        #endregion

        #region enum Assisted

        public enum CategoryAssisted
        {
            Assisted,
            NonAssisted
        };

        #endregion

        #region enum Band

        public enum CategoryBand
        {
            _ALL,
            _160M,
            _80M,
            _40M,
            _20M,
            _15M,
            _10M
        };

        #endregion

        #region enum Mode

        public enum CategoryMode
        {
            SSB,
            CW,
            RTTY,
            FM,
            Mixed
        }

        #endregion

        #region enum Operator

        enum CategoryOperator
        {
            Single,
            Multi,
            CheckLog
        }

        #endregion

        #region enum Power
        enum CategoryPower
        {
            High,
            Low,
            QRP
        }
        #endregion

        #region enum Station
        enum CategoryStation
        {
            Fixed,
            Mobile,
            Rover,
            Portable,
            RoverLimited,
            RoverUnlimited,
            Expidetion,
            HQ,
            School
        }
        #endregion

        #region enum Time
        enum CategoryTime
        {
            Six,
            Tweleve,
            TwentyFour
        }
        #endregion

        #region enum Transmitter
        enum CategoryTransmitter
        {
            One,
            Two,
            Limited,
            Unlimited,
            SWL
        }
        #endregion

        #region enum Overlay
        enum CategoryOverlay
        {
            Classic,
            Rookie,
            Wires,
            NoviceTech,
            OverFifty
        }
        #endregion

        #endregion

        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public string Assisted { get; set; }
        public string Band { get; set; }
        public string Mode { get; set; }
        public string Operator { get; set; }
        public string Power { get; set; }
        public string Station { get; set; }
        public string Time { get; set; }
        public string Transmitter { get; set; }
        public string Overlay { get; set; }
        public string Club { get; set; }

    } // end class Contest

} // end namespace LBLibrary