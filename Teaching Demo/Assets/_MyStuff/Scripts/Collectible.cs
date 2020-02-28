using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectible : MonoBehaviour
{
    public AudioClip collectSound;

    public bool canBeCollected;

    private void Awake()
    {
        canBeCollected = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && canBeCollected)
        {
            canBeCollected = false;
            SoundManager.Instance.PlaySound(collectSound);
            Destroy(gameObject);
            GetCollected();
        }
    }

    public abstract void GetCollected();
}
