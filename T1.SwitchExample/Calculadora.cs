using System;

namespace ExempleSwitch
{
    public class Program
    {
        /* Crear una calculadora amb 4 operacions:
             * 0. Suma
             * 1. Resta
             * 2. Multiplicació
             * 3. Divisió
             * Per crearla s'ha d'escullir entre les 4 opcions i
             * inserir dos operants.
             * 
             * Nota: les dades estan fetes amb dos formes diferents de conversions de tipus i de controlar els errors
             * */
        public static void Main()
        {
            const string MenuMsg = "Calculadora \n0. Suma \n1. Resta \n2. Multiplicació \n3. Divisió";
            const string StatementMsg = "Introdueix una opció";
            const string OperandsMsg = "Indrodueix els dos operants. Un per linia. Admet decimals.";

            int userOption = -1;
            double operant0, operant1, result;
            bool isCorrect = false;
            char operationSelected = ' ';
            operant0 = operant1 = result = 0;


            Console.WriteLine(MenuMsg);
            Console.WriteLine(StatementMsg);

            do
            {
                isCorrect = int.TryParse(Console.ReadLine(), out userOption);

                if (!isCorrect || !(userOption >= 0 && userOption <= 3)) //Estic mirant dins del rang! Feu el mateix mirant fora del rang del menú
                {
                    Console.WriteLine("Format o numero incorrecte. Torna a intentar");
                }
            } while (!isCorrect || !(userOption >= 0 && userOption <= 3));


            Console.WriteLine(OperandsMsg);
            try
            {
                operant0 = Convert.ToDouble(Console.ReadLine());
                operant1 = Convert.ToDouble(Console.ReadLine());

            }
            catch (FormatException)
            {
                Console.WriteLine("No has introduït un número decimal correctament");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Es un valor masa gran");
            }
            catch (Exception)
            {
                Console.WriteLine("Error inesperat");
            }

            switch (userOption)
            {
                case 0:
                    result = operant0 + operant1;
                    operationSelected = '+';
                    break;
                case 1:
                    result = operant0 - operant1;
                    operationSelected = '-';
                    break;
                case 2:
                    result = operant0 * operant1;
                    operationSelected = '*';
                    break;
                case 3:
                    result = operant0 / operant1;
                    operationSelected = '/';
                    break;
                default:
                    result = 0;
                    operationSelected = '?';
                    Console.WriteLine("Error en l'opció introduida");
                    break;
            }

            Console.WriteLine("El resultat de l'operació \n \t {0} {1} {2} = {3}", operant0, operationSelected, operant1, result);
        }
    }
}
