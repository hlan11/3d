using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefarb;
    public int spawnQuantity;
    public float spawnInterval;
    public float spawnRadius;
    public Color color;
    public float traceDistance;
    private List<EnemyAI> _listEnemyAI = new List<EnemyAI>();
    private void OnDrawGizmos()
    {
        Handles.color = color;
        Handles.DrawSolidDisc(transform.position, Vector3.up, spawnRadius);
    }
    private void Start()
    {
        StartCoroutine(SpawnEnemyByTime());
    }
    IEnumerator SpawnEnemyByTime()
    {
        while (spawnQuantity > 0)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    void SpawnEnemy()
    {
        Vector3 SpawnPos = Random.insideUnitCircle * spawnRadius;
        var enemy = Instantiate(enemyPrefarb, transform.position+ SpawnPos, transform.rotation);
        var enemyAI = enemy.GetComponent<EnemyAI>();
        enemyAI.spawnPos = transform;
        _listEnemyAI.Add(enemyAI);
        spawnQuantity--;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("-------------Player In -----------------");
            for (int i = 0; i < _listEnemyAI.Count; i++)
            {
                if (Vector3.Distance(other.transform.position, _listEnemyAI[i].transform.position) <= traceDistance)
                    _listEnemyAI[i].TracePlayer();
            }
        }
    }
}
