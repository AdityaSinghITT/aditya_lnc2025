def calculateArmstrongSum(inputNumber):
    armstrongSum = 0
    digitCount = 0

    temporaryNumber = inputNumber
    while temporaryNumber > 0:
        digitCount = digitCount + 1
        temporaryNumber = temporaryNumber // 10

    temporaryNumber = inputNumber
    for i in range(1, temporaryNumber + 1):
        lastDigit = temporaryNumber % 10
        armstrongSum = armstrongSum + (lastDigit ** digitCount)
        temporaryNumber //= 10
    return armstrongSum

inputNumber = int(input("\nPlease Enter the Number to Check for Armstrong: "))

if (inputNumber == calculateArmstrongSum(inputNumber)):
    print("\n %d is Armstrong Number.\n" % inputNumber)
else:
    print("\n %d is Not a Armstrong Number.\n" % inputNumber)