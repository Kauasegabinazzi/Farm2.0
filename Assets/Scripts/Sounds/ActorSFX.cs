using UnityEngine;

public class ActorSFX : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    public void PlaySFX(AudioClip clip)
    {
        // toca uma vez e se chamar de novo chama por cima da outra requisicao
        audioSource.PlayOneShot(clip);
    }
}
