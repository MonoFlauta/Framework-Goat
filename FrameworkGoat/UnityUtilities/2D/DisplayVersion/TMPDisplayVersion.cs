using TMPro;
using UnityEngine;

namespace Framework_Goat.FrameworkGoat.UnityUtilities._2D.DisplayVersion
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TMPDisplayVersion : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<TextMeshProUGUI>().text = Application.version;
        }
    }
}
