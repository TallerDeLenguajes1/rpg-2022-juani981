using System;

//Creacion de una lista de personajes y una lista de caracteristicas
List<Character> characters = new List<Character>();
List<Caracteristicas> caracteristicas = new List<Caracteristicas>();

//Creacion de personajes, agregandolos a la lista
Console.WriteLine("Cuantos personajes va a crear?");
int n=Convert.ToInt32(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    Character personajePruebai = new Character();
    Caracteristicas caracteristicasPi = new Caracteristicas();
    characters.Add(personajePruebai);
    caracteristicas.Add(caracteristicasPi);
}

//Muestra de los personajes y caracteristicas de la lista
for (int i = 0; i < characters.Count(); i++)
{
        Console.WriteLine("Prueba de generacion de personajes:");
        Console.WriteLine("Atributos aleatorios de personaje: "+i);
        Console.WriteLine("Velocidad:" + characters[i].velocidad);
        Console.WriteLine("Destreza:" + characters[i].destreza);
        Console.WriteLine("Fuerza:" + characters[i].fuerza);
        Console.WriteLine("Nivel:" + characters[i].nivel);
        Console.WriteLine("Armadura:" + characters[i].armadura);
        Console.WriteLine("Edad(1-300):" + caracteristicas[i].edad);
        Console.WriteLine("Salud(100):" + caracteristicas[i].salud);
        Console.WriteLine("Tipo:" + caracteristicas[i].tipo);
        Console.WriteLine("===");
        Console.WriteLine("=========");
}