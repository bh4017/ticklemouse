namespace ticklemouse
{
    using System;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Xml.Serialization;

    [Serializable]
    public class Settings : ISerializable
    {
        #region CONSTANT FIELDS
        #endregion
        #region FIELDS
        #endregion
        #region CONSTRUCTORS
        public Settings() {}
        protected Settings(SerializationInfo si, StreamingContext sc)
        {
            TickleFrequency = si.GetDouble("TickleFrequency");
            TickleSize = si.GetDouble("TickleSize");
            TickleLength = si.GetDouble("TickleLength");
        }
        #endregion
        #region DESTRUCTORS
        #endregion
        #region DELEGATES
        #endregion
        #region EVENTS
        #endregion
        #region ENUMS
        #endregion
        #region INTERFACES
        #endregion
        #region PROPRERTIES
        public double TickleFrequency {get; set;}
        public double TickleSize { get; set;}
        public double TickleLength { get; set; }
        #endregion
        #region INDEXERS
        #endregion
        #region METHODS
        public virtual void GetObjectData(SerializationInfo si, StreamingContext sc)
        {
            si.AddValue("TickleFrequency", TickleFrequency);
            si.AddValue("TickleLength", TickleLength);
            si.AddValue("TickleSize", TickleSize);
        }
        #region EVENT HANDLERS
        #endregion
        #endregion
        #region STRUCTS
        #endregion
        #region CLASSES
        #endregion
    }
}

