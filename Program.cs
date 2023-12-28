Console.WriteLine("Numerology App in RaspBerry !!!");
Console.WriteLine("Type your Name: ");
string userInput = Console.ReadLine();
int numerologyValue = CalculateNumerologyValue(userInput);
Console.WriteLine("Your magic numbers for your name '{0}' is: {1}", userInput, numerologyValue);
      
 static int CalculateNumerologyValue(string input)
 {
     int value = 0;
     input = input.ToLower();
     foreach (char character in input)
     {
         if (char.IsLetter(character))
         {
             int charValue = character - 'a' + 1;
             value += charValue;
         }
     }
     while (value > 9)
     {
         int sum = 0;
         foreach (char digit in value.ToString())
         {
             sum += int.Parse(digit.ToString());
         }
         value = sum;
     }
     return value;
 }