using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public string geneCode;
    public float forceMagnitude = 1f;

    public Image imageRenderer; 
    public SpriteRenderer spriteRenderer; 

    public string GeneCode => geneCode; 
    public Sprite CurrentSprite
    {
        get
        {
            if (imageRenderer != null)
                return imageRenderer.sprite;

            if (spriteRenderer == null)
                spriteRenderer = GetComponent<SpriteRenderer>();

            return spriteRenderer != null ? spriteRenderer.sprite : null;
        }
    }

    public void Setup(string code, Sprite sprite)
    {
        geneCode = code;

        if (imageRenderer != null)
        {
            imageRenderer.sprite = sprite;
        }
        else
        {
            if (spriteRenderer == null)
                spriteRenderer = GetComponent<SpriteRenderer>();

            if (spriteRenderer != null)
                spriteRenderer.sprite = sprite;
        }
    }

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        float angle = Random.Range(0f, 360f);
        Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
        rb.AddForce(direction * forceMagnitude, ForceMode2D.Impulse);
    }
}
