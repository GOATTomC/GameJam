using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal_movement : MonoBehaviour {
    Vector2 current_pos;
    private Rigidbody2D rb;

    private float timeLeft;
    private Vector3 direction;
    public float speed = 3;



    // Use this for initialization
    void Start ()
    {
        timeLeft = Random.Range(2, 5);
        rb = GetComponent<Rigidbody2D>();
        current_pos = new Vector2(Random.Range(10, 100), Random.Range(10, 100));
        ChangeDirection();
    }
	
	// Update is called once per frame
	void Update ()
    {
        WaitForNewDirection();
        Move();

	}

    private void WaitForNewDirection()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0)
        {
            ChangeDirection();
            timeLeft = Random.Range(2, 5);
        }
    }

    private void ChangeDirection()
    {
        Vector3 tempDirection = (Random.insideUnitCircle * 3) + new Vector2(this.transform.position.x, this.transform.position.y);
        tempDirection -= this.transform.position;
        tempDirection.Normalize();

        direction = tempDirection;
    }

    private void Move()
    {
        this.transform.Translate((direction * speed) * Time.deltaTime);
    }
}
