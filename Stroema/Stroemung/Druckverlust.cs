using Stroemung.Rohrreibung;
using System;

namespace Stroemung
{
	public class Druckverlust
	{
		private const double g = 9.81;

		private double v { get; }

		private Rohrreibungsbeiwert lambda { get; }

		public double value { get; }

		Druckverlust() {}
		
		public Druckverlust(
			double V, double d, double L, double k, double delta_h, double rho, double nu, double zeta_zu)
		{
			v = calculate_Geschwindigkeit(V, d);
			lambda = new Rohrreibungsbeiwert(v, d, nu, k);
			value = calculate_Druckverlust(rho, g, delta_h, lambda.value, L, d, zeta_zu, v);
            
        }

		public double calculate_Geschwindigkeit(double V, double d) { return 4 * V / Math.PI / Math.Pow(d, 2); }

		public double calculate_Druckverlust(
			double rho, double g, double delta_h, double lambda, double L, double d, double zeta_zu, double v)
		{
			return rho * g * delta_h + (lambda * L / d + zeta_zu) * rho / 2 * Math.Pow(v, 2);
		}
	}
}
