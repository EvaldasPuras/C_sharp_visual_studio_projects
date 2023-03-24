using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for VairuotojasData
/// </summary>
public class VairuotojasData
{
    public Vairuotojas Vairuotojas { get; set; }
    public VairuotojasData Kitas { get; set; }

    public VairuotojasData(Vairuotojas vairuotojas, VairuotojasData kitas)
    {
        Vairuotojas = vairuotojas;
        Kitas = kitas;
    }

    public override string ToString()
    {
        return String.Format("{0}", Vairuotojas);
    }
}