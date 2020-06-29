namespace Adobe.Utility
{
    public class Field
    {
        private readonly string _name;

        private readonly FieldsDescriptor _parent;

        public Field(FieldsDescriptor parent, string name)
        {
            _name = name;
            _parent = parent;
        }

        public string Name
        {
            get
            {
                if (_parent == null)
                    return _name;

                return string.Join(".", _parent.ClassName, _name);
            }
        }

        public override string ToString()
        {
            return Name;
        }

        protected bool Equals(Field other)
        {
            return _name == other._name && Equals(_parent, other._parent);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;

            return Equals((Field)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_name != null
                    ? _name.GetHashCode()
                    : 0) * 397) ^ (_parent != null
                    ? _parent.GetHashCode()
                    : 0);
            }
        }

        public static bool operator ==(Field left, Field right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Field left, Field right)
        {
            return !Equals(left, right);
        }
    }
}
