
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---- Audio Source -----")]
   [SerializeField] AudioSource musicSource;
   [SerializeField] AudioSource SFXSource;

   [Header("---- Audio Clips ------")]
   public AudioClip background;
   public AudioClip Select;

   private void Start()
   {
    musicSource.clip = background;
    musicSource.Play();
   }

   public void PlaySFX(AudioClip clip)
   {
    SFXSource.PlayOneShot(clip);
   }

}
