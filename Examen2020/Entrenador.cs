using System;
using System.Collections.Generic;
namespace Examen2020
{
    public class Entrenador:Persona

    {
        
        //puntos de tactica
        public int puntosdetactica;


        public Entrenador(string nombre, int edad, string nacion, int sueldo, int puntosdetactica)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.nacion = nacion;
            this.sueldo = sueldo;
            this.puntosdetactica = puntosdetactica;
        }

        public void CambiarJugador(Jugador jugador,List<Jugador> jugadores)
        {
            int i = 0;

            if (jugador.Lesion)
            {
                Console.WriteLine("He decidido sacar al jugador"+ jugador.nombre+"por lesion");
                jugadores.Remove(jugador);
                i++;

            }
          
            if (i != 0)
            {
                Console.WriteLine("Escriba el nombre del jugador que lo reemplazara");

                string nombre = Console.ReadLine();

                foreach(Jugador jugador1 in jugadores)
                {

                    if (nombre == jugador1.nombre)
                    {

                        Console.WriteLine("Entra el jugador "+jugador1+" en reemplazo del jugador "+jugador.nombre);


                    }



                }





            }

            


        }





    }



}
