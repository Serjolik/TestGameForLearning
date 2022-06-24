using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTimer : MonoBehaviour
{
    [SerializeField] private float spawnRate;
    [SerializeField] private GameObject[] Enemies;
    [SerializeField] private PlayerStats player;

    private Transform[] FREnemyTransform;
    private List<Transform> FREnemyTransforms = new List<Transform>();
    private bool spawnPause = false;

    private void Start()
    {
        foreach (GameObject Enemy in Enemies)
        {
            FREnemyTransforms.Add(Enemy.transform);
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
        foreach (GameObject Enemy in Enemies)
        {
            Instantiate(Enemy);
            var AIScript = Enemy.GetComponent<AIDestinationSetter>();
            var BeatScript = Enemy.GetComponentInChildren<Beat>();
            AIScript.target = player.PlayerTransformPosition();
            BeatScript.player = player;

        }
        yield return new WaitForSeconds(spawnRate);
        spawnPause = false;
    }
}
