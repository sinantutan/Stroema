using System;

namespace Stroemung.Rohrreibung
{
	public enum Rohrstroemung { laminar, turbulent }
	public enum Hyd_Rauheit { glatt, uebergang, rauh }

	class Rohrreibungsbeiwert
	{

		public ReynoldsZahl Re { get; }

		public double value { get; }

		public Rohrreibungsbeiwert() { }

		public Rohrreibungsbeiwert(double v, double d, double nu, double k) {
			value = calculate(new ReynoldsZahl(v, d, nu), k, d);
		}

		public Rohrreibungsbeiwert(double rho, double v, double d, double eta, double k) { 
			value = calculate( new ReynoldsZahl(rho, v, d, eta), k, d); 
		}

		public Rohrstroemung rohrstroemung(ReynoldsZahl Re) { 
			return Re.value >= 2320 ? Rohrstroemung.turbulent : Rohrstroemung.laminar; 
		}

		public Hyd_Rauheit hydraulische_Rauheit(ReynoldsZahl Re, double k, double d) {
			var temp = Math.Pow(Re.value, (double)7/8) * k / d;

			if (temp <= 5) return Hyd_Rauheit.glatt;
			else if (temp <= 225) return Hyd_Rauheit.uebergang;
			
			return Hyd_Rauheit.rauh;
		}

		public double calculate(ReynoldsZahl Re, double k, double d) {
			double value = 0;

			if(rohrstroemung(Re) == Rohrstroemung.laminar) value = 64 / Re.value;

			else /*Rohrstroemung.turbulent*/ {
				if (hydraulische_Rauheit(Re, k, d) == Hyd_Rauheit.glatt)
				{
                    if (Re.value > Math.Pow(10, 5))
                    {
                        value = calculate_Hermann(Re);
                        Console.WriteLine("calculated with Hermann" + value);
					}
                    else
                    {
                        value = calculate_Blasius(Re);
                        Console.WriteLine("calculated with Blasius" + value);
					}
                    
				}
				else if (hydraulische_Rauheit(Re, k, d) == Hyd_Rauheit.uebergang)
				{
					value = calculate_Pham(k, d, Re);
                    Console.WriteLine("calculated with Pham" + value);
                }
                else
                {

                    value = calculate_Nikuradse(k, d, Re);
                    Console.WriteLine("calculated with Niku" + value);
				}
			}
			return value;
		}

		private double calculate_Hermann(ReynoldsZahl Re) { return 0.0032 + 0.221 * Math.Pow(Re.value, -0.237d);  }
		private double calculate_Blasius(ReynoldsZahl Re) { return 0.3164 / Math.Pow(Re.value,(double) 1 / 4); }
		private double calculate_Pham(double k, double d, ReynoldsZahl Re) { return Math.Pow(-2d * Math.Log10(k / 3.7 / d - 4.52 / Re.value * Math.Log10(7 / Re.value + k / 7 / d)), (double)-2); }
		private double calculate_Nikuradse(double k, double d, ReynoldsZahl Re) { return Math.Pow(2 * Math.Log10(d/k) + 1.138,-2);  }

	}
}
