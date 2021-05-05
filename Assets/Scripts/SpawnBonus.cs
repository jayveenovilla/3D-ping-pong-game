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
    public PaddleShrinkPenalty myPaddleShrinkPenalty;
    ParticleEffects myParticleEffects;

    // Start is called before the first frame update
    public void Start()
    {
        myPaddleShrinkPenalty = GameObject.Find("PlayerPaddle").GetComponent<PaddleShrinkPenalty>();
        //save time
        time = spawnTime;
        StartCoroutine(spawnTimer());
        onTableCount = 0;
        myParticleEffects = GameObject.Find("ParticleEffects").GetComponent<ParticleEffects>(); ;  //attached ParticleEffects script to particleeffect object
        GameManager._instance.player.penaltyCount = 0;
    }
    // Update is called once per frame
    public void Update()
    {
        //Instantiate clones based on spawn time with 3 max on table
        time -= Time.deltaTime;
        if(time <= 0)
        {
            Vector3 bonusPos = new Vector3(Random.Range(-11f,11f), 1.5f, Random.Range(-21f,21f));
            prefabCount = Random.Range(0,49);
            if (prefabCount >= 0 && prefabCount <= 4 && GameManager._instance.player.penaltyCount >= 1)
            {
                prefabCount = Random.Range(5, 49);      //spawn a star if 1 black star is in the field of play
            }
                if (prefabCount >= 0 && prefabCount <= 4 && GameManager._instance.player.penaltyCount < 1)        //blackstar spawns are penalties. max black stars
            {
                GameManager._instance.player.penaltyCount++;
                bonusClone = Instantiate(bonusPrefabs[prefabCount], bonusPos, transform.rotation) as GameObject;
                StartCoroutine(blackStarCountdown(bonusClone));
            }

            if(prefabCount > 4 && onTableCount != 3)        //spawns bonus items
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

    private IEnumerator blackStarCountdown(GameObject go)
    {
        int countDown = 20;         //black spawn countdown time till destruction
        while (countDown > 0)
        {
            yield return new WaitForSeconds(1);
            --countDown;
        }
        if (go != null)
        {
            StartCoroutine(myParticleEffects.blackFirework(go.transform));      //black firework particles for black star destruction
            Destroy(go);
            GameManager._instance.player.penaltyCount--;            //decrease singleton penalty count
        }
    }
}
