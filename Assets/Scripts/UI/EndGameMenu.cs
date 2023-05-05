using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGameMenu : MonoBehaviour, ICrossFadeHolder
{
    //[SerializeField]
    private CrossFade crossFade;

    public Button retryButton;
    public Button quitGameButton;

    public TMP_Text scoreBox;
    public TMP_Text timeBox;
    // Start is called before the first frame update
    void Start()
    {
        EnableCrossFade();

        retryButton = retryButton.GetComponent<Button>();
        //Debug.Log(retryButton.gameObject.name);
        

        retryButton.onClick.AddListener(delegate
        {
            StartCoroutine(crossFade.MoveToScene(1));
        });

        quitGameButton.onClick.AddListener(delegate
        {
            Application.Quit();
        });

        //set scoreBox and TimeBox
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager.hasStartedFromLevelOne==false)
        {
            Debug.Log("level one is false");
            Debug.Log(ScoreManager.score + " " + SavedValues.TIME);
            scoreBox.text = "No Score Yet\n Please try Again";
            timeBox.text = "No Time Record Yet\n Please try Again";
        }
        else
        {
            Debug.Log("level one true");
            //scoreBox.text ="Score\n"+ (ScoreManager.score).ToString();
            //timeBox.text = FindObjectOfType<TimerManager>().timeText.text;
            timeBox.text ="Time\n" +SavedValues.TIME;

        }
        //reset value
        gameManager.hasStartedFromLevelOne = false;

    }

    public void EnableCrossFade()
    {
        crossFade = GetComponentInChildren<CrossFade>(true);
        crossFade.gameObject.SetActive(true);
    }

}
