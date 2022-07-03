using System;

public class Character
{
	//Constructor
	public Character()
	{
		Random random = new Random();
		velocidad = random.Next(1, 11);
		destreza = random.Next(1, 6);
		fuerza = random.Next(1, 11);
		nivel = random.Next(1, 11);
		armadura = random.Next(1, 11);
	}
	//Declaracion de variables
	public int velocidad {get;set;}
	public int destreza {get; set;}
	public int fuerza {get; set;}
	public int nivel {get; set;}
	public int armadura {get; set;}

}
