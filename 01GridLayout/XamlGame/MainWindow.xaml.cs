using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FontAwesome.WPF;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;

namespace XamlGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FontAwesomeIcon elozoKartya;
        private long score;
        private DispatcherTimer pendulumClock;
        private TimeSpan playTime;
        private Stopwatch stopwatch;
        private List<long> listReactionTimes;
        private FontAwesomeIcon[] kartyapakli;
        private Random dobokocka;
        private List<long> listTop5Score;
        private string top5Filename;


        /// <summary>
        /// Az ablak un. létrehozó függvénye (constructor)
        /// Az ablak a képernyőre kirajzolásakor ez lefut.
        /// </summary>
        public MainWindow()
        {
            //Ez a sor elintéz adminisztrációt, 
            //a saját kódunkat ez után írjuk
            InitializeComponent();

            //csak az alkalmazás indulásakor kell

            //ingaóra létrehozása:
            //meghatározott időközönként jelez:
            //lesz egy esemény, ami ilyenkor megtörténik, és 
            //erre az eseményre fel tudunk iratkozni.

            //a változója osztályszintű, mivel máshonnan is hozzá kell férnem
            pendulumClock = new DispatcherTimer(
                TimeSpan.FromSeconds(1)        //az eseményt 1 másodpercenként kérem
                , DispatcherPriority.Normal     //semmi különös, semmi nagyon fontos, normális ügymenet
                , ClockShock                    //ez az az eseményvezérlő, amit minden másodpercben az ingaóránk meghív
                , Application.Current.Dispatcher
            );

            //mivel ez az óra azonnal elindul, állítsuk is meg: 
            //majd a Start gombra kell elindítani
            pendulumClock.Stop();

            //stopperóra létrehozása az egyes reakciók mérésére.
            stopwatch = new Stopwatch();

            //szigorúan típusos nyelv a C#, ezért megmondjuk, hogy a polcunkon mi
            //lehet. Ezzel a polcra csak olyan dolgot tehetek, mást nem.
            //a "polc" programozói neve: "tömb"

            //var a variable rövidítése
            //a variable neve: változó
            //egy olyan "változót" hoztam létre, ami 6 db ilyen ikon nevet tartalmazhat
            //változó: vagyis változtatható az értéke, ellentéte a konstans, amit egyszer lehet megadni, utána nem változhat.
            kartyapakli = new FontAwesomeIcon[6];

            //0-tól 5-ig vannak a helyek ebben a tömbben
            //feltöltjük ikonokkal
            kartyapakli[0] = FontAwesomeIcon.Fax;
            kartyapakli[1] = FontAwesomeIcon.Female;
            kartyapakli[2] = FontAwesomeIcon.Download;
            kartyapakli[3] = FontAwesomeIcon.Edge;
            kartyapakli[4] = FontAwesomeIcon.Hashtag;
            kartyapakli[5] = FontAwesomeIcon.Mars;

            //létrehozunk egy elektronikus dobókockát
            dobokocka = new Random();

            //minden játék idításakor kell
            StartingState();

            //visszatölteni az előző játék eredményét
            //A top 5 listánkat tartalmazó állomány neve
            top5Filename = "toplista.txt";

            //figyelni, hogy az állomány létezik-e?

            if (File.Exists(top5Filename))
            { //ha létezik az állomány, akkor visszatöltjük
                var fs = new FileStream(top5Filename, FileMode.Open);
                var szovegesito = new XmlSerializer(typeof(List<long>));

                //a Deserialize függvény általános object-tet ad vissza,
                //ahhoz, hogy a mi változónkba ez be tudjuk tuszkolni,
                //explicit módon meg kell mondani, hogy milyen típusra alakítsuk
                listTop5Score = (List<long>)szovegesito.Deserialize(fs);
            }
            else
            { //ha nem létezik, üres listával kezdünk
                listTop5Score = new List<long>();
            }

            ShowTop5Data();
        }


        /// <summary>
        /// A játék kezdőállapotát állítja elő
        /// </summary>
        private void StartingState()
        {
            //megmutatjuk a start gombot
            ButtonStart.Visibility = Visibility.Visible;

            //eltüntetjük a restart gombot
            ButtonRestart.Visibility = Visibility.Hidden;

            //engedélyezzük az indítás gombot
            ButtonStart.IsEnabled = true;

            //letiltjuk az Igen/Nem gombokat
            ButtonYes.IsEnabled = false;
            ButtonNo.IsEnabled = false;

            score = 0;
            ShowScore();

            playTime = TimeSpan.FromSeconds(10);
            ShowPlayTime();

            //az összes reakcióidőt tartalmazó lista létrehozása
            listReactionTimes = new List<long>();
            ShowReactionTimes(0,0,0,0,0,0);

            UjKartyaHuzasa();
        }


        /// <summary>
        /// A játék végállapotának kezelése
        /// </summary>
        private void FinalState()
        {
            pendulumClock.Stop();

            //letiltjuk az Igen/Nem gombokat
            ButtonYes.IsEnabled = false;
            ButtonNo.IsEnabled = false;

            //eltüntetjük a start gombot
            ButtonStart.Visibility = Visibility.Hidden;

            //megmutatjuk a restart gombot
            ButtonRestart.Visibility = Visibility.Visible;

            //elmentjük az utolsó játék pontszámát
            listTop5Score.Add(score);

            //top 5 intézése
            //addig, amíg legfeljebb 5 elem van a listán, addig nem kell tenni semmit.
            //ha több, mint 5 elemünk van (tehát 6 db) akkor
            if (listTop5Score.Count > 5)
            {//sorbarendezés után a legkisebbet törölni kell

                //sorbarendezés
                listTop5Score.Sort();

                //az elsőt, ami a legkisebb, töröljük
                //listTop5Score.Remove(listTop5Score[0]);  //így is lehetne, de ez még kevesebb munka
                listTop5Score.RemoveAt(0);

            }

            //top 5 lista mentése
            //adatfolyamot hozunk létre, amibe beleírjuk a top 5 listánk tartalmát.
            //a név a közös név, amit osztályszinten tárolunk
            //az állományt pedig ha nincs létrehozzuk, ha van felülírjuk
            var fs = new FileStream(top5Filename, FileMode.Create);
            //létrehozunk egy olyan objektumot, ami a listánkból olyan szöveget gyárt, 
            //amit aztán vissza tud olvasni.
            //ez a szöveg XML formátumú lesz, nyitó és záró tag-ekkel, mint az XAML
            var szovegesito = new XmlSerializer(typeof(List<long>));

            //majd a megadott file-ba kiiratjuk a listánkat.
            szovegesito.Serialize(fs, listTop5Score);

            ShowTop5Data();
        }

        private void ShowTop5Data()
        {
            //megjelenítjük a listát, érték szerint csökkenő sorrendben
            ListBoxTop5.ItemsSource = new ObservableCollection<long>(listTop5Score.OrderByDescending(x => x));
        }

        /// <summary>
        /// Itt tudjuk a játékidőt számítani, ezt a függvényt hívja az ingaóránk másodpercenként egyszer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClockShock(object sender, EventArgs e)
        {
            playTime = playTime - TimeSpan.FromSeconds(1);

            if (playTime == TimeSpan.FromSeconds(0))
            { // vége a játéknak
                FinalState();
            }

            ShowPlayTime();
        }

        private void ShowPlayTime()
        {
            LabelPlayTime.Content = $"{playTime.Minutes:00}:{playTime.Seconds:00}";
        }

        /// <summary>
        /// Ebbe a függvénybe szerveztük ki a kártyahúzással kapcsolatos feladatokat.
        /// Előnye, hogy több helyről is meghívható.
        /// </summary>
        private void UjKartyaHuzasa()
        {
            //dobunk egyet 0 és 5 között
            var dobas = dobokocka.Next(0, 5);

            //ez egy értékadás szabályai
            //az egyenlőségjel két részre osztja a sort
            //az egyenlóségjel bal oldalán szereplő változó KAPJA az értéket és tárolja
            //az egyenlőségjel jobb oldalán lévő kifejezés ADJA az értékét

            //+ feladat: olyan változót kell létrehozni, 
            //ami itt is látszódik ebben a kódblokkban,
            //és ami a gombok 
            //eseményvezérlőiben is látszik, így nem lehet lokális változó
            elozoKartya = CardRight.Icon;

            //eltüntetni az előző kártyát: átköltözik az XAML-be
            //var animationOut = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(100));
            //CardRight.BeginAnimation(OpacityProperty, animationOut);

            //veszem a kártyapakli dobásnak megfelelő elemét és megjelenítem.
            CardRight.Icon = kartyapakli[dobas];

            //megjeleníteni az új kártyát: átköltözik az XAML-be
            //var animationIn = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(100));
            //CardRight.BeginAnimation(OpacityProperty, animationIn);

            //stopperórát elindítani
            stopwatch.Restart();
        }

        private void ButtonYes_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Igen gombot nyomtunk");
            YesAnswer();
        }

        private void ButtonNo_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Nem gombot nyomtunk");
            NoAnswer();
        }

        private void RosszValasz()
        {
            Debug.WriteLine("A válasz nem volt helyes volt");
            CardLeft.Icon = FontAwesomeIcon.Times;
            CardLeft.Foreground = Brushes.Red;

            Scoring(false);

            VisszajelzesEltuntetese();

        }

        private void JoValasz()
        {
            Debug.WriteLine("A válasz helyes volt");
            CardLeft.Icon = FontAwesomeIcon.Check;
            CardLeft.Foreground = Brushes.Green;

            Scoring(true);

            VisszajelzesEltuntetese();
        }

        /// <summary>
        /// Pont számítása és megjelenítése
        /// </summary>
        /// <param name="isGoodAnswer">
        ///     jelzi, hogy jó válasz után hívtuk-e a pontszámítást. 
        ///     A névben az is (has, must) előtagok a logikai változóra utalnak. 
        ///     A paraméter névkonvenciója szerint pascal case tagolású,
        ///     vagyis az első szó kisbetűvel kezdődik, a többi szó nagybetűvel.
        ///     ha =true, akkor jó választ jelöl a paraméter, ha =false akkor rossz választ.
        /// </param>
        private void Scoring(bool isGoodAnswer)
        {

            //stopper állj (ez egyáltalán nem szükséges ebben az esetben)
            //stopwatch.Stop();

            //eltelt idő tárolása a listára
            listReactionTimes.Add(stopwatch.ElapsedMilliseconds);

            //átlagszámítás algoritmusa: számok átlaga: a számok összege osztva a számok darabszámával.
            //1. össze kell adni a számokat
            //2. tudni kell a darabszámukat
            //3. ezt a két számot egymással el kell osztani.

            //átlagszámítás 1. (még mindig a C# erejéve)
            var average1 = listReactionTimes.Sum() / listReactionTimes.Count;

            //átlagszámítás 2.
            long sum2 = 0;  //ebbe gyűjtöm a reakcióidők összegét, fontos, hogy "long" legyen, mert a ezredmásodpercek azok.

            //végig gyalogolva a listán, minden elemen ugyanazt tesszük, hozzáadjuk az összeghez
            foreach (var reactionTime in listReactionTimes)
            {
                sum2 = sum2 + reactionTime;
            }

            var average2 = sum2 / listReactionTimes.Count;

            //átlagszámítás 3.
            long sum3 = 0;

            //végig megyünk a listán "kézzel"
            for (int i = 0; i < listReactionTimes.Count; i++)
            { //az i értéke 0-tól listReactionTimes.Count-1-ig megy egyesével, majd végrehajtja a kódblokkot
                sum3 = sum3 + listReactionTimes[i];
            }

            var average3 = sum3 / listReactionTimes.Count;

            //átlagszámítás 4.

            long sum4 = 0;
            var ii = 0;

            //végiglépkedünk a listán mezítlábas módszerrel
            while (ii < listReactionTimes.Count)
            {
                sum4 = sum4 + listReactionTimes[ii];
                ii = ii + 1;
            }

            var average4 = sum4 / ii;

            //kiszámoljuk az átlagot? Majd a dotnet kiszámolja!

            //a lista sokoldalúságát kihasználva a listáról visszaolvassuk az utolsó reakcióidőt és az átlagot.
            //annyi feladat van ezzel, hogy az átlag törtszámban adja az eredményt.
            //ezért a végén egésszé alakítjuk

            ShowReactionTimes(listReactionTimes.Last(), (long)listReactionTimes.Average(), average1, average2, average3, average4);

            if (isGoodAnswer)
            { //ha jó válasz után hívtuk
                score = score + 100000 / listReactionTimes.Last();  //minél gyorsabb valaki, annál jobban jutalmazzuk
            }
            else
            { //ha rossz válasz után hívtuk
                score = score - 100 * (listReactionTimes.Last() / 1000); //minél lassabb valaki, annál jobban büntessük
            }

            ShowScore();
        }

        private void ShowReactionTimes(long lastReactionTime, long average0, long average1, long average2, long average3, long average4)
        {
            LabelReactionTime.Content = $"{lastReactionTime}/{average0}/{average1}/{average2}/{average3}/{average4}";
        }

        private void ShowScore()
        {
            LabelScore.Content = score;
        }

        private void VisszajelzesEltuntetese()
        {
            //Animáció: egy érték változtatása az idő függvényében.
            //példa: egy szám folyamatosan változik 0-tól 1-ig
            //az egyik tizedes tört típus neve: double

            //A feladat: a baloldali kártya Opacity tulajdonságának értékét 
            //100%-ról lecsökkenteni 0%-ra rövid idő alatt (legyen 1 másodperc)

            //a 100%-ot 1-el adjuk meg
            //a   0%-ot 0-val,
            //az időtartam neve C# nyelven: TimeSpan

            var animation = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(1000));
            CardLeft.BeginAnimation(OpacityProperty, animation);
        }

        private void YesAnswer()
        {
            // el kell dönteni, hogy az előző kártya és az aktuális kártya egyezik-e?
            // ha igen, akkor a válaszunk jó,
            // ha nem, akkor a válaszunk rossz.
            // ez a feltételvizsgálat:

            // ha (az előző kártya és a mostani megegyezik)
            // akkor a válasz jó
            // különben rossz

            if (elozoKartya == CardRight.Icon) //igaz, ha egyezik a két kártya
            { //ha a kifejezés igaz, akkor ez a kódblokk hajtódik végre
                JoValasz();
            }
            else
            { //ha a kifejezés nem igaz (hamis), akkor ez a kódblokk hajtódik végre
                RosszValasz();
            }

            UjKartyaHuzasa();
        }

        private void NoAnswer()
        {
            if (elozoKartya != CardRight.Icon) //igaz, ha nem egyezik meg a két kártya
            { //ha a kifejezés igaz, akkor ez a kódblokk hajtódik végre
                JoValasz();
            }
            else
            { //ha a kifejezés nem igaz (hamis), akkor ez a kódblokk hajtódik végre
                RosszValasz();
            }

            UjKartyaHuzasa();
        }

        private void StartGame()
        {
            UjKartyaHuzasa();

            //le kell tiltani az Indítást,
            ButtonStart.IsEnabled = false;

            //és engedélyezni kell az Igen/ Nem gombot.
            ButtonYes.IsEnabled = true;
            ButtonNo.IsEnabled = true;

            //időzítő elindítása
            pendulumClock.Start();
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Start gombot nyomtunk");
            StartGame();
        }

        private void ButtonRestart_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Restart gombot nyomtunk");
            StartingState();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Debug.WriteLine(e.Key);

            //todo: itt is vizsgálni, hogy a gomb elérhető-e?
            if (e.Key==Key.Right)
            { // jobbranyíl: nem gomb
                NoAnswer();
                return;
            }

            //todo: itt is vizsgálni, hogy a gomb elérhető-e?
            if (e.Key==Key.Left)
            { //balranyíl: igen gomb
                YesAnswer();
                return;
            }

            //Figyelem: figyelni kell arra, hogy a gomb látható és engedélyezve van-e
            if (ButtonStart.IsEnabled    //az indítás gomb engedélyezve van (kattintható) 
                && ButtonStart.IsVisible //ÉS az indítás gomb látható 
                && e.Key == Key.Up)      //ÉS felfelé nyíl jött
            { // indítás
                StartGame();
                return;
            }

            //Figyelem: figyelni kell arra, hogy a gomb látható és engedélyezve van-e
            if (ButtonRestart.IsEnabled
                && ButtonRestart.IsVisible
                && e.Key==Key.Multiply)
            { //csillag gomb: játék újrakezdése
                StartingState();
                return;
            }

            ///Ctrl+K, Ctrl+C a kijelölt rész megjegyzésbe tétele
            ///Ctrl+K, Ctrl+U a kijelölt rész megjegyzésből kivétele
            //switch (e.Key)
            //{
            //    case Key.Left:
            //        if (ButtonYes.IsEnabled)
            //        {
            //            YesAnswer();
            //        }
            //        break;
            //    case Key.Up:
            //        break;
            //    case Key.Right:
            //        break;
            //    case Key.Multiply:
            //        break;
            //}

        }
    }
}
