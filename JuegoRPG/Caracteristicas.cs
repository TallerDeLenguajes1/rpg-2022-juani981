using System;
using JuegoRPG;
using System.Text.Json;
using System.Net;
public class Caracteristicas
{
	public Caracteristicas()
	{
		Random random = new Random();
		//edad = random.Next(0, 301);
		salud = 100;
		tipo = Tipoaleatorio();
		fechaNac = GenerarFechaAleatoria();
		edad = CalcularEdad(fechaNac);
	}
	public string tipo { get; set; }
	public string? nombre { get; set; }
	public string? apodo { get; set; }
	public DateTime fechaNac { get; set; }
	public int edad { get; set; }
	public int salud { get; set; }

	public string Tipoaleatorio()
	{
		Random random = new Random();
		string[] tipos = { "Bufón", "Paladin", "Bárbaro", "Erudito" };
		return tipos[random.Next(0, 4)];
	}
	
	public DateTime GenerarFechaAleatoria()
	{
		DateTime dtmFechaInicial = new DateTime(1723, 1, 1);//Para que tenga maximo 300 anios
		Random aleatorio = new Random();
		int rangoDias = (DateTime.Today - dtmFechaInicial).Days;
		DateTime dtmFechaAleatoria = dtmFechaInicial.AddDays(aleatorio.Next(rangoDias));
		return (dtmFechaAleatoria);
	}
	public int CalcularEdad(DateTime a)
    {
		var b = DateTime.Today;
		var edad = b.Year - a.Year;
		return edad;
	}
}
