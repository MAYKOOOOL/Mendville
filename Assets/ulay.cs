using UnityEngine;

public class ulay : MonoBehaviour
{
    public SetDialogue setDialogue;

    void Start()
    {
        if (setDialogue != null)
        {
            setDialogue.PassScenario();
        }
    }
}
