using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

/// <summary>
/// Summary description for InfoList
/// </summary>
public class InfoList<Tipas> : IEnumerable<Tipas> where Tipas : IComparable<Tipas>, IEquatable<Tipas>
{
    private Data<Tipas> Pr;
    private Data<Tipas> Pb;
    private Data<Tipas> d;

    public InfoList()
    {
        Pr = null;
        Pb = null;
        d = null;
    }

    public void Pradzia()
    {
        d = Pr;
    }

    public void Kitas()
    {
        d = d.Kitas;
    }

    public bool Yra()
    {
        return d != null;
    }

    public void DetiDuomenis(Tipas naujas)
    {
        var dd = new Data<Tipas>(naujas, null);
        {
            if (Pr != null)
            {
                Pb.Kitas = dd;
                Pb = dd;
            }
            else
            {
                Pr = dd;
                Pb = dd;
            }
        }
    }

    public void Sort()
    {
        for (Data<Tipas> d = Pr; d != null; d = d.Kitas)
        {
            for (Data<Tipas> f = d; f != null; f = f.Kitas)
            {
                if (f.Info.CompareTo(d.Info) == 1)
                {
                    Tipas temp = d.Info;
                    d.Info = f.Info;
                    f.Info = temp;
                }
            }
        }
    }

    public IEnumerator GetEnumerator()
    {
        for (Data<Tipas> dd = Pr; dd != null; dd = dd.Kitas)
        {
            yield return dd.Info;
        }
    }

    IEnumerator<Tipas> IEnumerable<Tipas>.GetEnumerator()
    {
        throw new NotImplementedException();
        for (Data<Tipas> dd = Pr; dd != null; dd = dd.Kitas)
        {
            yield return dd.Info;
        }
    }
}