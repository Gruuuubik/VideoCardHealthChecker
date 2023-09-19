using System;
using System.Management;
using System.Runtime.Versioning;

namespace VideoCardHealthChecker
{
	internal class Program
	{
		static void Main()
		{
			if (OperatingSystem.IsWindows())
			{
				ShowVideoCards();
			}

			Console.ReadKey();
		}

		[SupportedOSPlatform("windows")]
		static void ShowVideoCards()
		{
			var searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController");

			foreach (var queryObj in searcher.Get())
			{
				Console.WriteLine(queryObj["VideoProcessor"]);
			}
		}
	}
}
