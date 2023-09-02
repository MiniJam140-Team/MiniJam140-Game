﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    internal class MageController : MonoBehaviour
    {
        //Damagable damagable;
        public enum attacks { attack1, attack2 };
        //public DetectionZone attackZone;
        Animator animator;
        Rigidbody2D rb;
        CapsuleCollider2D capsuleCollider;
        public GameObject ledgeDetector;
        public Transform target;
        private bool isMoving;
        public float speed;
        public float distToChasePlayer = 8f;

        public bool IsMoving
        {
            get
            {
                return isMoving;
            }
            set
            {
                isMoving = value;
                animator.SetBool(AnimationStrings.isMoving, value);
            }
        }
        public bool _canMove = true;
        public bool CanMove
        {
            get
            {
                return animator.GetBool(AnimationStrings.canMove);
            }
        }
        public bool _hasTarget = false;
        public bool HasTarget
        {
            get
            {
                return _hasTarget;
            }
            private set
            {
                _hasTarget = value;
                animator.SetBool(AnimationStrings.hasTarget, value);
            }
        }
        public float AttackCooldown
        {
            get
            {
                return animator.GetFloat(AnimationStrings.attackCooldown);
            }
            private set
            {
                animator.SetFloat(AnimationStrings.attackCooldown, Mathf.Max(value, 0));
            }
        }
        private void Awake()
        {
            animator = GetComponent<Animator>();
        }
        // Start is called before the first frame update
        void Start()
        {
        }
        // Update is called once per frame
        void Update()
        {
            //HasTarget = attackZone.detectedColliders.Count > 0;
            Vector3 scale = transform.localScale;
            //IsChasing = Vector2.Distance(transform.position, target.position) < distToChasePlayer ? true : false;

            if (transform.position.x > target.position.x)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
                scale.x = Mathf.Abs(scale.x) * -1;
            }
            if (transform.position.x < target.position.x)
            {
                scale.x = Mathf.Abs(scale.x) * 1;
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            if (transform.position.y > target.position.y)
            {
                transform.position += Vector3.down * speed * Time.deltaTime;
                scale.x = Mathf.Abs(scale.x) * -1;
            }
            if (transform.position.y < target.position.y)
            {
                scale.x = Mathf.Abs(scale.x) * 1;
                transform.position += Vector3.up * speed * Time.deltaTime;
            }
            transform.localScale = scale;
        }
        private void FixedUpdate()
        {
            target = GameObject.FindWithTag("Enemy").transform;
        }
    }
}
