using System;
class Programm
{
    static double[] remplir(out int n)
    {
        double[] t = new double[100];
        n = 0;

        Console.WriteLine("Entrer les notes ( -1 pour arrêter ) :");
        double x = double.Parse(Console.ReadLine());

        while ((x >= 0) && (x <= 20))
        {
            t[n] = x;
            n++;
            x = double.Parse(Console.ReadLine());
        }

        return t;
    }

    static void afficher(double[] t, int n)
    {
        for (int i = 0; i < n; i++)
        {
            Console.Write(t[i] + "  ");
        }
        Console.WriteLine();
    }

    static double somme(double[] t, int n)
    {
        double s = 0;
        for (int i = 0; i < n; i++)
            s = s + t[i];

        return s;
    }

    static double moyenne(double[] t, int n)
    {
        return somme(t, n) / n;
    }

    static double max(double[] t, int n)
    {
        double max = t[0];
        for (int i = 1; i < n; i++)
        {
            if (t[i] > max) max = t[i];
        }
        return max;
    }

    static double min(double[] t, int n)
    {
        double min = t[0];
        for (int i = 1; i < n; i++)
        {
            if (t[i] < min) min = t[i];
        }
        return min;
    }

    static bool rechercheSeq(double[] t, int n, double x)
    {
        int i = 0;
        bool f = false;

        while (i < n && !f)
        {
            if (t[i] == x)
                f = true;

            i++;
        }
        return f;
    }

    
    static double[] tri(double[] t, int n)
    {
        bool permut;
        do
        {
            permut = false;
            for (int i = 0; i < n - 1; i++)   
            {
                if (t[i] > t[i + 1])
                {
                    double temp = t[i];
                    t[i] = t[i + 1];
                    t[i + 1] = temp;   
                    permut = true;
                }
            }
        } while (permut);

        return t;
    }

    static bool rechercheDicho(double[] t, int n, double x)
    {
        int debut = 0;
        int fin = n - 1;

        while (debut <= fin)
        {
            int milieu = (debut + fin) / 2;

            if (t[milieu] == x)
                return true;

            if (x > t[milieu])
                debut = milieu + 1;
            else
                fin = milieu - 1;
        }

        return false;
    }
    static void Main()
    {
        int n;
        double[] t = remplir(out n);

        Console.WriteLine($"Somme : {somme(t, n):F2}");
        Console.WriteLine($"Moyenne : {moyenne(t, n):F2}");
        Console.WriteLine($"Maximum : {max(t, n):F2}");
        Console.WriteLine($"Minimum : {min(t, n):F2}");

        Console.WriteLine("Donner une note à rechercher :");
        double x = double.Parse(Console.ReadLine());

        if (rechercheSeq(t, n, x))
            Console.WriteLine("Existe");
        else
            Console.WriteLine("N'existe pas");

        Console.WriteLine("Le tableau trié :");
        t = tri(t,n);
        afficher(t,n);

        Console.WriteLine("Recherche avec Dicho");
        if (rechercheDicho(t, n, x))
            Console.WriteLine("Existe ");
        else
            Console.WriteLine("N'existe pas ");
    }
}
