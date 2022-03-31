using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlayer : MonoBehaviour
{
    float _t = 0.0f;
    public float _refire = 1.0f;
    GameObject _firePrefab;
    public float _animStart;
    void FixedUpdate()
    {
        _t = _t + Time.deltaTime;

        if (Input.anyKey == false)
        {

            SMOOTH();

            if (_t > _refire & _targetE != null)
            {
                _firePrefab = GetComponent<Weapon>().ActiveWeaponPrefab;
                Instantiate(_firePrefab, transform.position, Quaternion.identity);
                _t = 0f;
            }
        }
        else
        {
            if (_t > 0.7f)
                _t = 0.7f;

            gameObject.GetComponent<Animator>().SetBool("fire", false);
        }
        if (_targetE)
        {
            if (_t <= _animStart && _t >= _animStart - 0.1f)
                gameObject.GetComponent<Animator>().SetBool("fire", true);
            if (_t >= _refire - 0.1f)
                gameObject.GetComponent<Animator>().SetBool("fire", false);
        }
    }


    Quaternion q2;
    GameObject _targetE;
    public GameObject _empty;
    void SMOOTH()
    {
        _targetE = GameObject.FindGameObjectWithTag("ENEMY");

        if (_targetE != null)
        {
            _empty.transform.LookAt(_targetE.transform);
            q2 = _empty.transform.rotation;
            transform.rotation = Quaternion.Lerp(transform.rotation, q2, Time.deltaTime * 10);
        }
    }


}