namespace Adobe.Models.Analytics
{
    using System;
    using System.Collections.Generic;

    using Enums;

    using General;

    using Newtonsoft.Json;

    using Utility;

    [Serializable]
    public class AnalyticsDimension
    {
        public static readonly AnalyticsDimensionFields Fields = new AnalyticsDimensionFields();

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

        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }

        [JsonProperty(PropertyName = "categories")]
        public IList<string> Categories { get; set; }

        [JsonProperty(PropertyName = "support")]
        public IList<string> Support { get; set; }

        [JsonProperty(PropertyName = "pathable")]
        public bool? Pathable { get; set; }

        [JsonProperty(PropertyName = "parent")]
        public string Parent { get; set; }

        [JsonProperty(PropertyName = "extraTitleInfo")]
        public string ExtraTitleInfo { get; set; }

        [JsonProperty(PropertyName = "segmentable")]
        public bool? Segmentable { get; set; }

        [JsonProperty(PropertyName = "reportable")]
        public IList<string> Reportable { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "allowedForReporting")]
        public bool? AllowedForReporting { get; set; }

        [JsonProperty(PropertyName = "noneSettings")]
        public NoneSettings NoneSettings { get; set; }

        [JsonProperty(PropertyName = "tags")]
        public IList<Tag> Tags { get; set; }

        protected bool Equals(AnalyticsDimension other)
        {
            return Id == other.Id && Title == other.Title && Name == other.Name && Type == other.Type &&
                   Category == other.Category && Pathable == other.Pathable && Parent == other.Parent &&
                   ExtraTitleInfo == other.ExtraTitleInfo && Segmentable == other.Segmentable &&
                   Description == other.Description && AllowedForReporting == other.AllowedForReporting;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;

            return Equals((AnalyticsDimension)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id != null
                    ? Id.GetHashCode()
                    : 0;
                hashCode = (hashCode * 397) ^ (Title != null
                    ? Title.GetHashCode()
                    : 0);
                hashCode = (hashCode * 397) ^ (Name != null
                    ? Name.GetHashCode()
                    : 0);
                hashCode = (hashCode * 397) ^ (int)Type;
                hashCode = (hashCode * 397) ^ (Category != null
                    ? Category.GetHashCode()
                    : 0);
                hashCode = (hashCode * 397) ^ Pathable.GetHashCode();
                hashCode = (hashCode * 397) ^ (Parent != null
                    ? Parent.GetHashCode()
                    : 0);
                hashCode = (hashCode * 397) ^ (ExtraTitleInfo != null
                    ? ExtraTitleInfo.GetHashCode()
                    : 0);
                hashCode = (hashCode * 397) ^ Segmentable.GetHashCode();
                hashCode = (hashCode * 397) ^ (Description != null
                    ? Description.GetHashCode()
                    : 0);
                hashCode = (hashCode * 397) ^ AllowedForReporting.GetHashCode();

                return hashCode;
            }
        }

        public static bool operator ==(AnalyticsDimension left, AnalyticsDimension right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AnalyticsDimension left, AnalyticsDimension right)
        {
            return !Equals(left, right);
        }
    }

    public class AnalyticsDimensionFields : FieldsDescriptor
    {
        public Field Tags { get; protected set; }

        public Field AllowedForReporting { get; protected set; }

        public Field Categories { get; protected set; }

        public AnalyticsDimensionFields() : this(null)
        {
        }

        public AnalyticsDimensionFields(FieldsDescriptor parent) : base(parent, string.Empty)
        {
            MakeFields<AnalyticsDimension>();
        }
    }
}
