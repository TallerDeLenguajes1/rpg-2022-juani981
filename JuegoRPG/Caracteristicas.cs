using System;

public class Caracteristicas
{
	public Caracteristicas()
	{
		Random random = new Random();
		edad = random.Next(0, 301);
		salud = 100;
		tipo = Tipoaleatorio();
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
	public string DevolverGanadorCSV(Character ganador)
    {
		return nombre+";"+apodo+";"+ganador.nivel+";"+tipo;
    }
}
