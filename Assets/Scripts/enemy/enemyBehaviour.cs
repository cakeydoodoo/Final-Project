using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPBehave;


namespace Complete
{
    public partial class Enemy : MonoBehaviour {

        private Root CreateBehaviourTree()
        {
            return new Root(
                    new Service(0.2f, UpdatePerception,
                    new Selector(
                        //if the player is more than 25 units away, move forward and turn when it hits the environment
                        new BlackboardCondition("targetDistance",
                                                Operator.IS_GREATER, 25f,
                                                Stops.IMMEDIATE_RESTART,
                                                new Selector(
                                                    new BlackboardCondition("environmentFront",
                                                    Operator.IS_EQUAL, true,
                                                    Stops.IMMEDIATE_RESTART,
                                                    new Selector(
                                                        new BlackboardCondition("environmentRight",
                                                                                Operator.IS_EQUAL, true,
                                                                                Stops.IMMEDIATE_RESTART,
                                                                                new Sequence(
                                                                                    StopMove(),
                                                                                    new Action(() => TurnAI(-0.7f))
                                                                                    )
                                                            ),
                                                        new BlackboardCondition("environmentLeft",
                                                                                Operator.IS_EQUAL, true,
                                                                                Stops.IMMEDIATE_RESTART,
                                                                                new Sequence(
                                                                                    StopMove(),
                                                                                    new Action(() => TurnAI(0.7f))
                                                                                    )

                                                            ),
                                                        //if there is nothing on the left or right and only in front, reverse then turn right.
                                                        new Sequence(
                                                            new Action(() => MoveAI(-0.5f)),
                                                            //                                                            new Wait(0.5f),
                                                            new Action(() => TurnAI(-0.7f))
                                                            )
                                                    )
                                                    ),
                                                    //if there is no part of the environment in front, then stop turning and move forward.
                                                    new Sequence(
                                                    StopTurn(),
                                                    new Action(() => MoveAI(0.1f))
                                                    )
                                                )
                                            ),        
                                        
                        //if the distance is less than 25 and greater than 2, turn and follow the player

                        new BlackboardCondition("targetInFront",
                                               Operator.IS_EQUAL, false,
                                               Stops.IMMEDIATE_RESTART,
                                               new Selector(

                                                   new BlackboardCondition("targetOnRight",
                                                   Operator.IS_EQUAL, true,
                                                   Stops.IMMEDIATE_RESTART,
                                                   new Sequence(

                                                        StopMove(),
                                                        new Action(() => TurnAI(0.7f))
                                                        )
                                                        ),

                                                   new BlackboardCondition("targetOnRight",
                                                                          Operator.IS_EQUAL, false,
                                                                          Stops.IMMEDIATE_RESTART,
                                                                          new Sequence(
                                                                                StopMove(),
                                                                                new Action(() => TurnAI(-0.7f))
                                                                                )
                                                                                )
                                                   )
                                                       
                             ),

                        new BlackboardCondition("targetDistance",
                                                Operator.IS_GREATER_OR_EQUAL,1f,
                                                Stops.IMMEDIATE_RESTART,
                                                new Selector(

                                                    new BlackboardCondition("targetOffCentre",
                                                                            Operator.IS_SMALLER_OR_EQUAL, 0.1f,
                                                                            Stops.IMMEDIATE_RESTART,
                                                                            new Sequence(
                                                                            StopTurn(),
                                                                            new Action(() => MoveAI(0.1f))
                                                                            )
                                                        ),

                                                    new BlackboardCondition("targetOnRight",
                                                                            Operator.IS_EQUAL, true,
                                                                            Stops.IMMEDIATE_RESTART,
                                                                            new Sequence(
                                                                            StopMove(),
                                                                            new Action(() => TurnAI(0.7f))
                                                                            )
                                                        ),
                                                    new BlackboardCondition("targetOnRight",
                                                                            Operator.IS_EQUAL, false,
                                                                            Stops.IMMEDIATE_RESTART,
                                                                            new Sequence(
                                                                            StopMove(),
                                                                            new Action(()
                                                                            => TurnAI(-0.7f))
                                                                            )
                                                                            )
                                                    )
                            
                            ),
                        new Sequence(
                            StopMove(),
                            new Action(() => attack()),                            
                            new Action(() =>  Stop()),
                            new Wait(3f)
                            )
                                                    // if the player is within a distance of 2

                            
                        )
                    )                     
               );
        }


        private void UpdatePlayerDistance()
        {
            Vector3 playerLocalPos = this.transform.InverseTransformPoint(GameObject.FindGameObjectWithTag("Player").transform.position);
            behaviorTree.Blackboard["playerLocalPos"] = playerLocalPos;
            behaviorTree.Blackboard["playerDistance"] = playerLocalPos.magnitude;
        }

        private void UpdatePerception()
        {
            Vector3 targetPos = target.position;
            Vector3 localPos = this.transform.InverseTransformPoint(targetPos);
            Vector3 heading = localPos.normalized;


            blackboard["targetDistance"] = localPos.magnitude;
            blackboard["targetInFront"] = heading.z > 0;
            blackboard["targetOnRight"] = heading.x > 0;
            blackboard["targetOffCentre"] = Mathf.Abs(heading.x);

            blackboard["environmentFront"] = environmentFront();
            blackboard["envronmentLeft"] = environmentLeft();
            blackboard["envronmentRight"] = environmentRight();


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
        private Node StopTurn()
        {
            return new Action(() => TurnAI(0));
        }
    }
}