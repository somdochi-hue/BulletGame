using UnityEngine;

public class BullerSpwaner : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Transform target;

    public float interval = 1f; //소환 시간 간격
    private float timer = 0;
    private void Start()
    {
        GameObject findGo =GameObject.FindWithTag("Player");
        target = findGo.transform;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > interval)
        {
            timer = 0f;
            Spawn();
        }
    }
    private void Spawn()
    {
        Vector3 position = transform.position;
        Vector3 direction = target.position - position;
        direction.Normalize();
        Quaternion rotation = Quaternion.LookRotation(direction);
        Instantiate(bulletPrefab, position, rotation);
    }
}
