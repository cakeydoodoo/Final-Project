using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPBehave;


public class enemyBehaviour : MonoBehaviour {

    private Blackboard blackboard;
    private Root behaviorTree;
    public Transform Target;

    // Use this for initialization
    void Start () {
		behaviorTree = CreateBehaviourTree();
        blackboard = behaviorTree.Blackboard;
	}

    private Root CreateBehaviourTree()
    {
        return new Root(
                new Service(0.2f, UpdatePerception,

                    

    }
    

    private void UpdatePlayerDistance()
    {
        Vector3 playerLocalPos = this.transform.InverseTransformPoint(GameObject.FindGameObjectWithTag("Player").transform.position);
        behaviorTree.Blackboard["playerLocalPos"] = playerLocalPos;
        behaviorTree.Blackboard["playerDistance"] = playerLocalPos.magnitude;
    }

    // Update is called once per frame
    void Update () {
		
	}
    private void UpdatePerception()
    {
        Vector3 targetPos = Target.position;
        Vector3 localPos = this.transform.InverseTransformPoint(targetPos);
        Vector3 heading = localPos.normalized;


        blackboard["targetDistance"] = localPos.magnitude;
        blackboard["targetInFront"] = heading.z > 0;
        blackboard["targetOnRight"] = heading.x > 0;
        blackboard["targetOffCentre"] = Mathf.Abs(heading.x);

        blackboard["environmentFront"] = environmentFront();
        blackboard["envronmentLeft"] = environmentLeft();
        blackboard["envronmentLeft"] = environmentRight();

        blackboard["targetOpen"] = targetOpen();

    }
    bool environmentLeft()
    {
        Vector3 left = transform.TransformDirection(Vector3.left);
        if (Physics.Raycast(transform.position, left, 5))
        {
            return true;
        }

        return false;

    }
    bool environmentFront()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, forward, 10))
        {
            return true;
        }

        return false;
    }
    bool environmentRight()
    {
        Vector3 right = transform.TransformDirection(Vector3.right);
        if (Physics.Raycast(transform.position, right, 5))
        {
            return true;
        }

        return false;

    }
    private bool targetOpen()
    {
        Vector3 targetPosition = new Vector3(Target.position.x, Target.position.y + 0.5f, Target.position.z + 0.88f);
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, 0.5f, targetPosition - transform.position, out hit))
        {
            //the spherecast will hit anything with a collider but will return true if it hits anything with the name tank.
            if (hit.collider.gameObject.name.Contains("Tank"))
            {
                return true;
            }
        }
        return false;
    }
}
