using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneManager : MonoBehaviour
{
    public static ZoneManager Instance { get; private set; }
    public const float ZONE2_THRESHOLD = 50.0f;
    [SerializeField] private float _leftBoundaryX;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

    }

    void Update()
    {
        if (PlayerManager.Instance.transform.position.x <= -_leftBoundaryX)
        {
            ObjectPool.Instance.OnZoneChanged();
            Debug.Log("Proxima Zona");

        }
    }
}
