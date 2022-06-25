using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTimer : MonoBehaviour
{
    [SerializeField] private PlayerStats player;
    [SerializeField] private float spawnRate;
    [SerializeField] private GameObject[] Enemies;
    [SerializeField] private Transform[] SpawnPositions;

    private List<Transform> SpawnPosList = new List<Transform>();
    private Transform selected_spawn_position;
    private bool spawnPause = false;

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

    private IEnumerator Spawner()
    {
        spawnPause = true;
        selected_spawn_position = SpawnPosList[Random.Range(0, SpawnPosList.Count)];
        foreach (GameObject Enemy in Enemies)
        {
            Instantiate(Enemy, selected_spawn_position);
            var AIScript = Enemy.GetComponent<AIDestinationSetter>();
            var BeatScript = Enemy.GetComponentInChildren<Beat>();
            AIScript.target = player.PlayerTransformPosition();
            BeatScript.player = player;
        }
        yield return new WaitForSeconds(spawnRate);
        spawnPause = false;
    }
}
