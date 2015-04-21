using System;

namespace WpfIntro
{
	public class ObiektDanych
	{
		public string Nazwa { get; set; }

		public int Identyfikator { get; set; }

		public DateTime Data { get; set; }

		public bool CzyAktywny { get; set; }

		public override string ToString()
		{
			return Nazwa;
		}
	}
}
