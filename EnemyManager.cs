
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    float currentTimeBetweenSpawns;
    bool shouldSpawnEnemies;

    Transform enemiesParent;

    public static EnemyManager Instance;

    private void Awake() {
        // To call it from other scripts
        if (Instance == null) Instance = this;
    }

    private void Start() {
        enemiesParent = GameObject.Find("Enemies").transform;
        Invoke("StartSpawning", 3f);
    }

    private void Update() {
        if (!WaveManager.Instance.WaveRunning()) return;

        currentTimeBetweenSpawns -= Time.deltaTime;
        if (!shouldSpawnEnemies) return;
        if (currentTimeBetweenSpawns <= 0)
        {
            SpawnEnemy();
            currentTimeBetweenSpawns = timeBetweenSpawns;
        }
    }
    Vector2 RandomPosition() {
        return new Vector2(Random.Range(-16,16), Random.Range(-8,8));
    }
    void StartSpawning() { shouldSpawnEnemies = true; }

    void SpawnEnemy() {
        var e = Instantiate(enemyPrefab, RandomPosition(), Quaternion.identity);
        e.transform.SetParent(enemiesParent);
    }
    public void DestroyAllEnemies() { 
    foreach(Transform e in enemiesParent)
            Destroy(e.gameObject);
    }
}
