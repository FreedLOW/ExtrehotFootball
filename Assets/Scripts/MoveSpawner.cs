using UnityEngine;

public class MoveSpawner : MonoBehaviour
{
    Transform border;

    [SerializeField] private int side;

    [SerializeField] private GameObject[] spawners;

    private float moving = 6f;

    private void Start()
    {
        border = this.transform;
        side = Random.Range(-1, 1);

        if (side == 0)
            side = 1;
    }

    private void Update()
    {
        border.Rotate(0, 0, moving * side * Time.deltaTime);

        if (GameController.Instance.Score == 5)
        {
            moving = 8f;
            spawners[0].SetActive(true);
        }
        else if (GameController.Instance.Score == 20)
        {
            moving = 10f;
            spawners[1].SetActive(true);
        }           
        else if (GameController.Instance.Score == 40)
        {
            moving = 14f;
            spawners[2].SetActive(true);
        }
    }
}