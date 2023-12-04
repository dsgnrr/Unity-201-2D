using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPointScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.name);
        Transform parent =
            other           // колайдер (компонент об'єкту)
            .gameObject     // об'єкт цього колайдеру
            .transform      // його компонент transform
            .parent;         // батьківський transform
                             //.gameObject;     // об'єкт цього transform - батьківський об'єкт

        // У випадку труби колізія відбувається з її складовою
        // частиною, тоді як знищувати требя "батьківський" об'єкт
        if (parent != null && parent.gameObject.CompareTag("Pipe"))
        {
            GameObject.Destroy(parent.gameObject); // знищення об'єкту - повне не лише деактивація
        }
        else // інакше знищуємо сам об'єкт
        {
            GameObject.Destroy(other.gameObject);
        }
    }
}
