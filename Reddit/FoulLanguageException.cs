/*
 * Name: Brett Carney ZID: z1860518
 * Partner: Adedayo Uwensuyi ZID: z1703101
 */

using System;

namespace Reddit
{
    /// <summary>
    ///     Represents an exception that's thrown
    ///     when foul language is detected.
    /// </summary>
    [Serializable]
    public class FoulLanguageException : Exception
    {
        private readonly string _input;

        public FoulLanguageException()
        {
            _input = "";
        }

        public FoulLanguageException(string input)
        {
            this._input = input;
        }

        public override string ToString()
        {
            return $"Your input \"{_input}\" contains foul language!";
        }
    }
}