using System;

namespace Examen2020
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            
            
            Console.WriteLine("Escriba la nacionalidad de su equipo");
            string Nacionalidad = Console.ReadLine();
            Console.WriteLine("Desea que su equipo sea equipo 1-Nacional o 0-Liga ");
            string Tipodeequipo=Console.ReadLine();
            Console.WriteLine("Nombre del primer equipo ");
            string Nombredelequipo = Console.ReadLine();



            Equipo equipo1 = new Equipo(Tipodeequipo, Nacionalidad,Nombredelequipo);
                equipo1.AgregarJugadoresalEquipo();
                equipo1.AgregarEntrenador();
                equipo1.AgregarmedicoalEquipo();
                
            
            
            Console.WriteLine("Escriba la nacionalidad de su segundo equipo");
            string Nacionalidad2 = Console.ReadLine();
            Console.WriteLine("Desea que su segundo equipo sea equipo 1-Nacional o de 2-Liga ");
            string Tipodeequipo2 = Console.ReadLine();
            Console.WriteLine("Nombre del segundo equipo ");
            string Nombredelequipo2 = Console.ReadLine();

            Equipo equipo2 = new Equipo(Tipodeequipo2, Nacionalidad,Nombredelequipo2);
                equipo2.AgregarJugadoresalEquipo();
                equipo2.AgregarEntrenador();
                equipo2.AgregarmedicoalEquipo();
                


            Console.WriteLine("Bienviedo a tu simulador de partido");
            Console.WriteLine("1) Ver jugadores de equipo");
            Console.WriteLine("2) Ver medico equipo");
            Console.WriteLine("3) Ver entrenador equipo");
            Console.WriteLine("4) Iiciar simulacion de un partido");
            Console.WriteLine("5) Salir del programa");

            string opcion = Console.ReadLine();

            Partido partido = new Partido(equipo1, equipo2);

            equipo1.SendingLesion += partido.OnLesiondelJugador;
            equipo2.SendingLesion += partido.OnLesiondelJugador;




            switch (opcion)
            {

                case ("1"):

                    Console.WriteLine("Escriba el nombre del equipo que desea ver");
                    string eleccion = Console.ReadLine();
                    if (eleccion == equipo1.NombredelEquipo)
                    {

                        equipo1.RetornarJugadores();


                    }
                    else if (eleccion == equipo2.NombredelEquipo)
                    {

                        equipo2.RetornarJugadores();


                    }

                    break;
                case ("2"):
                    Console.WriteLine("Escriba el nombre del equipo que desea ver");
                    string eleccion1 = Console.ReadLine();
                    if (eleccion1 == equipo1.NombredelEquipo)
                    {

                        equipo1.RetornarMedico();


                    }
                    else if (eleccion1 == equipo2.NombredelEquipo)
                    {

                        equipo2.RetornarMedico();


                    }
                    break;
                case ("3"):
                    Console.WriteLine("Escriba el nombre del equipo que desea ver");
                    string eleccion2 = Console.ReadLine();
                    if (eleccion2 == equipo1.NombredelEquipo)
                    {

                        equipo1.RetornarEntrenador();


                    }
                    else if (eleccion2 == equipo2.NombredelEquipo)
                    {

                        equipo2.RetornarEntrenador();


                    }
                    break;
                case ("4"):


                    break;

                case ("5"):

                    break;





            }
            







            







        }
    }
}
