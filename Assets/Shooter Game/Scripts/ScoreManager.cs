using System;
using UnityEngine;
public class ScoreManager : MonoBehaviour
{
    // A variável estática que conterá a única instância da classe.
    public static ScoreManager Instance {get; private set;}

    // public static event Action OnEnemyDeath;

    public void MyMethod()
    {
        Debug.Log("Método do Singleton executado.");
    }

    // Certifique-se de tornar o construtor privado para evitar a criação de instâncias por fora.
    private ScoreManager() { }

    // Opcional: Defina um método Awake() para personalizar o comportamento do Singleton na inicialização.
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
        Debug.Log("IncreaseScoreOnEnemyKill called");
        // +1 score
    }
}

