using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingPiece : MonoBehaviour {


	public Vector3 StartPos{get; private set;}
	public Vector3 EndPos{get; private set;}

	public float PercentageAlongTrajectory{get{return percentageAlongTrajectory;} private set{percentageAlongTrajectory = value;}}

	public Vector3 DirectionToCenter{get{return directionToCenter;} private set{directionToCenter = value;}}

	public Vector3 OppDirectionToCenter{get{return oppDirectionToCenter;}private set{oppDirectionToCenter = value;}}


	private ExplodingObject myExplodingParent; 

	// Use this for initialization
	void Start () {
		myExplodingParent = transform.parent.GetComponent<ExplodingObject>();
		CalculateStartPos();
		CalculateDistanceToCenter();
		CalculateEndPos();
		FindDirectionToCenter();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CalculateStartPos(){
		startPos = transform.position;
	}
	void CalculateEndPos(){
		//multiply the startPos by a constant amount, in the opposite direction as the center
		endPos = StartPos + (oppDirectionToCenter * myExplodingParent.ExplosionMultiplier);
	}
	void CalculateDistanceToCenter(){
		Vector3.Distance(transform.position, myExplodingParent.CenterPiece.position);
	}
	void FindDirectionToCenter(){
		//// Gets a vector that points from the player's position to the target's.
		//var heading = target.position - player.position;
		directionToCenter = transform.position - myExplodingParent.transform.position;
	}
	void Find_OPP_DirectionToCenter(){
		//// Gets a vector that points from the player's position to the target's.
		//var heading = target.position - player.position;
		oppDirectionToCenter = -1*directionToCenter;
	}

	private Vector3 startPos;
	private Vector3 endPos;
	private float percentageAlongTrajectory;
	private Vector3 directionToCenter;
	private Vector3 oppDirectionToCenter;
}
