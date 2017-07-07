using RainbowWords.XForms.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RainbowWords.XForms
{
	public partial class MainPage : ContentPage
	{
		private MainPageViewModel _vm;

		public MainPage()
		{
			_vm = new MainPageViewModel();
			BindingContext = _vm;

			InitializeComponent();
		}

		private void PrevButton_Clicked(object sender, EventArgs e)
		{
			_vm.PrevWord();
		}

		private void NextButton_Clicked(object sender, EventArgs e)
		{
			_vm.NextWord();
		}

		private void SayButton_Clicked(object sender, EventArgs e)
		{
		}

		private void FirstButton_Clicked(object sender, EventArgs e)
		{
			_vm.FirstWord();
		}

		private void LastButton_Clicked(object sender, EventArgs e)
		{
			_vm.LastWord();
		}

		private void GroupButton_Clicked(object sender, EventArgs e)
		{
			var b = (Button)sender;
			var bText = b.Text;

			if (bText == _vm.CurrentGroup?.Label)
				return;

			_vm.GotoGroup(bText);
		}
	}
}
