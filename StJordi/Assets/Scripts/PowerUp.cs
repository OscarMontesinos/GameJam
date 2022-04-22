using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public int powerup;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (powerup == 1)
            {
                collision.gameObject.GetComponent<PlayerMovement>().forceSpeed = 2000;
                Destroy(gameObject);
            }
            else if(powerup == 2)
            {
                collision.gameObject.GetComponent<Unit>(). hp += 2;
                Destroy(gameObject);
            }

        }
    }
}
