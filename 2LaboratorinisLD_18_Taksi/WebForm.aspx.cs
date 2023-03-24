using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;

public partial class WebForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        VairuotojasList Vairuotojai = new VairuotojasList();
        AutomobilisList Automobiliai = new AutomobilisList();
        InfoList InfoList = new InfoList();
        ReadData(Vairuotojai, Automobiliai);
        SudarytiSarasa(Automobiliai, Vairuotojai, InfoList);
        InfoList.PrintAll();
        AutomobilisData IntExploat = new AutomobilisData();
        IntExploatuojamas(Automobiliai, ref IntExploat);
        WriteToFile(InfoList, IntExploat);
    }
    //Nuskaitomi duomenys iš failų
    void ReadData(VairuotojasList vairuotojai, AutomobilisList automobiliai)
    {
        {
            using (StreamReader reader = new StreamReader(Server.MapPath("App_Data/TaksiVairuotojai.txt"),
                Encoding.GetEncoding(1257)))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(';');
                    string pavarde = values[0];
                    string numeris = values[1];
                    Vairuotojas v = new Vairuotojas(pavarde, numeris);
                    vairuotojai.Add(v);
                }
            }
            using (StreamReader reader = new StreamReader(Server.MapPath("App_Data/TaksiAutomobiliai.txt"),
                Encoding.GetEncoding(1257)))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(',');
                    string marke = values[0];
                    string numeris = values[1];
                    int metai = int.Parse(values[2]);
                    int rida = int.Parse(values[3]);
                    Automobilis a = new Automobilis(marke, numeris, metai, rida);
                    automobiliai.Add(a);
                }
            }
        }
    }
    //Sudaromas susietasis sąrašas iš pavardės, automobilio markės ir automobilio amžiaus
    void SudarytiSarasa(AutomobilisList automobiliai, VairuotojasList vairuotojai, InfoList infoList)
    {
        for (VairuotojasData d = vairuotojai.Pradzia(); d != null; d = d.Kitas)
        {
            for (AutomobilisData a = automobiliai.Pradzia(); a != null; a = a.Kitas)
            {
                if (a.Automobilis.ValstybinisNumeris == d.Vairuotojas.ValstybinisNumeris)
                {
                    Console.WriteLine(";");
                    Info info = new Info(d.Vairuotojas.Pavarde, a.Automobilis.Marke);
                    DateTime today = DateTime.Today;
                    int dabarMetai = today.Year;
                    int amzius = dabarMetai - a.Automobilis.PagaminimoMetai;
                    info.PridetiAmziu(amzius);
                    if(amzius > int.Parse(TextBox1.Text) && amzius < int.Parse(TextBox2.Text))
                    {
                        infoList.Add(info);
                    }
                }
            }
        }
    }
    //Randamas intensyviausiai exploatuojamas automobilis
    void IntExploatuojamas(AutomobilisList autoList, ref AutomobilisData intAuto)
    {
        intAuto = autoList.Pradzia();
        for(AutomobilisData d = autoList.Pradzia(); d != null; d = d.Kitas)
        {
            if(d.Automobilis.Rida > intAuto.Automobilis.Rida)
            {
                intAuto = d;
            }
        }
    }

    void Sort(InfoList infoList)
    {
        for (InfoData d = infoList.Pradzia(); d != null; d = d.Kitas)
        {
            for (InfoData f = d; f != null; f = f.Kitas)
            {
                if (f.Info.Marke.CompareTo(d.Info.Marke) > 1)
                {
                    
                }
            }
        }
    }

    //Suvedami duomenys į rezultatų failą
    void WriteToFile(InfoList infoList, AutomobilisData intExploat)
    {
        using (StreamWriter writer = new StreamWriter(@"C:\Users\Evaldas\Desktop\Objektinis programavimas 2\2LaboratorinisLD_18_Taksi\Rezultatai.txt"))
        {
            writer.WriteLine("{0,-20}|{1,-15}|{2,-5}", "Pavarde", "Marke", "Amzius");
            for (int i = 0; i < 40; i++)
            {
                writer.Write("-");
            }
            writer.WriteLine();
            for (InfoData d = infoList.Pradzia(); d != null; d = d.Kitas)
            {
                writer.WriteLine(d);
                for(int i = 0; i < 40; i++)
                {
                    writer.Write("-");
                }
                writer.WriteLine();
                writer.WriteLine();
            }
            writer.WriteLine("Intensyviausiai exploatuojamas automobilis:");
            writer.WriteLine(intExploat);
        }
    }
}