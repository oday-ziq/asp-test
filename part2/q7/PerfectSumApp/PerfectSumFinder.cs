using System;
using System.Collections.Generic;
using System.Linq;

public static class PerfectSumFinder
{
    public static List<List<int>> FindPerfectSums(int[] nums, int target)
    {
        int n = nums.Length;
        int mid = n / 2;

        var left = nums[..mid];
        var right = nums[mid..];

        var leftSubsets = GetSubsets(left);
        var rightSubsets = GetSubsets(right);

        // Map from subset sum to list of subsets
        var rightDict = new Dictionary<int, List<List<int>>>();

        foreach (var subset in rightSubsets)
        {
            int sum = subset.Sum();
            if (sum > target) continue;

            if (!rightDict.ContainsKey(sum))
                rightDict[sum] = new List<List<int>>();

            rightDict[sum].Add(subset);
        }

        var result = new List<List<int>>();

        foreach (var l in leftSubsets)
        {
            int sumL = l.Sum();
            if (sumL > target) continue;

            int needed = target - sumL;

            if (rightDict.TryGetValue(needed, out var matches))
            {
                foreach (var r in matches)
                {
                    var combined = new List<int>(l);
                    combined.AddRange(r);
                    result.Add(combined);
                }
            }
        }

        return result;
    }

    private static List<List<int>> GetSubsets(int[] nums)
    {
        var subsets = new List<List<int>>();
        int n = nums.Length;
        int total = 1 << n;

        for (int mask = 0; mask < total; mask++)
        {
            var subset = new List<int>();
            for (int i = 0; i < n; i++)
            {
                if ((mask & (1 << i)) != 0)
                    subset.Add(nums[i]);
            }
            subsets.Add(subset);
        }

        return subsets;
    }
}
