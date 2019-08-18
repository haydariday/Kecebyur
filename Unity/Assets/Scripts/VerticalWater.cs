using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VerticalWater : MonoBehaviour
{
    [Tooltip ("Game unit per second.")]
    [SerializeField] float scrollUpRate = 2f;

    [SerializeField] float LevelLoadDelay = 2f;
    [SerializeField] float LevelExitSlowMoFactor = 0.2f;
    // Update is called once per frame
    void Update()
    {
        float yMove = scrollUpRate * Time.deltaTime;
        transform.Translate(new Vector2(0f, yMove));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(LoadGameOver());
    }
    IEnumerator LoadGameOver()
    {
        Time.timeScale = LevelExitSlowMoFactor;
        yield return new WaitForSecondsRealtime(LevelLoadDelay);
        Time.timeScale = 1f;
        SceneManager.LoadScene(3);
    }
}
