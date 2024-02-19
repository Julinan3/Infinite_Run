using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //engellerin havuzda olusturulmasi ve rastgele olarak sahneye eklenmesi icin kullanilan kod
    public GameObject[] barrierPrefabs;
    private List<GameObject> pooledBarriers = new List<GameObject>();
    private void Start()
    {
        SpawnObjects();
    }
    //engellerin havuzda olusturulmasi
    private void SpawnObjects()
    {
        for(int i = 0; i < barrierPrefabs.Length; i++)
        {
            for(int j = 0; j < 10; j++)
            {
                GameObject obj = Instantiate(barrierPrefabs[i]);
                obj.name = barrierPrefabs[i].name;  
                obj.SetActive(false);
                pooledBarriers.Add(obj);
            }
            if(i == barrierPrefabs.Length - 1)
            {
                StartCoroutine(SpawnBarriers());
            }
        }
    }
    //engellerin rastgele olarak sahneye eklenmesi
    IEnumerator SpawnBarriers()
    {
        float locationX = -2.5f;
        int barrierCount = 0;

        for (int i = 0; i < 3; i++)
        {
            int randomBarrier = Random.Range(0, pooledBarriers.Count);

            if(pooledBarriers[randomBarrier].gameObject.name == "Barrier")
            {
                barrierCount++;
            }

            if (pooledBarriers[randomBarrier].activeInHierarchy == false)
            {
                if(barrierCount == 2)
                {
                    break;
                }
                pooledBarriers[randomBarrier].transform.position = new Vector3(locationX, 0f, 85f);

                pooledBarriers[randomBarrier].SetActive(true);
                for (int z = 0; z < pooledBarriers[randomBarrier].transform.childCount; z++)
                {
                    pooledBarriers[randomBarrier].transform.GetChild(z).gameObject.SetActive(true);
                }

                locationX += 2.5f;
            }
        }
        yield return new WaitForSeconds(2f);
        StartCoroutine(SpawnBarriers());
    }
}
