using UnityEngine;

public class StarController : MonoBehaviour
{
    Rigidbody2D star;

    [SerializeField] private float moveSpeed = 4f;

    private GameObject player;

    private void Awake()
    {
        star = GetComponent<Rigidbody2D>();

        player = FindObjectOfType<PlayerController>().gameObject;
    }

    private void Start()
    {
        star.velocity = player.transform.up * moveSpeed;

        Destroy(gameObject, 4f);
    }
}