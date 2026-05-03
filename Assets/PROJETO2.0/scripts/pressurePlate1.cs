using UnityEngine;

public class PressurePlate1 : MonoBehaviour
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
            gameManeger.GetComponent<End>().isPlayerPortal = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            nextPhaseLine.SetActive(false);
            gameManeger.GetComponent<End>().isPlayerPortal = false;
        }
    }
}
