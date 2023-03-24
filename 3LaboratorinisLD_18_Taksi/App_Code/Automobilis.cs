using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

/// <summary>
/// Summary description for Automobilis
/// </summary>
public class Automobilis : IComparable<Automobilis>, IEquatable<Automobilis>
{
    public string Marke { get; set; }
    public string ValstybinisNumeris { get; set; }
    public int PagaminimoMetai { get; set; }
    public int Rida { get; set; }

    public Automobilis()
    {

    }

    public Automobilis(string marke, string numeris, int pagamMetai, int rida)
    {
        Marke = marke;
        ValstybinisNumeris = numeris;
        PagaminimoMetai = pagamMetai;
        Rida = rida;
    }

    public override string ToString()
    {
        return String.Format("{0} {1} {2} {3}", Marke, ValstybinisNumeris, PagaminimoMetai, Rida);
    }

    public int CompareTo(Automobilis other)
    {
        throw new NotImplementedException();
    }

    public bool Equals(Automobilis other)
    {
        throw new NotImplementedException();
    }
}