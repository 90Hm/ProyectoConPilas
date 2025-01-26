using System;
using System.Collections.Generic;

class TorresDeHanoiProgram
{
    // Método principal del programa
    public static void Main(string[] args)
    {
        int numDiscos = 3; // Número de discos
        TorreHanoi origen = new TorreHanoi("Origen");
        TorreHanoi destino = new TorreHanoi("Destino");
        TorreHanoi auxiliar = new TorreHanoi("Auxiliar");

        // Apilar los discos en la torre de origen
        for (int i = numDiscos; i >= 1; i--)
        {
            origen.Push(i);
        }

        // Resolver el problema de las Torres de Hanoi
        ResolverHanoi(numDiscos, origen, destino, auxiliar);

        // Mostrar los discos en la torre de destino
        Console.WriteLine("Discos en la torre destino:");
        while (destino.Count > 0)
        {
            Console.WriteLine(destino.Pop());
        }
    }

    // Método recursivo para resolver el problema de las Torres de Hanoi
    public static void ResolverHanoi(int numDiscos, TorreHanoi origen, TorreHanoi destino, TorreHanoi auxiliar)
    {
        if (numDiscos == 1)
        {
            // Mover un disco de la torre de origen a la torre de destino
            destino.Push(origen.Pop());
            Console.WriteLine($"Mover disco de {origen.Nombre} a {destino.Nombre}");
        }
        else
        {
            // Mover n-1 discos de la torre de origen a la torre auxiliar
            ResolverHanoi(numDiscos - 1, origen, auxiliar, destino);
            // Mover el disco restante de la torre de origen a la torre de destino
            destino.Push(origen.Pop());
            Console.WriteLine($"Mover disco de {origen.Nombre} a {destino.Nombre}");
            // Mover los n-1 discos de la torre auxiliar a la torre de destino
            ResolverHanoi(numDiscos - 1, auxiliar, destino, origen);
        }
    }
}

// Clase TorreHanoi que hereda de Stack<int> para representar una torre en el problema de las Torres de Hanoi
class TorreHanoi : Stack<int>
{
    // Propiedad para almacenar el nombre de la torre
    public string Nombre { get; private set; }

    // Constructor que inicializa la torre con un nombre
    public TorreHanoi(string nombre)
    {
        // Asigna el nombre proporcionado a la propiedad Nombre
        Nombre = nombre;
    }
}