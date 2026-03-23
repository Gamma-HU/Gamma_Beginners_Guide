using UnityEngine;
using UnityEngine.SceneManagement;

namespace GuideSample
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private PlayerController player;
        void Awake()
        {
            Application.targetFrameRate = 60;
        }

        void Update()
        {
            if (player.cleared)
            {
                SceneManager.LoadScene("ClearSample");
            }
            else if (player.death)
            {
                SceneManager.LoadScene("GameOverSample");
            }
        }
    }
}