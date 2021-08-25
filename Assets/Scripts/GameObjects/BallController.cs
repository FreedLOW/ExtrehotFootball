using UnityEngine;

public class BallController : MonoBehaviour, IDamageble
{
    PlayerController player;

    [SerializeField] private float lifeTime;

    [SerializeField] private float moveSpeed;

    [SerializeField] private AudioClip catchScore;

    [SerializeField] private AudioClip leftHeart;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();

        lifeTime = Random.Range(5f, 15f);
        moveSpeed = Random.Range(.5f, 1.5f);

        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);

        if (lifeTime <= 0f)
        {
            AudioSource.PlayClipAtPoint(catchScore, transform.position, 10f);
        }
    }

    public void SetDamage(int damage)
    {
        player.Health -= damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(leftHeart, transform.position, 10f);
            SetDamage(1);
            GameController.Instance.Score--;
            Destroy(gameObject);
        }

        if (collision.CompareTag("Star"))
        {
            lifeTime -= 0.5f;
            moveSpeed -= 0.15f;
            Destroy(collision.gameObject);

            if (lifeTime <= 0f)
            {
                AudioSource.PlayClipAtPoint(catchScore, transform.position, 10f);
                Destroy(gameObject);
            }
        }
    }

    private void OnDestroy()
    {
        GameController.Instance.Score++;
    }
}