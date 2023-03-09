using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Vector3[] teleportPositions; // An array of positions to teleport to
    public float teleportInterval = 1.0f; // Time between teleports (in seconds)

    private int previousTeleportIndex = -1; // The index of the previous teleport position
    private int currentTeleportIndex = -1; // The index of the current teleport position
    private float timeSinceLastTeleport = 0.0f; // Time since the last teleport

    void Start()
    {
        // Initialize the teleportPositions array with the specified positions
        teleportPositions = new Vector3[3];
        teleportPositions[0] = new Vector3(-8.58f, 1.26f, -7.8f);
        teleportPositions[1] = new Vector3(7f, 1.26f, -7.8f);
        teleportPositions[2] = new Vector3(-7f, 1.26f, -2.87f);
    }

    void Update()
    {
        timeSinceLastTeleport += Time.deltaTime;

        if (timeSinceLastTeleport >= teleportInterval)
        {
            timeSinceLastTeleport = 0.0f;

            // Generate a random teleport index that is not the previous index
            do
            {
                currentTeleportIndex = Random.Range(0, teleportPositions.Length);
            } while (currentTeleportIndex == previousTeleportIndex);

            // Teleport to the next position
            transform.position = teleportPositions[currentTeleportIndex];

            // Update the previous index
            previousTeleportIndex = currentTeleportIndex;
        }
    }
}
