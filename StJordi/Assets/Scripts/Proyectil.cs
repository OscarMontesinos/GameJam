using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{

    float tiempo = 0;
    public float lifetime = 0;
    public float speed = 0;
    public float detour = 0;
    public bool enemy;
    public float followRange;
    PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        float aux = Random.Range(-detour, detour);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y - aux, transform.eulerAngles.z);
        player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (followRange > 0)
        {
            transform.LookAt(player.transform.position);

            transform.Translate(Vector3.forward * speed / 4 * Time.deltaTime);
            followRange -= Time.deltaTime;
        }
        else
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        tiempo += Time.deltaTime;
        if (tiempo >= lifetime*2.5)
        {
            Destroy(gameObject);
        }
    }

}
