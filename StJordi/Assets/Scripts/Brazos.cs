using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brazos : MonoBehaviour
{
    float pointToReach = 11.6f;
    float actualPoint;
    bool ataque;
    public float speed;
    public float giro;
    GameObject pointGiro;
    private void Start()
    {
        actualPoint = transform.position.y;
        pointGiro = transform.GetChild(0).gameObject;
        StartCoroutine(Parriba());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Unit>().isPlayer && ataque)
        {
            other.GetComponent<Unit>().TakeDmg(1);
        }
    }

    IEnumerator Parriba()
    {
        yield return new WaitForSeconds(1);
        ataque = true;
        while(transform.position.y < pointToReach + actualPoint)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * speed, transform.position.z);
            yield return null;
        }
        yield return new WaitForSeconds(1);
        int girar = Random.Range(0, 2);
        if(girar == 1)
        {
            while (pointGiro.transform.eulerAngles.y < 74)
            {
                pointGiro.transform.eulerAngles = new Vector3(pointGiro.transform.eulerAngles.x + Time.deltaTime * speed * 17, pointGiro.transform.eulerAngles.y, pointGiro.transform.eulerAngles.z);
                yield return null;
            }

            yield return new WaitForSeconds(0.4f);
            while (giro > 0)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + Time.deltaTime * speed * 10, transform.eulerAngles.x);

                    giro -= speed * Time.deltaTime;
                yield return null;
            }
        } 
        Destroy(gameObject);
    }
}
