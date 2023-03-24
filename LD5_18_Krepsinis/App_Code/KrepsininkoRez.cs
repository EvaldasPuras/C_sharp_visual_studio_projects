using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;

public class KrepsininkoRez
{
    public string KomandosPavadinimas { get; set; }
    public string Pavarde { get; set; }
    public string Vardas { get; set; }
    public int ZaistaMinuciu { get; set; }
    public int PelnytaTasku { get; set; }
    public int PadarytaKlaidu { get; set; }

    public KrepsininkoRez(string komandosPavadinimas, string pavarde, string vardas, int zaistaMinuciu,
        int pelnytaTasku, int padarytaKlaidu)
    {
        KomandosPavadinimas = komandosPavadinimas;
        Pavarde = pavarde;
        Vardas = vardas;
        ZaistaMinuciu = zaistaMinuciu;
        PelnytaTasku = pelnytaTasku;
        PadarytaKlaidu = padarytaKlaidu;
    }

    public override string ToString()
    {
        return String.Format("|{0,-15}|{1,-15}|{2,-10}|{3,-2}|{4,-2}|{5,-2}|", KomandosPavadinimas,
            Pavarde, Vardas, ZaistaMinuciu, PelnytaTasku, PadarytaKlaidu);
    }
}