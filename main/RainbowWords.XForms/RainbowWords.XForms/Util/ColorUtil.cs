using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowWords.XForms.Util
{
	public static class ColorUtil
	{
		/// <summary>
		/// Determines if RGB combination is a relatively <i>light</i>
		/// color.
		/// </summary>
		/// <remarks>
		/// Thanks to:
		/// * https://stackoverflow.com/questions/1855884/determine-font-color-based-on-background-color
		/// * https://codepen.io/WebSeed/pen/pvgqEq
		/// </remarks>
		public static bool IsLightColor(double r, double g, double b)
		{
			// Counting the perceptive luminance
			// human eye favors green color... 
			var a = 1 - (0.299 * r + 0.587 * g + 0.114 * b);
			return (a < 0.5);
		}

		/// <summary>
		/// Determines if RGB combination is a relatively <i>light</i>
		/// color.
		/// </summary>
		/// <remarks>
		/// Thanks to:
		/// * https://stackoverflow.com/questions/1855884/determine-font-color-based-on-background-color
		/// * https://codepen.io/WebSeed/pen/pvgqEq
		/// </remarks>
		public static bool IsLightColor(int r, int g, int b)
		{
			// Counting the perceptive luminance
			// human eye favors green color... 
			var a = 1 - (0.299 * r + 0.587 * g + 0.114 * b) / 255;
			return (a < 0.5);
		}
	}
}
