using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for VairuotojasList
/// </summary>
public sealed class VairuotojasList
{
    private VairuotojasData Pr;
    private int count;

    public VairuotojasList()
    {
        Pr = null;
        count = 0;
    }

    public bool Empty()
    {
        return count == 0;
    }

    public int Count()
    {
        return count;
    }

    public object Add(int index, Vairuotojas o)
    {
        if (index > count)
        {
            index = count;
        }
        VairuotojasData current = Pr;
        if (this.Empty() || index == 0)
        {
            this.Pr = new VairuotojasData(o, this.Pr);
        }
        else
        {
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Kitas;
            }
            current.Kitas = new VairuotojasData(o, current.Kitas);
        }
        count++;

        return 0;
    }

    public object Add(Vairuotojas o)
    {
        return this.Add(count, o);
    }

    public void PrintAll()
    {
        for (VairuotojasData d = Pr; d != null; d = d.Kitas)
        {
            Console.WriteLine(d);
        }
    }

    public VairuotojasData Pradzia()
    {
        return Pr;
    }
}