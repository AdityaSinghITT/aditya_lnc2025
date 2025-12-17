import filesystem from "fs";
import path from "path";

type CountryData = {
  name: string;
  borders: string[];
};

type CountryMap = {
  [countryCode: string]: CountryData;
};

const countryBordersFilePath = path.join(__dirname, "../data/countryBorders.json");

function getCountryData(): CountryMap {
  const countryBordersFileContent = filesystem.readFileSync(countryBordersFilePath, "utf-8");
  return JSON.parse(countryBordersFileContent);
}

export function getAdjacentCountryNames(countryCode: string): CountryData | null{
  const countries = getCountryData();
  const country = countries[countryCode];

  if (!country) {
    return null;
  }

  return country;
}
