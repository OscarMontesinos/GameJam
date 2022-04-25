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
        yield return new WaitForSeconds(1f);
        inmune = false;
    }

}
