namespace Adobe.Models.Analytics
{
    using System.Collections.Generic;
    using Enums;
    using General;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Utility;

    public class AnalyticsMetric
    {
        public static readonly AnalyticsMetricFields Fields = new AnalyticsMetricFields();

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'STRING', 'INT', 'DECIMAL',
        /// 'CURRENCY', 'PERCENT', 'TIME', 'ENUM', 'ORDERED_ENUM'
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof(MeasureTypeConverter))]
        public MeasureType Type { get; set; }

        [JsonProperty(PropertyName = "extraTitleInfo")]
        public string ExtraTitleInfo { get; set; }

        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }

        [JsonProperty(PropertyName = "categories")]
        public IList<string> Categories { get; set; }

        [JsonProperty(PropertyName = "support")]
        public IList<string> Support { get; set; }

        [JsonProperty(PropertyName = "allocation")]
        public bool? Allocation { get; set; }

        [JsonProperty(PropertyName = "precision")]
        public int? Precision { get; set; }

        [JsonProperty(PropertyName = "calculated")]
        public bool? Calculated { get; set; }

        [JsonProperty(PropertyName = "segmentable")]
        public bool? Segmentable { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'positive', 'negative'
        /// </summary>
        [JsonProperty(PropertyName = "polarity")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PolarityType Polarity { get; set; }

        [JsonProperty(PropertyName = "helpLink")]
        public string HelpLink { get; set; }

        [JsonProperty(PropertyName = "allowedForReporting")]
        public bool? AllowedForReporting { get; set; }

        [JsonProperty(PropertyName = "tags")]
        public IList<Tag> Tags { get; set; }

        protected bool Equals(AnalyticsMetric other)
        {
            return Id == other.Id && Title == other.Title && Name == other.Name && Type == other.Type && ExtraTitleInfo == other.ExtraTitleInfo && Category == other.Category && Allocation == other.Allocation && Precision == other.Precision && Calculated == other.Calculated && Segmentable == other.Segmentable && Description == other.Description && Polarity == other.Polarity && HelpLink == other.HelpLink && AllowedForReporting == other.AllowedForReporting;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AnalyticsMetric)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Id != null ? Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Title != null ? Title.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int)Type;
                hashCode = (hashCode * 397) ^ (ExtraTitleInfo != null ? ExtraTitleInfo.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Category != null ? Category.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Allocation.GetHashCode();
                hashCode = (hashCode * 397) ^ Precision.GetHashCode();
                hashCode = (hashCode * 397) ^ Calculated.GetHashCode();
                hashCode = (hashCode * 397) ^ Segmentable.GetHashCode();
                hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int)Polarity;
                hashCode = (hashCode * 397) ^ (HelpLink != null ? HelpLink.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ AllowedForReporting.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(AnalyticsMetric left, AnalyticsMetric right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AnalyticsMetric left, AnalyticsMetric right)
        {
            return !Equals(left, right);
        }
    }

    public class AnalyticsMetricFields : FieldsDescriptor
    {
        public Field Tags { get; protected set; }

        public Field AllowedForReporting { get; protected set; }

        public Field Categories { get; protected set; }

        public AnalyticsMetricFields() : this(null)
        {
        }

        public AnalyticsMetricFields(FieldsDescriptor parent) : base(parent, string.Empty)
        {
            MakeFields<AnalyticsMetric>();
        }
    }
}