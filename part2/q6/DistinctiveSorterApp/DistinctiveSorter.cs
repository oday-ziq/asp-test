using System;
using System.Collections.Generic;

public static class DistinctiveSorter
{
    public static List<int> DistinctSort(int[] input)
    {
        if (input == null || input.Length == 0)
            return new List<int>();

        HashSet<int> uniqueSet = new HashSet<int>(input); // Remove duplicates
        List<int> result = new List<int>(uniqueSet);
        result.Sort(); // Sort in ascending order

        return result;
    }
}
