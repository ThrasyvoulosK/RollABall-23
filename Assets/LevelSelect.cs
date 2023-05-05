using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    Button[] levelButton;

    [SerializeField]
    CrossFade crossFade;
    // Start is called before the first frame update
    void Start()
    {
        //crossFade=GetComponentInChildren<CrossFade>(true);

        int totalLevels = gameObject.transform.childCount;
        //Debug.Log(totalLevels);
        int i = 1;
        for ( i=1;i<=totalLevels; i++)
        {
            Button currentButton = gameObject.transform.GetChild(i - 1).GetComponent<Button>();
            currentButton.onClick.AddListener(delegate
            {
                
                int j = 0;
                for ( j=0; j<gameObject.transform.childCount; j++)
                {
                    //Debug.Log(j);
                    //Debug.Log(gameObject.transform.GetChild(j).name);
                    if (gameObject.transform.GetChild(j).name == EventSystem.current.currentSelectedGameObject.name)
                        break;
                }
                //Debug.Log(EventSystem.current.currentSelectedGameObject.name);

                StartCoroutine(crossFade.MoveToScene(j+1));

            });

            //disable level(s) beyond the current one
            //Debug.Log("Current level is "+SavedValues.CURRENT_LEVEL);
            if (SavedValues.CURRENT_LEVEL <= (i - 1))
                currentButton.interactable = false;


        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
