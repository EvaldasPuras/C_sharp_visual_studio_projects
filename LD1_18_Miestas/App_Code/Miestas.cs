using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

public class Miestas
{
    const int CN = 20;
    char[,] mat = new char[CN, CN];
    char[,] kopi = new char[CN, CN];
    int[] x1 = new int[CN * CN]; // Frontai
    int[] y1 = new int[CN * CN]; // Frontai
    int[] x2 = new int[CN * CN]; // Frontai
    int[] y2 = new int[CN * CN]; // Frontai
    int n1, n2;
    int nn;
    int vx, vy;
    int gx = -1, gy = -1;
    int kv;

    public Miestas()
    {

    }

    public void Skaityti(string fv)
    {
        for (int i = 0; i < CN; i++)
            for (int j = 0; j < CN; j++)
                mat[i, j] = '1';
        string[] lines = File.ReadAllLines(fv);
        nn = lines.Length - 1;
        string line0 = lines[0];
        string[] parts = line0.Split(' ');
        vx = Convert.ToInt32(parts[1]);
        vy = Convert.ToInt32(parts[2]);
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            for (int j = 1; j <= nn; j = j + 1)
                mat[i, j] = line[j - 1];
        }
        for (int i = 0; i < CN; i++) // Duomenų kopija
            for (int j = 0; j < CN; j++)
                kopi[i, j] = mat[i, j];
        //vienetai kvartalo viduryje, negalima pereiti
        for (int i = 2; i <= nn; i += 4)
            for (int j = 4; j <= nn; j += 4)
                mat[i, j] = '1';
        for (int i = 4; i <= nn; i += 4)
            for (int j = 2; j <= nn; j += 4)
                mat[i, j] = '1';
        kopi[vx, vy] = mat[vx, vy] = 'Ž';
    }

    public void Spausdinti(string fv)
    {
        using (StreamWriter fr = new StreamWriter(fv))
        {
            for (int i = 1; i <= nn; i++)
            {
                for (int j = 1; j <= nn; j++)
                    fr.Write("{0}", kopi[i, j]);
                fr.WriteLine();
            }
            if (gx != -1)
                if (gx != 0)
                {
                    fr.WriteLine("Kvartalų skaičius iki gėlių: {0}",
                    kv);
                    if (kv > 5)
                        if (gx != -1)
                            if (gx != 0)
                            {
                                fr.WriteLine("Parduotuvė yra už {0} kvartalų", kv);
                                if (kv > 5)
                                    fr.WriteLine("Deja, kelias per ilgas iki gėlių");
                                else
                                    fr.WriteLine("*** Rastų gėlių vieta {0} {1}", gx, gy);
                            }
                            else
                                fr.WriteLine("Kelio iki gėlių parduotuvės nėra");
                }
        }
    }

    public void Kelias()
    {
        int i, j;
        bool yra = false;
        n2 = 1;
        gx = gy = 0; // pradedam
        x2[n2] = vx; y2[n2] = vy;
        while (!yra && n2 != 0)
        {
            for (i = 1; i <= n2; i++)
            { // Ankstesnis frontas tampa pradiniu
                x1[i] = x2[i]; y1[i] = y2[i];
            }
            n1 = n2; // Ankstesnio fronto skaitliukas
            n2 = 0; // Naujas frontas valomas
            while (n1 > 0 && !yra)
            {
                while (n1 > 0 && !yra)
                {
                    i = x1[n1];
                    j = y1[n1];
                    n1 = n1 - 1;
                    if (!yra) Padeti(i - 1, j, ref yra, 'v');
                    if (!yra) Padeti(i, j + 1, ref yra, 'd');
                    if (!yra) Padeti(i + 1, j, ref yra, 'a');
                    if (!yra) Padeti(i, j - 1, ref yra, 'k');
                }
            }
            if (gx != 0)
            {
                Trasa(); // Surasto kelio pažymėjimas
                Kvartalai(); // Kvartalų skaičiavimas
            }
        }
    }

    private void Padeti(int i, int j, ref bool yra, char sim)
    {
        if (mat[i, j] == 'G')
        {
            yra = true;
            gx = i; gy = j;
        } // Tikslas pasiektas
        else
        if (mat[i, j] == '0')
        {
            n2++;
            x2[n2] = i; y2[n2] = j;
            mat[i, j] = sim;
        }
        else // Gatvė. Ar galima pereiti? Ar perėjus yra G?
        if (mat[i, j] == '.')
        {
            if (sim == 'v')
                if (mat[i - 1, j] == '0')
                {
                    mat[i, j] = sim; mat[i - 1, j] = sim;
                    n2++;
                    x2[n2] = i - 1; y2[n2] = j;
                }
                else
                if (mat[i - 1, j] == 'G')
                {
                    yra = true;
                    gx = i - 1; gy = j;
                    mat[i, j] = sim;
                }
            if (sim == 'd')
                if (mat[i, j + 1] == '0')
                {
                    mat[i, j] = sim; mat[i, j + 1] = sim;
                    n2++;
                    x2[n2] = i; y2[n2] = j + 1;
                }
                else
                if (mat[i, j + 1] == 'G')
                {
                    yra = true;
                    gx = i; gy = j + 1;
                    mat[i, j] = sim;
                }
            if (sim == 'a')
                if (mat[i + 1, j] == '0')
                {
                    mat[i, j] = sim; mat[i + 1, j] = sim;
                    n2++;
                    x2[n2] = i + 1; y2[n2] = j;
                }
                else
                if (mat[i + 1, j] == 'G')
                {
                    yra = true;
                    gx = i + 1; gy = j;
                    mat[i, j] = sim;
                }
            if (sim == 'k')
                if (mat[i, j - 1] == '0')
                {
                    mat[i, j] = sim; mat[i, j - 1] = sim;
                    n2++;
                    x2[n2] = i; y2[n2] = j - 1;
                }
                else
                if (mat[i, j - 1] == 'G')
                {
                    yra = true;
                    gx = i; gy = j - 1;
                    mat[i, j] = sim;
                }
        }
    }

    private void Trasa()
    {
        int i, j;
        char sim;
        i = gx; j = gy;
        kopi[i, j] = 'K'; // Gelių parduotuvė
        if (mat[i - 1, j] == 'a')
            i--;
        else
        if (mat[i + 1, j] == 'v')
            i++;
        else
        if (mat[i, j + 1] == 'k')
            j++;
        else
            j--;
        sim = mat[i, j];
        kopi[i, j] = 'K';
        while ((i != vx) || (j != vy))
        {
            if (sim == 'v')
                i++;
            else
            if (sim == 'a')
                i--;
            else
            if (sim == 'k')
                j++;
            else
                j--;
            kopi[i, j] = 'K';
            sim = mat[i, j];
        }
    }

    private void Kvartalai()
    {
        kv = 0;
        for (int i = 1; i <= nn; i += 4)// Horizontalūs viršutiniai kvartalai
        {
            for (int j = 1; j <= nn; j += 4)
            {
                if (kopi[i, j] == 'K' && kopi[i, j + 1] == 'K' && kopi[i, j + 2] == 'K')
                {
                    kv++;
                }
            }
        }
        for (int i = 3; i <= nn; i += 4)// Horizontalūs apatiniai kvartalai
        {
            for (int j = 1; j <= nn; j += 4)
            {
                if (kopi[i, j] == 'K' && kopi[i, j + 1] == 'K' && kopi[i, j + 2] == 'K')
                {
                    kv++;
                }
            }
        }
        for (int j = 1; j <= nn; j += 4)// Vertikalūs kairiniai kvartalai
        {
            for (int i = 1; i <= nn; i += 4)
            {
                if (kopi[i, j] == 'K' && kopi[i + 1, j] == 'K' && kopi[i + 2, j] == 'K')
                {
                    kv++;
                }
            }
        }
        for (int j = 3; j <= nn; j += 4)// Vertikalūs dešininiai kvartalai
        {
            for (int i = 1; i <= nn; i += 4)
            {
                if (kopi[i, j] == 'K' && kopi[i + 1, j] == 'K' && kopi[i + 2, j] == 'K')
                {
                    kv++;
                }
            }
        }
    }
}