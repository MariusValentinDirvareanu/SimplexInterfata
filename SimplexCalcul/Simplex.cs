using System.IO;
using System.Windows.Controls;

namespace SimplexCalcul
{
    public class Simplex
    {
        public int j { get; set; } = 0;
        public int i { get; set; } = 0;
        public Fraction Pivot { get; private set; } = new Fraction(0, 1);
        public Fraction PivotDoi { get; private set; } = new Fraction(0, 1);
        public Fraction PivotUnu { get; private set; } = new Fraction(0, 1);
        public int Pozitie { get; private set; } = 0;
        public int jj { get; private set; } = 0;
        public int COLOANE { get; set; } = 0;
        public int LINII { get; set; } = 0;
        public Fraction[,] Tablou { get; private set; } = new Fraction[10, 10];
        public StreamWriter Fisier { get; private set; } = new StreamWriter("fisier.txt");

        // Partea de programe utilitare

        public void SetareColoaneSiLinii(int rand, int coloana)
        {
            COLOANE = coloana + i;
            LINII = rand - 4;
        }

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
            Fraction min = new Fraction(0, 1);
            int poz = 0;
            for (int e = 0; e < COLOANE; ++e)
            {
                if (min >= Tablou[LINII - 1, e])
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
                if (minim > Tablou[ii, COLOANE - 1] / Tablou[ii, jj] && Tablou[ii, jj] != new Fraction(0, 1))
                {
                    minim = Tablou[ii, COLOANE - 1] / Tablou[ii, jj];
                    Pivot = Tablou[ii, jj];
                    Pozitie = ii;
                }
            }
        }


        private void ImpartireLaPivot()
        {
            // Imparte linia pivotului la pivot
            for (int counter = 0; counter < COLOANE; ++counter)
            {
                Tablou[Pozitie, counter] /= Pivot;
            }
        }

        private void LiniiPrecedentePivotului()
        {
            // Modifica liniile precedente pivotului
            for (int counter1 = 0; counter1 < Pozitie; ++counter1)
            {
                PivotUnu = Tablou[counter1, jj];
                for (int counter2 = 0; counter2 < COLOANE; ++counter2)
                {
                    Tablou[counter1, counter2] = Tablou[counter1, counter2] - PivotUnu * Tablou[Pozitie, counter2];
                }
            }
        }

        private void LiniiSuccesoarePivotului()
        {
            // Modifica liniile succesoare pivotului
            for (int counter1 = Pozitie + 1; counter1 < LINII; ++counter1)
            {
                PivotDoi = Tablou[counter1, jj];
                for (int counter2 = 0; counter2 < COLOANE; ++counter2)
                {
                    Tablou[counter1, counter2] = Tablou[i, counter2] - PivotDoi * Tablou[Pozitie, counter2];
                }
            }
        }

        public void VariabileAditionale(int rand, int coloana)
        {
            for (int counter1 = 0; counter1 < rand - 4; ++counter1)
            {
                for (int counter2 = coloana - 2; counter2 < coloana - 1 + i; ++counter2)
                {
                    if (counter1 == (counter2 - (coloana - 2)))
                    {
                        Tablou[counter1, counter2].Numerator = 1;
                        Tablou[counter1, counter2].Denominator = 1; 
                    }
                }
            }
        }

        public void ExtragereRezultateRestrictii(TextBox[] rezultateRestrictii, int rand, int coloana)
        {
            for (int counter = 0; counter < rand - 5; ++counter)
            {
                if (rezultateRestrictii[counter].Text != string.Empty)
                {
                    Tablou[counter, coloana - 1 + i].Numerator = int.Parse(rezultateRestrictii[counter].Text);
                    Tablou[counter, coloana - 1 + i].Denominator = 1;
                }
            }
        }

        public void ExtragereEcuatie(TextBox[] ecuatie, int rand, int coloana)
        {
            for (int counter = 0; counter < coloana - 2; ++counter)
            {
                if (ecuatie[counter].Text != string.Empty)
                {
                    Tablou[rand - 5, counter].Numerator = int.Parse(ecuatie[counter].Text) * (-1);
                    Tablou[rand - 5, counter].Denominator = 1;
                }
            }
        }

        public void ExtragereRestrictii(TextBox[,] restrictii, int rand, int coloana)
        {
            for (int counter1 = 0; counter1 < rand - 5; ++counter1)
            {
                for (int counter2 = 0; counter2 < coloana - 2; ++counter2)
                {
                    if (restrictii[counter1, counter2].Text != string.Empty)
                    {
                        Tablou[counter1, counter2].Numerator = int.Parse(restrictii[counter1, counter2].Text);
                        Tablou[counter1, counter2].Denominator = 1;
                    }
                }
            }
        }

        public void ScriereInFisier(int Rand, int Coloana)
        {
            for(int counter = 0; counter < Coloana; ++counter)
            {
                Fisier.Write($"x{counter}" + "\t\t");
            }
            for (int counter = 0; counter < Rand; ++counter)
            {
                Fisier.Write($"s{counter}" + "\t\t");
            }
            Fisier.Write("P" + "\t\t\t\t");
            Fisier.Write('\n');

            for (int counter1 = 0; counter1 < LINII; ++counter1)
            {
                for (int counter2 = 0; counter2 < COLOANE; ++counter2)
                {
                    if (Tablou[counter1, counter2].Numerator == 0)
                    {
                        Fisier.Write("0\t\t");
                    }
                    else
                    {
                        if (Tablou[counter1, counter2].Denominator == 1)
                        {
                            Fisier.Write(Tablou[counter1, counter2].Numerator + "\t\t");
                        }
                        else
                        {
                            Fisier.Write(Tablou[counter1, counter2] + "\t\t");
                        }
                    }
                }
                Fisier.Write('\n');
            }
            Fisier.Write("\n\n");
        }

        public void Maximizare(int Rand,int Coloana)
        {
            while (LiniePozitiva() == false)
            {
                // Pozitia pe coloana a minimului de pe ultima linie
                jj = MinNegativ();

                GasestePivot();

                ImpartireLaPivot();

                LiniiPrecedentePivotului();

                LiniiSuccesoarePivotului();

                ScriereInFisier(Rand, Coloana);
            }
        }
        public void InitializareTablou()
        {
            for (int counter = 0; counter < 8; ++counter)
            {
                for (int j = 0; j < 8; ++j)
                {
                    Tablou[counter, j] = new Fraction(0, 1);
                }
            }
        }

    }
}
