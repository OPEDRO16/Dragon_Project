using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{

    [HideInInspector] public bool isPlayerPortal = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerPortal)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                EnterPortal();
            }
        }
    }

    private void EnterPortal()
    {
        Debug.Log("Player has entered the portal.");
        SceneManager.LoadScene("Casa 1");
    }
}
