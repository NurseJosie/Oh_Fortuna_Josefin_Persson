using System;  //behövs
using System.Collections.Generic;  //för att kunna använda random...
//using System.Linq;       TA BORT?
//using System.Text;         TA BORT?
//using System.Threading.Tasks;       TA BORT?
using System.Threading; // thread/paus...

namespace Oh_Fortuna_Josefin_Persson
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            int userPix = 500;
            int dice = 0;
            int userLuckyNum = 0;
            int userBet = 0;
            int correctGuesses = 0;

            while (userPix > 50)
            {
                correctGuesses = 0;  //ställer om antal korrekta tärningar inför varje kast. behövs inne i while-loopen för att återställas varje kast. 

                Console.WriteLine("Nu spelar vi Oh Fortuna! Skåda in i stjärnorna och välj ett lyckotal mellan 1-6...");
                userLuckyNum = int.Parse(Console.ReadLine());       //      OBS, inte så vi lärt oss... 

                if (userLuckyNum <= 6 && userLuckyNum >= 1)    // DET GÅR ATT ANGE NEGATIVA TAL!!!
                {
                    Console.WriteLine("Du valde lyckonummer: " + userLuckyNum + "... Nu kör vi!!!");
                }
                else
                {
                    Console.WriteLine("Felaktigt värde! Välj ett tal mellan 1-6...");
                    continue;         //för att stoppa programmet från att fortsätta med ett felaktigt tal  börjar om på while
                }


                while (true)
                {
                    Console.WriteLine("Ange din insats... Du får ej satsa mer än " + userPix + " Pix.");  // DET GÅR ATT SATSA NEGATIVA TAL!!!!   -1, inte typ -4
                    userBet = int.Parse(Console.ReadLine());

                    if (userBet > userPix)
                    {
                        Console.WriteLine("Satsa en mindre summa!");   //break och continue? man stoppas om man gissar fel EN gång, andra gången går det igenom...
                        continue;     // börjar om på while....
                    }
                    else if (userBet < 50)
                    {
                        Console.WriteLine("Satsa mer, snåljåp!");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Modig satsning! Nu kör vi...");
                        Thread.Sleep(1000); //paus 1 sek, för att öka spänningen...
                        break;
                    }
                }

                for (int i = 0; i < 3; i++) //3 tärningskast... = 3 tärningar som kastas "samtidigt"
                {

                    dice = rnd.Next(1, 7);
                    Console.WriteLine("Tärningen visar: " + dice);

                    if (dice == userLuckyNum)
                    {
                        correctGuesses++;
                    }

                }

                switch (correctGuesses)
                {
                    case 1:
                        Console.WriteLine("Grattis, ett rätt!");
                        userPix = userBet * (correctGuesses + 1) + userPix;
                        Console.WriteLine("Du har nu " + userPix + " Pix!");

                        break;
                    case 2:
                        Console.WriteLine("Grattis, TVÅ rätt!");
                        userPix = userBet * (correctGuesses + 1) + userPix;
                        Console.WriteLine("Du har nu " + userPix + " Pix!");

                        break;

                    case 3:
                        Console.WriteLine("WOHOO, ALLA RÄTT!!!");
                        userPix = userBet * (correctGuesses + 1) + userPix;
                        Console.WriteLine("Du har nu " + userPix + " Pix!");
                        break;

                    default:
                        Console.WriteLine("Sorry, inga rätt...");
                        userPix -= userBet;
                        Console.WriteLine("Du har nu " + userPix + " Pix kvar.");
                        if (userPix < 50)
                        {
                            Console.WriteLine("Du förlorade, spelet är slut.");
                        }
                        break;
                }

                if (userPix > 50)
                {
                    Console.WriteLine("Vågar du fortsätta spelet? Svara 'Ja' eller 'Nej'. På ditt saldo finns: " + userPix + " Pix.");
                    string userAnswer = Console.ReadLine();

                    if (userAnswer == "Ja")
                    {
                        Console.Clear();
                        continue;
                    }
                    else if (userAnswer == "Nej")       //behövs?
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Svara 'Ja' eller 'Nej'");
                        userAnswer = Console.ReadLine();
                    }
                }
            }
        }
    }
}

    // TODO:
    // man kan välja negativa lyckotal
    // man kan välja negativa satsningar, om man väljer en negativ satsning 2 ggr i rad.......
    // spelet fortsätter om man gissar fel 2 ggr i rad..!
    // metoder?
    // roliga färger?
    // rensa using system-listan...?

