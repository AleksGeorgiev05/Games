using System;
using System.Runtime.CompilerServices;
using System.Threading;
namespace TIC_TAC_TOE
{
    class Program
    {
        //Прави се масив и по подразбиране се предоставя 0-9, където не се използва нула
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1; //По подразбиране е Играч 1
        static int choice; //Това съдържа избора на коя позиция потребителят иска да маркира
        static int flag = 0;
        //Променливата флаг проверява кой е спечелил, ако стойността й е 1, значи някой е спечелил мача
        //Ако -1, тогава мачът има равенство, ако 0, тогава мачът продължава
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();//Всеки път, когато цикълът започне отново, екранът ще бъде изчистен
                Console.WriteLine("Player 1 : X and Player 2 : O");
                Console.WriteLine("\n");
                if (player % 2 == 0)//Проверява се ходът на играча
                {
                    Console.WriteLine("Player 2 Turn");
                }
                else
                {
                    Console.WriteLine("Player 1 Turn");
                }
                Console.WriteLine("\n");
                Board();//Извикваме функцията Дъска
                choice = int.Parse(Console.ReadLine());//Взимаме избора на играча
                //Проверка дали позицията, в която потребителят иска да бяга, е маркирана (с X или O) или не
                if (arr[choice] != 'X' && arr[choice] != 'O')
                {
                    if (player % 2 == 0) //Ако Играч 2 е на ход, маркирайте О, иначе маркирайте Х
                    {
                        arr[choice] = 'O';
                        player++;
                    }
                    else
                    {
                        arr[choice] = 'X';
                        player++;
                    }
                }
                else
                //Ако има някаква позиция, на която потребителят иска да бяга и вече е маркирана
                //, се показва съобщение и таблото зарежда отново 
                {
                    Console.WriteLine($"Sorry the row {choice} is already marked with {arr[choice]}");
                    Console.WriteLine("\n");
                    Console.WriteLine("Please wait 2 second board is loading again.....");
                    Thread.Sleep(2000);
                }
                flag = CheckWin();//Викане на метода за проверка за победа
            }
            while (flag != 1 && flag != -1);
            //Този цикъл ще върви, докато всички клетки не за маркирани с Х или О или някой не победи
            Console.Clear();//Изчиства конзолата
            Board();//Запълва дъската отново
            if (flag == 1)
            //Ако стойността на флага е 1, някой е победил
            {
                Console.WriteLine($"Player {(player % 2) + 1} has won");
            }
            else//Ако стойността на флага е -1, никой не е победил или е равенство
            {
                Console.WriteLine("Draw");
            }
            Console.ReadLine();
        }
        //Метод за дъската, който създава дъска
        private static void Board()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {arr[1]}  |  {arr[2]}  |  {arr[3]}");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {arr[4]}  |  {arr[5]}  |  {arr[6]}");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {arr[7]}  |  {arr[8]}  |  {arr[9]}");
            Console.WriteLine("     |     |      ");
        }
        //Метод, който проверява за победа
        private static int CheckWin()
        {
            #region за хоризонтална победа
            //Условие за победа на 1-ви ред
            if (arr[1] == arr[2] && arr[2] == arr[3])
            {
                return 1;
            }
            //Условие за победа на 2-ри ред
            else if (arr[4] == arr[5] && arr[5] == arr[6])
            {
                return 1;
            }
            //Условие за победа на 3-ти ред
            else if (arr[7] == arr[8] && arr[8] == arr[9])
            {
                return 1;
            }
            #endregion
            #region за вертикална победа
            //Условие за победа на 1-ва колона
            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return 1;
            }
            //Условие за победа на 2-ра колона
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return 1;
            }
            //Условие за победа на 3-та колона
            else if (arr[3] == arr[6] && arr[6] == arr[9])
            {
                return 1;
            }
            #endregion
            #region за диагонална победа
            else if (arr[1] == arr[5] && arr[5] == arr[9])
            {
                return 1;
            }
            else if (arr[3] == arr[5] && arr[5] == arr[7])
            {
                return 1;
            }
            #endregion
            #region проверява за равенство
            //Ако всички клетки или стойности са попълнени с X или O, тогава всеки играч е спечелил мача
            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
            {
                return -1;
            }
            #endregion
            else
            {
                return 0;
            }
        }
    }
}