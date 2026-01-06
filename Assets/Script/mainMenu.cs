using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        StartCoroutine(PlaySFXAndLoad(sceneName));
    }

    private IEnumerator PlaySFXAndLoad(string sceneName)
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClickSound);
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClickSound);
        Application.Quit();
    }
}
