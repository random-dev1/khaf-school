using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using TreeEditor;

public class PlayerMovementTutorial : MonoBehaviour {
    public CharacterController controller;
    private float speed = 4f;
    private float gravity = -15f;
    Vector3 velocity;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    private float jumpForce = 1f;
    public bool sprinting = false;
    public bool canSprint = true;
    public AudioSource walkingsound;
    public AudioSource runningsound;
    public PlayerOtherStuff otherStuff;
    public bool walking = false;
    public bool crouching = false;
    void Update() {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        if (otherStuff.Energy < 1) {
            canSprint = false;
        }
        if (otherStuff.Energy > 50) {
            canSprint = true;
        }
        if (Input.GetKey(KeyCode.LeftShift) && move.x != 0 & move.z != 0 && canSprint) {
            controller.Move(move * speed * 1.8f * Time.deltaTime);
            sprinting = true;
            walking = false;
        } else if (crouching && move.x != 0 & move.z != 0) {
            controller.Move(move * speed * 0.5f * Time.deltaTime);
            sprinting = false;
            walking = false;
        } else {
            controller.Move(move * speed * Time.deltaTime);
            sprinting = false;
            walking = true;
        }
        if (move.x == 0 && move.y == 0) {
            walking = false;
        }
        if (move.x != 0 & move.z != 0 && !walkingsound.isPlaying && isGrounded) {
            walkingsound.Play();
        } else if (move.x == 0 && move.z == 0 && walkingsound.isPlaying || !isGrounded) {
            walkingsound.Pause();
        }
        
        if (sprinting && !runningsound.isPlaying) {
            if (walkingsound.isPlaying) {
                walkingsound.Pause();
            }
            runningsound.Play();
        } else if (!sprinting && runningsound.isPlaying) {
            runningsound.Pause();
        }

        if (Input.GetButton("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpForce * -2 * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.C)) {
            transform.localScale = new Vector3(0f, 0.5f, 0f);
            crouching = true;
        } else if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.C)) {
            transform.localScale = new Vector3(0f, 1f, 0f);
            controller.Move(new Vector3(0f, 0.5f, 0f));
            crouching = false;
        }
        if (crouching) {
            transform.localScale -= new Vector3(0f, (transform.localScale.y - 0.5f) / 20, 0f);
        } else {
            transform.localScale -= new Vector3(0f, (transform.localScale.y - 1f) / 20, 0f);
        }
    }
}