namespace LBLibrary
{
    public class Operator
    {
        #region Properties

        /// <summary>
        /// Person properties
        /// </summary>
        public long Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string CallSign { get; set; }

        #endregion

        #region FullName: Id, FName, LName, CallSign

        /// <summary>
        /// Returns Person Id, First Name, Last Name, and Callsign
        /// </summary>
        public string FullName => $"{Id} {FName?.Trim()} {LName?.Trim()} {CallSign?.Trim()}";

        #endregion

        #region FirstLastCallsign: FNmand, LName, CallSign

        /// <summary>
        /// Returns Person: First name, Last name, and Callsign
        /// </summary>
        public string FirstLastCallsign => $"{FName?.Trim()} {LName?.Trim()} {CallSign?.Trim()}";

        #endregion

        #region IdAndCallsign: Id, CallSign

        /// <summary>
        /// Returns Person Id, and Callsign
        /// </summary>
        public string IdAndCallsign => $" #{Id} {CallSign?.Trim()}";

        #endregion

    } // end class Operator

} // end namespace LBLibrary

