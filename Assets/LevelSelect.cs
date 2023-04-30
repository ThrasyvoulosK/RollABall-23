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
        Debug.Log(totalLevels);
        int i = 1;
        int tempNum;
        for ( i=1;i<=totalLevels; i++)
        {
            Debug.Log(i);
            Debug.Log(gameObject.transform.GetChild(i - 1));
            tempNum = i;
            gameObject.transform.GetChild(i-1).GetComponent<Button>().onClick.AddListener(delegate
            {
                //Debug.Log("Move to scene " + i);
                //Debug.Log(i == 4);
                //int childNum = i;
                //StartCoroutine(crossFade.MoveToScene(i));
                //StartCoroutine(crossFade.MoveToScene(1));
                //StartCoroutine(crossFade.MoveToScene(SceneManager.GetActiveScene().buildIndex+i));
                //int tempNum
                int j = 0;
                for ( j=0; j<gameObject.transform.childCount; j++)
                {
                    Debug.Log(j);
                    Debug.Log(gameObject.transform.GetChild(j).name);
                    if (gameObject.transform.GetChild(j).name == EventSystem.current.currentSelectedGameObject.name)
                        break;
                }
                Debug.Log(EventSystem.current.currentSelectedGameObject.name);
                //StartCoroutine(crossFade.MoveToScene(tempNum));
                StartCoroutine(crossFade.MoveToScene(j+1));

            });
        }
        Debug.Log(i);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
