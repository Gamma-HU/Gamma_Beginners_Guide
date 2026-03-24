using UnityEngine;
using UnityEngine.SceneManagement;

namespace GuideSample
{
    public class ButtonManager : MonoBehaviour
    {
        public void OnPressed()
        {
            SceneManager.LoadScene("GuideSample");
        }
    }
}