using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    public bool escopeta;
    public bool lanzallamas;

    private void OnTriggerStay(Collider other)
    {
        if (escopeta)
        {
            if (!other.GetComponent<Unit>().isPlayer && other.GetComponent<Unit>().isZombie)
            {
                other.GetComponent<Unit>().TakeDmg(1);
                StartCoroutine(DesactivarEscopeta());
            }
        }
        if (lanzallamas)
        {
            if (!other.GetComponent<Unit>().isPlayer && other.GetComponent<Unit>().isZombie)
            {
                other.GetComponent<Unit>().Ignite();
            }
        }
    }
    
    IEnumerator DesactivarEscopeta()
    {
        yield return null;
        escopeta = false;
    }
}
