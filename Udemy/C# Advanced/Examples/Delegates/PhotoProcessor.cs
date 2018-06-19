using System;

namespace Delegates
{
    public class PhotoProcessor
    {
        /* 
         * Declara un delegate personalizado que se utilizara para acceder a los filtros de la foto. 
         * Este delefate podra acceder a todos los metodos que compartan el mismo signature 
         */         
        public delegate void PhotoFilterHandler(Photo photo);

        //Recibe como parametro un directorio y el delegate personalizado
        public void Process(string path, PhotoFilterHandler filterHandler)
        {
            var photo = Photo.Load(path);

            //El delegate ejecuta los filtros  
            filterHandler(photo);                       

            photo.Save();
        }

        //Recibe como parametro un directorio y un Action que recibe una foto como parametro
        public void ProcessAction(string path, Action<Photo> action)
        {
            var photo = Photo.Load(path);

            //El Action ejecuta los filtros  
            action(photo);

            photo.Save();
        }
    }
}