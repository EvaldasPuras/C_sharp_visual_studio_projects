using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;

public class Rungtynes
{
    public int Data { get; set; }
    public List<KrepsininkoRez> KrepsininkuRez { get; set; }

    public Rungtynes()
    {

    }

    public Rungtynes(int data, List<KrepsininkoRez> krepsininkuRez)
    {
        Data = data;
        KrepsininkuRez = krepsininkuRez;
    }
}