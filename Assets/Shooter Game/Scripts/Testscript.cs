using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Testscript : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void SpawnEnemies(){
        Vector3 playerPos = player.transform.position;
        bool a = true;
        for (int i = -10; i < 20; i++)
        {
            if(a){
                Instantiate(enemy,playerPos + new Vector3(i,6,1), quaternion.identity);
            }else if(!a){
                Instantiate(enemy,playerPos + new Vector3(i-1,6,1), quaternion.identity);
            }
            a = !a;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.R)){
            SpawnEnemies();
        }
    }
}
