using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameMenu : MonoBehaviour, ICrossFadeHolder
{
    //[SerializeField]
    private CrossFade crossFade;

    public Button retryButton;
    public Button quitGameButton;
    // Start is called before the first frame update
    void Start()
    {
        EnableCrossFade();

        retryButton = GetComponent<Button>();

        

        retryButton.onClick.AddListener(delegate
        {
            StartCoroutine(crossFade.MoveToScene(1));
        });

        quitGameButton.onClick.AddListener(delegate
        {
            Application.Quit();
        });
    }

    public void EnableCrossFade()
    {
        crossFade = GetComponentInChildren<CrossFade>(true);
        crossFade.gameObject.SetActive(true);
    }

}
