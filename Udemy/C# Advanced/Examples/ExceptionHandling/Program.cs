using System;
using System.IO;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Ejemplo 1
            try
            {
                Calculator calculator = new Calculator();
                int result = calculator.Divide(5, 0);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("You cannot divide by 0.");
            }
            catch (ArithmeticException) { }
            catch (Exception ex)
            {
                Console.WriteLine("Sorry, an unexpected error ocurred.");
            }
            finally { }
            #endregion

            #region Ejemplo 2            
            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(@"C:\Dev\Temp\1.zip");
                var content = streamReader.ReadToEnd();
            }
            catch (Exception)
            {
                Console.WriteLine("Sorry, an unexpected error occurred.");
            }
            finally
            {
                if(streamReader != null)
                    streamReader.Dispose();
            }
            #endregion

            #region Ejemplo 3
            try
            {
                using (var streamReader2 = new StreamReader(@"C:\Dev\Temp\1.zip"))
                {
                    var content = streamReader2.ReadToEnd();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Sorry, an unexpected error occurred.");
            }
            #endregion

            #region Ejemplo 4
            try
            {
                var api = new YoutubeApi();
                api.GetVideos("Enzo");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion
        }
    }
}
