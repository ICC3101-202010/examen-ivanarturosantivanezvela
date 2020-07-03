using System;
using System.Collections.Generic;



namespace Examen2020
{
    public class Equipo
    {
        //Nombre del equipo
        public string NombredelEquipo;
        //Entrenador
        Entrenador entrenadorequipo;
        //Medico
        Medico medicoequipo;
        //Seleccion_nacional=1  Liga=0
        public string Seleccion_nacional;
        //Nacionalidad del equipo
        string NacionalidadDelEquipo;
        //Lista de jugadores del equipo
        List<Jugador> Jugadores = new List<Jugador>();
        string ArqueroEquipo; //1 si es arquero 1 si no es arquero
        string Helpernacionalidad;
        public bool Lesion = false;

        //Evento para comunicar Lesion
        public delegate bool LesionDelJugadorEventArgs(object source, LesionjugadorEventArgs args);
        public event LesionDelJugadorEventArgs SendingLesion;




        public Equipo(string seleccion_nacional, string nacionalidadDelEquipo,string nombredelequipo)
        {
            this.Seleccion_nacional = seleccion_nacional;
            this.NacionalidadDelEquipo = nacionalidadDelEquipo;
            this.NombredelEquipo = nombredelequipo;
        }

        public void AgregarEntrenador()
        {

            //Caracteristicas
            Console.WriteLine("Escriba el nombre de su entrenador");
            string NombreEntrenador = Console.ReadLine();
            Console.WriteLine("Escriba la edad de su entrenador");
            int EdadEntrenador = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Escriba la Nacionalidad del entrenador");
            string NacionalidadEntrenador = Console.ReadLine();
            Console.WriteLine("Escriba el sueldo de su entrenador");
            int SueldoEntrenador = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Escriba los puntos de tactica del entrenador");
            int Puntosdetactica = Convert.ToInt32(Console.ReadLine());

            Entrenador entrenador = new Entrenador(NombreEntrenador, EdadEntrenador, NacionalidadEntrenador, SueldoEntrenador,Puntosdetactica);


            this.entrenadorequipo = entrenador;




        }


        public void AgregarmedicoalEquipo()
        {

            //Caracteristicas
            Console.WriteLine("Escriba el nombre de su medico");
            string NombreMedico= Console.ReadLine();
            Console.WriteLine("Escriba la edad de su medico");
            int Edadmedico = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Escriba la Nacionalidad del medico");
            string NacionalidadMedico = Console.ReadLine();
            Console.WriteLine("Escriba el sueldo de su medico");
            int SueldoMedico = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Escriba los puntos de tactica del entrenador");
            int PuntosdeExperiencia = Convert.ToInt32(Console.ReadLine());



            Medico medico = new Medico(NombreMedico,Edadmedico,NacionalidadMedico,SueldoMedico,PuntosdeExperiencia);

            this.medicoequipo = medico;



        }


        public void AgregarJugadoresalEquipo()
        {
            int  i = 1;

            while (i < 15)
            {

                if (Jugadores.Count<= 15)
                {
                    //Caracteristicas
                    Console.WriteLine("Escriba el nombre de su jugador");
                    string NombreJugador = Console.ReadLine();
                    Console.WriteLine("Escriba la edad de su jugador");
                    int Edad = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Escriba la Nacionalidad del jugador");
                    string Nacionalidad= Console.ReadLine();
                    while (Nacionalidad.ToUpper() != NacionalidadDelEquipo.ToUpper())
                    {
                        Console.WriteLine("La nacionalidad del jugador no coincide con la del equipo, vuelva a escribirla");
                        Helpernacionalidad = Console.ReadLine();
                        if (Helpernacionalidad == NacionalidadDelEquipo)
                        {
                            Nacionalidad = Helpernacionalidad;
                            break;
                        }
                        
                    }

                    Console.WriteLine("Escriba el sueldo de su jugador");
                    int Sueldo = Convert.ToInt32(Console.ReadLine());

                    //Atributos
                    Console.WriteLine("Escriba puntos de defensa del jugador");
                    int PuntosdeDefenda = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Escriba puntos de ataque del jugador");
                    int PuntosdeAtaque = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Escriba el numero de la camiseta del jugador");
                    int Numerodecamiseta = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Desea que su jugador sea arquero? 1-Si 2-No");
                    string Arquero = Console.ReadLine();

                    if (Jugadores.Count != 0 || Jugadores != null)
                    {

                        foreach (Jugador jugador1 in Jugadores)
                        {

                            if (jugador1.Arquero == "1")
                            {
                                Console.WriteLine("Ya hay un arquero en el equipo, este automaticamente sera solo de cancha");
                                ArqueroEquipo = "0";
                                

                            }
                            else
                            {
                                if (Arquero == "1")
                                {

                                    ArqueroEquipo = "1";
                                   

                                }
                                else if (Arquero == "2")
                                {
                                    ArqueroEquipo = "0";
                                


                                }


                            }



                        }


                    }

                    Jugador jugador = new Jugador(NombreJugador, Edad, Nacionalidad, Sueldo, PuntosdeAtaque, PuntosdeDefenda, Numerodecamiseta, ArqueroEquipo);
                    Jugadores.Add(jugador);
                    i++;

                }

                i++;

            }


        }
        protected virtual void OnLesiondelJugador(List<Jugador> jugadores)
        {

            if (SendingLesion != null)
            {


                foreach (Jugador jugador in jugadores)
                {
                    Random rnd = new Random();
                    int prob = rnd.Next(0, 1);


                    //Probabilidad de lesion del jugador es 0.05

                    if (jugador.Probabilidadlesion <= prob)
                    {

                        jugador.Lesion = true;
                        Lesion = jugador.Lesion;
                        SendingLesion(this, new LesionjugadorEventArgs() { ComunicarLesiondelJugador = Lesion, NombredelJugador = jugador.nombre });


                    }




                }




            }



        }

        public void RetornarJugadores()
        {
            foreach(Jugador jugador in Jugadores)
            {

                Console.WriteLine("Jugador: "+jugador.nombre+" del equipo "+NombredelEquipo + "\n");

            }


        }
        public void RetornarEntrenador()
        {


            Console.WriteLine("Entrenador : "+ entrenadorequipo.nombre);



        }
        public void RetornarMedico()
        {


            Console.WriteLine("Medico: "+ medicoequipo.nombre);

        }
        public void Nombreequipo()
        {

            Console.WriteLine("NombredelEquipo: " +NombredelEquipo);


        }













    }
}
