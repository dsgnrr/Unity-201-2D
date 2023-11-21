using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPointScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.name);
        // У випадку труби колізія відбувається з її складовою
        // частино, тоді як знищувати требя "батьківський" об'єкт
        GameObject.Destroy( // знищення об'єкту - повне не лише деактивація
            other           // колайдер (компонент об'єкту)
            .gameObject     // об'єкт цього колайдеру
            .transform      // його компонент transform
            .parent         // батьківський transform
            .gameObject     // об'єкт цього transform - батьківський об'єкт
            );              //
    }
}
