using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;

[assembly: AssemblyVersion("1.0.1.0")]
[assembly: InternalsVisibleTo("Sandbox.Test")]
[assembly: InternalsVisibleTo("Sandbox.Game")]
[assembly: InternalsVisibleTo("Sandbox.Tools")]
[assembly: InternalsVisibleTo("Sandbox.Menu")]
[assembly: InternalsVisibleTo("Sandbox.Client")]
[assembly: InternalsVisibleTo("Sandbox.Server")]
[assembly: InternalsVisibleTo("Sandbox.Engine")]
[assembly: InternalsVisibleTo("Sandbox.Filesystem.Test")]
[assembly: InternalsVisibleTo("Sandbox.Addon.Test")]
[assembly: AssemblyCompany("Sandbox.Engine")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyFileVersion("1.0.1.0")]
[assembly: AssemblyInformationalVersion("1.0.1")]
[assembly: AssemblyProduct("Sandbox.Engine")]
[assembly: AssemblyTitle("Sandbox.Engine")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
