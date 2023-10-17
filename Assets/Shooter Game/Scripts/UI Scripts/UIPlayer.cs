using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayer : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = PlayerManager.Instance.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
