import random
def diceRoll(numberOfSides):
 
    diceValue = random.randint(1, numberOfSides)
 
    return diceValue
def main():
 
    diceFaces = 6
 
    isDiceRolling = True
 
    while isDiceRolling:
 
        userInput = input("Ready to roll? Enter Q to Quit: ")
 
        if userInput.lower() != "q":
 
            diceResult = diceRoll(diceFaces)
 
            print("You have rolled a", diceResult)
 
        else:
 
            isDiceRolling = False