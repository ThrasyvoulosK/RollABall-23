using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;

    private readonly string Horizontal = "Horizontal";
    private readonly string Vertical = "Vertical";
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movementHorizontal = Input.GetAxis(Horizontal);
        float movementVertical = Input.GetAxis(Vertical);

        Vector3 movement = new Vector3(movementHorizontal, 0, movementVertical);

        rb.AddForce(speed * movement);
    }
}
