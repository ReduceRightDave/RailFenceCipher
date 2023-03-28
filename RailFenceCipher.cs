using System;
using System.Linq;

public class RailFenceCipher
{
    private readonly int numberOfrails;

    public RailFenceCipher(int numberOfrails) => this.numberOfrails = numberOfrails;

    public string Encode(string input)
    {
        string[] rails = new string[numberOfrails];
        BounceBetweenRailsIndexIterator railsIndexIterator = new BounceBetweenRailsIndexIterator(numberOfrails);

        foreach (char c in input)
        {
            rails[railsIndexIterator.next] += c;
        }

        return string.Join(string.Empty, rails);
    }

    public string Decode(string input)
    {
        string result = ""; //TODO string builder
        StringWithCharIterator[] encodedRails = generateEncodedRails(input);
        BounceBetweenRailsIndexIterator railsIterator = new BounceBetweenRailsIndexIterator(numberOfrails);

        for (var i = 0; i < input.Length; i++)
        {
            result += encodedRails[railsIterator.next].nextChar;
        }

        return result;
    }

    private StringWithCharIterator[] generateEncodedRails(string encodedInput)
    {
        StringWithCharIterator[] rails = new StringWithCharIterator[numberOfrails];
        int[] charCountForEachRail = calculateCharCountForEachRail(encodedInput.Length);

        for (int i = rails.Length - 1; i >= 0; i--)
        {
            int startIndex = encodedInput.Length - charCountForEachRail[i];
            rails[i] = new StringWithCharIterator(encodedInput[startIndex..]);
            encodedInput = encodedInput.Remove(startIndex);
        }

        return rails;
    }

    private int[] calculateCharCountForEachRail(int encodedStringLength)
    {
        int[] charCountForEachRail = new int[numberOfrails];
        BounceBetweenRailsIndexIterator railsIterator = new BounceBetweenRailsIndexIterator(numberOfrails);

        for (var i = 0; i < encodedStringLength; i++)
        {
            charCountForEachRail[railsIterator.next] += 1;
        }

        return charCountForEachRail;
    }
}
