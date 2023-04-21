using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy{
    public abstract class Enemy : MonoBehaviour
    {
        public GameObject target;
        public GameObject weapon;
        public GameObject hand;

        public int HP;
        public Animator animator;
        public float waitToNextShot;
        public StateManager manager;

        [SerializeField]
        protected enum side
        {
            L, // Left side
            R, // Right side 
            O,
            U, // Back
            D  // Front
        }

        [SerializeField] protected string curVerSide, curHoriSide;
        [SerializeField] private Vector3 targetPos;
        [SerializeField] protected NavMeshAgent agent;

        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
            agent = GetComponent<NavMeshAgent>();
            agent.updateRotation = false;
            agent.updateUpAxis = false;
            manager = new StateManager(new Spawn(), animator);
            
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            manager.EnterState();
            targetPos = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
            SetAgentPos(targetPos);
            WeaponLookAtPLayer();
            CompareTargetPositionToAgent();
            SetDir();
            if (target != null) manager.SwithcState(new MoveState());
            if (HP == 0) Die();
        }

        private void SetAgentPos(Vector3 position)
        {
            var agentDrift = 0.0001f;
            var driftPos = position + (Vector3)(agentDrift * Random.insideUnitCircle);
            agent.SetDestination(driftPos);
        }
        private void WeaponLookAtPLayer()
        {
            if (weapon != null)
            {
                Vector3 vectorToTarget = target.transform.position - hand.transform.position;
                float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
                hand.GetComponent<Rigidbody2D>().rotation = angle;
            }
        }
        private void ChangeSideHand(int i) // Just 0 to turn to left and 1 to turn to right
        {
            if (i == 0) // Right - rotation to left
            {
                hand.transform.localScale = new Vector3(1, -1, 1);
                hand.transform.localPosition = new Vector3(-0.5f, -0.35f, 0);
            }
            if (i == 1) // Left  - rotation to right
            {
                hand.transform.localScale = new Vector3(1, 1, 1);
                hand.transform.localPosition = new Vector3(0.5f, -0.35f, 0);
            }
        }
        private void CompareTargetPositionToAgent()
        {
            if (targetPos.x > transform.position.x + 0.5f)
            {
                if (weapon != null)
                {
                    ChangeSideHand(1);
                }
                curHoriSide = side.R.ToString();
            }
            if (targetPos.x < transform.position.x - 0.5f)
            {
                if (weapon != null)
                {
                    ChangeSideHand(0);
                }
                curHoriSide = side.L.ToString();
            }
            if (targetPos.x <= transform.position.x + 0.5f && targetPos.x >= transform.position.x - 0.5f)
            {
                if (weapon != null)
                {
                    ChangeSideHand(1);
                }
                curHoriSide = side.O.ToString();
            }
            if (targetPos.y > transform.position.y + 0.5f) curVerSide = side.U.ToString();
            if (targetPos.y < transform.position.y + 0.5f) curVerSide = side.D.ToString();
            if (targetPos.y <= transform.position.y + 0.5f && targetPos.y >= transform.position.y - 0.5f) curVerSide = side.O.ToString();
        }

        private void SetDir()
        {
            if (animator.parameterCount == 1)
            {
                if (animator.GetParameter(0).name == "ver") manager.setDirection("O",curVerSide);
                if (animator.GetParameter(0).name == "hori") manager.setDirection(curHoriSide, "0");
            }
            if (animator.parameterCount == 2) manager.setDirection(curHoriSide,curVerSide);
        }

        public abstract void Fire();
        public abstract void Die();

    }

}
