using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public int hp;
    public bool player;
    public bool inmune;
    public GameObject canvas;
    public Text vida;
    bool menu = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menu == false)
            {
                canvas.SetActive(true);
                menu = true;
                Time.timeScale = 0;
            }
            else
            {
                canvas.SetActive(false);
                menu = false;
                Time.timeScale = 1;
            }
        }

        vida.text = "HP: " + hp;
    }

    public void TakeDmg(int dmg)
    {
        if (!inmune)
        {
            hp -= dmg; 
            if (player)
            {
                inmune = true;
                StartCoroutine(Deinmunizar());
            }

            if (hp <= 0)
            {
                canvas.SetActive(true);
                Destroy(gameObject);
            }
        }
    }

    IEnumerator Deinmunizar()
    {
        yield return new WaitForSeconds(2f);
        inmune = false;
    }

}
