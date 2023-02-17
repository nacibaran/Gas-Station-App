using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Benzin_istasyonu
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        double D_Benzin95 = 0, D_Benzin97 = 0, D_Dizel = 0, D_Eurodizel = 0, D_Lpg = 0;  // DOLAN
        double E_Benzin95 = 0, E_Benzin97 = 0, E_Dizel = 0, E_Eurodizel = 0, E_Lpg = 0;  // EKLENEN
        double F_Benzin95 = 0, F_Benzin97 = 0, F_Dizel = 0, F_Eurodizel = 0, F_Lpg = 0;  // FİYAT
        double S_Benzin95 = 0, S_Benzin97 = 0, S_Dizel = 0, S_Eurodizel = 0, S_Lpg = 0;  // SATILAN
        string [] Depo_bilgileri;
        string [] Fiyat_bilgileri;

        private void txt_depo_oku()
        {
            Depo_bilgileri = System.IO.File.ReadAllLines(Application.StartupPath + "\\depo.txt");
            D_Benzin95 = Convert.ToDouble(Depo_bilgileri[0]);
            D_Benzin97 = Convert.ToDouble(Depo_bilgileri[1]);
            D_Dizel = Convert.ToDouble(Depo_bilgileri[2]);
            D_Eurodizel = Convert.ToDouble(Depo_bilgileri[3]);
            D_Lpg = Convert.ToDouble(Depo_bilgileri[4]);             // Harry.Codder
        }
        private void txt_depo_yaz()
        {
            label7.Text = D_Benzin95.ToString("N");         // Harry.Codder
            label6.Text = D_Benzin97.ToString("N");
            label8.Text = D_Dizel.ToString("N");
            label9.Text = D_Eurodizel.ToString("N");
            label10.Text = D_Lpg.ToString("N");
        }
        private void txt_fiyat_oku()
        {
            Fiyat_bilgileri = System.IO.File.ReadAllLines(Application.StartupPath + "\\fiyat.txt");
            F_Benzin95 = Convert.ToDouble(Fiyat_bilgileri[0]);
            F_Benzin97 = Convert.ToDouble(Fiyat_bilgileri[1]);
            F_Dizel = Convert.ToDouble(Fiyat_bilgileri[2]);
            F_Eurodizel = Convert.ToDouble(Fiyat_bilgileri[3]);
            F_Lpg = Convert.ToDouble(Fiyat_bilgileri[4]);
        }
        private void txt_fiyat_yaz()         // Harry.Codder
        {
            label15.Text = F_Benzin95.ToString("N");
            label16.Text = F_Benzin97.ToString("N");
            label13.Text = F_Dizel.ToString("N");
            label14.Text = F_Eurodizel.ToString("N");
            label12.Text = F_Lpg.ToString("N");
        }
        private void progressBar_guncelle()
        {
            progressBar1.Value = Convert.ToInt16(D_Benzin95);
            progressBar2.Value = Convert.ToInt16(D_Benzin97);
            progressBar3.Value = Convert.ToInt16(D_Dizel);
            progressBar4.Value = Convert.ToInt16(D_Eurodizel);               // Harry.Codder
            progressBar5.Value = Convert.ToInt16(D_Lpg);
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            progressBar1.Maximum = 1000;
            progressBar2.Maximum = 1000;
            progressBar3.Maximum = 1000;                         // Harry.Codder
            progressBar4.Maximum = 1000;
            progressBar5.Maximum = 1000;

            String[] Yakit_türleri = { "Benzin(95)", "Benzin(97)", "Dizel", "Euro Dizel", "LPG" };
            cb_yakitturu.Items.AddRange(Yakit_türleri);

            txt_depo_oku();
            txt_depo_yaz();
            txt_fiyat_oku();
            txt_fiyat_yaz();
            progressBar_guncelle();
            numericupdown_value();

            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;              // Harry.Codder
            numericUpDown3.Enabled = false;
            numericUpDown4.Enabled = false;
            numericUpDown5.Enabled = false;

            numericUpDown1.DecimalPlaces = 2;
            numericUpDown2.DecimalPlaces = 2;
            numericUpDown3.DecimalPlaces = 2;
            numericUpDown4.DecimalPlaces = 2;                    // Harry.Codder
            numericUpDown5.DecimalPlaces = 2;

            numericUpDown1.Increment = 0.1m;
            numericUpDown2.Increment = 0.1m;
            numericUpDown3.Increment = 0.1m;
            numericUpDown4.Increment = 0.1m;
            numericUpDown5.Increment = 0.1m;

            numericUpDown1.ReadOnly = true;                  // Harry.Codder
            numericUpDown2.ReadOnly = true;
            numericUpDown3.ReadOnly = true;
            numericUpDown4.ReadOnly = true;
            numericUpDown5.ReadOnly = true;
        }
        private void numericupdown_value()
        {
            numericUpDown1.Maximum = Convert.ToDecimal(D_Benzin95);
            numericUpDown2.Maximum = Convert.ToDecimal(D_Benzin97);
            numericUpDown3.Maximum = Convert.ToDecimal(D_Dizel);                 // Harry.Codder
            numericUpDown4.Maximum = Convert.ToDecimal(D_Eurodizel);
            numericUpDown5.Maximum = Convert.ToDecimal(D_Lpg);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {           
                E_Benzin95 = Convert.ToDouble(textBox1.Text);
                if (1000 < E_Benzin95 + D_Benzin95 || E_Benzin95<0)                  // Harry.Codder
                    textBox1.Text = "Hata !";
                else
                    Depo_bilgileri[0] = Convert.ToString(E_Benzin95 + D_Benzin95);
            }
            catch (Exception)
            {
                textBox1.Text = "Hata !";
            }
            try
            {
                E_Benzin97 = Convert.ToDouble(textBox2.Text);                        // Harry.Codder
                if (1000 < E_Benzin97 + D_Benzin97 || E_Benzin97<0)
                {
                    textBox2.Text = "Hata !";
               
                }
                    Depo_bilgileri[1] = Convert.ToString(E_Benzin97 + D_Benzin97);
            }
            catch (Exception)
            {
                textBox2.Text = "Hata !";
            }
            try
            {
                E_Dizel = Convert.ToDouble(textBox3.Text);
                if (1000 < D_Dizel + E_Dizel || E_Dizel < 0)                     // Harry.Codder
                    textBox3.Text = "Hata !";
                    Depo_bilgileri[2] = Convert.ToString(E_Dizel + D_Dizel);
            }
            catch (Exception)
            {
                textBox3.Text = "Hata !";
            }

            try
            {
               E_Eurodizel = Convert.ToDouble(textBox4.Text);                    // Harry.Codder
                if (1000 < E_Eurodizel + D_Eurodizel || E_Eurodizel < 0)
                    textBox4.Text = "Hata !";
                   Depo_bilgileri[3] = Convert.ToString(E_Eurodizel + D_Eurodizel);
            }
            catch (Exception)
            {
                 textBox4.Text = "Hata !";
            }
            try
            {
                E_Lpg = Convert.ToDouble(textBox5.Text);
                if (1000 < E_Lpg + D_Lpg || E_Lpg < 0)
                    textBox5.Text = "Hata !";               
                   Depo_bilgileri[4] = Convert.ToString(E_Lpg + D_Lpg);                  // Harry.Codder
            }   
            catch (Exception)
            {
                textBox5.Text = "Hata !";
            } 
            System.IO.File.WriteAllLines(Application.StartupPath + "\\depo.txt", Depo_bilgileri);
            txt_depo_oku();
            txt_depo_yaz();
            progressBar_guncelle();
            numericupdown_value();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void buttonSatis_Click(object sender, EventArgs e)
        {
            S_Benzin95 = double.Parse(numericUpDown1.Value.ToString());
            S_Benzin97 = double.Parse(numericUpDown2.Value.ToString());
            S_Dizel = double.Parse(numericUpDown3.Value.ToString());
            S_Eurodizel = double.Parse(numericUpDown4.Value.ToString());             // Harry.Codder
            S_Lpg = double.Parse(numericUpDown5.Value.ToString());

            if (numericUpDown1.Enabled==true)
            {
                D_Benzin95 = D_Benzin95 - S_Benzin95;
                label30.Text = Convert.ToString( S_Benzin95 * F_Benzin95);
            }
            if (numericUpDown2.Enabled == true)
            {
                D_Benzin97 = D_Benzin97 - S_Benzin97;
                label30.Text = Convert.ToString(S_Benzin97 * F_Benzin97);            // Harry.Codder
            }
            if (numericUpDown3.Enabled == true)
            {
                D_Dizel = D_Dizel - S_Dizel;
                label30.Text = Convert.ToString(S_Dizel * F_Dizel);
            }
            if (numericUpDown4.Enabled == true)
            {
                D_Eurodizel = D_Eurodizel - S_Eurodizel;
                label30.Text = Convert.ToString(S_Eurodizel * F_Eurodizel);              // Harry.Codder
            }
            if(numericUpDown5.Enabled==true)
            {
                D_Lpg = D_Lpg - S_Lpg;
                label30.Text = Convert.ToString(S_Lpg * F_Lpg);
            }
        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                F_Benzin95 = F_Benzin95 + (F_Benzin95 * Convert.ToDouble(textBox10.Text) / 100);
                Fiyat_bilgileri[0] = Convert.ToString(F_Benzin95);
            }
            catch (Exception)
            {
                textBox10.Text = "Hata !";
            }
            try

            {
                F_Benzin97 = F_Benzin97 + (F_Benzin97 * Convert.ToDouble(textBox9.Text) / 100);           
                Fiyat_bilgileri[1] = Convert.ToString(F_Benzin97);
            }
            catch (Exception)
            {
                textBox9.Text = "Hata !";       // Harry.Codder
            }
            try
            {   
                F_Dizel = F_Dizel + (F_Dizel * Convert.ToDouble(textBox8.Text) / 100);                
                Fiyat_bilgileri[2] = Convert.ToString(F_Dizel);
            }
            catch (Exception)
            {
                textBox8.Text = "Hata !";
            }
            try
            {
                F_Eurodizel = F_Eurodizel + (F_Eurodizel * Convert.ToDouble(textBox7.Text) / 100);
                Fiyat_bilgileri[4] = Convert.ToString(F_Eurodizel);
            }
            catch (Exception)
            {
                textBox7.Text = "Hata !";           // Harry.Codder
            }
            try
            {
                F_Lpg = F_Lpg + (F_Lpg * Convert.ToDouble(textBox6.Text) / 100);                       
                Fiyat_bilgileri[4] = Convert.ToString(F_Lpg);
            }
            catch (Exception)
            {
                textBox6.Text = "Hata !";           // Harry.Codder
            }            
            System.IO.File.WriteAllLines(Application.StartupPath + "\\fiyat.txt",Fiyat_bilgileri);
            txt_fiyat_oku();
            txt_fiyat_yaz();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void cb_yakitturu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_yakitturu.Text=="Benzin(95)")

            {
                numericUpDown1.Enabled = true;                               // Harry.Codder
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;

            }

            if (cb_yakitturu.Text == "Benzin(97)")                   // Harry.Codder
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = true;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;

            }
            if (cb_yakitturu.Text == "Dizel")
            {
                numericUpDown1.Enabled = false;              // Harry.Codder
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = true;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;

            }
            if (cb_yakitturu.Text == "Euro Dizel")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false                       // Harry.Codder
                numericUpDown4.Enabled = true;
                numericUpDown5.Enabled = false;

            }
            if (cb_yakitturu.Text == "LPG")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = true;

            }
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void progressBar5_Click(object sender, EventArgs e)
        {

        }
    }
}
