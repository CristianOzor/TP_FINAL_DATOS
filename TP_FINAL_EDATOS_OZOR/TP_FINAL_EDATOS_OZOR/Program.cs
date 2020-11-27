using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;//Importo el módulo de Stack y Queue de la libreria. Uso de colas
using System.IO;//Éste módulo me va a permitir manipular archivos

namespace TP_FINAL_EDATOS_OZOR
{
    class Program
    {
        //Función principal Main
        static void Main(string[] args)
        {
            //Titulo en el cmd
            Console.Title = ("TP Final Estructura de Datos");

            //creo un diccionario que aloja como clave un nombre que es dado por el usuario y un valor que son las colas
            Dictionary<string, Queue<int>> colas = new Dictionary<string, Queue<int>>();

            //Inicializa la variable que va a alojar el menú.
            int opcion;
            do
            {
                do
                {
                    //Cada vez que se repite el ciclo limpia la pantalla y son más visibles las opciones
                    Console.Clear();
                    //Variable que aloja al menu creado y lo llama
                    opcion = Menu();

                    //Imprime el mensaje que retorna del catch si es algo que no sea numérico o si ingresa 0
                    if (opcion == 0)
                    {
                        Console.WriteLine("ERROR! Ingrese un número que figure en el Menú");
                        Console.ReadKey();
                    }

                    //Valida que la opción esté dentro del rango del Menú
                    if (opcion < 0 || opcion > 11)
                    {
                        Console.WriteLine("Ingrese una opción válida");

                        Console.ReadKey();
                    }



                } while (opcion < 0 || opcion > 11);

                switch (opcion)
                {
                    case 1: //Crear cola

                        //limpio pantalla
                        Console.Clear();
                        //imprimo las colas para tener una idea de lo que hay
                        PrintColas(colas);

                        Console.WriteLine("\n\nIngrese una nombre para la cola\n\n");

                        string nombre = Console.ReadLine();

                        //Indica si la cadena especificada no es null o una cadena vacía
                        if (!String.IsNullOrEmpty(nombre))
                        {
                            //Si no hay una cola en el diccionario con ese nombre como clave crea cola
                            if (!colas.ContainsKey(nombre))
                                colas.Add(nombre, new Queue<int>());

                            Console.WriteLine("Cola creada existosamente");
                            Console.ReadKey();
                        }

                        break;

                    case 2: //Borrar cola

                        Console.Clear();

                        if (colas.Count() > 0)
                        {
                            PrintColas(colas);

                            Console.WriteLine("\n\nIngrese el número de la cola\n\n");

                            try
                            {
                                //Se lee el número de la cola ingresada
                                int indexColaDelete = int.Parse(Console.ReadLine());

                                //Si la cuenta de colas es mayor al numero dado por el usuario
                                if (colas.Count > indexColaDelete)
                                {
                                    Console.Clear();

                                    //El var reemplaza <KeyValuePair<TKey,TValue>>
                                    //Devuelve el elemento identificado en una secuencia dentro del diccionario
                                    var cola = colas.ElementAt(indexColaDelete);

                                    //Remuevo la clave del diccionario
                                    colas.Remove(cola.Key);

                                    Console.WriteLine("Cola borrada existosamente");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine("No existe la cola ingresada");
                                    Console.ReadKey();
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Error! Ingrese un número entero");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.WriteLine("No existe ninguna cola");
                            Console.ReadKey();
                        }

                        break;

                    case 3: //Agregar pedido

                        Console.Clear();

                        if (colas.Count() > 0)
                        {
                            PrintColas(colas);

                            Console.WriteLine("\n\nIngrese el número de la cola\n\n");

                            try
                            {
                                int indexCola = int.Parse(Console.ReadLine());

                                //Si el numero de colas es mayor al número ingresado. La cola existe y se le puede agregar elementos
                                if (colas.Count > indexCola)
                                {
                                    Console.Clear();

                                    //Identifica el numero de cola que brinda el usuario
                                    var cola = colas.ElementAt(indexCola);

                                    Console.WriteLine(String.Format("Cola: {0}\n\n", cola.Key));

                                    PrintQueue(cola.Value);

                                    try
                                    {
                                        Console.WriteLine("\nIngrese el pedido\n");
                                        int pedido = int.Parse(Console.ReadLine());
                                        if (pedido >= 1 && pedido < 999)
                                        {
                                            cola.Value.Enqueue(pedido);
                                            Console.WriteLine("Pedido añadido exitosamente");
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            Console.WriteLine("El rango de pedidos debe de ser entre el 1 al 998");
                                            Console.ReadKey();
                                        }
                                    }
                                    catch (Exception ValueError)
                                    {
                                        Console.WriteLine("Error! Ingrese un numero entero");
                                        Console.ReadKey();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("La cola ingresada no existe");
                                    Console.ReadKey();
                                }
                            }
                            catch (Exception ValueError)
                            {
                                Console.WriteLine("Error! Ingrese un numero entero");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.WriteLine("No existe ninguna cola");
                            Console.ReadKey();
                        }

                        break;

                    case 4: //Borrar pedido

                        Console.Clear();
                        //Idem a agregar pedido valida si existe hay cola creada
                        if (colas.Count() > 0)
                        {
                            PrintColas(colas);

                            Console.WriteLine("\n\nIngrese el número de la cola\n\n");

                            //valido que sea un número entero y no una letra por ejemplo sino rompe el código
                            //documento una vez ya que voy a tener q atrapar el error en todas las opciones del menú
                            try
                            {

                                int indexColaBorrar = int.Parse(Console.ReadLine());

                                if (colas.Count > indexColaBorrar)
                                {
                                    Console.Clear();

                                    var cola = colas.ElementAt(indexColaBorrar);

                                    Console.WriteLine(String.Format("Cola: {0}\n\n", cola.Key));

                                    Queue<int> queue = cola.Value;

                                    PrintQueue(queue);
                                    //El método Dequeue elimina el elemento más antiguo cargado en la cola

                                    if (queue.Count > 0)
                                    {
                                        int pedido = queue.Dequeue();

                                        Console.WriteLine("El Pedido {0} ha sido borrado exitosamente", pedido);
                                        //Console.WriteLine("El Pedido " + Convert.ToString(pedido) + " ha sido borrado exitosamente");
                                        Console.ReadKey();
                                    }
                                    else
                                    {

                                        Console.WriteLine("El pedido está vacio");
                                        Console.ReadKey();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("No existe la cola ingresada");
                                    Console.ReadKey();
                                }

                            }
                            catch (Exception ValueError)
                            {
                                Console.WriteLine("Error! Ingrese un numero entero");
                                Console.ReadKey();
                            }


                        }
                        else
                        {
                            Console.WriteLine("No existe ninguna cola");
                            Console.ReadKey();
                        }

                        break;

                    case 5://listar elementos de una cola
                        {
                            Console.Clear();

                            if (colas.Count() > 0)
                            {
                                PrintColas(colas);

                                Console.WriteLine("\n\nIngrese el número de la cola\n\n");

                                try
                                {
                                    int listarCola = int.Parse(Console.ReadLine());

                                    if (colas.Count > listarCola)
                                    {
                                        Console.Clear();

                                        var cola = colas.ElementAt(listarCola);

                                        Console.WriteLine(String.Format("Cola: {0}\n\n", cola.Key));

                                        Queue<int> queue = cola.Value;

                                        PrintQueue(queue);
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        Console.WriteLine("No existe la cola ingresada");
                                        Console.ReadKey();
                                    }
                                }
                                catch (Exception ValueError)
                                {
                                    Console.WriteLine("Por favor ingrese un número entero");
                                    Console.ReadKey();
                                }
                            }
                            else
                            {
                                Console.WriteLine("No existe ninguna cola");
                                Console.ReadKey();
                            }
                            break;
                        }
                    case 6://Listar último pedido
                        {
                            Console.Clear();

                            if (colas.Count() > 0)
                            {
                                PrintColas(colas);

                                Console.WriteLine("\n\nIngrese el número de la cola\n\n");
                                try
                                {
                                    int indexCola = int.Parse(Console.ReadLine());

                                    if (colas.Count > indexCola)
                                    {
                                        Console.Clear();

                                        var cola = colas.ElementAt(indexCola);

                                        Console.WriteLine(String.Format("Cola: {0}\n\n", cola.Key));

                                        Queue<int> queue = cola.Value;


                                        int ultimo = queue.LastOrDefault();
                                        Console.WriteLine("El último pedido es {0}", ultimo);
                                        Console.ReadKey();

                                    }
                                    else
                                    {
                                        Console.WriteLine("No existe la cola ingresada");
                                        Console.ReadKey();
                                    }
                                }
                                catch(Exception ValueError)
                                {
                                    Console.WriteLine("Por favor ingrese un número entero");
                                    Console.ReadKey();
                                }
                            }
                            else
                            {
                                Console.WriteLine("No existe ninguna cola");
                                Console.ReadKey();
                            }

                            break;
                        }
                    case 7://Listar primer pedido
                        Console.Clear();

                        if (colas.Count() > 0)
                        {
                            PrintColas(colas);

                            Console.WriteLine("\n\nIngrese el número de la cola\n\n");

                            try
                            {
                                int indexCola = int.Parse(Console.ReadLine());

                                if (colas.Count > indexCola)
                                {
                                    Console.Clear();

                                    var cola = colas.ElementAt(indexCola);

                                    Console.WriteLine(String.Format("Cola: {0}\n\n", cola.Key));

                                    Queue<int> queue = cola.Value;


                                    int primero = queue.Peek();
                                    Console.WriteLine("El primer pedido es: {0}", primero);
                                    Console.ReadKey();

                                }
                                else
                                {
                                    Console.WriteLine("No existe la cola ingresada");
                                    Console.ReadKey();
                                }
                            }
                            catch (Exception ValueError)
                            {
                                Console.WriteLine("Por favor ingrese un número entero");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.WriteLine("No existe ninguna cola");
                            Console.ReadKey();
                        }
                        break;

                    case 8://Cantidad de pedidos
                        {

                            Console.Clear();

                            if (colas.Count() > 0)
                            {
                                PrintColas(colas);

                                Console.WriteLine("\n\nIngrese el número de la cola\n\n");

                                try
                                {
                                    int indexCola = int.Parse(Console.ReadLine());

                                    if (colas.Count > indexCola)
                                    {
                                        Console.Clear();

                                        var cola = colas.ElementAt(indexCola);

                                        Console.WriteLine(String.Format("Cola: {0}\n\n", cola.Key));

                                        Queue<int> queue = cola.Value;

                                        string nombreCola = cola.Key;


                                        int cantidad = queue.Count();
                                        Console.WriteLine("La cola {0} tiene {1} pedidos realizados", nombreCola, cantidad);
                                        Console.ReadKey();

                                    }
                                    else
                                    {
                                        Console.WriteLine("No existe la cola ingresada");
                                        Console.ReadKey();
                                    }
                                }
                                catch (Exception ValueError)
                                {
                                    Console.WriteLine("Por favor ingrese un número entero");
                                    Console.ReadKey();
                                }
                            }
                            else
                            {
                                Console.WriteLine("No existe ninguna cola");
                                Console.ReadKey();
                            }
                            break;
                        }


                    case 9:
                        {
                            Console.Clear();

                            if (colas.Count() > 0)
                            {
                                PrintColas(colas);

                                Console.WriteLine("\n\nIngrese el número de la cola que desee exportar\n\n");

                                try
                                {
                                    int listarCola = int.Parse(Console.ReadLine());

                                    if (colas.Count > listarCola)
                                    {
                                        Console.Clear();

                                        var cola = colas.ElementAt(listarCola);

                                        Console.WriteLine(String.Format("Cola: {0}\n\n", cola.Key));

                                        Queue<int> queue = cola.Value;

                                        string nombreCola = cola.Key;

                                        PrintQueue(queue);



                                        String myFile = @"ExpoQueue.txt";

                                        try
                                        {
                                            //valida si el archivo no existe lo crea
                                            if (!File.Exists(myFile))
                                            {
                                                //Se crea el archivo con el nombre indicado. Esta en modo escritura sw
                                                using (StreamWriter sw = File.CreateText(myFile))
                                                {
                                                    sw.WriteLine("Nombre de la cola: {0}", nombreCola);

                                                    foreach (int pedido in cola.Value)
                                                    {
                                                        sw.WriteLine(pedido);
                                                    }
                                                    sw.WriteLine("\nMuchas gracias por usar mi programa");
                                                    sw.Close();
                                                }

                                                Console.WriteLine("Archivo exportado exitosamente");
                                                Console.ReadKey();
                                            }
                                            //valida si el archivo existe lo sobrescribe
                                            if (File.Exists(myFile))

                                                using (StreamWriter sw = File.CreateText(myFile))
                                                {
                                                    sw.WriteLine("Nombre de la cola: {0}", nombreCola);

                                                    foreach (int pedido in cola.Value)
                                                    {
                                                        sw.WriteLine(pedido);
                                                    }
                                                    sw.WriteLine("\nMuchas gracias por usar mi programa");
                                                    sw.Close();
                                                }
                                            Console.WriteLine("\nArchivo exportado exitosamente");
                                            Console.ReadKey();
                                        }
                                        //Atrapa el error de entrada y salida
                                        catch (Exception IO)
                                        {
                                            Console.WriteLine("Error al exportar el archivo " + IO.Message);
                                        }

                                    }
                                    else
                                    {
                                        Console.WriteLine("No existe la cola ingresada");
                                        Console.ReadKey();
                                    }
                                }
                                catch(Exception ValueError)
                                {
                                    Console.WriteLine("Por favor ingrese un número entero");
                                    Console.ReadKey();
                                }

                            }
                            else
                            {
                                Console.WriteLine("No existe ninguna cola");
                                Console.ReadKey();
                            }
                            break;

                        }
                    case 10: //leer archivo
                        {
                            Console.Clear();

                            int contador = 0;
                            string linea;

                            //Hardcodeo el nombre del archivo con su extensión
                            String myFile = @"ExpoQueue.txt";
                            Console.WriteLine("");

                            try
                            { 
                                //Crea el StramReader y le paso el archivo a abrir 
                                System.IO.StreamReader file = new System.IO.StreamReader(myFile);

                                //lee linea por linea
                                while ((linea = file.ReadLine()) != null)
                                {
                                    System.Console.WriteLine(linea);
                                    contador++;
                                }
                                System.Console.ReadLine();
                                //cierra el archivo
                                file.Close();

                                
                            }
                            catch (Exception IO)
                            {
                                Console.WriteLine("Error al cargar el archivo: " + IO.Message);
                                Console.ReadKey();
                            }

                            break;
                        }
                    case 11://opción de salir
                        {
                            Console.Clear();

                            Console.WriteLine("Gracias por utilizar el programa!!");
                            Console.ReadLine();

                            break;
                        }
                }

            } while (opcion != 11);
        }

        //Función muy utilizada
        //va a mostrar los elementos de una cola particular
        static void PrintQueue(Queue<int> cola)
        {
            for (int i = 0; i <= cola.Count() - 1; i++)
            {
                var entry = cola.ElementAt(i);

                Console.WriteLine(String.Format("{0}. {1}", i, entry));
            }
        }

        //Esta función se va a utilizar muchas veces
        //Se va a utilizar para ir mostrando las colas y su índice
        static void PrintColas(Dictionary<string, Queue<int>> colas)
        {
            for (int i = 0; i <= colas.Count() - 1; i++)
            {
                var entry = colas.ElementAt(i);

                Console.WriteLine(String.Format("{0}. {1}", i, entry.Key));
            }
        }

        //función menú que devuelve un entero del 1 al 11
        static int Menu()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            //MENU PRINCIPAL
            Console.Write("Elija una opcion");
            Console.WriteLine("\n\n 1.Crear Cola \n 2.Borrar Cola \n 3.Agregar Pedido \n 4.Borrar Pedido \n 5.Listar todos los pedidos");
            Console.WriteLine(" 6.Listar último pedido \n 7.Listar primer pedido \n 8.Cantidad de pedidos \n 9.Exportar cola");
            Console.WriteLine(" 10.Cargar archivos pedidos \n 11.Salir\n");

            string returnValue = Console.ReadLine();

            int opcion;

            //Queria probar el método int.TryParse que convierte el string que agarró por lectura en un entero y lo devuelve
            //Al principio se me habia ocurrido el que estaba comentado 
            if (int.TryParse(returnValue, out opcion))
            {
                return opcion;
            }
            else
            {
                return 0;
            }

            /*try
            {
                int opcion = int.Parse(Console.ReadLine());

                return opcion;
            }
            catch (Exception e)
            {
                return 0;
            }*/
        }

    }
}