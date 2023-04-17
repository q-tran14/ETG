using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    public GameObject target;
    public int HP;
    public GameObject weapon;
    [SerializeField]private Vector3 targetPos;
    [SerializeField] private NavMeshAgent agent;
    public GameObject hand;
    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        targetPos = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        SetAgentPos(targetPos);

        WeaponLookAtPLayer();
    }

    void SetAgentPos(Vector3 position)
    {
        agent.SetDestination(position);
    }

    private void OnTriggerEnter2D(Collider2D collision) // Attack Boundary
    {
        if (collision.gameObject.tag == "Player") Fire();
    }
    private void OnCollisionEnter2D(Collision2D collision) // Enemy get shot
    {
        if (collision.gameObject.tag == "Player Bullet") HP -= 1;        
    }

    public abstract void Fire();
    public abstract void State();

    public void WeaponLookAtPLayer()
    {
        if (weapon != null) {
            Vector3 vectorToTarget = target.transform.position - hand.transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y,vectorToTarget.x)*Mathf.Rad2Deg - 360f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            hand.transform.rotation = Quaternion.Slerp(transform.rotation,q,Time.deltaTime*20);
        }
    }
}
