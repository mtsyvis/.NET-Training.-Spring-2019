using System.Collections.Generic;

namespace NET1.S._2019.Tsyvis._07.Transform
{
    /// <summary>
    /// Defines an interface for creating dictionaries.
    /// </summary>
    public interface IDictionariesCreator
    {
        /// <summary>
        /// Gets the words.
        /// </summary>
        /// <returns>dictionary with words</returns>
        Dictionary<char, string> GetWords();

        /// <summary>
        /// Gets the special doubles.
        /// </summary>
        /// <returns>dictionary with special doubles</returns>
        Dictionary<double, string> GetSpecialDoubles();
    }
}
