using System.Collections.Generic;
using UnityEngine;

namespace Core.AssetLoaderModule.Core.Scripts {
    [SerializeField]
    public class ResourcesGroupHandleContainer {
        public readonly Dictionary<string, ResourceRequest> CompletedHandles = new();
        public readonly Dictionary<string, List<ResourceRequest>> AllHandles = new();
    }
}