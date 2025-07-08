using System;
using System.Text;

public static class PalindromeChecker
{
    public static bool IsPalindrome(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return true;

        int left = 0;
        int right = input.Length - 1;

        while (left < right)
        {
            while (left < right && !char.IsLetterOrDigit(input[left])) left++;
            while (left < right && !char.IsLetterOrDigit(input[right])) right--;

            if (char.ToLower(input[left]) != char.ToLower(input[right]))
                return false;

            left++;
            right--;
        }

        return true;
    }
}
