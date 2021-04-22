using System.Windows;
using System.Windows.Controls;

namespace SimplexCalcul
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
                    Restrictii[counter - 5, SimplexCal.j] = new TextBox
                    {
                        MinWidth = 20,
                        Margin = new Thickness(5, 5, 5, 5)
                    };
                    da.Children.Add(Restrictii[counter - 5, SimplexCal.j]);
                    Grid.SetColumn(Restrictii[counter - 5, SimplexCal.j], Coloana);
                    Grid.SetRow(Restrictii[counter - 5, SimplexCal.j], counter);
                }

                // Adauga textbox-uri pentru ecuatie
                Ecuatie[Coloana - 2] = new TextBox
                {
                    MinWidth = 20,
                    Margin = new Thickness(5, 5, 5, 5)
                };
                da.Children.Add(Ecuatie[Coloana - 2]);
                Grid.SetColumn(Ecuatie[Coloana - 2], Coloana);
                Grid.SetRow(Ecuatie[Coloana - 2], 3);

            }
            else
            {
                Restrictii[0, SimplexCal.j] = new TextBox
                {
                    MinWidth = 20,
                    Margin = new Thickness(5, 5, 5, 5)
                };
                da.Children.Add(Restrictii[0, SimplexCal.j]);
                Grid.SetColumn(Restrictii[0, SimplexCal.j], Coloana);
                Grid.SetRow(Restrictii[0, SimplexCal.j], 5);


                // Adauga textbox-uri pentru ecuatie
                Ecuatie[0] = new TextBox
                {
                    MinWidth = 20,
                    Margin = new Thickness(5, 5, 5, 5)
                };
                da.Children.Add(Ecuatie[0]);
                Grid.SetColumn(Ecuatie[0], 2);
                Grid.SetRow(Ecuatie[0], 3);

                // Adaugare textbox-uri pentru rezultatele restrictiilor
                RezultateRestrictii[0] = new TextBox
                {
                    MinWidth = 20,
                    Margin = new Thickness(5, 5, 5, 5)
                };
                da.Children.Add(RezultateRestrictii[0]);
                Grid.SetColumn(RezultateRestrictii[0], 38);
                Grid.SetRow(RezultateRestrictii[0], 5);

                // Adugare semne
                Semne[0] = new ComboBox
                {
                    MinWidth = 50,
                    Margin = new Thickness(5, 5, 5, 5)
                };
                Semne[0].Items.Add("<=");
                Semne[0].Items.Add(">=");
                Semne[0].SelectedIndex = 1;
                da.Children.Add(Semne[0]);
                Grid.SetColumn(Semne[0], 37);
                Grid.SetRow(Semne[0], 5);



                SimplexCal.i += 1;
                Rand += 1;
            }

            Label lbl = new Label
            {
                Content = "x" + (Coloana - 2).ToString()
            };
            da.Children.Add(lbl);
            Grid.SetColumn(lbl, Coloana);
            Grid.SetRow(lbl, 4);

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
                    Restrictii[SimplexCal.i, counter - 2] = new TextBox
                    {
                        MinWidth = 20,
                        Margin = new Thickness(5, 5, 5, 5)
                    };
                    da.Children.Add(Restrictii[SimplexCal.i, counter - 2]);
                    Grid.SetColumn(Restrictii[SimplexCal.i, counter - 2], counter);
                    Grid.SetRow(Restrictii[SimplexCal.i, counter - 2], Rand);
                }

                // Adaugare textbox-uri pentru rezultatele restrictiilor
                RezultateRestrictii[Rand - 5] = new TextBox
                {
                    MinWidth = 20,
                    Margin = new Thickness(5, 5, 5, 5)
                };
                da.Children.Add(RezultateRestrictii[Rand - 5]);
                Grid.SetColumn(RezultateRestrictii[Rand - 5], 38);
                Grid.SetRow(RezultateRestrictii[Rand - 5], Rand);

                // Adugare semne
                Semne[Rand - 4] = new ComboBox
                {
                    MinWidth = 50,
                    Margin = new Thickness(5, 5, 5, 5)
                };
                Semne[Rand - 4].Items.Add("<=");
                Semne[Rand - 4].Items.Add(">=");
                Semne[Rand - 4].SelectedIndex = 1;
                da.Children.Add(Semne[Rand - 4]);
                Grid.SetColumn(Semne[Rand - 4], 37);
                Grid.SetRow(Semne[Rand - 4], Rand);

            }
            else
            {
                Restrictii[SimplexCal.i, 0] = new TextBox
                {
                    MinWidth = 20,
                    Margin = new Thickness(5, 5, 5, 5)
                };
                da.Children.Add(Restrictii[SimplexCal.i, 0]);
                Grid.SetColumn(Restrictii[SimplexCal.i, 0], 2);
                Grid.SetRow(Restrictii[SimplexCal.i, 0], Rand);

                Label lbl = new Label
                {
                    Content = "x0"
                };
                da.Children.Add(lbl);
                Grid.SetColumn(lbl, Coloana);
                Grid.SetRow(lbl, 4);

                // Adauga textbox-uri pentru ecuatie
                Ecuatie[0] = new TextBox
                {
                    MinWidth = 20,
                    Margin = new Thickness(5, 5, 5, 5)
                };
                da.Children.Add(Ecuatie[0]);
                Grid.SetColumn(Ecuatie[0], 2);
                Grid.SetRow(Ecuatie[0], 3);

                // Adaugare textbox-uri pentru rezultatele restrictiilor
                RezultateRestrictii[0] = new TextBox
                {
                    MinWidth = 20,
                    Margin = new Thickness(5, 5, 5, 5)
                };
                da.Children.Add(RezultateRestrictii[0]);
                Grid.SetColumn(RezultateRestrictii[0], 38);
                Grid.SetRow(RezultateRestrictii[0], 5);

                // Adugare semne
                Semne[0] = new ComboBox
                {
                    MinWidth = 50,
                    Margin = new Thickness(5, 5, 5, 5)
                };
                Semne[0].Items.Add("<=");
                Semne[0].Items.Add(">=");
                Semne[0].SelectedIndex = 1;
                da.Children.Add(Semne[0]);
                Grid.SetColumn(Semne[0], 37);
                Grid.SetRow(Semne[0], 5);


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
    }
}
