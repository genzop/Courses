using System;

namespace Generics
{
    public class Utilities
    {
        //Ejemplo de método genérico con una restriccion de Interfaz
        public T Max<T>(T a, T b) where T : IComparable
        {            
            return a.CompareTo(b) > 0 ? a : b;
        }
    }

    //Ejemplo de clase genérica con una restriccion de Interfaz y que permite crear nuevas instancias del objeto
    public class Utilities<T> where T : IComparable, new()
    {
        public T Max(T a, T b) 
        {
            return a.CompareTo(b) > 0 ? a : b;
        }

        public void DoSomething(T value)
        {
            var obj = new T();
        }
    }
}
