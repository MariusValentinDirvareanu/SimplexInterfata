using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplexCalcul
{
    class Simplex
    {
        private double pivot { get; set; } = 0;
        private double pivotDoi { get; set; } = 0;
        private double pivotUnu { get; set; } = 0;
        private int pozitie { get; set; } = 0;
        private int jj { get; set; } = 0;
        private int COLOANE { get; set; } = 0;
        private int LINII { get; set; } = 0;
        private double[,] tablou { get; set; } = new double[1000, 1000];
        private StreamWriter fisier { get; set; } = new StreamWriter("fisier.txt");
        private int i { get; set; } = 0;
        private bool LiniePozitiva()
        {
            for (int ii = 0; ii < COLOANE; ++ii)
            {
                if (tablou[LINII - 1, ii] < 0)
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
                if (min > tablou[LINII - 1, e])
                {
                    min = tablou[LINII - 1, e];
                    poz = e;
                }
            }
            return poz;
        }

        private void GasestePivot()
        {
            // Gaseste pivotul
            double minim = double.MaxValue;
            for (int ii = 0; ii < LINII - 1; ++ii)
            {
                if (minim > tablou[ii, COLOANE - 1] / tablou[ii, jj] && tablou[ii, jj] != 0)
                {
                    minim = tablou[ii, COLOANE - 1] / tablou[ii, jj];
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
    }
}
