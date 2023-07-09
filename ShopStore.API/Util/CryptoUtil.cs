using System;
using System.Security.Cryptography;

namespace ShopStore.API.Util;

public class CryptoUtil
{
    public static string HashString(string text)
    {
        if (String.IsNullOrEmpty(text))
        {
            return String.Empty;
        }

        // Uses SHA256 to create the hash
        var sha = SHA256.Create();

        // Convert the string to a byte array first, to be processed
        byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(text);
        byte[] hashBytes = sha.ComputeHash(textBytes);

        // Convert back to a string, removing the '-' that BitConverter adds
        string hash = BitConverter
            .ToString(hashBytes)
            .Replace("-", String.Empty);

        return hash;

    }
}

