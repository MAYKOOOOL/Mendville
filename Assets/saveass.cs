using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class saveass : MonoBehaviour
{
    public static saveass Instance;

    public Button contin;   // Continue button
    public bool padagos;    // Used once after scene load

    private void Awake()
    {
       

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void Update()
    {
        contin = GameObject.FindGameObjectWithTag("continue").GetComponent<Button>();
        if (MendVille.Instance.cont == true)
        {
            contin.interactable = true;        }
    }
    private void Start()
    {
        UpdateContinueButton();
    }

    // -----------------------------
    // FINISH TUTORIAL
    // -----------------------------
    public void FinishTutorial()
    {
        if (MendVille.Instance == null) return;

        MendVille.Instance.AllowContinue();
        UpdateContinueButton();
    }

    // -----------------------------
    // RESET (NEW GAME)
    // -----------------------------
    public void ResetGame()
    {
        padagos = false;

        //if (MendVille.Instance != null)
        //{
        //    MendVille.Instance.NewGame("Game");
        //    MendVille.Instance.cont = false;
        //    MendVille.Instance.UpdateTutorialObjects();
        //}

            if (MendVille.Instance != null)
                Destroy(MendVille.Instance.gameObject);

           

            if (SaveableObject.Instance != null)
                Destroy(SaveableObject.Instance.gameObject);

           
        
         

        UpdateContinueButton();
    }

    // -----------------------------
    // CONTINUE GAME
    // -----------------------------
    public void ContinueGame()
    {
        padagos = true;
        SceneManager.LoadScene("Game");
    }

    // -----------------------------
    // UI HELPER
    // -----------------------------
    private void UpdateContinueButton()
    {
        if (contin == null) return;

        if (MendVille.Instance != null)
            contin.interactable = MendVille.Instance.cont;
        else
            contin.interactable = false;
    }
}
