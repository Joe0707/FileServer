namespace GlobalDefine{
	/** 单参数：单参数值，只有key:value形式 */
	public class CONST{
		/** 该字段代码没用，目的是被转换成类 */
		public const string None = "none";
		/** 默认初始化的actor数据ID */
		public const long DefaultActorId = 10001;
		/** 第一个关卡ID,测试协议使用，默认关卡ID */
		public const long DefaultLevelId = 10001;
		/** 技能插槽个数最大值 */
		public const long SkillMaxSlots = 6;
		/** 给角色的默认被动技能ID */
		public const long SkillIdBeiDong = 2908;
		/** 给角色的默认AP技能ID */
		public const long SkillIdAp = 52403;
		/** 角色默认装备ID */
		public const long EquipDefaultId = 10001;
		/** 设置角色默认最大AP值 */
		public const long MaxAp = 3;
		/** 倍数基数 */
		public const long PERCENT_ONE = 10000;
		/** 带小数点的属性基础数值 */
		public const long PROP_PERCENT_ONE = 100;
		/**道具ID组成部分乘以的系数,道具ID生成规则：背包类型*系数+对应表(例如装备)的道具ID */
		public const long ItemIdRate = 1000000;
		/**根据装备类型获取槽位类型时要除以的系数 */
		public const long EquipSlotTypeRate = 1000;
		/**装备洗炼最大次数 */
		public const long EquipmentRefinementMax = 20;
		/**邮件一页的数量 */
		public const long MailNumberOfPage = 4;
		/**账号默认地图ID(新建账号默认值) */
		public const long DefaultMapId = 1;
		/**账号默认地图点ID(新建账号默认值) */
		public const long DefaultMapPointId = 101335;
		/**转职非特产国消耗提升倍数 */
		public const double ChangeJobConsumeUp = 1.5;
		/**账号默认主线任务ID */
		public const long DefaultMainTaskId = 100001;
		/**军团buff类型id */
		public const long LegionBuffType = 6;
		/**开启委托派遣任务城堡的开启等级 */
		public const long OpenEntrustCastleLevel = 3;
		/**征兵阵亡回信类型 */
		public const long ConscriptionDeadReply = 4;
		/**排行榜时间戳积分上限 */
		public const long RankTimestampMaxScore = 9999999999999;
		/**时间戳积分占比 */
		public const long RankTimestampScoreProportion = 10000000000000;
		/**血脉百分比转换系数 */
		public const long BloodRatioPercent = 10000;
	}

	/**触发器全局类型
     * [编辑器生成数据使用类型不能随便加类型]
     */
	public enum GlobalTriggerType{
		/**战斗胜利触发器 */
		BattleWin = 0, 
		/**战斗失败触发器 */
		BattleLose = 1, 
		/**通用*/
		Common = 2, 
		/**剧情 */
		Story = 3, 
	}

	/**血脉类型,同Descent表 */
	public enum DescentType{
		/**赫尔沃 */
		Holvo = 1, 
		/**索勒斯 */
		Solles = 2, 
		/**赫拉希诺 */
		Heracino = 3, 
		/**巴拉赞 */
		Balazan = 4, 
		/**金尼斯 */
		Guinness = 5, 
		/**雪山遗民 */
		SnowMountainRemnant = 6, 
		/**弗瑞莫德 */
		Fremod = 7, 
		/**沃尔加德 */
		Volgard = 8, 
		/**欧塔鲁特 */
		Otarute = 9, 
		/**科尼托 */
		Konito = 10, 
		/**艾德勒斯 */
		Edlers = 11, 
		/**埃非勒姆 */
		Eifelem = 12, 
		/**日出之子 */
		SonSunrise = 13, 
		/**普瑞帕恩 */
		Prieparn = 14, 
	}

	/** 触发条件 (代表Attr键)[代表Attr值类型]
     *  [编辑器生成数据使用类型不能随便加类型]
     */
	public enum EConditionType{
		/**角色GID为(entityGid)的角色死亡时*/
		EntityGidTargetDeed = -1, 
		/** 无 */
		None = 0, 
		/**条件组*/
		ConditionGroupConfig = 1, 
		/**战斗场景状态为(FightStatus)[EFightStatus]时 */
		FightScenetStatusConditionConfig = 2, 
		/**坚持回合数为(roundNumber)[int]*/
		KeepRoundConditionConfig = 3, 
		/**角色木桩Id((RoleId)[string]到达(SlotIndex)[int]*/
		RoleArriveEventConditionConfig = 4, 
		/**[RoleId: 角色出生位置ID\出生的角色的属性[Property: ConstantsClient.EActorAttrType]值小等于[Limit: 最低值限制]*/
		RoleInfoEventConditionConfig = 5, 
		/**角色木桩Id((RoleGid)[string]不能死亡*/
		RoleNoDeathConditionConfig = 6, 
		/**角色木桩Id((roleGid)[string]不能撤离*/
		RoleNoRunConditionConfig = 7, 
		/**角色木桩Id((roleGid)[string]撤离*/
		RoleRunConditionConfig = 8, 
		/**(Team)[ETeamType]阵营在回合数(RoundNumber)[int]的回合状态(RoundStatus)[ERoundStatus]时*/
		RoundEventConditionConfig = 9, 
		/**部队(Team)[ETeamType]撤离格子(SlotIndex)[int]*/
		RunConditionConfig = 10, 
		/**(CurScene)[ESceneType]切换到(NextScene)[ESceneType]*/
		SceneChangeEventConditionConfig = 11, 
		/**格子(SlotIndex)[int]的状态(StatusType)[EStatusType]的id号是(StatusId)[string]*/
		StatusConditionConfig = 12, 
		/**部队(deathTeam)[ETeamType]全灭*/
		TeamDeathConditionConfig = 13, 
		/**部队(team)[ETeamType]不能有成员死亡*/
		TeamNoDeathConditionConfig = 14, 
		/**部队(runTeam)[ETeamType]不能撤离条件*/
		TeamNoRunConditionConfig = 15, 
		/**部队(runTeam)[ETeamType]撤离条件*/
		TeamRunConditionConfig = 16, 
		/**职业Id(JobId)[int]击杀角色木桩id(RoleId)[string]条件*/
		JobKillRoleConditionConfig = 17, 
		/**战斗场景内真实玩家全部不能操作*/
		AllRealPlayerNotActive = 18, 
		/**角色木桩Id(RoleId)[string]到达HP值(HPValue)[float]时或到达HP百分比(HPPercent)[float]时触发*/
		RoleHPConditionConfig = 19, 
		/**角色木桩Id((RoleId)[string]到达多个指定格子(SlotIndexes)[string](注:多组用","分割)时触发*/
		RoleArriveSlotsEventConditionConfig = 20, 
	}

	/** 触发结果 (代表Attr键)[代表Attr值类型]
     *  触发结果 (属性字典的键名)[字典中键对应值的类型]所有类型的属性字典中共同的属性是 键:SameTimeAsPre 值类型:bool
     *  [编辑器生成数据使用类型不能随便加类型]
     */
	public enum EResultType{
		/**移除镜像角色并将召唤者重新入场*/
		DelMirrorRecoverSummoner = -1, 
		/** 无 */
		None = 0, 
		/**部队(Team)[ETeamType]在格子(SlotIndex)[int]撤离*/
		AddRunSlotEventResultConfig = 1, 
		/**战斗失败结果*/
		BattleFailedResultConfig = 2, 
		/**战斗胜利结果*/
		BattleWinResultConfig = 3, 
		/**角色木桩Id(CallRoleId)[string]通过(CallType)[ECallType]召唤 召唤的格子(SlotIndex)[int] 被召唤的角色木桩Id(RoleIdCalled)[string] 通知服务器参数:若目标格子上已有角色paramList.teamGid[string]，角色teamGid移动至(paramList.moveTileIndex)[int]*/
		CallEventResultConfig = 4, 
		/**相机焦点结束事件*/
		CameraFocusEndEventResultConfig = 5, 
		/**相机聚焦到角色木桩Id(RoleID)[string]身上 聚焦事件(Move2FocusTime)[float]相机焦点位置(EndPosition)[Value3] 相机焦点旋转角(EndRotation)[Value3] 相机尺寸(EndCameraSize)[float]*/
		CameraFocusEventResultConfig = 6, 
		/**相机移动到(EndPosition)[Value3] 角度(EndRotation)[Value3] 尺寸(EndCameraSize)[float] 移动时长(MoveTime)[float]*/
		CameraMoveEventResultConfig = 7, 
		/**相机放置到(CameraPosition)[Value3] 角度(CameraRotation)[Value3] 尺寸(CameraSize)[float]*/
		CameraPlaceEventResultConfig = 8, 
		/**角色木桩Id(RoleId)[string]更改AIID(AIId)[string]*/
		ChangeAIEventResultConfig = 9, 
		/**更改BGM(BGMId)[string]*/
		ChangeBGMEventResultConfig = 10, 
		/**更改格子(SlotIndex)[int]元件(ElementId)[string]事件*/
		ChangeSlotElementEventResultConfig = 11, 
		/**角色木桩Id(RoleId)[string]更换阵营(Team)[ETeamType]事件*/
		ChangeTeamEventResultConfig = 12, 
		/**变更胜利条件(WinId)[string]*/
		ChangeWinEventResultConfig = 13, 
		/**角色木桩Id(RoleId)[string]删除事件*/
		DeleteRoleEventResultConfig = 14, 
		/**角色木桩Id(RoleId)[string]死亡事件*/
		RoleDeathEventResultConfig = 15, 
		/**角色木桩Id(RoleId)[string]离开 离场格子(LevelSlotIndex)[int]*/
		RoleLeaveEventResultConfig = 16, 
		/**角色木桩Id(RoleId)[string] 移动到格子(SlotIndex)[int] 若目标格子上已有角色paramList.teamGid[string]，角色teamGid移动至(paramList.moveTileIndex)[int] */
		RoleMoveEventResultConfig = 17, 
		/**释放技能 来自角色木桩Id(FromId)[string] 目标角色木桩Id(ToId)[string] 技能Id(SkillId)[string] 伤害值(DamageValue)[float] 伤害百分比(DamagePercent)[float] 技能使用类型(UseType)[ESkillUseType] 技能受击类型(BeHitType)[ESkillBeHitType]*/
		SkillEventResultConfig = 18, 
		/**状态切换为(StatusType)[EStatusType]*/
		StatusResultConfig = 19, 
		/**发起文字事件 Id(StringId)[string]*/
		TextEventResultConfig = 20, 
		/**(Active)[bool]激活边界数据(Index)[int]*/
		SetActiveEdgeValueResultConfig = 21, 
		/**角色(ActorId)[string]或者在队伍位置(PositionInTeam)[int]的角色 在位置(Position)[Value3]生成*/
		RoleBornEventResultConfig = 22, 
		/** 开始剧情*/
		BeginStoryResultConfig = 23, 
		/** 结束剧情*/
		EndStoryResultConfig = 24, 
		/**摄像机初始位置变更为位置(Position)[Value3] 角度(Rotation)[Value3] 尺寸(CameraSize)[float] */
		CameraInitPositionSetEventResultConfig = 25, 
		/**角色HP更改事件 (RoleId)[string] 更改值为 (ChangeValue)[float]默认为-1或者更改百分比为(ChangePercent)[float]默认为-1 血量变化类型为(ChangeType)[ESkillUseType]*/
		RoleHPChangeEventResultConfig = 26, 
		/**角色BuffDebuff更改事件 (RoleId)[string] 添加Buff(BuffAddId)[string] 添加Debuff(DebuffAddId)[string]*/
		RoleBuffDebuffAddResultConfig = 27, 
		/**场外角色(OutsideRoleId)[string]入场 格子索引(SlotIndex)[int] 若目标格子上已有角色paramList.teamGid[string]，角色teamGid移动至(paramList.moveTileIndex)[int] */
		OutsideRoleInEventResultConfig = 28, 
		/**同时结果组 子结果数组里有同时播的事件集(SubResults)[TriggerResultDataModel[]]*/
		ResultGroup = 29, 
		/**角色木桩Id(RoleId)[string] 移动到位置(Position)[Value3] */
		RoleMove2PositionEventResultConfig = 30, 
		/**角色木桩Id(RoleId)[string] 移动到目标角色(TargetId)[string] 两角色间隔格子数为(RolesSlotInterval)[int] 通知服务器参数:角色移至的格子号是role2TileIndex[int]，若目标格子上已有角色paramList.teamGid[string]，角色teamGid移动至(paramList.moveTileIndex)[int] */
		RoleMove2RoleEventResultConfig = 31, 
		/** 战斗结束 战斗结果视作胜利但不弹出胜利、结算弹出框 执行下一步任务流程*/
		BattleEndResultConfig = 32, 
	}

	public enum BattleSceneResultType{
		/**加载剧情列表第param[0]剧情步骤*/
		loadScenario = 1, 
	}

	public enum WorldActorEventConditionType{
		/**角色年龄大于等于param[0]*/
		age_e_g = 1, 
		/**角色年龄小于等于param[0]*/
		age_e_l = 2, 
		/**角色年龄等于param[0]*/
		age_e = 3, 
		/**角色是否处于怀孕状态*/
		pregnant = 4, 
		/**角色连续相亲失败param[0]次*/
		engagementContinuousf = 5, 
		/**角色职业为param[0]职业*/
		actorJobID = 6, 
		/**角色职业为param[0]系*/
		actorjobType = 7, 
		/**角色等级大于等于param[0]*/
		actorLevel = 8, 
	}

	public enum WorldActorEventResultType{
		/**添加ID为[id]的特性*/
		addActorSpeciality = 1, 
	}

	public enum WorldPlayerEventConditionType{
		/**玩家军团士气等级等于N*/
		PlayerCorpsMoraleLevelCheck = 1, 
		/**玩家完成ID为N的任务时*/
		PlayerCompleteTaskCheck = 2, 
		/**玩家游戏世界时间到达N月*/
		PlayerWorldTimeCheck = 3, 
		/**玩家军团总人口数量到达N*/
		PlayerCorpsActorNumCheck = 3, 
	}

	public enum WorldPlayerEventResultType{
		/**开启伤病每年随机传染病的逻辑*/
		openRandomDiseaseInjuryRes = 1, 
		/**更改编队内角色每月随机精神创伤ID组为param*/
		changeTeamActorMindInjuryRandomListRes = 2, 
		/**清空编队内角色每月随机精神创伤ID组*/
		cleanTeamActorMindInjuryRandomListRes = 3, 
	}

	/** 是否死亡 */
	public enum EIsDead{
		/** 未死亡 */
		False = 0, 
		/** 死亡 */
		True = 1, 
	}

	/** 生物攻击类型 */
	public enum EMonsterAttcakType{
		/**生物移动 [msgType: EMonsterAttackType.YiDong, msgValue: tileIndex, attackId: fromGid, hiterId: "", isDev: 0, isRit: 0, isDead: 0, skillId: 0]*/
		YiDong = 0, 
		/**近战攻击 [msgType: EMonsterAttackType.JinZhan, msgValue: 伤害值, attackId: fromGid, hiterId: toGid, isDev: boolean, isRit: boolean, isDead: boolean, skillId: skillId]*/
		JinZhan = 1, 
		/**远程攻击 [msgType: EMonsterAttackType.YuanCheng, msgValue: 伤害值, attackId: fromGid, hiterId: toGid, isDev: boolean, isRit: boolean, isDead: boolean, skillId: skillId]*/
		YuanCheng = 2, 
		/**法术治疗 [msgType: EMonsterAttackType.YuanCheng, msgValue: 治疗值, attackId: fromGid, hiterId: toGid, isDev: boolean, isRit: boolean, isDead: boolean, skillId: skillId]*/
		FaShu = 3, 
		/**显示当前ap [{]msgType: EMonsterAttackType.ShowAp, msgValue: curAp, attackId: fromGid, hiterId: "", isDev: 0, isRit: 0, isDead: 0, skillId: 0]*/
		ShowAp = 4, 
		/**减少ap [msgType: EMonsterAttackType.ShowAp, msgValue: changeNum, attackId: fromGid, hiterId: "", isDev: 0, isRit: 0, isDead: 0, skillId: 0]*/
		JianAp = 5, 
		/**生物到达撤离点 [msgType: EMonsterAttackType.CheLiDian, msgValue: tileIndex, attackId: fromGid, hiterId: "", isDev: 0, isRit: 0, isDead: 0, skillId: 0]*/
		CheLiDian = 6, 
		/**当前生物移动力 [msgType: EMonsterAttackType.CurrMove, msgValue: currMoveValue(当前生物移动力), attackId: fromGid, hiterId: "", isDev: 0, isRit: 0, isDead: 0, skillId: 0]*/
		CurrMove = 7, 
	}

	/** 伤害判定结果标识*/
	public enum EDmgJudgmentFlag{
		/** 忽略防御*/
		isIgnoreDef = 1, 
		/** 招架*/
		isPry = 2, 
		/** 格挡*/
		isBlk = 4, 
		/** 暴击*/
		isCri = 8, 
		/** 命中*/
		isHit = 16, 
		/** 偏斜*/
		isDev = 32, 
		/** 闪避*/
		isDodge = 64, 
	}

	/** 服务器类型ID，目的服务器ID参数的名称*/
	public class ServerIdName{
		/** gate服，客户端配置获取连接服使用 */
		public const string gate = "gateId";
		/** 连接服 */
		public const string connectorid = "connId";
		/** 登录服 */
		public const string loginserverid = "loginId";
		/** 游戏服 */
		public const string gameserverid = "gameId";
		/** 战斗服 */
		public const string battleserverid = "battleId";
		/** token验证服 */
		public const string auth = "authId";
		/** 日志服 */
		public const string logserver = "logId";
	}

	/** 账号状态描述 */
	public enum ELOGINSTATUS{
		/** 手填账号密码登陆 */
		REGISTER = 0, 
		/** 游客登陆(快速登陆) */
		QUICKLOGIN = 1, 
		/** 通行证(第三方sdk) */
		SDKLOGIN = 2, 
		/** 起初为游客或快速登陆，后期补全信息 */
		QUICKLOGINSUFFIX = 3, 
	}

	/** 关卡格子上生物类型 */
	public enum EStumpTileThingType{
		/** 自己队员（包括自己） */
		SelfTeam = 1, 
		/** 敌方队员 */
		MonsterTeam = 2, 
	}

	/**
     * 战斗回合状态ID
     */
	public class BattleStateID{
		/** 不切换状态 */
		public const string None = "None";
		/** (初始化战斗机或站前准备)  */
		public const string BattleInit = "BattleInit";
		/** 战斗开始 */
		public const string BattleStart = "BattleStart";
		/** (队伍调整) */
		public const string TeamAdjustment = "TeamAdjustment";
		/** (我的回合) */
		public const string MyTurn = "MyTurn";
		/** (别人的回合) */
		public const string OthersTurn = "OthersTurn";
		/** (友方的回合) */
		public const string FriendsTurn = "FriendsTurn";
		/** (中立的回合) */
		public const string NeutralTurn = "NeutralTurn";
		/** 剧情 */
		public const string Dialog = "Dialog";
		/** 战斗结算 */
		public const string BattleResult = "BattleResult";
		/** 战斗结束 */
		public const string BattleEnd = "BattleEnd";
		/**战斗事件 */
		public const string BattleEvent = "BattleEvent";
	}

	/**
     * 战斗结果状态
     */
	public enum BattleResultState{
		/**战前 */
		ZhanQian = 0, 
		/** 战斗中 */
		ZhanZhong = 1, 
		/** 战斗失败 */
		Fail = 2, 
		/** 战斗胜利 */
		Successfully = 3, 
		/**战斗结束 */
		End = 4, 
	}

	/** 技能服务器类型 */
	public enum ESkillType{
		/** 0 普通技能(主动) */
		GNERAL_SKILL = 0, 
		/** 1 buffer */
		BUFFER_SKILL = 1, 
		/** 2 旋风斩目标为中心 */
		WHIRLWIND_TARGET_SKILL = 2, 
		/** 3 旋风斩自己为中心 */
		WHIRLWIND_SELF_SKILL = 3, 
		/** 4 冲锋 */
		CHARGE_SKILL = 4, 
		/** 5 暴击 */
		DOUBLE_SKILL = 5, 
		/**表中数值为空的数据，需要确定为空的数据是否默认0 */
		NONE_SKILL = 6, 
	}

	/** 渠道 */
	public enum EChannel{
		/** 苹果商店 */
		AppStore = 0, 
		/** 谷歌商店 */
		GooglePlay = 1, 
		/** TapTap */
		TapTap = 2, 
		/** 枚举最大值 */
		Max = 3, 
	}

	/** 性别 */
	public enum EGender{
		/** 未知 */
		Unknown = 0, 
		/** 男 */
		Male = 1, 
		/** 女 */
		Female = 2, 
	}

	/** 格子类型 */
	public enum ESlotType{
		/** 普通 */
		PuTong = 0, 
		/** 阻挡(不能走的) */
		ZuDang = 1, 
		/**遮挡(能走的,如草丛) */
		ZheDang = 2, 
	}

	/** 生物类型 */
	public enum EStumpType{
		/** 怪物 */
		Monster = 0, 
		/** Npc */
		NpcActor = 1, 
		/** 玩家 */
		PlayerActor = 2, 
	}

	/** 队伍类型 */
	public enum ETeamType{
		/** 自己 */
		Player = 0, 
		/** 敌方 */
		Enemy = 1, 
		/** 友方 */
		Friend = 2, 
		/** 中立 */
		Neutral = 3, 
		/** 全部 */
		All = 4, 
	}

	/** 目标类型 */
	public enum ESkillTargetType{
		/** 敌方 */
		Enemy = 1, 
		/** 友方 */
		Friend = 2, 
		/** 3之前值为空,为生成数据暂定为3后续核实后再修改 */
		Neutral = 3, 
	}

	/** 生物朝向 */
	public enum EDirection{
		/** 向上 */
		Up = 0, 
		/** 向下 */
		Down = 1, 
		/** 向左 */
		Left = 2, 
		/** 向右 */
		Right = 3, 
	}

	/** 关卡类型 */
	public enum ELevelType{
		/** 歼灭 */
		JianMie = 0, 
		/** 斩首 */
		ZhanShou = 1, 
		/** 夺旗 */
		DuoQI = 2, 
		/** 坚守 */
		JianShou = 3, 
		/** 撤离 */
		CheLi = 4, 
		/** 护卫 */
		HuWei = 5, 
		/** 追杀 */
		ZhuiSha = 6, 
		/** 防御 */
		FangYu = 7, 
		/** 护送 */
		HuSong = 8, 
		/** 任务 */
		RenWu = 9, 
		/**攻城 */
		GongCheng = 10, 
	}

	/** 场景类型 */
	public enum EThemeType{
		/** 平原 */
		PingYuan = 0, 
		/**城镇 */
		ChengZhen = 1, 
		/**城里 */
		ChengLi = 2, 
		/**城外 */
		ChengWai = 3, 
		/**沙漠 */
		ShaMo = 4, 
		/**山寨外 */
		ShanZhaiWai = 5, 
		/**山脚 */
		ShanJiao = 6, 
	}

	/** 生物职业类型 */
	public enum EMonsterOccuType{
		/**战士 */
		ZhanShi = 10211, 
		/** 新兵 */
		XinBing = 10312, 
		/** 轻步兵 */
		QingBuBing = 10101, 
		/** 轻骑兵 */
		QingQiBing = 10231, 
		/**游侠 */
		YouXia = 10342, 
		/**皇家骑兵 */
		HuangJiaQiBing = 10331, 
		/**贫民 */
		PingMin = 10101, 
		/**重甲僧侣 */
		ZhongJiaSengLv = 10323, 
		/**剑圣 */
		JianSheng = 10314, 
		/**斥候 */
		ChiHou = 10212, 
		/**狂战士 */
		KuangZhanShi = 10311, 
		/**刺客 */
		CiKe = 10313, 
		/**重步兵 */
		ZhongBuBing = 10121, 
		/**方阵步兵 */
		FangZhenBuBing = 10221, 
		/**重甲枪兵 */
		ZhongJiaQiangBing = 10222, 
		/**王室禁卫 */
		WangShiJinWei = 10321, 
		/**铁甲军士 */
		TieJiaJunShi = 10322, 
		/**圣堂铁卫 */
		ShengTangTieWei = 10324, 
		/**见习骑兵 */
		JianXiQiBing = 10131, 
		/**重骑兵 */
		ZhongQiBing = 10232, 
		/**重装骑兵 */
		ZhongZhuangQiBing = 10332, 
		/**掠袭骑兵 */
		LueXiQiBing = 10333, 
		/**统御骑士 */
		TongYuQiBing = 10334, 
		/**猎人 */
		LieRen = 10141, 
		/**弩手 */
		NuShou = 10242, 
		/**长弓手 */
		ChangGongShou = 10341, 
		/**盾弩手 */
		DunNuShou = 10343, 
		/**重弩手 */
		ZhongNuShou = 10344, 
		/**自学巫师 */
		ZiXueWuShi = 10151, 
		/**魔法师(德鲁伊) */
		MoFaShi = 10251, 
		/**牧师 */
		MuShi = 10252, 
		/**魔导师(大德鲁伊) */
		MoDaoShi = 10351, 
		/**主教 */
		ZhuJiao = 10352, 
		/**吟游诗人 */
		YinYouShiRen = 10353, 
		/**炼金术士 */
		LianJinShuShi = 10354, 
	}

	/** 怪物外形 */
	public enum EMonsterType{
		/** 人形 */
		RenXing = 0, 
		/** 野兽 */
		YeShou = 1, 
		/** 建筑 */
		JianZhu = 2, 
	}

	/** 人物部件 */
	public enum EPart{
		/** 后面的头发 */
		HouFa = 0, 
		//身体
		ShenTi = 1, 
		//衣服
		YiFu = 2, 
		//项链
		XiangLian = 3, 
		//脸
		ZhongFa = 4, 
		//脸
		Lian = 5, 
		//面纹
		MianWen = 6, 
		//圣痕
		ShengHeng = 7, 
		//眼
		Yan = 8, 
		//眉
		Mei = 9, 
		//鼻
		Bi = 10, 
		//嘴
		Zui = 11, 
		//皱纹
		ZhouWen = 12, 
		//胡须
		HuXu = 13, 
		//前发
		QianFa = 14, 
		//头饰
		TouShi = 15, 
		//耳
		Er = 16, 
		//耳环
		ErHuan = 17, 
		//前前发
		QianQianFa = 18, 
	}

	/** 光效目标 */
	public enum EViewTarget{
		/**未知 */
		None = 0, 
		/**自己 */
		Self = 1, 
		/**目标 */
		Target = 2, 
		/**全部 */
		All = 3, 
	}

	/**(效果状态表)删除状态条件 */
	public enum EEffectStatusStop1{
		/**无 */
		None = 0, 
		/**战斗过 */
		Battle = 1, 
		/**回合开始 */
		RoundStart = 2, 
		/**回合内没移动 */
		RoundNotMove = 3, 
		/**回合内没行动 */
		RoundNotAction = 4, 
	}

	/**关卡触发器应用类型,分服务器,客户端 */
	public enum ETriggerApplyType{
		/**客户端使用 */
		Client = 0, 
		/**服务器使用 */
		Server = 1, 
		/**客户端,服务器都使用 */
		Both = 2, 
	}

	/** 角色外观部件类型*/
	public class EExteriorPartType{
		//脸
		public const string face = "face";
		//脸
		public const string face2 = "face2";
		//大脸
		public const string eyebrow = "eyebrow";
		//眉
		public const string eye = "eye";
		//眼
		public const string nose = "nose";
		//鼻
		public const string mouth = "mouth";
		//嘴
		public const string ear = "ear";
		//耳
		public const string body = "body";
		//身体
		public const string clothes = "clothes";
		//衣服
		public const string hair = "hair";
		//发型
		public const string stigma = "stigma";
		//圣痕
		public const string tattoo = "tattoo";
		//刺青
		public const string beard = "beard";
		//胡子
		public const string beard2 = "beard2";
		//连鬓胡子
		public const string skin_color = "skin_color";
		//肤色
		public const string hair_color = "hair_color";
		//发色
		public const string eyebrow_color = "eyebrow_color";
		//眉毛颜色
		public const string beard_color = "beard_color";
		//胡子颜色
		public const string hair_jewelry = "hair_jewelry";
		//发饰
		public const string medal = "medal";
		//勋章
		public const string wrinkle = "wrinkle";
	}

	/** 角色属性类型枚举*/
	public enum EActorAttrType{
		/**力量*/
		str = 1, 
		/**常量力量增加*/
		str_s = 2, 
		/**百分比力量增加*/
		str_p = 3, 
		/**当前帧常量力量增加*/
		str_s_f = 4, 
		/**当前帧百分比力量增加*/
		str_p_f = 5, 
		/**体质*/
		vit = 6, 
		/**常量体质增加*/
		vit_s = 7, 
		/**百分比体质增加*/
		vit_p = 8, 
		/**当前帧常量体质增加*/
		vit_s_f = 9, 
		/**当前帧百分比体质增加*/
		vit_p_f = 10, 
		/**技巧*/
		dex = 11, 
		/**常量技巧增加*/
		dex_s = 12, 
		/**百分比技巧增加*/
		dex_p = 13, 
		/**当前帧常量技巧增加*/
		dex_s_f = 14, 
		/**当前帧百分比技巧增加*/
		dex_p_f = 15, 
		/**感知*/
		per = 16, 
		/**常量感知增加*/
		per_s = 17, 
		/**百分比感知增加*/
		per_p = 18, 
		/**当前帧常量感知增加*/
		per_s_f = 19, 
		/**当前帧百分比感知增加*/
		per_p_f = 20, 
		/**敏捷*/
		agi = 21, 
		/**常量敏捷增加*/
		agi_s = 22, 
		/**百分比敏捷增加*/
		agi_p = 23, 
		/**当前帧常量敏捷增加*/
		agi_s_f = 24, 
		/**当前帧百分比敏捷增加*/
		agi_p_f = 25, 
		/**意志*/
		wil = 26, 
		/**常量意志增加*/
		wil_s = 27, 
		/**百分比意志增加*/
		wil_p = 28, 
		/**当前帧常量意志增加*/
		wil_s_f = 29, 
		/**当前帧百分比意志增加*/
		wil_p_f = 30, 
		/**全六维*/
		quanLiuWei = 31, 
		/**常量全六维增加*/
		quanLiuWei_s = 32, 
		/**百分比全六维增加*/
		quanLiuWei_p = 33, 
		/**当前帧常量全六维增加*/
		quanLiuWei_s_f = 34, 
		/**当前帧百分比全六维增加*/
		quanLiuWei_p_f = 35, 
		/**HP上限*/
		hp = 36, 
		/**常量HP上限增加*/
		hp_s = 37, 
		/**百分比HP上限增加*/
		hp_p = 38, 
		/**当前帧常量HP上限增加*/
		hp_s_f = 39, 
		/**当前帧百分比HP上限增加*/
		hp_p_f = 40, 
		/**AP上限*/
		ap = 41, 
		/**常量AP上限增加*/
		ap_s = 42, 
		/**百分比AP上限增加*/
		ap_p = 43, 
		/**当前帧常量AP上限增加*/
		ap_s_f = 44, 
		/**当前帧百分比AP上限增加*/
		ap_p_f = 45, 
		/**每回合AP恢复量*/
		recoveryAp = 46, 
		/**常量每回合AP恢复量增加*/
		recoveryAp_s = 47, 
		/**百分比每回合AP恢复量增加*/
		recoveryAp_p = 48, 
		/**当前帧常量每回合AP恢复量增加*/
		recoveryAp_s_f = 49, 
		/**当前帧百分比每回合AP恢复量增加*/
		recoveryAp_p_f = 50, 
		/**负重上限*/
		wgt = 51, 
		/**常量负重上限增加*/
		wgt_s = 52, 
		/**百分比负重上限增加*/
		wgt_p = 53, 
		/**当前帧常量负重上限增加*/
		wgt_s_f = 54, 
		/**当前帧百分比负重上限增加*/
		wgt_p_f = 55, 
		/**移动力上限*/
		mov = 56, 
		/**常量移动力上限增加*/
		mov_s = 57, 
		/**百分比移动力上限增加*/
		mov_p = 58, 
		/**当前帧常量移动力上限增加*/
		mov_s_f = 59, 
		/**当前帧百分比移动力上限增加*/
		mov_p_f = 60, 
		/**移动次数*/
		movN = 61, 
		/**常量移动次数增加*/
		movN_s = 62, 
		/**百分比移动次数增加*/
		movN_p = 63, 
		/**当前帧常量移动次数增加*/
		movN_s_f = 64, 
		/**当前帧百分比移动次数增加*/
		movN_p_f = 65, 
		/**攻击次数*/
		atkN = 66, 
		/**常量攻击次数增加*/
		atkN_s = 67, 
		/**百分比攻击次数增加*/
		atkN_p = 68, 
		/**当前帧常量攻击次数增加*/
		atkN_s_f = 69, 
		/**当前帧百分比攻击次数增加*/
		atkN_p_f = 70, 
		/**行动次数*/
		actN = 71, 
		/**常量行动次数增加*/
		actN_s = 72, 
		/**百分比行动次数增加*/
		actN_p = 73, 
		/**当前帧常量行动次数增加*/
		actN_s_f = 74, 
		/**当前帧百分比行动次数增加*/
		actN_p_f = 75, 
		/**反击次数*/
		resistN = 76, 
		/**常量反击次数增加*/
		resistN_s = 77, 
		/**百分比反击次数增加*/
		resistN_p = 78, 
		/**当前帧常量反击次数增加*/
		resistN_s_f = 79, 
		/**当前帧百分比反击次数增加*/
		resistN_p_f = 80, 
		/**物理偏斜值*/
		pDev = 81, 
		/**常量物理偏斜值增加*/
		pDev_s = 82, 
		/**百分比物理偏斜值增加*/
		pDev_p = 83, 
		/**当前帧常量物理偏斜值增加*/
		pDev_s_f = 84, 
		/**当前帧百分比物理偏斜值增加*/
		pDev_p_f = 85, 
		/**物理偏斜减伤系数值*/
		pDevDmg = 86, 
		/**常量物理偏斜减伤系数值增加*/
		pDevDmg_s = 87, 
		/**百分比物理偏斜减伤系数值增加*/
		pDevDmg_p = 88, 
		/**当前帧物理偏斜减伤系数值增加*/
		pDevDmg_s_f = 89, 
		/**当前帧百分比物理偏斜减伤系数值增加*/
		pDevDmg_p_f = 90, 
		/**魔法偏斜值*/
		mDev = 91, 
		/**常量魔法偏斜值增加*/
		mDev_s = 92, 
		/**百分比魔法偏斜值增加*/
		mDev_p = 93, 
		/**当前帧常量魔法偏斜值增加*/
		mDev_s_f = 94, 
		/**当前帧百分比魔法偏斜值增加*/
		mDev_p_f = 95, 
		/**魔法偏斜减伤系数值*/
		mDevDmg = 96, 
		/**常量魔法偏斜减伤系数值增加*/
		mDevDmg_s = 97, 
		/**百分比魔法偏斜减伤系数值增加*/
		mDevDmg_p = 98, 
		/**当前帧常量魔法偏斜减伤系数值增加*/
		mDevDmg_s_f = 99, 
		/**当前帧百分比魔法偏斜减伤系数值增加*/
		mDevDmg_p_f = 100, 
		/**物理命中值*/
		pHit = 101, 
		/**常量物理命中值增加*/
		pHit_s = 102, 
		/**百分比物理命中值增加*/
		pHit_p = 103, 
		/**当前帧常量物理命中值增加*/
		pHit_s_f = 104, 
		/**当前帧百分比物理命中值增加*/
		pHit_p_f = 105, 
		/**魔法命中值*/
		mHit = 106, 
		/**常量魔法命中值增加*/
		mHit_s = 107, 
		/**百分比魔法命中值增加*/
		mHit_p = 108, 
		/**当前帧常量魔法命中值增加*/
		mHit_s_f = 109, 
		/**当前帧百分比魔法命中值增加*/
		mHit_p_f = 110, 
		/**物理暴击值*/
		pCri = 111, 
		/**常量物理暴击值增加*/
		pCri_s = 112, 
		/**百分比物理暴击值增加*/
		pCri_p = 113, 
		/**当前帧常量物理暴击值增加*/
		pCri_s_f = 114, 
		/**当前帧百分比物理暴击值增加*/
		pCri_p_f = 115, 
		/**魔法暴击值*/
		mCri = 116, 
		/**常量魔法暴击值增加*/
		mCri_s = 117, 
		/**百分比魔法暴击值增加*/
		mCri_p = 118, 
		/**当前帧常量魔法暴击值增加*/
		mCri_s_f = 119, 
		/**当前帧百分比魔法暴击值增加*/
		mCri_p_f = 120, 
		/**坚韧(物理抗爆值)*/
		pDCri = 121, 
		/**常量坚韧增加*/
		pDCri_s = 122, 
		/**百分比坚韧增加*/
		pDCri_p = 123, 
		/**当前帧常量坚韧增加*/
		pDCri_s_f = 124, 
		/**当前帧百分比坚韧增加*/
		pDCri_p_f = 125, 
		/**抵抗(魔法抗爆值)*/
		mDCri = 126, 
		/**常量抵抗增加*/
		mDCri_s = 127, 
		/**百分比抵抗增加*/
		mDCri_p = 128, 
		/**当前帧常量抵抗增加*/
		mDCri_s_f = 129, 
		/**当前帧百分比抵抗增加*/
		mDCri_p_f = 130, 
		/**物理暴击伤害系数值*/
		pCriDmg = 131, 
		/**常量物理暴击伤害系数值增加*/
		pCriDmg_s = 132, 
		/**百分比物理暴击伤害系数值增加*/
		pCriDmg_p = 133, 
		/**当前帧常量物理暴击伤害系数值增加*/
		pCriDmg_s_f = 134, 
		/**当前帧百分比物理暴击伤害系数值增加*/
		pCriDmg_p_f = 135, 
		/**魔法暴击伤害系数值*/
		mCriDmg = 136, 
		/**常量魔法暴击伤害系数值增加*/
		mCriDmg_s = 137, 
		/**百分比魔法暴击伤害系数值增加*/
		mCriDmg_p = 138, 
		/**当前帧常量魔法暴击伤害系数值增加*/
		mCriDmg_s_f = 139, 
		/**当前帧百分比魔法暴击伤害系数值增加*/
		mCriDmg_p_f = 140, 
		/**格挡概率值*/
		blk = 141, 
		/**常量格挡概率值增加*/
		blk_s = 142, 
		/**百分比格挡概率值增加*/
		blk_p = 143, 
		/**当前帧常量格挡概率值增加*/
		blk_s_f = 144, 
		/**当前帧百分比格挡概率值增加*/
		blk_p_f = 145, 
		/**格挡防御力*/
		blkDef = 146, 
		/**常量格挡防御力增加*/
		blkDef_s = 147, 
		/**百分比格挡防御力增加*/
		blkDef_p = 148, 
		/**当前帧常量格挡防御力增加*/
		blkDef_s_f = 149, 
		/**当前帧百分比格挡防御力增加*/
		blkDef_p_f = 150, 
		/**招架概率值*/
		pry = 151, 
		/**常量招架概率值增加*/
		pry_s = 152, 
		/**百分比招架概率值增加*/
		pry_p = 153, 
		/**当前帧常量招架概率值增加*/
		pry_s_f = 154, 
		/**当前帧百分比招架概率值增加*/
		pry_p_f = 155, 
		/**招架防御力*/
		pryDef = 156, 
		/**常量招架防御力增加*/
		pryDef_s = 157, 
		/**百分比招架防御力增加*/
		pryDef_p = 158, 
		/**当前帧常量招架防御力增加*/
		pryDef_s_f = 159, 
		/**当前帧百分比招架防御力增加*/
		pryDef_p_f = 160, 
		/**物理防御力*/
		pDef = 161, 
		/**常量物理防御力增加*/
		pDef_s = 162, 
		/**百分比物理防御力增加*/
		pDef_p = 163, 
		/**当前帧常量物理防御力增加*/
		pDef_s_f = 164, 
		/**当前帧百分比物理防御力增加*/
		pDef_p_f = 165, 
		/**魔法防御力*/
		mDef = 166, 
		/**常量魔法防御力增加*/
		mDef_s = 167, 
		/**百分比魔法防御力增加*/
		mDef_p = 168, 
		/**当前帧常量魔法防御力增加*/
		mDef_s_f = 169, 
		/**当前帧百分比魔法防御力增加*/
		mDef_p_f = 170, 
		/**物理攻击力*/
		pAtk = 171, 
		/**常量物理攻击力增加*/
		pAtk_s = 172, 
		/**百分比物理攻击力增加*/
		pAtk_p = 173, 
		/**当前帧常量物理攻击力增加*/
		pAtk_s_f = 174, 
		/**当前帧百分比物理攻击力增加*/
		pAtk_p_f = 175, 
		/**魔法攻击力*/
		mAtk = 176, 
		/**常量魔法攻击力增加*/
		mAtk_s = 177, 
		/**百分比魔法攻击力增加*/
		mAtk_p = 178, 
		/**当前帧常量魔法攻击力增加*/
		mAtk_s_f = 179, 
		/**当前帧百分比魔法攻击力增加*/
		mAtk_p_f = 180, 
		/**物理暴击最终概率*/
		pCriSp = 181, 
		/**常量物理暴击最终概率增加*/
		pCriSp_s = 182, 
		/**百分比物理暴击最终概率增加*/
		pCriSp_p = 183, 
		/**当前帧常量物理暴击最终概率增加*/
		pCriSp_s_f = 184, 
		/**当前帧百分比物理暴击最终概率增加*/
		pCriSp_p_f = 185, 
		/**魔法暴击最终概率*/
		mCriSp = 186, 
		/**常量魔法暴击最终概率增加*/
		mCriSp_s = 187, 
		/**百分比魔法暴击最终概率增加*/
		mCriSp_p = 188, 
		/**当前帧常量魔法暴击最终概率增加*/
		mCriSp_s_f = 189, 
		/**当前帧百分比魔法暴击最终概率增加*/
		mCriSp_p_f = 190, 
		/**物理暴击最终概率抵扣（坚韧概率）*/
		pDCriSp = 191, 
		/**常量物理暴击最终概率抵扣（坚韧概率）增加*/
		pDCriSp_s = 192, 
		/**百分比物理暴击最终概率抵扣（坚韧概率）增加*/
		pDCriSp_p = 193, 
		/**当前帧常量物理暴击最终概率抵扣（坚韧概率）增加*/
		pDCriSp_s_f = 194, 
		/**当前帧百分比物理暴击最终概率抵扣（坚韧概率）增加*/
		pDCriSp_p_f = 195, 
		/**魔法暴击最终概率抵扣（抵抗概率）*/
		mDCriSp = 196, 
		/**常量魔法暴击最终概率抵扣（抵抗概率）增加*/
		mDCriSp_s = 197, 
		/**百分比魔法暴击最终概率抵扣（抵抗概率）增加*/
		mDCriSp_p = 198, 
		/**当前帧常量魔法暴击最终概率抵扣（抵抗概率）增加*/
		mDCriSp_s_f = 199, 
		/**当前帧百分比魔法暴击最终概率抵扣（抵抗概率）增加*/
		mDCriSp_p_f = 200, 
		/**物理偏斜最终概率*/
		pDevSp = 201, 
		/**常量物理偏斜最终概率增加*/
		pDevSp_s = 202, 
		/**百分比物理偏斜最终概率增加*/
		pDevSp_p = 203, 
		/**当前帧常量物理偏斜最终概率增加*/
		pDevSp_s_f = 204, 
		/**当前帧百分比物理偏斜最终概率增加*/
		pDevSp_p_f = 205, 
		/**魔法偏斜最终概率*/
		mDevSp = 206, 
		/**常量魔法偏斜最终概率增加*/
		mDevSp_s = 207, 
		/**百分比魔法偏斜最终概率增加*/
		mDevSp_p = 208, 
		/**当前帧常量魔法偏斜最终概率增加*/
		mDevSp_s_f = 209, 
		/**当前帧百分比魔法偏斜最终概率增加*/
		mDevSp_p_f = 210, 
		/**物理命中最终概率*/
		pHitSp = 211, 
		/**常量物理命中最终概率增加*/
		pHitSp_s = 212, 
		/**百分比物理命中最终概率增加*/
		pHitSp_p = 213, 
		/**当前帧常量物理命中最终概率增加*/
		pHitSp_s_f = 214, 
		/**当前帧百分比物理命中最终概率增加*/
		pHitSp_p_f = 215, 
		/**魔法命中最终概率*/
		mHitSp = 216, 
		/**常量魔法命中最终概率增加*/
		mHitSp_s = 217, 
		/**百分比魔法命中最终概率增加*/
		mHitSp_p = 218, 
		/**当前帧常量魔法命中最终概率增加*/
		mHitSp_s_f = 219, 
		/**当前帧百分比魔法命中最终概率增加*/
		mHitSp_p_f = 220, 
		/**格挡最终概率*/
		blkSp = 221, 
		/**常量格挡最终概率增加*/
		blkSp_s = 222, 
		/**百分比格挡最终概率增加*/
		blkSp_p = 223, 
		/**当前帧常量格挡最终概率增加*/
		blkSp_s_f = 224, 
		/**当前帧百分比格挡最终概率增加*/
		blkSp_p_f = 225, 
		/**招架最终概率*/
		prySp = 226, 
		/**常量招架最终概率增加*/
		prySp_s = 227, 
		/**百分比招架最终概率增加*/
		prySp_p = 228, 
		/**当前帧常量招架最终概率增加*/
		prySp_s_f = 229, 
		/**当前帧百分比招架最终概率增加*/
		prySp_p_f = 230, 
		/**最终伤害*/
		dmgSp = 231, 
		/**常量最终伤害增加*/
		dmgSp_s = 232, 
		/**百分比最终伤害增加*/
		dmgSp_p = 233, 
		/**当前帧常量最终伤害增加*/
		dmgSp_s_f = 234, 
		/**当前帧百分比最终伤害增加*/
		dmgSp_p_f = 235, 
		/**物理防御穿透系数值*/
		iPDef = 236, 
		/**常量物理防御穿透系数值增加*/
		iPDef_s = 237, 
		/**百分比物理防御穿透系数值增加*/
		iPDef_p = 238, 
		/**当前帧常量物理防御穿透系数值增加*/
		iPDef_s_f = 239, 
		/**当前帧百分比物理防御穿透系数值增加*/
		iPDef_p_f = 240, 
		/**魔法防御穿透系数值*/
		iMDef = 241, 
		/**常量魔法防御穿透系数值增加*/
		iMDef_s = 242, 
		/**百分比魔法防御穿透系数值增加*/
		iMDef_p = 243, 
		/**当前帧常量魔法防御穿透系数值增加*/
		iMDef_s_f = 244, 
		/**当前帧百分比魔法防御穿透系数值增加*/
		iMDef_p_f = 245, 
		/**全攻击力*/
		atkSp = 246, 
		/**常量全攻击力增加*/
		atkSp_s = 247, 
		/**百分比全攻击力增加*/
		atkSp_p = 248, 
		/**当前帧常量全攻击力增加*/
		atkSp_s_f = 249, 
		/**当前帧百分比全攻击力增加*/
		atkSp_p_f = 250, 
		/**全暴击值*/
		criSp = 251, 
		/**常量全暴击值增加*/
		criSp_s = 252, 
		/**百分比全暴击值增加*/
		criSp_p = 253, 
		/**当前帧常量全暴击值增加*/
		criSp_s_f = 254, 
		/**当前帧百分比全暴击值增加*/
		criSp_p_f = 255, 
		/**全暴击伤害系数值*/
		criDmgSp = 256, 
		/**常量全暴击伤害系数值增加*/
		criDmgSp_s = 257, 
		/**百分比全暴击伤害系数值增加*/
		criDmgSp_p = 258, 
		/**当前帧常量全暴击伤害系数值增加*/
		criDmgSp_s_f = 259, 
		/**当前帧百分比全暴击伤害系数值增加*/
		criDmgSp_p_f = 260, 
		/**全防御忽略最终概率*/
		iDefSp = 261, 
		/**常量全防御忽略最终概率增加*/
		iDefSp_s = 262, 
		/**百分比全防御忽略最终概率增加*/
		iDefSp_p = 263, 
		/**当前帧常量全防御忽略最终概率增加*/
		iDefSp_s_f = 264, 
		/**当前帧百分比全防御忽略最终概率增加*/
		iDefSp_p_f = 265, 
		/**战斗速度*/
		bAgi = 266, 
		/**常量战斗速度增加*/
		bAgi_s = 267, 
		/**百分比战斗速度增加*/
		bAgi_p = 268, 
		/**当前帧常量战斗速度增加*/
		bAgi_s_f = 269, 
		/**当前帧百分比战斗速度增加*/
		bAgi_p_f = 270, 
		/**当前HP*/
		curHp = 271, 
		/**当前AP*/
		curAp = 272, 
		/**当前负重*/
		curWgt = 273, 
		/**当前武器物理攻击力*/
		curWpAtk = 274, 
		/**当前武器命中率*/
		curWHit = 275, 
		/**当前武器需求力量*/
		curWeaponNeedStr = 276, 
		/**当前盾牌格挡概率系数值*/
		curWBlk = 277, 
		/**当前盾牌格挡防御力*/
		curWBlkDef = 278, 
		/**当前盾牌需求力量*/
		curShieldNeedStr = 279, 
		/**当前剩余移动力*/
		curMov = 280, 
		/**当前剩余主动攻击次数*/
		curAtkN = 281, 
		/**当前剩余主动移动次数*/
		curMovN = 282, 
		/**当前剩余反击次数*/
		curResistN = 283, 
		/**当前剩余主动行动次数*/
		curActN = 284, 
		/**当前帧常量剩余连击次数增加*/
		curDHitN_s_f = 285, 
		/**常量当前帧消耗移动力*/
		curMovConsume_s_f = 286, 
		/**百分比当前帧消耗移动力*/
		curMovConsume_p_f = 287, 
		/**额外攻击选择范围*/
		selectRange = 288, 
		/**常量额外攻击选择范围增加*/
		selectRange_s = 289, 
		/**禁止移动开关*/
		forbidMove = 290, 
		/**当前帧禁止移动开关*/
		forbidMove_s_f = 291, 
		/**禁止攻击开关*/
		forbidAttack = 292, 
		/**当前帧禁止攻击开关*/
		forbidAttack_s_f = 293, 
		/**禁止行动开关*/
		forbidAction = 294, 
		/**当前帧禁止行动开关*/
		forbidAction_s_f = 295, 
		/**禁止命中开关*/
		forbidHit = 296, 
		/**当前帧禁止命中开关*/
		forbidHit_s_f = 297, 
		/**禁止暴击开关*/
		forbidCri = 298, 
		/**当前帧禁止暴击开关*/
		forbidCri_s_f = 299, 
		/**禁止格挡开关*/
		forbidBlk = 300, 
		/**当前帧禁止格挡开关*/
		forbidBlk_s_f = 301, 
		/**禁止招架开关*/
		forbidPry = 302, 
		/**当前帧禁止招架开关*/
		forbidPry_s_f = 303, 
		/**禁止反击开关*/
		forbidResistAtk = 304, 
		/**当前帧禁止反击开关*/
		forbidResistAtk_s_f = 305, 
		/**禁止连击开关*/
		forbidDHit = 306, 
		/**当前帧禁止连击开关*/
		forbidDHit_s_f = 307, 
		/**禁止抢攻开关*/
		forbidGrabRAtk = 308, 
		/**当前帧禁止抢攻开关*/
		forbidGrabRAtk_s_f = 309, 
		/**豁免死亡开关*/
		exemptDead = 310, 
		/**当前帧豁免死亡开关*/
		exemptDead_s_f = 311, 
		/**必定抢攻开关*/
		ariseGrabRAtk = 312, 
		/**当前帧必定抢攻开关*/
		ariseGrabRAtk_s_f = 313, 
		/**禁止偏斜开关*/
		forbidDev = 314, 
		/**当前帧禁止偏斜开关*/
		forbidDev_s_f = 315, 
		/**当前护甲防御力*/
		curArmorDef = 316, 
		/**豁免死亡次数*/
		exemptDeadNum = 317, 
		/**格挡大师开关*/
		blkMaster = 318, 
		/**招架大师开关*/
		pryMaster = 319, 
		/**无视防御开关*/
		ignoreDef = 320, 
		/**帧无视防御开关*/
		ignoreDef_s_f = 321, 
		/**角色相亲成功率常量增加*/
		actorEngagementS = 322, 
		/**战斗经验常数增加*/
		battleExpS = 323, 
		/**战斗经验百分比增加*/
		battleExpP = 324, 
		/**跑商银币奖励常数增加*/
		runBusinessSilverS = 325, 
		/**跑商银币奖励百分比增加*/
		runBusinessSilverP = 326, 
		/**军团技能开关*/
		legionSkills = 327, 
		/**战斗中触发伤病常数增加*/
		triggerHurtProS = 328, 
		/**单个未成年人不夭折开关*/
		actorJuvenilesDeath = 329, 
		/**全队未成年人不夭折开关*/
		legionJuvenilesDeath = 330, 
		/**角色怀孕概率常数增加*/
		actorPregnantProS = 331, 
		/**相亲遇到更高爵位概率常数增加*/
		meetHighNobilityProS = 332, 
		/**角色寿命常数增加*/
		actorLifeSpanS = 333, 
		/**角色寿命百分比增加*/
		actorLifeSpanP = 334, 
		/**伤病恢复时间常数增加*/
		hurtrRecoveryS = 335, 
		/**伤病恢复时间百分比增加*/
		hurtrRecoveryP = 336, 
		/**当前剩余连击次数*/
		curDHitN = 337, 
		/**全员战斗经验常数增加*/
		legionBattleExpS = 338, 
		/**全员战斗经验百分比增加*/
		legionBattleExpP = 339, 
		/**全员相亲成功率常数增加*/
		legionEngagementS = 340, 
		/**全员相亲成功率百分比增加*/
		legionEngagementP = 341, 
		/**全员怀孕概率常数增加*/
		legionPregnantProS = 342, 
		/**全员怀孕概率百分比增加*/
		legionPregnantProp = 343, 
		/**全员免疫濒死开关*/
		legionImmuneDying = 344, 
		/**全队战斗中触发伤病常数增加*/
		legionTriggerHurtProS = 345, 
		/**全队战斗中触发伤病百分比增加*/
		legionTriggerHurtProP = 346, 
		/**之后X次必定生女孩*/
		nextNewbornGirl = 347, 
		/**下次装备升品成功率百分比增加*/
		nextEquipPromoteP = 348, 
		/**下次装备强化成功率百分比增加*/
		nextEquipStrengthenP = 349, 
		/**角色相亲成功率百分比增加*/
		actorEngagementP = 350, 
		/**角色工资常数增加*/
		actorWageAddS = 351, 
		/**角色工资百分比增加*/
		actorWageAddP = 352, 
		/**遗传父母正面特性开关*/
		inheritGoodCha = 353, 
		/**遗传父母特性百分比增加*/
		inheritChaAddP = 354, 
		/**伤病负重上限百分比增加*/
		wgt_p_injury = 355, 
		/**伤病感知百分比增加*/
		per_p_injury = 356, 
		/**伤病魔法暴击百分比增加*/
		mCri_p_injury = 357, 
		/**伤病物理暴击百分比增加*/
		pCri_p_injury = 358, 
		/**伤病意志百分比增加*/
		wil_p_injury = 359, 
		/**伤病经验获取百分比增加*/
		battleExpP_injury = 360, 
		/**伤病相亲成功率百分比增加*/
		actorEngagementP_injury = 361, 
		/**伤病魔法攻击百分比增加*/
		mAtk_p_injury = 362, 
		/**伤病物理攻击百分比增加*/
		pAtk_p_injury = 363, 
		/**伤病技巧百分比增加*/
		dex_p_injury = 364, 
		/**伤病力量百分比增加*/
		str_p_injury = 365, 
		/**伤病格挡防御力百分比增加*/
		blkDef_p_injury = 366, 
		/**伤病全六维百分比增加*/
		quanLiuWei_p_injury = 367, 
		/**伤病HP上限百分比增加*/
		hp_p_injury = 368, 
		/**伤病敏捷百分比增加*/
		agi_p_injury = 369, 
		/**伤病魔法命中百分比增加*/
		mHit_p_injury = 370, 
		/**伤病物理命中百分比增加*/
		pHit_p_injury = 371, 
		/**伤病魔法偏斜百分比增加*/
		mDev_p_injury = 372, 
		/**伤病物理偏斜百分比增加*/
		pDev_p_injury = 373, 
		/**伤病体质百分比增加*/
		vit_p_injury = 374, 
		/**角色战力*/
		fighting = 375, 
		/**常量角色战力增加*/
		fighting_s = 376, 
		/**百分比角色战力增加*/
		fighting_p = 377, 
		/**角色夭折概率百分比增加*/
		JuvenilesDeath_p = 378, 
		/**帧防御值百分比惩罚系数增加*/
		DefPunCoe_p_f = 379, 
		/**当前装备物理攻击力*/
		pAtk_equip = 380, 
		/**当前装备魔法攻击力*/
		mAtk_equip = 381, 
		/**当前武器魔法攻击力*/
		curWmAtk = 382, 
		/**伤病物理防御百分比增加*/
		pDef_p_injury = 383, 
		/**伤病魔法防御百分比增加*/
		mDef_p_injury = 384, 
		/**伤病物理爆伤系数百分比增加*/
		pCriDmg_p_injury = 385, 
		/**伤病魔法爆伤系数百分比增加*/
		mCriDmg_p_injury = 386, 
		/**伤病坚韧百分比增加*/
		pDCri_p_injury = 387, 
		/**伤病抵抗百分比增加*/
		mDCri_p_injury = 388, 
		/**伤病招架防御力百分比增加*/
		pryDef_p_injury = 389, 
		/**伤病速度百分比增加*/
		movN_p_injury = 390, 
		/**当前装备物理防御力*/
		pDef_equip = 391, 
		/**当前装备魔法防御力*/
		mDef_equip = 392, 
		/**当前已失Hp*/
		curHpLost = 393, 
		/**最终治疗量*/
		recoverySp = 394, 
		/**常量最终治疗量增加*/
		recoverySp_s = 395, 
		/**百分比最终治疗量增加*/
		recoverySp_p = 396, 
		/**当前帧最终治疗量常量增加*/
		recoverySp_s_f = 397, 
		/**当前帧最终治疗量百分比增加*/
		recoverySp_p_f = 398, 
		/**忽略角色阻挡开关*/
		iActorObs = 399, 
		/**当前帧忽略角色阻挡开关*/
		iActorObs_f = 400, 
		/**禁止被选为主动技能(技能拥有者回合内可释放)主要目标开关*/
		forbidSkillTarget = 401, 
		/**当前帧禁止被选为主动技能(技能拥有者回合内可释放)主要目标开关*/
		forbidSkillTarget_f = 402, 
		/**常量当前HP增加*/
		curHp_s = 403, 
		/**百分比当前HP增加*/
		curHp_p = 404, 
	}

	/** 回合生命周期状态枚举*/
	public enum ERoundStatus{
		//开始
		Start = 0, 
		//结束
		End = 1, 
	}

	/**
     * 子代血脉随机类型
     */
	public enum EDescentBuildType{
		//普通类型
		common = 0, 
		//同卵双胞胎
		identical = 1, 
		//异卵双胞胎
		fraternal = 2, 
		//变异
		variation = 3, 
	}

	/**
     * 社会地位
     */
	public enum ESocialStatus{
		//平民
		civilian = 1, 
	}

	/**
     * 女性六维属性成长补正
     */
	public class EAttrGrow{
		//力量
		public const double str = 0.9;
		//体质
		public const double vit = 0.9;
		//意志
		public const double wil = 0.9;
		//技巧
		public const double dex = 1.1;
		//感知
		public const double per = 1.1;
		//敏捷
		public const double agi = 1.1;
	}

	/**
     * 属性计算相关常量
     */
	public class EAttrCorrelationConst{
		//感知转换魔攻
		public const double perToMAtk = 0.5;
		//力量转换物攻
		public const double strToPAtk = 0.5;
		//技巧转换物理命中
		public const double dexToPHit = 1.0;
		//技巧转换物理暴击
		public const double dexToPCri = 1.0;
		//感知转换魔法暴击
		public const double wilToMCri = 1.0;
		//技巧转换格挡概率
		public const double dexToBlk = 1.0;
		//技巧转换架招概率
		public const double dexToPry = 1.0;
		//真实敏捷转换物理暴击抵扣系数
		public const double bAgiToPDCri = 1.0;
		//真实敏捷转换物防忽略概率（用于物防忽略技能的计算判断，使用双方真实敏捷差计算）
		public const double agiToIgnoreDef = 1.0;
		//意志转换魔法命中
		public const double wilToMHit = 1.0;
		//意志转换魔法暴击抵扣系数
		public const double wilToMDCri = 1.0;
		//体质转换生命值上限
		public const double vitToHp = 0.5;
		//体质转换理想负重上限
		public const long vitToWgt = 350;
		//溢出理论负重上限的负重量转换真实敏捷惩罚
		public const long overWgtToAgi = 250;
		//实际负重量转换真实敏捷惩罚
		public const long agiToWgt = 1000;
		//武器攻击力转换招架防御值
		public const double wAtkToPryDef = 0.5;
		//感知转换受到的额外治疗值
		public const double perToHeal = 0.35;
		//基础物理暴击伤害系数
		public const long pCriDmg = 10000;
		//基础魔法暴击伤害系数
		public const long mCriDmg = 5000;
		//基础物理偏斜减伤系数
		public const long pDevDmg = 5000;
		//基础魔法偏斜减伤系数
		public const long mDevDmg = 5000;
		//最高物理偏斜减伤系数
		public const long maxPDevDmg = 9000;
		//基础负重量
		public const long baseWgt = 100;
		//基础AP上限
		public const long baseAp = 3;
		//基础移动次数
		public const long baseMovN = 1;
		//基础攻击次数
		public const long baseAtkN = 1;
		//基础行动次数
		public const long baseActN = 1;
		//基础物防
		public const long basePDef = 0;
		//基础魔防
		public const long baseMDef = 0;
	}

	/**装备槽位使用类型*/
	public enum EquipmentSlotType{
		/**主手武器 */
		master = 1, 
		/**副手武器 */
		assistant = 2, 
		/**头部护具 */
		head = 3, 
		/**身体护具 */
		body = 4, 
		/**足部护具 */
		foot = 5, 
		/**饰品 */
		ornament = 6, 
		/**双手武器 */
		both = 7, 
	}

	/**装备类型 */
	public enum EquipmentType{
		/**单手匕首*/
		DanShouBiShou = 1001, 
		/**单手剑*/
		DanShouJian = 1002, 
		/**单手斧*/
		DanShouFu = 1003, 
		/**单手锤*/
		DanShouChui = 1004, 
		/**单手枪*/
		DanShouQiang = 1005, 
		/**单手骑枪*/
		DanShouQiQiang = 1006, 
		/**单手手弩*/
		DanShouShouNu = 1007, 
		/**单手短杖*/
		DanShouDuanZhang = 1008, 
		/**单手链锤*/
		DanShouLianChui = 1009, 
		/**单手药瓶*/
		DanShouYaoPing = 1010, 
		/**刺剑*/
		CiJian = 1011, 
		/**副手小盾*/
		FuShouXiaoDun = 2001, 
		/**副手中盾*/
		FuShouZhongDun = 2002, 
		/**副手大盾*/
		FuShouDaDun = 2003, 
		/**布甲头盔*/
		BuJiaTouKui = 3001, 
		/**皮甲头盔*/
		PiJiaTouKui = 3002, 
		/**锁甲头盔*/
		SuoJiaTouKui = 3003, 
		/**板甲头盔*/
		BanJiaTouKui = 3004, 
		/**布甲胸甲*/
		BuJiaXiongJia = 4001, 
		/**皮甲胸甲*/
		PiJiaXiongJia = 4002, 
		/**锁甲胸甲*/
		SuoJiaXiongJia = 4003, 
		/**板甲胸甲*/
		BanJiaXiongJia = 4004, 
		/**布甲靴子*/
		BuJiaXueZi = 5001, 
		/**皮甲靴子*/
		PiJiaXueZi = 5002, 
		/**锁甲靴子*/
		SuoJiaXueZi = 5003, 
		/**板甲靴子*/
		BanJiaXueZi = 5004, 
		/**饰品*/
		ShiPin = 6001, 
		/**双手剑*/
		ShuangShouJian = 7001, 
		/**双手斧*/
		ShuangShouFu = 7002, 
		/**双手锤*/
		ShuangShouChui = 7003, 
		/**双手枪*/
		ShuangShouQiang = 7004, 
		/**短弓*/
		DuanGong = 7005, 
		/**长弓*/
		ChangGong = 7006, 
		/**重弩*/
		ZhongNu = 7007, 
		/**双手杖*/
		ShuangShouZhang = 7008, 
		/**琴*/
		Qin = 7009, 
		/**物理徒手1*/
		TuShou = 7010, 
		/**法术徒手1 */
		FaShuTuShou = 7011, 
		/**物理徒手2 */
		WuLiTuShou2 = 7012, 
		/**法术徒手2 */
		FaShuTuShou2 = 7013, 
		/**物理徒手3 */
		WuLiTuShou3 = 7014, 
		/**法术徒手3 */
		FaShuTuShou3 = 7015, 
	}

	/**背包道具类型 */
	public enum BagItemType{
		/**装备, 需要到equipment表获得数据 */
		Equipment = 1, 
		/**材料(道具),需要到itembag表获得数据 */
		BagItem = 2, 
		/**宝石, 需要到baoshi表获得数据 */
		Gem = 3, 
	}

	/**材料道具类型 */
	public enum BagItem{
		/**银币类型 */
		Silver = 1, 
		/**钻石 */
		ZuanShi = 2, 
		/**食物 */
		ShiWu = 3, 
		/**材料 */
		CaiLiao = 4, 
		/**经验 */
		Exp = 5, 
		/**军团声望 */
		JunTuanShengWang = 6, 
		/**升级材料 */
		UpLevelCaiLiao = 7, 
		/**道具*/
		Prop = 8, 
		/**宝石 */
		Gem = 9, 
		/**技能提取保存技能信息类型 */
		SkillSaveExtraAttr = 10, 
		/**士气 */
		Morale = 12, 
		/**友好度*/
		Friendly = 13, 
		/**国家声望 */
		CountryPrestige = 17, 
		/**礼包 */
		GiftBag = 20, 
	}

	/**材料道具的具体性质 */
	public enum BagItemAddType{
		/**增加某项的具体数值,例如货币值，经验值等 */
		AddValue = 1, 
		/**增加道具数量 */
		AddItemCount = 2, 
	}

	/**背包道具类型对应表名称 */
	public class BagTypeJsonName{
		/**装备Equipments.json表名称，获取 BagTypeJsonName[0] == Equipments*/
		public const string Equipments = "Equipments";
		/**材料道具表, ItemBag.json */
		public const string BagItem = "BagItem";
		/**宝石表, Baoshi.json */
		public const string BaoShi = "BaoShi";
	}

	public enum ERoleProperty{
		hp = 0, 
		ap = 1, 
	}

	public class AllControlKey{
		/**成人年龄*/
		public const string adult = "adult";
		/**退休年龄（男）*/
		public const string retireAgeMale = "retireAgeMale";
		/**退休年龄(女)*/
		public const string retireAgeFemale = "retireAgeFemale";
		/**最大寿命（男）*/
		public const string lifeSpanMale = "lifeSpanMale";
		/**最大寿命（女）*/
		public const string lifeSpanFemale = "lifeSpanFemale";
		/**最大怀孕年龄(男)*/
		public const string childbearingAgeMale = "childbearingAgeMale";
		/**最大怀孕年龄(女)*/
		public const string childbearingAgeFemale = "childbearingAgeFemale";
		/**背包最大格子数*/
		public const string bagMax = "bagMax";
		/**背包最大叠加数*/
		public const string bagMaxSP = "bagMaxSP";
		/**玩家银币显示上限*/
		public const string silverCoinMax = "silverCoinMax";
		/**玩家钻石显示上限*/
		public const string diamondMax = "diamondMax";
		/**声望上限*/
		public const string prestigeMax = "prestigeMax";
		/**友好度上限*/
		public const string friendlinessMax = "friendlinessMax";
		/**士气上限*/
		public const string moraleMax = "moraleMax";
		/**强化单次最小值*/
		public const string minValue = "minValue";
		/**队伍人数上限*/
		public const string teamSize = "teamSize";
		/**MVP系数*/
		public const string mvp = "mvp";
		/**感知转换魔攻*/
		public const string perToMAtk = "perToMAtk";
		/**力量转换物攻*/
		public const string strToPAtk = "strToPAtk";
		/**技巧转换物理命中*/
		public const string dexToPHit = "dexToPHit";
		/**技巧转换物理暴击*/
		public const string dexToPCri = "dexToPCri";
		/**感知转换魔法暴击*/
		public const string wilToMCri = "wilToMCri";
		/**技巧转换格挡概率*/
		public const string dexToBlk = "dexToBlk";
		/**技巧转换架招概率*/
		public const string dexToPry = "dexToPry";
		/**真实敏捷转换物理暴击抵扣系数*/
		public const string bAgiToPDCri = "bAgiToPDCri";
		/**真实敏捷转换物防忽略概率*/
		public const string agiToIgnoreDef = "agiToIgnoreDef";
		/**意志转换魔法命中*/
		public const string wilToMHit = "wilToMHit";
		/**意志转换魔法暴击抵扣系数*/
		public const string wilToMDCri = "wilToMDCri";
		/**体质转换生命值上限*/
		public const string vitToHp = "vitToHp";
		/**体质转换理想负重上限*/
		public const string vitToWgt = "vitToWgt";
		/**溢出理论负重上限的负重量转换真实敏捷惩罚*/
		public const string overWgtToAgi = "overWgtToAgi";
		/**实际负重量转换真实敏捷惩罚*/
		public const string agiToWgt = "agiToWgt";
		/**武器攻击力转换招架防御值*/
		public const string wAtkToPryDef = "wAtkToPryDef";
		/**感知转换受到的额外治疗值*/
		public const string perToHeal = "perToHeal";
		/**基础物理暴击伤害系数*/
		public const string pCriDmg = "pCriDmg";
		/**基础魔法暴击伤害系数*/
		public const string mCriDmg = "mCriDmg";
		/**基础物理偏斜减伤系数*/
		public const string pDevDmg = "pDevDmg";
		/**基础魔法偏斜减伤系数*/
		public const string mDevDmg = "mDevDmg";
		/**最高偏斜减伤系数*/
		public const string maxDevDmg = "maxDevDmg";
		/**基础负重量*/
		public const string baseWgt = "baseWgt";
		/**基础AP上限*/
		public const string baseAp = "baseAp";
		/**基础移动次数*/
		public const string baseMovN = "baseMovN";
		/**基础攻击次数*/
		public const string baseAtkN = "baseAtkN";
		/**基础行动次数*/
		public const string baseActN = "baseActN";
		/**附魔冷却基础价格*/
		public const string basicCoolPirce = "basicCoolPirce";
		/**附魔刷新冷却时间*/
		public const string nextFreeRefresh = "nextFreeRefresh";
		/**玩家邮箱上限*/
		public const string playerMailLimit = "playerMailLimit";
		/**邮件最大保存期*/
		public const string maxMailSave = "maxMailSave";
		/**非特产国家系数*/
		public const string transferPro = "transferPro";
		/**跑商任务刷新时间*/
		public const string runBusinessRefresh = "runBusinessRefresh";
		/**物资刷新时间*/
		public const string goodsRefreshTime = "goodsRefreshTime";
		/**酒馆刷新时间*/
		public const string tavernRefreshTime = "tavernRefreshTime";
		/**初始士气*/
		public const string initialMorale = "initialMorale";
		/**价格查询*/
		public const string queryGoodsPrice = "queryGoodsPrice";
		/**收取封地建筑月份*/
		public const string collectMonth = "collectMonth";
		/**额外封地建筑价格*/
		public const string addBuildingPrice = "addBuildingPrice";
		/**装备品质系数*/
		public const string equipQualityCoefficient = "equipQualityCoefficient";
		/**附加技能系数*/
		public const string skillCoefficient = "skillCoefficient";
		/**爵位相同基础相亲概率*/
		public const string basicEngagementPro = "basicEngagementPro";
		/**爵位大1基础相亲概率*/
		public const string basicEngagementPro_1 = "basicEngagementPro_1";
		/**相亲刷新月份*/
		public const string engagementRefreshTime = "engagementRefreshTime";
		/**参加相亲最低爵位*/
		public const string engagementMinNobility = "engagementMinNobility";
		/**参加宴会最低爵位*/
		public const string banquetMinNobility = "banquetMinNobility";
		/**宴会解锁地区的爵位等级*/
		public const string banquetUnlockAreaNobility = "banquetUnlockAreaNobility";
		/**宴会指定地区的主血脉人数*/
		public const string banquetRoyalBloodNum = "banquetRoyalBloodNum";
		/**宴会举办间隔时间*/
		public const string banquetInterval = "banquetInterval";
		/**宴会相亲对象人数*/
		public const string banquetActorNum = "banquetActorNum";
		/**相亲媒人ID*/
		public const string matchmakerID = "matchmakerID";
		/**相亲人员不出现特性*/
		public const string noneActorCha = "noneActorCha";
		/**城镇任务刷新时间*/
		public const string cityTaskRefreshTime = "cityTaskRefreshTime";
		/**跑商NPCID*/
		public const string runBusnessNPC_ID = "runBusnessNPC_ID";
		/**领取冷却间隔*/
		public const string cooltime = "cooltime";
		/**招募性别系数男*/
		public const string recruitMale = "recruitMale";
		/**招募性别系数女*/
		public const string recruitFemale = "recruitFemale";
		/**银币招募常数*/
		public const string silverCoinRecruitC = "silverCoinRecruitC";
		/**新出生角色初始职业*/
		public const string jobs = "jobs";
		/**初始等级*/
		public const string actorLevel = "actorLevel";
		/**历练获取经验职业系数*/
		public const string jobCoefficient = "jobCoefficient";
		/**历练额外位置价格*/
		public const string experiencePositionPrice = "experiencePositionPrice";
		/**学员最小年龄*/
		public const string studentAgetMin = "studentAgetMin";
		/**历练师徒最小等级差值*/
		public const string levelDifferenceMin = "levelDifferenceMin";
		/**历练教官最低等级*/
		public const string teacherLevelMin = "teacherLevelMin";
		/**短期历练银币花费*/
		public const string experience1Price = "experience1Price";
		/**长期历练银币花费*/
		public const string experience2Price = "experience2Price";
		/**短期历练月份范围*/
		public const string experience1Month = "experience1Month";
		/**短期历练月份随机概率*/
		public const string experience1MonthPro = "experience1MonthPro";
		/**短期历练月份范围*/
		public const string experience2Month = "experience2Month";
		/**短期历练月份随机概率*/
		public const string experience2MonthPro = "experience2MonthPro";
		/**友好度声望转化比*/
		public const string transforF_P = "transforF_P";
		/**物资类型*/
		public const string consumeType = "consumeType";
		/**功能道具类型*/
		public const string otherType = "otherType";
		/**传授教官最低等级*/
		public const string teachLevel = "teachLevel";
		/**学校教师最低年龄*/
		public const string teacherAgeMin = "teacherAgeMin";
		/**不可传授职业id*/
		public const string noTeachJobID = "noTeachJobID";
		/**传授额外花费*/
		public const string teachAdditionalSpend = "teachAdditionalSpend";
		/**学校重点培养出现年龄*/
		public const string schoolAge = "schoolAge";
		/**教师维护费用*/
		public const string teacherWage = "teacherWage";
		/**学费每月价格*/
		public const string tuition = "tuition";
		/**学校学习特性数量上限*/
		public const string studyChaMax = "studyChaMax";
		/**育鹰厅建造价格*/
		public const string yuyingtingPrice = "yuyingtingPrice";
		/**重点培养成功率加成*/
		public const string keyTrainingRate = "keyTrainingRate";
		/**宴会道具成功率使用上限*/
		public const string banquetPropSuccessMax = "banquetPropSuccessMax";
		/**婚宴花童年龄范围*/
		public const string flowerGirlsAge = "flowerGirlsAge";
		/**每日服务器刷新时间*/
		public const string serverDailyRefresh = "serverDailyRefresh";
		/**花童最多可学特性数量*/
		public const string flowerGirlsStudyNum = "flowerGirlsStudyNum";
		/**参加婚礼抢捧花人数*/
		public const string weddingNum = "weddingNum";
		/**物品增加通知提示类型*/
		public const string itemType = "itemType";
		/**佣兵团改名费用*/
		public const string renamePrice = "renamePrice";
		/**变更旗帜费用*/
		public const string flagPrice = "flagPrice";
		/**相亲对象初始职业*/
		public const string engagementActorJob = "engagementActorJob";
		/**角色任职最短时间*/
		public const string actorOnMonth = "actorOnMonth";
		/**变更岗位花费*/
		public const string changerPrice = "changerPrice";
		/**角色最大永久特性数量（不计学校获得）*/
		public const string actorChaMAX = "actorChaMAX";
		/**通用特性初始数量随机*/
		public const string generalChaNum = "generalChaNum";
		/**种族专属特性最大种类*/
		public const string descentChaMaxType = "descentChaMaxType";
		/**国家特性随机概率*/
		public const string countryChaRandomRate = "countryChaRandomRate";
		/**佣兵团名称最长字符*/
		public const string legionNameMax = "legionNameMax";
		/**角色名称最长字符*/
		public const string actorNameMax = "actorNameMax";
		/**衰老年龄1*/
		public const string growOld1 = "growOld1";
		/**衰老年龄2*/
		public const string growOld2 = "growOld2";
		/**混血随机特性概率*/
		public const string randomChaRate = "randomChaRate";
		/**佣兵团名称最少字符*/
		public const string legionNameMin = "legionNameMin";
		/**角色名称最少字符*/
		public const string actorNameMin = "actorNameMin";
		/**士气真实值与显示值的差值*/
		public const string moraleDifference = "moraleDifference";
		/**军团工资结算时间*/
		public const string wageSettlementTime = "wageSettlementTime";
		/**军团圣物效果刷新价格*/
		public const string sacredEffectRefresh = "sacredEffectRefresh";
		/**圣物解绑价格*/
		public const string unboundPrice = "unboundPrice";
		/**军团圣物转换消耗*/
		public const string sacredTransforConsume = "sacredTransforConsume";
		/**军团圣物装备所需最低职位*/
		public const string sacredPositionMinID = "sacredPositionMinID";
		/**不可转化圣物的装备类型*/
		public const string noTransforEquipType = "noTransforEquipType";
		/**圣物效果数量随机*/
		public const string sacredEffectRandom = "sacredEffectRandom";
		/**士气递减封顶月数*/
		public const string moraleDiminishingMonth = "moraleDiminishingMonth";
		/**神令每日免费领取数量*/
		public const string shengling = "shengling";
		/**扫荡劵每日免费领取数量*/
		public const string saodangjuan = "saodangjuan";
		/**精神创伤冷却期*/
		public const string spiritCoolTime = "spiritCoolTime";
		/**恶化伤病ID*/
		public const string worsenInjuryID = "worsenInjuryID";
		/**军团士气递减触发月数*/
		public const string triggerMoraleDiminishing = "triggerMoraleDiminishing";
		/**初始军团技能等级*/
		public const string legionBuffLevel = "legionBuffLevel";
		/**生病启动后判定月份*/
		public const string injuryOpenJudgeMonth = "injuryOpenJudgeMonth";
		/**疾病爆发每年提高概率*/
		public const string contagionAnnuallyAddPro = "contagionAnnuallyAddPro";
		/**疾病爆发数占总人口比*/
		public const string contagionNumPro = "contagionNumPro";
		/**军团技能最大等级*/
		public const string legionBuffLevelMax = "legionBuffLevelMax";
		/**触发战斗伤的任务类型*/
		public const string triggerInjuryTaskType = "triggerInjuryTaskType";
		/**战斗中被击倒的受伤概率*/
		public const string battleInjuryRate = "battleInjuryRate";
		/**角色入队满月份提需求*/
		public const string actorJoinMonth = "actorJoinMonth";
		/**每年角色需求判断月份*/
		public const string actorDemandJudgeMonth = "actorDemandJudgeMonth";
		/**角色需求触发人数占入团总人数万分比*/
		public const string actorDemandRate = "actorDemandRate";
		/**触发角色个人需求最大人数上限*/
		public const string actorDemandMaxNum = "actorDemandMaxNum";
		/**未成年人夭折基础概率*/
		public const string juvenilesDeathRate = "juvenilesDeathRate";
		/**个人需求冷却期*/
		public const string actorDemandCoolMonth = "actorDemandCoolMonth";
		/**军团职位收费月份*/
		public const string legionPositionMonth = "legionPositionMonth";
		/**未满足需求追加权重值*/
		public const string unsatisfiedAddWeight = "unsatisfiedAddWeight";
		/**需求奖金系数随机范围*/
		public const string bonusRandomRange = "bonusRandomRange";
		/**每种需求的初始权重*/
		public const string demandInitialWeight = "demandInitialWeight";
		/**年龄差值常数*/
		public const string ageDifference = "ageDifference";
		/**物资需求系数启动月数*/
		public const string goodDemandOpenMonth = "goodDemandOpenMonth";
		/**固定物资服役月数值*/
		public const string fixedGoodMonth = "fixedGoodMonth";
		/**非固定物资服役月数值*/
		public const string unfixedGoodMonth = "unfixedGoodMonth";
		/**角色获得负面特性概率*/
		public const string actorNegativeRate = "actorNegativeRate";
		/**角色获得负面特性追加概率*/
		public const string actorNegativeAddRate = "actorNegativeAddRate";
		/**委托任务执行人数*/
		public const string taskEntrusPeopleNum = "taskEntrusPeopleNum";
		/**委托小队队长年龄*/
		public const string entrusCaptainAge = "entrusCaptainAge";
		/**队长职业要求*/
		public const string entrusCaptainJobLevel = "entrusCaptainJobLevel";
		/**主线最后任务ID*/
		public const string mainLastTaskID = "mainLastTaskID";
		/**委托任务刷新钻石数*/
		public const string taskEntrusRefreshPrice = "taskEntrusRefreshPrice";
		/**委托任务刷新时间*/
		public const string taskEntrusRefreshTime = "taskEntrusRefreshTime";
		/**委托任务免费刷新间隔时间*/
		public const string freeRefreshCoolTime = "freeRefreshCoolTime";
		/**委托任务立即完成单月钻石基数*/
		public const string doneBasicPrice = "doneBasicPrice";
		/**最大怀孕次数*/
		public const string pregnantTimeMax = "pregnantTimeMax";
		/**怀孕间隔月数*/
		public const string pregnantCoolMonth = "pregnantCoolMonth";
		/**生育所需月数*/
		public const string birthMonth = "birthMonth";
		/**生女孩的概率*/
		public const string girlRate = "girlRate";
		/**特性状态“未知”描述*/
		public const string chaUnknownDes = "chaUnknownDes";
		/**标签显示要求血脉比例*/
		public const string labelDisplayBloodRate = "labelDisplayBloodRate";
		/**征兵基础回信概率*/
		public const string replyBasicRate = "replyBasicRate";
		/**回信冷却月份*/
		public const string replyMonth = "replyMonth";
		/**回信随机月范围*/
		public const string replyMonthMax = "replyMonthMax";
		/**每多一个角色回信增加值*/
		public const string singleAddRate = "singleAddRate";
		/**最大征兵回信概率*/
		public const string replyRateMax = "replyRateMax";
		/**商店礼包折扣随机范围*/
		public const string giftBagRandomRange = "giftBagRandomRange";
		/**商店特产折扣随机范围*/
		public const string goodsRandomRange = "goodsRandomRange";
		/**折扣率最小变化值*/
		public const string discountRateMin = "discountRateMin";
		/**周日特产国家*/
		public const string sundayCountryID = "sundayCountryID";
		/**赛季开始时间*/
		public const string seasonStartTime = "seasonStartTime";
		/**赛季结束时间*/
		public const string seasonEndTime = "seasonEndTime";
		/**委托任务钻石购买价格*/
		public const string entrustBuyPrice = "entrustBuyPrice";
		/**委托任务每日免费刷新次数*/
		public const string entrustFreeRefreshTime = "entrustFreeRefreshTime";
		/**双胞胎概率*/
		public const string brithRate = "brithRate";
		/**第一个孩子标识*/
		public const string firstChildIcon = "firstChildIcon";
		/**第二个孩子标识*/
		public const string secondChildIcon = "secondChildIcon";
		/**战力榜单团上榜人数*/
		public const string rankPeopleNum = "rankPeopleNum";
		/**委托奖励邮件ID*/
		public const string entrustRewardMail = "entrustRewardMail";
		/**角色升级进度条配置*/
		public const string speedConfig = "speedConfig";
		/**无家族成员提示*/
		public const string noFamilyText = "noFamilyText";
		/**竞技场次数购买价格*/
		public const string arenaTimePrice = "arenaTimePrice";
		/**排行榜奖励邮件ID*/
		public const string rankRewardMail = "rankRewardMail";
		/**初始主线任务ID*/
		public const string initialTaskMain = "initialTaskMain";
		/**衰老特性ID*/
		public const string oldChaID = "oldChaID";
		/**未成年人夭折判定开始月份*/
		public const string juvenilesDeathOpenMonth = "juvenilesDeathOpenMonth";
		/**夭折判定周期月份*/
		public const string juvenilesDeathCycle = "juvenilesDeathCycle";
		/**重伤HP界限*/
		public const string seriouslyHpLimit = "seriouslyHpLimit";
		/**濒死HP界限*/
		public const string dyingHpLimit = "dyingHpLimit";
		/**竞技场周礼包结算时间*/
		public const string arenaWeeklyST = "arenaWeeklyST";
		/**竞技场奖励邮件ID*/
		public const string arenaMailID = "arenaMailID";
		/**夭折邮件id*/
		public const string juvenilesDeathMailID = "juvenilesDeathMailID";
		/**组队副本人数*/
		public const string teamBattlePlayerNum = "teamBattlePlayerNum";
		/**连续签到VIP等级*/
		public const string signVipLeve = "signVipLeve";
		/**随机基础hp范围*/
		public const string radomBastcHpRanger = "radomBastcHpRanger";
		/**六维出生随机值*/
		public const string randomBirthSixD = "randomBirthSixD";
		/**单个副本每日参与次数*/
		public const string singelBattleDailyTimes = "singelBattleDailyTimes";
		/**主线副本挑战次数*/
		public const string mainBattleTimes = "mainBattleTimes";
		/**支线副本挑战次数*/
		public const string branchBattleTimes = "branchBattleTimes";
		/**组队副本购买挑战次数价格*/
		public const string teamBattleBuyTimesPrice = "teamBattleBuyTimesPrice";
		/**组队副本人员已满提示*/
		public const string teamBattleFullTips = "teamBattleFullTips";
		/**组队副本奖励邮件ID*/
		public const string teamBattleRewardMailID = "teamBattleRewardMailID";
		/**兑换码邮件模板id*/
		public const string exchangeCode = "exchangeCode";
		/**爬塔解锁友好度等级*/
		public const string unlockClimbTower = "unlockClimbTower";
		/**爬塔重置类型*/
		public const string resetClimbTowerType = "resetClimbTowerType";
		/**爬塔NpcID*/
		public const string climbTowerNPCid = "climbTowerNPCid";
		/**爬塔商店随机商品掉落个数*/
		public const string climbTowerShopRandomNum = "climbTowerShopRandomNum";
		/**特殊职业id*/
		public const string specialJobsID = "specialJobsID";
		/**爬塔答题未完成对话*/
		public const string climbTowerDoneDialog = "climbTowerDoneDialog";
		/**爬塔答题已完成对话*/
		public const string climbTowerIncompleteDialog = "climbTowerIncompleteDialog";
		/**爬塔跨周期提示文本*/
		public const string climbTowerCloseTipsID = "climbTowerCloseTipsID";
		/**爬塔赛季结束自动补偿结算时间*/
		public const string clmibTowerCompensateMailSendTime = "clmibTowerCompensateMailSendTime";
		/**爬塔补偿邮件ID*/
		public const string clmibTowerCompensateMailID = "clmibTowerCompensateMailID";
		/**爬塔获取卡牌文本*/
		public const string clmibTowerGetCardTips = "clmibTowerGetCardTips";
		/**每周数据重置时间*/
		public const string weeklyResetTime = "weeklyResetTime";
		/**技能基础战力*/
		public const string skillBasicUseless = "skillBasicUseless";
		/**速度战力系数*/
		public const string seedUselessCoefficient = "seedUselessCoefficient";
		/**六维战力系数*/
		public const string sixUselessCoefficient = "sixUselessCoefficient";
		/**HP战力系数*/
		public const string hpUselessCoefficient = "hpUselessCoefficient";
		/**AP战力系数*/
		public const string apUselessCoefficient = "apUselessCoefficient";
		/**物理爆伤战力系数*/
		public const string pdUselessCoefficient = "pdUselessCoefficient";
		/**魔法爆伤战力系数*/
		public const string mdUselessCoefficient = "mdUselessCoefficient";
		/**战力隐藏*/
		public const string uselessHide = "uselessHide";
		/**武器附加招架率计算系数*/
		public const string armsTranPryCoefficient = "armsTranPryCoefficient";
		/**基础治疗系数*/
		public const string basicHealCoefficient = "basicHealCoefficient";
		/**负重惩罚系数*/
		public const string weightCoefficient = "weightCoefficient";
		/**基础物理防御值*/
		public const string basePDef = "basePDef";
		/**基础魔法防御值*/
		public const string baseMDef = "baseMDef";
		/**不显示AP图标职业*/
		public const string noApJobs = "noApJobs";
		/**游戏起始年份*/
		public const string startYear = "startYear";
		/**杀敌数兑换升品值比例*/
		public const string killNum = "killNum";
		/**辅助/治疗兑换升品值比例*/
		public const string assTreatNum = "assTreatNum";
		/**升品值不足提示*/
		public const string promoteUpNe = "promoteUpNe";
		/**剧情玩家角色*/
		public const string plotActor = "plotActor";
		/**技能学习随机结果最大数量*/
		public const string studySkillRandomResultNum = "studySkillRandomResultNum";
		/**爵位前缀排序特性类型优先级*/
		public const string chaPrefixRank = "chaPrefixRank";
	}

	/** 战斗中回合状态*/
	public enum EBattleRoundStatus{
		//所有
		all = 1, 
		//所有
		isMy = 2, 
		//我方
		notMy = 3, 
	}

	/**货币类型 */
	public enum MoneyType{
		/**0未知 */
		None = 0, 
		/**1银币 */
		Silver = 1, 
		/**2钻石 */
		ZuanShi = 2, 
	}

	/**战斗场景循环状态 */
	public enum EBattleSceneCycleStatus{
		//玩家准备
		ready = 0, 
		//战斗场景正式开始
		start = 1, 
		//战斗回合开始时点
		roundBegin = 2, 
		//战斗回合操作循环
		roundActive = 3, 
		//战斗回合结束时点
		roundEnd = 4, 
		//战斗场景结束
		battleEnd = 5, 
		//结算数据
		result = 6, 
		//场景销毁，清除本线程上所有本场景相关数据
		destroy = 7, 
	}

	/**战斗角色状态 */
	public enum EBattleActorStatus{
		//未进入逻辑地图
		remove = 1, 
		//已进入逻辑地图
		enter = 2, 
		//逻辑地图上死亡
		dead = 3, 
		//逻辑地图上撤离
		escape = 4, 
		//忽视地形惩罚
		ignoreTileCost = 12, 
		//忽视角色阻碍
		ignoreActorObstruct = 13, 
		//惊惧(禁止反击)
		fright = 15, 
		//恐惧(禁止行动)
		fear = 16, 
		//缠绕(禁止移动)
		twine = 17, 
		//豁免惊惧
		ignoreFright = 18, 
		//豁免恐惧
		ignoreFear = 19, 
		//禁止当前HP增加
		forbidCurHpAdd = 20, 
	}

	/**移动状态 */
	public enum EMoveCycleStatus{
		//进入格子
		enter = 1, 
		//进入格子
		leave = 2, 
	}

	/**攻击状态 */
	public enum EAtkCycleStatus{
		//选择主目标时
		selectMainTarget = 1, 
		//使用技能前时
		beforeUseSkill = 2, 
		//AP消耗计算时
		apConsumeCount = 3, 
		//AP消耗结算时
		apConsumeSettle = 4, 
		//进行伤害计算流程
		runDmgCount = 5, 
		//偏斜结算时
		hitSettle = 6, 
		//暴击结算时
		criSettle = 7, 
		//防御完全穿透结算时
		ignoreDefSettle = 8, 
		//格挡结算时
		blkSettle = 9, 
		//招架结算时
		prySettle = 10, 
		//伤害值计算开始时
		dmgCountBegin = 11, 
		//伤害值计算结束时
		dmgCountEnd = 12, 
		//受到攻击伤害前时
		onDmgBefore = 13, 
		//致死性结算时
		killSettle = 14, 
		//伤害结算时
		onDmgSettle = 15, 
		//击杀结算时
		deedSettle = 16, 
		//使用技能后时
		afterUseSkill = 17, 
		//攻击结束时
		atkEnd = 18, 
	}

	/** 技能伤害类型 */
	public enum ESkillDamageType{
		/** 未知 */
		None = 0, 
		/** 物理伤害 */
		WuLi = 1, 
		/** 法术伤害 */
		FaShu = 2, 
		/** 斩击 */
		ZhanJi = 3, 
		/** 突刺 */
		TuCi = 4, 
		/** 钝击 */
		DunJi = 5, 
		/** 近战 */
		JinZhan = 6, 
		/** 远程 */
		YuanCheng = 7, 
		/** 治疗*/
		ZhiLiao = 8, 
		/** 辅助*/
		FuZhu = 9, 
	}

	public enum EEffectConditionType{
		//处于战斗场景[EBattleSceneCycleStatus]阶段时
		battleSceneCycleStatus = 1, 
		//战场回合类型为[EBattleRoundStatus]时
		battleRoundStatus = 2, 
		//移动时点[EMoveCycleStatus]时
		moveCycleStatus = 3, 
		//攻击时点[EAtkCycleStatus]时
		atkCycleStatus = 4, 
		//装备槽[EquipmentSlotType]穿戴装备时
		equipSlotWear = 5, 
		//装备槽[EquipmentSlotType]未穿戴装备时
		equipSlotNotWear = 6, 
		//穿戴ID为[手填数值]的装备时
		wearTargetEquip = 7, 
		//使用的技能伤害类型为[ESkillDamageType]时
		useSkillDamageType = 8, 
		//受到的技能伤害类型为[ESkillDamageType]时
		acceptSkillDamageType = 9, 
		//战斗场景中首次主动攻击时
		firstAtkAction = 10, 
		//受到攻击伤害前时
		onDmgBefore = 11, 
		//主动攻击宣言时
		atkActionDeclare = 12, 
		//主动攻击时
		initiativeAtkAction = 13, 
		//击杀攻击目标时
		killAtkTarget = 14, 
		//主动攻击命中时
		initiativeAtkHit = 15, 
		//消耗的AP值大于[手填数值]时
		consumeAp = 16, 
		//偏斜判定结算为[EYesAndNo]时
		devSettle = 17, 
		//暴击判定结算为[EYesAndNo]时
		criSettle = 18, 
		//格挡判定结算为[EYesAndNo]时
		blkSettle = 19, 
		//架招判定结算为[EYesAndNo]时
		prySettle = 20, 
		//[EActorAttrType]属性高于受攻击目标时
		attrFiner = 21, 
		//自身周围[手填数值]格范围内[ETeamType]阵营角色受到攻击伤害前检测
		areaOnDmgBeforeCheck = 22, 
		//ID为[手填数值]的buff持续时间结束时
		buffStop = 23, 
		//消耗的当前移动力大于[手填数值]时
		consumeCurMov = 24, 
		//职业为[EMonsterOccuType]时
		jobCheck = 25, 
		//装备槽[EquipmentSlotType]穿戴装备为[EquipmentType]时
		equipSlotWearEquipType = 26, 
		//0~10000随机取值数小于[手填数值]时
		randomCheck = 27, 
		//0~10000随机取值数小于[EActorAttrType]属性经过当前等级rate表换算值时
		randomCheckByAttr = 28, 
		//受到致死性伤害时
		dmgCanKill = 29, 
		//同阵营角色移动进入自身周围[手填数值]格范围内
		areaIdenticalCampMoveEnterCheck = 30, 
		//处于[ESlotType]类型的格子中时
		onTileType = 31, 
		//反击时
		isResistAtk = 32, 
		//异阵营角色移动进入自身周围[手填数值]格范围内
		areaDifferentCampMoveEnterCheck = 33, 
		//被动进入战斗时
		passiveAtkAction = 34, 
		//ap值大等于于[手填数值]时
		curApNum = 35, 
		//当前生命值低于生命值上限的百分之[手填数值]时
		curHpParLimit = 36, 
		//目标职业为[EMonsterOccuType]时
		targetOccu = 37, 
		//[EActorAttrType]属性小于[手填数值]时
		attrMinLimit = 38, 
		//任意装备槽穿戴护甲类型为[EArmorType]时
		armorTypeCheck = 39, 
		//自身周围[手填数值]格范围内[ETeamType]阵营角色进行伤害计算前检测检测
		areaRunDmgCountBeforeCheck = 40, 
		//目标当前伤害计算过程中攻击者[EActorAttrType]属性小于自身时
		targetDmgContextAttackerAttrComparisonCheck = 41, 
		//伤害过程中受攻击目标[EActorAttrType]属性小于自身时
		targetAttrComparisonCheck = 42, 
		//受击方抢攻时
		mainReceiverGrabRAtk = 43, 
		//进入[ESlotType]类型格子时
		enterTargetTypeTile = 44, 
		//走出[ESlotType]类型格子时
		leaveTargetTypeTile = 45, 
		//与技能使用者距离为1的[ETeamType]阵营角色被指定为技能目标并即将受到伤害类型为[ESkillDamageType]的技能伤害时
		neighborRunDmgCountBeforeTypeCheck = 46, 
		//目标角色性别为[SexType]
		targetActorSex = 47, 
		//身上的任意装备槽存在[EquipmentType]装备时
		wearEquipType = 48, 
		//身上的任意装备槽不存在[EquipmentType]装备时
		notWearEquipType = 49, 
		//自身进入格子时
		entryTile = 50, 
		//角色的一次行动结束时
		actorActivityEnd = 51, 
		//角色途经本格子时，行动起点和终点都不在该格子上
		passByTile = 52, 
		//地图内存在空格时
		mapHasEmptyTile = 53, 
		//目标为主攻击目标时
		isAtkMainTarget = 54, 
		//目标为我方或者友方时
		mainTargetIsFriend = 55, 
		//为新攻击流程时点[EBattleAttackActionCycle]时
		onEBattleAttackActionCycle = 56, 
		//为新技能行动流程时点[EBattleUseSkillActionCycle]时
		onEBattleUseSkillActionCycle = 57, 
		//为新技能伤害效果执行流程时点[EBattleDmgEffectCycle]时
		onEBattleDmgEffectCycle = 58, 
	}

	/**效果结果 */
	public enum EEffectResult{
		//[EActorAttrType]属性增加[手填数值]
		addQuotaAttr = 1, 
		//[EActorAttrType]属性增加[EActorAttrType]属性的百分之[手填数值]
		addAttrByOtherAttrPer = 2, 
		//[EActorAttrType]属性自身与目标的[EActorAttrType]属性差值的百分之[手填数值]
		addAttrByContrastAttrDiffPer = 3, 
		//增加[EBattleActorStatus]状态
		addBattleActorStatus = 4, 
		//新增持续[手填数值]回合，MID为[手填数值]的Buff
		addBuff = 5, 
		//将目标向攻击来源的反方向击退[手填数值]格，在击退过程中存在阻碍则停止
		repelTarget = 6, 
		//[EActorAttrType]属性增加攻击伤害的百分之[手填数值]
		addAttrByDmgNum = 7, 
		//移动到攻击目标方向的身后[手填数值]格，在攻击目标身后移动过程中存在阻碍则停止
		penetrateTarget = 8, 
		//造成基础攻击力为[手填数值],攻击类型为[手填数值]的伤害
		fixedFinalDamage = 9, 
		//造成攻击类型为[手填数值]，基础攻击力依照伤害类型，取物攻数值或魔攻数值的伤害
		fixedBaseDamage = 10, 
		//造成攻击类型为[手填数值]，基础攻击力依照伤害类型，取物攻数值或魔攻数值的伤害
		commonDamage = 11, 
		//恢复最终治疗值为[手填数值]的血量
		fixedFinalCure = 12, 
		//恢复基础治疗值为[手填数值]的血量
		fixedBaseCure = 13, 
		//恢复基础治疗值为魔攻数值的血量
		commonCure = 14, 
		//修改角色主动攻击技能，MID为[手填数值]
		changeAtkSkill = 15, 
		//修改角色反击攻击技能，MID为[手填数值]
		changeResistSkill = 16, 
		//[EActorAttrType]属性增加自身与目标的曼哈顿距离的百分之[手填数值]
		basedTargetNumAddAttr = 17, 
		//[EActorAttrType]属性增加自身与目标的曼哈顿距离的百分之[手填数值]
		addAttrByManhattanDistancePer = 18, 
		//与目标交互站立位置
		exchangeTile = 19, 
		//替换受攻击对象
		replaceBeAttacker = 20, 
		//伤害计算时的受击方防御计算结果减少受击方当前护甲防御力数值
		dmgContextDefNumDetachCurArmorDef = 21, 
		//造成HP最大值属性的百分之[手填数值]的伤害
		fixedHpPerDamage = 22, 
		//恢复HP最大值属性的百分之[手填数值]的血量
		fixedHpPerCure = 23, 
		//[EActorAttrType]属性获得[手填数值]为基础的自身与攻击方曼哈顿距离为倍数的提升
		addDHitNumByRandomPer = 24, 
		//[EActorAttrType]属性获得[手填数值]为基础的自身与攻击方曼哈顿距离为倍数的提升
		addAttrByAttackerManhattanDistanceTimes = 25, 
		//将指定的一名其他目标传送到自己周围最近的空格子，从自身朝向前方顺时针选择格子
		transferToNeighborTile = 26, 
		//使指定空格子处于角色无法位于其上和无法穿越（地形阻碍）状态
		setTileTypeZuAi = 27, 
		//指定格子[手填数值]回合内，将会对处于格子上的角色挂载ID为[手填数值]的地形Buff
		addTileTemporaryBuff = 28, 
		//清除[ETeamType]阵营角色在所有战斗开始后获得的[ActorBuffType]的buff。当前所在的地形buff和被光环覆盖的buff不会被清除。
		cleanActorBattleBuffByActorBuffType = 29, 
		//本效果结束时，[EActorAttrType]属性增加[手填数值]
		addAttrInTimeout = 30, 
		//角色自身[手填数值]回合内暂时离场，并停止所有时限BUFF的逻辑结算，并在离场的回合数内召唤一名使用指定的我方角色的战场初始数据作为角色数据的召唤单位。召唤单位死亡或者到达离场回合数后离场，并让角色回到场内
		morphTempMirror = 31, 
		//使技能目标周围[手填数值]距离内的[ETeamType]阵营角色受到本次百分之[手填数值]的伤害
		diffusionDamage = 32, 
		//造成[手填数值]百分比攻击力的伤害
		atkNumPerDamage = 33, 
		//本效果结束时，[EActorAttrType]属性增加[手填数值]百分比
		addPerAttrInTimeout = 34, 
		// 对目标格子，增加持续时长为[手填数值]回合，mID为[手填数值]的地形Buff(TopographyBuff表里的buff)
		tileAddTemporaryBuff = 35, 
		//造成攻击类型为[手填数值]，基础攻击力依照伤害类型，取物攻数值或魔攻数值的伤害
		adaptionJobDamage = 36, 
	}

	/** 效果目标类型*/
	public enum EEffectTarget{
		//全体
		all = 1, 
		//我方
		identity = 2, 
		//我方及友方
		friend = 3, 
		//非我方
		different = 4, 
		//非我方及友方
		notFriend = 5, 
		//自己
		self = 6, 
		//我方（不包含自己）
		colleague = 7, 
		//格子
		tile = 8, 
		//空格子
		emptyTile = 9, 
	}

	/** 技能类型枚举*/
	public enum ESkillGroupType{
		//主动技能
		initiative = 1, 
		//被动技能
		passive = 2, 
		//固定增益技能
		fixedSkill = 3, 
		//条件触发技能
		condition = 4, 
		//buff技能
		buff = 5, 
		//多重复合技能
		complex = 6, 
	}

	/** 主动攻击技能类型*/
	public enum EInitiativeAtkType{
		passive = 0, 
		initiativeAtk = 1, 
		resistAtk = 2, 
		allAtk = 3, 
	}

	/** 是否展示*/
	public enum EisShow{
		no = 0, 
		yes = 1, 
	}

	/** 是和否*/
	public enum EYesAndNo{
		no = 0, 
		yes = 1, 
	}

	/**职业组*/
	public enum EJobGroup{
		//布甲
		cloth = 1, 
		//皮甲
		leather = 2, 
		//链甲
		chain = 3, 
		//板甲
		plate = 4, 
		//近战
		melee = 5, 
		//远程
		remote = 6, 
		//轻步兵
		lightInfantry = 7, 
		//骑兵
		cavalry = 8, 
		//弓兵
		archer = 9, 
		//重步兵
		heavyInfantry = 10, 
		//特殊职业
		special = 11, 
		//全职业
		all = 12, 
	}

	/**道具ID定义 */
	public enum BagItemID{
		/**银币 */
		Silver = 2000200, 
		/**经验 */
		Exp = 2000270, 
		/**钻石 */
		ZuanShi = 2000300, 
		/**军团声望*/
		corpsPrestige = 2000280, 
		/**神令 */
		GodMake = 2000298, 
		/**扫荡券 */
		Sweeping = 2000299, 
		/**士气 */
		Morale = 2000279, 
		/**荷尔沃声望 */
		heerwoPrestige = 2000301, 
		/**索勒斯声望 */
		suolesiPrestige = 2000302, 
		/**金尼斯声望 */
		jinnisiPrestige = 2000303, 
		/**赫拉希诺声望 */
		helaxinuoPrestige = 2000304, 
		/**巴拉赞声望 */
		balazanPrestige = 2000305, 
		/**斯诺兰多声望 */
		sinuolanduoPrestige = 2000306, 
		/**皇室凭证 */
		royalCredentials = 2000319, 
	}

	/**装备镶嵌宝石的槽位颜色类型 */
	public enum EquipGemSlotColorType{
		/**红色 */
		Hong = 1, 
		/**橙色 */
		Cheng = 2, 
		/**绿色 */
		Lv = 3, 
		/**蓝色 */
		Lan = 4, 
		/**紫色 */
		Zi = 5, 
		/** 黄色 */
		Huang = 6, 
		/** 彩色*/
		Cai = 7, 
	}

	/**装备洗练品质对应数据列名称 */
	public enum EquipRefinementType{
		/** 白色品质 */
		whiteConsume = 1, 
		/** 绿色品质 */
		greenConsume = 2, 
		/** 蓝色品质 */
		blueConsume = 3, 
		/** 紫色品质 */
		violetConsume = 4, 
		/** 橙色品质 */
		orangeConsume = 5, 
		/** 红色品质 */
		redConsume = 6, 
	}

	//召唤方式
	public enum ECallType{
		//指定格子
		Slot = 0, 
		//自身周边
		SelfAround = 1, 
		//随机
		Random = 2, 
	}

	//条件关系
	public enum ERelation{
		//与
		And = 0, 
		//与
		Or = 1, 
	}

	//触发器结果属性集
	public class ETriggerResultAttrs{
		//召唤角色ID，召唤方式，格子索引，召唤的友方角色，召唤的敌方角色
		public const string AddRunSlotEventResultConfig = "SlotIndex,Team";
		//召唤角色ID，召唤方式，格子索引，召唤的友方角色，召唤的敌方角色
		public const string CallEventResultConfig = "CallRoleId,CallType,SlotIndex,ActorId,MonsterId";
		//相机终点位置,相机终点旋转角,相机终点尺寸,相机移动时长
		public const string CameraFocusEventResultConfig = "RoleID,Move2FocusTime,EndPosition,EndRotation,EndCameraSize";
		//相机位置,相机旋转角,相机尺寸
		public const string CameraMoveEventResultConfig = "EndPosition,EndRotation,EndCameraSize,MoveTime";
		//角色ID,AIID
		public const string CameraPlaceEventResultConfig = "CameraPosition,CameraRotation,CameraSize";
		//更改BGM的Id
		public const string ChangeAIEventResultConfig = "RoleId,AIId";
		//更改BGM的Id
		public const string ChangeBGMEventResultConfig = "BGMId";
		//角色ID,变更阵营类型
		public const string ChangeSlotElementEventResultConfig = "ElementId，SlotIndex";
		//变更胜利条件ID
		public const string ChangeTeamEventResultConfig = "RoleId,Team";
		//变更胜利条件ID
		public const string ChangeWinEventResultConfig = "WinId";
		//删除角色ID
		public const string DeleteRoleEventResultConfig = "RoleId";
		//角色死亡Id
		public const string RoleDeathEventResultConfig = "RoleId";
		//移动角色ID，终点格子索引,目标角色ID，角色和目标角色之间的间隔格子数,移动时间
		public const string RoleLeaveEventResultConfig = "RoleId,LevelSlotIndex";
		//来源角色Id,目标角色Id,攻击技能Id
		public const string RoleMoveEventResultConfig = "RoleId,SlotIndex,TargetId,RolesSlotInterval,MoveTime";
		//状态类型
		public const string SkillEventResultConfig = "FromId,ToId,SkillId";
		//状态类型
		public const string StatusResultConfig = "StatusType";
		//文字表ID，文字事件类型
		public const string TextEventResultConfig = "StringId,TextType";
	}

	//触发器条件属性集
	public class ETriggerConditionAttrs{
		//战斗状态
		public const string ConditionGroupConfig = "Relation,mConditionList";
		//战斗状态
		public const string FightScenetStatusConditionConfig = "FightStatus";
		//坚持多少回合
		public const string KeepRoundConditionConfig = "roundNumber";
		//角色ID，角色属性类型，角色限制值
		public const string RoleArriveEventConditionConfig = "RoleId,SlotIndex";
		//角色ID，角色属性类型，角色限制值
		public const string RoleInfoEventConditionConfig = "RoleId,Property,Limit";
		//角色唯一码
		public const string RoleNoDeathConditionConfig = "RoleGid";
		//角色唯一码
		public const string RoleNoRunConditionConfig = "roleGid";
		//撤离角色
		public const string RoleRunConditionConfig = "roleGid";
		//回合数，阵营，回合状态
		public const string RoundEventConditionConfig = "RoundNumber,Team,RoundStatus";
		//当前场景,下一场景
		public const string RunConditionConfig = "Team,SlotIndex";
		//状态类型,格子索引,ID号
		public const string SceneChangeEventConditionConfig = "CurScene,NextScene";
		//死亡部队
		public const string StatusConditionConfig = "StatusType,SlotIndex,StatusId";
		//死亡部队
		public const string TeamDeathConditionConfig = "deathTeam";
		//不死亡部队
		public const string TeamNoDeathConditionConfig = "team";
		//不撤离部队
		public const string TeamNoRunConditionConfig = "runTeam";
		//撤离部队
		public const string TeamRunConditionConfig = "runTeam";
		//职业击杀角色
		public const string JobKillRoleConditionConfig = "RoleId,JobId";
	}

	//战斗状态
	public enum EFightStatus{
		Start = 0, 
		End = 1, 
	}

	//邮件状态
	public enum MailState{
		/** 未读 */
		unread = 0, 
		/** 已读未领取 */
		unreceived = 1, 
		/** 可删除 */
		delete = 3, 
	}

	//护甲枚举类型
	public enum EArmorType{
		/**布甲*/
		cloth = 1, 
		/**皮甲*/
		Leather = 2, 
		/**锁甲*/
		chain = 3, 
		/**板甲*/
		plate = 4, 
	}

	//行为树节点状态
	public enum EBehaviorTreeNodeState{
		//失败
		failure = 0, 
		//初始状态
		invalid = 1, 
		//成功
		success = 2, 
		//运行
		running = 3, 
		//终止
		aborted = 4, 
	}

	//行为树强制改变更新结果可选类型
	public enum EBehaviorTreeResChangeType{
		//失败
		failure = 0, 
		//成功
		success = 1, 
		//取反
		negation = 2, 
	}

	//行为树节点类型
	public enum EBehaviorTreeNodeType{
		//重复执行子节点指定次数的装饰器
		RepeatNum = 1, 
		//重复执行子节点直到子节点的状态为指定状态的装饰器
		RepeatToState = 2, 
		//更改子节点执行结果的装饰器
		ChangeRes = 3, 
		//子节点顺序执行模式节点，顺序执行每个子节点，直到某个子节点执行后状态不为成功时，以子节点状态作为该结点的状态更新结果，顺序执行所有子节点后仍未出现失败状态，状态更新返回成功
		Sequence = 4, 
		//子节点顺序选择模式节点，顺序执行每个子节点，直到某个子节点执行后状态不为失败时，以子节点状态作为该结点的状态更新结果，顺序执行所有子节点后仍未出现成功状态，状态更新返回失败
		OrderSelector = 5, 
		//子节点策略执行模式节点，顺序执行每个子节点，记录每个子节点的状态更新结果，之后根据参数配置的成功策略，返回该结点的状态更新结果
		Parallel = 6, 
		//子节点优先选择模式节点，在该节点旧状态为running时，记录当前状态为running的子节点，依据OrderSelector模式重选节点，在重选节点与旧节点不同时，终止旧节点行为，该节点旧状态非running时，等价于OrderSelector节点
		ActiveSelector = 7, 
		//指定配置ID的行为树子树
		SubTree = 8, 
		//逻辑行为节点，根据需求的逻辑类型，执行指定AI逻辑，该类节点不应当存在子节点
		Action = 9, 
		//向攻击目标位置使用技能
		runAtkAction = 10, 
		//向移动目标位置移动
		runMoveAction = 11, 
		//替换攻击发起位置集合为在攻击目标位置应用自身当前技能选择范围得到的位置集合，与自身可移动范围位置集合的交集，并重置攻击发起位置检索序，交集为空集时返回失败
		changeCanAtkTileByAtkTargetTile = 12, 
		//将攻击发起位置集合按每个位置周边敌人数量，从小到大进行排序，并重置可攻击位置检索序
		sortCanAtkInMinEnemyNum = 13, 
		//根据攻击发起位置检索序从攻击发起位置集合中获取一个攻击发起位置设为移动目标位置，之后可攻击发起位置检索序增加，如果取值时检索序超过集合大小，返回终止
		getNextAtkTile = 14, 
		//获取计算生物阻挡时当前位置到移动目标位置的最短路径，并设为预计算路径
		getMovePathInCountEntity = 15, 
		//获取忽略生物阻挡时当前位置到移动目标位置的最短路径，并设为预计算路径
		getMovePathInNotCountEntity = 16, 
		//判断当前移动力是否满足预计算路径需求
		checkMovContrastPathCostIsGT = 17, 
		//敌人集合替换为行为树预设目标ID对应的敌人集合，并重置敌人检索序
		changeEntityListByTreeParamEntityIdList = 18, 
		//替换可攻击位置集合为当前位置应用当前技能选择范围得到的位置集合
		changeCanAtkTileBySkill = 19, 
		//敌人集合替换为全图敌人，并重置敌人检索序
		changeEntityListBySceneEntityList = 20, 
		//敌人集合中筛选保留符合[敌人血量 =< 自身主动攻击技能基础伤害 - 敌人防御]的敌人，并重置敌人检索序
		filterEntityListInCanKill = 21, 
		//将敌人集合按敌人血量，从小到大进行排序，并重置敌人检索序
		sortEntityListInMinEnemyHp = 22, 
		//将敌人集合按敌人血量，从大到小进行排序，并重置敌人检索序
		sortEntityListInMaxEnemyHp = 23, 
		//根据检索序从敌人集合中获取一个敌人位置设为攻击目标位置，之后检索序增加，如果取值时检索序超过集合大小，返回终止
		getNextAtkTargetTile = 24, 
		//判断敌人集合的排序结果的首位的排序依据值是否在集合中唯一
		checkEntityListIsOneOnlyTop = 25, 
		//将敌人集合按敌人与自身的曼哈顿距离，从小到大进行排序，并重置敌人检索序
		sortEntityListInMinEnemyDis = 26, 
		//将敌人集合按敌人与自身的曼哈顿距离，从大到小进行排序，并重置敌人检索序
		sortEntityListInMaxEnemyDis = 27, 
		//将敌人集合按敌人等级，从小到大进行排序，并重置敌人检索序
		sortEntityListInMinEnemyLv = 28, 
		//将敌人集合按敌人等级，从大到小进行排序，并重置敌人检索序
		sortEntityListInMaxEnemyLv = 29, 
		//检索当前攻击范围内是否包含攻击目标位置
		checkCanAtkTileListHasAtkTargetTile = 30, 
		//检索移动范围内可以对攻击目标位置进行攻击的攻击位置作为移动目标位置，并得到对应预设路径
		getMovePathAndMoveTargetTileByAtkTargetTile = 31, 
		//根据预设路径进行移动，直至碰到障碍或移动力消耗完毕为止
		runMoveActionInSearchPath = 32, 
		//将敌人集合按当前主动技能攻击类型对应的防御力，从小到大进行排序，并重置敌人检索序
		sortEntityListInMinEnemyDef = 33, 
		//设置攻击位置为移动目标位置
		setMoveTargetTileByAtkTargetTile = 34, 
		//检索预设路径上距离最近的敌人位置作为攻击位置
		getAtkTargetTileOnSearchPath = 35, 
		//敌人集合替换为当前移动范围+攻击范围内的所有敌人，并重置敌人检索序
		changeEntityListByMovAndAtkRange = 36, 
		//根据自身可移动范围选取该范围中的所有敌人，使用敌人的位置加自身位置的集合构造一个凸包，判断自身位置是否不属于凸包的顶点集合
		checkBeSurrounded = 37, 
		//判断当前回合数
		checkBattleRoundNum = 38, 
		//将撤离目标位置设置为移动目标位置
		setMoveTargetTileByEscapeTargetTile = 39, 
		//判断自身当前生命值是否低于生命值上限的百分比
		checkCurHpByHpPer = 40, 
		//判断自身职业类型是否属于[jobList: string 职业集合，逗号分隔]
		checkCurJob = 41, 
		//替换攻击发起位置集合为在攻击目标位置应用自身当前技能选择范围计算箭楼加成得到的位置集合，与自身可移动范围位置集合的交集，并重置攻击发起位置检索序，交集为空集时返回失败
		changeCanAtkTileByAtkTargetTileAddArrowTowerBuff = 42, 
		//判断攻击目标位置是否在可攻击位置列表中
		checkAtkTargetTileBeCanAtkTile = 43, 
		//将攻击发起位置集合按每个位置与自身的距离，从小到大排序，并重置可攻击位置检索序
		sortCanAtkTileInMinDis = 44, 
		//将攻击发起位置集合按每个位置与自身的距离，从大到小排序，并重置可攻击位置检索序
		sortCanAtkTileInMaxDis = 45, 
		//攻击发起位置集合中筛选保留符合位置类型属于[tileTypeList: string 位置类型集合，逗号分隔]的位置，并重置检索序
		changeCanAtkTileByTileType = 46, 
		//判断移动目标点位到防御点的距离是否小等于[dis: int 距离数]
		checkMoveTargetTileBeNearbyGuardTarget = 47, 
		//判断自身当前点位到防御点的距离是否小等于[dis: int 距离数]
		checkCurTileBeNearbyGuardTarget = 48, 
		//敌人集合替换为我方全体，并重置敌人检索序
		changeEntityListByScenePlayerActorList = 49, 
		//敌人集合替换为当前移动范围+攻击范围内的所有我方/友方，并重置敌人检索序
		changeEntityListBeFriendAndInMovAndAtkRange = 50, 
		//敌人集合替换为当前移动范围+攻击范围内的所有非我方/非友方，并重置敌人检索序
		changeEntityListBeNoFriendAndInMovAndAtkRange = 51, 
		//判断我方角色是否全部都满血
		checkAllPlayerActorIsMaxHp = 52, 
		//判断当前主动攻击技能AP消耗是否大等于[consumeNum: int 消耗数量]
		checkCurAtkSkillIsConsumeAp = 53, 
		//判断当前主动攻击技能的首要效果目标类型是否属于[effectTargetTypeList: string 效果目标类型集合，逗号分隔]
		checkCurAtkSkillEffectTargetType = 54, 
		//将敌人集合按敌人到防御点的距离，从小到大进行排序，并重置敌人检索序
		sortEntityListInGuardTargetDis = 55, 
		//检索距离防御点最近的可用位置作为移动目标位置
		changeMoveTargetTileByNearbyGuardTarget = 56, 
		//将自身位置设为攻击目标位置
		changeAtkTargetTileBySelfTile = 57, 
		//将敌人集合按敌人的物理攻击力或魔法攻击力中的较高值，从小到大进行排序，并重置敌人检索序
		sortEntityListInMinPAtkOrMAtk = 58, 
		//将敌人集合按敌人的物理攻击力或魔法攻击力中的较高值，从大到小进行排序，并重置敌人检索序
		sortEntityListInMaxPAtkOrMAtk = 59, 
		//判断我方角色是否有血量低于[perNum: int 万分比]的角色
		checkAllPlayerActorCurHpPer = 60, 
		//判断攻击目标位置是否在当前敌人集合中
		checkAtkTargetTileBeEntityList = 61, 
		//检索预设路径上可移动到的最远位置设置为移动目标位置
		setMoveTargetTileByFarthestSearchPath = 62, 
		//敌人集合替换为当前移动目标位置上计算当前技能选择范围内的敌人，并重置检索序
		changeEntityListByMoveTargetTileUseSkill = 63, 
		//判断是否配置行为树预设守卫目标
		checkTreeGuardTarget = 64, 
		//将撤离点集合替换为全图撤离点，并重置撤离点检索序
		changeEscapeListByScene = 65, 
		//将撤离点集合根据距离进行从小到大排序，并重置撤离点检索序
		sortEscapeListByMinDis = 66, 
		//根据检索序从撤离点集合中获取一个位置设为撤离目标位置，之后检索序增加，如果取值时检索序超过集合大小，返回终止
		getNextEscapeTargetTile = 67, 
		//敌人集合中筛选保留具备VIP的敌人，并重置敌人检索序
		filterEntityListInHasVip = 68, 
		//将敌人集合按敌人已损失HP，从大到小进行排序
		sortEntityListInMaxLossHp = 69, 
		//敌人集合中筛选已经损失过HP的敌人，并重置敌人检索序
		filterEntityListInLossHp = 70, 
		//将敌人集合按敌人六维总值，从大到小进行排序
		sortEntityListInMaxBaseMainAttr = 71, 
	}

	/**邮件附件类型 */
	public enum MailAppendType{
		/**奖励组 */
		RewardGroup = 1, 
		/**背包物品 */
		BagItem = 2, 
		/**装备 */
		Eqiutments = 3, 
		/**英雄 */
		Heroes = 4, 
	}

	/**地形通行规则类型*/
	public enum EPassType{
		/**全职业通行*/
		AllPass = 1, 
		/**不可通行*/
		NoPass = 2, 
		/**部分职业通行*/
		PartPass = 3, 
	}

	/** 角色基础六维id */
	public enum AcotrBaseSixAttrs{
		/**力量*/
		str = 1, 
		/**体质*/
		vit = 6, 
		/**技巧*/
		dex = 11, 
		/**感知*/
		per = 16, 
		/**敏捷*/
		agi = 21, 
		/**意志*/
		wil = 26, 
	}

	public enum 
ECastleArchitectureType{
		//祈神厅
		QiSheng = 1, 
		//宴庆厅
		YanHui = 2, 
		//主战厅
		ZhuZhan = 3, 
		//营商厅
		YingShang = 4, 
		//育婴厅
		YuYing = 5, 
	}

	/**任务类型*/
	public enum ETaskType{
		/**主线*/
		main = 1, 
		/**支线*/
		branch = 2, 
		/**场景事件*/
		battleSceneEvent = 3, 
		/**每日 */
		daily = 4, 
		/**角色特性依据条件学习*/
		autoAddActorSpeciality = 5, 
	}

	/**账号任务类型 */
	public enum ETaskFunctionType{
		/**主线 */
		Main = 1, 
		/**随机 */
		SuiJi = 2, 
		/**目标 */
		MuBiao = 3, 
		/**跑商 */
		PaoShang = 4, 
		/**成就 */
		ChengJiu = 5, 
		/**支线 */
		ZhiXian = 6, 
	}

	/**任务完成状态 */
	public enum ETaskComplateStatus{
		/**未知 */
		WeiZhi = 0, 
		/**已接任务(执行中) */
		Received = 1, 
		/**已完成任务(需要领取奖励的) */
		Complete = 2, 
		/**已提交任务(针对手动提交的任务) */
		Submit = 3, 
		/**任务超时(需删除)*/
		OverTime = 4, 
	}

	/**装备挂点类型 */
	public enum EHangPointType{
		/**不考虑挂点 */
		BuKaoLv = 0, 
		/**左手挂点 */
		ZuoShou = 1, 
		/**右手挂点 */
		YouShou = 2, 
		/**与人物平行挂点 */
		PingXing = 3, 
	}

	/**说话方类型 */
	public enum ESeatType{
		/**左边 */
		ZuoBian = 1, 
		/**右边 */
		YouBian = 2, 
		/**旁白 */
		PangBai = 3, 
	}

	/**显示方类型 */
	public enum EDispalyType{
		/**左 */
		Zuo = 1, 
		/**右 */
		You = 2, 
		/**旁白 */
		PangBai = 3, 
		/**两个 */
		LiangGe = 4, 
	}

	/** 全局触发器类型(除关卡战斗) */
	public enum EGlobalTriggerType{
		/**战场类型触发器 */
		ZhangChang = 1, 
		/**进入指定界面触发器*/
		InAppointInterface = 2, 
		/**事件类触发器 */
		Event = 3, 
		/**时间节点类触发器 */
		TimeNode = 4, 
		/**爵位解锁后触发器 */
		JueWeiAfterUnlocking = 5, 
		/**爵位授予后触发器 */
		JueWeiAfterAward = 6, 
		/**战斗时点类触发器 */
		BattlePoint = 7, 
		/**进入城市类触发器 */
		InCity = 8, 
		/**解锁某地类触发器 */
		OpenCity = 9, 
		/**对话结束后触发器 */
		DuiHuaEnd = 10, 
		/**接取某任务 */
		AcceptTask = 11, 
		/**解锁某个角色 */
		ActiveActor = 12, 
		/**进入组队副本 */
		JoinTeamLevel = 13, 
		/**点击当前的主线任务 */
		OnclickMainTask = 14, 
		/**图鉴事件类 */
		LibraryEvent = 15, 
		/**进入游戏后自动触发 */
		EnterGameAutoActive = 20, 
		/**触发新章节开启 */
		NewChapterOpen = 21, 
	}

	/**[触发器]任务操作类型 */
	public enum ETaskOpretionType{
		/**未知 */
		None = 0, 
		/**接任务触发类型 */
		Accepte = 1, 
		/**完成任务触发类型 */
		Finish = 2, 
	}

	/**角色待命位置*/
	public enum EAwaitPosition{
		//无
		none = 0, 
		//战斗队伍
		BATTLE_TEAM = 1, 
		//城堡历练教师
		CASTLE_PRACTICE_INSTRUCTOR = 2, 
		//城堡历练学员
		CASTLE_PRACTICE_STUDENT = 3, 
		//城堡建筑守卫
		CASTLE_ARCHITECTURE_GUARD = 4, 
		//城堡学员
		CASTLE_SCHOOL_STUDENT = 5, 
		//城堡教师
		CASTLE_SCHOOL_INSTRUCTOR = 6, 
		//城堡委托派遣
		CASTLE_ENTRUST_WEITUO = 7, 
	}

	/**建筑状态类型 */
	public enum EConstructionStatus{
		//未解锁
		None = 0, 
		//待解锁
		DaiJieSuo = 1, 
		//育英厅
		YuYingTing = 2, 
		//待建造
		DaiJianZao = 3, 
		//其他建筑
		QiTaJianZhu = 4, 
	}

	/** 酒馆招募类型*/
	public enum tavernRecruitType{
		/**银币 */
		Silver = 1, 
		/**钻石 */
		Diamond = 2, 
	}

	/**城堡槽位类型 */
	public enum ECastleModuleSlotType{
		/**普通*/
		common = 1, 
		/**钻石*/
		diamond = 2, 
	}

	/**城堡历练类型 */
	public enum ECastlePracticeType{
		/**短期历练*/
		isShort = 1, 
		/**长期历练*/
		isLong = 2, 
	}

	/**城堡历练事件类型 */
	public enum ECastlePracticeEventType{
		/**需选择结果*/
		option = 1, 
		/**已确认结果*/
		confirm = 2, 
	}

	/**角色类型 */
	public enum EActorType{
		/**玩家角色*/
		playerActor = 0, 
		/**怪物角色*/
		monsterActor = 1, 
		/**玩家角色配偶*/
		playerActorSpouse = 2, 
	}

	/**角色婚姻状态 */
	public enum EActorMarryState{
		unmarried = 0, 
		married = 1, 
		waitReply = 2, 
	}

	/**路点类型*/
	public enum EMapPointType{
		/**任务路点*/
		task = 1, 
		/**寻宝路点*/
		treasure = 2, 
		/**组队副本路点*/
		fortress = 3, 
		/**王城路点*/
		capital = 4, 
		/**重镇路点*/
		city = 5, 
		/**村落路点*/
		village = 6, 
	}

	/**节日类型 */
	public enum EFestivalType{
		/**加buff */
		AddBuff = 1, 
		/**相亲 */
		XiangQin = 2, 
		/**战斗 */
		Battle = 3, 
		/**物品兑换 */
		ItemExchange = 4, 
	}

	/**账号改变城市点功能类型 */
	public enum EChangeMapPointFuncType{
		/**未知0 */
		WeiZhi = 0, 
		/**进入 */
		Join = 1, 
	}

	/**节日id */
	public enum EFestivalId{
		/**角斗日 */
		Wrestle = 3, 
		/**通商节 */
		TongShang = 5, 
		/**丰饶节 */
		FengRao = 10, 
	}

	/**节日物资兑换类型 */
	public enum EFestivalExchangeType{
		/**通商节 */
		TongShang = 1, 
		/**丰饶节 */
		FengRao = 2, 
	}

	/**城堡历练状态 */
	public enum EExperienceState{
		//未解锁
		NotUnlocked = 0, 
		//已解锁
		Unlocked = 1, 
		//历练中
		Experiencing = 2, 
		//历练完成
		ExperienceCompleted = 3, 
	}

	/**任务触发器类型 */
	public enum ETaskTriggerType{
		/**进入战场 */
		BattleLevel = 1, 
		/**进入指定界面 */
		JoinTargetInterface = 2, 
		/**解锁节日 */
		OpenJieRi = 3, 
		/**时间节点类 */
		TimeNode = 4, 
		/**爵位解锁后 */
		OpenTitle = 5, 
		/**爵位授予后 */
		TitleLevel = 6, 
		/**找某个角色 */
		FindAvatar = 7, 
		/**进入城市类 */
		JoinMapPoint = 8, 
		/**解锁某地 */
		OpenMapPoint = 9, 
		/**对话结束后 */
		DialogueEnd = 10, 
	}

	/**城堡特性池类型*/
	public enum CastleSpecialityPoolType{
		common = 1, 
		emphasis = 2, 
		teacher = 3, 
	}

	/**节日选项id */
	public enum FestivalOptionId{
		/**不会受伤 */
		NotHurt = 1, 
		/**不会夭折 */
		NotDieYoung = 2, 
		/**延长寿命 */
		Addlife = 3, 
		/**经验加成 */
		AddExp = 4, 
		/**祝福法师 */
		BlessingMage = 5, 
		/**生女儿 */
		BabyBaughter = 6, 
		/**赋予特性 */
		GiveSpeciality = 7, 
		/**祝福轻步兵 */
		BlessingLightInfantry = 8, 
		/**祝福重步兵 */
		BlessingHeavyInfantry = 9, 
		/**增加品质提升概率 */
		AddPromoteProbability = 10, 
		/**增加强化成功概率 */
		AddStrengthenProbability = 11, 
		/**祝福骑兵 */
		BlessingCavalry = 12, 
		/**祝福弓兵 */
		BlessingArcher = 13, 
	}

	/**城堡联姻相亲对象描述词条类型*/
	public enum ECastleAllianceIntroType{
		/**姓名类*/
		name = 1, 
		/**长相类*/
		partInfo = 2, 
		/**父母血脉类*/
		parentBlood = 3, 
		/**特性类*/
		speciality = 4, 
		/**爱好类*/
		hobby = 5, 
		/**年龄类*/
		age = 6, 
		/**爵位类*/
		nobility = 7, 
		/**无用类*/
		pointless = 8, 
		/**自身血脉*/
		blood = 9, 
		/**结束对话*/
		endDialog = 10, 
	}

	/**解锁任务条件类型 */
	public enum EOpenTaskConditionType{
		/**忽略该参数 */
		None = 0, 
		/**友好度类型，国家id和友好度等级(格式：解锁类型_国家ID_友好度等级) */
		Friendly = 1, 
		/**物品触发类型(获得物品数量),配置物品id和数量(例：解锁类型_物品id_物品数量) */
		GetItem = 2, 
		/**访问城市触发（解锁类型_城市id_0） */
		InPoint = 3, 
		/**完成指定类型任务（解锁类型_任务id_0） */
		CompleteTask = 4, 
		/**5为功能解锁,配置指定功能的开启状态（例：解锁类型_城市点ID_功能ID，功能ID对应Function表的mID字段）,某个城市点的某个功能 */
		FunctionOpen = 5, 
		/**6完成对话自动解锁：（解锁类型_对话id_0） */
		DuiHua = 6, 
		/**7为获得装备触发类型：（解锁类型_装备id_装备数量） */
		GetEquipment = 7, 
	}

	public enum EBanquetQuestionResultType{
		good = 1, 
		common = 2, 
		bad = 3, 
	}

	/** 表白回复类型 */
	public enum EReplyType{
		/** 成功 */
		success = 1, 
		/** 失败 */
		fail = 2, 
	}

	/**[目标任务奖励]条件大类型 */
	public enum ETargetType{
		/**战斗 */
		ZhanDou = 1, 
		/**内政 */
		NeiZheng = 2, 
		/**外交 */
		WaiJiao = 3, 
		/**装备 */
		ZhuangBei = 4, 
		/**事件 */
		ShiJian = 5, 
		/**节日 */
		JieRi = 6, 
	}

	/**[目标任务奖励]二级条件类型 */
	public enum ETargetRewardType{
		/**[友好度]索勒斯友好度达到某等级 */
		YouHaoDu = 1, 
		/**[爵位] */
		JueWei = 2, 
		/**血脉*/
		XueMai = 3, 
		/**结果*/
		JieGuo = 4, 
		/**级别*/
		JiBie = 5, 
		/**转职*/
		ZhuanZhi = 6, 
		/**杀敌*/
		ShaDi = 7, 
		/**节日*/
		JieRi = 8, 
		/**道具*/
		DaoJu = 9, 
		/**结婚*/
		JieHun = 10, 
		/**儿童*/
		ErTong = 11, 
		/**城堡*/
		ChengBao = 12, 
		/**宴会*/
		YanHui = 13, 
		/**主线*/
		ZhuXian = 14, 
		/**隐藏*/
		YinCang = 15, 
		/**强化*/
		QiangHua = 16, 
		/**镶嵌*/
		XiangQian = 17, 
		/**洗炼*/
		XiLian = 18, 
		/**突破*/
		TuPo = 19, 
		/**升品*/
		ShengPin = 20, 
		/**附魔*/
		FuMo = 21, 
		/**提取技能*/
		TiQuJiNeng = 22, 
		/**成功率*/
		ChengGongLv = 23, 
		/**学习*/
		XueXi = 24, 
		/**历练*/
		LiLian = 25, 
		/**委托*/
		WeiTuo = 26, 
		/**角色*/
		JueSe = 27, 
		/**军团圣物*/
		JunTuanShengWu = 28, 
		/**伤病*/
		ShangBing = 29, 
		/**传染*/
		ChuanRan = 30, 
		/**爬塔*/
		PaTa = 31, 
		/**副本*/
		FuBen = 32, 
		/**治疗*/
		ZhiLiao = 33, 
		/**商会*/
		ShangHui = 34, 
		/**充值*/
		ChongZhi = 35, 
		/**酒馆招募*/
		ZhaoMu = 36, 
		/**NPC对话*/
		DuiHua = 37, 
		/**特性*/
		TeXing = 38, 
		/**求婚被拒绝*/
		JuJueQiuHun = 39, 
		/**登录天数*/
		DengLu = 40, 
		/**每日任务*/
		MeiRiRenWu = 41, 
		/**组队副本*/
		ZuDui = 42, 
		/**竞技场*/
		JingJiChang = 43, 
		/**关卡人数*/
		GuanKaRenShu = 44, 
		/**关卡移动*/
		GuanKaYiDong = 45, 
		/**关卡回合*/
		GuanKaHuiHe = 46, 
		/**关卡攻击*/
		GuanKaGongJi = 47, 
		/**关卡满血*/
		GuanKaManXue = 48, 
		/**职业*/
		ZhiYe = 49, 
		/**混血*/
		HunXue = 50, 
		/**活动*/
		HuoDong = 51, 
		/**经验*/
		JingYan = 52, 
		/**战力*/
		ZhanLi = 53, 
		/**组合成就*/
		ZuHe = 54, 
	}

	/**达成目标状态类型 */
	public enum ETargetStatusType{
		/**0未完成 */
		notComplete = 0, 
		/**1已完成待领取 */
		finished = 1, 
		/**2已领取 */
		received = 2, 
	}

	public enum EFeastUseGoodsType{
		nonuse = 0, 
		goods = 1, 
		diamond = 2, 
	}

	public enum ESpecialityType{
		/**永久通用特性*/
		common = 1, 
		/**永久圣痕特性*/
		stigma = 2, 
		/**节日特性*/
		festival = 3, 
		/**职位特性*/
		jobTitle = 4, 
		/**城堡学习特性*/
		castleStudy = 5, 
		/**星座特性*/
		constellation = 6, 
		/**种族特性*/
		descent = 7, 
		/**婚礼特性*/
		wedding = 8, 
		/**国家特性*/
		country = 9, 
		/**爵位特性*/
		nobility = 10, 
		/**混血特性*/
		mixedBlood = 11, 
	}

	/**军团旗帜配置类型枚举 */
	public enum ECorpsFlagCfgType{
		/**旗帜底色 */
		shapeColor = 1, 
		/**旗帜形状 */
		shape = 2, 
		/**图案 */
		pattern = 3, 
		/**图案颜色 */
		patternColor = 4, 
	}

	/**角色排序类型 */
	public enum EActorSortType{
		/**年龄 */
		NianLing = 1, 
		/**爵位 */
		JueWei = 2, 
		/**等级 */
		DengJi = 3, 
		/**力量成长 */
		LiLiangChengZhang = 4, 
		/**体质成长 */
		TiZhiChengZhang = 5, 
		/**技巧成长 */
		JiQiaoChengZhang = 6, 
		/**感知成长 */
		GanZhiChengZhang = 7, 
		/**敏捷成长 */
		MinJieChengZhang = 8, 
		/**意志成长 */
		YiZhiChengZhang = 9, 
		/**力量值 */
		LiLiangZhi = 10, 
		/**体质值 */
		TiZhiZhi = 11, 
		/**技巧值 */
		JiQiaoZhi = 12, 
		/**感知值 */
		GanZhiZhi = 13, 
		/**敏捷值 */
		MinJieZhi = 14, 
		/**意志值 */
		YiZhiZhi = 15, 
		/**血脉比例 */
		XueMaiBiLi = 16, 
	}

	/**角色排序顺序 */
	public enum EActorSortOrder{
		/**升序 */
		Up = 1, 
		/**降序 */
		Down = 2, 
	}

	/**成就目标显示结果类型 */
	public enum EAttainmentDisplayType{
		/**单条结果显示 */
		OneResult = 1, 
		/**进度条结果显示(包含组合类型) */
		MoreResult = 2, 
	}

	/**账号场景状态 */
	public enum EPlayerSceneState{
		/**通常状态*/
		none = 0, 
		/**战斗场景*/
		battle = 1, 
		/**城市*/
		city = 2, 
		/**爬塔*/
		climbTower = 3, 
	}

	public enum ECastleAllianceType{
		/**城堡联姻*/
		alliance = 0, 
		/**城堡宴会*/
		feast = 1, 
	}

	/**学校角色类型 */
	public enum ESchoolRoleType{
		/**教师 */
		Teacher = 1, 
		/**重点培养 */
		KeyTraining = 2, 
	}

	/**学校槽位状态 */
	public enum ESchoolSlotState{
		/**未解锁 */
		NotUnlocked = 1, 
		/**已解锁 */
		Unlock = 2, 
		/**已派遣 */
		Dispatch = 3, 
	}

	/**属性增加类型 */
	public enum ESattrAddType{
		/**常量怎加 */
		constantAdd = 1, 
		/**百分比增加 */
		percentAdd = 2, 
	}

	/**军团士气行为类型 */
	public enum EMoraleActionType{
		/**角色离队 */
		actorLeave = 1, 
		/**战斗胜利 */
		battleWin = 2, 
		/**角色需求 */
		actorNeed = 3, 
		/**跑商任务 */
		runTask = 4, 
		/**随机任务 */
		randomTask = 5, 
		/**未战斗 */
		notBattle = 6, 
		/**发放工资 */
		payroll = 7, 
	}

	/**军团士气角色离队行为 */
	public enum EMoraleActionActorLeave{
		/**退休 */
		retire = 1, 
		/**主动离开 */
		leave = 2, 
		/**解雇 */
		fired = 3, 
	}

	/**军团士气战斗胜利行为 */
	public enum EMoraleActionBattleWin{
		/**角斗节 */
		wrestle = 1, 
		/**随机任务 */
		randomTask = 2, 
	}

	/**军团士气角色需求行为 */
	public enum EMoraleActionActorNeed{
		/**接受 */
		accept = 1, 
		/**拒绝 */
		refuse = 2, 
		/**完成 */
		complete = 3, 
		/**未完成 */
		unfinished = 4, 
	}

	/**军团士气任务行为(跑商和随机任务) */
	public enum EMoraleActionTask{
		/**完成 */
		complete = 1, 
		/**未完成 */
		unfinished = 0, 
	}

	/**军团士气工资发放行为 */
	public enum EMoraleActionPayroll{
		/**未完全发放 */
		notAll = 1, 
	}

	/**军团技能状态 */
	public enum ECorpsSkillStatus{
		/**未解锁 */
		notUnlocked = 1, 
		/**未激活 */
		nonactivated = 2, 
		/**激活 */
		activated = 3, 
	}

	/**伤病类型*/
	public enum EInjuryType{
		battle = 1, 
		worsenBattle = 2, 
		mind = 3, 
		disease = 4, 
	}

	/**[任务]完成任务的条件类型 */
	public enum ECompleteTaskByDoneConditionType{
		/**与指定npc对话 */
		npcDialog = 1, 
		/**获得指定物品 */
		getItem = 2, 
	}

	/**角色状态 */
	public enum EActorStatus{
		/**未入队*/
		notJoin = 0, 
		/**已入队*/
		hasJoin = 1, 
		/**退休*/
		retired = 2, 
		/**解雇*/
		fired = 3, 
		/**离队*/
		leave = 4, 
		/**死亡*/
		die = 5, 
		/**未成年*/
		minor = 6, 
		/**征兵 */
		conscription = 7, 
		/**怀孕*/
		pregnancy = 8, 
		/**夭折 */
		dieYoung = 9, 
	}

	/**角色需求状态 */
	public enum EActorDemandStatus{
		/**等待处理*/
		waitingProcess = 0, 
		/**拒绝需求*/
		refused = 1, 
		/**接受等待完成 */
		waitingFinished = 2, 
		/**已完成*/
		finished = 3, 
		/**已过期未完成 */
		overdueUnfinished = 4, 
	}

	/**角色需求类型 */
	public enum EActorDemandType{
		/**奖金需求*/
		bonus = 1, 
		/**爵位需求*/
		nobility = 2, 
		/**相亲需求*/
		blindDate = 3, 
		/**物资需求 */
		goods = 4, 
	}

	/**对话表中显示内容的类型 */
	public enum EDialogOptionType{
		/**1纯对话 */
		Dialog = 1, 
		/**2奖励组 */
		RewardGroup = 2, 
	}

	/**角色需求触发条件 */
	public enum EActorDemandCondition{
		/**加入军团 */
		joinCorp = 1, 
		/**拥有爵位 */
		haveNobility = 2, 
		/**没有爵位 */
		noNobility = 3, 
		/**未婚 */
		unmarried = 4, 
	}

	/**技能类型-编辑器专用 */
	public enum ESkillUseType{
		/**伤害 */
		Damage = 0, 
		/**治疗 */
		Heal = 1, 
	}

	/**技能受击类型-编辑器专用 */
	public enum ESkillBeHitType{
		/**无状态 */
		None = 0, 
		/**正常 */
		Normal = 1, 
		/**偏斜 */
		IsDev = 2, 
		/**暴击 */
		IsCrit = 3, 
		/**格挡 */
		IsBlock = 4, 
		/**招架 */
		IsHold = 5, 
		/**死亡 */
		Death = 6, 
	}

	/**城堡委托任务状态 */
	public enum EEntrustStatusType{
		/**未接取 */
		WeiJieQu = 0, 
		/**已接未完成 */
		YiJieWeiWanCheng = 1, 
		/**完成待领奖 */
		WanChengDaiLingJiang = 2, 
	}

	/**城堡任务追加要求配置类型 */
	public enum EEntrustConditionType{
		/**无条件 */
		None = 1, 
		/**队伍中男性角色数量大于N */
		MaleNum = 2, 
		/**队伍中女性角色数量大于N */
		FemaleNum = 3, 
		/**队伍中爵位等级等于X的角色须有至少N个 */
		JueWeiLevelNum = 4, 
		/**队伍中血脉有X血脉的角色须有至少N个 */
		XueMaiTypeNum = 5, 
	}

	/**邮件类型 */
	public enum EMailType{
		/**为通知邮件 */
		Message = 1, 
		/**为玩家邮件 */
		Player = 2, 
		/**为公会邮件 */
		Worker = 3, 
		/**为补偿邮件 */
		Compensate = 4, 
		/**为征兵回信 */
		Conscription = 5, 
		/**排行榜奖励 */
		RankListReward = 6, 
	}

	/**钻石商店商品类型*/
	public enum EDiamondShopGoodsType{
		/**常驻*/
		common = 1, 
		/**周期*/
		cycle = 2, 
	}

	public enum EBloodActorSearchType{
		/**actor表中使用actorId进行检索*/
		actorId = 0, 
		/**玩家角色列表中使用actorGid进行检索*/
		actorGid = 1, 
	}

	/**排行榜一级类型 */
	public enum ERankFirstType{
		/**军团声望 */
		corpsPrestige = 1, 
		/**军团财富 */
		corpsSilver = 2, 
		/**胜利次数 */
		winCount = 3, 
		/**角色战力 */
		actorPower = 4, 
		/**皇室征兵 */
		Conscription = 5, 
		/**军团传承榜 */
		corpsTimes = 6, 
		/**活动排行 */
		activityRank = 7, 
		/**竞技场*/
		arena = 8, 
	}

	/**排行榜二级类型 */
	public enum ERankSecondType{
		/**军团总声望 */
		allPrestige = 1, 
		/**荷尔沃声望 */
		heerwoPrestige = 2, 
		/**索勒斯声望 */
		suolesiPrestige = 3, 
		/**金尼斯声望 */
		jinnisiPrestige = 4, 
		/**赫拉希诺声望 */
		helaxinuoPrestige = 5, 
		/**巴拉赞声望 */
		balazanPrestige = 6, 
		/**斯诺兰多声望 */
		sinuolanduoPrestige = 7, 
		/**军团财富 */
		corpsSilver = 8, 
		/**胜利场次 */
		winCount = 9, 
		/**角色战力 */
		actorPower = 10, 
		/**皇室凭证 */
		royalCredentials = 11, 
		/**征兵人数 */
		conscriptionNum = 12, 
		/**军团传承榜 */
		corpsTimes = 13, 
		/**新年充值榜 */
		newYearTopUp = 14, 
		/**奢华婚礼榜 */
		luxuryWedding = 21, 
		/**指定关卡造成伤害榜 */
		levelDmg = 22, 
		/**指定关卡胜利次数榜 */
		levelWins = 23, 
		/**军团战力榜 */
		corpsPower = 29, 
		/**竞技场排行榜*/
		arena = 30, 
	}

	/**榜单计时类型 */
	public enum ERankTimeType{
		/**天 */
		day = 1, 
		/**周 */
		weeks = 2, 
		/**月 */
		month = 3, 
		/**赛季 */
		season = 4, 
		/**自定义 */
		custom = 5, 
		/**永远存在 */
		forever = 6, 
	}

	/**主线、支线任务剧情类型 */
	public enum EMainTaskStoryType{
		/**未知 */
		None = 0, 
		/**播放动画 */
		PlayAnimation = 1, 
		/**弹出对话 */
		Dialog = 2, 
		/**进入战斗 */
		EnterBattle = 3, 
		/**点击按钮 */
		ButtonClick = 4, 
		/**关闭上一个动画 */
		ClosePreviousAnimation = 5, 
		/**点击角色 */
		ClickActor = 6, 
		/**播放摄像机动画 */
		PlayeCameraAnimtion = 7, 
		/**进入场景 */
		EnterScene = 8, 
		/**进入路点 */
		EnterRoadPoint = 9, 
	}

	/**排行榜三级榜单id */
	public enum ERankThirdId{
		/**角色战力赛季榜 */
		actorPowerSeason = 19, 
		/**角色战力历史榜 */
		actorPowerForever = 20, 
		/**弓兵战力榜 */
		archerPower = 35, 
		/**轻步兵战力榜 */
		lightInfantryPower = 36, 
		/**重步兵战力榜 */
		heavyInfantryPower = 37, 
		/**特殊系战力榜 */
		specialPower = 38, 
		/**骑兵战力榜 */
		cavalryPower = 39, 
		/**军团战力赛季榜 */
		corpsPowerSeason = 40, 
		/**军团战力历史榜 */
		corpsPowerForever = 41, 
		/**竞技场赛季榜 */
		arenaSeason = 42, 
	}

	/**榜单显示类型 */
	public enum ERankDisplayType{
		/**玩家积分榜单 */
		playerScore = 1, 
		/**角色战力榜单 */
		actorPower = 2, 
	}

	/**
     * 战斗场景类型(关卡种类)
     */
	public enum EBattleSceneType{
		/**常规关卡*/
		common = 0, 
		/**测试关卡*/
		test = 1, 
		/**主线关卡*/
		master = 2, 
		/**竞技场*/
		arena = 3, 
		/**爬塔关卡*/
		climbTower = 4, 
		/**世界boss关卡*/
		worldBoss = 5, 
		/**为决斗节关卡*/
		duelDay = 6, 
		/**组队副本 */
		teamBattle = 7, 
	}

	/**连续签到状态 */
	public enum EContinuousSignState{
		/**不可领取 */
		notReceive = 1, 
		/**可以领取 */
		canReceive = 2, 
		/**已经领取 */
		haveReceive = 3, 
	}

	/**账号当前处于主线剧情状态 */
	public enum EPlayerCurrMainTaskStoryType{
		/**非主线剧情状态 */
		IsFalse = 0, 
		/**是主线剧情状态 */
		IsTrue = 1, 
	}

	/**城堡功能解锁类型 */
	public enum ECastleUnlockFunctionType{
		/**学校教师功能类型 */
		SchoolTeacherSlot = 1, 
		/**学校重点培养位置 */
		SchoolKeyTraining = 2, 
		/**训练的历练功能 */
		TraniningExperience = 3, 
		/**封底功能 */
		Fief = 4, 
	}

	/**
     * 面部部件
     */
	public enum EPartType{
		//头发
		hair = 0, 
		//头发
		ear = 1, 
		//耳朵
		eyebrow = 2, 
		//眉毛
		eye = 3, 
		//眼
		nose = 4, 
		//鼻子
		beard = 5, 
		//胡子
		mouth = 6, 
		//嘴
		tattoo = 7, 
		//纹身
		face = 8, 
		//脸
		face2 = 9, 
		//大脸
		clothes = 10, 
		//衣服
		body = 11, 
		//身体
		scar = 12, 
		//伤疤
		stigma = 13, 
		//圣痕
		bigbeard = 14, 
		//大胡子
		wrinkle = 15, 
	}

	/**任务JSON数据表类型 */
	public enum ETaskJsonType{
		/**主线、支线 */
		TaskMainJson = 1, 
		/**随机、跑商*/
		TaskJson = 2, 
	}

	/**塔开放状态 */
	public enum ETowerOpenStatus{
		/**关闭 */
		Down = 0, 
		/**开启 */
		Open = 1, 
	}

	/**塔开商店刷新类型 */
	public enum ETowerShopRefeshType{
		/**固定 */
		fixation = 1, 
		/**随机 */
		random = 2, 
	}

	/**塔答题状态 */
	public enum ETowerAnswerStatus{
		/**关闭 */
		Down = 0, 
		/**开启 */
		Open = 1, 
	}

	/**每日任务奖励领取状态 */
	public enum ETaskDailyReceiveStatus{
		/**不可领取 */
		notReceive = 0, 
		/**可领取 */
		receive = 1, 
		/**已领取 */
		received = 2, 
	}

	/**每日任务行为 */
	public enum ETaskDailyAction{
		/**登录 */
		login = 1, 
		/**竞技场 */
		arenaBattle = 2, 
		/**参加节日 */
		joinFestival = 3, 
		/**爬塔挑战 */
		climbTowerBattle = 4, 
		/**组队副本 */
		teamBattle = 5, 
		/**装备强化 */
		equipStrengthen = 6, 
		/**婚礼 */
		wedding = 7, 
		/**城堡联姻 */
		castleMarriage = 8, 
		/**城堡宴会 */
		castleParty = 9, 
		/**充值 */
		topUp = 10, 
		/**酒馆招募 */
		tavernRecruit = 11, 
		/**跑商任务 */
		runTask = 12, 
		/**随机任务 */
		randomTask = 13, 
	}

	/**战斗公式计算结果类型*/
	public enum EBattleRecordResultType{
		/**命中*/
		hitNum = 1, 
		/**暴击*/
		criNum = 2, 
		/**最终伤害系数*/
		dmgPer = 3, 
		/**随机无视防御概率*/
		randomIgnoreDefPer = 4, 
		/**最终防御率*/
		defEfficiency = 5, 
		/**盾牌格挡概率*/
		blkPer = 6, 
		/**盾牌格挡防御力*/
		blkNum = 7, 
		/**武器架招概率*/
		pryPer = 8, 
		/**武器架招防御力*/
		pryNum = 9, 
		/**最终防御力*/
		defNum = 10, 
		/**攻击力*/
		baseDmg = 11, 
		/**最终伤害值*/
		totalDmg = 12, 
		/**真实伤害值*/
		realDmg = 13, 
	}

	/** 前端用技能选择目标枚举*/
	public enum EClientSkillSelectTarget{
		//我方
		identity = 1, 
		//友方
		friend = 2, 
		//敌方及中立
		different = 3, 
		//格子
		slot = 4, 
		//空格子
		empty_slot = 5, 
		//自己
		self = 6, 
	}

	/**主线、支线任务接取方式 */
	public enum ETaskAcceptType{
		/**自动接取 */
		ZiDong = 1, 
		/**手动接取 */
		ShouDong = 2, 
	}

	/**婚宴触发类型*/
	public enum EWeddingTriggerType{
		/**城堡相亲*/
		castleAlliance = 1, 
		/**城堡宴会*/
		castleFeast = 2, 
		/**节日*/
		festival = 3, 
	}

	/**格子效果触发条件*/
	public enum ETileTriggerConditionType{
		/**进入格子时*/
		enterTile = 1, 
		/**离开格子时*/
		leaveTile = 2, 
		/**格子中角色行动结束时*/
		actorActivityEnd = 3, 
		/**角色途经本格子时，行动起点和终点都不在该格子上*/
		passByTile = 4, 
		/**位于格子上的角色目标职业为[EMonsterOccuType]*/
		actorJob = 5, 
	}

	/**格子效果触发结果*/
	public enum ETileTriggerResultType{
		/**更改格子状态为阻碍*/
		setTileTypeZuAi = 1, 
		/**为格子中角色添加MID为[手填数值],持续时间为[手填数值]的角色BUFF*/
		addActorBuffToTileChild = 2, 
		/**为格子中角色移除MID为[手填数值]的角色BUFF*/
		removeActorBuffInTileChild = 3, 
		/**对格子中的角色治疗其血量上限万分之[手填数值]的血量*/
		actorPerCure = 4, 
		/**对格子中的角色造成其血量上限万分之[手填数值]的伤害*/
		actorPerDamage = 5, 
	}

	/**新攻击行动流程枚举*/
	public enum EBattleAttackActionCycle{
		/**确认开启攻击行动*/
		openAtkAct = 1, 
		/**挂载主动进攻角色主动技能效果前*/
		loadSkillEffectBefore = 2, 
		/**确认攻击主目标*/
		selectedAtkMainTarget = 3, 
		/**攻击行动中双方可能进行的技能流程结算顺序确定前*/
		useSkillOrderAdjustBefore = 4, 
		/**执行攻击行动中的多个技能行动队列*/
		runUseSkillQueue = 5, 
		/**攻击行动结束*/
		atkActEnd = 6, 
	}

	/**新技能行动流程枚举*/
	public enum EBattleUseSkillActionCycle{
		/**计算使用技能所需的AP消耗*/
		countApConsume = 1, 
		/**结算并消耗AP*/
		settleApConsume = 2, 
		/**确认开启技能使用行动*/
		openUseSkill = 3, 
		/**确认技能主目标*/
		selectedUseSkillMainTarget = 4, 
		/**确认技能次要目标*/
		selectedUseSkillAllTarget = 5, 
		/**非主动进攻方挂载技能效果前*/
		loadSkillEffectBefore = 6, 
		/**应用技能效果*/
		trySkillEffect = 7, 
		/**伤害及连击循环前*/
		skillDmgCycleBefore = 8, 
		/**伤害效果连击触发*/
		runDHit = 9, 
		/**依次执行所有目标的伤害效果结算流程*/
		runSettleDmg = 10, 
		/**伤害及连击循环后*/
		skillDmgCycleAfter = 11, 
		/**结算技能效果及技能伤害流程后*/
		settleSkillEffectAfter = 12, 
		/**使用技能行动结束*/
		useSkillActEnd = 13, 
	}

	/**新技能伤害效果执行流程*/
	public enum EBattleDmgEffectCycle{
		/**计算命中结果前*/
		countHitBefore = 1, 
		/**结算命中结果*/
		settleHit = 2, 
		/**计算暴击结果前*/
		countCri = 3, 
		/**结算暴击结果*/
		settleCri = 4, 
		/**计算防御完全穿透前*/
		countIgnoreDefBefore = 5, 
		/**结算防御完全穿透结果*/
		settleIgnoreDef = 6, 
		/**计算格挡/架招概率前*/
		countBlkPryBefore = 7, 
		/**结算格挡/架招结果*/
		settleBlkPry = 8, 
		/**计算总伤害前*/
		countTotalDmgNumBefore = 9, 
		/**结算总伤害*/
		settleTotalDmgNum = 10, 
		/**结算真实伤害*/
		settleRealDmgNum = 11, 
		/**结算真实伤害对受击方的致死性*/
		settleCanSkill = 12, 
		/**对受击方应用损伤结算后*/
		onDmgAfter = 13, 
		/**结算受击方死亡状态*/
		settleDeadState = 14, 
	}

	/**游戏语言类型 */
	public enum ELanguage{
		/**英语 */
		English = 0, 
		/**简体 */
		S_Chinese = 1, 
		/**繁体 */
		T_Chinese = 2, 
	}

	/**城堡图书馆中图鉴一级类型 */
	public enum EAtlasType{
		/**装备 */
		Equipment = 1, 
		/**材料 */
		Material = 2, 
		/**血脉 */
		Blood = 3, 
		/**特性 */
		Characteristic = 4, 
	}

	/**图鉴类型中装备图鉴类型 */
	public enum EEquipmentAtlasType{
		/**武器 */
		Weapon = 1, 
		/**盾牌 */
		Shield = 2, 
		/**护手 */
		HandGuard = 3, 
		/**护甲 */
		Armor = 4, 
		/**鞋 */
		Shoes = 5, 
		/**饰品 */
		Ornaments = 6, 
	}

	/**图书馆图鉴信息状态类型 */
	public enum EAtlasInfoStatusType{
		/**未激活 */
		None = 0, 
		/**已激活未领奖 */
		Activation = 1, 
		/**已激活已领取奖励 */
		Received = 2, 
	}

	/**材料和血脉类型 */
	public enum EMaterialType{
		/**赫尔沃 */
		HerErWo = 1, 
		/**赫拉西诺 */
		HeLaXiNuo = 2, 
		/**金尼斯 */
		JinNiSi = 3, 
		/**巴拉赞 */
		BaLaZan = 4, 
		/**索勒斯 */
		SuoLeSi = 5, 
		/**斯诺兰多 */
		SiNuoLanDuo = 6, 
	}

	/**特性类型 */
	public enum ECharacteristic{
		/**圣痕 */
		HolyMarks = 1, 
		/**种族 */
		Race = 2, 
		/**星座 */
		Horoscope = 3, 
		/**地域 */
		Regional = 4, 
		/**混血 */
		Dhampir = 5, 
	}

	/**图鉴事件类型2说明 */
	public enum LibraryEventType2{
		/**军团建立 */
		CreateGroup = 1, 
		/**军团修改名称(每次都记录) */
		GroupChangeName = 2, 
		/**拥有第一位某爵位的角色 */
		GetFirstNobilityActor = 3, 
		/**达到友好度等级 */
		AchieveFriendLevel = 4, 
		/**完成所有主线剧情 */
		CompleteMainTask = 5, 
	}

}
