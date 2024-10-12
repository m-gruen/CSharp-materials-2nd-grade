using System.Runtime.CompilerServices;
using WordGuesser;

Console.WriteLine("Welcome to Word Guesser!");

// TODO: Ask the user if she wants to play a normal, easy, or hard game.
// If the user enters an invalid input, ask again until she enters a valid input.

var isValid = false;
var gameType = "";
do
{
    System.Console.WriteLine("What do you want to play? [N]ormal, [E]asy, [H]ard");
    gameType = Console.ReadLine()!.ToUpper();
    isValid = gameType is "N" or "E" or "H";
    if (!isValid) { Console.WriteLine("Invalid input. Please enter N, E, or H."); }
}
while (!isValid);

// TODO: Create the proper instance of WordGuess or its derived class based on the user's input.
WordGuess game = gameType switch
{
    "N" => new WordGuess(),
    "E" => new EasyWordGuess(),
    "H" => new HardWordGuess(),
    _ => throw new InvalidOperationException()
};

// TODO: Game loop
// 1. Clear the screen
// 2. Show the current guess and the current number of wrong guesses
// 3. Ask the user to press a letter (use Console.ReadKey().KeyChar)
// 4. If the user's guess is wrong, increment the number of wrong guesses
// 5. Repeat until the word is completed

int wrongGuesses = 0;
while (!game.Completed)
{
    Console.Clear();
    Console.WriteLine($"Current guess: {game.CurrentGuess}");
    Console.WriteLine($"Wrong guesses: {wrongGuesses}");

    Console.WriteLine("Enter a letter:");
    var letter = Console.ReadKey().KeyChar;
    if (!game.Guess(letter)) { wrongGuesses++; }
}

// TODO: Show the final result:
// 1. Clear the screen
// 2. Show a message with the guessed word and the number of wrong guesses 

Console.Clear();
System.Console.WriteLine($"The word was: {game.GetWordToGuess()}");
System.Console.WriteLine($"You made {wrongGuesses} wrong guesses.");
