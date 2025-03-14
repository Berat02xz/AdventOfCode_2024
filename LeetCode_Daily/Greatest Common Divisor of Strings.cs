public class Solution {
    public string GcdOfStrings(string str1, string str2) {
        if (IsItEqual(str1, str2)) {
            int amount = (int)BigInteger.GreatestCommonDivisor(str1.Length, str2.Length);
            return OutputString(str1, amount);
        } else {
            return "";
        }
    }

    private bool IsItEqual(string str1, string str2) {
        return (str1 + str2 == str2 + str1);
    }

    private string OutputString(string str1, int amount) {
        return str1.Substring(0, amount);
    }
}
