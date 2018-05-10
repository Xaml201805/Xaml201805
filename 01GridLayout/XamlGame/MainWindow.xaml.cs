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

namespace XamlGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FontAwesomeIcon elozoKartya;

        /// <summary>
        /// Az ablak un. létrehozó függvénye (constructor)
        /// Az ablak a képernyőre kirajzolásakor ez lefut.
        /// </summary>
        public MainWindow()
        {
            //Ez a sor elintéz adminisztrációt, 
            //a saját kódunkat ez után írjuk
            InitializeComponent();

            //engedélyezzük az indítás gombot
            ButtonStart.IsEnabled = true;

            //letiltjuk az Igen/Nem gombokat
            ButtonYes.IsEnabled = false;
            ButtonNo.IsEnabled = false;

            UjKartyaHuzasa();

        }

        /// <summary>
        /// Ebbe a függvénybe szerveztük ki a kártyahúzással kapcsolatos feladatokat.
        /// Előnye, hogy több helyről is meghívható.
        /// </summary>
        private void UjKartyaHuzasa()
        {
            //szigorúan típusos nyelv a C#, ezért megmondjuk, hogy a polcunkon mi
            //lehet. Ezzel a polcra csak olyan dolgot tehetek, mást nem.
            //a "polc" programozói neve: "tömb"

            //var a variable rövidítése
            //a variable neve: változó
            //egy olyan "változót" hoztam létre, ami 6 db ilyen ikon nevet tartalmazhat
            //változó: vagyis változtatható az értéke, ellentéte a konstans, amit egyszer lehet megadni, utána nem változhat.
            var kartyapakli = new FontAwesomeIcon[6];

            //0-tól 5-ig vannak a helyek ebben a tömbben
            //feltöltjük ikonokkal
            kartyapakli[0] = FontAwesomeIcon.Fax;
            kartyapakli[1] = FontAwesomeIcon.Female;
            kartyapakli[2] = FontAwesomeIcon.Download;
            kartyapakli[3] = FontAwesomeIcon.Edge;
            kartyapakli[4] = FontAwesomeIcon.Hashtag;
            kartyapakli[5] = FontAwesomeIcon.Mars;

            //létrehozunk egy elektronikus dobókockát
            var dobokocka = new Random();

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

            //eltüntetni az előző kártyát
            var animationOut = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(100));
            CardRight.BeginAnimation(OpacityProperty, animationOut);

            //veszem a kártyapakli dobásnak megfelelő elemét és megjelenítem.
            CardRight.Icon = kartyapakli[dobas];

            //megjeleníteni az új kártyát
            var animationIn = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(100));
            CardRight.BeginAnimation(OpacityProperty, animationIn);

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

            VisszajelzesEltuntetese();

        }

        private void JoValasz()
        {
            Debug.WriteLine("A válasz helyes volt");
            CardLeft.Icon = FontAwesomeIcon.Check;
            CardLeft.Foreground = Brushes.Green;

            VisszajelzesEltuntetese();
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
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Start gombot nyomtunk");
            StartGame();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Debug.WriteLine(e.Key);

            if (e.Key==Key.Up)
            { // felfelé nyíl: indítás
                StartGame();
            }

            if (e.Key==Key.Right)
            { // jobbranyíl: nem gomb
                NoAnswer();
            }

            if (e.Key==Key.Left)
            { //balranyíl: igen gomb
                YesAnswer();
            }

        }
    }
}
