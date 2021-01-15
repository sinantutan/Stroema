using System;

namespace Stroemung.Rohrreibung
{
{
	public class ReynoldsZahl
	{
		public double value { get; }

		public ReynoldsZahl() { }

		public ReynoldsZahl(double v, double d, double nu) { value = calculate(v, d, nu); }

		public ReynoldsZahl(double rho, double v, double d, double eta) { value = calculate(v, d, dyn_to_kin_viscosity(eta, rho)); }

		public double calculate(double v, double d, double nu) { return v * d / nu; }

		public double dyn_to_kin_viscosity(double eta, double rho) { return eta / rho; }

		public static explicit operator int(ReynoldsZahl v)
		{
			throw new NotImplementedException();
		}
	}
}
