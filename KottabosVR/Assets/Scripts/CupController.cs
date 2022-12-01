using UnityEngine;


public class CupController : MonoBehaviour
{
	[Tooltip("The prefab to spawn when filling the cup.")]
	public ProjectileController fillPrefab;
	[Tooltip("The parent of the wine-lees.")]
	public Transform fill;
	[Tooltip("The location to spawn the projectile from.")]
	public Transform throwOffset;
	[Tooltip("The collider that follows this cup.")]
	public Collider meshCollider;
	[Tooltip("Speed at which to release the projectile.")]
	public float releaseSpeed;
	[Tooltip("Reset threshold for peak speed.")]
	public float peakResetThreshold;


	public Vector3 Acceleration => this.prevAcceleration;

	private Vector3 velocity, prevVelocity, prevPos, acceleration, prevAcceleration; // various physics variables used for determining when to release the projectile
	private bool isFilled;
	private ProjectileController fillObject;
	private Transform[] wine_lees;
	private RunningAverage<Vector3> averageVelocity;
	private PeakTracker peakSpeed;

	public int shotsFired;


	public void Start()
	{
		this.prevPos = this.transform.position;
		this.isFilled = false;
		this.wine_lees = this.fill.GetComponentsInChildren<Transform>();
		this.averageVelocity = new(10);
		this.peakSpeed = new(this.peakResetThreshold);
		shotsFired = 0;
	}

	public void FixedUpdate()
	{
		// update physics variables
		float deltaTime = Time.deltaTime;
		this.prevVelocity = this.velocity;
		Vector3 currentPos = this.transform.position;
		this.velocity = (currentPos - this.prevPos) / deltaTime;
		this.prevPos = currentPos;
		this.prevAcceleration = this.acceleration;
		this.acceleration = (this.velocity - this.prevVelocity) / deltaTime;
		Vector3 avgVel = this.averageVelocity.Update(this.velocity);
		float peak = this.peakSpeed.Update(this.velocity.magnitude);
//		DrawArrow.ForDebug(currentPos, avgVel);
//		Debug.Log($"current: {this.velocity.magnitude}\naverage: {this.averageSpeed.Update(this.velocity.magnitude)}\nvalues: {this.averageSpeed}");
		if (this.isFilled & peak > this.releaseSpeed && this.acceleration.z < 0)
		{
			this.fillObject.GetComponent<Rigidbody>().velocity = avgVel.normalized * peak;
			this.isFilled = false;
			this.fill.gameObject.SetActive(false);
			this.fillObject.Release();
			this.fillObject.gameObject.SetActive(true);
			IncreaseShotsFired();
			Debug.Log(avgVel);
		}
	}

	public void Fill()
	{
		if (!this.isFilled)
		{
			this.isFilled = true;
			this.fillObject = Object.Instantiate(this.fillPrefab, this.throwOffset.position, this.throwOffset.rotation, this.transform);
			this.fillObject.gameObject.SetActive(false);
			this.fill.gameObject.SetActive(true);
			this.peakSpeed.Reset();
		}
		foreach (Transform each in this.wine_lees)
		{
			each.localPosition = Vector3.zero;
		}
	}

	public void IncreaseShotsFired()
	{
		Score.shotsFired += 1;
	}
}
