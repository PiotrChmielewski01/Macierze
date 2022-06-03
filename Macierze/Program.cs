using System;

namespace Macierze
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n|||Program wykonuje operacje na macierzach|||\n");

            Zadania zad1 = new Zadania();
            zad1.Rozmiar();
            zad1.macierz = new int[zad1.x,zad1.y];
            zad1.Pobranie();
            zad1.Wyswietlenie();

            int wybor;
            char koniec = 'n';
            while(koniec == 'n')
            {
                Console.Write("\nWybierz numer:\n1 - dodawanie macierzy\n2 - transponowanie macierzy\n3 - mnożenie macierzy przez liczbę lub inną macierz\n4 - wyznacznik macierzy(tylko dla macierzy 2x2 i 3x3)\n");
                wybor = Int32.Parse(Console.ReadLine());
            
                switch (wybor)
                {
                    case 1:
                        zad1.Dodawanie();
                        break;
                    case 2:
                        zad1.Transponowanie();
                        break;
                    case 3:
                        zad1.Mnozenie();
                        break;
                    case 4:
                        zad1.Wyznacznik();
                        break;
                    default:
                        Console.Write("Nie ma takiego numeru");
                        break;
                }
                Console.Write("\nKończymy(t/n)?\n");
                koniec = Char.Parse(Console.ReadLine());
            }
            
        }

        
        class Zadania
        {

            public int x, y;
            public int[,] macierz;


            public void Rozmiar()                                    ///////Zadeklarowanie rozmiaru macierzy
            {
                Console.Write("Podaj ilość wierszy macierzy: ");
                y = Int32.Parse(Console.ReadLine());

                Console.Write("Podaj ilość kolumn macierzy: ");
                x = Int32.Parse(Console.ReadLine());
            }

            public void Pobranie()                                   ///////Pobieranie od uzytkownika
            {
                Console.WriteLine();
                for (int j = 0; j < y; j++)
                {
                    for (int i = 0; i < x; i++)
                    {
                        Console.Write("Podaj wyraz dla wiersza {0} kolumny {1}: ", j + 1, i + 1);
                        macierz[i, j] = Int32.Parse(Console.ReadLine());
                        Console.WriteLine();
                    }
                }
            }

            public void Wyswietlenie()                               ///////Wyswietlanie macierzy
            {

                Console.WriteLine("\nTwoja macierz:\n");

                for (int j = 0; j < y; j++)
                {
                    for (int i = 0; i < x; i++)
                    {
                        Console.Write(macierz[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
            }

            public void Mnozenie()                                   ///////Mnozenie macierzy przez liczbe lub inna macierz
            {
                int s;
                Console.Write("Wybierz 1 aby pomnożyć przez liczbę\nWybierz 2 aby pomnożyć przez macierz\n");
                s = Int32.Parse(Console.ReadLine());

                switch (s)
                {
                    case 1:
                        int a;
                        Console.Write("Podaj liczbę przez którą chcesz pomnożyc macierz: ");
                        a = Int32.Parse(Console.ReadLine());
                        for (int j = 0; j < y; j++)
                        {
                            for (int i = 0; i < x; i++)
                            {
                                macierz[i, j] *= a;
                            }
                        }
                        Console.WriteLine("\nTwoja macierz:\n");

                        for (int j = 0; j < y; j++)
                        {
                            for (int i = 0; i < x; i++)
                            {
                                Console.Write(macierz[i, j] + "\t");
                            }
                            Console.WriteLine();
                        }
                        break;


                    case 2:
                        int x1, y1;
                        { 
                            Console.Write("Podaj ilość wierszy macierzy: ");
                            y1 = Int32.Parse(Console.ReadLine());

                            Console.Write("Podaj ilość kolumn macierzy: ");
                            x1 = Int32.Parse(Console.ReadLine());
                        }

                        if(x == y1)
                        {
                            int[,] macierz2 = new int[x1, y1];
                            Console.Write("Podaj macierz przez którą chcesz pomnożyć\n");
                            for (int j = 0; j < y1; j++)
                            {
                                for (int i = 0; i < x1; i++)
                                {
                                    Console.Write("Podaj wyraz dla wiersza {0} kolumny {1}: ", j + 1, i + 1);
                                    macierz2[i,j] = Int32.Parse(Console.ReadLine());
                                    Console.WriteLine();
                                }
                            }

                            int[,] macierz3 = new int[x1, y];

                            int my = 0;
                            for (int j = 0; j < y; j++)
                            {
                                int mx=0;
                                for (int i = 0; i < x1; i++)
                                {
                                    macierz3[i, j] = 0;

                                    int ax = 0, ay = 0;
                                    for(int k = 0; k < x; k++)
                                    {
                                        macierz3[i, j] += macierz[ax,my] * macierz2[mx,ay];

                                        ax++;
                                        ay++;

                                    }
                                    
                                    mx++;
                                }
                                my++;
                            }

                            Console.WriteLine("\nTwoja macierz:\n");

                            for (int j = 0; j < y; j++)
                            {
                                for (int i = 0; i < x1; i++)
                                {
                                    Console.Write(macierz3[i, j] + "\t");
                                }
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Pomnożenie przez macierz o podanych wymiarach nie jest możliwe");
                        }

                        break;

                    default:
                        Console.WriteLine("Nie wybrałeś 1 lub 2");
                        break;
                }
                
            }

            public void Dodawanie()
            {
                int a;
                int[,] macierz2 = new int[x,y];
                Console.Write("Podaj macierz którą chcesz dodać (musi być tych samych wymiarów czyli {0}x{1})\n", y, x);
                for (int j = 0; j < y; j++)
                {
                    for (int i = 0; i < x; i++)
                    {
                        Console.Write("Podaj wyraz dla wiersza {0} kolumny {1}: ", j + 1, i + 1);
                        a = Int32.Parse(Console.ReadLine());
                        macierz2[i, j] = macierz[i, j] + a; 
                        Console.WriteLine();
                    }
                }

                Console.WriteLine("\nTwoja macierz:\n");

                for (int j = 0; j < y; j++)
                {
                    for (int i = 0; i < x; i++)
                    {
                        Console.Write(macierz2[i, j] + "\t");
                    }
                    Console.WriteLine();
                }

            }                               ///////Dodawanie do siebie dwoch macierzy

            public void Transponowanie()
            {
                int[,] macierztran = new int[x,y];
                int y2 = 0;
                for (int j = 0; j < y; j++)
                {
                    int x2 = 0;
                    for (int i = 0; i < x; i++)
                    {
                        macierztran[y2,x2] = macierz[i, j];
                        x2++;
                    }
                    y2++;
                }

                Console.WriteLine("\nTwoja macierz transponowana:\n");

                for (int j = 0; j < y; j++)
                {
                    for (int i = 0; i < x; i++)
                    {
                        Console.Write(macierztran[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
            }                          ///////Transponowanie macierzy

            public void Wyznacznik()                                 ////////Obliczanie wyznacznika macierzy
            {
                int wyznacznik;
                if(x == 2 && y == 2 || x == 3 && y == 3)
                {
                    if (x == 2)
                    {
                        wyznacznik = macierz[0, 0] * macierz[1, 1] - macierz[0, 1] * macierz[1, 0];
                        Console.WriteLine("Wyznacznik tej macierzy to: {0}", wyznacznik);
                    }
                    else
                    {
                        wyznacznik = macierz[0, 0] * macierz[1, 1] * macierz[2, 2] + macierz[1, 0] * macierz[2, 1] * macierz[0, 2]
                         + macierz[2, 0] * macierz[0, 1] * macierz[1, 2] - macierz[2, 0] * macierz[1, 1] * macierz[0, 2]
                         - macierz[0, 0] * macierz[2, 1] * macierz[1, 2] - macierz[1, 0] * macierz[0, 1] * macierz[2, 2];
                        Console.WriteLine("Wyznacznik tej macierzy to: {0}", wyznacznik);
                    }   
                }
                else
                {
                    Console.WriteLine("Podana macierz nie jest macierzą 2x2 lub 3x3");
                }
                
            }                              

        }




    } 
}
