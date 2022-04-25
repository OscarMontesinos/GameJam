using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{

    float tiempo = 0;
    public float lifetime = 0;
    public float speed = 0;
    public float detour = 0;
    // Start is called before the first frame update
    void Start()
    {
        float aux = Random.RandomRange(-detour, detour);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y - aux, transform.eulerAngles.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        tiempo += Time.deltaTime;
        if (tiempo >= lifetime*5)
        {
            Destroy(gameObject);
        }
    }

}
