using RainbowWords.XForms.Model;
using RainbowWords.XForms.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace RainbowWords.XForms.ViewModel
{
	public class MainPageViewModel : INotifyPropertyChanged
    {
		public event PropertyChangedEventHandler PropertyChanged;

		private static TypeConverter _colorConverter = new ColorTypeConverter();

		private WordPack _pack;
		private WordGroup[] _groups;
		private int _groupIndex = -1;
		private int _wordIndex = -1;

		public MainPageViewModel(WordPack pack = null)
		{
			if (pack == null)
				pack = WordPack.LoadDefault();
			SetWordPack(pack);
		}

		public WordPack CurrentPack => _pack;

		public IEnumerable<WordGroup> AllGroups => _groups == null ? new WordGroup[0] : _groups;

		public int CurrentGroupIndex => _groupIndex;

		public int CurrentWordIndex => _wordIndex;

		public WordGroup CurrentGroup
		{
			get
			{
				if (_groupIndex >= 0 && _groupIndex < _groups?.Length)
					return _groups[_groupIndex];
				return null;
			}
		}

		public Color CurrentGroupColor
		{
			get
			{
				Color c = Color.Default;
				var grpColor = CurrentGroup?.Color;

				try
				{
					if (!string.IsNullOrWhiteSpace(grpColor))
					{
						c = (Color)(new ColorTypeConverter()).ConvertFromInvariantString(grpColor);
					}
				}
				catch (Exception ex)
				{
					Debug.WriteLine("Failed to convert color: " + ex.ToString());
				}

				return c;
			}
		}

		public Color CurrentGroupTextColor
		{
			get
			{
				var c = CurrentGroupColor;
				return ColorUtil.IsLightColor(c.R, c.G, c.B)
						? Color.Black
						: Color.White;
			}
		}

		public Word CurrentWord
		{
			get
			{
				if (_wordIndex >= 0 && _wordIndex < CurrentGroup?.Words?.Length)
					return CurrentGroup.Words[_wordIndex];
				return null;
			}
		}

		public bool HasPrevWord
		{
			get
			{
				return _groups != null
						&& (_groupIndex > 0 || _wordIndex > 0);
			}
		}

		public bool HasNextWord
		{
			get
			{
				return _groups != null
						&& ((_groupIndex + 1) < _groups.Length
								|| (_wordIndex + 1) < CurrentGroup.Words.Length);
			}
		}

		public void SetWordPack(WordPack pack)
		{
			_groupIndex = -1;
			_wordIndex = -1;
			_groups = null;
			_pack = null;

			if (pack != null)
			{
				_pack = pack;
				// Pull out all non-empty groups
				_groups = pack.Groups.Where(x => x.Words.Length > 0).ToArray();

				if (_groups.Length > 0)
				{
					_groupIndex = 0;
					_wordIndex = 0;
				}
				else
					_groups = null;

			}

			RaiseCurrentGroupChanged();
			RaisePropertyChanged(nameof(AllGroups));
			RaisePropertyChanged(nameof(CurrentPack));
		}

		public void GotoGroup(string label)
		{
			int index = _groups
					.Select((x, y) => x.Label == label ? y : -1)
					.FirstOrDefault(x => x != -1);

			_groupIndex = index;
			_wordIndex = 0;
			RaiseCurrentGroupChanged();
		}

		public void FirstWord()
		{
			if (_groups == null)
				return;

			_groupIndex = -1;
			_wordIndex = -1;

			if (_groups?.Length > 0)
			{
				_groupIndex = 0;
				if (_groups[0].Words.Length > 0)
					_wordIndex = 0;
			}

			RaiseCurrentGroupChanged();
		}

		public void LastWord()
		{
			if (_groups == null)
				return;

			_groupIndex = _groups.Length - 1;
			_wordIndex = _groups[_groupIndex].Words.Length - 1;

			RaiseCurrentGroupChanged();
		}

		public void PrevWord()
		{
			if (_groups == null)
				return;

			if (_wordIndex > 0)
			{
				_wordIndex--;

				RaiseCurrentWordChanged();
			}
			else if (_groupIndex > 0)
			{
				_groupIndex--;
				_wordIndex = _groups[_groupIndex].Words.Length - 1;

				RaiseCurrentGroupChanged();
			}
		}

		public void NextWord()
		{
			if (_groups == null)
				return;

			if ((_wordIndex + 1) < _groups[_groupIndex].Words.Length)
			{
				_wordIndex++;

				RaiseCurrentWordChanged();
			}
			else if ((_groupIndex + 1) < _groups.Length)
			{
				_groupIndex++;
				_wordIndex = 0;

				RaiseCurrentGroupChanged();
			}
		}

		protected void RaiseCurrentGroupChanged()
		{
			RaisePropertyChanged(nameof(CurrentGroupIndex));
			RaisePropertyChanged(nameof(CurrentGroup));
			RaisePropertyChanged(nameof(CurrentGroupColor));
			RaisePropertyChanged(nameof(CurrentGroupTextColor));
			RaiseCurrentWordChanged();
		}

		protected void RaiseCurrentWordChanged()
		{
			RaisePropertyChanged(nameof(CurrentWordIndex));
			RaisePropertyChanged(nameof(CurrentWord));
			RaisePropertyChanged(nameof(HasPrevWord));
			RaisePropertyChanged(nameof(HasNextWord));
		}

		protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
				handler(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
