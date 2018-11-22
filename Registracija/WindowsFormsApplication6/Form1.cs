﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Windows.Forms;

namespace WindowsFormsApplication6
{
    public partial class Form1 : Form
    {
        Korisnik noviKorisnik;    
        public Form1()
        {
            InitializeComponent();
        }


        private  void btnRegistracija_Click(object sender, EventArgs e)
        {
            string odgovorWebservisa = "";
            bool provjeraUnosa = ValidacijaUnosa();
            if (provjeraUnosa==true)
            {
                MessageBox.Show("Sva polja moraju biti popunjena!");
            }
            else
            {
                noviKorisnik = new Korisnik(txtIme.Text, txtPrezime.Text, txtEmail.Text, txtTitula.Text);
                odgovorWebservisa = noviKorisnik.SlanjePodataka();

                
            }
            txtOdgovor.Text = odgovorWebservisa;
            
            
        }

        private Boolean ValidacijaUnosa()
        {
            bool praznaPolja = false;
            if (txtIme.Text=="" || txtPrezime.Text=="" || txtEmail.Text=="" || txtTitula.Text=="")
            {
                praznaPolja = true;
            }


            return praznaPolja;
        }

        private void ckbProfesor_CheckStateChanged(object sender, EventArgs e)
        {
            if (ckbProfesor.Checked)
            {
                txtTitula.Enabled = true;
            }
            else
            {
                txtTitula.Enabled = false;
            }
        }
    }
}
