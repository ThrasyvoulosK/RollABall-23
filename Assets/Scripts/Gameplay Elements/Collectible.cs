using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float angularSpeed;
    public TMP_Text scoreText;
    public int points;

    public static Action<int> onPickedUp;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = FindObjectOfType<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, angularSpeed * Time.deltaTime, 0f, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Player"))
        {
            onPickedUp?.Invoke(points);
            //Destroy(this.gameObject);
            gameObject.SetActive(false);
            

           /* ScoreManager.score += points;
            scoreText.text = "Score: " + ScoreManager.score;

            Debug.Log("Passed Through");*/
        }
    }
}
