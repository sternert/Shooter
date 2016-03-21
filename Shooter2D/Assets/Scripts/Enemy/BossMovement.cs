using UnityEngine;
using System.Collections;

public class BossMovement : MonoBehaviour
{
	private float _moveSpeed;
	private Rigidbody2D _rigidbody;
	private Rigidbody2D _player;

	void Start ()
	{
		_rigidbody = GetComponent<Rigidbody2D> ();
		_player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update ()
	{
		if (_player != null) {
			var distanceToPlayerX = _player.position.x - _rigidbody.position.x;
			if (Mathf.Abs (distanceToPlayerX) > 0.5) { // If nearby, stand still
				var direction = (float)Mathf.Sign (distanceToPlayerX);
				_rigidbody.velocity = new Vector2 (direction * _moveSpeed, 0);
			}
		}
	}

	public void SetMovement (MovementType movementType, float moveSpeed, float aimTime)
	{
		_moveSpeed = moveSpeed;
		_rigidbody = GetComponent<Rigidbody2D> ();
	}
}
