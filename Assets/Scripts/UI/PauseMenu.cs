using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    bool hasGamePaused = false;
    private CanvasGroup canvasGroup;

    public Button continueGameButton;
    public Button quitGameButton;
    public Button goToMainMenu;

    //private CrossFade crossFade;
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0f;

        continueGameButton.onClick.AddListener(delegate
        {
            ContinueGame();
            hasGamePaused = false;
        });
        quitGameButton.onClick.AddListener(delegate
        {
            Time.timeScale = 0f;
            canvasGroup.alpha = 1f;
            hasGamePaused = true;
        });
        goToMainMenu.onClick.AddListener(delegate
        {
            ContinueGame();
            ScoreManager.score = 0;
            SceneManager.LoadScene(0);

            Destroy(gameObject);
        });

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //if stopped
            if (!hasGamePaused)
            {
                PauseGame();
            }
            //if not stopped
            else
            {
                ContinueGame();
            }

            hasGamePaused = !hasGamePaused;
        }
    }
    void PauseGame()
    {
        Time.timeScale = 0f;
        //with 1 it fully appears
        canvasGroup.alpha = 1f;
    }

    void ContinueGame()
    {
        Time.timeScale = 1f;
        canvasGroup.alpha = 0f;
    }
}
