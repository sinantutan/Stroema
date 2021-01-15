namespace Stroemung.Rohrreibungsbeiwert
{
	public enum Rohrstroemung { laminar, turbulent }

	class Rohrreibungsbeiwert
	{

		public ReynoldsZahl Re { get; }

		public float value { get; }

		Rohrreibungsbeiwert() { }

		Rohrreibungsbeiwert(float v, float d, float nu) {
			value = calculate(new ReynoldsZahl(v, d, nu));
		}

		Rohrreibungsbeiwert(float rho, float v, float d, float eta) { 
			Re = new ReynoldsZahl(rho, v, d, eta); 
		}

		public Rohrstroemung calculate_Rohrstroemung(ReynoldsZahl Re) { 
			return Re.value >= 2320 ? Rohrstroemung.turbulent : Rohrstroemung.laminar; 
		}

		public float calculate(ReynoldsZahl Re) {
			float value;
			if(calculate_Rohrstroemung(Re) == Rohrstroemung.laminar) {

			} else {

			}
			return value;
		}
	}
}
