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
        TableRow row = new TableRow();      //Formuojama lentelė grafinėje sąsajoje

        string[] names = { "<b>Komandos pavadinimas</b>", "<b>Krepšininko pavardė</b>",
            "<b>Vardas</b>", "<b>Žaidėjo pozicija</b>", "<b>Žaista minučių</b>",
        "<b>Pelnyta taškų</b>", "<b>Padaryta klaidų</b>"};

        for(int i = 0; i < names.Length; i++)
        {
            TableCell newCell = new TableCell();
            newCell.Text = names[i];
            row.Cells.Add(newCell);
        }

        Table1.Rows.Add(row);

        if(!IsPostBack)
        {
            DropDownList1.Items.Add("centras");
            DropDownList1.Items.Add("gynejas");
            DropDownList1.Items.Add("puolejas");
        }



        List<Krepsininkas> Krepsininkai = new List<Krepsininkas>();
        Rungtynes Rungtynes;
        ReadData(Krepsininkai, out Rungtynes);
        Krepsininkai = (from k in Krepsininkai
                        from r in Rungtynes.KrepsininkuRez
                        where r.KomandosPavadinimas == k.KomandosPavadinimas && r.Pavarde == k.Pavarde && r.Vardas == k.Vardas
                        select new Krepsininkas(k, r.ZaistaMinuciu, r.PelnytaTasku, r.PadarytaKlaidu)).ToList();
        //SudarytiSarasa(Krepsininkai, Rungtynes);
        List<Krepsininkas> Pradinis = Krepsininkai;
        FormuotiPradiniusDuomenis(Krepsininkai);
    }

    protected void Button1_Click(object sender, EventArgs e)    //Vykdomi metodai, grafinėje
    {                                                           //sąsajoje paspaudus Button1
        List<Krepsininkas> Krepsininkai = new List<Krepsininkas>();
        Rungtynes Rungtynes;
        ReadData(Krepsininkai, out Rungtynes);
        Krepsininkai = (from k in Krepsininkai
                        from r in Rungtynes.KrepsininkuRez
                        where r.KomandosPavadinimas == k.KomandosPavadinimas && r.Pavarde == k.Pavarde && r.Vardas == k.Vardas
                        select new Krepsininkas(k, r.ZaistaMinuciu, r.PelnytaTasku, r.PadarytaKlaidu)).ToList();
        //SudarytiSarasa(ref Krepsininkai, Rungtynes);
        
        SpausdintiIFaila(Krepsininkai);
        Krepsininkai.Sort();
        SpausdintiIFaila2(Krepsininkai);
        FormuotiLentele(Krepsininkai);
    }

    private void ReadData(List<Krepsininkas> krepsininkai, out Rungtynes rungtynes) //Nuskaitomi duomenys
    {
        string[] lines = File.ReadAllLines(Server.MapPath("App_Data/Žaidėjai.txt"), //Nuskaitomas krepšininkų failas
            Encoding.GetEncoding(1257));
        foreach (string l in lines)
        {
            string[] values = l.Split(';');
            string komandosPav = values[0];
            string pavarde = values[1];
            string vardas = values[2];
            string pozicija = values[3];
            Krepsininkas k = new Krepsininkas(komandosPav, pavarde, vardas, pozicija);
            krepsininkai.Add(k);
        }
        using (StreamReader reader = new StreamReader(Server.MapPath("App_Data/Rungtynės.txt")))//Nuskaitomas rungtynių
        {                                                                                       //rezultatų failas
            List<KrepsininkoRez> rezList = new List<KrepsininkoRez>();
            int date = int.Parse(reader.ReadLine());
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] values = line.Split(';');
                KrepsininkoRez rez = new KrepsininkoRez(values[0], values[1], values[2],
                    int.Parse(values[3]), int.Parse(values[4]), int.Parse(values[5]));
                rezList.Add(rez);
            }
            rungtynes = new Rungtynes(date, rezList);
        }
    }

    private void FormuotiPradiniusDuomenis(List<Krepsininkas> krepsininkai)
    {
        for (int i = 0; i < krepsininkai.Count; i++)
        {
            TableRow row = new TableRow();

            TableCell KomandosPavadinimas = new TableCell();
            KomandosPavadinimas.Text = krepsininkai.ElementAt(i).KomandosPavadinimas;
            row.Cells.Add(KomandosPavadinimas);

            TableCell KrepsininkoPavarde = new TableCell();
            KrepsininkoPavarde.Text = krepsininkai.ElementAt(i).Pavarde;
            row.Cells.Add(KrepsininkoPavarde);

            TableCell Vardas = new TableCell();
            Vardas.Text = krepsininkai.ElementAt(i).Vardas;
            row.Cells.Add(Vardas);

            TableCell ZaidimoPozicija = new TableCell();
            ZaidimoPozicija.Text = krepsininkai.ElementAt(i).Pozicija;
            row.Cells.Add(ZaidimoPozicija);

            TableCell ZaistaMinuciu = new TableCell();
            ZaistaMinuciu.Text = krepsininkai.ElementAt(i).ZaistaMinuciu.ToString();
            row.Cells.Add(ZaistaMinuciu);

            TableCell PelnytaTasku = new TableCell();
            PelnytaTasku.Text = krepsininkai.ElementAt(i).PelnytaTasku.ToString();
            row.Cells.Add(PelnytaTasku);

            TableCell PadarytaKlaidu = new TableCell();
            PadarytaKlaidu.Text = krepsininkai.ElementAt(i).PadarytaKlaidu.ToString();
            row.Cells.Add(PadarytaKlaidu);

            Table1.Rows.Add(row);
        }
    }

    private void SpausdintiIFaila(List<Krepsininkas> krepsininkai)  //Krepšininkų sąrašas spausdinamas į failą lentele
    {
        using (StreamWriter writer = new StreamWriter(Server.MapPath("App_Data/Rezultatai.txt")))
        {
            writer.WriteLine("Naudingiausiu zaideju sarasas");
            writer.WriteLine("-------------------------------------------------------------------------");
            foreach(Krepsininkas k in krepsininkai)
            {
                writer.WriteLine(k);
                writer.WriteLine("-------------------------------------------------------------------------");
            }
        }
    }

    private void SpausdintiIFaila2(List<Krepsininkas> krepsininkai)  //Krepšininkų sąrašas spausdinamas į failą lentele
    {
        using (StreamWriter writer = new StreamWriter(Server.MapPath("App_Data/Rezultatai2.txt")))
        {
            writer.WriteLine("Naudingiausiu zaideju sarasas");
            writer.WriteLine("-------------------------------------------------------------------------");
            foreach (Krepsininkas k in krepsininkai)
            {
                writer.WriteLine(k);
                writer.WriteLine("-------------------------------------------------------------------------");
            }
        }
    }

    private void FormuotiLentele(List<Krepsininkas> krepsininkai)   //Sąrašas spausdinamas grafinėje sąsajoje lentele
    {
        Table1.Rows.Clear();
        TableRow row = new TableRow();      //Formuojama lentelė grafinėje sąsajoje

        string[] names = { "<b>Komandos pavadinimas</b>", "<b>Krepšininko pavardė</b>",
            "<b>Vardas</b>", "<b>Žaidėjo pozicija</b>", "<b>Žaista minučių</b>",
        "<b>Pelnyta taškų</b>", "<b>Padaryta klaidų</b>"};

        for (int i = 0; i < names.Length; i++)
        {
            TableCell newCell = new TableCell();
            newCell.Text = names[i];
            row.Cells.Add(newCell);
        }

        Table1.Rows.Add(row);
        int n = int.Parse(TextBox2.Text);
        if (n > krepsininkai.Count)
        {
            TextBox2.Text = "Skaičius per didelis";
        }
        if (n <= krepsininkai.Count)
        {
            var kr = krepsininkai.Where(x => x.Pozicija == DropDownList1.Text).Take(n);
            foreach (Krepsininkas x in kr)
            {
                TableRow row2 = new TableRow();

                for (int i = 0; i < x.GautiReiksmes().Length; i++)
                {
                    TableCell cell = new TableCell();
                    cell.Text = x.GautiReiksmes()[i].ToString();
                    row2.Cells.Add(cell);
                }

                Table1.Rows.Add(row2);
            }
        }
    }

    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}