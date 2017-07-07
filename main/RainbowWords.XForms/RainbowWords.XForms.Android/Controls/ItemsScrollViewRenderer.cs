using RainbowWords.XForms.Controls;
using RainbowWords.XForms.Droid.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ItemsScrollView), typeof(ItemsScrollViewRenderer))]

namespace RainbowWords.XForms.Droid.Controls
{
	public class ItemsScrollViewRenderer : ScrollViewRenderer
	{
		protected override void OnElementChanged(VisualElementChangedEventArgs e)
		{
			base.OnElementChanged(e);

			(e.NewElement as ItemsScrollView)?.Render();
		}
	}
}