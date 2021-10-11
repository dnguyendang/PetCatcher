using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] float spawnTime = 3f;
    //private float elapsed_time = 0f;

    [SerializeField] GameObject[] Animals;
    [SerializeField] GameObject[] Fruits;

    private bool isGameOver = false;
    public Vector2 boundary;
    private int health = 5;
    public event Action OnGameEnd;
    private int score = 0;
    [SerializeField] UIController UI;

    public AudioSource aus;
    public AudioClip dieSound;

    private void Start()
    {
        StartCoroutine(SpawnAnimalCoroutine());
        StartCoroutine(SpawnFruitCoroutine());
    }

    private void Update()
    {
        spawnTime -= Time.deltaTime*0.1f;
        if(spawnTime <= 1f)
        {
            SpawnAnimal();
            SpawnAnimal();
            spawnTime = 2f;
        }
    }

    // Spawn animals
    private void SpawnAnimal()
    {
        int randomAnimal = UnityEngine.Random.Range(0, 49);
        boundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        Vector2 randomPos = new Vector2(UnityEngine.Random.Range(- boundary.x *3/4, boundary.x * 3/4), boundary.y);
        Instantiate(Animals[randomAnimal], randomPos, Quaternion.identity);
    }

    IEnumerator SpawnAnimalCoroutine()
    {
        while (!isGameOver)
        {
            SpawnAnimal();
            yield return new WaitForSeconds(spawnTime);
        }
    }

    // spawn fruits
    private void SpawnFruit()
    {
        int randomFruit = UnityEngine.Random.Range(0, 6);
        boundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        Vector2 randomPos = new Vector2(UnityEngine.Random.Range(-boundary.x * 3 / 4, boundary.x * 3 / 4), boundary.y);
        Instantiate(Fruits[randomFruit], randomPos, Quaternion.identity);
    }

    IEnumerator SpawnFruitCoroutine()
    {
        while (!isGameOver)
        {
            SpawnFruit();
            yield return new WaitForSeconds(2);
        }
    }


    //Health and Death
    public int _health { get { return health; } set { health = value; } }

    public void DecreaseHealth()
    {
        health--;
        if (CheckDeath())
        {
            EndGame();
        }
    }

    public void IncreaseHealth()
    {
        if(health < 5)
        {
            health++;
        }
    }

    private bool CheckDeath()
    {
        if(health <= 0)
        {
            Debug.Log("GameOver");
            return true;
        }
        return false;
    }

    public void EndGame()
    {
        if(aus && dieSound)
        {
            aus.PlayOneShot(dieSound);
        }
        isGameOver = true;
        PlayerPrefs.SetInt("High Score", score);
        OnGameEnd?.Invoke();
    }

    //Score
    public int _score { get { return score; } set { score = value; } }

    //replay
    //public void OnClickReplay()
    //{
    //    isGameOver = false;
    //    health = 3;
    //    score = 0;
    //    UI.TurnOffDeathPanel();
    //}
    public void resetGame()
    {
        SceneManager.LoadScene(0);
        UI.SetHighScore();
    }

}
