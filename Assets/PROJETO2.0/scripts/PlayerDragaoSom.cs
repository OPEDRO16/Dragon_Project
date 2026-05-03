using UnityEngine;

public class PlayerDragaoSom : MonoBehaviour
{

    public AudioSource fireBallSound;
    public AudioSource jumpSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            jumpSound.Play();
        }
        if (Input.GetMouseButtonUp(0))
        {
            fireBallSound.Play();
        }
    }
}
