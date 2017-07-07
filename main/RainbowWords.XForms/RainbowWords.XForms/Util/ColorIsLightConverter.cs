using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RainbowWords.XForms.Util
{
	public class ColorIsLightConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			Color c;
			if (value is Color)
				c = (Color)value;
			else
				c = (Color)new ColorTypeConverter().ConvertFromInvariantString(value.ToString());

			var s = (string)parameter;
			var lightDark = s.Split(';');
			if (ColorUtil.IsLightColor(c.R, c.G, c.B))
				return Color.FromHex(lightDark[0]);
			else
				return Color.FromHex(lightDark[1]);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
