using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBonus : MonoBehaviour
{
    public SpawnBonus spawnBonus;
    //public GameObject firework1;
    public void Start()
    {
        spawnBonus = GameObject.Find("BonusSpawn").GetComponent<SpawnBonus>();
        //firework1 = GameObject.Find("RocketMed");
    }
    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Ball")
        {
            //plus points todo
            spawnBonus.onTableCount--;
            // Instantiate(firework1);
            // firework1.transform.position = transform.position;
            // firework1.SetActive(true);
            // Destroy(GameObject.Find("RocketMed"), 1.0f);
            Destroy(gameObject);
        }
    }

}
