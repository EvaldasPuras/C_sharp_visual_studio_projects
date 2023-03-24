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
        TableRow row = new TableRow();

        TableCell Pavarde = new TableCell();
        Pavarde.Text = "<b>Pavarde</b>";
        row.Cells.Add(Pavarde);

        TableCell Marke = new TableCell();
        Marke.Text = "<b>Marke</b>";
        row.Cells.Add(Marke);

        TableCell Amzius = new TableCell();
        Amzius.Text = "<b>Amzius</b>";
        row.Cells.Add(Amzius);

        Table1.Rows.Add(row);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        InfoList<Vairuotojas> Vairuotojai = new InfoList<Vairuotojas>();
        InfoList<Automobilis> Automobiliai = new InfoList<Automobilis>();
        InfoList<Info> InfoList = new InfoList<Info>();
        ReadData(Vairuotojai, Automobiliai);//Nuskaitomi duomenys
        SudarytiSarasa(Automobiliai, Vairuotojai, InfoList); //Pagal sąlygą iš abiejų duomenų sąrašų formuojamas sąrašas
        Automobilis IntExploat = new Automobilis();
        IntExploatuojamas(Automobiliai, ref IntExploat); //Randamas intenstyviausiai exploatuojamas automobilis
        InfoList.Sort(); //Rikiuojamas rezultatų sąrašas
        WriteToFile(InfoList, IntExploat); //Rezultatai įrašomi į failą
        MakeTable(InfoList);    //Sukuriama rezultatų lentelė
    }

    //Nustaitomi duomenų failai
    void ReadData(InfoList<Vairuotojas> vairuotojai, InfoList<Automobilis> automobiliai)
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
                    vairuotojai.DetiDuomenis(v);
                }
            }
            using (StreamReader reader = new StreamReader(Server.MapPath("App_Data/TaksiAutomobiliai.txt"),
                Encoding.GetEncoding(1257)))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(';');
                    string marke = values[0];
                    string numeris = values[1];
                    int metai = int.Parse(values[2]);
                    int rida = int.Parse(values[3]);
                    Automobilis a = new Automobilis(marke, numeris, metai, rida);
                    automobiliai.DetiDuomenis(a);
                }
            }
        }
    }
    //Sudaromas susietasis sąrašas iš pavardės, automobilio markės ir automobilio amžiaus
    void SudarytiSarasa(InfoList<Automobilis> automobiliai, InfoList<Vairuotojas> vairuotojai, InfoList<Info> infoList)
    {
        foreach (Vairuotojas d in vairuotojai)
        {
            foreach (Automobilis a in automobiliai)
            {
                if (a.ValstybinisNumeris == d.ValstybinisNumeris)
                {
                    Console.WriteLine(";");
                    Info info = new Info(d.Pavarde, a.Marke);
                    DateTime today = DateTime.Today;
                    int dabarMetai = today.Year;
                    int amzius = dabarMetai - a.PagaminimoMetai;
                    info.PridetiAmziu(amzius);
                    if (amzius >= int.Parse(TextBox1.Text) && amzius <= int.Parse(TextBox2.Text))
                    {
                        infoList.DetiDuomenis(info);
                    }
                }
            }
        }
    }
    //Randamas intensyviausiai exploatuojamas automobilis
    void IntExploatuojamas(InfoList<Automobilis> autoList, ref Automobilis intAuto)
    {
        intAuto = new Automobilis();
        foreach (Automobilis d in autoList)
        {
            if (d.Rida > intAuto.Rida)
            {
                intAuto = d;
            }
        }
    }
    //Suvedami duomenys į rezultatų failą
    void WriteToFile(InfoList<Info> infoList, Automobilis intExploat)
    {
        using (StreamWriter writer = new StreamWriter(@"C:\Users\Evaldas\Desktop\Objektinis programavimas 2\3LaboratorinisLD_18_Taksi\Rezultatai.txt"))
        {
            writer.WriteLine("|{0,-20}|{1,-15}|{2,-5}|", "Pavarde", "Marke", "Amzius");
            for (int i = 0; i < 40; i++)
            {
                writer.Write("-");
            }
            writer.WriteLine();
            foreach(Info d in infoList)
            {
                writer.WriteLine(d);
                for (int i = 0; i < 40; i++)
                {
                    writer.Write("-");
                }
                writer.WriteLine();
            }
            writer.WriteLine("Intensyviausiai exploatuojamas automobilis:");
            writer.WriteLine(intExploat);
        }
    }
    //Grafinėje sąsajoje sukuriama rezultatų - galutinio sąrašo lentelė
    public void MakeTable(InfoList<Info> infoList)
    {
        foreach (Info d in infoList)
        {
            TableRow row = new TableRow();
            TableCell pavarde = new TableCell();
            pavarde.Text = d.Pavarde;
            TableCell marke = new TableCell();
            marke.Text = d.Marke;
            TableCell amzius = new TableCell();
            amzius.Text = d.Amzius.ToString();
            row.Cells.Add(pavarde);
            row.Cells.Add(marke);
            row.Cells.Add(amzius);
            Table1.Rows.Add(row);
        }
    }

    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {

    }

    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}