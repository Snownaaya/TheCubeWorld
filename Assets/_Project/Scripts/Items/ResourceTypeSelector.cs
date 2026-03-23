namespace Assets.Scripts.Items
{
    using System;
    using Random = UnityEngine.Random;

    public static class ResourceTypeSelector
    {
        public static ResourceTypes GetRandomTypes() =>
            (ResourceTypes)Random.Range(0, Enum.GetValues(typeof(ResourceTypes)).Length);
    }
}