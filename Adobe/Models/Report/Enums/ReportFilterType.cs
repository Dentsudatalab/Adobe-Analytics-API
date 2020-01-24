// ReSharper disable InconsistentNaming
namespace Adobe.Models.Report.Enums
{
    using System;
    using Newtonsoft.Json;

    public enum ReportFilterType
    {
        DATE_RANGE,
        BREAKDOWN,
        SEGMENT,
        EXCLUDE_ITEM_IDS
    }

    public class ReportFilterTypeConverter : JsonConverter
    {
        public override bool CanRead => true;

        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var convertedValue = value is ReportFilterType type ? type : ReportFilterType.DATE_RANGE;

            switch (convertedValue)
            {
                case ReportFilterType.DATE_RANGE:
                    writer.WriteValue("dateRange");
                    break;

                case ReportFilterType.EXCLUDE_ITEM_IDS:
                    writer.WriteValue("excludeItemIds");
                    break;

                default:
                    writer.WriteValue(convertedValue.ToString().ToLowerInvariant());
                    break;
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var type = reader.Value as string ?? string.Empty;

            switch (type.ToLowerInvariant())
            {
                case "dateRange":
                    return ReportFilterType.DATE_RANGE;

                case "excludeItemIds":
                    return ReportFilterType.EXCLUDE_ITEM_IDS;

                default:
                    var isParsed = Enum.TryParse(type, out ReportFilterType parsed);
                    return isParsed ? parsed : ReportFilterType.DATE_RANGE;
            }
        }
    }
}