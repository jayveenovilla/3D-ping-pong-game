using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBonus : MonoBehaviour
{
    public GameObject[] bonusPrefabs; //prefabs to insert
    private float time;
    public float spawnTime = 2.0f;
    int prefabCount;
    public int onTableCount;
    GameObject bonusClone;         //prefab clones

    // Start is called before the first frame update
    public void Start()
    {
        //save time
        time = spawnTime;
        StartCoroutine(spawnTimer());
        onTableCount = 0;
    }
    // Update is called once per frame
    public void Update()
    {
        //Instantiate clones based on spawn time with 3 max on table
        time -= Time.deltaTime;
        if(time <= 0)
        {
            Vector3 bonusPos = new Vector3(Random.Range(-11f,11f), 1.5f, Random.Range(-21f,21f));
            prefabCount = Random.Range(0,23);
            if(onTableCount != 3)
            {
                onTableCount++;
                bonusClone = Instantiate(bonusPrefabs[prefabCount], bonusPos, transform.rotation) as GameObject; 
            }
            time = spawnTime;         
        }    
    }

    public IEnumerator spawnTimer() 
    {
        if (spawnTime == 2.0f)
        {
            yield return new WaitForSeconds (spawnTime);
            spawnTime += spawnTime;
        }            
    }
}
