using SimplexCalcul;
using System.Windows;
using System.Windows.Controls;

namespace SimplexGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int Coloana { get; set; } = 2;
        private int Rand { get; set; } = 5;
        private TextBox[,] Restrictii { get; set; } = new TextBox[8, 8];
        private TextBox[] Ecuatie { get; set; } = new TextBox[8];
        private TextBox[] RezultateRestrictii { get; set; } = new TextBox[8];
        private ComboBox[] Semne { get; set; } = new ComboBox[8];

        public Simplex SimplexCal { get; private set; } = new Simplex();
        public MainWindow()
        {
            InitializeComponent();
        }

        //Buton de adaugare coloane
        private void Buton_Click(object sender, RoutedEventArgs e)
        {
            if (SimplexCal.i > 0)
            {
                for (int counter = 5; counter < Rand; ++counter)
                {
                    AdaugareRestrictiiColoana(counter - 5, SimplexCal.j);
                }
                AdaugareEcuatie(Coloana - 2, 3);
            }
            else
            {
                AdaugareRestrictiiColoana(0, SimplexCal.j);
                AdaugareEcuatie(0, 3);
                AdaugareTextBoxRezultateRestrictii(0);
                AdaugareSemne(0, 5);
                SimplexCal.i += 1;
                Rand += 1;
            }
            AdaugareLabel("x" + (Coloana - 2).ToString());
            Coloana += 1;
            SimplexCal.j += 1;
        }

        // Buton de adaugare randuri
        private void ButonRanduri_Click(object sender, RoutedEventArgs e)
        {
            if (SimplexCal.j > 0)
            {
                for (int counter = 2; counter < Coloana; ++counter)
                {
                    AdaugareRestrictiiRand(SimplexCal.i, counter - 2);
                }
                AdaugareTextBoxRezultateRestrictii(Rand - 5);
                AdaugareSemne(Rand - 4, Rand);
            }
            else
            {
                AdaugareRestrictiiRand(SimplexCal.i, 0);
                AdaugareLabel("x0");
                AdaugareEcuatie(0, 3);
                AdaugareTextBoxRezultateRestrictii(0);
                AdaugareSemne(0, 5);
                SimplexCal.j += 1;
                Coloana += 1;
            }
            Rand += 1;
            SimplexCal.i += 1;
        }

        // Buton de rezolvare
        private void Calcul_Click(object sender, RoutedEventArgs e)
        {
            SimplexCal.ExtragereRestrictii(Restrictii, Rand, Coloana);
            SimplexCal.ExtragereEcuatie(Ecuatie, Rand, Coloana);
            SimplexCal.ExtragereRezultateRestrictii(RezultateRestrictii, Rand, Coloana);
            SimplexCal.VariabileAditionale(Rand, Coloana);
            SimplexCal.SetareColoaneSiLinii(Rand, Coloana);
            SimplexCal.ScriereInFisier();
            SimplexCal.Maximizare();
            SimplexCal.Fisier.Close();
            MessageBox.Show("Gata!");

        }

        private void Window_Initialized(object sender, System.EventArgs e)
        {
            SimplexCal.InitializareTablou();
        }
        private void AdaugareEcuatie(int Indice1, int Indice2)
        {
            Ecuatie[Indice1] = new TextBox
            {
                MinWidth = 50,
                Margin = new Thickness(5, 5, 5, 5)
            };
            da.Children.Add(Ecuatie[Indice1]);
            Grid.SetColumn(Ecuatie[Indice1], Indice1 + 2);
            Grid.SetRow(Ecuatie[Indice1], Indice2);
        }

        private void AdaugareLabel(string Indice)
        {
            Label lbl = new Label
            {
                Content = Indice
            };
            da.Children.Add(lbl);
            Grid.SetColumn(lbl, Coloana);
            Grid.SetRow(lbl, 4);
        }

        private void AdaugareRestrictiiColoana(int Indice1, int Indice2)
        {
            Restrictii[Indice1, Indice2] = new TextBox
            {
                MinWidth = 50,
                Margin = new Thickness(5, 5, 5, 5)
            };
            da.Children.Add(Restrictii[Indice1, Indice2]);
            Grid.SetColumn(Restrictii[Indice1, Indice2], Coloana);
            Grid.SetRow(Restrictii[Indice1, Indice2], Indice1 + 5);
        }

        private void AdaugareRestrictiiRand(int Indice1, int Indice2)
        {
            Restrictii[Indice1, Indice2] = new TextBox
            {
                MinWidth = 50,
                Margin = new Thickness(5, 5, 5, 5)
            };
            da.Children.Add(Restrictii[Indice1, Indice2]);
            Grid.SetColumn(Restrictii[Indice1, Indice2], Indice2 + 2);
            Grid.SetRow(Restrictii[Indice1, Indice2], Rand);
        }

        private void AdaugareTextBoxRezultateRestrictii(int Indice1)
        {
            RezultateRestrictii[Indice1] = new TextBox
            {
                MinWidth = 50,
                Margin = new Thickness(5, 5, 5, 5)
            };
            da.Children.Add(RezultateRestrictii[Indice1]);
            Grid.SetColumn(RezultateRestrictii[Indice1], 38);
            Grid.SetRow(RezultateRestrictii[Indice1], Indice1 + 5);
        }

        private void AdaugareSemne(int Indice1, int Indice2)
        {
            Semne[Indice1] = new ComboBox
            {
                MinWidth = 50,
                Margin = new Thickness(5, 5, 5, 5)
            };
            Semne[Indice1].Items.Add("<=");
            Semne[Indice1].Items.Add(">=");
            Semne[Indice1].Items.Add("=");
            Semne[Indice1].SelectedIndex = 1;
            da.Children.Add(Semne[Indice1]);
            Grid.SetColumn(Semne[Indice1], 37);
            Grid.SetRow(Semne[Indice1], Indice2);
        }



    }
}
