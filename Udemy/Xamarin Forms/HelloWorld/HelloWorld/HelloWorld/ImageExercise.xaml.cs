using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ImageExercise : ContentPage
	{
		public ImageExercise ()
		{
			InitializeComponent ();
            img.Source = new UriImageSource
            {
                CachingEnabled = false,
                Uri = new Uri("https://placeimg.com/1920/1080/nature")
            };            
		}

        private void ChangeImage(object sender, EventArgs e)
        {
            img.Source = new UriImageSource
            {
                CachingEnabled = false,
                Uri = new Uri("https://placeimg.com/1920/1080/nature")
            };
        }
	}
}