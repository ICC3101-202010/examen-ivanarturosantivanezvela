using System;
using System.Collections.Generic;
namespace Examen2020
{
    public class Jugador:Persona
    {   //Caracteristicas del jugador
        

        public int puntosdeataque;
        public int puntosdedefensa;
        public int numerodecamiseta;
        public string Arquero;//1 si es arquero 0 si no 

       

        //Lesion bool

        public bool Lesion=false;

        //probabilidad de lesion del jugador

        public double Probabilidadlesion = 0.05; 

        public Jugador(string nombre, int edad, string nacion, int sueldo, int puntosdeataque, int puntosdedefensa, int numerodecamiseta, string arquero)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.nacion = nacion;
            this.sueldo = sueldo;
            this.puntosdeataque = puntosdeataque;
            this.puntosdedefensa = puntosdedefensa;
            this.numerodecamiseta = numerodecamiseta;
            this.Arquero = arquero;
        }

        public void Anotaciondeljugador(List<Jugador> jugadores)
        {
            foreach(Jugador jugarreta in jugadores)
            {
                Random rnd = new Random();
                int prob = rnd.Next(0, 1);
                if (prob < 0.1)//Probablidad de gol por parte del jugador 
                {
                    Console.WriteLine("Golazo del jugador" + jugarreta.nombre);


                }

                else
                {
                    Tapadadelarquero(jugadores);
                }


            }
           
       

        }

        public void Tapadadelarquero(List<Jugador> jugadores)
        {
            foreach(Jugador jugador in jugadores)
            {
                if (jugador.Arquero == "1")
                {

                    Console.WriteLine("Tapadon del arquero"+jugador.nombre);

                }
                

            }
            


        }



   
    }
}
