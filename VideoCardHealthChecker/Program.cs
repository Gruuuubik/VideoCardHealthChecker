using System;
using System.Collections.Generic;
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
				var videoCards = GetVideoCards();

				foreach (var videoCard in videoCards)
				{
					Console.WriteLine(videoCard);
				}
			}

			Console.ReadKey();
		}

		[SupportedOSPlatform("windows")]
		static IEnumerable<string> GetVideoCards()
		{
			var searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController");
			var videoCards = new List<string>();

			foreach (var queryObj in searcher.Get())
			{
				videoCards.Add(queryObj["VideoProcessor"].ToString());
			}

			return videoCards;
		}
	}
}
