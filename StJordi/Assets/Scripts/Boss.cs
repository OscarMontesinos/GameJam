using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    /*
     ·Disparo básico, 2nda veneno
     ·Stomp latigo     
     ·Barrido latigo
     ·Clavar latigos ataque diglett uwu
     ·Rosas
     ·Enemigos (odio cuando los boses hacen esos)
     ·Sí
     ·No
     ·Puede que sí
     ·Puede que no
     ·ª
     
     */
    public GameObject disparo;
    bool ataque;
    public GameObject rosas;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {

       
    }
    IEnumerator Disparar(int repeticiones)
    {
        while (repeticiones > 0)
        {
            animator.SetBool("Atacando", true);
            yield return new WaitForSeconds(0.8f);
            Instantiate(disparo, new Vector3(transform.position.x,transform.position.y +3.5f,transform.position.z), transform.rotation);
            repeticiones--;

            yield return new WaitForSeconds(0.4f);
            animator.SetBool("Atacando", false);

            yield return new WaitForSeconds(1f);
        }
    }
}
