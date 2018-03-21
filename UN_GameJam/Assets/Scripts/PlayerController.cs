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
    Animator walking_animation;
    //Dash function
    void Start()
    {
        walking_animation = GetComponent<Animator>();
    }
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
        float move = Input.GetAxis("Vertical");
        walking_animation.SetFloat("Speed", move);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dash();
        }

        Vector2 currentPosition = rb.position;
        if (Input.GetKey(KeyCode.D))
        {
            currentPosition.x += speed * Time.deltaTime;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            walking_animation.SetFloat("Speed", 1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            currentPosition.x -= speed * Time.deltaTime;
            transform.localRotation = Quaternion.Euler(0,180,0);
            walking_animation.SetFloat("Speed", 1);
        }
        if (Input.GetKey(KeyCode.W))
        {
            currentPosition.y += speed * Time.deltaTime;
            walking_animation.SetFloat("Speed", 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            currentPosition.y -= speed * Time.deltaTime;
            walking_animation.SetFloat("Speed", 1);
        }

        if (!Input.anyKey)
        {
            walking_animation.SetFloat("Speed", 0);
        }

        timer -= Time.deltaTime;
        rb.MovePosition(currentPosition);
        bar.fillAmount = 1f-(timer / 5f);
        


    }
}   
