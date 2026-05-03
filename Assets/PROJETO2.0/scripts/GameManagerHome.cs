using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerHome : MonoBehaviour
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
        // Logic to handle entering the portal
        Debug.Log("Player has entered the portal.");
        SceneManager.LoadScene("Demo");
    }
}
