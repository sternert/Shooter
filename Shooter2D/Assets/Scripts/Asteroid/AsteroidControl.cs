using UnityEngine;

public class AsteroidControl : MonoBehaviour 
{
    public DirectionVector2 _direction;
    public float rotationSpeed;
    
	private float _speed;
    private Rigidbody2D _rigidBody;

    void Start()
    {
		_speed = 4;
        _rigidBody = GetComponent<Rigidbody2D>();
        _rigidBody.angularVelocity = Random.Range(-1.0f, 1.0f) * rotationSpeed;
    }

	public void SetSpeed(float newSpeed) 
	{
		_speed = newSpeed;
		GetComponent<Rigidbody2D>().velocity = _direction.direction * _speed;
	}
}