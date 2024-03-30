using UnityEngine;
using UnityEngine.UI;

namespace Framework_Goat.FrameworkGoat.UnityUtilities._2D.DisplayVersion
{
    [RequireComponent(typeof(Text))]
    public class TextDisplayVersion : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<Text>().text = Application.version;
        }
    }
}