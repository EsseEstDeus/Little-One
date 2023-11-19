using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO.Ports;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace aaa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "ATM";

            string kadi = "burak";
            string kadi1;
            string sifre = "1234";
            string sifre1;
            string onay = "e";
            string geri = "g";
            string degistir = "h";
            string cikis = "q";
            string girdi;
            string bak = "1";
            string cek = "2";
            string yatir = "3";
            string para_birimi = "TL";
            int hak = 4;
            int bakiye = 1500;
            int pyatirma;
            int pcekme;
            bool k_dogrulama = false;
            bool s_dogrulama = false;
            bool k_cikis = false;
            bool k_kilit = false;
            bool sistem_acik = true;

            while (sistem_acik == true )
            {
                while (k_dogrulama == false)
                {
                    Console.WriteLine("Kullanıcı adınızı yazın: ");
                    kadi1 = Console.ReadLine();
                    bool bos_mu = string.IsNullOrWhiteSpace(kadi1);

                    if (bos_mu)
                    {
                        Console.WriteLine("Kullanıcı adı boş olamaz!");
                    }

                    else if (k_kilit == true)
                    {
                        Console.WriteLine("Kullanıcı kilitli!");
                    }

                    else if (kadi == kadi1)
                    {
                        k_dogrulama = true;
                    }
                    else
                    {
                        Console.WriteLine("Kullanıcı bulunamadı!");
                    }
                }


                while (s_dogrulama == false && hak > 0)
                {
                    Console.WriteLine("\nŞifre:");
                    sifre1 = Console.ReadLine();
                    bool bos_mu = string.IsNullOrWhiteSpace(sifre1);

                    if (sifre1 == sifre)
                    {
                        s_dogrulama = true;
                    }

                    else if (bos_mu)
                    {
                        Console.WriteLine("Şifre boş olamaz!");
                    }

                    else
                    {
                        hak--;

                        if (hak < 1)
                        {
                            break;
                        }

                        else
                        {
                            Console.WriteLine("Hatalı Şifre!");
                            Console.WriteLine(hak + " hakkınız kaldı!");
                        }
                    }

                }

                if (s_dogrulama == false)
                {
                    k_dogrulama = false;
                    k_kilit = true;
                    Console.WriteLine("Kullanıcı Kilitlendi!");
                }

                else
                {
                    while (k_cikis != true)
                    {
                        hak = 4;
                        Console.Write("\nHoş Geldiniz!\n\n1) Bakiye Gör \n2) Para Çek \n3) Para Yatır\n\nSeçiminiz: ");
                        girdi = Console.ReadLine();

                        while (girdi != cikis && girdi != geri && girdi != bak && girdi != cek && girdi != yatir && girdi != onay)
                        {
                            Console.Write("\nGeçersiz tuşlama! \n\n1) Bakiye Gör \n2) Para Çek \n3) Para Yatır\n\n");
                            girdi = Console.ReadLine();
                        }
                        //BAKİYE GÖRME
                        if (girdi == bak)
                        {
                            Console.WriteLine("\n1)BAKİYE GÖRÜNTÜLEME\n\nHesap Bakiyesi:" + bakiye + para_birimi);
                            Console.WriteLine("Geri gitmek için g ye basın.\n");
                            girdi = Console.ReadLine();

                            while (girdi != geri)
                            {
                                Console.WriteLine("Geçersiz tuşlama tekrar deneyin!");
                                girdi = Console.ReadLine();
                            }

                        }
                        //PARA ÇEKME
                        else if (girdi == cek)
                        {
                            while (girdi != geri || girdi == degistir)
                            {
                                Console.Write("\n2)PARA ÇEKME\n\nÇekmek istediğiniz miktarı giriniz:\nAna menüye dönmek için g ye basın.\nMiktar:");
                                girdi = Console.ReadLine();
                                bool bos_mu = string.IsNullOrWhiteSpace(girdi);
                                bool sayimi = int.TryParse(girdi, out pcekme);

                                if (girdi == geri)
                                {
                                    geri = girdi;
                                }

                                else if (bos_mu)
                                {
                                    Console.WriteLine("Tutar boş bırakılamaz");
                                }

                                else if (sayimi == false && girdi != geri)
                                {
                                    Console.WriteLine("Geçersiz Giriş!");
                                }

                                else if (girdi != geri)
                                {
                                    if (pcekme < 0)
                                    {
                                        Console.WriteLine("Geçersiz Tutar!");
                                    }

                                    else if (bakiye < pcekme)
                                    {
                                        Console.WriteLine("Yetersiz Bakiye!");
                                    }

                                    else
                                    {
                                        Console.WriteLine("Çekmek istediğiniz tutar : " + pcekme + "\nOnaylıyorsanız e'ye , miktarı değiştirmek için h'ye basın. ");
                                        girdi = Console.ReadLine();

                                        if (girdi == onay)
                                        {
                                            bakiye = bakiye - pcekme;
                                            Console.WriteLine("Para Çekme başarılı. Kalan bakiye : " + bakiye);
                                            girdi = geri;
                                        }

                                        if (girdi == degistir)
                                        {
                                            girdi = degistir;
                                        }
                                    }
                                }
                            }
                        }
                        //PARA YATIRMA
                        else if (girdi == yatir)
                        {
                            while (girdi != geri || girdi == degistir)
                            {
                                Console.Write("\n2)PARA YATIRMA\n\nYatırmak istediğiniz miktarı giriniz:\nAna menüye dönmek için g ye basın.\nMiktar:");
                                girdi = Console.ReadLine();
                                bool bos_mu = string.IsNullOrWhiteSpace(girdi);
                                bool sayimi = int.TryParse(girdi, out pyatirma);

                                if (girdi == geri)
                                {
                                    geri = girdi;
                                }

                                else if (bos_mu)
                                {
                                    Console.WriteLine("Tutar boş bırakılamaz");
                                }

                                else if (sayimi == false && girdi != geri)
                                {
                                    Console.WriteLine("Geçersiz Giriş!");
                                }

                                else if (girdi != geri)
                                {
                                    if (pyatirma < 0)
                                    {
                                        Console.WriteLine("Geçersiz Tutar!");
                                    }

                                    else
                                    {
                                        Console.WriteLine("Çekmek istediğiniz tutar : " + pyatirma + "\nOnaylıyorsanız e'ye , miktarı değiştirmek için h'ye basın. ");
                                        girdi = Console.ReadLine();

                                        if (girdi == onay)
                                        {
                                            bakiye = bakiye + pyatirma;
                                            Console.WriteLine("Para Çekme başarılı. Yeni bakiye : " + bakiye);
                                            girdi = geri;
                                        }

                                        if (girdi == degistir)
                                        {
                                            girdi = degistir;
                                        }
                                    }
                                }
                            }
                        }

                        else if (girdi == cikis)
                        {
                            k_cikis = true;
                        }
                    }

                    if (k_cikis == true)
                    {
                        k_dogrulama = false;
                        s_dogrulama = false;
                        Console.WriteLine("Çıkış Yapılmıştır! İyi Günler Dileriz.");
                    }
                }
            }
        }
    }
}
