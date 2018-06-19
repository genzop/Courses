namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            var video = new Video() { Title = "Video 1" };                       
            var videoEncoder = new VideoEncoder();
            var mailService = new MailService();        
            var messageService = new MessageService();

            // 4 - Suscribir esos métodos al EventHandler
            videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
            videoEncoder.VideoEncoded += messageService.OnVideoEncoded;

            // 5 - Ejecutar el metodo
            videoEncoder.Encode(video);
        }
    }
}
