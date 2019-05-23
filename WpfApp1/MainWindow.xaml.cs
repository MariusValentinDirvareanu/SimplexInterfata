using System.IO;
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
        private readonly double[,] tablou = new double[1000, 1000];
        private readonly TextBox[] ecuatie = new TextBox[1000];
        private readonly TextBox[] rezultateRestrictii = new TextBox[1000];
        private readonly ComboBox[] semne = new ComboBox[1000];
        private readonly StreamWriter fisier = new StreamWriter("fisier.txt");
        private double pivot = 0, pivotDoi = 0, pivotUnu = 0;
        private int pozitie = 0, jj = 0;
        private int COLOANE = 0, LINII = 0;

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
                ecuatie[coloana - 2] = new TextBox
                {
                    MinWidth = 20,
                    Margin = new Thickness(5, 5, 5, 5)
                };
                da.Children.Add(ecuatie[coloana - 2]);
                Grid.SetColumn(ecuatie[coloana - 2], coloana);
                Grid.SetRow(ecuatie[coloana - 2], 3);

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
                rezultateRestrictii[rand - 5] = new TextBox
                {
                    MinWidth = 20,
                    Margin = new Thickness(5, 5, 5, 5)
                };
                da.Children.Add(rezultateRestrictii[rand - 5]);
                Grid.SetColumn(rezultateRestrictii[rand - 5], 38);
                Grid.SetRow(rezultateRestrictii[rand - 5], rand);

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



        // Partea de programe utilitare

        private bool LiniePozitiva()
        {
            for (int ii = 0; ii < COLOANE; ++ii)
            {
                if (tablou[LINII-1, ii] < 0)
                {
                    return false;
                }
            }
            return true;
        }


        // Gaseste minimul de pe ultima linie
        private int MinNegativ()
        {
            double min = 0;
            int poz = 0;
            for (int e = 0; e < COLOANE; ++e)
            {
                if (min > tablou[LINII-1, e])
                {
                    min = tablou[LINII-1, e];
                    poz = e;
                }
            }
            return poz;
        }

        private void GasestePivot()
        {
            // Gaseste pivotul
            double minim = 9999;
            for (int ii = 0; ii < LINII-1; ++ii)
            {
                if (minim > tablou[ii, COLOANE-1] / tablou[ii, jj] && tablou[ii, jj] != 0)
                {
                    minim = tablou[ii, COLOANE-1] / tablou[ii, jj];
                    pivot = tablou[ii, jj];
                    pozitie = ii;
                }
            }
        }


        private void ImpartireLaPivot()
        {
            // Imparte linia pivotului la pivot
            for (int ii = 0; ii < COLOANE; ++ii)
            {
                tablou[pozitie, ii] /= pivot;
            }
        }

        private void LiniiPrecedentePivotului()
        {
            // Modifica liniile precedente pivotului
            for (int ii = 0; ii < pozitie; ++ii)
            {
                pivotUnu = tablou[ii, jj];
                for (int j1 = 0; j1 < COLOANE; ++j1)
                {
                    tablou[ii, j1] = tablou[ii, j1] - pivotUnu * tablou[pozitie, j1];
                }
            }
        }

        private void LiniiSuccesoarePivotului()
        {
            // Modifica liniile succesoare pivotului
            for (int ii = pozitie + 1; ii < LINII; ++ii)
            {
                pivotDoi = tablou[ii, jj];
                for (int j2 = 0; j2 < COLOANE; ++j2)
                {
                    tablou[ii, j2] = tablou[i, j2] - pivotDoi * tablou[pozitie, j2];
                }
            }
        }

        private void Maximizare()
        {
            while (LiniePozitiva() == false)
            {
                // Pozitia pe coloana a minimului de pe ultima linie
                jj = MinNegativ();

                GasestePivot();

                ImpartireLaPivot();

                LiniiPrecedentePivotului();

                LiniiSuccesoarePivotului();

                for (int b = 0; b < LINII; ++b)
                {
                    for (int c = 0; c < COLOANE; ++c)
                    {
                        fisier.Write(tablou[b, c] + " ");
                    }
                    fisier.Write('\n');
                }
                fisier.Write("\n\n");
            }
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
                        tablou[b, c] = double.Parse(restrictii[b, c].Text);
                    }
                    else
                    {
                        tablou[b, c] = 0;
                    }
                }
            }

            for (int b = 0; b < coloana - 2; ++b)
            {
                if (ecuatie[b].Text != string.Empty)
                {
                    tablou[rand - 5, b] = double.Parse(ecuatie[b].Text);
                    tablou[rand - 5, b] *= (-1);
                }
                else
                {
                    tablou[rand - 5, b] = 0;
                }
            }

            for (int c = 0; c < rand - 5; ++c)
            {
                if (rezultateRestrictii[c].Text != string.Empty)
                {
                    tablou[c, coloana - 1 + i] = double.Parse(rezultateRestrictii[c].Text);
                }
                else
                {
                    tablou[c, coloana - 1 + i] = 0;
                }
            }

            //fisier.Write(rand-4);


            for (int cc = 0; cc < rand - 4; ++cc)
            {
                for (int r = coloana - 2; r < coloana - 1 + i; ++r)
                {
                    //fisier.Write(r - (coloana - 2) + " ");
                    if (cc == (r - (coloana - 2)))
                    {
                        tablou[cc, r] = 1;

                    }
                    else
                    {
                        tablou[cc, r] = 0;
                    }
                }
            }

            //fisier.Write("da:" + da);


            //tablou[rand - 5, coloana - 2 + restrictiiAdd] = 0;

            COLOANE = coloana + i;
            LINII = rand - 4;

            //fisier.Write(COLOANE + "si" + LINII);

            Maximizare();



            for (int b = 0; b < LINII; ++b)
            {
                for (int c = 0; c < COLOANE; ++c)
                {
                    fisier.Write(tablou[b, c] + " ");
                }
                fisier.Write('\n');
            }
            fisier.Close();

        }
    }
}
