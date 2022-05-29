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
    public Spawner _spawner { get; private set; }
    public StageGameplay _stageManager { get; private set; }


    private void Awake()
    {
        _spawner = new Spawner();
        _spawner.Initialize(_stageData.GetWaves());

        _stageManager = new StageGameplay();
        _stageManager.Initialize(this._spawner, _stageData.GetWavePause());
    }
}
