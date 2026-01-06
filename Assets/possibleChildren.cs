using UnityEngine;

public class possibleChildren : MonoBehaviour
{
    public Transform posUp;
    public Transform posDown;
    public bool isUp = false;

    public void Click()
    {
        if (!isUp)
        {
            gameObject.transform.position = posDown.position;
            isUp = true;
        }

        else
        {
            gameObject.transform.position = posUp.position;
            isUp = false;
        }
    }
}
