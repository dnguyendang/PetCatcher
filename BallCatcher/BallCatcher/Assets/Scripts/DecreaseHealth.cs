using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseHealth : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    public AudioSource aus;
    public AudioClip RabitSound;
    public AudioClip DearSound;
    public AudioClip DogSound;
    public AudioClip CatSound;
    public AudioClip MouseSound;
    public AudioClip PigSound;
    public AudioClip DuckSound;
    public AudioClip FrogSound;
    public AudioClip BearSound;
    public AudioClip PandaSound;
    public AudioClip FoodSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rabit"))
        {
            if(aus && RabitSound)
            {
                aus.PlayOneShot(RabitSound);
            }
            gameManager.DecreaseHealth();
        }
        else if (collision.gameObject.CompareTag("Dear"))
        {
            if(aus&& DearSound)
            {
                aus.PlayOneShot(DearSound);
            }
            gameManager.DecreaseHealth();
        }
        else if (collision.gameObject.CompareTag("Dog"))
        {
            if(aus && DogSound)
            {
                aus.PlayOneShot(DogSound);
            }
            gameManager.DecreaseHealth();
        }
        else if (collision.gameObject.CompareTag("Cat"))
        {
            if(aus&& CatSound)
            {
                aus.PlayOneShot(CatSound);
            }
            gameManager.DecreaseHealth();
        }
        else if (collision.gameObject.CompareTag("Mouse"))
        {
            if(aus&& MouseSound)
            {
                aus.PlayOneShot(MouseSound);
            }
            gameManager.DecreaseHealth();
        }
        else if (collision.gameObject.CompareTag("Pig"))
        {
            if(aus && PigSound)
            {
                aus.PlayOneShot(PigSound);
            }
            gameManager.DecreaseHealth();
        }
        else if (collision.gameObject.CompareTag("Duck"))
        {
            if(aus&& DuckSound)
            {
                aus.PlayOneShot(DuckSound);
            }
            gameManager.DecreaseHealth();
        }
        else if (collision.gameObject.CompareTag("Bear"))
        {
            if(aus && BearSound)
            {
                aus.PlayOneShot(BearSound);
            }
            gameManager.DecreaseHealth();
        }
        else if (collision.gameObject.CompareTag("Panda"))
        {
            if(aus && PandaSound)
            {
                aus.PlayOneShot(PandaSound);
            }
            gameManager.DecreaseHealth();
        }
        else if (collision.gameObject.CompareTag("Frog"))
        {
            if(aus && FrogSound)
            {
                aus.PlayOneShot(FrogSound);
            }
            gameManager.DecreaseHealth();
        }
        else if (collision.gameObject.CompareTag("Food"))
        {
            if(aus && FoodSound)
            {
                aus.PlayOneShot(FoodSound);
            }
            gameManager.IncreaseHealth();
            Destroy(collision.gameObject);
        }
    }
}
