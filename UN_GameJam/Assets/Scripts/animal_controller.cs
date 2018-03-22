using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animal_controller : MonoBehaviour
{
    public Rigidbody2D player;
    public float x_length = 10f;
    public float y_length = 10f;
    public int amount = 10;
    private Vector3 new_position;


    [SerializeField] GameObject[] animals;
    
    GameObject temp_animal;
    bool can_spawn = true;
    // Use this for initialization
    void Start()
    {
        spawn();
        
    }
 
    void spawn()
    {
        if (amount > 0)
        {
            temp_animal = animals[Random.Range(0, animals.Length)];
            new_position = new Vector3(Random.Range(-150, 150), Random.Range(-50, 50), 0);
            Instantiate(temp_animal, player.transform.position + new_position, Quaternion.identity);
            amount -= 1;
            spawn();
        }
        
            
    }

    private void Update()
    {
        if (amount == 0)
        {
            spawn();
        }
    }
}
    

