using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for InfoData
/// </summary>
public class Data<Tipas>
{
    public Tipas Info { get; set; }
    public Data<Tipas> Kitas { get; set; }

    public Data(Tipas info, Data<Tipas> kitas)
    {
        Info = info;
        Kitas = kitas;
    }

    public override string ToString()
    {
        return String.Format("{0}", Info);
    }
}