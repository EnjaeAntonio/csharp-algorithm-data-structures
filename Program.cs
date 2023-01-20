﻿/********* Question1: **********/
using System.Text;


Dictionary<int, int> coinDenominations = new Dictionary<int, int> {
        {1, 20},
        {2, 10},
        {5, 15},
        {10, 5},
        {20, 2}
};

// Item prices

Dictionary<string, double> itemInv = new Dictionary<string, double> {
    {"CHIPS", 3 },
    {"CHOCOLATE", 2 },
    {"WATER", 1 }
};


// Ask user for money and initialize user's change
Console.WriteLine("PLEASE ENTER FUNDS (Min: $1 - Max: 205): ");
double userMoney = double.Parse(Console.ReadLine());
while(userMoney < 1)
{
    Console.WriteLine("!! MIN-MAX = $1 & $205 : PLEASE ENTER A NEW AMOUNT !!");

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
        // Displaying the list 
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
        foreach(KeyValuePair<int, int> item in coinDenominations)
        {
            if(userChange / item.Key > item.Value)
            {
                Console.WriteLine("Sorry we dont have enough change to give back");
                break;
            }
        }
        // Ending the output and also displaying how much change the user is getting back as minimal as possible
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
            // Declaring a coin counter
                int coinCount = 0;
                while (coin.Value > 0 && userChange >= coin.Key)
                {
                // Making sure the user gets the smalest amount of money back
                    userChange -= coin.Key;
                    coinCount++;
                    coinDenominations[coin.Key] = coinDenominations[coin.Key] - coinCount;
                }
                if(coinCount > 0)
                {
                // Adding to userChangeCoin
                    userChangeCoins.Add(coin.Key, coinCount);
                }
            }
        Console.WriteLine();
        Console.WriteLine("Vending...");
        foreach(KeyValuePair<int, int> coin in userChangeCoins)
        {
            Console.WriteLine($"WITHDRAWING {coin.Value} ${coin.Key} bill(s)");
        }
        break;
    }
    else if (!itemInv.ContainsKey(userItem))
    {
        // Validiation for error input
        Console.WriteLine("Item is invalid please try again");
        Console.WriteLine("Enter which item you would like or type 'CANCEL' to cancel your purchase!");
        userItem = Console.ReadLine().ToUpper();
    }
    else if (userMoney < itemInv[userItem])
    {
        // Validation if funds are insufficient
        Console.WriteLine("!! INSUFFICIENT FUNDS !! PLEASE TYPE 'LIST' TO CHECK WHAT YOU CAN AFFORD");
        Console.WriteLine();
        continue;
    }
    
    else
    {
        // Feedback for when an item is purchased
        Console.WriteLine();
        Console.WriteLine($"Now vending * {userItem} *");
        userChange = userMoney - itemInv[userItem];
        userMoney = userChange;
        Console.WriteLine($"Your remaining change is now * ${userChange} *");
        Console.WriteLine();
    }
}


/******* Question 2: ********/
Console.WriteLine();
string compressed = "RTFFFFYYUPPPEEEUU";
StringBuilder result = new StringBuilder();
int count = 1;
char currentChar = compressed[0];
Console.WriteLine($"Current String: {compressed  }");
for(int i = 0; i < compressed.Length; i++)
{
    if (compressed[i] == currentChar) { 
        // Keeping track of how many times the same character appears
        count++; 
    } else
    {
        if(count > 2)
        {
            // Appending the current character and also the x amount of times they appeared
            result.Append(currentChar);
            result.Append(count);
        } else
        {
            result.Append(currentChar);
        }
    currentChar = compressed[i];
    count = 1;
    }
}
if (count >= 2)
{
    result.Append(currentChar);
    result.Append(count);
}
else
{
    result.Append(currentChar);
}                               

Console.WriteLine($"Compressed string: {result.ToString()}");

StringBuilder decompressed = new StringBuilder();
currentChar = result[0];
int counter = 0;

for(int i = 0; i < result.Length; i++)
{
    if (char.IsLetter(result[i]))
    {
        currentChar = result[i];
        decompressed.Append(currentChar);
    } else
    {
        int newCount = Int32.Parse(result[i].ToString());
        for(int j = 0; j < counter - 1; j++)
        {
            decompressed.Append(currentChar);
        }
    }
}

Console.WriteLine($"Decompressed string: {decompressed.ToString()}");