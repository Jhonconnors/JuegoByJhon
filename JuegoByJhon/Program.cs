using JuegoByJhon.Entidades;

internal class Program
{
    private static void Main(string[] args)
    {
        //VARIABLES
        string Nombre1;
        string Nombre2;
        int Puntos = 100;
        int Eleccion = 0;
        bool Validacion = false;    
       
        //Variable Ramdon para crear la Probabilidad del 50%
        Random Random = new Random();
        double Probabilidad;

        Console.WriteLine("*****BIENVENIDO AL jUEGO DE lUCHA AIEP******");

        Console.WriteLine("Ingrese EL nombre del Jugador 1");
        Nombre1 = Console.ReadLine();

        Console.WriteLine("Ingrese EL nombre del Jugador 2");
        Nombre2 = Console.ReadLine();


        Jugador Jugador1 = new Jugador() { Nombre = Nombre1, Puntos = Puntos, Ataque=false, 
        Defensa=false, Turno = true, Contador =0, AtaqueEspecial = false, RecuperacionEspecial = false };

        Jugador Jugador2 = new Jugador()
        {
            Nombre = Nombre2,
            Puntos = Puntos,
            Ataque = false,
            Defensa = false,
            Turno = false,
            Contador = 0,
            AtaqueEspecial = false,
            RecuperacionEspecial = false
        };

        do
        {
            Probabilidad = Random.NextDouble();
            
            if (Jugador1.Turno && Jugador1.Contador<5)
            {
                do
                {
                    try
                    {
                        Console.WriteLine("Turno de: " + Jugador1.Nombre);
                        Console.WriteLine("Elija " + "1.- Atacar 2.- Bloquear" + "  Faltan " + (5 - Jugador1.Contador) +
                            " para ataque especial");
                        Eleccion = Convert.ToInt32(Console.ReadLine());
                        Validacion = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("ERROR "+ex.Message+" \n ->. \n Solo debes Ingresar numeros. \n Intenta de Nuevo: \n");
                        Validacion = false;
                    }
                } while (!Validacion);
               
                switch (Eleccion)
                {
                    case 1:
                        Console.WriteLine("Has Elegido atacar");
                        Jugador1.Ataque = true;
                
                        break;
                    case 2:
                        Console.WriteLine("Has elegido Defensa, tienes 50% de probabilidades " +
                            "\n de bloquear ataque rival");
                        Jugador1.Defensa = true;
                     
                        break;
                    default:
                        Console.WriteLine("No elegiste una opcion por ende No te defiendes ni atacas");
                        Jugador1.Ataque =false;
                        Jugador1.Defensa=false;
                        break;
                }
                Jugador2.Turno = true;
                Jugador1.Turno = false;
                Jugador1.Contador += 1;
                
            } else if (Jugador2.Turno && Jugador2.Contador<5)
            {
                do
                {
                    try
                    {
                        Console.WriteLine("Turno de: " + Jugador2.Nombre);
                        Console.WriteLine("Elija " + "1.- Atacar 2.- Bloquear" + "  Faltan " + (5 - Jugador2.Contador) +
                            " para ataque especial");
                        Eleccion = Convert.ToInt32(Console.ReadLine());
                        Validacion = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("ERROR " + ex.Message + " \n ->. \n Solo debes Ingresar numeros. \n Intenta de Nuevo: \n");
                        Validacion = false;
                    }
                } while (!Validacion);
                
                switch (Eleccion)
                {
                    case 1:
                        Console.WriteLine("Has Elegido atacar");

                        if (Jugador1.Ataque)
                        {
                            Console.WriteLine("Ambos Sufren perdidad de puntos");
                            Jugador1.Puntos -= 10;
                            Jugador2.Puntos -= 10;
                            Console.WriteLine(Jugador1.puntajeTotal());
                            Console.WriteLine(Jugador2.puntajeTotal());
                            Jugador1.Ataque = false;
                        } else if (Jugador1.Defensa)
                        {
                            Jugador1.Defensa = false;

                            if (Probabilidad < 0.5)
                            {
                                Console.WriteLine("Ataque bloqueado!");
                                Console.WriteLine(Jugador1.puntajeTotal());
                                Console.WriteLine(Jugador2.puntajeTotal());
                                
                            }
                            else 
                            {
                                Console.WriteLine(Jugador1.Nombre+" ¡Fallaste al bloquear el ataque!");
                                Jugador1.Puntos -= 10;
                                Console.WriteLine(Jugador1.puntajeTotal());
                                Console.WriteLine(Jugador2.puntajeTotal());

                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine("Has elegido Defensa, tienes 50% de probabilidades " +
                            "\n de bloquear ataque rival");
                 

                        if (Probabilidad < 0.5 && Jugador1.Ataque)
                        {
                            Console.WriteLine("¡Ataque bloqueado!");
                            Console.WriteLine(Jugador1.puntajeTotal());
                            Console.WriteLine(Jugador2.puntajeTotal());
                            Jugador1.Ataque = false;

                        }
                        else if (Probabilidad > 0.5 && Jugador1.Ataque)
                        {
                            Console.WriteLine("¡Fallaste al bloquear el ataque!");
                            Jugador2.Puntos -= 10;
                            Console.WriteLine(Jugador1.puntajeTotal());
                            Console.WriteLine(Jugador2.puntajeTotal());
                            Jugador1.Ataque = false;
                        }
                        else
                        {
                            Console.WriteLine("Ambos jugadores eligen defensa y nunguno sufre cambios");
                            Console.WriteLine(Jugador1.puntajeTotal());
                            Console.WriteLine(Jugador2.puntajeTotal());
                            Jugador1.Defensa = false;
                        }
                        break;
                    default:
                        
                        if (Jugador1.Ataque)
                        {
                            Jugador2.Puntos -= 10;
                            Console.WriteLine(Jugador2.Nombre+" Por No elegir correctamente y ya que" +
                                " "+Jugador1.Nombre+ " Eligió atacar pierdes 10 puntos");
                            Jugador2.Puntos -= 10;
                            Console.WriteLine(Jugador1.puntajeTotal());
                            Console.WriteLine(Jugador2.puntajeTotal());
                            Jugador1.Ataque = false;    
                        }
                        else
                        {
                            Console.WriteLine("Elejiste mal pero como no hay ataque por parte"+Jugador1.Nombre
                                +" Nadie pierde puntos");
                            Console.WriteLine(Jugador1.puntajeTotal());
                            Console.WriteLine(Jugador2.puntajeTotal());
                            Jugador1.Defensa = false;
                        }
                        break;

                }
                Jugador2.Turno = false;
                Jugador1.Turno = true;
                Jugador2.Contador += 1;

            }

            /***********************************INICIO de Zona Ataque especial*****************************/
            if (Jugador1.Turno && Jugador1.Contador >= 5)
            {
                do
                {
                    try
                    {
                        Console.WriteLine("Turno de: " + Jugador1.Nombre);
                        Console.WriteLine("Elija " + "1.- Atacar 2.- Bloquear 3.- Ataque especial, 4.- Recuperación. " + "¡¡Ataque ESpecial ACTIVADO!!");
                        Eleccion = Convert.ToInt32(Console.ReadLine());
                        Validacion = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("ERROR " + ex.Message + " \n ->. \n Solo debes Ingresar numeros. \n Intenta de Nuevo: \n");
                        Validacion = false;
                    }
                } while (!Validacion);
              
                switch (Eleccion)
                {
                    case 1:
                        Console.WriteLine("Has Elegido atacar");
                        Jugador1.Ataque = true;

                        break;
                    case 2:
                        Console.WriteLine("Has elegido Defensa, tienes 50% de probabilidades de bloquear ataque rival excepto si es Ataque Especial");
                        Jugador1.Defensa = true;

                        break;
                    case 3:
                        Console.WriteLine("Has Elegido Ataque Especial \n");
                        Jugador1.AtaqueEspecial = true;

                        break;
                    case 4:
                        if (Jugador1.Puntos <= 90)
                        {
                            Jugador1.Puntos += 10;
                            Console.WriteLine("Has elegido Recuperacion y sumas 10 puntos");
                        }
                        if (Jugador1.Puntos > 90 && Jugador2.Puntos < 100)
                        {
                            Jugador1.Puntos = 100;
                            Console.WriteLine("Has elegido Recuperacion y llegas al limite de 100 puntos");
                        }
                        if (Jugador1.Puntos >= 100)
                        {
                            Console.WriteLine("Has elegido Recuperacion Pero ya estas en el limite de 100 puntos No puedes aumentar más");
                        }
                        Jugador1.RecuperacionEspecial = true;
                        break;

                    default:
                        Console.WriteLine("No elegiste una opcion por ende No te defiendes ni atacas");
                        Jugador1.Ataque = false;
                        Jugador1.Defensa = false;
                        break;
                }
                Jugador1.Turno = false;
                Jugador2.Turno = true;
                Jugador1.Contador += 1;

            }
            else if (Jugador2.Turno && Jugador2.Contador >= 5)
            {
                do
                {
                    try
                    {
                        Console.WriteLine("Turno de: " + Jugador2.Nombre);
                        Console.WriteLine("Elija " + "1.- Atacar 2.- Bloquear 3.- Ataque especial, 4.- Recuperación. ¡¡Ataque ESpecial ACTIVADO!!");
                        Eleccion = Convert.ToInt32(Console.ReadLine()); 
                        Validacion = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("ERROR " + ex.Message + " \n ->. \n Solo debes Ingresar numeros. \n Intenta de Nuevo: \n");
                        Validacion = false;
                    }
                } while (!Validacion);
               
                switch (Eleccion)
                {
                    case 1:
                        Console.WriteLine("Has Elegido atacar");

                        if (Jugador1.Ataque)
                        {
                            Console.WriteLine("Ambos Sufren perdidad de puntos");
                            Jugador1.Puntos -= 10;
                            Jugador2.Puntos -= 10;
                            Console.WriteLine(Jugador1.puntajeTotal());
                            Console.WriteLine(Jugador2.puntajeTotal());
                            Jugador1.Ataque = false;
                        }
                        else if (Jugador1.AtaqueEspecial)
                        {
                            Console.WriteLine("Ambos Sufren perdida de puntos Aunque " + Jugador2.Nombre + " Sufre daño de Ataque Especial \n");
                            Jugador1.AtaqueEspecial = false;
                            Jugador2.Puntos -= 30;
                            Console.WriteLine(Jugador1.puntajeTotal());
                            Console.WriteLine(Jugador2.puntajeTotal());

                        }
                        else if (Jugador1.Defensa)
                        {
                            Jugador1.Defensa = false;

                            if (Probabilidad < 0.5 )
                            {
                                Console.WriteLine(Jugador1.Nombre + "Ataque bloqueado!");
                                Console.WriteLine(Jugador1.puntajeTotal());
                                Console.WriteLine(Jugador2.puntajeTotal());

                            } 
                            else
                            {
                                Console.WriteLine(Jugador1.Nombre + " ¡Fallaste al bloquear el ataque!");
                                Jugador1.Puntos -= 10;
                                Console.WriteLine(Jugador1.puntajeTotal());
                                Console.WriteLine(Jugador2.puntajeTotal());
                            }
                        } else if (Jugador1.RecuperacionEspecial)
                        {
                            Console.WriteLine("Como " + Jugador1.Nombre + " Eligió Recuperacion y " + Jugador2.Nombre + "Elijió Ataque se le restan 10 Puntos a " +Jugador1.Nombre);
                            Jugador1.RecuperacionEspecial = false;
                        }
                        break;
                    case 2:
                        Console.WriteLine("Has elegido Defensa, tienes 50% de probabilidades de bloquear ataque rival excepto si es Ataque Especial");

                        if (Probabilidad < 0.5 && Jugador1.Ataque)
                        {
                            Console.WriteLine("¡Ataque bloqueado!");
                            Console.WriteLine(Jugador1.puntajeTotal());
                            Console.WriteLine(Jugador2.puntajeTotal());
                            Jugador1.Ataque = false;

                        }
                        else if (Jugador1.AtaqueEspecial)
                        {
                            Console.WriteLine("¡Fallaste al bloquear el ataque! Ya que es Ataque Especial");
                            Jugador2.Puntos -= 30;
                            Console.WriteLine(Jugador1.puntajeTotal());
                            Console.WriteLine(Jugador2.puntajeTotal());
                            Jugador1.AtaqueEspecial = false;
                        }
                        else if (Probabilidad > 0.5 && Jugador1.Ataque)
                        {
                            Console.WriteLine("¡Fallaste al bloquear el ataque!");
                            Jugador2.Puntos -= 10;
                            Console.WriteLine(Jugador1.puntajeTotal());
                            Console.WriteLine(Jugador2.puntajeTotal());
                            Jugador1.Ataque = false;
                        }
                        else
                        {
                            Console.WriteLine("Nungún Jugador Elije Ataques y por ende ninguno sufre cambios");
                            Console.WriteLine(Jugador1.puntajeTotal());
                            Console.WriteLine(Jugador2.puntajeTotal());
                            Jugador1.Defensa = false;
                        }
                        break;
                    case 3:
                        Console.WriteLine("Has elegido Ataque Especial");
                        if (Jugador1.Defensa)
                        {
                            Console.WriteLine("Como "+Jugador1.Nombre+" Eligió Defensa se le restan 30 Puntos");
                            Jugador1.Puntos -= 30;
                            Console.WriteLine(Jugador1.puntajeTotal());
                            Console.WriteLine(Jugador2.puntajeTotal());
                            Jugador1.Defensa = false;   
                        }
                        else if (Jugador1.Ataque)
                        {
                            Console.WriteLine("Como " + Jugador1.Nombre + " Eligió Ataque y "+Jugador2.Nombre+" eligió Ataque Especial, se le restan 30 Puntos a "+Jugador1.Nombre
                                +" y se le restan 10 puntos a "+Jugador2.Nombre);
                            Jugador2.Puntos -= 10;
                            Jugador1.Puntos -= 30;
                            Console.WriteLine(Jugador1.puntajeTotal());
                            Console.WriteLine(Jugador2.puntajeTotal());
                            Jugador1.Ataque = false;
                        }
                        else if (Jugador1.AtaqueEspecial)
                        {
                            Console.WriteLine("Como " + Jugador1.Nombre + " Eligió Ataque Especial y "+ Jugador2.Nombre+" tambien Eligió Ataque Especial se le restan 30 Puntos a Ambos ");
                            Jugador2.Puntos -= 30;
                            Jugador1.Puntos -= 30;
                            Console.WriteLine(Jugador1.puntajeTotal());
                            Console.WriteLine(Jugador2.puntajeTotal());
                            Jugador1.AtaqueEspecial = false;
                        }
                        else
                        {
                            Console.WriteLine("a " + Jugador1.Nombre + " restan 30 Puntos");
                            Jugador1.Puntos -= 30;
                            Console.WriteLine(Jugador1.puntajeTotal());
                            Console.WriteLine(Jugador2.puntajeTotal());
                            Jugador1.RecuperacionEspecial = false;
                        }
                        break;
                    case 4:
                        
                        if (Jugador2.Puntos <=90)
                        {
                            Jugador2.Puntos += 10;
                            Console.WriteLine("Has elegido Recuperacion y sumas 10 puntos");
                        }
                        if (Jugador2.Puntos >90 && Jugador2.Puntos <100)
                        {
                            Jugador2.Puntos = 100;
                            Console.WriteLine("Has elegido Recuperacion y llegas al limite de 100 puntos");
                        }
                        if (Jugador2.Puntos >= 100)
                        {
                            Console.WriteLine("Has elegido Recuperacion Pero ya estas en el limite de 100 puntos No puedes aumentar más");
                        }

                        if (Jugador1.AtaqueEspecial)
                        {
                            Console.WriteLine("Como " + Jugador1.Nombre + " Eligió Ataque Especial se le restan a "+Jugador2.Nombre+" 30 Puntos");
                            Jugador2.Puntos -= 30;
                            Console.WriteLine(Jugador1.puntajeTotal());
                            Console.WriteLine(Jugador2.puntajeTotal());
                            Jugador1.AtaqueEspecial = false;
                        }else if (Jugador1.Ataque)
                        {
                            Console.WriteLine("Como " + Jugador1.Nombre + " Eligió Ataque se le restan a" + Jugador2.Nombre + " 10 Puntos");
                            Jugador1.Ataque = false;
                        }
                        else
                        {
                            Console.WriteLine("Como " + Jugador1.Nombre + " No Eligió un Ataque a" + Jugador2.Nombre + " No se le restan Puntos");
                            Jugador1.RecuperacionEspecial = false;
                        }

                        break;
                    default:

                        if (Jugador1.Ataque)
                        {
                            Jugador2.Puntos -= 10;
                            Console.WriteLine(Jugador2.Nombre + " Por No elegir correctamente y ya que" +
                                " " + Jugador1.Nombre + " Eligió atacar pierdes 10 puntos");
                            Jugador2.Puntos -= 10;
                            Console.WriteLine(Jugador1.puntajeTotal());
                            Console.WriteLine(Jugador2.puntajeTotal());
                            Jugador1.Ataque = false;
                        } else if (Jugador1.AtaqueEspecial)
                        {
                            Console.WriteLine(Jugador2.Nombre + " Por No elegir correctamente y ya que" +
                               " " + Jugador1.Nombre + " Eligió Ataque Especial pierdes 30 puntos");
                            Jugador2.Puntos -= 30;
                            Console.WriteLine(Jugador1.puntajeTotal());
                            Console.WriteLine(Jugador2.puntajeTotal());
                        }
                        else
                        {
                            Console.WriteLine("Elejiste mal pero como no hay ataque por parte" + Jugador1.Nombre
                                + " Nadie pierde puntos");
                            Console.WriteLine(Jugador1.puntajeTotal());
                            Console.WriteLine(Jugador2.puntajeTotal());
                            Jugador1.Defensa = false;
                        }
                        break;

                }
                Jugador2.Turno = false;
                Jugador1.Turno = true;
                Jugador2.Contador += 1;

            }
            /***********************************FIN de Zona Ataque especial*****************************/

        } while (Jugador1.Puntos>0 && Jugador2.Puntos>0);

        if (Jugador1.Puntos > Jugador2.Puntos)
        {
            Console.WriteLine("\n El ganador es: "+Jugador1.Nombre);
        }
        else if (Jugador1.Puntos == Jugador2.Puntos)
        {
            Console.WriteLine("\n Hay un empate entre " + Jugador1.Nombre +" y "+Jugador2.Nombre);
        }
        else
        {
            Console.WriteLine("\n El ganador es: " + Jugador2.Nombre);
        }


    }
}