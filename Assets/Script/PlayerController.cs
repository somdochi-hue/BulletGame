using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    private float speed = 10f;
    private Rigidbody rb;
    private GameManager gameManager;
    public int HP = 3;
    public bool isHit;
    public float Timer;
    public float NoHitTime = 1500f;
    private MeshRenderer MeshRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameObject findGo = GameObject.FindWithTag("GameController");
        gameManager = findGo.GetComponent<GameManager>();
        //MeshRenderer = gameObject.GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        Vector3 direction = Vector3.zero;
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        Timer += Time.deltaTime;
        if (Timer > NoHitTime)
        {
            isHit = false;
        }

        /*if (isHit)
        {
            
            if (Timer % 2 == 0)
            {
                MeshRenderer.enable = false;
            }
            else 
            {
            MeshRenderer.enable = true;
            }
        }
        else
        {
            MeshRenderer.enable = true;
        }*/

        if(direction.magnitude > 1f)
        {
            direction.Normalize();
        }

        rb.linearVelocity = direction * speed;
    }

    public void OnDie()
    {
        gameObject.SetActive(false);
        gameManager.EndGame();
    }

    public void Hit()
    {
        if (!isHit)
        {
            isHit = true;
            Timer = 0;
            HP -= 1;
            if (HP == 0)
            {
                OnDie();
            }
        }     
    }
}
