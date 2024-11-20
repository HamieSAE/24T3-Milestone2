using UnityEngine; /* HamieNouri - 04.11.2024 */
/* We are going to access the GameManager Script from the player script.
 * Then we are going to get the sorted array of targets from GM
 * and put it into our own array called targets
 * Using int to define the positions of each index of array, 
 * Using the position of array is much easier and safer than 
 * refering to  the actual content of the array as we may not know whats in it!
 * ---------------------------------------------
 * I also had some fun with it, 
 * made it so it checks if there are any walls blocking the view 
 * If player doesn't have a clear sight of Vision, it ignores the target!
 * I will Comment "Wall" for the bits that relate to this section.
 */

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;                // Refering the GameManager Script because we want the arrays in it!
    private Target[] targets;                       // We need a new empty array to import the sorted target list
    private int currentTargetIndex = 0;             // Int to refer index position of the array above

    [SerializeField] private Camera playerCamera;   // Reference to the player's camera
    /*WALL*/[SerializeField] private LayerMask obstacleLayer;   // Layer mask for walls/obstacles

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();  // Get the GameManager component

        targets = gameManager.GetSortedTargets();       // Get the sorted targets from GameManager

        /*-->We are starting the game by looking at the first target:<--*/

        FaceNextVisibleTarget();                        // Face the highest HP target first, if not blocked
    }

    void Update()
    {
        // If Space is pressed, move to the next target
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FaceNextVisibleTarget();
        }
    }
    /* This method is for the player to look at the next target in the sorted list that is visible 
     * (not obstructed by any wall). 
     * It uses a loop to cycle through the list of targets 
     * and check if each target is in line of sight. 
     * Once a visible target is found, 
     * the camera will turn to face it, 
     * and the method stops checking further targets.
     */
    
    private void FaceNextVisibleTarget()
    {
        int targetCount = targets.Length;

        for (int i = 0; i < targetCount; i++)
        {
            //-------------------------------> Cycle to the next target<--------------------------
            /*
             * currentTargetIndex + 1 increments the current index by 1.
             * Using % targetCount ensures the index "wraps around" when it reaches the last target, 
             * looping back to the beginning of the list.*/
            currentTargetIndex = (currentTargetIndex + 1) % targetCount;

            Target target = targets[currentTargetIndex];

            // Check if the target is obstructed by a wall
            /*WALL*/if (IsTargetVisible(target))
            {    /*If not using WALL, keep whats inside the loop but you don't need the if statement to run it*/
                playerCamera.transform.LookAt(target.transform);    // Make the camera look at the target if visible
                return;                                             // Stop after finding the first visible target
            }
        }
    }

    /*The purpose of IsTargetVisible is to determine 
     * if the player can see a given target 
     * without any obstacles (wall) blocking the view. 
     * This is done using a raycast, 
     * which sends an invisible line from the player’s camera to the target. 
     * If the raycast hits an obstacle, 
     * it indicates the target is not visible. 
     * If the raycast reaches the target without hitting any obstacles, 
     * the target is visible.*/

    private bool IsTargetVisible(Target target)
    {
        Vector3 directionToTarget = target.transform.position - playerCamera.transform.position;
        float distanceToTarget = Vector3.Distance(playerCamera.transform.position, target.transform.position);

        // Perform a raycast to check if there's an obstacle between the camera and the target
        if (!Physics.Raycast(playerCamera.transform.position, directionToTarget, distanceToTarget, obstacleLayer))
        {
            // If the raycast doesn't hit any obstacle, the target is visible
            return true;
        }

        // If the raycast hits an obstacle, the target is not visible
        return false;
    }
}