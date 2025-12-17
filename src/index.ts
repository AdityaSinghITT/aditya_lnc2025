import readline from "readline";
import { getAdjacentCountryNames } from "./countryService";

const consoleReader = readline.createInterface({
  input: process.stdin,
  output: process.stdout,
});

consoleReader.question("Enter Country Code (Eg: IN / US): ", (input) => {
  const countryCode = input.trim().toUpperCase();

  if (!isValidCountryCode(countryCode)) {
    console.log("Invalid country code. Please enter 2 letters.");
    consoleReader.close();
    return;
  }
  
  const adjacentCountries = getAdjacentCountryNames(countryCode);

  if(!adjacentCountries){
    console.log("Country not found");
  }
  else if(adjacentCountries.borders.length === 0){
    console.log("This country has no adjacent countries.");
  }
  else{
    console.log("Adjacent countries of :", adjacentCountries.name);
    adjacentCountries.borders.forEach((country: string) => {
        console.log("-", country);
    })
  }

  consoleReader.close();
});

function isValidCountryCode(code: string): boolean {
  return code.length === 2;
}