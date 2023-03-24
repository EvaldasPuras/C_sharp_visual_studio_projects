using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for InfoList
/// </summary>
public class InfoList
{
    private InfoData Pr;
    private int count;

    public InfoList()
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

    public object Add(int index, Info o)
    {
        if (index > count)
        {
            index = count;
        }
        InfoData current = Pr;
        if (this.Empty() || index == 0)
        {
            this.Pr = new InfoData(o, this.Pr);
        }
        else
        {
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Kitas;
            }
            current.Kitas = new InfoData(o, current.Kitas);
        }
        count++;

        return 0;
    }

    public object Add(Info o)
    {
        return this.Add(count, o);
    }

    public void PrintAll()
    {
        for (InfoData d = Pr; d != null; d = d.Kitas)
        {
            Console.WriteLine(d);
        }
    }

    public InfoData Pradzia()
    {
        return Pr;
    }
}