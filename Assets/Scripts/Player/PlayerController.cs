using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Camera _camera;

    [SerializeField] private Transform shootPlace;

    [SerializeField] private GameObject star;

    [SerializeField] private float shootDelay = .2f;
    private float nextShoot;

    private int health = 3;

    public int Health { get => health; set => health = value; }

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        RotatePlayer();

        Shoot();
    }

    void RotatePlayer()
    {
        if (Input.touchCount > 0)
        {
            //var angle = Vector3.SignedAngle(Input.GetTouch(0).position, Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition, transform.forward);
            //transform.RotateAround(transform.position, -transform.forward, angle);

            var touch = Input.GetTouch(0);
            Vector2 direction = _camera.ScreenToWorldPoint(touch.position) - transform.position;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
            transform.rotation = rotation;
        }
    }

    void Shoot()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Vector2 ray = new Vector2(_camera.ScreenToWorldPoint(new Vector3(Input.touches[i].position.x, Input.touches[i].position.y, 0f)).x,
                                          _camera.ScreenToWorldPoint(new Vector3(Input.touches[i].position.x, Input.touches[i].position.y, 0f)).y);

                RaycastHit2D hit2D = Physics2D.Raycast(ray, Vector2.zero);
                if (hit2D)
                {
                    if (Time.time > nextShoot)
                    {
                        var randomRot = Random.rotation;
                        var x = Random.Range(-45f, 45f);
                        var y = Random.Range(-50f, 50f);
                        var z = Random.Range(-50, 50f);
                        var starObj = Instantiate(star, shootPlace.position, Quaternion.Euler(x, y, z));
                        nextShoot = Time.time + shootDelay;
                    }
                }
            }
        }
    }
}