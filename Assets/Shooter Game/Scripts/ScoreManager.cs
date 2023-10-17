using UnityEngine;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance {get; private set;}
    
    public static int metalScrap;
    private ScoreManager() { }
    private void Awake()
    {
        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }
    public void IncreaseScoreOnEnemyKill(){
        metalScrap += 1;
        Debug.Log(metalScrap);
    }
}

