using Unity.Mathematics;
using UnityEngine;
public class SpawnEnemiesManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    void Start()
    { }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            SpawnEnemies();
        }
    }
    void SpawnEnemies()
    {
        Vector3 playerPos = player.transform.position;
        bool a = true;
        for (int i = 0; i < 3; i++)
        {
            if (a)
            {
                Instantiate(enemy, playerPos + new Vector3(i, 6, 1), quaternion.identity);
            }
            else if (!a)
            {
                Instantiate(enemy, playerPos + new Vector3(i - 1, 6, 1), quaternion.identity);
            }
            a = !a;
        }
    }

}