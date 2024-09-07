using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss2Pentten : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float spawnCycle; //�� ���� �ֱ�

    private void OnEnable()
    {
        StartCoroutine(nameof(SpawnEnemys));
    }
    private void OnDisable()
    {
        StopCoroutine(nameof(SpawnEnemys));
    }

    private IEnumerator SpawnEnemys()
    {
        //���� ���� �� ��� ����ϴ� �ð�
        float waitTime = 1;
        yield return new WaitForSeconds(waitTime);

        Vector3 position = new Vector3(Random.Range(Constants.min.x, Constants.max.x), Constants.max.y, 0);
        Instantiate(enemyPrefab, position, Quaternion.identity);
        yield return new WaitForSeconds(spawnCycle);

    }   
}
