using System;
using System.Numerics;
class SubarrayMeanCalculator {
    static void Main(string[] args) {
        var (numberOfElements, numberOfQueries) = ReadArrayAndQueryCount();
        var arrayElements = ReadArrayElements();
        var prefixSumArray = BuildPrefixSumArray(arrayElements, numberOfElements);
        
        ProcessQueries(numberOfQueries, prefixSumArray);
    }

    static (int numberOfElements, int numberOfQueries) ReadArrayAndQueryCount()
    {
        var input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        return (input[0], input[1]);
    }

    static long[] ReadArrayElements()
    {
        return Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
    }

    static long[] BuildPrefixSumArray(long[] arrayElements, int numberOfElements)
    {
        long[] prefixSumArray = new long[numberOfElements + 1];
        prefixSumArray[0] = 0;
        
        for (int index = 1; index <= numberOfElements; index++)
        {
            prefixSumArray[index] = prefixSumArray[index - 1] + arrayElements[index - 1];
        }
        
        return prefixSumArray;
    }

    static void ProcessQueries(int numberOfQueries, long[] prefixSumArray)
    {
        for (int queryIndex = 0; queryIndex < numberOfQueries; queryIndex++)
        {
            var (leftIndex, rightIndex) = ReadQueryRange();
            long floorMean = CalculateFloorMean(prefixSumArray, leftIndex, rightIndex);
            Console.WriteLine(floorMean);
        }
    }

    static (int leftIndex, int rightIndex) ReadQueryRange()
    {
        var rangeInput = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        return (rangeInput[0], rangeInput[1]);
    }

    static long CalculateFloorMean(long[] prefixSumArray, int leftIndex, int rightIndex)
    {
        long rangeSum = prefixSumArray[rightIndex] - prefixSumArray[leftIndex - 1];
        int rangeLength = rightIndex - leftIndex + 1;
        long floorMean = rangeSum / rangeLength;
        
        return floorMean;
    }
}