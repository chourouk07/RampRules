using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rail : MonoBehaviour
{
    public Transform railStart;
    public Transform railEnd;
    [SerializeField] private bool onRail = false;
    private Transform player;
    private float railLength;
    private float progress;
    [SerializeField] private float posY;

    void Start()
    {
        // Calculate the length of the rail
        railLength = Vector3.Distance(railStart.position, railEnd.position);
    }

    void Update()
    {
        if (onRail)
        {
            player.GetComponent<PlayerController>().enabled = false;
            // Calculate the progress along the rail
            Vector3 playerPos = player.position - railStart.position;
            float dot = Vector3.Dot(playerPos, railEnd.position - railStart.position);
            progress = Mathf.Clamp01(dot / (railLength * railLength));

            // Position the player on the rail
            player.position = Vector3.Lerp(railStart.position, railEnd.position, progress) + (Vector3.up * 0.5f) + (Vector3.forward * 0.5f);

            // Check if the player has reached the end of the rail
            if (progress >= 1.0f)
            {
                player.position = new Vector3(player.position.x,posY, player.position.z);
                onRail = false;
                
                StartCoroutine(EnableMove());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onRail = true;
            player = other.transform;
        }
    }
    IEnumerator EnableMove()
    {
        yield return new WaitForSeconds(0.1f);
        player.GetComponent<PlayerController>().enabled = true;
    }
}
