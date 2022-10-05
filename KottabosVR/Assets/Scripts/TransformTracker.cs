using UnityEngine;



public class TransformTracker : MonoBehaviour
{
	[Tooltip("The transform for this object to track.")]
	public Transform trackedTransform;


	public void FixedUpdate()
	{
		this.transform.SetPositionAndRotation(this.trackedTransform.position, this.trackedTransform.rotation);
	}
}
