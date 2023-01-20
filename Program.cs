/********* Question1: **********/
using System.Text;

Dictionary<int, int> coinDenominations = new Dictionary<int, int> {
        { 1, 15 },
        { 2, 10 },
        { 5, 5 },
        { 10, 3 },
        { 20, 2 }
};

// Item prices

Dictionary<string, double> itemInv = new Dictionary<string, double> {
    {"CHIPS", 3 },
    {"CHOCOLATE", 2 },
    {"WATER", 1 }
};


// Ask user for money and initialize user's change
Console.WriteLine("PLEASE ENTER FUNDS (Min: $1): ");
double userMoney = double.Parse(Console.ReadLine());
while(userMoney < 1)
{
    Console.WriteLine("!! MINIMUM AMOUNT IS * $1 * PLEASE ENTER A NEW AMOUNT !!");

    userMoney= double.Parse(Console.ReadLine());
}   
double userChange = 0;
while(userMoney > 0)
{

    // Ask for item name
    Console.WriteLine("Enter which item you would like :)");
    Console.WriteLine("Type 'List' to view our options, 'Done' to finish your transaction, or 'Cancel' to cancel your purchase!");
    string userItem = Console.ReadLine().ToUpper();

    if (userItem.ToUpper() == "CANCEL")
    {
        Console.WriteLine("SHUTTING DOWN");
        break;
    }
    else if(userItem.ToUpper() == "LIST")
    {
        Console.WriteLine();
        Console.WriteLine("Available Options: ");
        Console.WriteLine();
        foreach(KeyValuePair<string, double> item in itemInv)
        {
            Console.WriteLine($"* {item.Key}: ${item.Value} *");
            Console.WriteLine();

        }
    }
    else if (userItem.ToUpper() == "DONE")
    {
        userChange = userMoney;
        Dictionary<int, int> userChangeCoins = new Dictionary<int, int>();
        List<KeyValuePair<int, int>> coinList = coinDenominations.ToList();
        for(int i = 0; i < coinList.Count; i++)
        {
            for (int j = i + 1; j < coinList.Count; j++)
            {
                if (coinList[i].Key < coinList[j].Key)
                {
                    KeyValuePair<int, int> temp = coinList[i];
                    coinList[i] = coinList[j];
                    coinList[j] = temp;
                }
            }
        }
        foreach (KeyValuePair<int, int> coin in coinList)
            {
                int coinCount = 0;
                while (coin.Value > 0 && userChange >= coin.Key)
                {
                    userChange -= coin.Key;
                    coinCount++;
                    coinDenominations[coin.Key] = coinDenominations[coin.Key] - coinCount;
                }
                if(coinCount > 0)
                {
                    userChangeCoins.Add(coin.Key, coinCount);
                }
            }
        foreach(KeyValuePair<int, int> coin in userChangeCoins)
        {
            Console.WriteLine("Vending...");
            Console.WriteLine($"WITHDRAWING {coin.Value} ${coin.Key} bill(s)");
        }
        break;
    }
    else if (!itemInv.ContainsKey(userItem))
    {
        Console.WriteLine("Item is invalid please try again");
        Console.WriteLine("Enter which item you would like or type 'CANCEL' to cancel your purchase!");
        userItem = Console.ReadLine().ToUpper();
    }
    else if (userMoney < itemInv[userItem])
    {
        Console.WriteLine("!! INSUFFICIENT FUNDS !! PLEASE TYPE 'LIST' TO CHECK WHAT YOU CAN AFFORD");
        Console.WriteLine();
        continue;
    }
    
    else
    {
        Console.WriteLine();
        Console.WriteLine($"Now vending * {userItem} *");
        userChange = userMoney - itemInv[userItem];
        userMoney = userChange;
        Console.WriteLine($"Your remaining change is now * ${userChange} *");
        Console.WriteLine();
    }
}


/******* Question 2: ********/
//We want to create a simple file compression algorithm that works with strings, those strings are uppercase letters only.

//To compress a string, the program will count the consecutive similar letters and replace them with a number.

//Example:

//String = “RTFFFFYYUPPPEEEUU”

//Result = “RTF4YYUP3E3UU”

//So basically the program will replace a letter if it appeared more than 2 times continuously, the replacement is done by keeping one copy of this letter then writing down the number this letter appeared consecutively.

//Write a function to compress a string and return the result

//Write a function to decompress a string and return the original one.

StringBuilder result = new StringBuilder();
int count = 0;