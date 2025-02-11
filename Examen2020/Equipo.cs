﻿using System;
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

        

        public static int PedirInt(string explicacion)
        {
            int valor = 0;
            bool valido = false;
            while (!valido)
            {
                Console.WriteLine(explicacion);
                valido = int.TryParse(Console.ReadLine(), out valor);
                if (!valido)
                    Console.WriteLine("Ingresa un numero valido válido");
            }
            return valor;
        }


        public void AgregarEntrenador()
        {

            //Caracteristicas
            Console.WriteLine("Escriba el nombre de su entrenador");
            string NombreEntrenador = Console.ReadLine();
            int EdadEntrenador = PedirInt("Escriba la edad de su entrenador");
            Console.WriteLine("Escriba la Nacionalidad del entrenador");
            string NacionalidadEntrenador = Console.ReadLine();
            int SueldoEntrenador = PedirInt("Escriba el sueldo de su entrenador");
            int Puntosdetactica = PedirInt("Escriba los puntos de tactica del entrenador");

            Entrenador entrenador = new Entrenador(NombreEntrenador, EdadEntrenador, NacionalidadEntrenador, SueldoEntrenador,Puntosdetactica);


            this.entrenadorequipo = entrenador;




        }


        public void AgregarmedicoalEquipo()
        {

            //Caracteristicas
            Console.WriteLine("Escriba el nombre de su medico");
            string NombreMedico = Console.ReadLine();
            int Edadmedico = PedirInt("Escriba la edad de su medico");
            Console.WriteLine("Escriba la Nacionalidad del medico");
            string NacionalidadMedico = Console.ReadLine();
            int SueldoMedico = PedirInt("Escriba el sueldo de su medico");
            int PuntosdeExperiencia = PedirInt("Escriba los puntos de experiencia del medico");



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
                    int Edad = PedirInt("Escriba la edad de su jugador");
                    Console.WriteLine("Escriba la Nacionalidad del jugador");
                    string Nacionalidad= Console.ReadLine();
                    while (Nacionalidad.ToUpper() != NacionalidadDelEquipo.ToUpper())
                    {
                        Console.WriteLine("La nacionalidad del jugador no coincide con la del equipo, vuelva a escribirla");
                        Helpernacionalidad = Console.ReadLine();
                        if (Helpernacionalidad.ToUpper() == NacionalidadDelEquipo.ToUpper())
                        {
                            Nacionalidad = Helpernacionalidad;
                            Helpernacionalidad = "";
                            break;

                        }
                        
                        
                    }
            
                    int Sueldo = PedirInt("Escriba el sueldo de su jugador");
                    //Atributos
                    int PuntosdeDefenda = PedirInt("Escriba puntos de defensa del jugador");              
                    int PuntosdeAtaque = PedirInt("Escriba puntos de ataque del jugador");                   
                    int Numerodecamiseta = PedirInt("Escriba el numero de la camiseta del jugador");
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
        public virtual void OnLesiondelJugador(List<Jugador> jugadores)
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

        public Medico RetornarnobjetoMedico()
        {

            return medicoequipo;


        }

        public Entrenador RetornarObjetoEntrenador()
        {
            return entrenadorequipo;


        }



        public void Nombreequipo()
        {

            Console.WriteLine("NombredelEquipo: " +NombredelEquipo);


        }
        public List<Jugador> Devolverjugadoresdeesteequipo()
        {

            return Jugadores;


        }













    }
}
