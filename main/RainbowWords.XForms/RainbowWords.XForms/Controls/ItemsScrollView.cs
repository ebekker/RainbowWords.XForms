using System.Collections;
using Xamarin.Forms;

namespace RainbowWords.XForms.Controls
{
	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// Adapted from:
	/// http://www.fabiocozzolino.eu/a-little-and-simple-bindable-horizontal-scroll-view/
	/// </remarks>
	public class ItemsScrollView : ScrollView
	{
		public static readonly BindableProperty ItemsSourceProperty =
				BindableProperty.Create("ItemsSource", typeof(IEnumerable), typeof(ItemsScrollView), default(IEnumerable));

		public IEnumerable ItemsSource
		{
			get { return (IEnumerable)GetValue(ItemsSourceProperty); }
			set { SetValue(ItemsSourceProperty, value); }
		}

		public static readonly BindableProperty ItemTemplateProperty =
			BindableProperty.Create("ItemTemplate", typeof(DataTemplate), typeof(ItemsScrollView), default(DataTemplate));

		public DataTemplate ItemTemplate
		{
			get { return (DataTemplate)GetValue(ItemTemplateProperty); }
			set { SetValue(ItemTemplateProperty, value); }
		}

		public void Render()
		{
			if (this.ItemTemplate == null || this.ItemsSource == null)
				return;

			var layout = new StackLayout();
			layout.Orientation = this.Orientation == ScrollOrientation.Vertical
				? StackOrientation.Vertical : StackOrientation.Horizontal;

			foreach (var item in this.ItemsSource)
			{
				var viewCell = this.ItemTemplate.CreateContent() as ViewCell;
				viewCell.View.BindingContext = item;
				layout.Children.Add(viewCell.View);
			}

			this.Content = layout;
		}
	}
}
