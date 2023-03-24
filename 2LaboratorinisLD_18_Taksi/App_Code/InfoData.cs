using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for InfoData
/// </summary>
public sealed class InfoData
{
    public Info Info { get; set; }
    public InfoData Kitas { get; set; }

    public InfoData(Info info, InfoData kitas)
    {
        Info = info;
        Kitas = kitas;
    }

    public override string ToString()
    {
        return String.Format("{0}", Info);
    }
}