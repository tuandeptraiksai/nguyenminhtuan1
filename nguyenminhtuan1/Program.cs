
using System;

class Program
{
    static void Main()
    {
        Random rand = new Random();
        int targetNumber = rand.Next(100, 1000); // Phát sinh số ngẫu nhiên từ 100 đến 999

        Console.WriteLine("Chao mung ban đen voi tro choi đoan so!");
        Console.WriteLine("May tinh đa phat sinh mot so ngau nhien co 3 chu so tu 100 đen 999.");
        Console.WriteLine("Ban co toi đa 7 lan đoan đe tim ra so nay.");

        int attempts = 0;
        const int maxAttempts = 7;
        bool isGuessed = false;

        while (attempts < maxAttempts && !isGuessed)
        {
            Console.Write($"Lan đoan thu {attempts + 1}: ");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int guessedNumber) || guessedNumber < 100 || guessedNumber > 999)
            {
                Console.WriteLine("So đoan phai nam trong khoang tu 100 đen 999. Vui long thu lai.");
                continue;
            }

            string feedback = GetFeedback(guessedNumber, targetNumber);

            if (feedback == "+++")
            {
                isGuessed = true;
                Console.WriteLine($"Chuc mung ban! Ban đa đoan đung so {targetNumber} sau {attempts + 1} lan đoan!");
            }
            else
            {
                Console.WriteLine($"Phan hoi: {feedback}");
            }

            attempts++;
        }

        if (!isGuessed)
        {
            Console.WriteLine($"Rat tiec, ban đa het luot đoan. So đung la: {targetNumber}");
        }
    }

    static string GetFeedback(int guessedNumber, int targetNumber)
    {
        string feedback = "";
        string guessedStr = guessedNumber.ToString();
        string targetStr = targetNumber.ToString();

        for (int i = 0; i < 3; ++i)
        {
            if (guessedStr[i] == targetStr[i])
            {
                feedback += '+';
            }
            else if (targetStr.Contains(guessedStr[i]))
            {
                feedback += '?';
            }
            else
            {
                feedback += ' ';
            }
        }

        return feedback;
    }
}
