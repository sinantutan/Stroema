namespace Stroemung.Rohrreibungsbeiwert
{
{
	public class ReynoldsZahl
	{
		public float value { get; }

		public ReynoldsZahl() { }

		public ReynoldsZahl(float v, float d, float nu) { value = calculate(v, d, nu); }

		public ReynoldsZahl(float rho, float v, float d, float eta) { value = calculate(v, d, dyn_to_kin_viscosity(eta, rho)); }

		public float calculate(float v, float d, float nu) { return v * d / nu; }

		public float dyn_to_kin_viscosity(float eta, float rho) { return eta / rho; }
	}
}
