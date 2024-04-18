using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;

namespace CastleAdventure
{
    public partial class MainWindow : Window
    {
        private List<string> inventory = new List<string>();
        private int currentRoom = 1;
        private Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
            UpdateRoom();
        }

        private void UpdateRoom()
        {
            switch (currentRoom)
            {
                case 1:
                    roomDescriptionTextBlock.Text = "Egy sötét, poros szobában vagy. Mit szeretnél tenni?";
                    button1.Content = "1. Kinyitod a szekrényt.";
                    button2.Content = "2. Elindulsz az ajtó felé.";
                    button3.Content = "3. Ellenőrzöd az ablakot.";
                    roomImage.Source = new BitmapImage(new Uri("/Castle Adventures;component/Images/droom.jpg", UriKind.Relative));
                    break;
                case 2:
                    roomDescriptionTextBlock.Text = "Egy hatalmas, düledező teremben találod magad, ahol az óriási ablakokon át beszűrődő fénynyalábok alatt egy régi, rozoga lépcső vezet lefelé.";
                    button1.Content = "1. Felmászol a lépcsőn.";
                    button2.Content = "2. Mész vissza az előző szobába.";
                    button3.Visibility = Visibility.Collapsed;
                    roomImage.Source = new BitmapImage(new Uri("/Castle Adventures;component/Images/cons.jpg", UriKind.Relative));
                    break;
                case 3:
                    roomDescriptionTextBlock.Text = "Egy gyönyörű kertben találod magad, ahol egy kút mellett egy kis tábla van a földben. Mit szeretnél tenni?";
                    button1.Content = "1. Kinyitod a táblát.";
                    button2.Content = "2. Felmászol a kútra.";
                    button3.Content = "3. Megnézed a virágokat.";
                    button3.Visibility = Visibility.Visible;
                    roomImage.Source = new BitmapImage(new Uri("/Castle Adventures;component/Images/kert.jpg", UriKind.Relative));
                    break;
                case 4:
                    roomDescriptionTextBlock.Text = "Az ajtónál állsz, ami egy nagy sziklafalban van. Megpróbálod kinyitni, de nem mozdul.";
                    break;
                case 5:
                    roomDescriptionTextBlock.Text = "Egy kis tó partján találod magad. A túloldalon látod a vár kapuját.";
                    button1.Content = "1. Átkelni a tó túloldalára.";
                    button2.Content = "2. Mész vissza az előző szobába.";
                    button3.Visibility = Visibility.Visible;
                    button3.Content = "3. Szólsz a titokzatos alakhoz.";
                    roomImage.Source = new BitmapImage(new Uri("/Castle Adventures;component/Images/lake.jpg", UriKind.Relative));
                    break;
                case 6:
                    roomDescriptionTextBlock.Text = "Átértél a tó túloldalára. A vár kapuja most már közelebb van hozzád.";
                    button1.Content = "1. Megpróbálod kinyitni a kaput.";
                    button2.Content = "2. Visszamész a tó másik oldalára.";
                    button3.Visibility = Visibility.Collapsed;
                    roomImage.Source = new BitmapImage(new Uri("/Castle Adventures;component/Images/lake.jpg", UriKind.Relative));
                    break;
            }
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            switch (currentRoom)
            {
                case 1:
                    int foundGold = random.Next(1, 11);
                    roomDescriptionTextBlock.Text = $"Találtál {foundGold} aranyat a szekrényben!";
                    inventory.Add($"Arany ({foundGold})");
                    currentRoom = 2;
                    break;
                case 2:
                    roomDescriptionTextBlock.Text = "Felmásztál a lépcsőn, és egy új szobába érkeztél.";
                    currentRoom = 3;
                    break;
                case 3:
                    if (inventory.Contains("Rejtélyes kód"))
                    {
                        roomDescriptionTextBlock.Text = "Sikerült megfejtened a rejtélyes kódot, és az ajtó kinyílt előtted!";
                        currentRoom = 7; 
                    }
                    else
                    {
                        roomDescriptionTextBlock.Text = "A tábla alatt egy titkos rejtélyt találtál, de nincs meg a megfejtő kód.";
                    }
                    break;
                case 4:
                    roomDescriptionTextBlock.Text = "Az ajtónál állsz, ami egy nagy sziklafalban van. Megpróbálod kinyitni, de nem mozdul.";
                    break;
                case 5:
                    roomDescriptionTextBlock.Text = "Átértél a tó túloldalára. A vár kapuja most már közelebb van hozzád.";
                    currentRoom = 6;
                    break;
            }
            UpdateRoom();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            switch (currentRoom)
            {
                case 2:
                    currentRoom = 1;
                    break;
                case 3:
                    currentRoom = 2;
                    break;
                case 4:
                    currentRoom = 3;
                    break;
                case 5:
                    currentRoom = 1;
                    break;
                case 6:
                    currentRoom = 5;
                    break;
            }
            UpdateRoom();
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            switch (currentRoom)
            {
                case 3:
                    roomDescriptionTextBlock.Text = "Megfigyelted a virágokat, de semmi különös nem történt.";
                    break;
                case 5:
                    roomDescriptionTextBlock.Text = "Egy titokzatos alak áll előtted a tóban. Hirtelen eltűnik.";
                    break;
            }
            UpdateRoom();
        }
    }
}