using System;
using Stroemung;

namespace StroemungTest
{
	class Program
	{
		static void Main(string[] args)
		{
			double delta_p = 1543000 ; //bar
			double d = 0.0254; //m
			double L = 400; //m
			double k = 0.000015; //mikro m
			double delta_h = 20; //m
			double rho = 1000; //kg/m^3
			double nu = 0.000001; //-
			double zeta_zu = 0.5; //-
			double V = 5.47 / 3600; //m^3/s

			Volumenstrom volumen = new Volumenstrom(delta_p, d, L, k, delta_h, rho, nu, zeta_zu);
			Console.WriteLine(volumen.value);

			Rohrdurchmesser rohrduchmesser = new Rohrdurchmesser(delta_p, V, L, k, delta_h, rho, nu, zeta_zu);

			Console.WriteLine("ICH HABE FERTITG");
			Console.WriteLine(rohrduchmesser.v + " " + rohrduchmesser.d);
			Console.ReadLine();
		}
	}
}
