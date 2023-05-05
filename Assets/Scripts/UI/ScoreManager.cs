using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour,ICrossFadeHolder
{
    public static int score=0;
    public TMP_Text scoreText;
    public Collectible[] collectibles;
    public static int levelScore = 0;

    private CrossFade crossFade;

    private void Awake()
    {
        CollectibleSpawner.onCollectiblesSpawned += FindCollectibles;

        SceneManager.sceneLoaded += InitialiseVariables;

        Collectible.onPickedUp += SetScore;
    }
    // Start is called before the first frame update
    void Start()
    {

        EnableCrossFade();

        FindCollectibles();        

        DisplayScore(PlayerPrefs.GetInt(SavedValues.SCORE, 0));

        SaveScore();

        DontDestroyOnLoad(this.gameObject);
    }

    void FindCollectibles()
    {
        collectibles = FindObjectsOfType<Collectible>();
    }

    void SaveScore()
    {
        score = PlayerPrefs.GetInt(SavedValues.SCORE, 0);
    }

    void DisplayScore(int points)
    {
        scoreText.text = "Score: " + points;
    }
    private void SetScore(int points)
    {
        StartCoroutine(SetScoreCoroutine(points));
    }
    private IEnumerator SetScoreCoroutine(int points)
    {
        score += points;
        Debug.Log(score);
        //DisplayScore(points);
        DisplayScore(score);

        //wait onee frame
        yield return null;
        if (HasPlayerCollectedAllCollectibles())
        {
            scoreText.text = "You Win!";
            StartCoroutine(crossFade.MoveToNextScene());
        }
    }

    private void InitialiseVariables(Scene arg0, LoadSceneMode arg1)
    {
        EnableCrossFade();

        FindCollectibles();

        DisplayScore(PlayerPrefs.GetInt(SavedValues.SCORE, 0));

        SaveScore();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //DisplayScore(PlayerPrefs.GetInt(SavedValues.SCORE, 0));
    }

    bool HasPlayerCollectedAllCollectibles()
    {
        foreach (var collectible in collectibles)
        {
            if (collectible.gameObject.activeInHierarchy)
                return false;
        }
        return true;
    }

    private void OnDisable()
    {
        CollectibleSpawner.onCollectiblesSpawned -= FindCollectibles;
    

        SceneManager.sceneLoaded -= InitialiseVariables;

        Collectible.onPickedUp -= SetScore;
    }

    public void EnableCrossFade()
    {
        crossFade = GetComponentInChildren<CrossFade>(true);
        crossFade.gameObject.SetActive(true);
    }
}
