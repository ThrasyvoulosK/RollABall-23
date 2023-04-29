using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour,ICrossFadeHolder
{
    public Button playGameButton;
    public Button quitGameButton;
    public float animationTime = 1f;

    [SerializeField]
    private CrossFade crossFade;

    public void EnableCrossFade()
    {
        crossFade = GetComponentInChildren<CrossFade>(true);
        crossFade.gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {

        EnableCrossFade();
        
        playGameButton.onClick.AddListener(delegate 
        {
            StartCoroutine(crossFade.MoveToScene( PlayerPrefs.GetInt(SavedValues.LEVEL,1)));
        });
        quitGameButton.onClick.AddListener(delegate 
        {
            Application.Quit();
        });
    }

    
   
}
