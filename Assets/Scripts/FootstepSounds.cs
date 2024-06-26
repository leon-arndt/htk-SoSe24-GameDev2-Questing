using UnityEngine;

/// <summary>
/// Detect the terrain under the GameObject
/// Play sounds using `PlayFootstep` e.g. from animation events
/// </summary>
public class FootstepSounds : MonoBehaviour
{
    private enum Terrain
    {
        Concrete,
        Gravel,
        WoodFloor
    };

    [SerializeField] private Terrain terrain;

    private FMOD.Studio.EventInstance foosteps;
    private const float _raycastDistance = 10f;


    /// <summary>
    /// Call this method from animation events to trigger them
    /// </summary>
    public void PlayFootstep()
    {
        UpdateTerrain();
        foosteps = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/SFX_Footsteps");
        foosteps.setParameterByName("Terrain", (int)terrain);
        foosteps.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        foosteps.start();
        foosteps.release();
    }

    private void UpdateTerrain()
    {
        var rayhit = Physics.RaycastAll(transform.position, Vector3.down, _raycastDistance)[0];

        if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Gravel"))
        {
            terrain = Terrain.Gravel;
        }
        else if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Wood"))
        {
            terrain = Terrain.WoodFloor;
        }
        else if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Grass"))
        {
            terrain = Terrain.Concrete;
        }
    }
}