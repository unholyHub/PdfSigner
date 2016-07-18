using System;

namespace PdfSigner.Classes
{
    public class Person
    {
        private static Person instance;

        /// <summary>
        /// The sync root to ensure that only one instance is running.
        /// </summary>
        private static readonly object SyncRoot = new object();

        /// <summary>
        /// Gets instance of the <see cref="Person"/> class.
        /// </summary>
        public static Person Instance
        {
            get
            {
                lock (SyncRoot)
                {
                    return instance ?? (instance = new Person());
                }
            }
        }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public string Country { get; set; }

        public string DocumentNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public void GetNames()
        {
            FullName = ReplaceWrongSymbolsInName(this.FullName, true);

            if ((FullName != string.Empty) ||
                (FirstName == string.Empty) ||
                (MiddleName == string.Empty) ||
                (LastName == string.Empty))
            {
                FirstName = string.Empty;
                MiddleName = string.Empty;
                LastName = FullName;

                int tFound = LastName.IndexOf(" ");
                if (tFound != -1)
                {
                    FirstName = CStringFunctions.SubstrString(LastName, tFound, LastName.Length - tFound);
                    FirstName = CStringFunctions.TrimString(FirstName, " ");
                    LastName = CStringFunctions.SubstrString(LastName, 0, tFound);
                    LastName = CStringFunctions.TrimString(LastName, " ");
                    tFound = FirstName.IndexOf(" ");
                    if (tFound != -1)
                    {
                        MiddleName = CStringFunctions.SubstrString(FirstName, tFound, FirstName.Length - tFound);
                        MiddleName = CStringFunctions.TrimString(MiddleName, " ");
                        FirstName = CStringFunctions.SubstrString(FirstName, 0, tFound);
                        FirstName = CStringFunctions.TrimString(FirstName, " ");
                    }
                }

                if ((FirstName.Equals(string.Empty)) && (MiddleName.Equals(string.Empty)))
                {
                    if ((tFound = LastName.IndexOf(" ")) != -1)
                    {
                        FirstName = CStringFunctions.SubstrString(LastName, tFound, LastName.Length - tFound);
                        FirstName = CStringFunctions.TrimString(FirstName, " ");
                        LastName = CStringFunctions.SubstrString(LastName, 0, tFound);
                        LastName = CStringFunctions.TrimString(LastName, " ");
                        string tStr = FirstName;
                        FirstName = LastName;
                        LastName = tStr;
                    }
                }
            }
        }

        public string ReplaceWrongSymbolsInName(string name, bool isFullName = false)
        {
            name = name.Replace("0", "O");
            name = name.Replace("*", "<");
            name = name.Replace("_", "<");
            name = name.Replace("^", "<");
            name = name.Replace("<", " ");

            if (isFullName)
            {
                return name;
            }

            name = name.Replace(" ", "");

            return name;
        }
    }

    public class CStringFunctions
    {
        /// <summary>
        /// Retrieves a substring from this instance. The substring starts at a specified character position and has a specified length.
        /// </summary>
        /// <param name="inputString">
        /// The source string.
        /// </param>
        /// <param name="startIndex">
        /// The source start index.
        /// </param>
        /// <param name="length">
        /// The source length.
        /// </param>
        /// <returns>
        /// A <see cref="string"/> equivalent to the substring of length that begins at startIndex in this instance, or <see cref="string.Empty"/> if startIndex is equal to the length of this instance and length is zero.
        /// </returns>
        public static string SubstrString(string inputString, int startIndex, int length)
        {
            string substring = string.Empty;

            try
            {
                substring = inputString.Substring(startIndex, length);
            }
            catch
            {
            }

            return substring;
        }

        /// <summary>
        /// Removes all leading and trailing occurrences of a set of characters specified in an array from the current String object.
        /// </summary>
        /// <param name="removeString">
        /// The string to be remove.
        /// </param>
        /// <param name="trimWith">
        /// String of Unicode characters to remove.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string TrimString(string removeString, string trimWith = " ")
        {
            if (removeString == null)
            {
                return String.Empty;
            }

            return removeString.Trim(trimWith.ToCharArray());
        }
    }
}
