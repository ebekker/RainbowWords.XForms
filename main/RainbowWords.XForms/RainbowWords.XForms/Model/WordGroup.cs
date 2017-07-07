using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowWords.XForms.Model
{
    public class WordGroup
    {
		public string Label
		{ get; set; }

		public string Color
		{ get; set; }

		public Word[] Words
		{ get; set; }
    }
}
