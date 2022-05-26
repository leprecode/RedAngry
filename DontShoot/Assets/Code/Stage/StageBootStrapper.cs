using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageBootStrapper : MonoBehaviour
{
    //������ �������� ���� ��� ��� ��� �������� ����� ��������� �� ������������ ������ (���� ����� �� �����, ���������� ����� � ��)
    
    //����� �������� �������
    
    //����� ����� � ��� �������������
    
    //����� ����������� � �� ������������� (������� ��� ������ � ��������� ��������? ����, ��, ��� (����������, �������� ���)). ���� �������� � ��������
    //� �������������� ����� ����� �������


    [SerializeField] private StageData _stageData;
    private Spawner _spawner;

    private void Awake()
    {
        _spawner = new Spawner();
       _spawner.Initialize();
    }

    public StageData GetStageData()
    {
        return _stageData;
    }
}
