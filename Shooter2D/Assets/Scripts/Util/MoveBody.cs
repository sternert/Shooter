using UnityEngine;

public class MoveBody : MonoBehaviour
{
    public Limits limits;
    public float speed;

    private Rigidbody2D _rigidBody;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    public Vector2 Move(Vector2 direction)
    {
        _rigidBody.velocity = direction * speed;
        if (limits != null)
        {
            var currentLimits = limits.GetLimits();

            _rigidBody.position = new Vector2
                (
                    Mathf.Clamp(_rigidBody.position.x, currentLimits.XMin, currentLimits.XMax),
                    Mathf.Clamp(_rigidBody.position.y, currentLimits.YMin, currentLimits.YMax)
                );
        }

        return _rigidBody.velocity;
    }
}
