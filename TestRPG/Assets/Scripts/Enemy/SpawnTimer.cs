using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTimer : MonoBehaviour
{
    [SerializeField] private PlayerStats player;
    [SerializeField] private PlayerDamage playerDamage;
    [SerializeField] private GameObject[] EnemyTypes;
    [SerializeField] private Transform[] SpawnPositions;
    [Header("Spawn rate")]
    [SerializeField] private float spawnRate;

    private List<GameObject> Enemies = new List<GameObject>();
    private List<Transform> SpawnPosList = new List<Transform>();
    private Transform playerTransform;
    private Transform selected_spawn_position;
    private bool spawnPause = false;

    private void Awake()
    {
        playerTransform = player.transform;
    }

    private void Start()
    {
        foreach (Transform transforms in SpawnPositions)
        {
            SpawnPosList.Add(transforms);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!spawnPause && collision.gameObject.tag == "Player")
        {
            StartCoroutine(Spawner());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        foreach(GameObject Enemy in Enemies)
        {
            Destroy(Enemy);
        }
        Enemies.Clear();
    }

    private IEnumerator Spawner()
    {
        spawnPause = true;
        selected_spawn_position = SpawnPosList[Random.Range(0, SpawnPosList.Count)];
        foreach (GameObject Enemy in EnemyTypes)
        {
            var AIScript = Enemy.GetComponent<AIDestinationSetter>();
            var BeatScript = Enemy.GetComponentInChildren<Beat>();
            AIScript.target = playerTransform;
            BeatScript.player = player;
            BeatScript.playerDamage = playerDamage;
            Enemies.Add(Instantiate(Enemy, selected_spawn_position));
        }
        yield return new WaitForSeconds(spawnRate);
        spawnPause = false;
    }
}
