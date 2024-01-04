using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisSpawner : MonoBehaviour
{
    [Header("Zone Sizes")]
    public float zShipSize;
    public float zOneSize;
    public float zTwoSize;
    public float zThreeSize;
    public float zFourSize;

    [Header("Zone Timers")]
    public float zOneTimer;
    public float zTwoTimer;
    public float zThreeTimer;
    public float zFourTimer;

    [Header("Debris Cycles")]
    public List<GameObject> zOneList = new List<GameObject>();
    public List<GameObject> zTwoList = new List<GameObject>();
    public List<GameObject> zThreeList = new List<GameObject>();
    public List<GameObject> zFourList = new List<GameObject>();

    public GameObject test;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(zSpawn(zOneList, zOneTimer, zShipSize, zOneSize));
        StartCoroutine(zSpawn(zTwoList, zTwoTimer, zOneSize, zTwoSize));
        StartCoroutine(zSpawn(zThreeList, zThreeTimer, zTwoSize, zThreeSize));
        StartCoroutine(zSpawn(zFourList, zFourTimer, zThreeSize, zFourSize));
    }

    private void spawnDebris(float minDistance, float maxDistance, GameObject currentDebris)
    {
        float distance = Random.Range(minDistance, maxDistance);
        float angle = Random.Range(-Mathf.PI, Mathf.PI);

        GameObject debris = Instantiate(currentDebris) as GameObject;

        debris.transform.position = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * distance;
    }

    IEnumerator zSpawn(List<GameObject> list, float timer, float minSize, float maxSize)
    {
        while (true)
        {
            foreach (GameObject currentDebris in list)
            {
                yield return new WaitForSeconds(timer);
                spawnDebris(minSize, maxSize, currentDebris);
                Debug.Log("spawning1");
            }
        }
    }
}


    