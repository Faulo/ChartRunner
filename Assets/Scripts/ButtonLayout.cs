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

    public void PressLeft() {

    }

    public void PressRight() {

    }

    public void PressUp() {

    }

    public void PressDown() {

    }

    public void PressRewind() {

    }
}
