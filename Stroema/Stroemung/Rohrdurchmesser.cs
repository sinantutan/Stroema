using Stroemung.Rohrreibung;
using System;

namespace Stroemung
{
	public class Rohrdurchmesser
	{
		private const double g = 9.81;

		private double epsilon_d { get; set; } = 0.05;
		private double epsilon_lambda { get; set; } = 0.05;

		private double lambda_0 { get; set; } = 0.02;
		private double lambda { get; set; }

		private double d_0 { get; set; }
		public double d { get; set; }

		public double v { get; set; }

		public Rohrdurchmesser() { }
		public Rohrdurchmesser(double delta_p, double V, double L, double k, double delta_h, double rho, double nu, double zeta_zu ) 
		{
			d_0 = calculate_d_0(rho, V, lambda_0, L, delta_p, delta_h);

			iterate_lambda(rho, V, L, delta_p, delta_h, zeta_zu, nu, k);
		}

		public void iterate_lambda(double rho, double V, double L, double delta_p, double delta_h, double zeta_zu, double nu, double k)
		{
			bool is_finished = false;
			double lambda = 0;
			int trials = 0;
			int max_trials = 1000;

			while(!is_finished)
			{
				d = iterate_d(rho, V, L, delta_p, delta_h, zeta_zu, lambda_0);
				v = calculate_v(V, d);

				lambda = new Rohrreibungsbeiwert(v, d, nu, k).value;


				if (calculate_error_lambda(lambda, lambda_0) >= epsilon_lambda) lambda_0 = lambda;
				else is_finished = true;

				if (trials >= max_trials) is_finished = true;
				trials++;
			}
		}

		public double iterate_d(double rho, double V, double L, double delta_p, double delta_h, double zeta_zu, double lambda)
		{
			bool is_finished = false;
			double d = 0;
			int trials = 0;
			int max_trials = 1000;

			while (!is_finished)
			{
				d = calculate_d(rho, V, lambda, L, delta_p, delta_h, zeta_zu);

				if (calculate_error_d(d, d_0) >= epsilon_d) d_0 = d;
				else is_finished = true;

				if (trials >= max_trials) is_finished = true;
				trials++;
			}

			return d;
		}

		public double calculate_v(double V, double d)
		{
			return 4d * V / Math.PI / Math.Pow(d, 2);
		}

		public double calculate_d_0(double rho, double V, double lambda, double L, double delta_p, double delta_h)
		{
			double a = 8 / Math.Pow(Math.PI, 2);
			double b = rho * Math.Pow(V, 2) * lambda * L / (delta_p - rho * g * delta_h);
			double c = Math.Pow(a * b, 1d / 5d);
			return c;
		}

		public double calculate_d(double rho, double V, double lambda, double L, double delta_p, double delta_h, double zeta_zu)
		{
			return Math.Pow(8 / Math.Pow(Math.PI, 2) * rho * Math.Pow(V, 2) * (lambda * L + zeta_zu * d_0) / (delta_p - rho * g * delta_h), (1d/5d));
		}

		public double calculate_error_d(double d, double d_0)
		{
			return Math.Abs((d - d_0) / d);
		}

		public double calculate_error_lambda(double lambda, double lambda_0)
		{
			return Math.Abs((lambda - lambda_0) / lambda);
		}
	}
}
