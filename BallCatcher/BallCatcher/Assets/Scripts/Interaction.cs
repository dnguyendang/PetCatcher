using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    public AudioSource aus;

    public AudioClip HealthSound;
    public AudioClip ScoreSound;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            if(aus && HealthSound)
            {
                aus.PlayOneShot(HealthSound);
            }
            gameManager.IncreaseHealth();
            Destroy(collision.gameObject);
        }
        else
        {
            if(aus && ScoreSound)
            {
                aus.PlayOneShot(ScoreSound);
            }
            gameManager._score++;
            Destroy(collision.gameObject);
        }
    }
}
