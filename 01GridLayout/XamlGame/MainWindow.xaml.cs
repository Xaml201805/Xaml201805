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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonYes_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Igen gombot nyomtunk");

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


            CardLeft.Icon = FontAwesome.WPF.FontAwesomeIcon.CreditCard;

        }
    }
}
