using System;

namespace Events
{
    public class MailService
    {
        // 3 - Define un método que comparte el signature con el EventHandler 
        public void OnVideoEncoded(object source, VideoEventArgs args)
        {
            Console.WriteLine("MailService: Sending an email... " + args.Video.Title);
        }
    }
}
