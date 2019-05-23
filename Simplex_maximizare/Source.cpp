#include <iostream>
#include <map>
#include <string>
#include <vector>
#include <fstream>

using namespace std;


vector<vector<double>> m;
int COLOANE;
int LINII;
map<string, double> solutie;
string numeFisier, tip;
ofstream f;

// Afiseaza matricea
void afisareMatrice() {
	cout << "Tabel valori\n";
	f << "Tabel valori\n";
	for (int i = 0; i < LINII; ++i) {
		for (int j = 0; j < COLOANE; ++j) {
			printf("%f ", m[i][j]);
			f << m.at(i).at(j) << ' ';
		}
		cout << "\n";
		f << "\n";
	}
	cout << "_________________________________________________\n";
	f << "_________________________________________________\n";
}

// Verifica daca ultima linie este pozitiva
bool liniePozitiva() {
	for (int i = 0; i < COLOANE; ++i) {
		if (m[LINII - 1][i] < 0) {
			return false;
		}
	}
	return true;
}

// Gaseste minimul de pe ultima linie
int minNegativ() {
	double min = 0;
	int poz = 0;
	for (int e = 0; e < COLOANE; ++e) {
		if (min > m[LINII - 1][e]) {
			min = m[LINII - 1][e];
			poz = e;
		}
	}
	return poz;
}

void AfisareSolutie()
{
	// Afiseaza solutia in cazul MAXIMIZARII si MINIMIZARII
	cout << "Valori rezultate: \n";
	for (auto &val : solutie) {
		cout << val.first << "=" << val.second << '\n';
	}
}

void ValoriPrincipale()
{
	// Memoreaza valorile variabilelor principale pentru a afisa solutia in cazul MAXIMIZARII
	for (int i = 0; i < (COLOANE - 2) / 2; ++i) {
		int k = 0;
		int pozz;
		for (int j = 0; j < LINII - 1; ++j) {
			if (m[j][i] != 0) {
				k++;
				pozz = j;
			}
		}
		if (k == 1) {
			solutie.emplace("x(" + to_string(i + 1) + ")", m[pozz][COLOANE - 1]);
		}
		else {
			solutie.emplace("x(" + to_string(i + 1) + ")", 0);
		}
	}
}

void ValoriSecundareMinimizare()
{
	// Memoreaza valorile variabilelor secundare pentru a afisa solutia in cazul MINIMIZARII
	for (int i = 0; i < (COLOANE - 2) / 2; ++i) {
		solutie.emplace("s(" + to_string(i + 1) + ")", m[LINII - 1][i]);
	}
}

void ValoriPrincipaleMinimizare()
{
	// Memoreaza valorile variabilelor principale pentru a afisa solutia in cazul MINIMIZARII
	for (int i = (COLOANE - 2) / 2; i < COLOANE - 2; ++i) {
		solutie.emplace("x(" + to_string(i + 1) + ")", m[LINII - 1][i]);
	}
}

void ValoriSecundare()
{
	// Memoreaza valorile variabilelor secundare pentru a afisa solutia in cazul MAXIMIZARII
	for (int i = (COLOANE - 2) / 2; i < COLOANE - 2; ++i) {
		int k = 0;
		int pozz;
		for (int j = 0; j < LINII - 1; ++j) {
			if (m[j][i] != 0) {
				k++;
				pozz = j;
			}
		}
		if (k == 1) {
			solutie.emplace("s(" + to_string(i + 1) + ")", m[pozz][COLOANE - 1]);
		}
		else {
			solutie.emplace("s(" + to_string(i + 1) + ")", 0);
		}
	}
}

void GasestePivot(double &minim, int &i, int j, double &pivot, int &pozitie)
{
	// Gaseste pivotul
	minim = 9999;
	for (i = 0; i < LINII - 1; ++i) {
		if (minim > m[i][COLOANE - 1] / m[i][j] && m[i][j]!=0) {
			minim = m[i][COLOANE - 1] / m[i][j];
			pivot = m[i][j];
			pozitie = i;
		}
	}
}

void ImpartireLaPivot(int &i, int pozitie, double pivot)
{
	// Imparte linia pivotului la pivot
	for (i = 0; i < COLOANE; ++i) {
		m[pozitie][i] /= pivot;
	}
}

void LiniiPrecedentePivotului(int &i, int pozitie, double &pivotUnu, int j, int &j1)
{
	// Modifica liniile precedente pivotului
	for (i = 0; i < pozitie; ++i) {
		pivotUnu = m[i][j];
		for (j1 = 0; j1 < COLOANE; ++j1) {
			m[i][j1] = m[i][j1] - pivotUnu * m[pozitie][j1];
		}
	}
}

void LiniiSuccesoarePivotului(int &i, int pozitie, double &pivotDoi, int j, int &j2)
{
	// Modifica liniile succesoare pivotului
	for (i = pozitie + 1; i < LINII; ++i) {
		pivotDoi = m[i][j];
		for (j2 = 0; j2 < COLOANE; ++j2) {
			m[i][j2] = m[i][j2] - pivotDoi * m[pozitie][j2];
		}
	}
}

int main() {
	string semn;
	cout << "Nume fisier=";
	cin >> numeFisier;
	f.open(numeFisier + ".txt");
	cout << "Tipul de calcul (Ma pentru maximizare/ Mi pentru minimizare)\n";
	cin >> tip;
	double pivot = 0, minim, pivotUnu, pivotDoi, var;
	int j = 0, i, pozitie = 0, j1, j2, nrVar, restrictii, k;
	vector<double> temp;


	cout << "Introduceti numarul de variabile : ";
	cin >> nrVar;
	cout << "Inroduce numarul de restrictii : ";
	cin >> restrictii;

	if (tip == "Ma") {
		COLOANE = nrVar + restrictii + 2;
		LINII = restrictii + 1;
		// Alocare matrice

		for (i = 0; i < LINII; ++i) {
			for (j = 0; j < COLOANE; ++j) {

				temp.push_back(0);
			}
			m.push_back(temp);
		}
		afisareMatrice();
		// Introducere Valori
		cout << "Introduceti coeficientii variabilelor ecuatiei\n";
		for (i = 0; i < nrVar; ++i) {
			cin >> var;
			m.at(LINII - 1).at(i) = -var;
		}
		m.at(LINII - 1).at(COLOANE - 2) = 1;
		k = COLOANE - restrictii - 2;
		cout << "Introduceti semnul + coeficientii variabilelor restrictiilor + rezultatul inegalitatii\n";
		for (j = 0; j < restrictii; ++j) {
			cout << "Restrictia " << j + 1 << '\n';
			cin >> semn;
			for (i = 0; i < nrVar; ++i) {
				cin >> var;
				if (semn == ">")
					m.at(j).at(i) = -var;
				else
					m.at(j).at(i) = var;
			}
			m.at(j).at(k) = 1;
			k++;
			cin >> var;
			if(semn ==">")
				m.at(j).at(COLOANE - 1) = -var;
			else
				m.at(j).at(COLOANE - 1) = var;
		}


		afisareMatrice();

		cout << '\n';

		while (liniePozitiva() == false) {
			// Pozitia pe coloana a minimului de pe ultima linie
			j = minNegativ();

			GasestePivot(minim, i, j, pivot, pozitie);

			ImpartireLaPivot(i, pozitie, pivot);

			LiniiPrecedentePivotului(i, pozitie, pivotUnu, j, j1);

			LiniiSuccesoarePivotului(i, pozitie, pivotDoi, j, j2);

			afisareMatrice();
		}


		ValoriPrincipale();

		ValoriSecundare();

		// Solutia ecuatiei
		solutie.emplace("P", m[LINII - 1][COLOANE - 1]);

		cout << '\n';
		f.close();
		AfisareSolutie();
	}
	else {
		if (tip == "Mi") {
			COLOANE = nrVar + restrictii + 2;
			LINII = nrVar + 1;
			// Alocare matrice

			for (i = 0; i < LINII; ++i) {
				for (j = 0; j < COLOANE; ++j) {

					temp.push_back(0);
				}
				m.push_back(temp);
			}
			afisareMatrice();
			// Introducere Valori
			cout << "Introduceti coeficientii variabilelor ecuatiei\n";
			for (i = 0; i < nrVar; ++i) {
				cin >> var;
				m.at(i).at(COLOANE-1) = var;
			}
			m.at(LINII - 1).at(COLOANE - 2) = 1;
			k = restrictii;
			cout << "Introduceti coeficientii variabilelor restrictiilor + rezultatul inegalitatii\n";
			for (j = 0; j < restrictii; ++j) {
				cout << "Restrictia " << j + 1 << '\n';
				cin >> semn;
				for (i = 0; i < nrVar; ++i) {
					cin >> var;
					if(semn == "<")
						m.at(i).at(j) = -var;
					else
						m.at(i).at(j) = var;
				}
				cin >> var;
				if (semn == "<")
					m.at(LINII-1).at(j) = -var;
				else
					m.at(LINII - 1).at(j) = var;
			}
			for (i = 0; i < LINII; ++i) {
				m.at(i).at(k) = 1;
				k++;
			}


			afisareMatrice();

			cout << '\n';

			while (liniePozitiva() == false) {
				// Pozitia pe coloana a minimului de pe ultima linie
				j = minNegativ();

				GasestePivot(minim, i, j, pivot, pozitie);

				ImpartireLaPivot(i, pozitie, pivot);

				LiniiPrecedentePivotului(i, pozitie, pivotUnu, j, j1);

				LiniiSuccesoarePivotului(i, pozitie, pivotDoi, j, j2);

				afisareMatrice();
			}


			ValoriPrincipaleMinimizare();

			ValoriSecundareMinimizare();

			// Solutia ecuatiei
			solutie.emplace("C", m[LINII - 1][COLOANE - 1]);

			cout << '\n';
			f.close();
			AfisareSolutie();

		}
		else {
			cout << "Nu ati ales corect!";
		}
	}
	system("PAUSE");
	return 0;
}