
using System.Collections;
using TMPro;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI waveText;

    public static WaveManager Instance;

    bool waveRunning = true;
    int currentWave = 0;
    int currentWaveTime;

    private void Awake() {
        if (Instance == null) Instance = this;
        StartNewWave();
    }
    private void Start() {
        timeText.text = "30";
        waveText.text = "Wave: 1";
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) { StartNewWave(); }
    }
    public bool WaveRunning() => waveRunning;
    private void StartNewWave() {
        StopAllCoroutines();
        timeText.color = Color.white;
        currentWave++;
        waveRunning = true;
        currentWaveTime = 30;
        waveText.text = "Wave: " + currentWave;
        timeText.text = currentWaveTime.ToString();
        StartCoroutine(WaveTimer());


    }
    IEnumerator WaveTimer() {

        while (waveRunning)
        {
            yield return new WaitForSeconds(1f);
            // Decrement currentWaveTime instead of currentWave
            currentWaveTime--;
            timeText.text = currentWaveTime.ToString();

            if (currentWaveTime <= 0)
            {
                WaveComplete();
            }
        }
        yield return null;
    }
    private void WaveComplete() {
        StopAllCoroutines();
        EnemyManager.Instance.DestroyAllEnemies();
        waveRunning = false;
        currentWaveTime = 30;
        timeText.text = currentWaveTime.ToString();
        timeText.color = Color.red;
    }
}
