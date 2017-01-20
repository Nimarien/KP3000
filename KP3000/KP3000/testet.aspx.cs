using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Xml;

namespace KP3000
{
    public partial class testet : System.Web.UI.Page
    {
        int räkna;
        List<frågor> AllaFrågorÅ = new List<frågor>();
        List<frågor> AllaFrågorL = new List<frågor>();

        //pageload
        protected void Page_Load(object sender, EventArgs e)
        {            

            if (!IsPostBack)
            {
                skapaFrågor();
                Session["counter"] = 0;
            }
            Button1.Enabled = true;
            Button3.Enabled = false;

            if  (Convert.ToInt32(Session["counter"]) == 0)
            {
                Button1.Enabled = false;
            }
            else if (Convert.ToInt32(Session["counter"]) == räkna)
            {
                Button2.Enabled = false;
                Button3.Enabled = true;
            }
        }

        //ladda alla frågor vid Åku
        public List<frågor> LagraAllaFrågorÅku()
        {
            string vägen = Server.MapPath("ÅKU.xml");
            XmlDocument Frågorna = new XmlDocument();
            Frågorna.Load(vägen);
            XmlNodeList Frågedetaljer = Frågorna.SelectNodes("frågor/fråga");
            foreach (XmlNode nod in Frågedetaljer)
            {
                frågor Fråga = new frågor();
                Fråga.Del = nod["del"].InnerText;
                Fråga.Nummer = nod["nummer"].InnerText;
                Fråga.Text = nod["text"].InnerText;
                Fråga.Alternativ1 = nod["alternativett"].InnerText;
                Fråga.Alternativ2 = nod["alternativtvå"].InnerText;
                Fråga.Alternativ3 = nod["alternativtre"].InnerText;
                Fråga.Svar = nod["svar"].InnerText;
                Fråga.Svar2 = nod["svartvå"].InnerText;

                AllaFrågorÅ.Add(Fråga);
                räkna++;
            }
            return AllaFrågorÅ;
        }

        //ladda alla frågor vid licensiering
        public List<frågor> LagraAllaFrågorLicensierad()
        {
            string vägen = Server.MapPath("Licenstest.xml");
            XmlDocument Frågorna = new XmlDocument();
            Frågorna.Load(vägen);
            XmlNodeList Frågedetaljer = Frågorna.SelectNodes("frågor/fråga");
            foreach (XmlNode nod in Frågedetaljer)
            {
                frågor Fråga = new frågor();
                Fråga.Del = nod["del"].InnerText;
                Fråga.Nummer = nod["nummer"].InnerText;
                Fråga.Text = nod["text"].InnerText;
                Fråga.Alternativ1 = nod["alternativett"].InnerText;
                Fråga.Alternativ2 = nod["alternativtvå"].InnerText;
                Fråga.Alternativ3 = nod["alternativtre"].InnerText;
                Fråga.Svar = nod["svar"].InnerText;
                Fråga.Svar2 = nod["svartvå"].InnerText;

                AllaFrågorL.Add(Fråga);
                räkna++;
            }
            return AllaFrågorL;
        }

        //skapar frågorna (somtyvärr töms vid varje postback)
        public void skapaFrågor()
        {
            int nummer = Convert.ToInt32(Session["counter"]);
            nummer++;

            if ((bool)Session["anställd"] == true && nummer <= 25)
            {
                LagraAllaFrågorLicensierad();

                Label1.Text = AllaFrågorL[Convert.ToInt32(Session["counter"])].Del.ToString();
                Label2.Text = " " + nummer + " " + AllaFrågorL[Convert.ToInt32(Session["counter"])].Text.ToString();
                RadioButton1.Text = AllaFrågorL[Convert.ToInt32(Session["counter"])].Alternativ1.ToString();
                RadioButton2.Text = AllaFrågorL[Convert.ToInt32(Session["counter"])].Alternativ2.ToString();
                RadioButton3.Text = AllaFrågorL[Convert.ToInt32(Session["counter"])].Alternativ3.ToString();

                Button3.Visible = false;               
            }
            else if ((bool)Session["anställd"] == false && nummer <= 15)
            {
                LagraAllaFrågorÅku();

                Label1.Text = AllaFrågorÅ[Convert.ToInt32(Session["counter"])].Del.ToString();
                Label2.Text = " " + nummer + " " + AllaFrågorÅ[Convert.ToInt32(Session["counter"])].Text.ToString();
                RadioButton1.Text = AllaFrågorÅ[Convert.ToInt32(Session["counter"])].Alternativ1.ToString();
                RadioButton2.Text = AllaFrågorÅ[Convert.ToInt32(Session["counter"])].Alternativ2.ToString();
                RadioButton3.Text = AllaFrågorÅ[Convert.ToInt32(Session["counter"])].Alternativ3.ToString();

                Button3.Visible = false;
            }
            else if ((bool)Session["anställd"] == true && nummer == 26)
            {
                Label1.Text = "Nu är testet klart";
                Label2.Text = "Tryck på knappen rätta för att se dina svar";
                RadioButton1.Visible = false;
                RadioButton2.Visible = false;
                RadioButton3.Visible = false;
                Button1.Visible = false;
                Button2.Visible = false;
                Button3.Visible = true;
                Button3.Enabled = true;
            }
            else if ((bool)Session["anställd"] == false && nummer == 16)
            {
                Label1.Text = "Nu är testet klart";
                Label2.Text = "Tryck på knappen rätta för att se dina svar";
                RadioButton1.Visible = false;
                RadioButton2.Visible = false;
                RadioButton3.Visible = false;
                Button1.Visible = false;
                Button2.Visible = false;
                Button3.Visible = true;
                Button3.Enabled = true;
            }
        }

        //spara svaren
        public void sparafråga(int a, out string b)
        {
            string nummerochtext = "inget";
            string texten = "inget";
                                    
            if ((bool)Session["anställd"] == true)
            {                
                if (RadioButton1.Checked)
                {
                    texten = RadioButton1.Text;

                }
                else if (RadioButton2.Checked)
                {
                    texten = RadioButton2.Text;
                }
                else if (RadioButton3.Checked)
                {
                    texten = RadioButton3.Text;
                }
                                
                nummerochtext = a.ToString() + "; " + texten;

            }
            else if ((bool)Session["anställd"] == false)
            {
                if (RadioButton1.Checked)
                {
                    texten = RadioButton1.Text;
                    
                }
                else if (RadioButton2.Checked)
                {
                    texten = RadioButton2.Text;
                    
                }
                else if (RadioButton3.Checked)
                {
                    texten = RadioButton3.Text;                    
                }
                nummerochtext = a.ToString() + "; " + texten;
                
            }            
            b = nummerochtext;
        }

        //föregående fråga
        protected void Button1_Click1(object sender, EventArgs e)
        {
            if(Convert.ToInt32(Session["counter"]) == 0)
            {
                //ska inte gå att backa när man redan är på 0
                Button1.Visible = false;
            }
            else
            {
                Session["counter"] = Convert.ToInt32(Session["counter"]) - 1;
                skapaFrågor();
            }
        }

        //nästa fråga
        protected void Button2_Click(object sender, EventArgs e)
        {            

            List<string> licensieradesvar = (List<string>)Session["Lsvar"];
            List<string> åkusvar = (List<string>)Session["Åsvar"];            

            int nummer = Convert.ToInt32(Session["counter"]);

            //hela svaret är q
            string q = "";

            //gör så att delen följer med i svaret också
            int delen = 0;

            if (Label1.Text == "Produkter och hantering av kundens affärer")
            {
                delen = 1;
            }
            else if (Label1.Text == "Ekonomi – nationalekonomi, finansiell ekonomi och privatekonomi")
            {
                delen = 2;
            }
            else if (Label1.Text == "Etik och regelverk")
            {
                delen = 3;
            }
            
            sparafråga(nummer, out q);

            string a = delen + "; " + q;

            if ((bool)Session["anställd"] == true)
            {
                licensieradesvar.Add(a);
            }
            else if ((bool)Session["anställd"] == false)
            {
                åkusvar.Add(a);
            }
                                        
            Session["counter"] = Convert.ToInt32(Session["counter"]) + 1;

            skapaFrågor();                        
        }

        //rättning
        protected void Button3_Click(object sender, EventArgs e)
        {
            //detta är svaren som står skrivna i xml-dokumentet
            List<string> rättsvar = new List<string>();            

            //detta är svaren som användaren gett i testet
            List<string> licensieradesvar = (List<string>)Session["Lsvar"];
            List<string> åkusvar = (List<string>)Session["Åsvar"];

            List<frågor> felsvar = (List<frågor>)Session["felsvar"];

            int rätt = 0;
            int fel = 0;
            int rättpådelett = 0;
            int rättpådeltvå = 0;
            int rättpådeltre = 0;

            int nummer = 0;
            int del = 0;
                   
            if ((bool)Session["anställd"] == true)
            {
                string vägen = Server.MapPath("Licenstest.xml");
                XmlDocument Frågorna = new XmlDocument();
                Frågorna.Load(vägen);
                XmlNodeList Frågedetaljer = Frågorna.SelectNodes("frågor/fråga");
                foreach (XmlNode nod in Frågedetaljer)
                {
                    frågor Fråga = new frågor();
                    Fråga.Svar = nod["svar"].InnerText;
                    Fråga.Svar2 = nod["svartvå"].InnerText;
                    Fråga.Text = nod["text"].InnerText;

                    Fråga.Del = nod["del"].InnerText;

                    if (Fråga.Del == "Produkter och hantering av kundens affärer")
                    {
                        del = 1;
                    }
                    else if (Fråga.Del == "Ekonomi – nationalekonomi, finansiell ekonomi och privatekonomi")
                    {
                        del = 2;
                    }
                    else if (Fråga.Del == "Etik och regelverk")
                    {
                        del = 3;
                    }
                    string rättformat = del + "; " + nummer + "; " + Fråga.Svar + ", " + Fråga.Svar2 + ": " + Fråga.Text;
                    rättsvar.Add(rättformat);
                    nummer++;
                }

                //här kollas varje svar vid licensieringstestet
                int nyttnummer = 0;
                                
                foreach (string item in licensieradesvar)
                {
                    //här plockas strängen som hör till frågan, nyttnummer är indexnumret
                    string detsomsvarats = licensieradesvar[nyttnummer].ToString();                    

                    //delar upp svaret så att det går att använda
                    string[] splittad = rättsvar[nyttnummer].Split(';');

                    
                    string[] detkorrektasvaret = splittad[2].Split(',');
                    if(detkorrektasvaret[1].StartsWith(" :") == true)
                    {
                        detkorrektasvaret[1] = "";
                    }

                    string[] ingenfrågamedisvaret = detkorrektasvaret[1].Split(':');
                    //här vill jag plocka ut bara strängen, och spara delnumret i en ny sträng.
                    string[] delen = detsomsvarats.Split(';');

                    string[] frågan = rättsvar[nyttnummer].Split(':');

                    if (delen[2] == detkorrektasvaret[0] || delen[2] == ingenfrågamedisvaret[0])
                    {
                        if (delen[0] == "1")
                        {
                            rättpådelett++;
                        }
                        else if (delen[0] == "2")
                        {
                            rättpådeltvå++;
                        }
                        else if (delen[0] == "3")
                        {
                            rättpådeltre++;
                        }
                        rätt++;
                        nyttnummer++;
                    }
                    else if (delen[2] != detkorrektasvaret[0] || delen[2] != detkorrektasvaret[1])
                    {                        
                        
                        //här ska det felaktiga svaret lagras i nåt så att användaren kan läsa vad som är fel på rättningssidan
                        frågor nyttfelsvar = new frågor();
                        nyttfelsvar.Text = frågan[1];
                        nyttfelsvar.användarsvar = delen[2];
                        nyttfelsvar.Svar = detkorrektasvaret[0];

                        if (detkorrektasvaret[1] != null)
                        {
                            nyttfelsvar.Svar2 = detkorrektasvaret[1];
                        }

                        if (nyttfelsvar.Svar2.Contains(":"))
                        {
                            nyttfelsvar.Svar2 = nyttfelsvar.Svar2.Remove(nyttfelsvar.Svar2.LastIndexOf(":"));
                        }

                        felsvar.Add(nyttfelsvar);

                        fel++;
                        nyttnummer++;
                    }
                }                
            }

            //åkudelen
            if ((bool)Session["anställd"] == false)
            {
                string vägen = Server.MapPath("ÅKU.xml");
                XmlDocument Frågorna = new XmlDocument();
                Frågorna.Load(vägen);
                XmlNodeList Frågedetaljer = Frågorna.SelectNodes("frågor/fråga");
                foreach (XmlNode nod in Frågedetaljer)
                {
                    frågor Fråga = new frågor();
                    Fråga.Svar = nod["svar"].InnerText;
                    Fråga.Svar2 = nod["svartvå"].InnerText;
                    Fråga.Text = nod["text"].InnerText;

                    Fråga.Del = nod["del"].InnerText;

                    if (Fråga.Del == "Produkter och hantering av kundens affärer")
                    {
                        del = 1;
                    }
                    else if (Fråga.Del == "Ekonomi – nationalekonomi, finansiell ekonomi och privatekonomi")
                    {
                        del = 2;
                    }
                    else if (Fråga.Del == "Etik och regelverk")
                    {
                        del = 3;
                    }
                    string rättformat = del + "; " + nummer + "; " + Fråga.Svar + ", " + Fråga.Svar2 + ": " + Fråga.Text;
                    rättsvar.Add(rättformat);
                    nummer++;
                }

                //här kollas varje svar vid licensieringstestet
                int nyttnummer = 0;

                foreach (string item in åkusvar)
                {
                    //här plockas strängen som hör till frågan, nyttnummer är indexnumret
                    string detsomsvarats = åkusvar[nyttnummer].ToString();

                    //delar upp svaret så att det går att använda
                    string[] splittad = rättsvar[nyttnummer].Split(';');


                    string[] detkorrektasvaret = splittad[2].Split(',');
                    if (detkorrektasvaret[1].StartsWith(" :") == true)
                    {
                        detkorrektasvaret[1] = "";
                    }

                    string[] ingenfrågamedisvaret = detkorrektasvaret[1].Split(':');
                    //här vill jag plocka ut bara strängen, och spara delnumret i en ny sträng.
                    string[] delen = detsomsvarats.Split(';');

                    string[] frågan = rättsvar[nyttnummer].Split(':');

                    if (delen[2] == detkorrektasvaret[0] || delen[2] == ingenfrågamedisvaret[0])
                    {
                        if (delen[0] == "1")
                        {
                            rättpådelett++;
                        }
                        else if (delen[0] == "2")
                        {
                            rättpådeltvå++;
                        }
                        else if (delen[0] == "3")
                        {
                            rättpådeltre++;
                        }
                        rätt++;
                        nyttnummer++;
                    }
                    else if (delen[2] != detkorrektasvaret[0] || delen[2] != detkorrektasvaret[1])
                    {

                        //här ska det felaktiga svaret lagras i nåt så att användaren kan läsa vad som är fel på rättningssidan
                        frågor nyttfelsvar = new frågor();
                        nyttfelsvar.Text = frågan[1];
                        nyttfelsvar.användarsvar = delen[2];
                        nyttfelsvar.Svar = detkorrektasvaret[0];

                        if (detkorrektasvaret[1] != null)
                        {
                            nyttfelsvar.Svar2 = detkorrektasvaret[1];
                        }

                        if (nyttfelsvar.Svar2.Contains(":"))
                        {
                            nyttfelsvar.Svar2 = nyttfelsvar.Svar2.Remove(nyttfelsvar.Svar2.LastIndexOf(":"));
                        }

                        felsvar.Add(nyttfelsvar);

                        fel++;
                        nyttnummer++;
                    }
                }
            }

            Session["rätt"] = rätt;
            Session["fel"] = fel;
            Session["rättpådelett"] = rättpådelett;
            Session["rättpådeltvå"] = rättpådeltvå;
            Session["rättpådeltre"] = rättpådeltre;

            Response.Redirect("rättning.aspx");

        }
    }
}