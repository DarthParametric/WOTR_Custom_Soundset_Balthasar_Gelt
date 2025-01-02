using Kingmaker.Localization;
using ModMenu.Settings;

namespace PC_TWWH_Balthasar_Gelt {
	public static class ModMenuSettings
	{
		private static bool Initialized = false;

		private static readonly string RootKey = "dpgeltvoice";
		public static readonly string HeaderA = "dpgelt-headera";
		public static readonly string MoveBarkCool = "dpgelt-movebarkcooldown";
		public static readonly string MoveBarkProc = "dpgelt-movebarkprocchance";

		private static SettingsBuilder MMSettings = SettingsBuilder.New(RootKey, GetString(GetKey("dpgelt-title"), "Balthasar Gelt Soundset"));

		public static void Init()
		{
			if (Initialized)
			{
				Main.LogDebug("ModMenu settings already initialised");
				return;
			}

			Main.log.Log("Initialising ModMenu settings");

			MMSettings.SetMod(Main.modEntry);
			MMSettings.SetModDescription(ModStrings.ModDesc);
			MMSettings.SetModIllustration(Utilities.CreateSprite("PC_TWWH_Balthasar_Gelt.Img.Logo.png"));

			var MoveBarkSection = MMSettings.AddSubHeader(ModStrings.HeaderADesc, true);

			MoveBarkSection.AddSliderFloat(
				SliderFloat.New(
					GetKey(MoveBarkCool),
					defaultValue: 10.0f,
					ModStrings.MoveBarkCoolDesc,
					minValue: 0.0f,
					maxValue: 120.0f)
				.WithLongDescription(ModStrings.MoveBarkCoolDescLong)
			);

			MoveBarkSection.AddSliderInt(
				SliderInt.New(
					GetKey(MoveBarkProc),
					defaultValue: 10,
					ModStrings.MoveBarkProcDesc,
					minValue: 0,
					maxValue: 100)
				.WithLongDescription(ModStrings.MoveBarkProcDescLong)
			);

			ModMenu.ModMenu.AddSettings(MMSettings);
			Initialized = true;
			Main.log.Log("ModMenu settings initialisation complete");
		}

		private static string GetKey(string partialKey)
		{
			return $"{RootKey}.{partialKey}";
		}

		private static LocalizedString GetString(string partialKey, string text)
		{
			return Utilities.CreateString(GetKey(partialKey), text);
		}

		internal static float GetMoveCooldown()
		{
			float result = ModMenu.ModMenu.GetSettingValue<float>(GetKey(MoveBarkCool));
			Main.LogDebug($"UnitAsksList requested value of the Move bark cooldown slider: {result}s");
			return result;
		}

		internal static float GetMoveChance()
		{
			int value = ModMenu.ModMenu.GetSettingValue<int>(GetKey(MoveBarkProc));
			float result = (float)value;
			Main.LogDebug($"UnitAsksList requested value of the Move bark proc chance slider: {value}% (Output: {result})");
			return value;
		}
	}
}
