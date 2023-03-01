using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    public const float WIDTH_MAP = 6;
    public const float HEIGHT_MAP = 6;
    public const float DELTA_TIME_PER_WAVE = 5;

    [SerializeField]
    GameObject Banshee;
    [SerializeField]
    GameObject Harpy;
    [SerializeField]
    GameObject Minotaur;
    [SerializeField]
    GameObject Orge;

    public int StrengthPerWave{ get; set; }

    public int CountWave { get; set; }

    public float AccumStrength { get; set; }
    public int TypeUnit { get; set; }

    private GameObject Instance;

    Timer timer;
    void Start()
    {
        CountWave = 1;
        timer = gameObject.AddComponent<Timer>();
        SpawnNewWave();
    }

    // Update is called once per frame
    // Khi kết thúc một wave, tăng số wave, tăng tổng sức mạnh->sinh Unit mỗi delta giây 
    void Update()
    {
        if (isFinishWave())
        {
            CountWave += 1;
            StrengthPerWave = StrengthPerWave + 10 * (CountWave + 2);
            timer.Run();
            if (timer.Finished)
            {
                SpawnNewWave();              
            }
        }
    }

    bool isFinishWave()
    {
        GameObject[] attackers = GameObject.FindGameObjectsWithTag("attackers");
        if (attackers.Length > 0) return false;
        return true;
    }

    void SpawnNewWave()
    {
        while (true)
        {
            TypeUnit = Random.Range(1, 5);
            switch (TypeUnit)
            {
                case 1:
                    Instance = GenerateUnit(Harpy);
                    break;
                case 2:
                    Instance = GenerateUnit(Orge);
                    break;
                case 3:
                    Instance = GenerateUnit(Minotaur);
                    break;
                case 4:
                    Instance = GenerateUnit(Banshee);
                    break;
                default: break;
            }
            // Tổng chỉ số sức mạnh của từng con, lấy tạm cái tầm đánh
            AccumStrength += Instance.GetComponent<Unit>().AttackRange;
            if (AccumStrength > StrengthPerWave) break;
        }
    }

    public GameObject GenerateUnit(GameObject gameObject)
    {
        return null;
    }
}
