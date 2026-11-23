decimal cena, rabat, cenaPo;
bool czyAkceptacja = false;
string wybor;

PobierzCene("Wpisz cenę.", out cena);

do
{
    do
    {
        Console.WriteLine("Rabat procentowy - wpisz a . Rabat kwotowy - wpisz b .");
        wybor = Console.ReadLine() ?? "";
        wybor = wybor.Trim().ToLowerInvariant();
    }
    while(wybor != "a" && wybor != "b");

    if(wybor == "a")
    {
        PobierzRabat("Podaj wartość rabatu.", 100, out rabat);
        
        if(rabat != 0 && rabat != 100)
        {
            czyAkceptacja = true;
            cenaPo = cena * (100 - rabat) / 100;
            Console.WriteLine($"Cena po rabacie wynosi {cenaPo} zł.");
        }
        else
        {
            if (rabat == 0)
            {
                czyAkceptacja = PobierzPotwierdzenie("Czy potwierdzasz rabat 0%? Wpisz t lub n.");
                if(czyAkceptacja)
                {
                    Console.WriteLine($"Potwierdzono rabat 0%. Cena wynosi {cena} zł.");
                }
            }
            else
            {
                czyAkceptacja = PobierzPotwierdzenie("Czy potwierdzasz rabat 100%? Wpisz t lub n.");
                if(czyAkceptacja)
                {
                    Console.WriteLine("Produkt darmowy. Pamiętaj o VAT.");
                }
            }
        }
    }
    else
    {
        PobierzRabat("Podaj wartość rabatu.", cena, out rabat);
        if(rabat != 0 && rabat != cena)
        {
            czyAkceptacja = true;
            cenaPo = cena - rabat;
            Console.WriteLine($"Cena po rabacie wynosi {cenaPo} zł.");
        }
        else
        {
            if (rabat == 0)
            {
                czyAkceptacja = PobierzPotwierdzenie("Czy potwierdzasz rabat 0 zł? Wpisz t lub n.");
                if (czyAkceptacja)
                {
                    Console.WriteLine($"Potwierdzono rabat 0 zł. Cena wynosi {cena} zł.");
                }
            }
            else
            {
                czyAkceptacja = PobierzPotwierdzenie("Czy potwierdzasz rabat kwotowy równy cenie? Wpisz t lub n.");
                if (czyAkceptacja)
                {
                    Console.WriteLine("Produkt darmowy. Pamiętaj o VAT.");
                }
            }
        }
    }
}
while(!czyAkceptacja);


void PobierzCene(string komunikat1, out decimal cena)
{
    Console.WriteLine(komunikat1);
    while(!decimal.TryParse(Console.ReadLine(), out cena) || cena <=0)
    {
        Console.WriteLine(komunikat1);
    }
    Console.WriteLine($"Wprowadzono cenę {cena} zł.");
}

void PobierzRabat(string komunikat2, decimal maksymalnyRabat, out decimal rabat)
{
    Console.WriteLine(komunikat2);
    while (!decimal.TryParse(Console.ReadLine(), out rabat) || rabat < 0 || rabat > maksymalnyRabat)
        {
            Console.WriteLine(komunikat2);
        }
}
  

bool PobierzPotwierdzenie(string komunikat3)
{
    string odpowiedz;
    
    do
    {
        Console.WriteLine(komunikat3);
        odpowiedz = Console.ReadLine() ?? "";
        odpowiedz = odpowiedz.Trim().ToLowerInvariant();
    }
    while (odpowiedz != "t" && odpowiedz != "n");

    if (odpowiedz == "t")
    {
        return true;
    }
    else
    {
        return false;
    }
}

