using UnityEngine;

public class SpawnBallController : MonoBehaviour
{
    [SerializeField] private GameObject ball;

    private const float maxDelay = 3f;

    [SerializeField] private float spawnDelay = 8f;
    
    private float nextLaunch = 0.5f;

    private void Update()
    {
        SpawnDelayControll();

        SpawnBall(spawnDelay);
    }

    void SpawnBall(float spawnDelay)
    {
        if (Time.time > nextLaunch)
        {
            Instantiate(ball, transform.position, Quaternion.identity);
            nextLaunch = Time.time + spawnDelay;
        }
    }

    void SpawnDelayControll()
    {
        if (spawnDelay >= maxDelay)
        {
            spawnDelay -= 0.001f * Time.deltaTime;
        }
    }
}