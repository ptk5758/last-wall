using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMonsterSpawnManager
{   
    public void Spawn(GameObject prefab, float delay);
    public void Spawn(GameObject prefab) => Spawn(prefab, 0f);
    public void SpawnRound(RoundData data);
}
public class MonsterSpawnManager : Manager<MonsterSpawnManager>, IMonsterSpawnManager
{
    public static HashSet<GameObject> spawned = new HashSet<GameObject>();

    [SerializeField]
    private Transform spawnPoint;

    private void Start()
    {
        Event.MonsterSpawned += MonsterSpawned_EventHandler;
    }

    private void OnDisable()
    {
        Event.MonsterSpawned -= MonsterSpawned_EventHandler;
    }
    private void MonsterSpawned_EventHandler(GameObject gameObject)
    {
        spawned.Add(gameObject);
    }

    public void Spawn(GameObject prefab, float delay)
    {
        StartCoroutine(SpawnCoroutine(prefab, delay));
    }

    public void SpawnRound(RoundData data)
    {
        StartCoroutine(SpawnRoundCoroutine(new Queue<Wave>(data.waves)));
    }

    private IEnumerator SpawnRoundCoroutine(Queue<Wave> waves)
    {
        while (waves.Count > 0)
        {
            Wave wave = waves.Dequeue();
            Spawn(wave.prefab, wave.delay);
            yield return new WaitForSeconds(wave.delay);  // 다음 웨이브까지 대기
        }
    }

    private IEnumerator SpawnCoroutine(GameObject prefab, float delay)
    {   
        GameObject gameObject = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
        Event.OnMonsterSpawnedTrigger(gameObject);
        yield return new WaitForSeconds(delay);
    }

    public static class Event
    {
        public static event System.Action<GameObject> MonsterSpawned;
        public static void OnMonsterSpawnedTrigger(GameObject gameObject)
        {
            MonsterSpawned?.Invoke(gameObject);
        }
    }
}
