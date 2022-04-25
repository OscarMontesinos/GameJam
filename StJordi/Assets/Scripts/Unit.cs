using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public int hp;
    public bool isPlayer;
    public bool inmune;
    public float igniteSec;
     float igniteSecCalc;
    bool menu = false;
    public float speed;
    float mSpeed;
    PlayerMovement player;
    bool golpeando;
    public float rango;
    public bool isZombie;

    // Start is called before the first frame update
    private void Awake()
    {
        mSpeed = speed;
        player = FindObjectOfType<PlayerMovement>();
    }
    public void TakeDmg(int dmg)
    {
        if (!inmune)
        {
            hp -= dmg; 
            if (isPlayer)
            {
                inmune = true;
                StartCoroutine(Deinmunizar());
            }

            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    private void Update()
    {

        igniteSecCalc -= Time.deltaTime;
        if(igniteSecCalc < 0)
        {
            igniteSecCalc = 1;
            if (igniteSec > 0)
            {
                TakeDmg(1);
            }
        }

        igniteSec -= Time.deltaTime;

        if (!isPlayer && isZombie)
        {
            var dist = player.transform.position - transform.position;
            transform.Translate(dist.normalized * speed * Time.deltaTime);
            if (dist.magnitude < rango && !golpeando)
            {
                StartCoroutine(Golpear());
            }
        }

    }
    
    public void Ignite()
    {
        igniteSec = 3;
    }
    IEnumerator Golpear()
    {
        speed = 0;
        golpeando = true;
        yield return new WaitForSeconds(1f);
        player.GetComponent<Unit>().TakeDmg(1);
        golpeando = false;
        speed = mSpeed;
    }
    IEnumerator Deinmunizar()
    {
        yield return new WaitForSeconds(1f);
        inmune = false;
    }

}
