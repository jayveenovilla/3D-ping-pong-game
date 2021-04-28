using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBonus : MonoBehaviour
{
    public SpawnBonus spawnBonus;

    public void Start()
    {
        spawnBonus = GameObject.Find("BonusSpawn").GetComponent<SpawnBonus>();
    }
    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Ball")
        {
            //plus points todo
            spawnBonus.onTableCount--;
            Destroy(gameObject);
        }
    }
}
