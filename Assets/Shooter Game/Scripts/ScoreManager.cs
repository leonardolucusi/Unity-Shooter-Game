using UnityEngine;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance {get; private set;}
    private ScoreManager() { }
    private void Awake()
    {
        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else Destroy(Instance);
        
    }
}

