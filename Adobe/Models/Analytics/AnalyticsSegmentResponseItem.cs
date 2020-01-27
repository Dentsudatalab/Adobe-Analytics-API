namespace Adobe.Models.Analytics
{
    using System;
    using System.Collections.Generic;
    using General;
    using Newtonsoft.Json;
    using Utility;

    public class AnalyticsSegmentResponseItem
    {
        public static readonly AnalyticsSegmentResponseItemFields Fields = new AnalyticsSegmentResponseItemFields();

        /// <summary>
        /// Gets or sets id of the segment.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets a name for the segment.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a description of the segment.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the report suite id.
        /// </summary>
        [JsonProperty(PropertyName = "rsid")]
        public string Rsid { get; set; }

        /// <summary>
        /// Gets or sets the friendly name for the report suite id.
        /// </summary>
        [JsonProperty(PropertyName = "reportSuiteName")]
        public string ReportSuiteName { get; set; }

        /// <summary>
        /// Gets or sets the owner of the segment as an Owner object.
        /// </summary>
        [JsonProperty(PropertyName = "owner")]
        public Owner Owner { get; set; }

        /// <summary>
        /// Gets or sets the segment definition as a JSON object
        /// </summary>
        [JsonProperty(PropertyName = "definition")]
        public IDictionary<string, object> Definition { get; set; }

        /// <summary>
        /// Gets or sets analytics products that the segment is compatible with
        /// </summary>
        [JsonProperty(PropertyName = "compatibility")]
        public IDictionary<string, object> Compatibility { get; set; }

        [JsonProperty(PropertyName = "definitionLastModified")]
        public System.DateTime? DefinitionLastModified { get; set; }

        [JsonProperty(PropertyName = "categories")]
        public IList<string> Categories { get; set; }

        /// <summary>
        /// Gets or sets a name for the report suite.  This is deprecated and
        /// should use the report suite name instead.
        /// </summary>
        [JsonProperty(PropertyName = "siteTitle")]
        public string SiteTitle { get; set; }

        /// <summary>
        /// Gets or sets all existing tags associated with the segment.
        /// </summary>
        [JsonProperty(PropertyName = "tags")]
        public IList<Tag> Tags { get; set; }

        [JsonProperty(PropertyName = "modified")]
        public System.DateTime? Modified { get; set; }

        [JsonProperty(PropertyName = "created")]
        public System.DateTime? Created { get; set; }

        protected bool Equals(AnalyticsSegmentResponseItem other)
        {
            return Id == other.Id && Name == other.Name && Description == other.Description && Rsid == other.Rsid && ReportSuiteName == other.ReportSuiteName && Equals(Owner, other.Owner) && Nullable.Equals(DefinitionLastModified, other.DefinitionLastModified) && SiteTitle == other.SiteTitle && Nullable.Equals(Modified, other.Modified) && Nullable.Equals(Created, other.Created);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AnalyticsSegmentResponseItem)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Id != null ? Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Rsid != null ? Rsid.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ReportSuiteName != null ? ReportSuiteName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Owner != null ? Owner.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ DefinitionLastModified.GetHashCode();
                hashCode = (hashCode * 397) ^ (SiteTitle != null ? SiteTitle.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Modified.GetHashCode();
                hashCode = (hashCode * 397) ^ Created.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(AnalyticsSegmentResponseItem left, AnalyticsSegmentResponseItem right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AnalyticsSegmentResponseItem left, AnalyticsSegmentResponseItem right)
        {
            return !Equals(left, right);
        }
    }

    public class AnalyticsSegmentResponseItemFields : FieldsDescriptor
    {
        public Field ReportSuiteName { get; protected set; }

        public Field Modified { get; protected set; }

        public Field OwnerFullName { get; protected set; }

        public Field Tags { get; protected set; }

        public Field Compatibility { get; protected set; }

        public Field Definition { get; protected set; }

        public Field DefinitionLastModified { get; protected set; }

        public Field PublishingStatus { get; }

        public Field Categories { get; protected set; }

        public AnalyticsSegmentResponseItemFields() : this(null)
        {
        }

        public AnalyticsSegmentResponseItemFields(FieldsDescriptor parent) : base(parent, string.Empty)
        {
            OwnerFullName = new Field(null, "ownerFullName");
            PublishingStatus = new Field(null, "publishingStatus");
            MakeFields<AnalyticsSegmentResponseItem>();
        }
    }
}