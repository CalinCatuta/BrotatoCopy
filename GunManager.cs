
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    [SerializeField] GameObject gunPrefab;

    Transform player;

    List<Vector2> gunPostiion = new List<Vector2>();

    int spawnedGuns = 0;

    private void Start() {
        player = GameObject.Find("Player").transform;

        gunPostiion.Add(new Vector2(-1.2f, 1f));
        gunPostiion.Add(new Vector2(1.2f, 1f));

        gunPostiion.Add(new Vector2(-1.4f, 0.2f));
        gunPostiion.Add(new Vector2(1.4f, 0.2f));

        gunPostiion.Add(new Vector2(-1f, - 0.5f));
        gunPostiion.Add(new Vector2(1f, -0.5f));

        AddGun();
        AddGun();
    }

    private void Update() {
        // For Testing
        if (Input.GetKeyDown(KeyCode.G))
        {
            AddGun();
        }
    }

    void AddGun() {

        var pos = gunPostiion[spawnedGuns];

        var newGun = Instantiate(gunPrefab, pos, Quaternion.identity);

        newGun.GetComponent<Gun>().SetOffset(pos);
        spawnedGuns++;
    }
}
