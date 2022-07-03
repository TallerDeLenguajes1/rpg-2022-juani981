using System;
//Clase que definirá los valores dentro de un combate
public class Combate
{
	public Combate()
	{
		Random random = new Random();
		Character personaje = new Character();
		PD = PoderdeDisparo(personaje);//Poder de disparo
		ED = random.Next(1, 101); //Efectividad de disparo.Tomar como valor porcentual
		VA = PD * ED;//Valor de Ataque
		PDEF = PoderdeDefensa(personaje);//Poder de defensa
		MDP = 50000;//Maximo danio provocable
	}
	public int PD { get; set; }
	public int ED { get; set; }
	public int VA { get; set; }
	public int PDEF { get; set; }
	public int MDP { get; set; }

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
	public int ActualizarSalud(Caracteristicas personaje)
    {
		int danioProvocado = ((VA * ED) - PDEF) / MDP;
		//danio se calcula sin factor de correccion *100, ya que el valor porcentual de ED es int
		return danioProvocado;
		//personaje.salud = personaje.salud - danioProvocado;
    }

}
