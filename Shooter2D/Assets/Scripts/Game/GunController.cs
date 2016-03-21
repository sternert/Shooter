using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GunController : MonoBehaviour
{

	public float shotSpeed;
	public float shotDelay;

	public List<GunControl> gunControls;

	void Update ()
	{
		var shotsFired = 0;
		foreach (var gunControl in gunControls) {
			if (gunControl.CanShoot ()) {
				gunControl.Shoot ();
				shotsFired++;
			}
		}
	}
}
