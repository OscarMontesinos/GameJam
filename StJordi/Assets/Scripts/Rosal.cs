using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rosal : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (!other.GetComponent<Unit>().isPlayer)
        {
            other.GetComponent<Unit>().isZombie = true;
        }
        else
        {
            other.GetComponent<PlayerMovement>().Envenenarse();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Unit>().isPlayer)
        {
            other.GetComponent<PlayerMovement>().envenenado = false;
        }
    }
}
