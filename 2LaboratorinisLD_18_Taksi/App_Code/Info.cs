using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Info
/// </summary>
public class Info
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

    public static bool operator >(Info pirmas, Info antras)
    {
        if((string.Compare(pirmas.Marke, antras.Marke) < 0))
        {
            if(pirmas.Amzius > antras.Amzius)
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
        return String.Format("|{0,-20}|{1,-15}|{2,-1}|", Pavarde, Marke, Amzius);
    }
}