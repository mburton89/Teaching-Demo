using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectible : MonoBehaviour
{
    public AudioClip collectSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundManager.Instance.PlaySound(collectSound);
        Destroy(gameObject);
        GetCollected();
    }

    public abstract void GetCollected();
}