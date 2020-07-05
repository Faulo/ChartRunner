using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Slothsoft.UnityExtensions;

public class ButtonLayout : MonoBehaviour
{
    [SerializeField, Expandable]
    SpriteRenderer buttonLeft = default;
    [SerializeField, Expandable]
    SpriteRenderer buttonRight = default;
    [SerializeField, Expandable]
    SpriteRenderer buttonRoll = default;
    [SerializeField, Expandable]
    SpriteRenderer buttonRewind = default;
    [SerializeField, Expandable]
    SpriteRenderer buttonJump = default;

    bool moveLeft = false;
    bool moveRight = false;

    void Update() {
        if(AvatarController.instance.intendedMovement > 0) {
            moveRight = true;
        } else {
            moveRight = false;
        }
        if(AvatarController.instance.intendedMovement < 0) {
            moveLeft = true;
        } else {
            moveLeft = false;
        }

        PressLeft();
        PressRewind();
        PressRight();
        PressJump();
        PressRoll();
    }

    public void PressLeft() {
        buttonLeft.enabled = moveLeft;
    }

    public void PressRight() {
        buttonRight.enabled = moveRight;

    }

    public void PressJump() {
        buttonJump.enabled = AvatarController.instance.intendsJump;
    }

    public void PressRoll() {
        buttonRoll.enabled = AvatarController.instance.intendsRoll;
    }

    public void PressRewind() {
        buttonRewind.enabled = AvatarController.instance.intendsRewind;
    }
}
