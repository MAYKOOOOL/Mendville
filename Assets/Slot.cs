using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    [SerializeField] private string allowedGeneType;

    public bool isFilled = true;

    public void OnDrop(PointerEventData eventData)
    {
        if (isFilled)
        {
            return;
        }

        GameObject dropped = eventData.pointerDrag;

        if (dropped != null)
        {
            hold holdComponent = dropped.GetComponent<hold>();
            drag dragComponent = dropped.GetComponent<drag>();

            if (holdComponent != null && holdComponent.geneData != null)
            {
                if (holdComponent.geneData.geneType == allowedGeneType)
                {
                    if (dragComponent != null)
                    {
                        dragComponent.parentAfter = transform;
                    }

                    isFilled = true;
                }
            }
        }
    }

    private void Update()
    {
        if (transform.childCount == 0)
        {
            isFilled = false;
        }

        if (transform.childCount == 1)
        {
            isFilled = true;
        }
    }
}
