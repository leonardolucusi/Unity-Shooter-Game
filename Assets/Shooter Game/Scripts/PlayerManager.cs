using System.Collections;
using UnityEngine;
public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    public GameObject player;
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public float shootDelay = 0.1f;
    private float moveHorizontal;
    private float moveVertical;
    public float moveSpeed = 10f;
    private Rigidbody2D rb2D;
    private LineRenderer lineRenderer;
    private bool shooted = false;
    public float maxDistance;
    public bool activateDebugDrawLine = true;
    private static PlayerManager instance;
    public static PlayerManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlayerManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject("PlayerManager");
                    instance = go.AddComponent<PlayerManager>();
                }
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
    }
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        direction.z = 0f;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        if (Input.GetMouseButton(0) && !shooted)
        {   
            shooted = true;
            StartCoroutine(DelayShots(direction));
        }

        if (Input.GetMouseButton(1))
        {
            Vector3 mouseDirection =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseDirection.z = 0f;
            Vector3 mouseDir = mouseDirection - transform.position;
            LayerMask playerLayerMask = LayerMask.GetMask("Player");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, mouseDir.normalized * maxDistance, maxDistance, ~playerLayerMask);

            if(activateDebugDrawLine){
                Debug.DrawLine(transform.position, hit.point, Color.red, 0.5f);
            }

            if (hit.collider != null)
            {
                lineRenderer.positionCount = 2;
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, hit.point);
            }
            else
            {
                lineRenderer.positionCount = 2;
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, transform.position + mouseDir.normalized * maxDistance);
            }
        }else{
            lineRenderer.positionCount = 0;
        }
    }
    IEnumerator DelayShots(Vector2 direction){
        FireProjectile(direction);
        yield return new WaitForSeconds(shootDelay);
        shooted = false;
    }
    void FixedUpdate()
    {
        Vector2 direction = new Vector2(moveHorizontal, moveVertical).normalized;
        Vector2 newPosition = (Vector2)transform.position + direction * moveSpeed * Time.deltaTime;
        rb2D.MovePosition(newPosition); 
    }
    void FireProjectile(Vector2 direction)
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
        // Rotaciona o projetil para direcao do mous
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        projectile.transform.rotation = Quaternion.Euler(0, 0, angle);
        
        if (projectileRigidbody != null)
        {
            projectileRigidbody.velocity = direction.normalized * projectileSpeed;
        }
        else
        {
            Debug.LogError("O projetil não possui um Rigidbody2D.");
        }
    }
}