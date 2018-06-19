using System;

namespace Events
{
    public class MessageService
    {
        // 3 - Define un método que comparte el signature con el EventHandler 
        public void OnVideoEncoded(object source, VideoEventArgs args)
        {
            Console.WriteLine("MessageService: Sending a text message... " + args.Video.Title);
        }
    }
}
