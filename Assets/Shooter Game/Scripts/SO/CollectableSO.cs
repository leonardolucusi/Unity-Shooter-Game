using UnityEngine;
[CreateAssetMenu(fileName = "Collectables", menuName = "ScriptableObject/Collectables")]
public class CollectableSO : ScriptableObject
{
    public float metalScrap;

    public void IncreaseMetalScrap(){
        metalScrap += 1;
    }
}


