using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Gridsim
{
	class Marche
	{
		public float elecBuy { get; private set; }
		public float elecSell { get; private set; }
		public float CO2Cost { get; private set; }
		private readonly Random _random = new Random();


		public float RandomNumber(int min, int max)
		{
			return _random.Next(min, max);
		}
		public Marche()
		{
			this.elecBuy = RandomNumber(10, 25);
			this.elecSell = RandomNumber(7, 21);
			this.CO2Cost = RandomNumber(8, 15);
		}
	}
}
