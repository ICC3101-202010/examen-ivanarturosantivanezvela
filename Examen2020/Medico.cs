using System;
namespace Examen2020
{
    public class Medico:Persona
    {
        
        public int Puntosdeexperiencia;

    
        public Medico(string nombre, int edad, string nacion, int sueldo, int puntosdeexperiencia)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.nacion = nacion;
            this.sueldo = sueldo;
            this.Puntosdeexperiencia = puntosdeexperiencia;
        }


        public void Evaluar(Jugador jugador)
        {

            if (jugador.Lesion)
            {

                Console.WriteLine("Estoy revisando la jugador");
                Curar(jugador);


            }

        }

        public void Curar(Jugador jugador )
        {

            Console.WriteLine("He curado a jugador "+ jugador.nombre);

        }



    }

    
    

}
