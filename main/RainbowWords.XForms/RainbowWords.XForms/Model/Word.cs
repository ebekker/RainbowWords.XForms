using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowWords.XForms.Model
{
    public class Word
    {
		public Word(string value, string phonetic = null)
		{
			Value = value;
			Phonetic = phonetic;
		}

		public string Value
		{ get; set; }

		public string Phonetic
		{ get; set; }
    }
}
