using System;
using System.IO;
using System.Text.Json;


/*Creacion de una lista de personajes, una lista de caracteristicas, y una lista de atributos de combate
Si bien son 3 listas distintas, el indice representa el acceso al mismo personaje
Es decir, un personaje esta definido por un indice unico en 3 listas diferentes
Se decidio esta implementacion por la facilidad de mantener el codigo*/
List<Character> characters = new List<Character>();
List<Caracteristicas> caracteristicas = new List<Caracteristicas>();
List<Combate> combat = new List<Combate>();

//Creacion de personajes, agregandolos a la lista
Console.WriteLine("Cuantos personajes va a crear?");
int n = Convert.ToInt32(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    //Se crea un elemnto de cada lista y se agrega a su respectiva lista
    Character personaje = new Character();
    Caracteristicas caracteristicasDelPersonaje = new Caracteristicas();
    Combate atributosdepeleaDelPersonaje = new Combate(personaje);
    characters.Add(personaje);
    caracteristicas.Add(caracteristicasDelPersonaje);
    combat.Add(atributosdepeleaDelPersonaje);
}

//Muestra de los personajes y caracteristicas de la lista
for (int i = 0; i < characters.Count(); i++)
{
    Console.WriteLine("Prueba de generacion de personajes:");
    Console.WriteLine("Atributos aleatorios del personaje " + i + ":");
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
    //Console.WriteLine("Danio provocado: " + combat[i].PuntosdeDanio); no vale hasta uq eno se creen los demas personajes
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
for (int i = 0; i < n / 2; i++)
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


//Los contrincantes estan definidos
//Ahora se debe iniciar las batallas
//3 ataques deben definirse para cada uno

//characters[]      caracteristicas[]      combat[]

/*Voy a usar como parametro principal para modificar el ataque, el nivel del personaje.
 A menor nivel, mas favorecido sera el ataque de este personaje*/
//Se van a modificar sus valores de combate de forma temporal durante su turno de 3 ataques.
//Guardo los valores originales en variables auxiliares lo que dure el turno

//Split es un denominador que partirá en 2 la partida en cada ciclo
//int split = 1;
//for (int i = 0; i < characters.Count(); i++)
//{
    int tamanioLista = characters.Count();

    for (int index = 0; index < tamanioLista; index += 2)
    {
        //Indices para ambos peleadores
        int atacante = indices[index];
        int contrincante = indices[index + 1];
    
        MostarPeleadores(tamanioLista, indices, index);

        ResoluciondelCombate(characters, caracteristicas, combat, indices, atacante, contrincante, index);

        EscribirCSV(characters, caracteristicas);
        //split *= 2;
        
    }
    //BorrarPerdedores(characters, caracteristicas, combat, indices);
//}
if (characters.Count() == 1)
{
    Console.WriteLine("El ganador del trono de hierro es: " + indices[0]);
}
MostrarCSV();

static void Ataque1(List<Character> characters, List<Combate> combat, int atacante)
{
    int EfectividadDisparoDefault = combat[atacante].ED;
    if (characters[atacante].nivel <= 3)
    {
        combat[atacante].ED += 20;//A bajo nivel, bonus de 20% de precision al primer ataque
    }
    else if (characters[atacante].nivel <= 6)
    {
        combat[atacante].ED += 8;//A medio nivel, bonus de 8% de precision al primer ataque
    }                     //A alto nivel, ningun bonus de precision al primer ataque
    Console.WriteLine("Ataque 1:--");
    Console.WriteLine("Efectividad de Disparo: " + combat[atacante].ED);
    Console.WriteLine("Valor de Ataque: " + combat[atacante].VA);
    combat[atacante].ED = EfectividadDisparoDefault;//Devuelvo a su valor original
}

static void Ataque2(List<Character> characters, List<Combate> combat, int atacante)
{
    double ValorDeAtaqueDefault = combat[atacante].VA;
    //Ataque 2: 'Buff en el Valor de Ataque'
    if (characters[atacante].nivel <= 3)
    {
        combat[atacante].VA += combat[atacante].VA * 0.05;//5% bonus en Valor de Ataque Si es Nivel Bajo
    }
    else if (characters[atacante].nivel <= 6)
    {
        combat[atacante].VA += combat[atacante].VA * 0.02;//2% bonus en Valor de ataque Si es Nivel Medio
    }
    Console.WriteLine("Ataque 2:--");
    Console.WriteLine("Efectividad de Disparo: " + combat[atacante].ED);
    Console.WriteLine("Valor de Ataque: " + combat[atacante].VA);
    combat[atacante].VA = ValorDeAtaqueDefault;//Devuelvo a su valor original
}

static void Ataque3(List<Caracteristicas> caracteristicas, List<Combate> combat, int atacante, int contrincante)
{
    double DanioDefault = combat[atacante].DanioProvocado(combat[contrincante]);
    //Ataque 3: 'Golpe Critico' : Si la diferencia de Salud es mayor a 50%, se hace el doble de danio, independiente del nimvel
    if (Math.Abs(caracteristicas[atacante].salud - caracteristicas[contrincante].salud) > 50)
    {
        if (caracteristicas[atacante].salud < caracteristicas[contrincante].salud)
        {
            combat[atacante].PuntosdeDanio *= 2;
            Console.Write("\tGOLPE CRITICO!\n");
        }
    }
    Console.WriteLine("Ataque 3--");
    Console.WriteLine("Efectividad de Disparo: " + combat[atacante].ED);
    Console.WriteLine("Valor de Ataque: " + combat[atacante].VA);
    Console.WriteLine("Danio provocado 3: " + combat[atacante].DanioProvocado(combat[contrincante]));
    combat[atacante].PuntosdeDanio = DanioDefault;//Devuelvo a su valor original
}

static void ActualizarSaludContrincante(List<Caracteristicas> caracteristicas, List<Combate> combat, int atacante, int contrincante)
{
    /*if (combat[atacante].DanioProvocado(combat[contrincante])>= caracteristicas[contrincante].salud)
    {
        caracteristicas[contrincante].salud = 0;
    }else*/
    caracteristicas[contrincante].salud -= combat[atacante].DanioProvocado(combat[contrincante]);
}

static void Duelo(List<Character> characters, List<Caracteristicas> caracteristicas, List<Combate> combat, int atacante, int contrincante)
{
    //Ataque 1: 'Precision maxima' 
    Ataque1(characters, combat, atacante);
    //Console.WriteLine("Danio provocado 1: " + combat[atacante].DanioProvocado(combat[contrincante]));
    ActualizarSaludContrincante(caracteristicas, combat, atacante, contrincante);

    Ataque1(characters, combat, contrincante);
    //Console.WriteLine("Danio provocado 1: " + combat[contrincante].DanioProvocado(combat[atacante]));
    ActualizarSaludContrincante(caracteristicas, combat, contrincante, atacante);

    //Ataque 2: 'Buff en Valor de Ataque'
    Ataque2(characters, combat, atacante);
    //Console.WriteLine("Danio provocado 2: " + combat[atacante].DanioProvocado(combat[contrincante]));
    ActualizarSaludContrincante(caracteristicas, combat, atacante, contrincante);

    Ataque2(characters, combat, contrincante);
    //Console.WriteLine("Danio provocado 2: " + combat[contrincante].DanioProvocado(combat[atacante]));
    ActualizarSaludContrincante(caracteristicas, combat, contrincante, atacante);

    //Ataque 3: 'Posibilidad de golpe critico'
    Ataque3(caracteristicas, combat, atacante, contrincante);
    ActualizarSaludContrincante(caracteristicas, combat, atacante, contrincante);

    Ataque3(caracteristicas, combat, contrincante, atacante);
    ActualizarSaludContrincante(caracteristicas, combat, contrincante, atacante);
}

static void ResoluciondelCombate(List<Character> characters, List<Caracteristicas> caracteristicas, List<Combate> combat, List<int> indices, int atacante, int contrincante, int indexcombates)
{
    Duelo(characters, caracteristicas, combat, atacante, contrincante);
    Console.Write("El Ganador del encuentro es:\t");

    if (caracteristicas[atacante].salud > caracteristicas[contrincante].salud)
    {
        Console.Write("Jugador " + atacante + "\n");
        caracteristicas[atacante].salud += 10;//Se otorga 10 puntos de vida al ganador
        characters[atacante].armadura -= 1;//Pierde 1 punto de armadura
        characters[atacante].destreza += 2;//Se otorgan 2 puntos de destreza
        characters[atacante].ganador = true;
    }
    else if (caracteristicas[atacante].salud < caracteristicas[contrincante].salud)
    {
        Console.Write("Jugador " + contrincante + "\n");
        caracteristicas[contrincante].salud += 10;//Se otorga 10 puntos de vida al ganador
        characters[contrincante].armadura -= 1;//Pierde 1 punto de armadura
        characters[contrincante].destreza += 2;//Se otorgan 2 puntos de destreza
        characters[contrincante].ganador = true;
    }
    else
    {
        //Console.WriteLine("EMPATE!, se enfrentaran de nuevo");
    }
}

static void BorrarPerdedores(List<Character> characters, List<Caracteristicas> caracteristicas, List<Combate> combat, List<int> indices)
{

    for (int i = 0; i < characters.Count(); i++)
    {
        int atacante = indices[i];
        //int contrincante = indices[i + 1];

        if (characters[atacante].ganador == false)
        {
            //Elimino de las listas al perdedor
            characters.Remove(characters[atacante]);
            caracteristicas.Remove(caracteristicas[atacante]);
            combat.Remove(combat[atacante]);
            indices.Remove(indices[i]);
        }
        /*else if (characters[contrincante].ganador)
        {
            //Elimino de las listas al perdedor
            characters.Remove(characters[atacante]);
            caracteristicas.Remove(caracteristicas[atacante]);
            combat.Remove(combat[atacante]);
            indices.Remove(indices[i]);
        }*/
    }
}

static void SiguienteRonda(List<Character> characters, List<Caracteristicas> caracteristicas, List<Combate> combat, List<int> indices)
{
    foreach (var item in indices)
    {
        if (characters[item].ganador)
        {

        }
    }
}

static void EscribirCSV(List<Character> characters, List<Caracteristicas> caracteristicas)
    {
        StreamWriter sw = new StreamWriter(@"C:\Users\Juan Ignacio Carrizo\Desktop\Ganadores.csv");

        if (!File.Exists(@"C:\Users\Juan Ignacio Carrizo\Desktop\Ganadores.csv"))
        {
            sw.WriteLine("Nombre;Apodo;Nivel;Tipo");
        }
        else
        {
                sw.WriteLine(caracteristicas[0].nombre + ";" + caracteristicas[0].apodo + ";" + characters[0].nivel + ";" + caracteristicas[0].tipo + ";");
        }
        sw.Close();
    }

static void MostrarCSV() {

    if (File.Exists(@"C:\Users\Juan Ignacio Carrizo\Desktop\Ganadores.csv"))
    {
        Console.WriteLine("Nombre\t\tApodo\t\tNivel\t\tTipo\t\t");
        string line = "";
        using (StreamReader sr = new StreamReader(@"C:\Users\Juan Ignacio Carrizo\Desktop\Ganadores.csv"))
        {
            while ((line = sr.ReadLine()) != null)
            {
                string[] substring = line.Split(';');

                foreach (var sub in substring)
                {
                    Console.Write($"{sub}\t\t");
                }
            }
        }
    }
    else
    {
        Console.WriteLine("No existe registro de ganadores anteriores");
    }
}

static void GuardarJson(List<Character> characters, List<Caracteristicas> caracteristicas)
{
    string participantesJson = JsonSerializer.Serialize(caracteristicas);
    using (var archivo = new FileStream("participantes.json", FileMode.Create))
    {
        using (var strWriter = new StreamWriter(archivo))
        {
            strWriter.WriteLine("{0}", participantesJson);
            strWriter.Close();
        }
    }
}

static void AbrirJson(List<Character> characters, List<Caracteristicas> caracteristicas, List<Combate> combat, List<int> indices)
{
    string documento;
    using (var archivoOpen = new FileStream("participantes.json", FileMode.Open))
    {
        using (var strReader = new StreamReader(archivoOpen))
        {
            documento = strReader.ReadToEnd();
            archivoOpen.Close();
        }
    }
    var leidoDesdeJson = JsonSerializer.Deserialize<List<Caracteristicas>>(documento);
}

static void MostarPeleadores(int n, List<int> indices, int k = 0, string condicion = "NULL")
    {
        //Muestra de los pares de jugadores a pelear
        //int k = 0;
        if (condicion == "showall")
        {
            while (k < n)
            {
                Console.WriteLine("Proxima batalla: " + indices[k] + " Vs. " + indices[k + 1]);
                k += 2;
            }
        }
        else
            Console.WriteLine("Proxima batalla: " + indices[k] + " Vs. " + indices[k + 1]);
    }
