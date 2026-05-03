using System;
using System.Collections;
using TMPro;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class npcAI : MonoBehaviour
{
    public Slider playerHealthBar;
    private float playerHealth;
    public TextMeshProUGUI playerHealthText;
    private bool doneDamage = false;

    public GameObject player;
    public Transform[] waypoints;
    public int currentTarget = 0;
    public NavMeshAgent navMeshAgent;

    private Animator m_animator;
    private Vector3 distance2player;

    private IEnumerator coroutineSaw;
    private RaycastHit hit;
    private float maxDistanceCheck = 30f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        m_animator = GetComponent<Animator>();
        coroutineSaw = Saw();
        StartCoroutine(coroutineSaw);
    }

    IEnumerator Saw()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            if (Physics.SphereCast(transform.position + Vector3.up,0.5f,transform.forward,out hit, maxDistanceCheck))
            {
                if (hit.transform.gameObject.CompareTag("Player"))
                {
                    m_animator.SetBool("Saw", true);
                    Debug.DrawRay(transform.position + Vector3.up, transform.forward * maxDistanceCheck, Color.green);
                } else
                {
                    m_animator.SetBool("Saw", false);
                    Debug.DrawRay(transform.position + Vector3.up, transform.forward * maxDistanceCheck, Color.red);
                }
            } else
            {
                m_animator.SetBool("Saw", false);
                Debug.DrawRay(transform.position + Vector3.up, transform.forward * maxDistanceCheck, Color.red);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        distance2player = transform.position - player.transform.position;
        m_animator.SetFloat("distance2Player", distance2player.magnitude);

        NavMeshPath path = new NavMeshPath();
        navMeshAgent.CalculatePath(player.transform.position, path);
        if (path.status != NavMeshPathStatus.PathComplete)
        {
            m_animator.SetBool("pathValid", false);
        }
        else
        {
            m_animator.SetBool("pathValid", true);
        }
        if (m_animator.GetCurrentAnimatorStateInfo(0).IsName("Atacking"))
        {
            if (!doneDamage)
            {
                DoDamage();
                doneDamage = true;
            }
        }
        else
        {
            doneDamage = false;
        }
    }

    public void MoveToNextWaypoint()
    {
        currentTarget = (currentTarget + 1) % waypoints.Length;
        navMeshAgent.SetDestination(waypoints[currentTarget].position);
    }

    public void DoDamage()
    {
        playerHealth = Mathf.Round((playerHealthBar.value - 0.1f) * 10f) / 10f;
        playerHealthBar.value = playerHealth;
        playerHealthText.text = (playerHealth*100).ToString();
        if (playerHealth <= 0f)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
