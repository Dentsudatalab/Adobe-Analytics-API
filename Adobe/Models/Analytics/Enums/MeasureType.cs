// ReSharper disable InconsistentNaming
namespace Adobe.Models.Analytics.Enums
{
    using System;

    using Newtonsoft.Json;

    [Serializable]
    public enum MeasureType
    {
        STRING,
        INT,
        DECIMAL,
        CURRENCY,
        PERCENT,
        TIME,
        ENUM,
        ORDERED_ENUM
    }

    public class MeasureTypeConverter : JsonConverter
    {
        public override bool CanRead => true;

        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var convertedValue = value is MeasureType type
                ? type
                : MeasureType.STRING;

            switch (convertedValue)
            {
                case MeasureType.ORDERED_ENUM:
                    writer.WriteValue("ordered-enum");

                    break;

                default:
                    writer.WriteValue(
                        convertedValue.ToString()
                            .ToLowerInvariant());

                    break;
            }
        }

        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            var type = reader.Value as string ?? string.Empty;

            switch (type.ToLowerInvariant())
            {
                case "ordered-enum":
                    return MeasureType.ORDERED_ENUM;

                default:
                    var isParsed = Enum.TryParse(type, out MeasureType parsed);

                    return isParsed
                        ? parsed
                        : MeasureType.STRING;
            }
        }
    }
}
