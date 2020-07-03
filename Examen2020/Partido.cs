using System;
using System.Collections.Generic;
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

                    List<Jugador> jugadores1 = Equipo1.Devolverjugadoresdeesteequipo();
                    List<Jugador> jugadores2 = Equipo2.Devolverjugadoresdeesteequipo();

                    foreach(Jugador jugadores11 in jugadores1)
                    {

                        foreach(Jugador jugadores22 in jugadores2)
                        {


                           if(jugadores11.Anotaciondeljugador(jugadores1))
                            {

                                Numero_de_goles_equipo1++;

                               


                            }



                            if (jugadores22.Anotaciondeljugador(jugadores2))
                            {


                                Numero_de_goles_Equipo2++;

                            }
                            Equipo1.RetornarObjetoEntrenador().CambiarJugador(jugadores11, jugadores1); //Con esto veo el cambio de equipo del equipo 1 
                            Equipo2.RetornarObjetoEntrenador().CambiarJugador(jugadores22, jugadores2); //Con esto veo el cambio de equipo del equipo 2
                             
                        }



                    }


                    Equipo1.OnLesiondelJugador(jugadores1); //Con esto veo la lesiones del partido del equipo 1
                    Equipo2.OnLesiondelJugador(jugadores2); //Con esto veo las lesiones del partido del equipo 2


                   
        



                }

                if (Numero_de_goles_equipo1 > Numero_de_goles_Equipo2)
                {

                    Console.WriteLine("Ha ganado el equipo 1");


                }
                else if (Numero_de_goles_equipo1 < Numero_de_goles_Equipo2)
                {

                    Console.WriteLine("Ha ganado el equipo 2 ");


                }
                else if (Numero_de_goles_equipo1 == Numero_de_goles_Equipo2)
                {

                    Console.WriteLine("El partido ha sido un empate");


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
