// Guids.cs
// MUST match guids.h
using System;

namespace VSJamSession.VSThrowawayPackage
{
    static class GuidList
    {
        public const string guidVSThrowawayPackagePkgString = "5861a8ab-50aa-4df0-9b51-1a2c6d302e57";
        public const string guidVSThrowawayPackageCmdSetString = "6c0ded4e-a9d4-409d-a30e-ca1eb8afd4ef";
        public const string guidToolWindowPersistanceString = "3d89b393-76f8-4f3b-a7de-f1af36ccef54";
        public const string guidVSThrowawayPackageEditorFactoryString = "e160ee17-1f2a-45a6-bae7-2e3e35669a2a";

        public static readonly Guid guidVSThrowawayPackageCmdSet = new Guid(guidVSThrowawayPackageCmdSetString);
        public static readonly Guid guidVSThrowawayPackageEditorFactory = new Guid(guidVSThrowawayPackageEditorFactoryString);
    };
}