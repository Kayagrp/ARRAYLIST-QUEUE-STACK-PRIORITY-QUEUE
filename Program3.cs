using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje2I
{

    public class Musteri
    {
        int Urun_say;
        string Musteri_ad;
        public Musteri(int Urun_say, string Musteri_ad)
        {
            this.Musteri_ad = Musteri_ad;
            this.Urun_say = Urun_say;
        }
        public Musteri()
        {

        }
        public int GetUrun_say()
        {
            return Urun_say;
        }
        public string GetMusteri_ad()
        {
            return Musteri_ad;
        }

    }


    class Program
    {
        public static ArrayList GList_atama(int[] Urun_sayi, string[] Musteri_ad)//generic list oluşturur arrayliste ekler ve arraylist dödürür
        {
            Random rnd = new Random();
            ArrayList arrlist = new ArrayList();
            List<Musteri> liste = new List<Musteri>();
            int uzunluk = Urun_sayi.Length;
            int uzunluk2 = Urun_sayi.Length;
            int tut = 0;
            while (uzunluk >= 0)
            {
                int rastgele = rnd.Next(1, 6);//1 ile 5 arasında rastgele sayı üretir

                for (int i = tut; i < tut + rastgele; i++)
                {
                    if (i < uzunluk2)
                    {
                        liste.Add(new Musteri(Urun_sayi[i], Musteri_ad[i]));//rastgele sayıdaki müşteri nesnelerini listeye ekler
                    }
                }
                tut += rastgele;
                if (liste.Count > 0)
                {
                    arrlist.Add(new List<Musteri>(liste));// generic listeyi arrayliste ekler
                }
                liste.Clear();
                uzunluk -= rastgele;
            }
            return arrlist;
        }
        static void Main(string[] args)
        {
            StackX theStack = new StackX(12);//arrayden oluşan yığıt
            Queue theQueue = new Queue(12);//arrayden oluşan kuyruk
            oncQueue oncQue = new oncQueue();//listeden oluşan öncelikli kuyruk
            oncQueueartan oncartan = new oncQueueartan();//listeden oluşan artan sırada öncelikli kuyruk
            ArrayList arrlist2 = new ArrayList();
            List<int> ortalama_list = new List<int>();
            Musteri musteri = new Musteri();
            List<Musteri> liste2 = new List<Musteri>();
            double liste_say;
            double nesne_say;
            string[] Musteri_adi = { "Ali", "Merve", "Veli", "Gülay", "Okan", "Zekiye", "Kemal", "Banu", "İlker", "Songül", "Nuri", "Deniz", };
            int[] Urun_say = { 8, 11, 16, 5, 15, 14, 19, 3, 18, 17, 13, 15, };
            arrlist2 = GList_atama(Urun_say, Musteri_adi);
            liste_say = arrlist2.Count;
            nesne_say = Musteri_adi.Length;
            Console.WriteLine("Bileşik Veri Yapısı Oluşturma ve Eleman Ekleme Ön Çalışması ve Metodu");
            Console.WriteLine("Müşteri Adı | Ürün sayısı");
            for (int i = 0; i < arrlist2.Count; i++)
            {
                liste2 = (List<Musteri>)arrlist2[i];
                Console.WriteLine("---ArrayList eleman:"+i+ "---");
                for (int j = 0; j < liste2.Count; j++)
                {
                    musteri = (Musteri)liste2[j];
                    theStack.push(musteri);
                    theQueue.insert(musteri);
                    oncQue.insert(musteri);
                    oncartan.insert(musteri);
                    Console.WriteLine(String.Format("{0,-6}{1,13}", musteri.GetMusteri_ad(), Convert.ToString(musteri.GetUrun_say())));
                    Console.WriteLine("-------------------","\n-------------------------------------------------");
                }
                
            }
            Console.WriteLine("\nListe sayısı: "+liste_say);
            Console.WriteLine("\nOrtalama eleman sayısı:" + nesne_say / liste_say+"\n");
            Console.WriteLine("          YIĞIT        ");
            Console.WriteLine("Müşteri Adı | Ürün sayısı");
            while (!theStack.isEmpty())
            {
                Musteri musteri2 = theStack.pop();
                
                Console.WriteLine(String.Format("{0,-6}{1,13}", musteri2.GetMusteri_ad(), Convert.ToString(musteri2.GetUrun_say())));
                Console.WriteLine("-------------------", "\n-------------------------------------------------");
            }
            Console.WriteLine("          Kuyruk        ");
            Console.WriteLine("Müşteri Adı | Ürün sayısı");
            while (!theQueue.isEmpty()) 
            { 
                Musteri musteri3 = theQueue.remove(); 
                Console.WriteLine(String.Format("{0,-6}{1,13}", musteri3.GetMusteri_ad(), Convert.ToString(musteri3.GetUrun_say())));
                Console.WriteLine("-------------------", "\n-------------------------------------------------");

            }
            Console.WriteLine("          Öncelikli Kuyruk          ");
            Console.WriteLine("Müşteri Adı | Ürün sayısı");
            while (!oncQue.isEmpty())
            {
                Musteri musteri4 = oncQue.remove();
                Console.WriteLine(String.Format("{0,-6}{1,13}", musteri4.GetMusteri_ad(), Convert.ToString(musteri4.GetUrun_say())));
                Console.WriteLine("-------------------", "\n-------------------------------------------------");
            }
            

            Console.WriteLine("          Artan Öncelikli Kuyruk          ");
            Console.WriteLine("Müşteri Adı | Ürün sayısı");
            while (!oncartan.isEmpty())
            {
                Musteri musteri5 = oncartan.remove();
                ortalama_list.Add(musteri5.GetUrun_say());
                Console.WriteLine(String.Format("{0,-6}{1,13}", musteri5.GetMusteri_ad(), Convert.ToString(musteri5.GetUrun_say())));
                Console.WriteLine("-------------------", "\n-------------------------------------------------");
            }

            Console.WriteLine("Kuyruk için ortalama tamamlanma süresi: "+theQueue.ortSure());
            Console.WriteLine("\nÖncelikli kuyruk için ortalama tamamlanma süresi: " + oncartan.ortSure(ortalama_list));
            Console.ReadKey();

        }
        class StackX // yığıt arraylerden oluşur
        {
            private int arr_boyut; // yığıtın tutulacağı arrayin boyutu
            private Musteri[] stackArray;
            private int tepe; // yığıtın başı
            public StackX(int s) 
            {
                arr_boyut = s; 
                stackArray = new Musteri[arr_boyut]; 
                tepe = -1; 
            }
            public void push(Musteri j) // müşteri nesnelerini yığıta ekler
            {
                stackArray[++tepe] = j; 
            }
            public Musteri pop() 
            {
                return stackArray[tepe--]; 
            }
            public Musteri peek() 
            {
                return stackArray[tepe];
            }
            //--------------------------------------------------------------
            public Boolean isEmpty() // yığıtın boş olup olmadığını kontrol eder
            {
                return (tepe == -1);
            }
            //--------------------------------------------------------------
            public Boolean isFull() // yığıtın dolu olup olmadığını kontrol eder
            {
                return (tepe == arr_boyut - 1);
            }
        } 

        class Queue //kuyruk arraylarden oluşur
        {
            private int maxSize;
            private Musteri[] queArray;
            private int bas;
            private int son;
            private int eleman_say;
            public Queue(int s) 
            {
                maxSize = s;
                queArray = new Musteri[maxSize];
                bas = 0;
                son = -1;
                eleman_say = 0;
            }
            public void insert(Musteri j) // kuyruğa eleman ekler
            {
                if (son == maxSize - 1) 
                    son = -1;
                queArray[++son] = j; 
                eleman_say++; 
            }
            public double ortSure()
            {
                double bek_sure = 0;
                double toplam_sure = 0;
                for (int i = 0; i < queArray.Length; i++)
                {
                    bek_sure += queArray[i].GetUrun_say();
                    toplam_sure += bek_sure;
                }
                return toplam_sure / queArray.Length;
            }
            public Musteri remove() // Kuyruktan eleman çıkarır
            {
                Musteri temp = queArray[bas++]; 
                if (bas == maxSize) 
                    bas = 0;
                eleman_say--; 
                return temp;
            }
            public Musteri peekFront() //kuyruğun başındaki elemanı döndürür
            {
                return queArray[bas];
            }
            public Boolean isEmpty() // kuyruğun boş olup olmadığını kontrol eder
            {
                return (eleman_say == 0);
            }
            public Boolean isFull() // kuyruğun dolu olup olmadığını kontrol eder
            {
                return (eleman_say == maxSize);
            }
            public int size() // Kuyruğun boyutunu döndürür
            {
                return eleman_say;
            }
        } 

        class oncQueue //öncelikli kuyruk
        {
            private List<Musteri> queList;
            private int eleman_say;
            public oncQueue() 
            {
                queList = new List<Musteri>();
                eleman_say = 0;
            }
            public void insert(Musteri m) // öncelikli kuyruğa eleman ekler
            {
                queList.Add(m);
                eleman_say++;
            }
            
            public Musteri remove() // öncelikli kuyruktan eleman siler
            {
                    Musteri max = queList[0];
                    int maxIndex = 0;
                    for (int i = 1; i < queList.Count; i++)
                    {
                        if (queList[i].GetUrun_say() > max.GetUrun_say())
                        {
                            max = queList[i];
                            maxIndex = i;
                        }
                    }
                    queList.RemoveAt(maxIndex);
                    eleman_say--;
                return max;
            }
            public Boolean isEmpty() // kuyruğun boş olup olmadığını kontrol eder
            {
                return (eleman_say == 0);
            }
        } 

        class oncQueueartan //artan sırada öncelikli kuyruk
        {
            private List<Musteri> queList;
            private int eleman_say;
            public oncQueueartan()
            {
                queList = new List<Musteri>();
                eleman_say = 0;
            }
            public void insert(Musteri j) // eleman ekler
            {
                queList.Add(j);
                eleman_say++;
            }
            public Musteri remove() // artan sırada elemanları siler
            {
                Musteri max = queList[0];
                int maxIndex = 0;
                for (int i = 1; i < queList.Count; i++)
                {
                    if (queList[i].GetUrun_say() < max.GetUrun_say())
                    {
                        max = queList[i];
                        maxIndex = i;
                    }
                }
                queList.RemoveAt(maxIndex);
                eleman_say--;
                return max;
            }
            public double ortSure(List<int> liste)
            {
                double bek_sure2 = 0;
                double toplam_sure2 = 0;
                for (int i = 0; i < liste.Count; i++)
                {
                    bek_sure2 += liste[i];
                    toplam_sure2 += bek_sure2;
                }
                return toplam_sure2 / liste.Count;
            }
            public Boolean isEmpty() // boş olup olmadığını kontrol eder
            {
                return (eleman_say == 0);
            }
        } 

    }
    }


