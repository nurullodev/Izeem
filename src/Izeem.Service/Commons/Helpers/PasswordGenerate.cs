using System.Text;

namespace Izeem.Service.Commons.Helpers;

public static class PasswordGenerate
{
    private const string UppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string LowercaseChars = "abcdefghijklmnopqrstuvwxyz";
    private const string DigitChars = "0123456789";

    public static string Password()
    {
        int length = 8;
        bool uppercase = true;
        bool lowercase = true;
        bool digit = true;

        StringBuilder password = new StringBuilder();
        Random random = new Random();

        string allChars = string.Empty;
        if (uppercase) allChars += UppercaseChars;
        if (lowercase) allChars += LowercaseChars;
        if (digit) allChars += DigitChars;

        for (int i = 0; i < length; i++)
        {
            password.Append(allChars[random.Next(allChars.Length)]);
        }

        return password.ToString();
    }
}
