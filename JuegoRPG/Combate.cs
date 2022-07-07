using System;

	//Clase que definirá los valores dentro de un combate
	public class Combate
	{
		public Combate(Character personaje)
		{
			Random random = new Random();
			//Character personaje = new Character();
			PD = PoderdeDisparo(personaje);//Poder de disparo
			ED = random.Next(1, 101); //Efectividad de disparo porcentual
			VA = PD * ED / 100;//Valor de Ataque
			PDEF = PoderdeDefensa(personaje);//Poder de defensa
			MDP = 50000;//Maximo danio provocable
						//DanioDefault =DanioProvocado();
		}
		public int PD { get; set; }
		public int ED { get; set; }
		public double VA { get; set; }
		public int PDEF { get; set; }
		public int MDP { get; set; }
		public double PuntosdeDanio { get; set; }
		public int PoderdeDisparo(Character personaje)
		{
			int podDisparo = personaje.destreza * personaje.fuerza * personaje.nivel;
			return podDisparo;
		}
		public int PoderdeDefensa(Character personaje)
		{
			int podDefensa = personaje.armadura * personaje.velocidad;
			return podDefensa;
		}
		public int DanioProvocado(Combate contrincante)
		{
			double danioProvocado = Math.Truncate((VA * ED - contrincante.PDEF) / MDP * 100);
			/*if (danioProvocado > MDP)
			{
				return MDP;
			}
			else
			{*/
			return Convert.ToInt32(danioProvocado);
			//}
		}
		public void ActualizarSalud(Combate atacante, Caracteristicas contrincante)
		{
			contrincante.salud -= DanioProvocado(atacante);
		}

	}

