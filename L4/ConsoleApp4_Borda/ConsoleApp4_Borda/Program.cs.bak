using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4_Borda
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0; //индекс
            int j = 0; //индекс
            int k = 0; //индекс
            int N; //количество участников
            string vod;  //ввод приоритета игроками  и кому отдать приоритет       
            int[] arr = new int[0];//массив приоритетов игр
            int[] arr2 = new int[0];//массив игр с одинаковым максимальным приоритетом (парадокс)

            Console.WriteLine("Сколько человек будет голосовать за выбор телефона?");
            N = Convert.ToInt32(Console.ReadLine());
            int[,] input = new int[Convert.ToInt32(N), 3]; //входной массив            
            for (i = 0; i < (Convert.ToInt32(N)); i++)
            {
                j = 0;
                Console.WriteLine("Участник " + (i + 1) + " расставьте приоритет (Дорогой айфон, Дорогой андроид, Дешевый телефон) от 1 до 3");

                Console.WriteLine("Дорогой айфон:");
                vod = Console.ReadLine();
                if (Convert.ToInt32(vod) == 1)
                    input[i, j] = input[i, j] + 3;
                else if (Convert.ToInt32(vod) == 2)
                    input[i, j] = input[i, j] + 2;
                else if (Convert.ToInt32(vod) == 3)
                    input[i, j] = input[i, j] + 1;

                j++;

                Console.WriteLine("Дорогой андроид:");
                vod = Console.ReadLine();
                if (Convert.ToInt32(vod) == 1)
                    input[i, j] = input[i, j] + 3;
                else if (Convert.ToInt32(vod) == 2)
                    input[i, j] = input[i, j] + 2;
                else if (Convert.ToInt32(vod) == 3)
                    input[i, j] = input[i, j] + 1;

                j++;

                Console.WriteLine("Дешевый телефон:");
                vod = Console.ReadLine();
                if (Convert.ToInt32(vod) == 1)
                    input[i, j] = input[i, j] + 3;
                else if (Convert.ToInt32(vod) == 2)
                    input[i, j] = input[i, j] + 2;
                else if (Convert.ToInt32(vod) == 3)
                    input[i, j] = input[i, j] + 1;

                j++;

            }


            Array.Resize(ref arr, arr.Length + 3);
            for (i = 0; i < N; i++)
                for (j = 0; j < 3; j++)
                    arr[j] = arr[j] + input[i, j];

            k = Array.IndexOf(arr, arr.Max());

            for (i = 0; i < 3; i++)
                if (arr[i] == arr.Max())
                {
                    Array.Resize(ref arr2, arr2.Length + 1);
                    arr2[i] = i;
                }
                else i++;
            if (arr2.Length > 1)
            {
                Console.Write("Парадокс. Несколько игр имеют одинаковый приоритет. Номера игр с одинаковым приоритетом: ");
                for (i = 0; i < arr2.Length; i++)
                    Console.Write((arr2[i] + 1) + " ");
            }
            else
                Console.WriteLine("Максимальное количество очков набрал телефон: " + (k + 1));



            Console.ReadLine();
        }
    }
}