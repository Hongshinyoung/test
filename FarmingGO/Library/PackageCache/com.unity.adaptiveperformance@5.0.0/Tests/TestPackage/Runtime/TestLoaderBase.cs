using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.AdaptivePerformance;
using UnityEngine.AdaptivePerformance.Provider;
#endif

using UnityEngine.AdaptivePerformance.Tests.Standalone;

namespace UnityEngine.AdaptivePerformance.TestPackage
{
    public class TestLoaderBase : AdaptivePerformanceLoaderHelper
    {
#if UNITY_EDITOR
        public TestLoaderBase()
        {
            WasAssigned = false;
            WasUnassigned = false;
        }

        public static bool WasAssigned { get; set; }
        public static bool WasUnassigned { get; set; }
#endif
        static List<AdaptivePerformanceSubsystemDescriptor> s_StandaloneSubsystemDescriptors =
            new List<AdaptivePerformanceSubsystemDescriptor>();

        public override bool Initialized
        {
            get { return inputSubsystem != null; }
        }

        public override bool Running
        {
            get { return inputSubsystem != null && inputSubsystem.running; }
        }

        public StandaloneSubsystem inputSubsystem
        {
            get { return GetLoadedSubsystem<StandaloneSubsystem>(); }
        }

        public override ISubsystem GetDefaultSubsystem()
        {
            return GetLoadedSubsystem<StandaloneSubsystem>();
        }

        public override IAdaptivePerformanceSettings GetSettings()
        {
            TestSettings settings = null;
            // When running in the Unity Editor, we have to load user's customization of configuration data directly from
            // EditorBuildSettings. At runtime, we need to grab it from the static instance field instead.
#if UNITY_EDITOR
            UnityEditor.EditorBuildSettings.TryGetConfigObject(Constants.k_SettingsKey, out settings);
#else
            settings = TestSettings.s_RuntimeInstance;
#endif
            return settings;
        }

        #region AdaptivePerformanceLoader API Implementation

        /// <summary>Implementaion of <see cref="AdaptivePerformanceLoader.Initialize"/></summary>
        /// <returns>True if successful, false otherwise</returns>
        public override bool Initialize()
        {
            IAdaptivePerformanceSettings settings = GetSettings();
            if (settings != null)
            {
                // TODO: Pass settings off to plugin prior to subsystem init.
            }

            CreateSubsystem<AdaptivePerformanceSubsystemDescriptor, StandaloneSubsystem>(s_StandaloneSubsystemDescriptors, "Standalone Subsystem");

            return false;
        }

        /// <summary>Implementaion of <see cref="AdaptivePerformanceLoader.Start"/></summary>
        /// <returns>True if successful, false otherwise</returns>
        public override bool Start()
        {
            StartSubsystem<StandaloneSubsystem>();
            return true;
        }

        /// <summary>Implementaion of <see cref="AdaptivePerformanceLoader.Stop"/></summary>
        /// <returns>True if successful, false otherwise</returns>
        public override bool Stop()
        {
            StopSubsystem<StandaloneSubsystem>();
            return true;
        }

        /// <summary>Implementaion of <see cref="AdaptivePerformanceLoader.Deinitialize"/></summary>
        /// <returns>True if successful, false otherwise</returns>
        public override bool Deinitialize()
        {
            DestroySubsystem<StandaloneSubsystem>();
            return true;
        }

#if UNITY_EDITOR
        public override void WasAssignedToBuildTarget(BuildTargetGroup buildTargetGroup)
        {
            WasAssigned = true;
        }

        public override void WasUnassignedFromBuildTarget(BuildTargetGroup buildTargetGroup)
        {
            WasUnassigned = true;
        }

#endif
        #endregion
    }
}
