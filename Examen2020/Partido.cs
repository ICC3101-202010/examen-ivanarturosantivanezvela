using System;
namespace Examen2020
{
    public class Partido
    {
        int Numero_de_goles_equipo1;
        int Numero_de_goles_Equipo2;

        string Ganador_del_partido;
        Equipo Equipo1;
        Equipo Equipo2;



        public Partido(Equipo equipo1, Equipo equipo2)
        {

            this.Equipo1 = equipo1;
            this.Equipo2 = equipo2;

        }

        public bool Comprobarsiequipossondelamismaliga()
        {


            if (Equipo1.Seleccion_nacional == Equipo2.Seleccion_nacional)
            {

                Console.WriteLine("Ambos equipos son de la misma liga, se puede continuar");
                return true;

            }
            else
            {

                Console.WriteLine("Un equipo pertenece a otra liga o otra seleccion nacional, no se puede jugar con equipos de distinta liga o seleccion nacional");
                return false;


            }


        }
        public void SimularPartido()
        {
            if (Comprobarsiequipossondelamismaliga())
            {
                for (int i = 1; i <= 90; i++)
                {
                    throw new NotImplementedException();


                }


            }


        }
        public bool OnLesiondelJugador(object source, LesionjugadorEventArgs e)
        {

            if (e.ComunicarLesiondelJugador)
            {

                Console.WriteLine("Se ha lesionado el jugador "+e.NombredelJugador);
                return true;

            }
            else
            {
                return false;



            }

           
        }



    }
}
