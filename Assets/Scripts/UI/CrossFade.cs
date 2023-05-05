using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrossFade : MonoBehaviour
{
    public Animator crossFadeAnimator;
    public float animationTime = 0f;

    public const string FadeIn = "FadeIn";
    public const string FadeOut = "FadeOut";
    // Start is called before the first frame update
    void Start()
    {
        crossFadeAnimator = GetComponent<Animator>();
        crossFadeAnimator.SetTrigger(FadeOut);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator MoveToNextScene()
    {
        crossFadeAnimator.SetTrigger(FadeIn);

        yield return new WaitForSeconds(animationTime);

        ScoreManager.levelScore = ScoreManager.score;

        crossFadeAnimator.SetTrigger(FadeOut);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public IEnumerator MoveToScene(int index)
    {
        Debug.Log("MoveToScene " + index);
        //if starting from level one, set boolean
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (index == 1)
            gameManager.hasStartedFromLevelOne = true;
        else
            gameManager.hasStartedFromLevelOne = false;
        Debug.Log(gameManager.hasStartedFromLevelOne);

        crossFadeAnimator.SetTrigger(FadeIn);

        yield return new WaitForSeconds(animationTime);

        ScoreManager.levelScore = ScoreManager.score;

        SceneManager.LoadScene(index);        
    }

}
