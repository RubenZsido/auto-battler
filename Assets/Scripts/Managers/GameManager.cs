using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TMP_Text MessageText;
    public float startWait;
    public float endWait;
    public float gameOverWait;
    public int roundNumber;
    public static GameManager instance;
    public Entity player;
    public Entity enemyPrefab;
    public Transform spawnPoint;
    private bool cardChosen;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        StartCoroutine(GameLoop());
    }


    IEnumerator GameLoop()
    {
        yield return StartCoroutine(BattleStarting());
        yield return StartCoroutine(BattleInProgress());
        yield return StartCoroutine(BattleEnding());
        yield return StartCoroutine(CardChoosing());
        StartCoroutine(GameLoop());
    }

    IEnumerator BattleStarting()
    {
        cardChosen = false;
        ResetPlayer();
        DisableAttacking();
        SpawnEnemy();
        roundNumber++;
        MessageText.text = "Round " + roundNumber;
        yield return new WaitForSeconds(startWait);
    }

    IEnumerator BattleInProgress()
    {
        EnableAttacking();
        MessageText.text = "";
        while (!EntityManager.Instance.OneLeaderLeft())
        {
            yield return null;
        }

    }

    IEnumerator BattleEnding()
    {
        DisableAttacking();
        MessageText.text = "Round ended";
        yield return new WaitForSeconds(endWait);
        if (!player.health.isAlive)
        {
            StartCoroutine(GameOver());
        }

    }

    private IEnumerator GameOver()
    {
        MessageText.text = "Game Over!";
        yield return new WaitForSeconds(gameOverWait);
        Messenger.Instance.Log("You lost!");
    }

    IEnumerator CardChoosing()
    {
        CardChoiceManager.instance.StartChoosing();
        while (!cardChosen)
        {
            yield return null;
        }
    }
    private void DisableAttacking()
    {
        EntityManager.Instance.DisableAllEntities();
    }
    private void EnableAttacking()
    {
        EntityManager.Instance.EnableAllEntities();
    }

    private void ResetPlayer()
    {
        player.ResetEntity();
    }

    private void SpawnEnemy()
    {
        EntityManager.Instance.SpawnEntity(enemyPrefab, spawnPoint.position);
    }
    public void FinishCardChoosing()
    {
        cardChosen = true;
    }




}