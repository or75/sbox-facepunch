using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using Sandbox;

[assembly: AssemblyVersion("1.0.1.0")]
[assembly: InternalsVisibleTo("Sandbox.Test")]
[assembly: InternalsVisibleTo("Sandbox.Menu")]
[assembly: InternalsVisibleTo("Sandbox.Client")]
[assembly: InternalsVisibleTo("Sandbox.Server")]
[assembly: TasksPersistOnContextReset]
[assembly: AssemblyCompany("Sandbox.Game")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyFileVersion("1.0.1.0")]
[assembly: AssemblyInformationalVersion("1.0.1")]
[assembly: AssemblyProduct("Sandbox.Game")]
[assembly: AssemblyTitle("Sandbox.Game")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
