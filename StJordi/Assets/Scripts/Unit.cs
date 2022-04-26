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
    public PlayerMovement player;
    bool golpeando;
    public float rango;
    public bool isZombie;
    public bool zona1;
    public bool zona2;
    public bool zona3;
    public bool zona4;

    // Start is called before the first frame update
    private void Awake()
    {
        mSpeed = speed;
        player = FindObjectOfType<PlayerMovement>();
    }
    virtual public void TakeDmg(int dmg)
    {
        StartCoroutine(GolpearVelocidad());
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
    virtual public void Update()
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
            if (zona1 && player.GetComponent<Unit>().zona1 || zona3 && player.GetComponent<Unit>().zona3 || zona2 && player.GetComponent<Unit>().zona2 || zona1 && player.GetComponent<Unit>().zona1) {
                var dist = player.transform.position - transform.position;
                transform.Translate(dist.normalized * speed * Time.deltaTime);
                if (dist.magnitude < rango && !golpeando)
                {
                    StartCoroutine(Golpear());
                } }
        }

    }
    
    public void Ignite()
    {
        igniteSec = 3;
    }
    IEnumerator GolpearVelocidad()
    {
        if (!isPlayer)
        {
            speed = 0;
            yield return new WaitForSeconds(0.2f);
            speed = mSpeed;
        }
        else
        {
            GetComponent<PlayerMovement>().forceSpeed = 0;
            yield return new WaitForSeconds(0.4f);
            GetComponent<PlayerMovement>().forceSpeed = GetComponent<PlayerMovement>().mForceSpeed;
        }
    }
    public virtual IEnumerator Golpear()
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
