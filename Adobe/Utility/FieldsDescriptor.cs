namespace Adobe.Utility
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using Newtonsoft.Json;

    public class FieldsDescriptor
    {
        private readonly FieldsDescriptor _parent;

        private readonly string _name;

        public FieldsDescriptor(string name)
        {
            _name = name;
        }

        public FieldsDescriptor(FieldsDescriptor parent, string name)
        {
            _parent = parent;
            _name = name;
        }

        public string ClassName
        {
            get
            {
                if (_parent?._parent == null)
                    return _name;

                return string.Join(".", _parent.ClassName, _name);
            }
        }

        protected void MakeFields<TModelType>()
        {
            var fieldType = typeof(Field);

            var modelProperties = typeof(TModelType).GetProperties();
            var ownProperties = GetType()
                .GetProperties()
                .Where(e => fieldType.IsAssignableFrom(e.PropertyType));

            foreach (var ownProperty in ownProperties)
            {
                var ownPropName = ownProperty.Name;
                var matchingProperty = modelProperties.FirstOrDefault(e => e.Name == ownPropName);

                if (matchingProperty == null)
                    continue;

                // Get JSON Attribute value
                var jsonProp =
                    matchingProperty.GetCustomAttribute(typeof(JsonPropertyAttribute)) as JsonPropertyAttribute;
                var jsonPropName = jsonProp?.PropertyName;

                var field = MakeField(jsonPropName);
                ownProperty.SetValue(this, field);
            }
        }

        private Field ToField()
        {
            return new Field(this, _name);
        }

        public IEnumerable<Field> All
        {
            get
            {
                var type = GetType();
                var fieldType = typeof(Field);
                var fieldDescriptorType = typeof(FieldsDescriptor);

                var properties = type.GetProperties();

                var fieldProperties = properties.Where(e => fieldType.IsAssignableFrom(e.PropertyType));
                var fieldDescriptorProperties = properties
                    .Where(e => fieldDescriptorType.IsAssignableFrom(e.PropertyType))
                    .ToList();

                var fieldValues = fieldProperties.Select(e => e.GetValue(this) as Field);
                var fieldDescriptorValues =
                    fieldDescriptorProperties.SelectMany(e => ((FieldsDescriptor)e.GetValue(this)).All);

                var fields = fieldValues
                    .Concat(fieldDescriptorValues);

                return fields;
            }
        }

        protected Field MakeField(string name)
        {
            if (_parent == null)
                return new Field(_parent, name);

            return new Field(this, name);
        }

        protected bool Equals(FieldsDescriptor other)
        {
            return Equals(_parent, other._parent) && _name == other._name;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;

            return Equals((FieldsDescriptor)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_parent != null
                    ? _parent.GetHashCode()
                    : 0) * 397) ^ (_name != null
                    ? _name.GetHashCode()
                    : 0);
            }
        }

        public static bool operator ==(FieldsDescriptor left, FieldsDescriptor right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(FieldsDescriptor left, FieldsDescriptor right)
        {
            return !Equals(left, right);
        }
    }
}
