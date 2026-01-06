using UnityEngine;
using UnityEngine.UI;

public class Embudo : MonoBehaviour
{
    [Header("References")]
    public Result resultScript;
    public GameObject generateButton;
    public GameObject holder;
    public GameObject ballPrefab;
    public Transform[] spawnPoint;
    public GameObject[] balls;
    public GameObject resultPanel;
    public GameObject dial;
    public GameObject dial1;
    public Button But;
    public Button But1;
    public Button But2;
    public makuhaRes res;

    [Header("State")]
    public string firstGeneCode { get; private set; }
    public Sprite firstSprite { get; private set; }

    private bool hasCollided = false;
    
    private void Start()
    {
        balls = new GameObject[spawnPoint.Length];

        if (resultScript == null)
        {
            Debug.LogError("ResultScript is not assigned in the Inspector!");
        }
    }

    public void SpawnBalls()
    {
        var children = resultScript.GetPunnettSquare();
        if (children.Count < spawnPoint.Length) return;

        for (int i = 0; i < spawnPoint.Length; i++)
        {
            balls[i] = Instantiate(ballPrefab, spawnPoint[i].position, Quaternion.identity);

            var child = children[i];
            Sprite usedSprite = resultScript.Is_Color ? child.colorSprite : child.altSprite;

            Ball ballScript = balls[i].GetComponent<Ball>();
            if (ballScript != null)
            {
                ballScript.Setup(child.geneCode, usedSprite);
            }
        }

        hasCollided = false;
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasCollided) return;

        if (collision.gameObject.CompareTag("Balls") )
        {
            Ball ballScript = collision.gameObject.GetComponent<Ball>();
            if (ballScript == null) return;

            hasCollided = true;

            firstGeneCode = ballScript.GeneCode;
            firstSprite = ballScript.CurrentSprite;
           
            foreach (var ball in balls)
            {
                if (ball != null)
                    Destroy(ball);
            }

            if (resultPanel != null)
                resultPanel.SetActive(true);

            if (resultScript.Is_Color)
            {
                if (dial1 != null)
                    dial1.SetActive(true);

                generateButton.SetActive(false);
                holder.SetActive(false);
                gameObject.SetActive(false);

                But.interactable = false;
                But1.interactable = false;
                But2.interactable = true;
            }
            
            else
            {
                if (dial != null)
                    dial.SetActive(true);

                generateButton.SetActive(false);
                holder.SetActive(false);
                gameObject.SetActive(false);

                But.interactable = true;
                But1.interactable = false;
                But2.interactable = false;
            }
        }
    }

    public void Resets()
    {
        for (int i = 0; i < spawnPoint.Length; i++)
        {
            if (balls[i] != null)
                Destroy(balls[i]);
        }

        hasCollided = false;
        firstGeneCode = null;
        firstSprite = null;
        gameObject.SetActive(true);
        generateButton.SetActive(true);
        holder.SetActive(true);

        if (resultPanel != null)
            resultPanel.SetActive(false);
    }
}
