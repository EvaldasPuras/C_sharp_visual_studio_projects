using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

/// <summary>
/// Summary description for AutomobilisList
/// </summary>
public class AutomobilisList : IEnumerable
{
    private AutomobilisData Pr;
    private int count;

    public AutomobilisList()
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

    public object Add(int index, Automobilis o)
    {
        if (index > count)
        {
            index = count;
        }
        AutomobilisData current = Pr;
        if (this.Empty() || index == 0)
        {
            this.Pr = new AutomobilisData(o, this.Pr);
        }
        else
        {
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Kitas;
            }
            current.Kitas = new AutomobilisData(o, current.Kitas);
        }
        count++;

        return 0;
    }

    public object Add(Automobilis o)
    {
        return this.Add(count, o);
    }

    public void PrintAll()
    {
        for (AutomobilisData d = Pr; d != null; d = d.Kitas)
        {
            Console.WriteLine(d);
        }
    }

    public AutomobilisData Pradzia()
    {
        return Pr;
    }

    public IEnumerator GetEnumerator()
    {
        for (AutomobilisData dd = Pr; dd != null; dd = dd.Kitas)
        {
            yield return dd.Automobilis;
        }
    }
}