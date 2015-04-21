using System;
using System.Collections.Generic;

namespace WpfIntro
{
	public static class Generator
	{
		public static List<ObiektDanych> ObiektyDanych
		{
			get
			{
				return new List<ObiektDanych>
				{
					new ObiektDanych { Nazwa = "Obiekt A", Identyfikator = 101, Data = new DateTime(2015, 4, 10), CzyAktywny = true },
					new ObiektDanych { Nazwa = "Obiekt B", Identyfikator = 202, Data = new DateTime(2015, 4, 12), CzyAktywny = false },
					new ObiektDanych { Nazwa = "Obiekt C", Identyfikator = 303, Data = new DateTime(2015, 4, 14), CzyAktywny = true },
					new ObiektDanych { Nazwa = "Obiekt D", Identyfikator = 404, Data = new DateTime(2015, 4, 16), CzyAktywny = false }
				};
			}
		}
	}
}
