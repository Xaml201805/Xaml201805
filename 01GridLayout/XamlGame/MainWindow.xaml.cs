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

namespace XamlGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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

        private void ButtonYes_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Igen gombot nyomtunk");
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
            var kartyapakli = new FontAwesome.WPF.FontAwesomeIcon[6];

            //0-tól 5-ig vannak a helyek ebben a tömbben
            //feltöltjük ikonokkal
            kartyapakli[0] = FontAwesome.WPF.FontAwesomeIcon.Fax;
            kartyapakli[1] = FontAwesome.WPF.FontAwesomeIcon.Female;
            kartyapakli[2] = FontAwesome.WPF.FontAwesomeIcon.Download;
            kartyapakli[3] = FontAwesome.WPF.FontAwesomeIcon.Edge;
            kartyapakli[4] = FontAwesome.WPF.FontAwesomeIcon.Hashtag;
            kartyapakli[5] = FontAwesome.WPF.FontAwesomeIcon.Mars;

            //létrehozunk egy elektronikus dobókockát
            var dobokocka = new Random();

            //dobunk egyet 0 és 5 között
            var dobas = dobokocka.Next(0, 5);

            //veszem a kártyapakli dobásnak megfelelő elemét és megjelenítem.
            CardLeft.Icon = kartyapakli[dobas];
        }

        private void ButtonNo_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Nem gombot nyomtunk");
            UjKartyaHuzasa();
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Start gombot nyomtunk");
            UjKartyaHuzasa();

            //le kell tiltani az Indítást,
            ButtonStart.IsEnabled = false;

            //és engedélyezni kell az Igen/ Nem gombot.
            ButtonYes.IsEnabled = true;
            ButtonNo.IsEnabled = true;
        }
    }
}
