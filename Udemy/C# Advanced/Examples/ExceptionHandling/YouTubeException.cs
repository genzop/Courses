using System;

namespace ExceptionHandling
{
    // Ejemplo de excepcion personalizada
    public class YouTubeException : Exception
    {
        // Constructor que recibe un mensaje para la excepcion y una excepcion que se guardara como inner exception
        public YouTubeException(string message, Exception innerException) : base(message, innerException) {  }
    }
}
