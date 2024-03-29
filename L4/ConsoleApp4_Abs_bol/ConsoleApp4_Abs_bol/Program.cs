﻿namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int i ; //индекс
            int N; //количество участников
            int k ; //индекс игры с максимальным количеством голосов
            string vod;  //ввод приоритета игроками  и кому отдать приоритет       
            int[] arr = new int[0];//массив данных выбора каждого игрока
            int[] arr1 = new int[0];//массив данных c количеством голосов за каждую игру
            int[] arr2 = new int[0];//массив игр с одинаковым максимальным количеством голосов (парадокс)

            Console.WriteLine("Сколько человек будет голосовать за выбор телефона?");
            N = Convert.ToInt32(Console.ReadLine()); //Коли-во человек
            Array.Resize(ref arr, N); // Создаеться массив для N-ого кол-ва человек

            for (i = 0; i < N; i++)  //цикл перебора каждого человека
            {
                Console.WriteLine("Участник " + (i + 1) + " выберите телефон (1.Дорогой айфон, 2.Дорогой андроид, 3.Дешевый телефон) от 1 до 3");
                vod = Console.ReadLine();
                arr[i] = Convert.ToInt32(vod); //готовый массив с выбором каждого человека
            }



            Array.Resize(ref arr1, 3);//массив выбора каждого человека с вариантами голосвания 
            for (i = 0; i < N; i++)  //перебор массива
                arr1[arr[i] - 1] = arr1[arr[i] - 1] + 1; 

            k = Array.IndexOf(arr1, arr1.Max()); //нахождение максимальных значений 

            for (i = 0; i < 3; i++) //перебор каждого варианта 
            {
                if (arr1[i] == arr1.Max()) //если вариант = максимум
                {
                    Array.Resize(ref arr2, arr2.Length + 1); //+1
                    arr2[i] = i; //массив телефона с максимумом
                }
                else i++; //если не равен максимуму 
            }
            if (arr2.Length > 1) 
            {
                Console.Write("Парадокс. Несколько игр имеют одинаковое количество голосов. Номера игр с одинаковым количеством голосов: ");
                for (i = 0; i < arr2.Length; i++)
                    Console.Write((arr2[i] + 1) + " ");
            }
            else
                Console.WriteLine("Победила игра с номером: " + (k + 1));


            Console.ReadLine();
        }
    }
}