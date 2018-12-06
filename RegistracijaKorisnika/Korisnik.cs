using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistracijaKorisnika
{
    class Korisnik
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Titula { get; set; }


        public Korisnik(string ime, string prezime, string mail, string titula)
        {
            Ime = ime;
            Prezime = prezime;
            Email = mail;
            Titula = titula;
            
        }

        public string SlanjePodataka()
        {
            string httpOdgovor = "";
            string uloga;
            try
            {
                using (var wb = new WebClient())
                {
                    NameValueCollection podaci;
                    if (this.Titula!="")
                    {
                       
                        podaci = new NameValueCollection();
                        podaci["ime"] = this.Ime;
                        podaci["prezime"] = this.Prezime;
                        podaci["email"] = this.Email;
                        podaci["titula"] = this.Titula;
                        uloga = "profesor";


                    }
                    else
                    {
                        podaci = new NameValueCollection();
                        podaci["ime"] = this.Ime;
                        podaci["prezime"] = this.Prezime;
                        podaci["email"] = this.Email;
                        uloga = "student";


                    }
                    string adresa = "https://studentattendancesystem-sas.000webhostapp.com/webservice/registracija/"+uloga+"/";
                    var odgovor = wb.UploadValues(adresa, "POST", podaci);
                    httpOdgovor = Encoding.UTF8.GetString(odgovor);
                    
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Pogreska prilikom slanja podataka na server! Obratite se administraciji.");
            }
            return httpOdgovor;
        }
    }
}
