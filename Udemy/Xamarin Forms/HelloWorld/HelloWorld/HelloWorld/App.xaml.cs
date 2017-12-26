using HelloWorld.Lists;
using HelloWorld.Navigation;
using HelloWorld.Navigation.HierarchicalNavigation;
using HelloWorld.Navigation.ModalPages;
using HelloWorld.Navigation.SimpleMasterDetail;
using HelloWorld.Navigation.MasterDetail;
using HelloWorld.Navigation.TabbedPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace HelloWorld
{
	public partial class App : Application
	{
        public App()
        {
            InitializeComponent();

            MainPage = new Navigation.Exercise.MainPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
