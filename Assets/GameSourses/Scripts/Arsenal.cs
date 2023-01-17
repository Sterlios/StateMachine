using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
class Arsenal
{
    [SerializeField] private List<Weapon> _weapons;

    public Arsenal()
    {
        _weapons = new List<Weapon>();
    }

    public void GetNextWeapon(ref Weapon currentWeapon)
    {
        if (_weapons.Count > 0)
            ExchangeWeapon(ref currentWeapon, 0, _weapons.Count);
    }

    public void GetPreviousWeapon(ref Weapon currentWeapon)
    {
        if (_weapons.Count > 0)
            ExchangeWeapon(ref currentWeapon, _weapons.Count, 0);
    }

    public bool TryAddWeapon(Weapon newWeapon)
    {
        foreach(var weapon in _weapons)
            if (weapon.Name.Equals(newWeapon.Name))
                return false;

        _weapons.Add(newWeapon);

        return true;
    }

    private void ExchangeWeapon(ref Weapon currentWeapon, int insertIndex, int gettingIndex)
    {
        _weapons.Insert(insertIndex, currentWeapon);

        currentWeapon = _weapons[gettingIndex];
        _weapons.RemoveAt(gettingIndex);
    }
}