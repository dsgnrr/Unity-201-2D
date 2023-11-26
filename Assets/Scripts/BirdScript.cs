using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    private Rigidbody2D body;

    private float discreteForceFactor = 300f;
    private float continualForceFactor = 1000f;


    // Start is called before the first frame update
    void Start()
    {
        GameState.pipesPassed = 0;
        body = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // "імпульс" - лише на натиснення
        {
            body.AddForce(Vector2.up * discreteForceFactor);
        }
        if (Input.GetKey(KeyCode.W)) // "непереривний" - з кожним Update
        {
            body.AddForce(Vector2.up * continualForceFactor * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collision detected " + collision.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Trigger detected " + collision.gameObject.name);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("Pipe") || other.gameObject.CompareTag("HardPipe"))
        {
            GameState.pipesPassed += 1;
        }
    }
}
/* З точки зору взаємодії між собою колайдери поділяються на фізичні та тригери
 * 
 * Фізичні колайдери "відпрацьовують" зіткнення засобами двигуна Юніті nf
 * передають у скріпт подію OnCollisionEnter2D
 * 
 * Тригер-колайдери не беруть участь у двигуні, лише передають подію OnTriggerEnter2D
 * 
 * Події взаємно виключні - або тригер, або колізія. Не обидві відразу,
 * навіть якщо один з колайдерів фізичний. А інший тригер
 * 
 * Подія отримує кожен скрипт, що бере участь у зіткненні. Якщо один з
 * колайдерів фізичний, інший тригер -- обидва підтримують подію "Тригер"
 * 
 * Хоча б один з учасників зіткнення повинен мати компонент RigibodyБ
 * інакше колізії не детектуються. (Відсутність Rigidbody - значить об'єкт не бере участь у фізичному циклі)
 */
