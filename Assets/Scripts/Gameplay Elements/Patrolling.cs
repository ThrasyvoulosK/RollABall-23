using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : MonoBehaviour
{
    public Vector3 startingPosition;
    public Transform endingTransform;
    public bool hasReachedFinalPosition;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        patrolBetweenTwoPoints();
    }
    public void patrolBetweenTwoPoints()
    {
        if (!hasReachedFinalPosition)
        {
            if (transform.position != endingTransform.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, endingTransform.position, speed * Time.deltaTime);

            }
            else
                hasReachedFinalPosition = true;
        }
        //
        else
        {
            if (transform.position != startingPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, startingPosition, speed * Time.deltaTime);

            }
            else
                hasReachedFinalPosition = false;
        }
    }
}
