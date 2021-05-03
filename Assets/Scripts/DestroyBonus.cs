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
            if(gameObject.tag == "Bonus")
            {
                spawnBonus.onTableCount--;
                Destroy(gameObject);
                ScoreManager.instance.AddBonus();  //add a BonusPoints
            }

            if (gameObject.tag == "Penalty")            //changed black star tags as "Penalty"
            {
                if(gameObject != null) {        //check if gameobject is null
                    Destroy(gameObject);
                    GameManager._instance.player.penaltyCount--;
                }
            }

        }
    }
}
