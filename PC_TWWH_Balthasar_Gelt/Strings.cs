using Kingmaker.Localization;

namespace PC_TWWH_Balthasar_Gelt
{
	internal class ModStrings
	{
		public static readonly LocalizedString ModDesc = Utilities.CreateStringAll("dpgelt-desc",
			enGB: "Adds a custom, standalone soundset for male PCs and mercenaries, including custom casting lines that replace the vanilla chanting. Does not overwrite or replace any of the vanilla soundsets.",
			deDE: "Fügt ein benutzerdefiniertes, eigenständiges Soundset für männliche PCs und Söldner hinzu, einschließlich benutzerdefinierter Zauberzeilen, die die Vanilla-Gesänge ersetzen. Überschreibt oder ersetzt keines der Vanilla-Soundsets.",
			esES: "Agrega un conjunto de sonidos personalizado e independiente para los personajes masculinos y los mercenarios, incluidas las líneas de conjuros personalizadas que reemplazan los cánticos originales. No sobrescribe ni reemplaza ninguno de los conjuntos de sonidos originales.",
			frFR: "Ajoute un ensemble de sons personnalisé et autonome pour les personnages masculins et les mercenaires, y compris des lignes de casting personnalisées qui remplacent le chant de base. N'écrase ni ne remplace aucun des ensembles de sons de base.",
			itIT: "Aggiunge un set di suoni personalizzato e autonomo per i PG maschi e i mercenari, incluse le linee di lancio personalizzate che sostituiscono il canto vanilla. Non sovrascrive o sostituisce nessuno dei set di suoni vanilla.",
			plPL: "Dodaje niestandardowy, samodzielny zestaw dźwięków dla męskich postaci graczy i najemników, w tym niestandardowe linie rzucania zaklęć, które zastępują skandowanie wanilii. Nie nadpisuje ani nie zastępuje żadnego z zestawów dźwięków wanilii.",
			ptBR: "Adiciona um soundset personalizado e autônomo para PCs e mercenários masculinos, incluindo linhas de conjuração personalizadas que substituem o canto vanilla. Não sobrescreve ou substitui nenhum dos soundsets vanilla.",
			ruRU: "Добавляет пользовательский, автономный набор звуков для мужских персонажей и наемников, включая пользовательские реплики, которые заменяют ванильное пение. Не перезаписывает и не заменяет ни один из ванильных наборов звуков.",
			zhCN: "为男性 PC 和雇佣兵添加自定义独立音效，包括替换原版吟唱的自定义施法台词。不会覆盖或替换任何原版音效。"
		);

		public static readonly LocalizedString HeaderADesc = Utilities.CreateStringAll("dpgelt-headera-desc",
			enGB: "Adjust Movement Bark Values",
			deDE: "Passen Sie die Bewegungsbellwerte an",
			esES: "Ajustar los valores de ladrido de movimiento",
			frFR: "Ajuster les valeurs d'aboiement de mouvement",
			itIT: "Regola i valori della corteccia del movimento",
			plPL: "Dostosuj wartości szczekania ruchu",
			ptBR: "Ajustar valores de casca de movimento",
			ruRU: "Отрегулируйте значения коры движения",
			zhCN: "调整运动吠叫值"
		);

		public static readonly LocalizedString MoveBarkCoolDesc = Utilities.CreateStringAll("dpgelt-movebarkcooldown-desc",
			enGB: "Movement Bark Cooldown (s)",
			deDE: "Abklingzeit von Bewegungsbell (Sekunden)",
			esES: "Tiempo de recuperación de la corteza de movimiento (segundos)",
			frFR: "Temps de recharge de l'écorce de mouvement (secondes)",
			itIT: "Tempo di recupero della corteccia di movimento (secondi)",
			plPL: "Czas odnowienia ruchu Bark (sekundy)",
			ptBR: "Tempo de espera do movimento Bark (segundos)",
			ruRU: "Перезарядка движения Bark (секунды)",
			zhCN: "移动吠叫冷却时间（秒）"
		);

		public static readonly LocalizedString MoveBarkCoolDescLong = Utilities.CreateStringAll("dpgelt-movebarkcooldown-desc-long",
			enGB: "Sets the interval (in seconds) between barks when a move order is issued. Vanilla value is 10s.\n\nN.B.: May require a game restart to take effect.",
			deDE: "Legt das Intervall (in Sekunden) zwischen den Bellgeräuschen fest, wenn ein Bewegungsbefehl erteilt wird. Der Standardwert beträgt 10 s.\n\nHinweis: Es kann ein Neustart des Spiels erforderlich sein, damit die Änderung wirksam wird.",
			esES: "Establece el intervalo (en segundos) entre los ladridos cuando se emite una orden de movimiento. El valor original es 10 s.\n\nN.B.: Puede ser necesario reiniciar el juego para que tenga efecto.",
			frFR: "Définit l'intervalle (en secondes) entre les aboiements lorsqu'un ordre de déplacement est émis. La valeur standard est de 10 s.\n\nN.B. : peut nécessiter un redémarrage du jeu pour prendre effet.",
			itIT: "Imposta l'intervallo (in secondi) tra i latrati quando viene impartito un ordine di mossa. Il valore Vanilla è 10s.\n\nN.B.: Potrebbe essere necessario riavviare il gioco per avere effetto.",
			plPL: "Ustawia interwał (w sekundach) między szczeknięciami, gdy wydawany jest rozkaz ruchu. Wartość podstawowa to 10s.\n\nUwaga: Może wymagać ponownego uruchomienia gry, aby zadziałało.",
			ptBR: "Define o intervalo (em segundos) entre latidos quando uma ordem de movimento é emitida. O valor vanilla é 10s.\n\nN.B.: Pode exigir uma reinicialização do jogo para entrar em vigor.",
			ruRU: "Устанавливает интервал (в секундах) между лаянием при отдаче приказа на движение. Стандартное значение — 10 с.\n\nПримечание: для вступления в силу может потребоваться перезапуск игры.",
			zhCN: "设置发出移动命令时吠叫的间隔（以秒为单位）。原始值为 10 秒。\n\n注意：可能需要重新启动游戏才能生效。"
		);

		public static readonly LocalizedString MoveBarkProcDesc = Utilities.CreateStringAll("dpgelt-movebarkprocchance-desc",
			enGB: "Movement Bark Proc Chance (%)",
			deDE: "Chance, dass Movement Bark ausgelöst wird (%)",
			esES: "Movimiento Corteza Probabilidad de activación (%)",
			frFR: "Chance de déclenchement de l'écorce de mouvement (%)",
			itIT: "Probabilità di attivazione di Movimento Corteccia (%)",
			plPL: "Szansa na Proc. Szczekania Ruchu (%)",
			ptBR: "Chance de Proc de Latido de Movimento (%)",
			ruRU: "Шанс срабатывания лая движения (%)",
			zhCN: "移动吠叫触发几率 (%)"
		);

		public static readonly LocalizedString MoveBarkProcDescLong = Utilities.CreateStringAll("dpgelt-movebarkprocchance-desc-long",
			enGB: "The percentage chance of a bark occurring when a move order is issued. Vanilla value is 10%.\n\nN.B.: May require a game restart to take effect.",
			deDE: "Die prozentuale Wahrscheinlichkeit, dass ein Bellen ertönt, wenn ein Bewegungsbefehl erteilt wird. Der Standardwert beträgt 10 %.\n\nHinweis: Es kann ein Neustart des Spiels erforderlich sein, damit die Wirkung eintritt.",
			esES: "Porcentaje de probabilidad de que se produzca un ladrido cuando se da una orden de movimiento. El valor original es del 10 %.\n\nNota: puede ser necesario reiniciar el juego para que surta efecto.",
			frFR: "Pourcentage de chance qu'un aboiement se produise lorsqu'un ordre de déplacement est émis. La valeur de base est de 10 %.\n\nN.B. : peut nécessiter un redémarrage du jeu pour prendre effet.",
			itIT: "La percentuale di possibilità che si verifichi un abbaio quando viene impartito un ordine di movimento. Il valore Vanilla è del 10%.\n\nN.B.: Potrebbe essere necessario riavviare il gioco per avere effetto.",
			plPL: "Procentowa szansa na wystąpienie szczekania, gdy wydany zostanie rozkaz ruchu. Wartość podstawowa to 10%.\n\nUwaga: Może wymagać ponownego uruchomienia gry, aby zadziałało.",
			ptBR: "A porcentagem de chance de um latido ocorrer quando uma ordem de movimento é emitida. O valor vanilla é 10%.\n\nN.B.: Pode exigir uma reinicialização do jogo para entrar em vigor.",
			ruRU: "Процентная вероятность лая при отдаче приказа на ход. Стандартное значение — 10%.\n\nПримечание: для вступления в силу может потребоваться перезапуск игры.",
			zhCN: "发出移动命令时发生吠叫的百分比概率。原始值为 10%。\n\n注意：可能需要重新启动游戏才能生效。"
		);
	}
}
