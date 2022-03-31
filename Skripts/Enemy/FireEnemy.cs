using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnemy : MonoBehaviour
{
    public GameObject EnemyFirePrefab1;
    float _t;
    public float refire = 2f;

    GameObject _target;

    public float _timeMoveToPlayer = 0.5f;


    private void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        //  if (_target.GetComponent<PlayerLife>().SetActiveStartGoVS == true)
        {
            _t = _t + Time.deltaTime;

            if (_t < _timeMoveToPlayer)
            {
                SMOOTH();
                MoveToPlayer();
            }
            if (_t > _timeMoveToPlayer)
                this.GetComponent<Animator>().SetBool("move", false);


            if (_t > refire)
            {
                Instantiate(EnemyFirePrefab1, transform.position, Quaternion.identity);

                _t = 0f;
            }

            if (_t > refire - 0.7f)
                gameObject.GetComponent<Animator>().SetBool("fire", true);
            if (_t > refire - 0.1f)
                gameObject.GetComponent<Animator>().SetBool("fire", false);

        }
    }


    float _dist;
    public float _minDist = 0.7f;
    public float _speedToPlayer = 0.5f;
    void MoveToPlayer()
    {
        _dist = Vector3.Distance(this.transform.position, _target.transform.position);

        if (_dist > _minDist)
        {
            this.GetComponent<Animator>().SetBool("move", true);
            this.transform.Translate(Vector3.forward.normalized * _speedToPlayer * Time.deltaTime);

        }
    }




    Quaternion q1;
    Quaternion q2;
    public float _smooth = 10.0f;

    void SMOOTH()
    {
        q1 = transform.rotation;                                              // плавный поворот 
        transform.LookAt(_target.transform);
        q2 = transform.rotation;
        transform.rotation = Quaternion.Lerp(q1, q2, Time.deltaTime * _smooth);
    }
}
