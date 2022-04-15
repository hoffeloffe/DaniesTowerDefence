using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private GameObject newEnemy;

    [SerializeField]
    private GameObject spawnerPrefab;

    [SerializeField]
    private GameObject BigspawnerPrefab;

    [SerializeField]
    private float SwarmerInterval = 3.5f;

    [SerializeField]
    private float bigSwarmerInterval = 10f;

    public int xBox, zBox;
    private int xPos, zPos;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(spawnEnemy(SwarmerInterval, spawnerPrefab));
        StartCoroutine(spawnEnemy(bigSwarmerInterval, BigspawnerPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        xPos = Random.Range((int)this.transform.position.x - xBox, (int)this.transform.position.x + xBox);
        zPos = Random.Range((int)this.transform.position.z - zBox, (int)this.transform.position.z);
        yield return new WaitForSeconds(interval);
        newEnemy = Instantiate(enemy, new Vector3(xPos, 1, zPos), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}