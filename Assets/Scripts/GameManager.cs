using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject player;

    public bool hasPlayerDied=false;
    bool death = false;

    [SerializeField]
    private GameObject scoreCanvas;

    [SerializeField]
    private GameObject pauseMenuCanvas;    

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(this.gameObject);

        //Debug.Log("Current Level: " + PlayerPrefs.GetInt("LEVEL"));
    }
    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(this.gameObject);

        SceneManager.sceneLoaded += InitialiseVariables;

        DontDestroyOnLoad(gameObject);
    }

    private void InitialiseVariables(Scene scene, LoadSceneMode arg1)
    {
        
        //if main menu or win screen
        if (scene.buildIndex==0||scene.buildIndex==4)
        {
            DestroyObjects<PauseMenu, ScoreManager>();

            if (scene.buildIndex == 4)
            {
                SavePlayerLevel(1);

                ScoreManager.levelScore = 0;
                SavePlayerScore(scene.buildIndex);
            }
            
        }
        else
        {
            SavePlayerLevel(scene.buildIndex);

            SavePlayerScore(scene.buildIndex);

            if (FindObjectOfType<PauseMenu>() == null)
                Instantiate(pauseMenuCanvas);

            if (FindObjectOfType<ScoreManager>() == null)
                Instantiate(scoreCanvas);

            if (FindObjectOfType<EventSystem>() == null)
                new GameObject("EventSystem", typeof(EventSystem),typeof(StandaloneInputModule));

            player = FindObjectOfType<PlayerController>().gameObject;
            hasPlayerDied = false;
            death = false;

        }
        
    }

    void DestroyObjects<T,M>() where T:MonoBehaviour where M:MonoBehaviour
        {
        if (FindObjectOfType<T>() != null)
            Destroy(FindObjectOfType<T>().gameObject);

        if (FindObjectOfType<M>() != null)
            Destroy(FindObjectOfType<M>().gameObject);
    }
    void InstantiateObjects<T, M>() where T : PauseMenu where M : ScoreManager
    {
        if (FindObjectOfType<T>() == null)
            Instantiate(pauseMenuCanvas);

        if (FindObjectOfType<T>() == null)
            Instantiate(scoreCanvas);
    }
    void SavePlayerScore(int level)
    {
        if(level==3)
        {
            ScoreManager.levelScore = 0;
            ScoreManager.score = 0;

            PlayerPrefs.SetInt(SavedValues.SCORE, ScoreManager.levelScore);
        }
        else
        {
            if(ScoreManager.levelScore!=0)
            {
                PlayerPrefs.SetInt(SavedValues.SCORE, ScoreManager.levelScore);
            }
        }
        
    }
    void SavePlayerLevel(int level)
    {
        SavedValues.CURRENT_LEVEL = level;

        PlayerPrefs.SetInt(SavedValues.LEVEL, SavedValues.CURRENT_LEVEL);
    }
    // Update is called once per frame
    void Update()
    {
        if(player!=null)
        {
            if (player.transform.position.y < -5f)
            {
                player.SetActive(false);
                hasPlayerDied = true;
            }

            if (hasPlayerDied)
            {
                if (!death)
                    StartCoroutine(RespawnPlayer());
            }
        }
        
    }

    IEnumerator RespawnPlayer()
    {
        death = true;
        yield return new WaitForSecondsRealtime(1f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
