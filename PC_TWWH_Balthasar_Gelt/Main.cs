using Kingmaker;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.Blueprints.Root;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.Localization;
using Kingmaker.Sound;
using Kingmaker.Visual.Sound;
using UnityEngine;
using static UnityModManagerNet.UnityModManager;

namespace PC_TWWH_Balthasar_Gelt;

public static class Main {
	internal static Harmony HarmonyInstance;
	internal static ModEntry.ModLogger log;
	internal static ModEntry modEntry;

	public static bool Load(ModEntry modEntry)
	{
		Main.modEntry = modEntry;
		log = modEntry.Logger;
		HarmonyInstance = new Harmony(modEntry.Info.Id);
		HarmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
		return true;
	}

	public static void LogDebug(string message)
	{
#if DEBUG
			log.Log($"DEBUG: {message}");
#endif
	}

	// Create a new blueprint component to be added to the barks blueprint. This will be checked to
	// flag the caster as silent in order to disable the vanilla generic cast chanting VO, allowing
	// for custom casting VO to be fired using animation events.
	public class NoCastChants : BlueprintComponent { }

	[HarmonyPatch]
	public static class Soundbanks
	{
		[HarmonyPatch(typeof(AkAudioService), nameof(AkAudioService.Initialize))]
		[HarmonyPostfix]
		public static void AddBankPaths()
		{
			var banksPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			AkSoundEngine.AddBasePath(banksPath);
		}

		const string PreviewName = "PC_TWWH_Balthasar_Gelt_Test";
		static readonly uint TestEventId = AkSoundEngine.GetIDFromString(PreviewName);

		[HarmonyPatch(typeof(UnitAsksComponent), nameof(UnitAsksComponent.PlayPreview))]
		[HarmonyPrefix]
		static bool LoadPreviewBank(UnitAsksComponent __instance)
		{
			if (__instance.PreviewSound is not PreviewName)
				return true;

			if (!SoundBanksManager.s_Handles.Any(handle => handle.Key is PreviewName))
				SoundBanksManager.LoadBankSync(PreviewName);

			GameObject gameObject = Game.Instance.UI.Common.gameObject;
			SoundEventsManager.PostEvent(TestEventId, gameObject);

			return false;
		}

		[HarmonyPatch(typeof(BlueprintsCache), nameof(BlueprintsCache.Init))]
		[HarmonyPostfix]
		static void AddAsksListBlueprint()
		{
			// Initialise the ModMenu settings.
			ModMenuSettings.Init();

			string sProjectName = "PC_TWWH_Balthasar_Gelt";

			LocalizationManager.CurrentPack.PutString($"{sProjectName}", "Balthasar Gelt");

			var blueprint = new BlueprintUnitAsksList
			{
				AssetGuid = new(Guid.Parse("e99a8d6c75a64928ad5761567fc36bfe")),
				name = $"{sProjectName}_Barks",
				DisplayName = new() { m_Key = $"{sProjectName}" }
			};

			blueprint.ComponentsArray =
			[
				new NoCastChants() { },

				new UnitAsksComponent()
			{
				OwnerBlueprint = blueprint,

				SoundBanks = [ $"{sProjectName}_GVR_ENG" ],
				PreviewSound = $"{sProjectName}_Test",
				Aggro = new()
				{
					Entries =
					[
						new()
						{
							Text = null,
							AkEvent = $"{sProjectName}_CombatStart_01",
							RandomWeight = 0.0f,
							ExcludeTime = 2,
							m_RequiredFlags = [],
							m_ExcludedFlags = [],
							m_RequiredEtudes = null,
							m_ExcludedEtudes = null
						},
						new()
						{
							Text = null,
							AkEvent = $"{sProjectName}_CombatStart_02",
							RandomWeight = 0.0f,
							ExcludeTime = 2,
							m_RequiredFlags = [],
							m_ExcludedFlags = [],
							m_RequiredEtudes = null,
							m_ExcludedEtudes = null
						},
						new()
						{
							Text = null,
							AkEvent = $"{sProjectName}_CombatStart_03",
							RandomWeight = 0.0f,
							ExcludeTime = 2,
							m_RequiredFlags = [],
							m_ExcludedFlags = [],
							m_RequiredEtudes = null,
							m_ExcludedEtudes = null
						}
					],
					Cooldown = 0.0f,
					InterruptOthers = true,
					DelayMin = 0.0f,
					DelayMax = 0.0f,
					Chance = 1.0f,
					ShowOnScreen = false
				},
				Pain = new()
				{
					Entries =
					[
						new()
						{
							Text = null,
							AkEvent = $"{sProjectName}_Pain",
							RandomWeight = 0.0f,
							ExcludeTime = 0,
							m_RequiredFlags = [],
							m_ExcludedFlags = [],
							m_RequiredEtudes = null,
							m_ExcludedEtudes = null
						}
					],
					Cooldown = 2.0f,
					InterruptOthers = false,
					DelayMin = 0.0f,
					DelayMax = 0.0f,
					Chance = 1.0f,
					ShowOnScreen = false
				},
				Fatigue = new()
				{
					Entries =
					[
						new()
						{
							Text = null,
							AkEvent = $"{sProjectName}_Fatigue",
							RandomWeight = 0.0f,
							ExcludeTime = 0,
							m_RequiredFlags = [],
							m_ExcludedFlags = [],
							m_RequiredEtudes = null,
							m_ExcludedEtudes = null
						}
					],
					Cooldown = 60.0f,
					InterruptOthers = false,
					DelayMin = 0.0f,
					DelayMax = 0.0f,
					Chance = 1.0f,
					ShowOnScreen = false
				},
				Death = new()
				{
					Entries =
					[
						new()
						{
							Text = null,
							AkEvent = $"{sProjectName}_Death",
							RandomWeight = 0.0f,
							ExcludeTime = 0,
							m_RequiredFlags = [],
							m_ExcludedFlags = [],
							m_RequiredEtudes = null,
							m_ExcludedEtudes = null
						}
					],
					Cooldown = 0.0f,
					InterruptOthers = true,
					DelayMin = 0.0f,
					DelayMax = 0.0f,
					Chance = 1.0f,
					ShowOnScreen = false
				},
				Unconscious = new()
				{
					Entries =
					[
						new()
						{
							Text = null,
							AkEvent = $"{sProjectName}_Unconscious",
							RandomWeight = 0.0f,
							ExcludeTime = 0,
							m_RequiredFlags = [],
							m_ExcludedFlags = [],
							m_RequiredEtudes = null,
							m_ExcludedEtudes = null
						}
					],
					Cooldown = 0.0f,
					InterruptOthers = true,
					DelayMin = 0.0f,
					DelayMax = 0.0f,
					Chance = 1.0f,
					ShowOnScreen = false
				},
				LowHealth = new()
				{
					Entries =
					[
						new()
						{
							Text = null,
							AkEvent = $"{sProjectName}_LowHealth_01",
							RandomWeight = 0.0f,
							ExcludeTime = 1,
							m_RequiredFlags = [],
							m_ExcludedFlags = [],
							m_RequiredEtudes = null,
							m_ExcludedEtudes = null
						},
						new()
						{
							Text = null,
							AkEvent = $"{sProjectName}_LowHealth_02",
							RandomWeight = 0.0f,
							ExcludeTime = 1,
							m_RequiredFlags = [],
							m_ExcludedFlags = [],
							m_RequiredEtudes = null,
							m_ExcludedEtudes = null
						}
					],
					Cooldown = 10.0f,
					InterruptOthers = false,
					DelayMin = 0.0f,
					DelayMax = 0.0f,
					Chance = 1.0f,
					ShowOnScreen = false
				},
				CriticalHit = new()
				{
					Entries =
					[
						new()
						{
							Text = null,
							AkEvent = $"{sProjectName}_CharCrit_01",
							RandomWeight = 0.0f,
							ExcludeTime = 2,
							m_RequiredFlags = [],
							m_ExcludedFlags = [],
							m_RequiredEtudes = null,
							m_ExcludedEtudes = null
						},
						new()
						{
							Text = null,
							AkEvent = $"{sProjectName}_CharCrit_02",
							RandomWeight = 0.0f,
							ExcludeTime = 2,
							m_RequiredFlags = [],
							m_ExcludedFlags = [],
							m_RequiredEtudes = null,
							m_ExcludedEtudes = null
						},
						new()
						{
							Text = null,
							AkEvent = $"{sProjectName}_CharCrit_03",
							RandomWeight = 0.0f,
							ExcludeTime = 2,
							m_RequiredFlags = [],
							m_ExcludedFlags = [],
							m_RequiredEtudes = null,
							m_ExcludedEtudes = null
						}
					],
					Cooldown = 0.0f,
					InterruptOthers = false,
					DelayMin = 0.0f,
					DelayMax = 0.0f,
					Chance = 0.7f,
					ShowOnScreen = false
				},
				Order = new()
				{
					Entries =
					[
						new()
						{
							Text = null,
							AkEvent = $"{sProjectName}_AttackOrder_01",
							RandomWeight = 0.0f,
							ExcludeTime = 3,
							m_RequiredFlags = [],
							m_ExcludedFlags = [],
							m_RequiredEtudes = null,
							m_ExcludedEtudes = null
						},
						new()
						{
							Text = null,
							AkEvent = $"{sProjectName}_AttackOrder_02",
							RandomWeight = 0.0f,
							ExcludeTime = 3,
							m_RequiredFlags = [],
							m_ExcludedFlags = [],
							m_RequiredEtudes = null,
							m_ExcludedEtudes = null
						},
						new()
						{
							Text = null,
							AkEvent = $"{sProjectName}_AttackOrder_03",
							RandomWeight = 0.0f,
							ExcludeTime = 3,
							m_RequiredFlags = [],
							m_ExcludedFlags = [],
							m_RequiredEtudes = null,
							m_ExcludedEtudes = null
						},
						new()
						{
							Text = null,
							AkEvent = $"{sProjectName}_AttackOrder_04",
							RandomWeight = 0.0f,
							ExcludeTime = 3,
							m_RequiredFlags = [],
							m_ExcludedFlags = [],
							m_RequiredEtudes = null,
							m_ExcludedEtudes = null
						}
					],
					Cooldown = 0.0f,
					InterruptOthers = false,
					DelayMin = 0.0f,
					DelayMax = 0.0f,
					Chance = 1.0f,
					ShowOnScreen = false
				},
				OrderMove = new()
				{
					Entries =
					[
						new()
						{
							Text = null,
							AkEvent = $"{sProjectName}_Move_01",
							RandomWeight = 0.0f,
							ExcludeTime = 4,
							m_RequiredFlags = [],
							m_ExcludedFlags = [],
							m_RequiredEtudes = null,
							m_ExcludedEtudes = null
						},
						new()
						{
							Text = null,
							AkEvent = $"{sProjectName}_Move_02",
							RandomWeight = 0.0f,
							ExcludeTime = 4,
							m_RequiredFlags = [],
							m_ExcludedFlags = [],
							m_RequiredEtudes = null,
							m_ExcludedEtudes = null
						},
						new()
						{
							Text = null,
							AkEvent = $"{sProjectName}_Move_03",
							RandomWeight = 0.0f,
							ExcludeTime = 4,
							m_RequiredFlags = [],
							m_ExcludedFlags = [],
							m_RequiredEtudes = null,
							m_ExcludedEtudes = null
						},
						new()
						{
							Text = null,
							AkEvent = $"{sProjectName}_Move_04",
							RandomWeight = 0.0f,
							ExcludeTime = 4,
							m_RequiredFlags = [],
							m_ExcludedFlags = [],
							m_RequiredEtudes = null,
							m_ExcludedEtudes = null
						},
						new()
						{
							Text = null,
							AkEvent = $"{sProjectName}_Move_05",
							RandomWeight = 0.0f,
							ExcludeTime = 4,
							m_RequiredFlags = [],
							m_ExcludedFlags = [],
							m_RequiredEtudes = null,
							m_ExcludedEtudes = null
						},
						new()
						{
							Text = null,
							AkEvent = $"{sProjectName}_Move_06",
							RandomWeight = 0.0f,
							ExcludeTime = 2,
							m_RequiredFlags = [],
							m_ExcludedFlags = [],
							m_RequiredEtudes = null,
							m_ExcludedEtudes = null
						},
						new()
						{
							Text = null,
							AkEvent = $"{sProjectName}_Move_07",
							RandomWeight = 0.0f,
							ExcludeTime = 4,
							m_RequiredFlags = [],
							m_ExcludedFlags = [],
							m_RequiredEtudes = null,
							m_ExcludedEtudes = null
						}
					],
					Cooldown = ModMenuSettings.GetMoveCooldown(), // Default Cooldown value is 10s. Make it user-adjustable from 0-120s instead of fixed.
					InterruptOthers = false,
					DelayMin = 0.0f,
					DelayMax = 0.0f,
					Chance = ModMenuSettings.GetMoveChance(), // Default Chance value is 10%. Make it user-adjustable from 0-100% instead of fixed.
					ShowOnScreen = false
				},
				Selected = new()
				{
					Entries =
					[
						new()
						{
							Text = null,
							AkEvent = $"{sProjectName}_Select_01",
							RandomWeight = 1.0f,
							ExcludeTime = 4,
							m_RequiredFlags = [],
							m_ExcludedFlags = [],
							m_RequiredEtudes = null,
							m_ExcludedEtudes = null
						},
						new()
						{
							Text = null,
							AkEvent = $"{sProjectName}_Select_02",
							RandomWeight = 1.0f,
							ExcludeTime = 4,
							m_RequiredFlags = [],
							m_ExcludedFlags = [],
							m_RequiredEtudes = null,
							m_ExcludedEtudes = null
						},
						new()
						{
							Text = null,
							AkEvent = $"{sProjectName}_Select_03",
							RandomWeight = 1.0f,
							ExcludeTime = 4,
							m_RequiredFlags = [],
							m_ExcludedFlags = [],
							m_RequiredEtudes = null,
							m_ExcludedEtudes = null
						},
						new()
						{
							Text = null,
							AkEvent = $"{sProjectName}_Select_04",
							RandomWeight = 1.0f,
							ExcludeTime = 4,
							m_RequiredFlags = [],
							m_ExcludedFlags = [],
							m_RequiredEtudes = null,
							m_ExcludedEtudes = null
						},
						new()
						{
							Text = null,
							AkEvent = $"{sProjectName}_Select_05",
							RandomWeight = 1.0f,
							ExcludeTime = 4,
							m_RequiredFlags = [],
							m_ExcludedFlags = [],
							m_RequiredEtudes = null,
							m_ExcludedEtudes = null
						},
						new()
						{
							Text = null,
							AkEvent = $"{sProjectName}_Select_06",
							RandomWeight = 1.0f,
							ExcludeTime = 4,
							m_RequiredFlags = [],
							m_ExcludedFlags = [],
							m_RequiredEtudes = null,
							m_ExcludedEtudes = null
						},
						new()
						{
							Text = null,
							AkEvent = $"{sProjectName}_SelectJoke",
							RandomWeight = 0.1f,
							ExcludeTime = 30,
							m_RequiredFlags = [],
							m_ExcludedFlags = [],
							m_RequiredEtudes = null,
							m_ExcludedEtudes = null
						}
					],
					Cooldown = 0.0f,
					InterruptOthers = false,
					DelayMin = 0.0f,
					DelayMax = 0.0f,
					Chance = 1.0f,
					ShowOnScreen = false
				},
				RefuseEquip = new()
				{
					Entries =
					[
						new()
						{
							Text = null,
							AkEvent = $"{sProjectName}_CantEquip_01",
							RandomWeight = 1.0f,
							ExcludeTime = 2,
							m_RequiredFlags = [],
							m_ExcludedFlags = [],
							m_RequiredEtudes = null,
							m_ExcludedEtudes = null
						},
						new()
						{
							Text = null,
							AkEvent = $"{sProjectName}_CantEquip_02",
							RandomWeight = 1.0f,
							ExcludeTime = 2,
							m_RequiredFlags = [],
							m_ExcludedFlags = [],
							m_RequiredEtudes = null,
							m_ExcludedEtudes = null
						}
					],
					Cooldown = 0.0f,
					InterruptOthers = true,
					DelayMin = 0.0f,
					DelayMax = 0.0f,
					Chance = 1.0f,
					ShowOnScreen = false
				},
				RefuseCast = new()
				{
					Entries =
					[
						new()
						{
							Text = null,
							AkEvent = $"{sProjectName}_CantCast",
							RandomWeight = 0.0f,
							ExcludeTime = 1,
							m_RequiredFlags = [],
							m_ExcludedFlags = [],
							m_RequiredEtudes = null,
							m_ExcludedEtudes = null
						}
					],
					Cooldown = 0.0f,
					InterruptOthers = true,
					DelayMin = 0.0f,
					DelayMax = 0.0f,
					Chance = 1.0f,
					ShowOnScreen = false
				},
				CheckSuccess = new()
				{
					Entries =
					[
						new()
						{
							Text = null,
							AkEvent = $"{sProjectName}_CheckSuccess_01",
							RandomWeight = 1.0f,
							ExcludeTime = 2,
							m_RequiredFlags = [],
							m_ExcludedFlags = [],
							m_RequiredEtudes = null,
							m_ExcludedEtudes = null
						},
						new()
						{
							Text = null,
							AkEvent = $"{sProjectName}_CheckSuccess_02",
							RandomWeight = 1.0f,
							ExcludeTime = 2,
							m_RequiredFlags = [],
							m_ExcludedFlags = [],
							m_RequiredEtudes = null,
							m_ExcludedEtudes = null
						}
					],
					Cooldown = 0.0f,
					InterruptOthers = false,
					DelayMin = 0.0f,
					DelayMax = 0.0f,
					Chance = 1.0f,
					ShowOnScreen = false
				},
				CheckFail = new()
				{
					Entries =
					[
						new()
						{
							Text = null,
							AkEvent = $"{sProjectName}_CheckFail_01",
							RandomWeight = 1.0f,
							ExcludeTime = 2,
							m_RequiredFlags = [],
							m_ExcludedFlags = [],
							m_RequiredEtudes = null,
							m_ExcludedEtudes = null
						},
						new()
						{
							Text = null,
							AkEvent = $"{sProjectName}_CheckFail_02",
							RandomWeight = 1.0f,
							ExcludeTime = 2,
							m_RequiredFlags = [],
							m_ExcludedFlags = [],
							m_RequiredEtudes = null,
							m_ExcludedEtudes = null
						}
					],
					Cooldown = 0.0f,
					InterruptOthers = false,
					DelayMin = 0.0f,
					DelayMax = 0.0f,
					Chance = 1.0f,
					ShowOnScreen = false
				},
				RefuseUnequip = new()
				{
					Entries = [],
					Cooldown = 0.0f,
					InterruptOthers = false,
					DelayMin = 0.0f,
					DelayMax = 0.0f,
					Chance = 1.0f,
					ShowOnScreen = false
				},
				Discovery = new()
				{
					Entries =
					[
						new()
						{
							Text = null,
							AkEvent = $"{sProjectName}_Discovery_01",
							RandomWeight = 0.0f,
							ExcludeTime = 1,
							m_RequiredFlags = [],
							m_ExcludedFlags = [],
							m_RequiredEtudes = null,
							m_ExcludedEtudes = null
						},
						new()
						{
							Text = null,
							AkEvent = $"{sProjectName}_Discovery_02",
							RandomWeight = 0.0f,
							ExcludeTime = 1,
							m_RequiredFlags = [],
							m_ExcludedFlags = [],
							m_RequiredEtudes = null,
							m_ExcludedEtudes = null
						}
					],
					Cooldown = 0.0f,
					InterruptOthers = false,
					DelayMin = 0.0f,
					DelayMax = 0.0f,
					Chance = 1.0f,
					ShowOnScreen = false
				},
				Stealth = new()
				{
					Entries =
					[
						new()
						{
							Text = null,
							AkEvent = $"{sProjectName}_StealthMode",
							RandomWeight = 1.0f,
							ExcludeTime = 1,
							m_RequiredFlags = [],
							m_ExcludedFlags = [],
							m_RequiredEtudes = null,
							m_ExcludedEtudes = null
						}
					],
					Cooldown = 0.0f,
					InterruptOthers = false,
					DelayMin = 0.0f,
					DelayMax = 0.0f,
					Chance = 1.0f,
					ShowOnScreen = false
				},
				StormRain = new()
				{
					Entries = [],
					Cooldown = 0.0f,
					InterruptOthers = false,
					DelayMin = 0.0f,
					DelayMax = 0.0f,
					Chance = 1.0f,
					ShowOnScreen = false
				},
				StormSnow = new()
				{
					Entries = [],
					Cooldown = 0.0f,
					InterruptOthers = false,
					DelayMin = 0.0f,
					DelayMax = 0.0f,
					Chance = 1.0f,
					ShowOnScreen = false
				},
				AnimationBarks =
				[
					new()
					{
						Entries =
						[
							new()
							{
								Text = null,
								AkEvent = $"{sProjectName}_AttackShort",
								RandomWeight = 0.0f,
								ExcludeTime = 0,
								m_RequiredFlags = [],
								m_ExcludedFlags = [],
								m_RequiredEtudes = null,
								m_ExcludedEtudes = null
							}
						],
						Cooldown = 0.0f,
						InterruptOthers = false,
						DelayMin = 0.0f,
						DelayMax = 0.0f,
						Chance = 0.7f,
						ShowOnScreen = false,
						AnimationEvent = MappedAnimationEventType.AttackShort
					},
					new()
					{
						Entries =
						[
							new()
							{
								Text = null,
								AkEvent = $"{sProjectName}_CoupDeGrace",
								RandomWeight = 0.0f,
								ExcludeTime = 0,
								m_RequiredFlags = [],
								m_ExcludedFlags = [],
								m_RequiredEtudes = null,
								m_ExcludedEtudes = null
							}
						],
						Cooldown = 0.0f,
						InterruptOthers = true,
						DelayMin = 0.0f,
						DelayMax = 0.0f,
						Chance = 1.0f,
						ShowOnScreen = false,
						AnimationEvent = MappedAnimationEventType.CoupDeGrace
					},
					new()
					{
						Entries =
						[
							new()
							{
								Text = null,
								AkEvent = $"{sProjectName}_Cast",
								RandomWeight = 0.0f,
								ExcludeTime = 0,
								m_RequiredFlags = [],
								m_ExcludedFlags = [],
								m_RequiredEtudes = null,
								m_ExcludedEtudes = null
							}
						],
						Cooldown = 0.0f,
						InterruptOthers = true,
						DelayMin = 0.0f,
						DelayMax = 0.0f,
						Chance = 1.0f,
						ShowOnScreen = false,
						AnimationEvent = MappedAnimationEventType.Cast
					},
					new()
					{
						Entries =
						[
							new()
							{
								Text = null,
								AkEvent = $"{sProjectName}_CastDirect",
								RandomWeight = 0.0f,
								ExcludeTime = 0,
								m_RequiredFlags = [],
								m_ExcludedFlags = [],
								m_RequiredEtudes = null,
								m_ExcludedEtudes = null
							}
						],
						Cooldown = 0.0f,
						InterruptOthers = true,
						DelayMin = 0.0f,
						DelayMax = 0.0f,
						Chance = 1.0f,
						ShowOnScreen = false,
						AnimationEvent = MappedAnimationEventType.CastDirect
					},
					new()
					{
						Entries =
						[
							new()
							{
								Text = null,
								AkEvent = $"{sProjectName}_CastLong",
								RandomWeight = 0.0f,
								ExcludeTime = 0,
								m_RequiredFlags = [],
								m_ExcludedFlags = [],
								m_RequiredEtudes = null,
								m_ExcludedEtudes = null
							}
						],
						Cooldown = 0.0f,
						InterruptOthers = true,
						DelayMin = 0.0f,
						DelayMax = 0.0f,
						Chance = 1.0f,
						ShowOnScreen = false,
						AnimationEvent = MappedAnimationEventType.CastLong
					},
					new()
					{
						Entries =
						[
							new()
							{
								Text = null,
								AkEvent = $"{sProjectName}_CastShort",
								RandomWeight = 0.0f,
								ExcludeTime = 0,
								m_RequiredFlags = [],
								m_ExcludedFlags = [],
								m_RequiredEtudes = null,
								m_ExcludedEtudes = null
							}
						],
						Cooldown = 0.0f,
						InterruptOthers = true,
						DelayMin = 0.0f,
						DelayMax = 0.0f,
						Chance = 1.0f,
						ShowOnScreen = false,
						AnimationEvent = MappedAnimationEventType.CastShort
					},
					new()
					{
						Entries =
						[
							new()
							{
								Text = null,
								AkEvent = $"{sProjectName}_CastTouch",
								RandomWeight = 0.0f,
								ExcludeTime = 0,
								m_RequiredFlags = [],
								m_ExcludedFlags = [],
								m_RequiredEtudes = null,
								m_ExcludedEtudes = null
							}
						],
						Cooldown = 0.0f,
						InterruptOthers = true,
						DelayMin = 0.0f,
						DelayMax = 0.0f,
						Chance = 1.0f,
						ShowOnScreen = false,
						AnimationEvent = MappedAnimationEventType.CastTouch
					},
					new()
					{
						Entries =
						[
							new()
							{
								Text = null,
								AkEvent = $"{sProjectName}_CastYourself",
								RandomWeight = 0.0f,
								ExcludeTime = 0,
								m_RequiredFlags = [],
								m_ExcludedFlags = [],
								m_RequiredEtudes = null,
								m_ExcludedEtudes = null
							}
						],
						Cooldown = 0.0f,
						InterruptOthers = true,
						DelayMin = 0.0f,
						DelayMax = 0.0f,
						Chance = 1.0f,
						ShowOnScreen = false,
						AnimationEvent = MappedAnimationEventType.CastYourself
					},
					new()
					{
						Entries =
						[
							new()
							{
								Text = null,
								AkEvent = $"{sProjectName}_Omnicast",
								RandomWeight = 0.0f,
								ExcludeTime = 0,
								m_RequiredFlags = [],
								m_ExcludedFlags = [],
								m_RequiredEtudes = null,
								m_ExcludedEtudes = null
							}
						],
						Cooldown = 0.0f,
						InterruptOthers = true,
						DelayMin = 0.0f,
						DelayMax = 0.0f,
						Chance = 1.0f,
						ShowOnScreen = false,
						AnimationEvent = MappedAnimationEventType.Omnicast
					},
					new()
					{
						Entries =
						[
							new()
							{
								Text = null,
								AkEvent = $"{sProjectName}_Precast",
								RandomWeight = 0.0f,
								ExcludeTime = 0,
								m_RequiredFlags = [],
								m_ExcludedFlags = [],
								m_RequiredEtudes = null,
								m_ExcludedEtudes = null
							}
						],
						Cooldown = 0.0f,
						InterruptOthers = true,
						DelayMin = 0.0f,
						DelayMax = 0.0f,
						Chance = 1.0f,
						ShowOnScreen = false,
						AnimationEvent = MappedAnimationEventType.Precast
					},
				],
			},
			];

				ResourcesLibrary.BlueprintsCache.AddCachedBlueprint(blueprint.AssetGuid, blueprint);
				blueprint.OnEnable();

				BlueprintRoot.Instance.CharGen.m_MaleVoices = BlueprintRoot.Instance.CharGen.m_MaleVoices
					.Append(blueprint.ToReference<BlueprintUnitAsksListReference>())
					.ToArray();
		}

		// In order to prevent the vanilla casting chants from playing when using custom chant events, the default check the
		// game does on the caster is patched, flagging the caster as silent if they have the No Chants blueprint component.
		[HarmonyPatch(typeof(UnitEntityData), nameof(UnitEntityData.SilentCaster), MethodType.Getter)]
		[HarmonyPostfix]
		static void Patch(ref bool __result, UnitEntityData __instance)
		{
			if (__instance.Descriptor.Asks.GetComponent<NoCastChants>() is not null)
			{
				__result = true;
			}
		}

	}
}