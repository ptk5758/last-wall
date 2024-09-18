using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMonsterSpawnManager
{   
    public void Spawn(Monster prefab, float delay);
    public void Spawn(Monster prefab) => Spawn(prefab, 0f);
    public void SpawnRound(RoundData data);
}
public class MonsterSpawnManager : Manager<MonsterSpawnManager>, IMonsterSpawnManager
{
    public static HashSet<Monster> spawned = new HashSet<Monster>();

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
    private void MonsterSpawned_EventHandler(Monster monster)
    {
        spawned.Add(monster);
    }

    public void Spawn(Monster prefab, float delay)
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

    private IEnumerator SpawnCoroutine(Monster prefab, float delay)
    {   
        GameObject gameObject = Instantiate(prefab.gameObject, spawnPoint.position, spawnPoint.rotation);
        Event.OnMonsterSpawnedTrigger(gameObject.GetComponent<Monster>());
        yield return new WaitForSeconds(delay);
    }

    public static class Event
    {
        public static event System.Action<Monster> MonsterSpawned;
        public static void OnMonsterSpawnedTrigger(Monster gameObject)
        {
            MonsterSpawned?.Invoke(gameObject);
        }
    }
}
