// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

int totalPlayer = 0;
int totalDealer = 0;
int numPlayer = 0;
int numDealer = 0;
string message = "";
string switchControl = "menu";
var coins = 0;

// BlackJack, Juntar 21 juntando carta o en caso de tener menos
// de 21 igual tener mayor puntación que el dealer


while (switchControl != "exit")
{
    if(switchControl == "menu" && coins < 1)
    {
        Console.WriteLine("Cuantas coins quieres comprar?");
        coins = Convert.ToInt32(Console.ReadLine());
    }
    totalDealer = 0; totalPlayer = 0;
    var play = "";

    switch (switchControl)
    {
        case "menu":
            Console.WriteLine($"Welcome al  c a s i n o, Tus coins: {coins}");
            Console.WriteLine("Escriba '21' para jugar al 21");
            switchControl = Console.ReadLine();
            break;

        case "21":
            do
            {
                numPlayer = new Random().Next(1, 12);
                totalPlayer = totalPlayer + numPlayer;
                Console.WriteLine($"Toma tu carta, jugador te salio el numero: {numPlayer}");

                numDealer = new Random().Next(1, 12);
                if(numDealer + totalDealer < 21)
                {
                    totalDealer = totalDealer + numDealer;
                }

                if(totalDealer > 21 || totalPlayer > 21 )
                {
                    play = "No";
                }
                else
                {
                    Console.WriteLine("Quieres otra Carta?! Si / No");
                    play = Console.ReadLine();
                }

            } while (coins > 0 && play == "Si" || play == "si" || play == "SI" || play == "yes" || play == "Yes" || play == "YES");

            if (totalPlayer > totalDealer && totalPlayer < 22)
            {
                message = $"Venciste al dealer felicidades. Tu: {totalPlayer}, Dealer: {totalDealer}" ;
            }
            else if (totalPlayer <= totalDealer || totalPlayer > 21)
            {
                message = $"Perdistes la casa gana, Lo siento . Tu: {totalPlayer}, Dealer: {totalDealer}";
            }
            else
            {
                message = "Condicion no valida";
            }
            Console.WriteLine(message);
            coins--;
            Console.WriteLine("Escriba 'exit para salir, o '21' para jugar de nuevo");
            switchControl = Console.ReadLine();
            break;

        default:
            Console.WriteLine("Valor ingresado no valido");
            switchControl = "exit";
            break;
    }

    if (coins == 0 && switchControl != "exit")
    {
        switchControl = "menu";
        Console.WriteLine($"Te Quedan {coins} coins");
    }
}
