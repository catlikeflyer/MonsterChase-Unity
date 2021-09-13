using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterReference;

    private GameObject spawnedMonster;

    [SerializeField]
    private Transform  leftPos, rightPos;

    private int randomIndex;
    private int randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(1,5));
            
            randomIndex = Random.Range(0, monsterReference.Length); // Selects random index to spawn random monster
            randomSide = Random.Range(0, 2); // Randomly selects a side

            spawnedMonster = Instantiate(monsterReference[randomIndex]);

            // Left side
            if (randomSide == 0) {
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(4, 10);
            } 
            // Right side
            else {
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Monster>().speed = -Random.Range(4, 10);
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
