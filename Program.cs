

namespace HomeWork5_6;

class Program
{
    static void Main()
    {
        var anketa = GetUserData();
        PrintDataInConsole(anketa);
        
    }

    static void PrintDataInConsole((string, string, int, string[], string[]) anketa)
    {
        Console.WriteLine("Your name is: {0}", anketa.Item1);
        Console.WriteLine("Your surname is: {0}", anketa.Item2);
        Console.WriteLine("Your age is: {0}", anketa.Item3);
        Console.WriteLine("You have {0} pets", anketa.Item4.Length);
        foreach (var item in anketa.Item4) {
            Console.WriteLine(" Your pet name is {0}", item);    
        }
        Console.WriteLine("You have {0} favorite colors", anketa.Item5.Length);
        foreach (var item in anketa.Item5)
        {
            Console.WriteLine(" Your favorite color is {0}", item);
        }
    }

    static (string, string, int, string[], string[]) GetUserData()
    {
        Console.WriteLine("Enter your name:");
        string Name = Console.ReadLine();

        Console.WriteLine("Enter your surname:");
        string Surname = Console.ReadLine();

        Console.WriteLine("Enter your age:");
        int Age = GetIntValueFromConsole(Console.ReadLine());

        Console.WriteLine("Do you have pets? 'yes' - you have pets, anything else - you have not");
        string HavePet = Console.ReadLine();
        int PetsQty = GetPetsQty(HavePet);
        string[] PetsNames = GetArrOfStrings(PetsQty, "your pet name");

        Console.WriteLine("How many favorite colors you have?:");
        int QtyFavColors = GetIntValueFromConsole(Console.ReadLine());
        string[] FavColors = GetArrOfStrings(QtyFavColors, "your favorite color");

        return (Name, Surname, Age, PetsNames, FavColors);
    }

    private static int GetIntValueFromConsole(string str, bool result = false)
    {
        int number;
        result = int.TryParse(str, out number);
        if (!result || number <= 0)
        {
            Console.WriteLine("Enter number greater than 0 please, or i will ask this until the time ends :(");
            str = Console.ReadLine();
            number = GetIntValueFromConsole(str, result);
        }
        return number;
    }

    private static string[] GetArrOfStrings(int Qty, string CallVariant)
    {
        string[] result = new string[Qty];
        for (int i = 0; i < Qty; i++)
        {
            Console.WriteLine("Enter {0}:", CallVariant);
            string smth = Console.ReadLine();
            result[i] = smth;
        }

        return result;
    }

    private static int GetPetsQty(string HavePet)
    {
        int PetsQty;
        if (HavePet == "yes")
        {
            Console.WriteLine("How many pets you have?");
            PetsQty = GetIntValueFromConsole(Console.ReadLine());
        }
        else
        {
            Console.WriteLine("Ok. You have no pets.");
            PetsQty = 0;
        }

        return PetsQty;
    }

}


