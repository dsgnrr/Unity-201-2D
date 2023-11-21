using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPointScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.name);
        // � ������� ����� ����� ���������� � �� ���������
        // �������, ��� �� ��������� ����� "�����������" ��'���
        GameObject.Destroy( // �������� ��'���� - ����� �� ���� �����������
            other           // �������� (��������� ��'����)
            .gameObject     // ��'��� ����� ���������
            .transform      // ���� ��������� transform
            .parent         // ����������� transform
            .gameObject     // ��'��� ����� transform - ����������� ��'���
            );              //
    }
}
