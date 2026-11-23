Console.WriteLine("Sprawdzamy pełnoletniość i zbieramy punkty.");

Console.Write("Podaj nazwę użytkownika: ");
string nazwa = Console.ReadLine() ?? "";

Console.Write ("Podaj swój wiek: ");

int wiek;
bool czyPelnoletni;
int saldo = 9;
int punkty;
string wybor;
StanKonta stanKonta = StanKonta.Ograniczone;

while (!int.TryParse(Console.ReadLine(), out wiek) || wiek < 0)

{   Console.WriteLine("Proszę podać wiek jako liczbę");
    Console.Write("Podaj swój wiek: ");
}

if (wiek >= 18)
{
    czyPelnoletni = true;
}
else
{
    czyPelnoletni = false;
}

Pelnoletniosc stan = czyPelnoletni ? Pelnoletniosc.Pełnoletnia : Pelnoletniosc.Niepełnoletnia;

Console.WriteLine($"Twój wiek to {wiek}");
Console.WriteLine($"Zostałeś zakwalifikowany jako Osoba {stan}");

if (czyPelnoletni)
{
    int licznik = 0;
    do {
    Console.WriteLine($"Twoje saldo wynosi {saldo}");
    Console.WriteLine(" Wykonaj działanie.");
    Console.WriteLine("1 - dodaj punkty");
    Console.WriteLine("2 - odejmij punkty");

    wybor = Console.ReadLine() ?? "";
    
    switch (wybor)
    {
        case "1":
        Console.Write("Podaj liczbę punktów: ");
        if(int.TryParse(Console.ReadLine(), out punkty) && punkty > 0)
            {
                saldo += punkty; 
            }
            else
            {
                Console.WriteLine("Niepoprawna wartośc.");
            }
            break;

        case "2":
        Console.Write("Podaj liczbę punktów: ");
        if(int.TryParse(Console.ReadLine(), out punkty) && punkty > 0)
        if (saldo < 10)
                {
                    Console.WriteLine("Nie możesz odjąć punktów");
                }
        else
                {
                    if (saldo >= punkty)
                    {
                        saldo -= punkty;
                    }
                    else
                    {
                        Console.WriteLine("Niepoprawna wartośc.");
                    }
                }
        else
            {
                Console.WriteLine("Niepoprawna wartośc.");
            }
            break;

        default: 
        Console.WriteLine("Nie ma takiej opcji");
        break;
    }
    if (saldo < 10)
    {
        stanKonta  = StanKonta.Ograniczone;
    }
    else if (saldo < 20)
    {
        stanKonta  = StanKonta.AktywneSlabe;
    }
    else if (saldo < 60)
    {
        stanKonta  = StanKonta.AktywneDobre;
    }
    else if (saldo < 100)
    {
        stanKonta  = StanKonta.AktywneBardzoDobre;
    }
    else if (saldo >= 100)
    {
        stanKonta = StanKonta.AktywnePoziom2;
    }
    Console.WriteLine($"Liczba punktów wynosi {saldo}. Status Twojego konta to {stanKonta}");
    licznik++;
    }
    while(licznik < 2);
}
else
{
    Console.WriteLine ("Koniec programu.");
}


enum Pelnoletniosc
{
    Pełnoletnia,
    Niepełnoletnia,

}

enum StanKonta
{
    Ograniczone,

    AktywneSlabe,

    AktywneDobre,

    AktywneBardzoDobre,

    AktywnePoziom2
}