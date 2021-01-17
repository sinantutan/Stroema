using Stroemung.Rohrreibung;
using System;

namespace Stroemung
{
	public class Volumenstrom
	{
		private const double g = 9.81F;

		public double value { get; }
		public double epsilon_lambda { get; set; } = 0.1;
		public double v { get; set; }
		public double lambda_0 { get; set; } = 0.02F;
		public double lambda { get; set; }
	
		public Volumenstrom() { }

		public Volumenstrom(double delta_p, double d, double L, double k, double delta_h, double rho, double nu, double zeta_zu)
		{
			lambda = iterate_lambda(delta_p, rho, delta_h, L, d, zeta_zu, nu, k);
			value = calcucate_Volumenstrom(rho, delta_h, lambda, L, d);
		}

		public double iterate_lambda(double delta_p, double rho, double delta_h, double L, double d, double zeta_zu, double nu, double k)
		{
			bool is_finished = false;
			int trials = 0;
			int max_trials = 1000;

			while(!is_finished)
			{
				v = calculate_v(delta_p, rho, delta_h, lambda_0, L, d, zeta_zu);
				lambda = new Rohrreibungsbeiwert(v, d, nu, k).value;

				if (calculate_Fehler(lambda) <= epsilon_lambda) is_finished = true;
				else lambda_0 = lambda; 

				if (trials >= max_trials) is_finished = true;
			}

			return lambda;
		} 

		public double calculate_v(double delta_p, double rho, double delta_h, double lambda, double L, double d, double zeta_zu)
		{
			return Math.Sqrt((delta_p - rho * g * delta_h) / (0.5 * rho * (lambda * L / d + zeta_zu)));
		}

		public double calculate_Fehler(double lambda)
		{
			return Math.Abs((lambda - lambda_0) / lambda);
		}

		public double calcucate_Volumenstrom(double rho, double delta_h, double lambda, double L, double d)
		{
			return Math.PI / 4d * Math.Pow(d, 2) * v;
		}
	}
}
