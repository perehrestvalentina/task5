using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication54
{
    class Program
    {
        static string FillUniqueLetters(string input)
        {
            string result = input[0].ToString();

            for (int i = 1; i < input.Length; i++)
            {
                bool flag = true;

                for (int j = 0; j < result.Length; j++)
                {
                    if (input[i] == result[j] || Convert.ToInt32(input[i]) >= 32 && Convert.ToInt32(input[i]) <= 64)
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag) result += input[i];
            }

            return result;
        }
        static string GetWordsOfArray(string[] str)
        {
            string result = "";

            for (int i = 0; i < str.Length; i++)
            {
                if (i == str.Length - 1)
                {
                    result += str[i];
                }
                else result += str[i] + ", ";
            }

            return result;
        }
        static void FindCountOfWords(string uniqueLetters, string[] diary)
        {
            int count_of_words = 0; // Сюда мы будем записывать количетсво слов

            foreach (string word in diary) // Проверяем словарь и наши уникальные буквы
            {
                int count_of_letters = 0;

                for (int i = 0; i < word.Length; i++)
                {
                    bool flag = false;

                    for (int j = 0; j < uniqueLetters.Length; j++)
                    {
                        if (word[i] == uniqueLetters[j])
                        {
                            flag = true; // ставим флаг true, если мы нашли нужную букву
                            break;
                        }
                    }

                    if (flag)
                    {
                        count_of_letters++;
                    }
                    else
                    {
                        count_of_letters = 0; // обнуляем, если не нашли и идем заново с другим словом словаря
                        break;
                    }
                }

                if (count_of_letters == word.Length) // в конце, если наше количество уникальных букв совпадает с количеством этих букв в слова, то выводим его и увеличиваем счетчик слов
                {
                    count_of_words++;
                    Console.WriteLine(word);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Количество слов: " + count_of_words);
        }
        public static void Main(string[] args)
        {
            // У нас есть строка, из который мы берем все буквы и закидываем их в uniqueLetters таким образом, что они не повторяются
            string input = "Lorem, ipsum.";

            // это массив из слов, которые мы должны проверить - можно ли из тех букв что у нас в uniqueLetters, построить эти слова
            string[] diary = { "de", "lor", "loria", "ipsu" };

            input = input.ToLower();

            string uniqueLetters = FillUniqueLetters(input); // здесь все буквы записаны просто, как одна строка

            // Выводим то, что у нас есть
            Console.WriteLine("Введено: " + input);
            Console.WriteLine("Уникальные буквы: " + uniqueLetters);
            Console.WriteLine("Словарь слов: " + GetWordsOfArray(diary));

            // Выводим то, что нам нужно найти
            Console.WriteLine();
            Console.WriteLine("Список найденных слов:");
            FindCountOfWords(uniqueLetters, diary);
            Console.ReadKey();
        }

    }
}