using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class moveDragon : MonoBehaviour
{

    private Rigidbody rb;
    private Animator animator;

    private float horizontal;
    private float vertical;

    // Bullet properties
    public float bulletForce = 3000.0f;
    public Transform shootPos;
    public Rigidbody bulletPrefab;
    private Rigidbody bulletInstance;
    public float range = 10.0f;

    public GameObject camera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Mouse X");
        vertical = Input.GetAxis("Vertical");

        if (!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S)))
        {
            if (horizontal > 0.99)
            {
                horizontal = 1f;
            }
            else if (horizontal < -0.99)
            {
                horizontal = -1f;
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetTrigger("Jump");
        }


        if (Input.GetKey(KeyCode.LeftShift))
        {
            vertical *= 2;
        }

        if (Input.GetMouseButtonUp(0))
        {
            animator.SetTrigger("Shoot");
            Fire();
        }

        animator.SetFloat("BlendX", horizontal, 0.02f, Time.deltaTime);
        animator.SetFloat("BlendY", vertical, 0.02f, Time.deltaTime);

        Debug.DrawRay(shootPos.transform.position, transform.TransformDirection(Vector3.forward) * range, Color.red);
    }

    private void Fire()
    {
        Debug.Log("Fire");
        bulletInstance = Instantiate(bulletPrefab, shootPos.position, shootPos.rotation);
        bulletInstance.AddForce(camera.transform.TransformDirection(Vector3.forward) * bulletForce);
        Destroy(bulletInstance.gameObject, 5.0f);
    }
}
