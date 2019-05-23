using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int coloana = 2;
        private int rand = 5;
        private readonly TextBox[,] restrictii = new TextBox[1000, 1000];
        private int j = 0;
        private int i = 0;
        private readonly int[,] tablou = new int[1000, 1000];
        private readonly TextBox[] ecuatie = new TextBox[1000];
        private readonly TextBox[] rezultateRestrictii = new TextBox[1000];
        private readonly ComboBox[] semne = new ComboBox[1000];

        public MainWindow()
        {
            InitializeComponent();

        }



        //Buton de adaugare coloane
        private void Buton_Click(object sender, RoutedEventArgs e)
        {
            if (i > 0)
            {
                for (int a = 5; a < rand; ++a)
                {
                    restrictii[a - 5, j] = new TextBox
                    {
                        MinWidth = 20,
                        Margin = new Thickness(5, 5, 5, 5)
                    };
                    da.Children.Add(restrictii[a - 5, j]);
                    Grid.SetColumn(restrictii[a - 5, j], coloana);
                    Grid.SetRow(restrictii[a - 5, j], a);
                }

                // Adauga textbox-uri pentru ecuatie
                ecuatie[coloana - 1] = new TextBox
                {
                    MinWidth = 20,
                    Margin = new Thickness(5, 5, 5, 5)
                };
                da.Children.Add(ecuatie[coloana - 1]);
                Grid.SetColumn(ecuatie[coloana - 1], coloana);
                Grid.SetRow(ecuatie[coloana - 1], 3);

            }
            else
            {
                restrictii[0, j] = new TextBox
                {
                    MinWidth = 20,
                    Margin = new Thickness(5, 5, 5, 5)
                };
                da.Children.Add(restrictii[0, j]);
                Grid.SetColumn(restrictii[0, j], coloana);
                Grid.SetRow(restrictii[0, j], 5);


                // Adauga textbox-uri pentru ecuatie
                ecuatie[0] = new TextBox
                {
                    MinWidth = 20,
                    Margin = new Thickness(5, 5, 5, 5)
                };
                da.Children.Add(ecuatie[0]);
                Grid.SetColumn(ecuatie[0], 2);
                Grid.SetRow(ecuatie[0], 3);

                // Adaugare textbox-uri pentru rezultatele restrictiilor
                rezultateRestrictii[0] = new TextBox
                {
                    MinWidth = 20,
                    Margin = new Thickness(5, 5, 5, 5)
                };
                da.Children.Add(rezultateRestrictii[0]);
                Grid.SetColumn(rezultateRestrictii[0], 38);
                Grid.SetRow(rezultateRestrictii[0], 5);

                // Adugare semne
                semne[0] = new ComboBox
                {
                    MinWidth = 50,
                    Margin = new Thickness(5, 5, 5, 5)
                };
                semne[0].Items.Add("<");
                semne[0].Items.Add(">");
                semne[0].SelectedIndex = 1;
                da.Children.Add(semne[0]);
                Grid.SetColumn(semne[0], 37);
                Grid.SetRow(semne[0], 5);



                i += 1;
                rand += 1;
            }

            Label lbl = new Label
            {
                Content = "x" + (coloana - 2).ToString()
            };
            da.Children.Add(lbl);
            Grid.SetColumn(lbl, coloana);
            Grid.SetRow(lbl, 4);

            coloana += 1;
            j += 1;
        }

        // Buton de adaugare randuri
        private void ButonRanduri_Click(object sender, RoutedEventArgs e)
        {
            if (j > 0)
            {
                for (int a = 2; a < coloana; ++a)
                {
                    restrictii[i, a - 2] = new TextBox
                    {
                        MinWidth = 20,
                        Margin = new Thickness(5, 5, 5, 5)
                    };
                    da.Children.Add(restrictii[i, a - 2]);
                    Grid.SetColumn(restrictii[i, a - 2], a);
                    Grid.SetRow(restrictii[i, a - 2], rand);
                }

                // Adaugare textbox-uri pentru rezultatele restrictiilor
                rezultateRestrictii[0] = new TextBox
                {
                    MinWidth = 20,
                    Margin = new Thickness(5, 5, 5, 5)
                };
                da.Children.Add(rezultateRestrictii[0]);
                Grid.SetColumn(rezultateRestrictii[0], 38);
                Grid.SetRow(rezultateRestrictii[0], rand);

                // Adugare semne
                semne[rand - 4] = new ComboBox
                {
                    MinWidth = 50,
                    Margin = new Thickness(5, 5, 5, 5)
                };
                semne[rand - 4].Items.Add("<");
                semne[rand - 4].Items.Add(">");
                semne[rand - 4].SelectedIndex = 1;
                da.Children.Add(semne[rand - 4]);
                Grid.SetColumn(semne[rand - 4], 37);
                Grid.SetRow(semne[rand - 4], rand);

            }
            else
            {
                restrictii[i, 0] = new TextBox
                {
                    MinWidth = 20,
                    Margin = new Thickness(5, 5, 5, 5)
                };
                da.Children.Add(restrictii[i, 0]);
                Grid.SetColumn(restrictii[i, 0], 2);
                Grid.SetRow(restrictii[i, 0], rand);

                Label lbl = new Label
                {
                    Content = "x0"
                };
                da.Children.Add(lbl);
                Grid.SetColumn(lbl, coloana);
                Grid.SetRow(lbl, 4);

                // Adauga textbox-uri pentru ecuatie
                ecuatie[0] = new TextBox
                {
                    MinWidth = 20,
                    Margin = new Thickness(5, 5, 5, 5)
                };
                da.Children.Add(ecuatie[0]);
                Grid.SetColumn(ecuatie[0], 2);
                Grid.SetRow(ecuatie[0], 3);

                // Adaugare textbox-uri pentru rezultatele restrictiilor
                rezultateRestrictii[0] = new TextBox
                {
                    MinWidth = 20,
                    Margin = new Thickness(5, 5, 5, 5)
                };
                da.Children.Add(rezultateRestrictii[0]);
                Grid.SetColumn(rezultateRestrictii[0], 38);
                Grid.SetRow(rezultateRestrictii[0], 5);

                // Adugare semne
                semne[0] = new ComboBox
                {
                    MinWidth = 50,
                    Margin = new Thickness(5, 5, 5, 5)
                };
                semne[0].Items.Add("<");
                semne[0].Items.Add(">");
                semne[0].SelectedIndex = 1;
                da.Children.Add(semne[0]);
                Grid.SetColumn(semne[0], 37);
                Grid.SetRow(semne[0], 5);


                j += 1;
                coloana += 1;
            }
            rand += 1;
            i += 1;
        }

        // Buton de rezolvare
        private void Calcul_Click(object sender, RoutedEventArgs e)
        {
            for (int b = 0; b < rand - 5; ++b)
            {
                for (int c = 0; c < coloana - 2; ++c)
                {
                    if (restrictii[b, c].Text != string.Empty)
                    {
                        tablou[b, c] = int.Parse(restrictii[b, c].Text);
                    }
                    else
                    {
                        tablou[b, c] = 0;
                    }
                }
            }
        }
    }
}
