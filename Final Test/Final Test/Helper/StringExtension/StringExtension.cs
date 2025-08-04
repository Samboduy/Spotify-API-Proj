using System.Security.Cryptography;

namespace Final_Test.Helper.StringExtension;

public static class StringExtension
{
    public static string RandomString(int length)
    {
        var generator = RandomNumberGenerator.Create();
        var word = new byte[length];
        generator.GetBytes(word);
        return Convert.ToBase64String(word);
    }
}