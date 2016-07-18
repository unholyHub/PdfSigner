using PdfSigner.Classes;

namespace PdfSigner
{
    using System;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Class for data operations.
    /// </summary>
    public static class DataFunctions
    {
        /// <summary>
        /// Gets the loaded string from file.
        /// </summary>
        public static string LoadedString { get; private set; }

        /// <summary>
        /// Saves a string to a specific file.
        /// </summary>
        /// <param name="path">The complete file path to be read.</param>
        /// <param name="textData">The string data that will be save to the file.</param>
        /// <param name="append">
        ///     Determines whether data is to be appended to the file. If the file exists and
        ///     append is false, the file is overwritten. If the file exists and append is true,
        ///     the data is appended to the file. Otherwise, a new file is created.
        /// </param>
        public static void SaveTextDataToFile(string path, string textData, bool append)
        {
            string pathWithEnvironmentVariables = Environment.ExpandEnvironmentVariables(path);

            try
            {
                using (StreamWriter sr = new StreamWriter(pathWithEnvironmentVariables, append, Encoding.Unicode))
                {
                    sr.Write(textData);
                }
            }
            catch (UnauthorizedAccessException unauthorizedAccessException)
            {
            }
            catch (IOException ioException)
            {
            }
        }

        /// <summary>
        /// Reads the string content from a specific file.
        /// </summary>
        /// <param name="path">The complete file path to be read.</param>
        /// <returns>Returns one for success and zero for <see cref="IOException"/>.</returns>
        public static int LoadStringFromFile(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    LoadedString = sr.ReadToEnd();
                    return 1;
                }
            }
            catch (IOException ioException)
            {
                return 0;
            }
        }

        /// <summary>
        /// Writes the <see cref="Collection{T}"/> to a specific file.
        /// </summary>
        /// <param name="filePath">The complete file path to write to.</param>
        /// <param name="collection">The collection that will be added to file.</param>
        public static void WriteCollectionToFile(string filePath, Collection<string> collection)
        {
            using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                if (collection == null)
                {
                    return;
                }

                foreach (string s in collection)
                {
                    writer.WriteLine(s);
                }
            }
        }

        /// <summary>
        /// Reads a text lines from a file and stores them in a <see cref="Collection{T}"/>.
        /// </summary>
        /// <param name="filePath">The complete file path to write to.</param>
        /// <returns>Returns the read <see cref="Collection{T}"/>.</returns>
        public static Collection<string> ReadTextFromFile(string filePath)
        {
            Collection<string> collection = new Collection<string>();

            if (!File.Exists(filePath))
            {
                return collection;
            }

            using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrEmpty(line))
                    {
                        continue;
                    }

                    collection.Add(line);
                }
            }

            return collection;
        }

        /// <summary>
        /// Adds a <see cref="Collection{T}"/> to a specific file.
        /// </summary>
        /// <param name="filePath">The complete file path to write to.</param>
        /// <param name="collection">The collection that will be added to file.</param>
        public static void AddCollectionToFile(string filePath, Collection<string> collection)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true, Encoding.UTF8))
            {
                if (collection == null)
                {
                    return;
                }

                foreach (string s in collection)
                {
                    writer.WriteLine(s);
                }
            }
        }

        public static string TransformPersonData()
        {
            string output;
            string format = Settings.Instance.PdfFileNameFormat;

            output = format.Replace("<NAME1>", Person.Instance.FirstName);
            output = output.Replace("<NAME2>", Person.Instance.MiddleName);
            output = output.Replace("<NAME3>", Person.Instance.LastName);
            output = output.Replace("<NAT>", Person.Instance.Country);
            output = output.Replace("<NDOC>", Person.Instance.DocumentNumber);

            return output;
        }
    }
}