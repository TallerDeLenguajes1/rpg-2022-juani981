using System;

/*Creacion de una lista de personajes, una lista de caracteristicas, y una lista de atributos de combate
Si bien son 3 listas distintas, el indice representa el acceso al mismo personaje
Es decir, un personaje esta definido por un indice unico en 3 listas diferentes
Se decidio esta implementacion por la facilidad de mantener el codigo*/
List<Character> characters = new List<Character>();
List<Caracteristicas> caracteristicas = new List<Caracteristicas>();
List<Combate> combat = new List<Combate>();

//Creacion de personajes, agregandolos a la lista
Console.WriteLine("Cuantos personajes va a crear?");
int n=Convert.ToInt32(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    //Se crea un elemnto de cada lista y se agrega a su respectiva lista
    Character personaje = new Character();
    Caracteristicas caracteristicasDelPersonaje = new Caracteristicas();
    Combate atributosdepeleaDelPersonaje =new Combate();
    characters.Add(personaje);
    caracteristicas.Add(caracteristicasDelPersonaje);
    combat.Add(atributosdepeleaDelPersonaje);
}

//Muestra de los personajes y caracteristicas de la lista
for (int i = 0; i < characters.Count(); i++)
{
    Console.WriteLine("Prueba de generacion de personajes:");
    Console.WriteLine("Atributos aleatorios del personaje "+i+":");
    Console.WriteLine("Velocidad:" + characters[i].velocidad);
    Console.WriteLine("Destreza:" + characters[i].destreza);
    Console.WriteLine("Fuerza:" + characters[i].fuerza);
    Console.WriteLine("Nivel:" + characters[i].nivel);
    Console.WriteLine("Armadura:" + characters[i].armadura);
    Console.WriteLine("Caracteristicas del personaje:");
    Console.WriteLine("Edad(1-300):" + caracteristicas[i].edad);
    Console.WriteLine("Salud(100):" + caracteristicas[i].salud);
    Console.WriteLine("Tipo:" + caracteristicas[i].tipo);
    Console.WriteLine("Atributos de combate del personaje:");
    Console.WriteLine("Poder de Disparo: " + combat[i].PD);
    Console.WriteLine("Efectividad de Disparo: " + combat[i].ED);
    Console.WriteLine("Valor de Ataque: " + combat[i].VA);
    Console.WriteLine("Poder de Defensa: " + combat[i].PDEF);
    Console.WriteLine("Maximo danio provocable: " + combat[i].MDP);
    Console.WriteLine("Danio provocado: "+ combat[i].ActualizarSalud(caracteristicas[i]));
    Console.WriteLine("=========");
}