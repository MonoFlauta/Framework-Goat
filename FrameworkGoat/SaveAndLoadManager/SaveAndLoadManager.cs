using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FrameworkGoat
{
    public static class SaveAndLoadManager
    {
        /// <summary>
        /// Serializes and saves a file in the persistent data path /GoatSave.g
        /// </summary>
        /// <param name="saveFile">The class to save</param>
        public static void Save(object saveFile)
        {
            var bf = new BinaryFormatter();
            var fs = File.Create(Application.persistentDataPath + "/GoatSave.g");
            bf.Serialize(fs, saveFile);
            fs.Close();
        }

        /// <summary>
        /// Serializes and saves a file in the persistent data path with the given file name
        /// </summary>
        /// <param name="saveFile">The class to save</param>
        /// <param name="fileName">Name of the file including it's extension</param>
        public static void Save(object saveFile, string fileName)
        {
            var bf = new BinaryFormatter();
            var fs = File.Create(Application.persistentDataPath + "/"+ fileName);
            bf.Serialize(fs, saveFile);
            fs.Close();
        }

        /// <summary>
        /// Serializes and saves a file in the given path with the given file name
        /// </summary>
        /// <param name="saveFile">The class to save</param>
        /// <param name="path">Path were it should be saved</param>
        /// <param name="fileName">Name of the file</param>
        public static void Save(object saveFile, string path, string fileName)
        {
            var bf = new BinaryFormatter();
            var fs = File.Create(path + fileName);
            bf.Serialize(fs, saveFile);
            fs.Close();
        }

        /// <summary>
        /// Loads, deserializes and returns the result. The file should be in the persistent data path /GoatSave.g
        /// </summary>
        /// <typeparam name="T">Type of the saved data</typeparam>
        /// <returns>The saved data</returns>
        public static T Load<T>()
        {
            var bf = new BinaryFormatter();
            var fs = File.Open(Application.persistentDataPath + "/GoatSave.g", FileMode.Open);
            T result = (T)bf.Deserialize(fs);
            fs.Close();
            return result;
        }

        /// <summary>
        /// Loads a file from the persistent data path with the given file name, deserializes and returns the result.
        /// </summary>
        /// <typeparam name="T">Type of the saved data</typeparam>
        /// <param name="fileName">File name</param>
        /// <returns>The saved data</returns>
        public static T Load<T>(string fileName)
        {
            var bf = new BinaryFormatter();
            var fs = File.Open(Application.persistentDataPath + "/"+ fileName, FileMode.Open);
            T result = (T)bf.Deserialize(fs);
            fs.Close();
            return result;
        }

        /// <summary>
        /// Loads a file from the given path with the given file name, deserializes and returns the result.
        /// </summary>
        /// <typeparam name="T">Type of the saved data</typeparam>
        /// <param name="path">File path</param>
        /// <param name="fileName">File name</param>
        /// <returns>The saved data</returns>
        public static T Load<T>(string path, string fileName)
        {
            var bf = new BinaryFormatter();
            var fs = File.Open(path + fileName, FileMode.Open);
            T result = (T)bf.Deserialize(fs);
            fs.Close();
            return result;
        }

        /// <summary>
        /// Checks if there is a file in the persistent data path /GoatSave.g
        /// </summary>
        /// <returns>If there is a file</returns>
        public static bool HasASave() => 
            File.Exists(Application.persistentDataPath + "/GoatSave.g");

        /// <summary>
        /// Checks if there is a file at the persistent data path with the given file name
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <returns>If there is a file</returns>
        public static bool HasASave(string fileName) =>
            File.Exists(Application.persistentDataPath + "/" + fileName);

        /// <summary>
        /// Checks if there is a file at the given path with the given file name
        /// </summary>
        /// <param name="path">File path</param>
        /// <param name="fileName">File name</param>
        /// <returns>If there is a file</returns>
        public static bool HasASave(string path, string fileName) =>
            File.Exists(path + fileName);
    }
}