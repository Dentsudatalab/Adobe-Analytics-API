namespace Adobe.Models.General
{
    using System;

    using Enums;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    using Utility;

    [Serializable]
    public class SuiteCollectionItem
    {
        public static readonly SuiteCollectionItemFields Fields = new SuiteCollectionItemFields();

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets suite friendly timezone name
        /// </summary>
        [JsonProperty(PropertyName = "timezoneZoneinfo")]
        public string TimezoneZoneInfo { get; set; }

        /// <summary>
        /// Gets or sets parent report suite id for virtual report suite
        /// </summary>
        [JsonProperty(PropertyName = "parentRsid")]
        public string ParentRsid { get; set; }

        /// <summary>
        /// Gets or sets suite type. Possible values include: 'reportsuite',
        /// 'virtualreportsuite'
        /// </summary>
        [JsonProperty(PropertyName = "collectionItemType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CollectionItemType CollectionItemType { get; set; }

        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        [JsonProperty(PropertyName = "calendarType")]
        public CalendarType CalendarType { get; set; }

        [JsonProperty(PropertyName = "rsid")]
        public string Rsid { get; set; }

        protected bool Equals(SuiteCollectionItem other)
        {
            return Name == other.Name && TimezoneZoneInfo == other.TimezoneZoneInfo && ParentRsid == other.ParentRsid &&
                   CollectionItemType == other.CollectionItemType && Currency == other.Currency && Rsid == other.Rsid;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;

            return Equals((SuiteCollectionItem)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Name != null
                    ? Name.GetHashCode()
                    : 0;
                hashCode = (hashCode * 397) ^ (TimezoneZoneInfo != null
                    ? TimezoneZoneInfo.GetHashCode()
                    : 0);
                hashCode = (hashCode * 397) ^ (ParentRsid != null
                    ? ParentRsid.GetHashCode()
                    : 0);
                hashCode = (hashCode * 397) ^ (int)CollectionItemType;
                hashCode = (hashCode * 397) ^ (Currency != null
                    ? Currency.GetHashCode()
                    : 0);
                hashCode = (hashCode * 397) ^ (Rsid != null
                    ? Rsid.GetHashCode()
                    : 0);

                return hashCode;
            }
        }

        public static bool operator ==(SuiteCollectionItem left, SuiteCollectionItem right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SuiteCollectionItem left, SuiteCollectionItem right)
        {
            return !Equals(left, right);
        }
    }

    public class SuiteCollectionItemFields : FieldsDescriptor
    {
        public Field Name { get; protected set; }

        public Field TimezoneZoneInfo { get; protected set; }

        public Field ParentRsid { get; protected set; }

        public Field Currency { get; protected set; }

        public Field CalendarType { get; protected set; }

        public SuiteCollectionItemFields() : this(null)
        {
        }

        public SuiteCollectionItemFields(FieldsDescriptor parent) : base(parent, string.Empty)
        {
            MakeFields<SuiteCollectionItem>();
        }
    }
}
