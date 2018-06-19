using System;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var filters = new PhotoFilters();
            var processor = new PhotoProcessor();
            bool useCustomDelegate = false;

            if (useCustomDelegate)
            {
                #region Delegate Personalizado
                //Declara una instacia del delegate y agrega los diferentes filtros que quiere ejecutar
                PhotoProcessor.PhotoFilterHandler filterHandler = filters.ApplyBrightness;
                filterHandler += filters.ApplyContrast;
                filterHandler += RemoveRedEyeFilter;

                //Ejecuta los filtros
                processor.Process("photo.jpg", filterHandler);
                #endregion
            }
            else
            {
                #region Action
                //Declara un Action y agrega los diferentes filtros que quiere ejecutar
                Action<Photo> filterAction = filters.ApplyBrightness;
                filterAction += filters.ApplyContrast;
                filterAction += RemoveRedEyeFilter;

                //Ejecuta los filtros
                processor.ProcessAction("photo.jpg", filterAction);
                #endregion
            }            
        }

        //Crea un filtro fuera de la clase PhotoFilters, pero como respeta el signature del delegate, puede utilizarse sin problema
        static void RemoveRedEyeFilter(Photo photo)
        {
            Console.WriteLine("Apply RemoveRedEye");
        }
    }
}
