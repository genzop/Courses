namespace Generics
{
    //Ejemplo de clase génerica con una restricción a tipos de datos primitivos
    public class Nullable<T> where T : struct
    {
        private object _value;

        public Nullable() { }
        public Nullable(T value)
        {
            _value = value;
        }

        public bool HasValue
        {
            get { return _value != null; }
        }

        public T GetValueOrDefault()
        {
            if (HasValue)
                return (T)_value;

            return default(T);
        }
    }
}
