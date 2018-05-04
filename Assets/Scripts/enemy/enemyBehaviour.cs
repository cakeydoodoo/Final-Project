using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using NPBehave;


namespace Complete
{
    public partial class enemy : MonoBehaviour {
        
        private Root CreateBehaviourTree()
        {
            return new Root(
                new Action(() => MoveAI(0.9f))

            );

        }

        /*
        private void UpdatePerception()
        {
            Vector3 targetPos = target.position;
            Vector3 localPos = this.transform.InverseTransformPoint(targetPos);
            Vector3 heading = localPos.normalized;


            blackboard["targetDistance"] = localPos.magnitude;
            blackboard["targetInFront"] = heading.z > 0;
            blackboard["targetOnRight"] = heading.x > 0;

            blackboard["environmentFront"] = environmentFront();
            blackboard["envronmentLeft"] = environmentLeft();
            blackboard["envronmentLeft"] = environmentRight();


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

        private Node StopMove()
        {
            return new Action(() => MoveAI(0));
        }

    */
    }
}