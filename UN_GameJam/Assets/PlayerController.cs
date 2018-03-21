using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour {
    public Rigidbody2D rb;
    public float speed = 10f;
    public bool dashCooldown = true;
    public float timer = 0f;
    public Image bar;
    //Dash function
    void Dash()
    {
        bool dash_ready = false;
        if (timer <= 0f)
        {
            dash_ready = true;
        }
        if (dash_ready)
        {
            speed *= 4f;
            timer = 5f;
            dash_ready = false;
            StartCoroutine(return_speed());
            
        }
    }
    IEnumerator return_speed()
    {
        yield return new WaitForSeconds(0.5f);
        speed = 5f;
    }
void Update () {

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dash();
        }

        Vector2 currentPosition = rb.position;
        if (Input.GetKey(KeyCode.D))
        {
            currentPosition.x += speed * Time.deltaTime;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            currentPosition.x -= speed * Time.deltaTime;
            transform.localRotation = Quaternion.Euler(0,180,0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            currentPosition.y += speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            currentPosition.y -= speed * Time.deltaTime;
        }

        timer -= Time.deltaTime;
        rb.MovePosition(currentPosition);
        bar.fillAmount = 1f-(timer / 5f);



    }
}   
