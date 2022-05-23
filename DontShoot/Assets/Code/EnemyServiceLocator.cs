using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyServiceLocator : MonoBehaviour
{
    public static Transform GetMyTransform(Component component)
    {
        return component.transform;
    }
}
