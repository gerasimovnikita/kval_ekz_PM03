﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace kval_ekz
{
    class Program
    {
        private static int arrSize = 0;
        private static Book[] Library;
        static void Main(string[] args)
        {
            ReadArrSize();
            Library = new Book[arrSize];
            FillLibrary();
            SortLibrary();
            FileWork();
            Console.WriteLine("Массив Library был записан в текстовый файл");
            Console.ReadKey();
        }
        private static void ReadArrSize()
        {
            Console.WriteLine("Введите целочисленный размер массива");
            string read = Console.ReadLine();
            while(!Int32.TryParse(read, out arrSize))
            {
                Console.WriteLine("Некорректный ввод, повторите");
                read = Console.ReadLine();
            }
        }
        private static void FillLibrary()
        {
            for(int i=0; i < Library.Length; i++)
            {
                Console.WriteLine("Заполните " + (i + 1) + "й элемент массива");
                Library[i] = new Book();
                Console.WriteLine("Введите название книги");
                string name = Console.ReadLine();
                while (name.Length == 0)
                {
                    Console.WriteLine("Нельзя вводить пустые строки");
                    name = Console.ReadLine();
                }
                Library[i].Name = name;

                Console.WriteLine("Введите автора книги");
                string author = Console.ReadLine();
                while (author.Length == 0)
                {
                    Console.WriteLine("Нельзя вводить пустые строки");
                    author = Console.ReadLine();
                }
                while (HasStrDigits(author))
                {
                    Console.WriteLine("Имя автора не может содержать цифр");
                    author = Console.ReadLine();
                }
                Library[i].Author = author;

                Console.WriteLine("Введите жанр книги");
                string genre = Console.ReadLine();
                while (genre.Length == 0)
                {
                    Console.WriteLine("Нельзя вводить пустые строки");
                    genre = Console.ReadLine();
                }
                while (HasStrDigits(genre))
                {
                    Console.WriteLine("Жанр не может содержать цифр");
                    genre = Console.ReadLine();
                }
                Library[i].Genre = genre;
            }
        }
        private static void SortLibrary()
        {
            Library.OrderBy(l => l.Genre).ThenBy(l => l.Author).ThenBy(l => l.Name).ToArray();
        }
        private static void FileWork()
        {
            using(StreamWriter sw = new StreamWriter("file.txt"))
            {
                foreach (Book book in Library)
                {
                    sw.WriteLine(book.Name + "; " + book.Author + "; " + book.Genre);
                }
                sw.Close();
            }
        }

        private static bool HasStrDigits(string str)
        {
            bool response = false;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= '0' && str[i] <= '9')
                {
                    response = true;
                }
            }
            return response;
        }
    }
}