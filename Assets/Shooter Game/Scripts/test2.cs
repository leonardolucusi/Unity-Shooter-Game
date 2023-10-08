using UnityEngine;
public class test2 : MonoBehaviour
{
    public float maxDistance;
    private LineRenderer lr;
    void Start(){
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 2;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;
            Vector3 mouseDir = mousePos - transform.position;
            Debug.DrawLine(transform.position, mousePos, Color.red, 0.5f);
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1,  transform.position + mouseDir.normalized * maxDistance);
        }
    }
}