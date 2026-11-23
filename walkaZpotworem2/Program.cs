Console.WriteLine("WITAJ HEROSIE. POKONAJ GOBLINA!");
int wyborPoziomu;
do
{
    Console.WriteLine("1 - Walka z goblinem");
    Console.WriteLine("2 - Hartowanie");
    Console.WriteLine("3 - Wyprawa do lochu");
    Console.WriteLine("0 - koniec gry");
   
    Console.Write("Wybierz poziom gry: ");
    while(!int.TryParse(Console.ReadLine(), out wyborPoziomu) || wyborPoziomu < 0 || wyborPoziomu > 3)
    {
        Console.WriteLine("Wybierz 1, 2, 3 lub 0");
    }

    if (wyborPoziomu == 1)
    {
        Console.WriteLine("Wybrano walkę z goblinem.");
        Poziom1();
    }
    else if (wyborPoziomu == 2)
    {
        Console.WriteLine("Wybrano Hartowanie.");
        Poziom2();
    }
    else if (wyborPoziomu == 3)
    {
        Console.WriteLine("Wybrano Wyprawę do lochu.");
        Poziom3();
    }
    else
    {
        Console.WriteLine("Wybrano koniec gry");
    }
}
while(wyborPoziomu !=0);


static void Poziom1()
{
    int zdrowieGracza = 100;
    int zdrowiePotwora = 50;
    
    const int minimalneCiosyGracza = 10;
    const int maksymalneCiosyGracza = 20;

    const int minimalneCiosyPotwora = 5;
    const int maksymalneCiosyPotwora = 15;

    Random obrazenia = new Random();

    Console.WriteLine($"Twój aktualny stan zdrowia: {zdrowieGracza}");
    Console.WriteLine($"Aktualny stan zdrowia goblina: {zdrowiePotwora}");

    while (zdrowieGracza > 0 && zdrowiePotwora > 0)
    {
        //Gracz atakuje goblina
        Console.Write("Wpisz hit, by wykonać atak na goblina:   ");
        string hit = Console.ReadLine() ?? "";
        hit = hit.Trim().ToLowerInvariant();
        while(hit != "hit")
        {
            Console.Write("Wpisz hit, by wykonać atak na goblina:   ");
            hit = Console.ReadLine() ?? "";
            hit = hit.Trim().ToLowerInvariant();
        }

        int obrazeniaPotwora = obrazenia.Next(minimalneCiosyGracza, maksymalneCiosyGracza + 1);
        zdrowiePotwora = zdrowiePotwora - obrazeniaPotwora;
    
        //Goblin atakuje gracza
        if (zdrowiePotwora > 0)
        {int obrazeniaGracza = obrazenia.Next(minimalneCiosyPotwora, maksymalneCiosyPotwora + 1);
        zdrowieGracza = zdrowieGracza - obrazeniaGracza;

        Console.WriteLine($"Twój aktualny stan zdrowia: {zdrowieGracza}");
        Console.WriteLine($"Aktualny stan zdrowia goblina: {zdrowiePotwora}");
        }
        else
        {
        Console.WriteLine($"Twój aktualny stan zdrowia: {zdrowieGracza}");
        Console.WriteLine("Goblin nie żyje.");
        }
    }
    Console.WriteLine(zdrowiePotwora <= 0? "Zwycięstwo. Pokonałeś Goblina" :"Goblina pokonał Ciebie:()");

}

static void Poziom2()
{
    int wyborAkcji;
    bool blednyWybor;
    const int mikstura = 25;
    int liczbaMikstur = 2;

    int zdrowieGracza = 100;
    int zdrowiePotwora = 50;
    
    const int minimalneCiosyGracza = 10;
    const int srednieCiosyGracza = 15;
    const int maksymalneCiosyGracza = 20;

    const int minimalneCiosyPotwora = 5;
    const int maksymalneCiosyPotwora = 15;

    Random obrazenia = new Random();

    Console.WriteLine($"Twój aktualny stan zdrowia: {zdrowieGracza}");
    Console.WriteLine($"Aktualny stan zdrowia goblina: {zdrowiePotwora}");

    while (zdrowiePotwora > 0 && zdrowieGracza > 0)
    {
        do
        {
            Console.WriteLine("Wybierz akcję:");
            Console.WriteLine("1 - Atak mieczem");
            Console.WriteLine("2 - Mikstura lecznicza");
            Console.WriteLine("3 - Ucieczka");

            blednyWybor = !int.TryParse(Console.ReadLine(), out wyborAkcji) || wyborAkcji < 1 || wyborAkcji > 3;
        
            if (blednyWybor)
            {
            Console.WriteLine("Błąd. Wpisz 1, 2 lub 3.");
            }

        }
        while (blednyWybor);

        if (wyborAkcji == 1)
        {
            Console.WriteLine("Atakujemy mieczem!");

            string wybor;

            do
            {
                Console.WriteLine("Wybierz a lub b :");
                Console.WriteLine("a - obrażenia losowe");
                Console.WriteLine("b - obrażenia zawsze takie same");
                wybor = Console.ReadLine() ?? "";
                wybor = wybor.Trim().ToLowerInvariant();

                if(wybor !="a" && wybor != "b")
                {
                    Console.WriteLine("Błędny wybór.");
                }
            }
            while (wybor != "a" && wybor != "b");

            Console.Write("Wpisz hit, by wykonać atak na goblina:   ");
            string hit = Console.ReadLine() ?? "";
            hit = hit.Trim().ToLowerInvariant();
            while(hit != "hit")
            {
                Console.Write("Wpisz hit, by wykonać atak na goblina:   ");
                hit = Console.ReadLine() ?? "";
                hit = hit.Trim().ToLowerInvariant();
            }

            if (wybor == "a")
            {

                int obrazeniaPotwora = obrazenia.Next(minimalneCiosyGracza, maksymalneCiosyGracza + 1);
                zdrowiePotwora = zdrowiePotwora - obrazeniaPotwora;
             
            }
          
            else

            {

                zdrowiePotwora = zdrowiePotwora - srednieCiosyGracza;
            }
                
            
    
        }
        else if (wyborAkcji == 2)
        {
            if (liczbaMikstur > 0)
            {
                Console.WriteLine("Wybrano miksturę leczniczą.");
                liczbaMikstur = liczbaMikstur - 1;
                zdrowieGracza = zdrowieGracza + mikstura;
                Console.WriteLine($"Twój aktualny stan zdrowia wynosi {zdrowieGracza}.");
                Console.WriteLine($"Pozostało {liczbaMikstur} z dostępnych mikstur");

            }
            else
            {
                Console.WriteLine("Nie masz już żadnej mikstury. Wybierz inną akcję");
                continue;
            }
        }
        else
        {
            Console.WriteLine("Uciekamy!");
            return;
        }

        if (zdrowiePotwora > 0)
                {
                    int obrazeniaGracza = obrazenia.Next(minimalneCiosyPotwora, maksymalneCiosyPotwora + 1);
                    zdrowieGracza = zdrowieGracza - obrazeniaGracza;

                    Console.WriteLine($"Po ataku goblina Twój aktualny stan zdrowia: {zdrowieGracza}");
                    Console.WriteLine($"Aktualny stan zdrowia goblina: {zdrowiePotwora}");
                }
                else
                {
                    Console.WriteLine($"Twój aktualny stan zdrowia: {zdrowieGracza}");
                    Console.WriteLine("Goblin nie żyje.");
                }

    }
    Console.WriteLine(zdrowiePotwora <= 0? "Zwycięstwo. Pokonałeś Goblina" : "Goblina pokonał Ciebie:()");
    
}


static void Poziom3()
{
    Console.WriteLine("Wybrano Wyprawę do lochu.");
    Console.WriteLine("Zwyciężaj potwory i osiągaj kolejne poziomy w grze!");

    const int maksymalneZdrowieGracza = 100;
    const int liczbaPotworow = 3;
    const int bazoweZdrowiePotwora = 30;
    const int przyrostZdrowiaPotwora = 15;
    const int regeneracjaPoZwyciestwie = 20;
    
    
    int zdrowieGracza = maksymalneZdrowieGracza;
    int zdrowiePotwora;
    int numerPotwora = 1;
    int doswiadczenie = 0;
    int poziom = doswiadczenie + 1;
    bool zwyciestwo;

    const int minimalneCiosyGracza = 10;
    const int maksymalneCiosyGracza = 20;

    const int minimalneCiosyPotwora = 5;
    const int maksymalneCiosyPotwora = 15;

    Random obrazenia = new Random();

    for (int i = numerPotwora; i <= liczbaPotworow; i++)
    {
        zdrowiePotwora = bazoweZdrowiePotwora + i * przyrostZdrowiaPotwora;
        Console.WriteLine($"Twój aktualny stan zdrowia: {zdrowieGracza}");
        Console.WriteLine($"Aktualny stan zdrowia goblina: {zdrowiePotwora}");

        while(zdrowiePotwora > 0 && zdrowieGracza > 0)
        {
            //Gracz atakuje goblina
            Console.Write("Wpisz hit, by wykonać atak na goblina:   ");
            string hit = Console.ReadLine() ?? "";
            hit = hit.Trim().ToLowerInvariant();
            while(hit != "hit")
            {
                Console.Write("Wpisz hit, by wykonać atak na goblina:   ");
                hit = Console.ReadLine() ?? "";
                hit = hit.Trim().ToLowerInvariant();
            }

            int obrazeniaPotwora = obrazenia.Next(minimalneCiosyGracza, maksymalneCiosyGracza + 1);
            zdrowiePotwora = zdrowiePotwora - obrazeniaPotwora;
    
            //Goblin atakuje gracza
            if (zdrowiePotwora > 0)
            {
                int obrazeniaGracza = obrazenia.Next(minimalneCiosyPotwora, maksymalneCiosyPotwora + 1);
                zdrowieGracza = zdrowieGracza - obrazeniaGracza;

                Console.WriteLine($"Twój aktualny stan zdrowia: {zdrowieGracza}");
                Console.WriteLine($"Aktualny stan zdrowia goblina: {zdrowiePotwora}");
            
            }
            if (zdrowieGracza <=0)
            {
                break;
            }
        }

        zwyciestwo = zdrowiePotwora <=0;

        if(zwyciestwo)
        {
            doswiadczenie ++;
            zdrowieGracza = zdrowieGracza + regeneracjaPoZwyciestwie;
            if (zdrowieGracza > maksymalneZdrowieGracza)
            {
                zdrowieGracza = maksymalneZdrowieGracza;
            }
            poziom = doswiadczenie + 1;
        }
        else
        {
            Console.WriteLine("Game over.");
            break;
        }

        Console.WriteLine($"Pokonano {doswiadczenie} potworów. Aktualny poziom gracza: {poziom}.");
    }
    

}


