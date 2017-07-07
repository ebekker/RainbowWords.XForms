using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RainbowWords.XForms.Model
{
    public class WordPack
    {
		public string Name
		{ get; set; }

		public string Label
		{ get; set; }

		public WordGroup[] Groups
		{ get; set; }

		private static WordPack _default;

		public static WordPack LoadDefault()
		{
			if (_default == null)
			{
				var res = $"{typeof(WordPack).Namespace}.DEFAULT.wpk.json";
				var asm = typeof(WordPack).GetTypeInfo().Assembly;
				using (var stm = asm.GetManifestResourceStream(res))
				using (var rdr = new StreamReader(stm))
				{
					_default = JsonConvert.DeserializeObject<WordPack>(rdr.ReadToEnd());
				}
			}
			return _default;
		}
	}
}
