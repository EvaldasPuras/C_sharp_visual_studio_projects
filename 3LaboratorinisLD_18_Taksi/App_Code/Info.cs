using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Info
/// </summary>
public class Info : IComparable<Info>, IEquatable<Info>
{
    public string Pavarde { get; set; }
    public string Marke { get; set; }
    public int Amzius { get; set; }

    public Info(string pavarde, string marke)
    {
        Pavarde = pavarde;
        Marke = marke;
    }

    public Info(string pavarde, string marke, int masinosAmzius)
    {
        Pavarde = pavarde;
        Marke = marke;
        Amzius = masinosAmzius;
    }

    public void PridetiAmziu(int amzius)
    {
        Amzius = amzius;
    }

    public int CompareTo(Info obj)
    {
        Info other = (Info)obj;
        if(string.Compare(this.Marke, other.Marke, StringComparison.CurrentCulture) < 0)
        {
            return 1;
        }
        if(this.Amzius < other.Amzius)
        {
            return 1;
        }
        return -1;
    }

    public bool Equals(Info other)
    {
        if (other == null)
            return false;
        if (this.Marke == other.Marke && this.Amzius == other.Amzius)
            return true;
        else
            return false;
    }

    public static bool operator >(Info pirmas, Info antras)
    {
        if ((string.Compare(pirmas.Marke, antras.Marke) < 0))
        {
            if (pirmas.Amzius > antras.Amzius)
            {
                return true;
            }
            return true;
        }
        return false;
    }

    public static bool operator <(Info pirmas, Info antras)
    {
        if ((string.Compare(pirmas.Marke, antras.Marke) > 0))
        {
            if (pirmas.Amzius < antras.Amzius)
            {
                return true;
            }
            return true;
        }
        return false;
    }

    public override string ToString()
    {
        return String.Format("|{0,-20}|{1,-15}|{2,-2}|", Pavarde, Marke, Amzius);
    }
}