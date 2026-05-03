using UnityEngine;

public class PlayerDragaoUI : MonoBehaviour
{

    public GameObject nextPhaseLine;
    public GameObject gameManeger;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            nextPhaseLine.SetActive(true);
            gameManeger.GetComponent<GameManagerHome>().isPlayerPortal = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            nextPhaseLine.SetActive(false);
            gameManeger.GetComponent<GameManagerHome>().isPlayerPortal = false;
        }
    }
}
