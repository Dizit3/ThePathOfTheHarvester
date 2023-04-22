using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitToMainMenuButton : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene(1);
    }
}