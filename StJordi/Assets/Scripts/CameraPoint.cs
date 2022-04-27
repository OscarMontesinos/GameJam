using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPoint : MonoBehaviour
{
    public string song;
    private void OnTriggerEnter(Collider other)
    {
        AudioManager.Instance.PlaySong(song);
    }
}
