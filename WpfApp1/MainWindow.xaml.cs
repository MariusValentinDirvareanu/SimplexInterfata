using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace SimplexCalcul
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int coloana { get; set; } = 2;
        private int rand { get; set; } = 5;
        private TextBox[,] restrictii { get; set; } = new TextBox[8, 8];
        private int j { get; set; } = 0;
        private TextBox[] ecuatie { get; set; } = new TextBox[8];
        private TextBox[] rezultateRestrictii { get; set; } = new TextBox[8];
        private ComboBox[] semne { get; set; } = new ComboBox[8];
        private Fraction pivot { get; set; } = new Fraction(0, 1);
        private Fraction PivotDoi { get; set; } = new Fraction(0, 1);
        private Fraction pivotUnu { get; set; } = new Fraction(0, 1);
        private int pozitie { get; set; } = 0;
        private int jj { get; set; } = 0;
        private int COLOANE { get; set; } = 0;
        private int LINII { get; set; } = 0;
        private Fraction[,] Tablou { get; set; } = new Fraction[8, 8];
        private StreamWriter Fisier { get; set; } = new StreamWriter("fisier.txt");
        private int i { get; set; } = 0;

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
                semne[0].Items.Add("<=");
                semne[0].Items.Add(">=");
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
                semne[rand - 4].Items.Add("<=");
                semne[rand - 4].Items.Add(">=");
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
                semne[0].Items.Add("<=");
                semne[0].Items.Add(">=");
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
                if (Tablou[LINII - 1, ii] < 0)
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
                if (min > Tablou[LINII - 1, e])
                {
                    min = Tablou[LINII - 1, e];
                    poz = e;
                }
            }
            return poz;
        }

        private void GasestePivot()
        {
            // Gaseste pivotul
            Fraction minim = new Fraction(long.MaxValue, 1);
            for (int ii = 0; ii < LINII - 1; ++ii)
            {
                if (minim > Tablou[ii, COLOANE - 1] / Tablou[ii, jj] && Tablou[ii, jj] != new Fraction(0,1))
                {
                    minim = Tablou[ii, COLOANE - 1] / Tablou[ii, jj];
                    pivot = Tablou[ii, jj];
                    pozitie = ii;
                }
            }
        }


        private void ImpartireLaPivot()
        {
            // Imparte linia pivotului la pivot
            for (int ii = 0; ii < COLOANE; ++ii)
            {
                Tablou[pozitie, ii] /= pivot;
            }
        }

        private void LiniiPrecedentePivotului()
        {
            // Modifica liniile precedente pivotului
            for (int ii = 0; ii < pozitie; ++ii)
            {
                pivotUnu = Tablou[ii, jj];
                for (int j1 = 0; j1 < COLOANE; ++j1)
                {
                    Tablou[ii, j1] = Tablou[ii, j1] - pivotUnu * Tablou[pozitie, j1];
                }
            }
        }

        private void LiniiSuccesoarePivotului()
        {
            // Modifica liniile succesoare pivotului
            for (int ii = pozitie + 1; ii < LINII; ++ii)
            {
                PivotDoi = Tablou[ii, jj];
                for (int j2 = 0; j2 < COLOANE; ++j2)
                {
                    Tablou[ii, j2] = Tablou[i, j2] - PivotDoi * Tablou[pozitie, j2];
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

                ScriereInFisier();
            }
        }

        // Buton de rezolvare
        private void Calcul_Click(object sender, RoutedEventArgs e)
        {
            ExtragereRestrictii();
            ExtragereEcuatie();
            ExtragereRezultateRestrictii();

            for (int cc = 0; cc < rand - 4; ++cc)
            {
                for (int r = coloana - 2; r < coloana - 1 + i; ++r)
                {
                    if (cc == (r - (coloana - 2)))
                    {
                        Tablou[cc, r].Numerator = 1;
                        Tablou[cc, r].Denominator = 1;

                    }
                }
            }


            COLOANE = coloana + i;
            LINII = rand - 4;

            ScriereInFisier();
            Maximizare();
            Fisier.Close();
            MessageBox.Show("Gata!");

        }

        private void ExtragereRezultateRestrictii()
        {
            for (int c = 0; c < rand - 5; ++c)
            {
                if (rezultateRestrictii[c].Text != string.Empty)
                {
                    Tablou[c, coloana - 1 + i].Numerator = int.Parse(rezultateRestrictii[c].Text);
                    Tablou[c, coloana - 1 + i].Denominator = 1;
                }
            }
        }

        private void ExtragereEcuatie()
        {
            for (int b = 0; b < coloana - 2; ++b)
            {
                if (ecuatie[b].Text != string.Empty)
                {
                    Tablou[rand - 5, b].Numerator = int.Parse(ecuatie[b].Text) * (-1);
                    Tablou[rand - 5, b].Denominator = 1;
                }
            }
        }

        private void ExtragereRestrictii()
        {
            for (int b = 0; b < rand - 5; ++b)
            {
                for (int c = 0; c < coloana - 2; ++c)
                {
                    if (restrictii[b, c].Text != string.Empty)
                    {
                        Tablou[b, c].Numerator = int.Parse(restrictii[b, c].Text);
                        Tablou[b, c].Denominator = 1;
                    }
                }
            }
        }

        private void ScriereInFisier()
        {
            for (int b = 0; b < LINII; ++b)
            {
                for (int c = 0; c < COLOANE; ++c)
                {
                    if (Tablou[b, c].Denominator == 1)
                    {
                        Fisier.Write(Tablou[b, c].Numerator + " ");
                    }
                    else
                    {
                        Fisier.Write(Tablou[b, c] + " ");
                    }
                }
                Fisier.Write('\n');
            }
            Fisier.Write("\n\n");
        }
        private void Window_Initialized(object sender, System.EventArgs e)
        {
            for (int i = 0; i < 8; ++i)
            {
                for (int j = 0; j < 8; ++j)
                {
                    Tablou[i, j] = new Fraction(0, 1);
                }
            }
        }
    }
}
