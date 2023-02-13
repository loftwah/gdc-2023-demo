using UnityEngine;

namespace Game
{
    public class GhostChase : GhostBehavior
    {
        private void OnDisable()
        {
            Ghost!.Scatter!.Enable();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Node node = other!.GetComponent<Node>();

            // Do nothing while the ghost is frightened
            if (node != null && enabled && !Ghost!.Frightened!.enabled)
            {
                Vector2 direction = Vector2.zero;
                float minDistance = float.MaxValue;

                // Find the available direction that moves closet to pacman
                foreach (Vector2 availableDirection in node.AvailableDirections!)
                {
                    // If the distance in this direction is less than the current
                    // min distance then this direction becomes the new closest
                    Vector3 newPosition = transform.position + new Vector3(availableDirection.x, availableDirection.y);
                    float distance = (Ghost.target!.position - newPosition).sqrMagnitude;

                    if (distance < minDistance)
                    {
                        direction = availableDirection;
                        minDistance = distance;
                    }
                }

                Ghost.Movement!.SetDirection(direction);
            }
        }
    }
}