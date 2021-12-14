using UnityEngine;

// This enum class is for the layer mask, when adding new layer, we need to update this script!
// To add multiple layers in one variable, we do the following: 
// LayerMask layers = (int)Layers.Player | (int)Layers.Enemy. (we work on bit wise here)
// this will make the layers have the player and enemy layers.
public enum Layers
{
    Everything = -1,
    Nothing = 0,
    Default = 1 << 0,
    TransparentFX = 1 << 1,
    IgnoreRaycast = 1 << 2,
    Player = 1 << 3,
    Water = 1 << 4,
    UI = 1 << 5,
    Enemy = 1 << 6
}

public struct Damage
{
    public float damageAmount;
    public float pushForce;
    public Vector3 origin;
}

public struct WeaponSword
{
    public string name;
    public Sprite sprite;
}