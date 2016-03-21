using UnityEngine;

public class ShotMover : MonoBehaviour
{
    private Rigidbody2D _rigidBody;

    public void SetVelocity(Vector2 newVelocity)
    {
        if (_rigidBody == null)
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }
        GetComponent<Rigidbody2D>().velocity = newVelocity;
    }
}
