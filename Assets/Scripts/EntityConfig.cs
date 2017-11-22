using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityConfig : MonoBehaviour {


	public float maxFOV = 180;
	public float maxAcceleration;
	public float maxVelocity;

	public float wanderJitter;
	public float wanterRadius;
	public float wanterDistance;
	public float wanterPriority;

	public float cohesionRadius;
	public float cohesionPriority;

	public float alignmentRadius;
	public float alignmentPriority;

	public float separationRadius;
	public float separationPriority;

	public float avoidanceRadius;
	public float avoidancePriority;


}
