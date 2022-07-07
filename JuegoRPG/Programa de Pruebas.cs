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
    Combate atributosdepeleaDelPersonaje =new Combate(personaje);
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
    Console.WriteLine("Danio provocado: " + combat[i].Danio);
    Console.WriteLine("=========");
}

//Programa de prueba de combate
    //Defino dos indices aleatorios, para pelear entre si
        //Se debe controlar que ambos valores no sean iguales, y no se repitan luego
Random rnd = new Random();
int peleador1, peleador2;
List<int> indices = new List<int>();//Voy a llevar registro de los indices mediante una lista
          //Generador de 2 indices aleatorios
          //El par de indices debe generarse n/2 veces
for (int i = 0; i < n/2; i++)
{
    do
    {
        peleador1 = rnd.Next(0, n);
        peleador2 = rnd.Next(0, n); ;//n estaba definida antes como la cantidad de personajes a generar
    } while (peleador1 == peleador2 || indices.Contains(peleador1) || indices.Contains(peleador2));
    //Si ambos pasaron el control, los agrego a la Lista de indices
    indices.Add(peleador1);
    indices.Add(peleador2);
}

//Muestra de los pares de indices a pelear
int k = 0;
while(k<n)
{
    Console.WriteLine("Proxima batalla: " + indices[k] + " contra " + indices[k+1]);
    k+=2;
}

//Los contrincantes estan definidos
//Ahora se debe iniciar las batallas
//3 ataques deben definirse para cada uno

//characters[]      caracteristicas[]      combat[]

/*Voy a usar como parametro principal para modificar el ataque, el nivel del personaje.
 A menor nivel, mas favorecido sera el ataque de este personaje*/
//Se van a modificar sus valores de combate de forma temporal durante su turno de 3 ataques.
//Guardo los valores originales en variables auxiliares lo que dure el turno
        //int index=0;
        //int j = indices[0];
for (int index=0; index < 2; index++)
{
    int j=indices[index];
    int EfectividadDisparoAux = combat[j].ED;
    double ValorDeAtaqueAux = combat[j].VA;
    double danioprovocadoAux = combat[j].Danio;

        //Ataque 1: 'Precision maxima' 
        if (characters[j].nivel <= 3)
        {
            combat[j].ED += 20;//A bajo nivel, bonus de 20% de precision al primer ataque
        }
        else if (characters[j].nivel <= 6)
        {
            combat[j].ED += 8;//A medio nivel, bonus de 8% de precision al primer ataque
        }                     //A alto nivel, ningun bonus de precision al primer ataque
        Console.WriteLine("Ataque 1:--");
        Console.WriteLine("Efectividad de Disparo: " + combat[j].ED);
        Console.WriteLine("Valor de Ataque: " + combat[j].VA);
        Console.WriteLine("Danio provocado: " + combat[j].DanioProvocado());

        combat[j].ED = EfectividadDisparoAux;//Devuelvo a su valor original
        //Ataque 2: 'Buff en el Valor de Ataque'
        if (characters[j].nivel <= 3)
        {
            combat[j].VA += combat[j].VA * 0.05;//5% bonus en Valor de Ataque Si es Nivel Bajo
        }
        else if (characters[j].nivel <= 6)
        {
            combat[j].VA += combat[j].VA * 0.02;//2% bonus en Valor de ataque Si es Nivel Medio
        }
        Console.WriteLine("Ataque 2:--");
        Console.WriteLine("Efectividad de Disparo: " + combat[j].ED);
        Console.WriteLine("Valor de Ataque: " + combat[j].VA);
        Console.WriteLine("Danio provocado: " + combat[j].DanioProvocado());
        //Devuelvo a su valor original
        combat[j].VA = ValorDeAtaqueAux;
    //Ataque 3: 'Golpe Critico' : Si la diferencia de Salud es mayor a 50%, se hace el doble de danio, independiente del nimvel
    if (Math.Abs(caracteristicas[j].salud - caracteristicas[indices[index+1]].salud) > 50)
    {
        if (caracteristicas[j].salud < caracteristicas[indices[index+1]].salud)
        {
            combat[j].Danio *= 2;
            Console.Write("\tGOLPE CRITICO!\n");
        }
        /*else
            combat[indices[index+1]].Danio *= 2;*/
    }
    Console.WriteLine("Ataque 3--");
    Console.WriteLine("Efectividad de Disparo: " + combat[j].ED);
    Console.WriteLine("Valor de Ataque: " + combat[j].VA);
    Console.WriteLine("Danio provocado: " + combat[j].DanioProvocado());

    combat[j].Danio = danioprovocadoAux;//Devuelvo a su valor original

    //Muestra si se hicieron los cambios, solo DEBUG
    Console.WriteLine("Primera batalla:");
    Console.WriteLine("Atributos aleatorios del personaje " + indices[index]);
    Console.WriteLine("Nivel:" + characters[j].nivel);
    Console.WriteLine("Salud(100):" + caracteristicas[j].salud);
    Console.WriteLine("Tipo:" + caracteristicas[j].tipo);
    Console.WriteLine("Atributos de combate del personaje:");
    Console.WriteLine("Poder de Disparo: " + combat[j].PD);
    Console.WriteLine("Efectividad de Disparo: " + combat[j].ED);
    Console.WriteLine("Valor de Ataque: " + combat[j].VA);
    Console.WriteLine("Danio provocado: " + combat[j].DanioProvocado());
}