using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

			Volumenstrom volumen = new Volumenstrom(delta_p, d, L, k, delta_h, rho, nu, zeta_zu);
			Console.WriteLine(volumen.value);
			Console.ReadLine();
		}
	}
}
