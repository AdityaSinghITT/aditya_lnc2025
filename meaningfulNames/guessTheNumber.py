import random
def guessTheNumber(userGuess):
    if userGuess.isdigit() and 1 <= int(userGuess) <= 100:
        return True
    else:
        return False
def main():
    originalNumber = random.randint(1, 100)
    guessedCorrectly = False
    guessedNumber = input("Guess a number between 1 and 100: ")
    numberOfGuesses = 0
    while not guessedCorrectly : 
        if not guessTheNumber(guessedNumber):
            guessedNumber = input("I won't count this one. Please enter a number between 1 to 100: ")
            continue
        else:
            numberOfGuesses += 1
            guessedNumber = int(guessedNumber)
        if guessedNumber < originalNumber:
            guessedNumber = input("Too low. Guess again: ")
        elif guessedNumber > originalNumber:
            guessedNumber = input("Too high. Guess again: ")
        else:
            print("You guessed it in", numberOfGuesses, "guesses!")
            guessedCorrectly = True

main()