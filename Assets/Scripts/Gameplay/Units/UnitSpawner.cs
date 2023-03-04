using Assets.Scripts.Gameplay.Units;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    public const float WIDTH_MAP = 6;
    public const float HEIGHT_MAP = 6;
    public const float DELTA_TIME_PER_WAVE = 5;

    [SerializeField]
    GameObject prefabBanshee;
    [SerializeField]
    GameObject prefabHarpy;
    [SerializeField]
    GameObject prefabMinotaur;
    [SerializeField]
    GameObject prefabOrge;

    public int StrengthPerWave { get; set; }

    public int CountWave { get; set; }

    public float AccumStrength { get; set; }
    public int TypeUnit { get; set; }

    private GameObject Instance;

    Timer timer;
    Unit unit;
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
                // tăng sức mạnh cho từng Unit sau mỗi wave
                IncreaseStrength();
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
                    Instance = GenerateUnit(prefabHarpy);
                    break;
                case 2:
                    Instance = GenerateUnit(prefabOrge);
                    break;
                case 3:
                    Instance = GenerateUnit(prefabMinotaur);
                    break;
                case 4:
                    Instance = GenerateUnit(prefabBanshee);
                    break;
                default: break;
            }
            // Tổng chỉ số sức mạnh của từng con, lấy tạm cái tầm đánh
            unit = Instance.GetComponent<Unit>();
            float StrengthPerUnit = (unit.Damage + unit.HitPoints / 2) + (1 + unit.Speed / 3);
            AccumStrength += StrengthPerUnit;
            if (AccumStrength > StrengthPerWave) break;
        }
    }

    public void IncreaseStrength()
    {
        Banshee banshee = prefabBanshee.GetComponent<Banshee>();
        Harpy harpy = prefabHarpy.GetComponent<Harpy>();
        //  Orge orge = prefabOrge.GetComponent<Orge>();
        //  Mage mage = prefabMage.GetComponent<Mage>();
        banshee.Damage = banshee.Damage * (1 + Banshee.damagePer);
        banshee.HitPoints = banshee.HitPoints * (1 + Banshee.hitpointsPer);
        banshee.Speed = banshee.Speed * (1 + Banshee.speedPer);

        harpy.Damage = harpy.Damage * (1 + Harpy.damagePer);
        harpy.HitPoints = harpy.HitPoints * (1 + Harpy.hitpointsPer);
        harpy.Speed = harpy.Speed * (1 + Harpy.speedPer);

        //orge.Damage = orge.Damage * (1 + OrgeOrge.damagePer);
        //orge.HitPoints = orge.HitPoints * (1 + Orge.hitpointsPer);
        //orge.Speed = orge.Speed * (1 + Orge.speedPer);

        //mage.Damage = mage.Damage * (1 + Mage.damagePer);
        //mage.HitPoints = mage.HitPoints * (1 + Mage.hitpointsPer);
        //bansmagehee.Speed = mage.Speed * (1 + Mage.speedPer);
    }
    public GameObject GenerateUnit(GameObject gameObject)
    {
        return null;
    }
}
