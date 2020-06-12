using System;
using System.Globalization;
using Newtonsoft.Json;

namespace SmartHunter.Core.Config
{
    public class StringFloatConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(float);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var floatValue = (float)value;            
            writer.WriteRawValue(floatValue.ToString("0.##", CultureInfo.InvariantCulture));
        }

        public override bool CanRead
        {
            get
            {
                return false;
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
