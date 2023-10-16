using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
public class ScreenManager : MonoBehaviour
{
    VisualElement mainDiv;
    VisualElement root;

    void Start()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        mainDiv = root.Q<VisualElement>("divMain");
    }
    void Update()
    {
        // StartCoroutine(PrintScreenDimensions());
    }
    void LateUpdate(){
        // Screen.SetResolution(1280, 720, true);
    }
    IEnumerator PrintScreenDimensions(){      
        yield return new WaitForSeconds(1f);

        // 1920 x 1080
        if(Screen.width == 1920 && Screen.height == 1080){
            print("Screen.width == 1920 / Screen.height == 1080");
        }

        // 1280 x 720
        if(Screen.width == 1280 && Screen.height == 720){
           
            print("Screen.width == 1280 / Screen.height == 720");
        }

        print("Width: " + Screen.width + " Height: " + Screen.height);
    }
}
