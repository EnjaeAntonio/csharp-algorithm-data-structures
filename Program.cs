/********* Question1: **********/

//A vending machine has a set of coins to handle purchase operations.

//When a customer buys a product from the machine and pays, the machine will return the remaining money from the coins in its internal storage.

//Suppose our machine has the following coins:

//$1, $2, $5, $10, $20


//The machine tracks the quantity of each coin: for example, the quantity of $5 coins is 15, which means the machine currently has 15 pieces of $5 coins.


//Write a program that represents the purchase operation.

//Initialize a Dictionary to represent the coin denominations, and the quantities remaining of each coin denomination.
//Initialize a second Dictionary that contains the possible items in the Vending Machine and their prices.You may hard -
//code these values for demonstration purposes. For example, your machine may have the values: { { A: 3}, { B: 2}, { C: 1.50} }
//to represent item A with the cost of $3, B with the cost of $2, and so on.
//Your console program should prompt the user first for an amount of money, and then an item name.
//If the item name is not found in the machine, the machine should prompt for a different input, but should store the money that the
//user initially input; it should not ask for a new amount of money.
//If the item costs more than what the user has input for money, it should also prompt the user for a selection that the user can afford.
//If the user selects an item that is valid, and they have entered enough money to buy, the program should output that it has vended the item by name,
//and how many coins it returns for change. It should return the fewest number of coins possible.
//If the machine does not have sufficient change to return to the user, it should not return any coins, and the entire operation should be canceled
//and returned to the beginning.
//If the user ever types "CANCEL", the entire transaction should end.
//Example:

//The user entered $25 and wants to buy a $2 item, so the machine should return the following:

//$20 : 1 piece 

//$2 : 1 piece

//$1 : 1 piece

//If the machine is out of a certain coin, it should not return it.

//The machine always returns the minimum amount of possible coins.
//For example, if the machine must return $7 in change, it should return one $5 coin and one $2 coin. If $5 coins are not available, it would return three $2 coins and one $1 coin. 

// Coin Denominations
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
    {"WATER", 1.50}
};

// Ask user for money
Console.WriteLine("Please enter the amount of money you have:");
double userMoney = double.Parse(Console.ReadLine());

double userChange = 0;
while(userMoney > 0)
{
    // Ask for item name
    Console.WriteLine("Enter which item you would like");
    Console.WriteLine("Type 'List' to view our options or 'Cancel' to cancel your purchase");
    string userItem = Console.ReadLine().ToUpper();

    if (userItem.ToUpper() == "CANCEL")
    {
        Console.WriteLine("SHUTTING DOWN");
        break;
    }
    else if(userItem.ToUpper() == "LIST")
    {
        foreach(KeyValuePair<string, double> item in itemInv)
        {
            Console.WriteLine($"Item: {item.Key} Cost: {item.Value}");
        }
    }
    else if (!itemInv.ContainsKey(userItem))
    {
        Console.WriteLine("Item is invalid please try again");
        Console.WriteLine("Enter which item you would like or type 'CANCEL' to cancel your purchase!");
        userItem = Console.ReadLine().ToUpper();
    }
    else if (userMoney < itemInv[userItem])
    {
        Console.WriteLine("Insufficient funds, please enter a different item!");
        continue;
    }
    else
    {
        Console.WriteLine($"Now vending {userItem}");
        userChange = userMoney - itemInv[userItem];
        userMoney = userChange;
        Console.WriteLine($"Your remaining change is {userChange}");
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