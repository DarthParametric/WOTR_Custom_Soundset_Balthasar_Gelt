using Kingmaker.Localization.Shared;
using Kingmaker.Localization;
using Kingmaker.Utility;
using UnityEngine;

namespace PC_TWWH_Balthasar_Gelt
{
	internal class Utilities
	{
		private static readonly List<LocalString> Strings = new();
		internal static LocalizedString EmptyString = CreateString("", "");

		internal static LocalizedString CreateString(string key, string value)
		{
			var localizedString = new LocalizedString() { m_Key = key };
			LocalizationManager.CurrentPack.PutString(key, value);
			return localizedString;
		}

		internal static LocalizedString CreateStringAll(string key, string enGB, string deDE = null, string esES = null, string frFR = null, string itIT = null, string plPL = null, string ptBR = null, string ruRU = null, string zhCN = null)
		{
			var localString = new LocalString(key, enGB, deDE, esES, frFR, itIT, plPL, ptBR, ruRU, zhCN);
			Strings.Add(localString);
			if (LocalizationManager.Initialized)
			{
				localString.Register();
			}
			return localString.LocalizedString;
		}

		private class LocalString
		{
			public readonly LocalizedString LocalizedString;
			private readonly string enGB;
			private readonly string deDE;
			private readonly string esES;
			private readonly string frFR;
			private readonly string itIT;
			private readonly string plPL;
			private readonly string ptBR;
			private readonly string ruRU;
			private readonly string zhCN;
			const string NullString = "<null>";

			public LocalString(string key, string enGB, string deDE, string esES, string frFR, string itIT, string plPL, string ptBR, string ruRU, string zhCN)
			{
				LocalizedString = new LocalizedString() { m_Key = key };

				this.enGB = enGB;
				this.deDE = deDE;
				this.esES = esES;
				this.frFR = frFR;
				this.itIT = itIT;
				this.plPL = plPL;
				this.ptBR = ptBR;
				this.ruRU = ruRU;
				this.zhCN = zhCN;
			}

			public void Register()
			{
				string localized;

				if (LocalizationManager.CurrentPack.Locale == Locale.enGB)
				{
					localized = enGB;
					goto putString;
				}

				localized = (LocalizationManager.CurrentPack.Locale) switch
				{
					Locale.deDE => deDE,
					Locale.esES => esES,
					Locale.frFR => frFR,
					Locale.itIT => itIT,
					Locale.plPL => plPL,
					Locale.ptBR => ptBR,
					Locale.ruRU => ruRU,
					Locale.zhCN => zhCN,
					_ => ""
				};

				if (localized.IsNullOrEmpty() || localized == NullString)
					localized = enGB;

				; putString:
				LocalizationManager.CurrentPack.PutString(LocalizedString.m_Key, localized);
			}
		}

		internal static Sprite CreateSprite(string embeddedImage)
		{
			var assembly = Assembly.GetExecutingAssembly();
			using var stream = assembly.GetManifestResourceStream(embeddedImage);
			byte[] bytes = new byte[stream.Length];
			stream.Read(bytes, 0, bytes.Length);
			var texture = new Texture2D(128, 128, TextureFormat.RGBA32, false);
			_ = texture.LoadImage(bytes);
			texture.name = embeddedImage + ".texture";
			// The default value for PixelsPerUnit is 1, meaning the sprite's preferred size becomes 100 times larger. So must be set to 100% manually.
			var sprite = Sprite.Create(texture, new(0, 0, texture.width, texture.height), Vector2.zero, 100);
			sprite.name = embeddedImage + ".sprite";
			return sprite;
		}
	}
}
