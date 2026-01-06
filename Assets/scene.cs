using UnityEngine;
using UnityEngine.SceneManagement;

public class scene : MonoBehaviour
{
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
