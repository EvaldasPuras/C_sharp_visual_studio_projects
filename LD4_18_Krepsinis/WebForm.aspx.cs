using System;
using System.Collections.Generic;
//using System.Linq;
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

        TableCell KomandosPavadinimas = new TableCell();
        KomandosPavadinimas.Text = "<b>Komandos pavadinimas</b>";
        row.Cells.Add(KomandosPavadinimas);

        TableCell KrepsininkoPavarde = new TableCell();
        KrepsininkoPavarde.Text = "<b>Krepšininko pavardė</b>";
        row.Cells.Add(KrepsininkoPavarde);

        TableCell Vardas = new TableCell();
        Vardas.Text = "<b>Vardas</b>";
        row.Cells.Add(Vardas);

        TableCell ZaidimoPozicija = new TableCell();
        ZaidimoPozicija.Text = "<b>Žaidimo pozicija</b>";
        row.Cells.Add(ZaidimoPozicija);

        TableCell ZaistaMinuciu = new TableCell();
        ZaistaMinuciu.Text = "<b>Žaista minučių</b>";
        row.Cells.Add(ZaistaMinuciu);

        TableCell PelnytaTasku = new TableCell();
        PelnytaTasku.Text = "<b>Pelnyta taškų</b>";
        row.Cells.Add(PelnytaTasku);

        TableCell PadarytaKlaidu = new TableCell();
        PadarytaKlaidu.Text = "<b>Padaryta klaidų</b>";
        row.Cells.Add(PadarytaKlaidu);

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
        SudarytiSarasa(Krepsininkai, Rungtynes);
        List<Krepsininkas> Pradinis = Krepsininkai;
        FormuotiPradiniusDuomenis(Krepsininkai);
    }

    protected void Button1_Click(object sender, EventArgs e)    //Vykdomi metodai, grafinėje
    {                                                           //sąsajoje paspaudus Button1
        List<Krepsininkas> Krepsininkai = new List<Krepsininkas>();
        Rungtynes Rungtynes;
        ReadData(Krepsininkai, out Rungtynes);
        SudarytiSarasa(Krepsininkai, Rungtynes);
        Krepsininkai.Sort();
        SpausdintiIFaila(Krepsininkai);
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

    private void SudarytiSarasa(List<Krepsininkas> krepsininkai, Rungtynes rungtynes)   //Sudaromas krepšininkų ir
    {                                                                                   //jų rezultatų sąrašas
        foreach(Krepsininkas k in krepsininkai)
        {
            foreach (KrepsininkoRez r in rungtynes.KrepsininkuRez)
            {
                if ((r.KomandosPavadinimas == k.KomandosPavadinimas) && r.Pavarde == k.Pavarde &&
                    r.Vardas == k.Vardas)
                {
                    k.PridetiRezultatus(r.ZaistaMinuciu, r.PelnytaTasku, r.PadarytaKlaidu);
                }
            }
        }
    }

    private void FormuotiPradiniusDuomenis(List<Krepsininkas> krepsininkai)
    {
        for (int i = 0; i < krepsininkai.Count; i++)
        {
            TableRow row = new TableRow();

            TableCell KomandosPavadinimas = new TableCell();
            KomandosPavadinimas.Text = krepsininkai[i].KomandosPavadinimas;
            row.Cells.Add(KomandosPavadinimas);

            TableCell KrepsininkoPavarde = new TableCell();
            KrepsininkoPavarde.Text = krepsininkai[i].Pavarde;
            row.Cells.Add(KrepsininkoPavarde);

            TableCell Vardas = new TableCell();
            Vardas.Text = krepsininkai[i].Vardas;
            row.Cells.Add(Vardas);

            TableCell ZaidimoPozicija = new TableCell();
            ZaidimoPozicija.Text = krepsininkai[i].Pozicija;
            row.Cells.Add(ZaidimoPozicija);

            TableCell ZaistaMinuciu = new TableCell();
            ZaistaMinuciu.Text = krepsininkai[i].ZaistaMinuciu.ToString();
            row.Cells.Add(ZaistaMinuciu);

            TableCell PelnytaTasku = new TableCell();
            PelnytaTasku.Text = krepsininkai[i].PelnytaTasku.ToString();
            row.Cells.Add(PelnytaTasku);

            TableCell PadarytaKlaidu = new TableCell();
            PadarytaKlaidu.Text = krepsininkai[i].PadarytaKlaidu.ToString();
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

    private void FormuotiLentele(List<Krepsininkas> krepsininkai)   //Sąrašas spausdinamas grafinėje sąsajoje lentele
    {
        Table1.Rows.Clear();
        TableRow row = new TableRow();      //Formuojama lentelė grafinėje sąsajoje

        TableCell KomandosPavadinimas = new TableCell();
        KomandosPavadinimas.Text = "<b>Komandos pavadinimas</b>";
        row.Cells.Add(KomandosPavadinimas);

        TableCell KrepsininkoPavarde = new TableCell();
        KrepsininkoPavarde.Text = "<b>Krepšininko pavardė</b>";
        row.Cells.Add(KrepsininkoPavarde);

        TableCell Vardas = new TableCell();
        Vardas.Text = "<b>Vardas</b>";
        row.Cells.Add(Vardas);

        TableCell ZaidimoPozicija = new TableCell();
        ZaidimoPozicija.Text = "<b>Žaidimo pozicija</b>";
        row.Cells.Add(ZaidimoPozicija);

        TableCell ZaistaMinuciu = new TableCell();
        ZaistaMinuciu.Text = "<b>Žaista minučių</b>";
        row.Cells.Add(ZaistaMinuciu);

        TableCell PelnytaTasku = new TableCell();
        PelnytaTasku.Text = "<b>Pelnyta taškų</b>";
        row.Cells.Add(PelnytaTasku);

        TableCell PadarytaKlaidu = new TableCell();
        PadarytaKlaidu.Text = "<b>Padaryta klaidų</b>";
        row.Cells.Add(PadarytaKlaidu);

        Table1.Rows.Add(row);
        int n = int.Parse(TextBox2.Text);
        if (n > krepsininkai.Count)
        {
            TextBox2.Text = "Skaičius per didelis";
        }
        int k = 0;
        if (n <= krepsininkai.Count)
        {
            for (int i = 0; i < krepsininkai.Count; i++)
            {
                if (krepsininkai[i].Pozicija == DropDownList1.Text)
                {
                    if (k < n)
                    {
                        TableRow row2 = new TableRow();

                        TableCell KomandosPavadinimas2 = new TableCell();
                        KomandosPavadinimas2.Text = krepsininkai[i].KomandosPavadinimas;
                        row2.Cells.Add(KomandosPavadinimas2);

                        TableCell KrepsininkoPavarde2 = new TableCell();
                        KrepsininkoPavarde2.Text = krepsininkai[i].Pavarde;
                        row2.Cells.Add(KrepsininkoPavarde2);

                        TableCell Vardas2 = new TableCell();
                        Vardas2.Text = krepsininkai[i].Vardas;
                        row2.Cells.Add(Vardas2);

                        TableCell ZaidimoPozicija2 = new TableCell();
                        ZaidimoPozicija2.Text = krepsininkai[i].Pozicija;
                        row2.Cells.Add(ZaidimoPozicija2);

                        TableCell ZaistaMinuciu2 = new TableCell();
                        ZaistaMinuciu2.Text = krepsininkai[i].ZaistaMinuciu.ToString();
                        row2.Cells.Add(ZaistaMinuciu2);

                        TableCell PelnytaTasku2 = new TableCell();
                        PelnytaTasku2.Text = krepsininkai[i].PelnytaTasku.ToString();
                        row2.Cells.Add(PelnytaTasku2);

                        TableCell PadarytaKlaidu2 = new TableCell();
                        PadarytaKlaidu2.Text = krepsininkai[i].PadarytaKlaidu.ToString();
                        row2.Cells.Add(PadarytaKlaidu2);

                        Table1.Rows.Add(row2);
                        k++;
                    }
                }
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