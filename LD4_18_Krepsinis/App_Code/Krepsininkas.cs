using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;

public class Krepsininkas : IComparable<Krepsininkas>, IEquatable<Krepsininkas>
{
    public string KomandosPavadinimas { get; set; }
    public string Pavarde { get; set; }
    public string Vardas { get; set; }
    public string Pozicija { get; set; }
    public int ZaistaMinuciu { get; set; }
    public int PelnytaTasku { get; set; }
    public int PadarytaKlaidu { get; set; }

    public Krepsininkas(string komandosPavadinimas, string pavarde, string vardas, string pozicija)
    {
        KomandosPavadinimas = komandosPavadinimas;
        Pavarde = pavarde;                          //Konstruktorius
        Vardas = vardas;
        Pozicija = pozicija;
    }

    public void PridetiRezultatus(int minuciu, int tasku, int klaidu)
    {
        ZaistaMinuciu = minuciu;    //Krepšininkui pridedami rungtynių rezultatai
        PelnytaTasku = tasku;
        PadarytaKlaidu = klaidu;
    }

    public int CompareTo(Krepsininkas obj) //IComparable sąsajai pritaikyta funkcija
    {
        Krepsininkas other = obj;
        if (this < other)
        {
            return 1;
        }
        else if (this > other)
        {
            return -1;
        }
        else
            return 0;
    }

    public bool Equals(Krepsininkas other) //IEquatable sąsajai pritaikyta funkcija
    {
        if (other == null)
            return false;
        if (this.KomandosPavadinimas == other.KomandosPavadinimas && this.Pavarde == other.Pavarde &&
            this.Vardas == other.Vardas)
            return true;
        else
            return false;
    }

    public static bool operator >(Krepsininkas k1, Krepsininkas k2) //Palyginimo operatorius
    {
        if (k1.PelnytaTasku > k2.PelnytaTasku)
        {
            if (k1.ZaistaMinuciu < k2.ZaistaMinuciu)
            {
                if(k1.PadarytaKlaidu < k1.PadarytaKlaidu)
                {
                    return true;
                }
                return true;
            }
            return true;
        }
        return false;
    }

    public static bool operator <(Krepsininkas k1, Krepsininkas k2) //Palyginimo operatorius
    {
        if (k1.PelnytaTasku < k2.PelnytaTasku)
        {
            if (k1.ZaistaMinuciu > k2.ZaistaMinuciu)
            {
                if (k1.PadarytaKlaidu > k1.PadarytaKlaidu)
                {
                    return true;
                }
                return true;
            }
            return true;
        }
        return false;
    }

    public override string ToString() //Eilutės formavimas
    {
        return String.Format("|{0,-30}|{1,-20}|{2,-10}|{3,-8}|{4,-2}|{5,-2}|{6,-2}|", KomandosPavadinimas,
            Pavarde, Vardas, Pozicija, ZaistaMinuciu, PelnytaTasku, PadarytaKlaidu);
    }
}