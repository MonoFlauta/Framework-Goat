using UnityEngine;
using UnityEditor;
using System.IO;

namespace FrameworkGoat.ScriptableObjects
{
    public class ScriptableObjectsCreator
    {
        /// <summary>
        /// Creates an scriptable object with a given type
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        public static void CreateAsset<T>() where T : ScriptableObject
        {
            T asset = ScriptableObject.CreateInstance<T>();
            CreateAndFocusAsset(asset, GetValidPath(AssetDatabase.GetAssetPath(Selection.activeObject), typeof(T)));
        }

        /// <summary>
        /// Creates an scriptable object with a given type and path
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="path">Path</param>
        public static void CreateAsset<T>(string path) where T : ScriptableObject
        {
            T asset = ScriptableObject.CreateInstance<T>();
            CreateAndFocusAsset(asset, GetValidPath(path, typeof(T)));
        }

        /// <summary>
        /// Modifies the path, if is not valid, for a valid one
        /// </summary>
        /// <param name="path">Path</param>
        /// <param name="type">Type</param>
        /// <returns>Valid path</returns>
        private static string GetValidPath(string path, System.Type type)
        {
            if (path == "") path = "Assets";
            else if (Path.GetExtension(path) != "")
                path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
            return AssetDatabase.GenerateUniqueAssetPath(path + "/" + type.ToString() + ".asset");
        }

        /// <summary>
        /// Creates the asset and places the focus on it
        /// </summary>
        /// <param name="asset">Asset to create</param>
        /// <param name="path">Path to locate</param>
        private static void CreateAndFocusAsset(ScriptableObject asset, string path)
        {
            AssetDatabase.CreateAsset(asset, path);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;
        }
    }
}