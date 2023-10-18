using System.Collections;
using UnityEngine;
public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance{ get; private set; } // SINGLETON
    [SerializeField] private GameObject projectileObject;
    private Projectile projectileInstance;
    private float moveHorizontal;
    private float moveVertical;
    public float  moveSpeed = 10f;
    private Rigidbody2D rb2D;
    private LineRenderer lineRenderer;
    private bool shooted = false;
    public float maxDistance;
    // public bool activateDebugDrawLine = true;
    public Projectile GetCurrentProjectile { get { return projectileInstance;}}
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
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;

        projectileInstance = projectileObject.GetComponent<Projectile>();
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
            StartCoroutine(FireRate(direction));
        }

        if (Input.GetMouseButton(1))
        {
            Vector3 mouseDirection =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseDirection.z = 0f;
            Vector3 mouseDir = mouseDirection - transform.position;
            mouseDir.z = 0f;
            LayerMask playerLayerMask = LayerMask.GetMask("Player");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, mouseDir.normalized * maxDistance, maxDistance, ~playerLayerMask);

            // DEBUG RAY
            // if(activateDebugDrawLine){
            //     Debug.DrawLine(transform.position, hit.point, Color.red, 0.5f);
            // }

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
    IEnumerator FireRate(Vector2 direction){
        FireProjectile(direction);
        yield return new WaitForSeconds(projectileInstance.projectileSO.fireRate);
        shooted = false;
    }
    void FixedUpdate()
    {
        Vector2 direction = new Vector2(moveHorizontal, moveVertical).normalized;
        Vector2 newPosition = (Vector2)transform.position + direction * moveSpeed * Time.deltaTime;
        rb2D.MovePosition(newPosition);
    }
    public void FireProjectile(Vector2 direction)
    {
        GameObject projectileClone = Instantiate(projectileObject.gameObject, transform.position, Quaternion.identity);
        projectileClone.GetComponent<Projectile>().direction = direction;
    }
}
