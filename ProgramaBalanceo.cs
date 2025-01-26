using System;
using System.Collections.Generic;

namespace Semana7
{
    // Clase principal que contiene los métodos para verificar el balanceo de una expresión
    class ProgramaBalanceo
    {
        // Método de inicio del programa. Se puede renombrar a Main si es necesario.
        public static void Iniciar(string[] args) //En caso no se inicie el programa cambiar la palabra "Iniciar" por "Main"
        {
            Ejecutar();
        }

        // Método que ejecuta la lógica principal del programa
        public static void Ejecutar()
        {
            // Definición de la expresión a verificar
            string expresion = "{7+(8*5)-[(9-7)+(4+1)]}";
            // Verificación del balanceo de la expresión y salida del resultado
            Console.WriteLine(VerificarBalanceo(expresion) ? "La fórmula está balanceada." : "La fórmula no está balanceada.");
        }

        // Método que verifica si una expresión está balanceada en términos de paréntesis, corchetes y llaves
        static bool VerificarBalanceo(string expresion)
        {
            // Pila para almacenar los caracteres de apertura
            Stack<char> pila = new Stack<char>();
            // Recorrido de cada carácter en la expresión
            foreach (char c in expresion)
            {
                // Si el carácter es de apertura, se agrega a la pila
                if (c == '{' || c == '[' || c == '(') pila.Push(c);
                // Si el carácter es de cierre, se verifica el balanceo
                else if (c == '}' || c == ']' || c == ')')
                {
                    // Si la pila está vacía o los caracteres no coinciden, la expresión no está balanceada
                    if (pila.Count == 0 || !Coinciden(pila.Pop(), c)) return false;
                }
            }
            // La expresión está balanceada si la pila está vacía al final
            return pila.Count == 0;
        }

        // Método auxiliar que verifica si los caracteres de apertura y cierre coinciden
        static bool Coinciden(char apertura, char cierre)
        {
            return (apertura == '(' && cierre == ')') || 
                   (apertura == '[' && cierre == ']') || 
                   (apertura == '{' && cierre == '}');
        }
    }
}