using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeWeaponButton : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Image _nextWeapon;
    [SerializeField] private Image _previousWeapon;
    [SerializeField] private Color _blickColor;
    [SerializeField] private float _blinkStep;
    [SerializeField] private Color _defaultColor;

    private Coroutine _changeColorJob;

    private WaitForSeconds _waitTime = new WaitForSeconds(0.01f);

    private void OnEnable()
    {
        _player.NextWeaponChanged += OnNextWeaponChanged;
        _player.PreviousWeaponChanged += OnPreviousWeaponChanged;
    }

    private void OnDisable()
    {
        _player.NextWeaponChanged -= OnNextWeaponChanged;
        _player.PreviousWeaponChanged -= OnPreviousWeaponChanged;
    }

    private void OnNextWeaponChanged()
    {
        ChangeIcon(_nextWeapon);
    }

    private void OnPreviousWeaponChanged()
    {
        ChangeIcon(_previousWeapon);
    }

    private void ChangeIcon(Image image)
    {
        if (_changeColorJob != null)
            StopCoroutine(_changeColorJob);

        _changeColorJob = StartCoroutine(Blink(image));
    }

    private IEnumerator Blink(Image image)
    {
        yield return ChangeColor(image, _blickColor);
        yield return ChangeColor(image, _defaultColor);
    }

    private IEnumerator ChangeColor(Image image, Color target)
    {
        while (image.color != target)
        {
            image.color = Color.Lerp(image.color, target, _blinkStep);
            yield return _waitTime;
        }
    }
}
