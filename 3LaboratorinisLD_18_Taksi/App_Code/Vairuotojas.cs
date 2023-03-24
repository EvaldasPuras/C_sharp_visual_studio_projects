using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Vairuotojas
/// </summary>
public class Vairuotojas : IComparable<Vairuotojas>, IEquatable<Vairuotojas>
{
    public string Pavarde { get; set; }
    public string ValstybinisNumeris { get; set; }

    public Vairuotojas(string pavarde, string valstNumeris)
    {
        Pavarde = pavarde;
        ValstybinisNumeris = valstNumeris;
    }

    public override string ToString()
    {
        return String.Format("{0} {1}", Pavarde, ValstybinisNumeris);
    }

    public int CompareTo(Vairuotojas other)
    {
        throw new NotImplementedException();
    }

    public bool Equals(Vairuotojas other)
    {
        throw new NotImplementedException();
    }
}