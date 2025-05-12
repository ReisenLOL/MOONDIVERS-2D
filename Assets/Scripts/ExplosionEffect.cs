using UnityEngine;

public class ExplosionEffect : ProjectileEffect
{
    public AudioClip explosionSound;
    public AudioSource audioSource;
    private void Start()
    {
        audioSource.PlayOneShot(explosionSound, 0.5f);
    }
}
