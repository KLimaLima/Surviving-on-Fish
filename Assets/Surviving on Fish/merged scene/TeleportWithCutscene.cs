using UnityEngine;
using UnityEngine.Playables; // For cutscenes

public class TeleportWithCutscene : MonoBehaviour
{
    [SerializeField] private Transform player; // Reference to the player
    [SerializeField] private Vector3 teleportPosition; // Target position
    [SerializeField] private PlayableDirector cutsceneDirector; // Cutscene director

    public void TeleportPlayer()
    {
        // Start the cutscene
        if (cutsceneDirector != null)
        {
            cutsceneDirector.Play();
            // Wait for the cutscene to finish before teleporting
            Invoke("PerformTeleport", (float)cutsceneDirector.duration);
        }
        else
        {
            // If no cutscene, teleport immediately
            PerformTeleport();
        }
    }

    private void PerformTeleport()
    {
        // Teleport the player to the target position
        if (player != null)
        {
            player.position = teleportPosition;
            Debug.Log("Player teleported to: " + teleportPosition);
        }
    }
}
