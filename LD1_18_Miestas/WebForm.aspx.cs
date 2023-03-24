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
    int Max = 14;
    int LinesCount = 0;

    protected void Page_Load(object sender, EventArgs e) //Užkraunant sąsają, joje užpildomi pradiniai duomenys
    {
        string[] Lines = new string[Max];
        ReadData(Lines);
        if (TextBox1.Text == "")
        {
            for (int i = 0; i < LinesCount; i++)
            {
                TextBox1.Text += Lines[i] + Environment.NewLine;
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e) //Pagrindinė funkcija vykstanti nuspaudus Mygtuką
    {
        string CFD = Server.MapPath("App_Data/Duom3.txt");
        string CFR = Server.MapPath("App_Data/Rezultatai.txt");
        if (File.Exists(CFR))
            File.Delete(CFR);
        Miestas a1 = new Miestas();
        a1.Skaityti(CFD);
        a1.Kelias();
        a1.Spausdinti(CFR);
        FormuotiRezultatus();
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }

    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

    }

    private void ReadData(string[] lines) //Nuskaitomi duomenys
    {
        using (StreamReader reader = new StreamReader(Server.MapPath("App_Data/Duom3.txt")))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                lines[LinesCount] = line;
                LinesCount += 1;
            }
        }
    }

    private void FormuotiRezultatus() //Formuojami rezultatai grafinėje sąsajoje
    {
        string[] lines = new string[Max];
        int k = 0;
        using (StreamReader reader = new StreamReader(Server.MapPath("App_Data/Rezultatai.txt")))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                lines[k] = line;
                k++;
            }
        }
        TextBox1.Text = "";
        TextBox2.Text = "Rezultatai";

        RekursinisSpausdinimas(0, lines);
    }

    private void RekursinisSpausdinimas(int k, string[] lines) //Rezultatų spausdinimas panaudojant rekursiją
    {
        TextBox1.Text += lines[k] + Environment.NewLine;
        k++;
        if(k < lines.Length)
        {
            RekursinisSpausdinimas(k, lines);
        }
    }
}