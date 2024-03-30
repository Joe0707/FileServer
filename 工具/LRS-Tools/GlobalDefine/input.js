module.exports = {
    /**
     * 服务器与客户端共用常量定义说明
     * 特殊说明： 此处定义的变量与生成json文件工具中的GlobleDefine.cs文件中定义的是一致的。
     * 有转化工具将该文件定义的变量转成GlobleDefine.cs文件中定义的常量。
     * 首字符有大写E的代表是枚举类型。以下带E字幕的会有3个地方用到，客户端，服务器，策划数据转换。
     * 没有E字幕的会转成类，客户端使用。
     */
    /** 单参数：单参数值，只有key:value形式 */
    CONST: {
        /** 该字段代码没用，目的是被转换成类 */
        None: "none",
        /** 默认初始化的actor数据ID */
        DefaultActorId: 10001,
        /** 第一个关卡ID,测试协议使用，默认关卡ID */
        DefaultLevelId: 10001,
        /** 技能插槽个数最大值 */
        SkillMaxSlots: 6,
        /** 给角色的默认被动技能ID */
        SkillIdBeiDong: 2908,
        /** 给角色的默认AP技能ID */
        SkillIdAp: 52403,
        /** 角色默认装备ID */
        EquipDefaultId: 10001,
        /** 设置角色默认最大AP值 */
        MaxAp: 3,
        /** 倍数基数 */
        PERCENT_ONE: 10000,
        /** 带小数点的属性基础数值 */
        PROP_PERCENT_ONE: 100,
        /**道具ID组成部分乘以的系数,道具ID生成规则：背包类型*系数+对应表(例如装备)的道具ID */
        ItemIdRate: 1000000,
        /**根据装备类型获取槽位类型时要除以的系数 */
        EquipSlotTypeRate: 1000,
        /**装备洗炼最大次数 */
        EquipmentRefinementMax: 20,
        /**装备基础属性提升幅度除数 */
        EquipmentBasicNatureAddDivisor: 10000,
        /**装备宝石槽位重置占比总和 */
        EquipGemSlotResetRatioTotal: 10000,
        /**装备强化概率除数 */
        EquipmentStrengthenProDivisor: 10000,
        /**装备升品概率除数 */
        EquipmentUpPromoteProDivisor: 10000,
        /**邮件一页的数量 */
        MailNumberOfPage: 4,
        /**装备宝石槽位升级概率总和 */
        EquipGemSlotUpLevelTotal: 10000,
        /**账号默认地图ID(新建账号默认值) */
        DefaultMapId: 1,
        /**账号默认地图点ID(新建账号默认值) */
        DefaultMapPointId: 101335,
        /**转职非特产国消耗提升倍数 */
        ChangeJobConsumeUp:1.5,

    },
    /**触发器全局类型 */
    GlobalTriggerType: {
        /**战斗胜利触发器 */
        BattleWin: 0,
        /**战斗失败触发器 */
        BattleLose: 1,
        /**通用*/
        Common: 2,
    },
    /**血脉类型 */
    DescentType: {
        /**没有类型 */
        none: -1,
        /**赫尔沃 */
        heerwo: 0,
        /**索勒斯 */
        suolesi: 1,
    },
    /** 触发条件 (代表Attr键)[代表Attr值类型]*/
    EConditionType: {
        /** 无 */
        None: 0,
        /**条件组*/
        ConditionGroupConfig: 1,
        /**战斗场景状态为(FightStatus)[EFightStatus]时 */
        FightScenetStatusConditionConfig: 2,
        /**坚持回合数为(roundNumber)[int]*/
        KeepRoundConditionConfig: 3,
        /**角色木桩Id((RoleId)[string]到达(SlotIndex)[int]*/
        RoleArriveEventConditionConfig: 4,
        /**角色木桩Id((RoleId)[string]属性(Property)[ERoleProperty]到达百分之(Limit)[float]*/
        RoleInfoEventConditionConfig: 5,
        /**角色木桩Id((RoleGid)[string]不能死亡*/
        RoleNoDeathConditionConfig: 6,
        /**角色木桩Id((roleGid)[string]不能撤离*/
        RoleNoRunConditionConfig: 7,
        /**角色木桩Id((roleGid)[string]撤离*/
        RoleRunConditionConfig: 8,
        /**(Team)[ETeamType]阵营在回合数(RoundNumber)[int]的回合状态(RoundStatus)[ERoundStatus]时*/
        RoundEventConditionConfig: 9,
        /**部队(Team)[ETeamType]撤离格子(SlotIndex)[int]*/
        RunConditionConfig: 10,
        /**(CurScene)[ESceneType]切换到(NextScene)[ESceneType]*/
        SceneChangeEventConditionConfig: 11,
        /**格子(SlotIndex)[int]的状态(StatusType)[EStatusType]的id号是(StatusId)[string]*/
        StatusConditionConfig: 12,
        /**部队(deathTeam)[ETeamType]全灭*/
        TeamDeathConditionConfig: 13,
        /**部队(team)[ETeamType]不能有成员死亡*/
        TeamNoDeathConditionConfig: 14,
        /**部队(runTeam)[ETeamType]不能撤离条件*/
        TeamNoRunConditionConfig: 15,
        /**部队(runTeam)[ETeamType]撤离条件*/
        TeamRunConditionConfig: 16,
        /**职业Id(JobId)[int]击杀角色木桩id(RoleId)[string]条件*/
        JobKillRoleConditionConfig: 17,
        /**战斗场景内真实玩家全部不能操作*/
        AllRealPlayerNotActive: 18,
    },
    /** 触发结果 (代表Attr键)[代表Attr值类型]*/
    EResultType: {
        /** 无 */
        None: 0,
        /**部队(Team)[ETeamType]在格子(SlotIndex)[int]撤离*/
        AddRunSlotEventResultConfig: 1,
        /**战斗失败结果*/
        BattleFailedResultConfig: 2,
        /**战斗胜利结果*/
        BattleWinResultConfig: 3,
        /**角色木桩Id(CallRoleId)[string]通过(CallType)[ECallType]召唤 召唤的格子(SlotIndex)[int] 召唤的友方角色木桩Id(ActorId)[string] 召唤的敌方角色木桩Id(MonsterId)[string]*/
        CallEventResultConfig: 4,
        /**相机焦点结束事件*/
        CameraFocusEndEventResultConfig: 5,
        /**相机聚焦到角色木桩Id(RoleID)[string]身上 聚焦事件(Move2FocusTime)[float]相机焦点位置(EndPosition)[Value3] 相机焦点旋转角(EndRotation)[Value3] 相机尺寸(EndCameraSize)[float]*/
        CameraFocusEventResultConfig: 6,
        /**相机移动到(EndPosition)[Value3] 角度(EndRotation)[Value3] 尺寸(EndCameraSize)[float] 移动时长(MoveTime)[float]*/
        CameraMoveEventResultConfig: 7,
        /**相机放置到(CameraPosition)[Value3] 角度(CameraRotation)[Value3] 尺寸(CameraSize)[float]*/
        CameraPlaceEventResultConfig: 8,
        /**角色木桩Id(RoleId)[string]更改AIID(AIId)[string]*/
        ChangeAIEventResultConfig: 9,
        /**更改BGM(BGMId)[string]*/
        ChangeBGMEventResultConfig: 10,
        /**更改格子(SlotIndex)[int]元件(ElementId)[string]事件*/
        ChangeSlotElementEventResultConfig: 11,
        /**角色木桩Id(RoleId)[string]更换阵营(Team)[ETeamType]事件*/
        ChangeTeamEventResultConfig: 12,
        /**变更胜利条件(WinId)[string]*/
        ChangeWinEventResultConfig: 13,
        /**角色木桩Id(RoleId)[string]删除事件*/
        DeleteRoleEventResultConfig: 14,
        /**角色木桩Id(RoleId)[string]死亡事件*/
        RoleDeathEventResultConfig: 15,
        /**角色木桩Id(RoleId)[string]离开 离场格子(LevelSlotIndex)[int]*/
        RoleLeaveEventResultConfig: 16,
        /**角色木桩Id(RoleId)[string]移动到格子(SlotIndex)[int] 目标角色木桩Id(TargetId)[string] 角色和目标角色间隔格子(RolesSlotInterval)[int] 移动时间(MoveTime)[float]*/
        RoleMoveEventResultConfig: 17,
        /**释放技能 来自角色木桩Id(FromId)[string] 目标角色木桩Id(ToId)[string] 技能Id(SkillId)[string]*/
        SkillEventResultConfig: 18,
        /**状态切换为(StatusType)[EStatusType]*/
        StatusResultConfig: 19,
        /**发起文字事件 Id(StringId)[string]*/
        TextEventResultConfig: 20,
        /**更改战斗场景生命周期状态到{cycleState: SceneCycleStateEnum}*/
        ChangeBattleCycleStateAlsoRunCycle: 21
    },
    /** 是否死亡 */
    EIsDead: {
        /** 未死亡 */
        False: 0,
        /** 死亡 */
        True: 1
    },
    /** 生物攻击类型 */
    EMonsterAttcakType: {
        /**生物移动 [msgType: EMonsterAttackType.YiDong, msgValue: tileIndex, attackId: fromGid, hiterId: "", isDev: 0, isRit: 0, isDead: 0, skillId: 0]*/
        YiDong: 0,
        /**近战攻击 [msgType: EMonsterAttackType.JinZhan, msgValue: 伤害值, attackId: fromGid, hiterId: toGid, isDev: boolean, isRit: boolean, isDead: boolean, skillId: skillId]*/
        JinZhan: 1,
        /**远程攻击 [msgType: EMonsterAttackType.YuanCheng, msgValue: 伤害值, attackId: fromGid, hiterId: toGid, isDev: boolean, isRit: boolean, isDead: boolean, skillId: skillId]*/
        YuanCheng: 2,
        /**法术治疗 [msgType: EMonsterAttackType.YuanCheng, msgValue: 治疗值, attackId: fromGid, hiterId: toGid, isDev: boolean, isRit: boolean, isDead: boolean, skillId: skillId]*/
        FaShu: 3,
        /**显示当前ap [{]msgType: EMonsterAttackType.ShowAp, msgValue: curAp, attackId: fromGid, hiterId: "", isDev: 0, isRit: 0, isDead: 0, skillId: 0]*/
        ShowAp: 4,
        /**减少ap [msgType: EMonsterAttackType.ShowAp, msgValue: changeNum, attackId: fromGid, hiterId: "", isDev: 0, isRit: 0, isDead: 0, skillId: 0]*/
        JianAp: 5,
        /**生物到达撤离点 [msgType: EMonsterAttackType.CheLiDian, msgValue: tileIndex, attackId: fromGid, hiterId: "", isDev: 0, isRit: 0, isDead: 0, skillId: 0]*/
        CheLiDian: 6,
        /**当前生物移动力 [msgType: EMonsterAttackType.CurrMove, msgValue: currMoveValue(当前生物移动力), attackId: fromGid, hiterId: "", isDev: 0, isRit: 0, isDead: 0, skillId: 0]*/
        CurrMove: 7,
    },
    /** 伤害判定结果标识*/
    EDmgJudgmentFlag: {
        /** 忽略防御*/
        isIgnoreDef: 1,
        /** 招架*/
        isPry: 2,
        /** 格挡*/
        isBlk: 4,
        /** 暴击*/
        isCri: 8,
        /** 命中*/
        isHit: 16,
        /** 偏斜*/
        isDev: 32,
        /** 闪避*/
        isDodge: 64,
    },
    /** 服务器类型ID，目的服务器ID参数的名称*/
    ServerIdName: {
        /** gate服，客户端配置获取连接服使用 */
        gate: "gateId",
        /** 连接服 */
        connectorid: "connId",
        /** 登录服 */
        loginserverid: "loginId",
        /** 游戏服 */
        gameserverid: "gameId",
        /** 战斗服 */
        battleserverid: "battleId",
        /** token验证服 */
        auth: "authId",
        /** 日志服 */
        logserver: "logId"
    },

    /** 账号状态描述 */
    ELOGINSTATUS: {
        /** 手填账号密码登陆 */
        REGISTER: 0,
        /** 游客登陆(快速登陆) */
        QUICKLOGIN: 1,
        /** 通行证(第三方sdk) */
        SDKLOGIN: 2,
        /** 起初为游客或快速登陆，后期补全信息 */
        QUICKLOGINSUFFIX: 3
    },

    /** 关卡格子上生物类型 */
    EStumpTileThingType: {
        /** 自己队员（包括自己） */
        SelfTeam: 1,
        /** 敌方队员 */
        MonsterTeam: 2,
    },

    /**
     * 战斗回合状态ID
     */
    BattleStateID: {
        /** 不切换状态 */
        None: "None",
        /** (初始化战斗机或站前准备)  */
        BattleInit: "BattleInit",
        /** 战斗开始 */
        BattleStart: "BattleStart",
        /** (队伍调整) */
        TeamAdjustment: "TeamAdjustment",
        /** (我的回合) */
        MyTurn: "MyTurn",
        /** (别人的回合) */
        OthersTurn: "OthersTurn",
        /** 剧情 */
        Dialog: "Dialog",
        /** 战斗结算 */
        BattleResult: "BattleResult",
        /** 战斗结束 */
        BattleEnd: "BattleEnd"

    },
    /**
     * 战斗结果状态
     */
    BattleResultState: {
        /**战前 */
        ZhanQian: -1,
        /** 战斗中 */
        ZhanZhong: 0,
        /** 战斗失败 */
        Fail: 1,
        /** 战斗胜利 */
        Successfully: 2,
        /**战斗结束 */
        End: 3
    },
    /** 技能服务器类型 */
    ESkillType: {
        /** 0 普通技能(主动) */
        GNERAL_SKILL: 0,
        /** 1 buffer */
        BUFFER_SKILL: 1,
        /** 2 旋风斩目标为中心 */
        WHIRLWIND_TARGET_SKILL: 2,
        /** 3 旋风斩自己为中心 */
        WHIRLWIND_SELF_SKILL: 3,
        /** 4 冲锋 */
        CHARGE_SKILL: 4,
        /** 5 暴击 */
        DOUBLE_SKILL: 5,
        /**表中数值为空的数据，需要确定为空的数据是否默认0 */
        NONE_SKILL: 6
    },

    /** 渠道 */
    EChannel: {
        /** 苹果商店 */
        AppStore: 0,
        /** 谷歌商店 */
        GooglePlay: 1,
        /** TapTap */
        TapTap: 2,
        /** 枚举最大值 */
        Max: 3
    },

    /** 性别 */
    EGender: {
        /** 未知 */
        Unknown: 0,
        /** 男 */
        Male: 1,
        /** 女 */
        Female: 2,
    },

    /** 格子类型 */
    ESlotType:
        {
            /** 普通 */
            PuTong: 0,
            /** 阻挡(不能走的) */
            ZuDang: 1,
            /**遮挡(能走的,如草丛) */
            ZheDang: 2
        },

    /** 生物类型 */
    EStumpType:
        {
            /** 怪物 */
            Monster: 0,
            /** Npc */
            NpcActor: 1,
            /** 玩家 */
            PlayerActor: 2
        },

    /** 队伍类型 */
    ETeamType: {
        /** 自己 */
        Player: 0,
        /** 敌方 */
        Enemy: 1,
        /** 友方 */
        Friend: 2,
        /** 中立 */
        Neutral: 3,
        /** 全部 */
        All: 4,
    },

    /** 目标类型 */
    ESkillTargetType: {
        /** 敌方 */
        Enemy: 1,
        /** 友方 */
        Friend: 2,
        /** 3之前值为空,为生成数据暂定为3后续核实后再修改 */
        Neutral: 3
    },

    /** 生物朝向 */
    EDirection:
        {
            /** 向上 */
            Up: 0,
            /** 向下 */
            Down: 1,
            /** 向左 */
            Left: 2,
            /** 向右 */
            Right: 3
        },

    /** 关卡类型 */
    ELevelType:
        {
            /** 歼灭 */
            JianMie: 0,
            /** 斩首 */
            ZhanShou: 1,
            /** 夺旗 */
            DuoQI: 2,
            /** 坚守 */
            JianShou: 3,
            /** 撤离 */
            CheLi: 4,
            /** 护卫 */
            HuWei: 5,
            /** 追杀 */
            ZhuiSha: 6,
            /** 防御 */
            FangYu: 7,
            /** 护送 */
            HuSong: 8
        },

    /** 场景类型 */
    EThemeType:
        {
            /** 平原 */
            PingYuan: 0,
            /**城镇 */
            ChengZhen: 1,
            /**城里 */
            ChengLi: 2,
            /**城外 */
            ChengWai: 3,
            /**沙漠 */
            ShaMo: 4,
            /**山寨外 */
            ShanZhaiWai: 5,
            /**山脚 */
            ShanJiao: 6,
        },

    /** 生物职业类型 */
    EMonsterOccuType:
        {
            /**战士 */
            ZhanShi: 10211,
            /** 新兵 */
            XinBing: 10312,
            /** 轻步兵 */
            QingBuBing: 10101,
            /** 轻骑兵 */
            QingQiBing: 10231,
            /**游侠 */
            YouXia: 10342,
            /**皇家骑兵 */
            HuangJiaQiBing: 10331,
            /**贫民 */
            PingMin: 10101,
            /**重甲僧侣 */
            ZhongJiaSengLv: 10323,
            /**剑圣 */
            JianSheng: 10314,
            /**斥候 */
            ChiHou: 10212,
            /**狂战士 */
            KuangZhanShi: 10311,
            /**刺客 */
            CiKe: 10313,
            /**重步兵 */
            ZhongBuBing: 10121,
            /**方阵步兵 */
            FangZhenBuBing: 10221,
            /**重甲枪兵 */
            ZhongJiaQiangBing: 10222,
            /**王室禁卫 */
            WangShiJinWei: 10321,
            /**铁甲军士 */
            TieJiaJunShi: 10322,
            /**圣堂铁卫 */
            ShengTangTieWei: 10324,
            /**见习骑兵 */
            JianXiQiBing: 10131,
            /**重骑兵 */
            ZhongQiBing: 10232,
            /**重装骑兵 */
            ZhongZhuangQiBing: 10332,
            /**掠袭骑兵 */
            LueXiQiBing: 10333,
            /**统御骑士 */
            TongYuQiBing: 10334,
            /**猎人 */
            LieRen: 10141, 
            /**弩手 */
            NuShou: 10242,
            /**长弓手 */
            ChangGongShou: 10341,
            /**盾弩手 */
            DunNuShou: 10343,
            /**重弩手 */
            ZhongNuShou: 10344,
            /**自学巫师 */
            ZiXueWuShi: 10151,
            /**魔法师(德鲁伊) */
            MoFaShi: 10251,
            /**牧师 */
            MuShi: 10252,
            /**魔导师(大德鲁伊) */
            MoDaoShi: 10351,
            /**主教 */
            ZhuJiao: 10352,
            /**吟游诗人 */
            YinYouShiRen: 10353,
            /**炼金术士 */
            LianJinShuShi: 10354,
        },

    /** 怪物外形 */
    EMonsterType: {
        /** 人形 */
        RenXing: 0,
        /** 野兽 */
        YeShou: 1,
        /** 建筑 */
        JianZhu: 2
    },

    /** 人物部件 */
    EPart: {
        /** 后面的头发 */
        HouFa: 0,
        //身体
        ShenTi: 1,
        //衣服
        YiFu: 2,
        //项链
        XiangLian: 3,
        //中间的头发,
        ZhongFa: 4,
        //脸
        Lian: 5,
        //面纹
        MianWen: 6,
        //圣痕
        ShengHeng: 7,
        //眼
        Yan: 8,
        //眉
        Mei: 9,
        //鼻
        Bi: 10,
        //嘴
        Zui: 11,
        //皱纹
        ZhouWen: 12,
        //胡须
        HuXu: 13,
        //前发
        QianFa: 14,
        //头饰
        TouShi: 15,
        //耳
        Er: 16,
        //耳环
        ErHuan: 17,
        //前前发
        QianQianFa: 18
    },
    /** 光效目标 */
    EViewTarget: {
        /**未知 */
        None: 0,
        /**自己 */
        Self: 1,
        /**目标 */
        Target: 2,
        /**全部 */
        All: 3
    },
    /**(效果状态表)删除状态条件 */
    EEffectStatusStop1: {
        /**无 */
        None: 0,
        /**战斗过 */
        Battle: 1,
        /**回合开始 */
        RoundStart: 2,
        /**回合内没移动 */
        RoundNotMove: 3,
        /**回合内没行动 */
        RoundNotAction: 4
    },
    /**关卡触发器应用类型,分服务器,客户端 */
    ETriggerApplyType: {
        /**客户端使用 */
        Client: 0,
        /**服务器使用 */
        Server: 1,
        /**客户端,服务器都使用 */
        Both: 2
    },
    /** 角色外观部件类型*/
    EExteriorPartType: {
        face: "face",//脸
        eyebrow: "eyebrow",//眉
        eye: "eye",//眼
        nose: "nose",//鼻
        mouth: "mouth",//嘴
        ear: "ear",//耳
        body: "body",//身体
        clothes: "clothes",//衣服
        hair: "hair",//发型
        stigma: "stigma",//圣痕
        tattoo: "tattoo",//刺青
        beard: "beard",//胡子
        beard2: "beard2",//连鬓胡子
        skin_color: "skin_color",//肤色
        hair_color: "hair_color",//发色
        eyebrow_color: "eyebrow_color",//眉毛颜色
        beard_color: "beard_color",//胡子颜色
        hair_jewelry: "hair_jewelry",//发饰
        medal: "medal",//勋章
    },
    /** 角色属性类型枚举*/
    EActorAttrType: {
        /**力量*/
        str: 1,
        /**常量力量增加*/
        str_s: 2,
        /**百分比力量增加*/
        str_p: 3,
        /**当前帧常量力量增加*/
        str_s_f: 4,
        /**当前帧百分比力量增加*/
        str_p_f: 5,
        /**体质*/
        vit: 6,
        /**常量体质增加*/
        vit_s: 7,
        /**百分比体质增加*/
        vit_p: 8,
        /**当前帧常量体质增加*/
        vit_s_f: 9,
        /**当前帧百分比体质增加*/
        vit_p_f: 10,
        /**技巧*/
        dex: 11,
        /**常量技巧增加*/
        dex_s: 12,
        /**百分比技巧增加*/
        dex_p: 13,
        /**当前帧常量技巧增加*/
        dex_s_f: 14,
        /**当前帧百分比技巧增加*/
        dex_p_f: 15,
        /**感知*/
        per: 16,
        /**常量感知增加*/
        per_s: 17,
        /**百分比感知增加*/
        per_p: 18,
        /**当前帧常量感知增加*/
        per_s_f: 19,
        /**当前帧百分比感知增加*/
        per_p_f: 20,
        /**敏捷*/
        agi: 21,
        /**常量敏捷增加*/
        agi_s: 22,
        /**百分比敏捷增加*/
        agi_p: 23,
        /**当前帧常量敏捷增加*/
        agi_s_f: 24,
        /**当前帧百分比敏捷增加*/
        agi_p_f: 25,
        /**意志*/
        wil: 26,
        /**常量意志增加*/
        wil_s: 27,
        /**百分比意志增加*/
        wil_p: 28,
        /**当前帧常量意志增加*/
        wil_s_f: 29,
        /**当前帧百分比意志增加*/
        wil_p_f: 30,
        /**全六维*/
        quanLiuWei: 31,
        /**常量全六维增加*/
        quanLiuWei_s: 32,
        /**百分比全六维增加*/
        quanLiuWei_p: 33,
        /**当前帧常量全六维增加*/
        quanLiuWei_s_f: 34,
        /**当前帧百分比全六维增加*/
        quanLiuWei_p_f: 35,
        /**HP上限*/
        hp: 36,
        /**常量HP上限增加*/
        hp_s: 37,
        /**百分比HP上限增加*/
        hp_p: 38,
        /**当前帧常量HP上限增加*/
        hp_s_f: 39,
        /**当前帧百分比HP上限增加*/
        hp_p_f: 40,
        /**AP上限*/
        ap: 41,
        /**常量AP上限增加*/
        ap_s: 42,
        /**百分比AP上限增加*/
        ap_p: 43,
        /**当前帧常量AP上限增加*/
        ap_s_f: 44,
        /**当前帧百分比AP上限增加*/
        ap_p_f: 45,
        /**每回合AP恢复量*/
        recoveryAp: 46,
        /**常量每回合AP恢复量增加*/
        recoveryAp_s: 47,
        /**百分比每回合AP恢复量增加*/
        recoveryAp_p: 48,
        /**当前帧常量每回合AP恢复量增加*/
        recoveryAp_s_f: 49,
        /**当前帧百分比每回合AP恢复量增加*/
        recoveryAp_p_f: 50,
        /**负重上限*/
        wgt: 51,
        /**常量负重上限增加*/
        wgt_s: 52,
        /**百分比负重上限增加*/
        wgt_p: 53,
        /**当前帧常量负重上限增加*/
        wgt_s_f: 54,
        /**当前帧百分比负重上限增加*/
        wgt_p_f: 55,
        /**移动力上限*/
        mov: 56,
        /**常量移动力上限增加*/
        mov_s: 57,
        /**百分比移动力上限增加*/
        mov_p: 58,
        /**当前帧常量移动力上限增加*/
        mov_s_f: 59,
        /**当前帧百分比移动力上限增加*/
        mov_p_f: 60,
        /**移动次数*/
        movN: 61,
        /**常量移动次数增加*/
        movN_s: 62,
        /**百分比移动次数增加*/
        movN_p: 63,
        /**当前帧常量移动次数增加*/
        movN_s_f: 64,
        /**当前帧百分比移动次数增加*/
        movN_p_f: 65,
        /**攻击次数*/
        atkN: 66,
        /**常量攻击次数增加*/
        atkN_s: 67,
        /**百分比攻击次数增加*/
        atkN_p: 68,
        /**当前帧常量攻击次数增加*/
        atkN_s_f: 69,
        /**当前帧百分比攻击次数增加*/
        atkN_p_f: 70,
        /**行动次数*/
        actN: 71,
        /**常量行动次数增加*/
        actN_s: 72,
        /**百分比行动次数增加*/
        actN_p: 73,
        /**当前帧常量行动次数增加*/
        actN_s_f: 74,
        /**当前帧百分比行动次数增加*/
        actN_p_f: 75,
        /**反击次数*/
        resistN: 76,
        /**常量反击次数增加*/
        resistN_s: 77,
        /**百分比反击次数增加*/
        resistN_p: 78,
        /**当前帧常量反击次数增加*/
        resistN_s_f: 79,
        /**当前帧百分比反击次数增加*/
        resistN_p_f: 80,
        /**物理偏斜值*/
        pDev: 81,
        /**常量物理偏斜值增加*/
        pDev_s: 82,
        /**百分比物理偏斜值增加*/
        pDev_p: 83,
        /**当前帧常量物理偏斜值增加*/
        pDev_s_f: 84,
        /**当前帧百分比物理偏斜值增加*/
        pDev_p_f: 85,
        /**物理偏斜减伤系数值*/
        pDevDmg: 86,
        /**常量物理偏斜减伤系数值增加*/
        pDevDmg_s: 87,
        /**百分比物理偏斜减伤系数值增加*/
        pDevDmg_p: 88,
        /**当前帧常量物理偏斜减伤系数值增加*/
        pDevDmg_s_f: 89,
        /**当前帧百分比物理偏斜减伤系数值增加*/
        pDevDmg_p_f: 90,
        /**魔法偏斜值*/
        mDev: 91,
        /**常量魔法偏斜值增加*/
        mDev_s: 92,
        /**百分比魔法偏斜值增加*/
        mDev_p: 93,
        /**当前帧常量魔法偏斜值增加*/
        mDev_s_f: 94,
        /**当前帧百分比魔法偏斜值增加*/
        mDev_p_f: 95,
        /**魔法偏斜减伤系数值*/
        mDevDmg: 96,
        /**常量魔法偏斜减伤系数值增加*/
        mDevDmg_s: 97,
        /**百分比魔法偏斜减伤系数值增加*/
        mDevDmg_p: 98,
        /**当前帧常量魔法偏斜减伤系数值增加*/
        mDevDmg_s_f: 99,
        /**当前帧百分比魔法偏斜减伤系数值增加*/
        mDevDmg_p_f: 100,
        /**物理命中值*/
        pHit: 101,
        /**常量物理命中值增加*/
        pHit_s: 102,
        /**百分比物理命中值增加*/
        pHit_p: 103,
        /**当前帧常量物理命中值增加*/
        pHit_s_f: 104,
        /**当前帧百分比物理命中值增加*/
        pHit_p_f: 105,
        /**魔法命中值*/
        mHit: 106,
        /**常量魔法命中值增加*/
        mHit_s: 107,
        /**百分比魔法命中值增加*/
        mHit_p: 108,
        /**当前帧常量魔法命中值增加*/
        mHit_s_f: 109,
        /**当前帧百分比魔法命中值增加*/
        mHit_p_f: 110,
        /**物理暴击值*/
        pCri: 111,
        /**常量物理暴击值增加*/
        pCri_s: 112,
        /**百分比物理暴击值增加*/
        pCri_p: 113,
        /**当前帧常量物理暴击值增加*/
        pCri_s_f: 114,
        /**当前帧百分比物理暴击值增加*/
        pCri_p_f: 115,
        /**魔法暴击值*/
        mCri: 116,
        /**常量魔法暴击值增加*/
        mCri_s: 117,
        /**百分比魔法暴击值增加*/
        mCri_p: 118,
        /**当前帧常量魔法暴击值增加*/
        mCri_s_f: 119,
        /**当前帧百分比魔法暴击值增加*/
        mCri_p_f: 120,
        /**物理暴击抵扣值（坚韧）*/
        pDCri: 121,
        /**常量物理暴击抵扣值（坚韧）增加*/
        pDCri_s: 122,
        /**百分比物理暴击抵扣值（坚韧）增加*/
        pDCri_p: 123,
        /**当前帧常量物理暴击抵扣值（坚韧）增加*/
        pDCri_s_f: 124,
        /**当前帧百分比物理暴击抵扣值（坚韧）增加*/
        pDCri_p_f: 125,
        /**魔法暴击抵扣值（抵抗）*/
        mDCri: 126,
        /**常量魔法暴击抵扣值（抵抗）增加*/
        mDCri_s: 127,
        /**百分比魔法暴击抵扣值（抵抗）增加*/
        mDCri_p: 128,
        /**当前帧常量魔法暴击抵扣值（抵抗）增加*/
        mDCri_s_f: 129,
        /**当前帧百分比魔法暴击抵扣值（抵抗）增加*/
        mDCri_p_f: 130,
        /**物理暴击伤害系数值*/
        pCriDmg: 131,
        /**常量物理暴击伤害系数值增加*/
        pCriDmg_s: 132,
        /**百分比物理暴击伤害系数值增加*/
        pCriDmg_p: 133,
        /**当前帧常量物理暴击伤害系数值增加*/
        pCriDmg_s_f: 134,
        /**当前帧百分比物理暴击伤害系数值增加*/
        pCriDmg_p_f: 135,
        /**魔法暴击伤害系数值*/
        mCriDmg: 136,
        /**常量魔法暴击伤害系数值增加*/
        mCriDmg_s: 137,
        /**百分比魔法暴击伤害系数值增加*/
        mCriDmg_p: 138,
        /**当前帧常量魔法暴击伤害系数值增加*/
        mCriDmg_s_f: 139,
        /**当前帧百分比魔法暴击伤害系数值增加*/
        mCriDmg_p_f: 140,
        /**格挡概率系数值*/
        blk: 141,
        /**常量格挡概率系数值增加*/
        blk_s: 142,
        /**百分比格挡概率系数值增加*/
        blk_p: 143,
        /**当前帧常量格挡概率系数值增加*/
        blk_s_f: 144,
        /**当前帧百分比格挡概率系数值增加*/
        blk_p_f: 145,
        /**格挡防御力*/
        blkDef: 146,
        /**常量格挡防御力增加*/
        blkDef_s: 147,
        /**百分比格挡防御力增加*/
        blkDef_p: 148,
        /**当前帧常量格挡防御力增加*/
        blkDef_s_f: 149,
        /**当前帧百分比格挡防御力增加*/
        blkDef_p_f: 150,
        /**招架概率系数值*/
        pry: 151,
        /**常量招架概率系数值增加*/
        pry_s: 152,
        /**百分比招架概率系数值增加*/
        pry_p: 153,
        /**当前帧常量招架概率系数值增加*/
        pry_s_f: 154,
        /**当前帧百分比招架概率系数值增加*/
        pry_p_f: 155,
        /**招架防御力*/
        pryDef: 156,
        /**常量招架防御力增加*/
        pryDef_s: 157,
        /**百分比招架防御力增加*/
        pryDef_p: 158,
        /**当前帧常量招架防御力增加*/
        pryDef_s_f: 159,
        /**当前帧百分比招架防御力增加*/
        pryDef_p_f: 160,
        /**物理防御力*/
        pDef: 161,
        /**常量物理防御力增加*/
        pDef_s: 162,
        /**百分比物理防御力增加*/
        pDef_p: 163,
        /**当前帧常量物理防御力增加*/
        pDef_s_f: 164,
        /**当前帧百分比物理防御力增加*/
        pDef_p_f: 165,
        /**魔法防御力*/
        mDef: 166,
        /**常量魔法防御力增加*/
        mDef_s: 167,
        /**百分比魔法防御力增加*/
        mDef_p: 168,
        /**当前帧常量魔法防御力增加*/
        mDef_s_f: 169,
        /**当前帧百分比魔法防御力增加*/
        mDef_p_f: 170,
        /**物理攻击力*/
        pAtk: 171,
        /**常量物理攻击力增加*/
        pAtk_s: 172,
        /**百分比物理攻击力增加*/
        pAtk_p: 173,
        /**当前帧常量物理攻击力增加*/
        pAtk_s_f: 174,
        /**当前帧百分比物理攻击力增加*/
        pAtk_p_f: 175,
        /**魔法攻击力*/
        mAtk: 176,
        /**常量魔法攻击力增加*/
        mAtk_s: 177,
        /**百分比魔法攻击力增加*/
        mAtk_p: 178,
        /**当前帧常量魔法攻击力增加*/
        mAtk_s_f: 179,
        /**当前帧百分比魔法攻击力增加*/
        mAtk_p_f: 180,
        /**物理暴击最终概率*/
        pCriSp: 181,
        /**常量物理暴击最终概率增加*/
        pCriSp_s: 182,
        /**百分比物理暴击最终概率增加*/
        pCriSp_p: 183,
        /**当前帧常量物理暴击最终概率增加*/
        pCriSp_s_f: 184,
        /**当前帧百分比物理暴击最终概率增加*/
        pCriSp_p_f: 185,
        /**魔法暴击最终概率*/
        mCriSp: 186,
        /**常量魔法暴击最终概率增加*/
        mCriSp_s: 187,
        /**百分比魔法暴击最终概率增加*/
        mCriSp_p: 188,
        /**当前帧常量魔法暴击最终概率增加*/
        mCriSp_s_f: 189,
        /**当前帧百分比魔法暴击最终概率增加*/
        mCriSp_p_f: 190,
        /**物理暴击最终概率抵扣（坚韧概率）*/
        pDCriSp: 191,
        /**常量物理暴击最终概率抵扣（坚韧概率）增加*/
        pDCriSp_s: 192,
        /**百分比物理暴击最终概率抵扣（坚韧概率）增加*/
        pDCriSp_p: 193,
        /**当前帧常量物理暴击最终概率抵扣（坚韧概率）增加*/
        pDCriSp_s_f: 194,
        /**当前帧百分比物理暴击最终概率抵扣（坚韧概率）增加*/
        pDCriSp_p_f: 195,
        /**魔法暴击最终概率抵扣（抵抗概率）*/
        mDCriSp: 196,
        /**常量魔法暴击最终概率抵扣（抵抗概率）增加*/
        mDCriSp_s: 197,
        /**百分比魔法暴击最终概率抵扣（抵抗概率）增加*/
        mDCriSp_p: 198,
        /**当前帧常量魔法暴击最终概率抵扣（抵抗概率）增加*/
        mDCriSp_s_f: 199,
        /**当前帧百分比魔法暴击最终概率抵扣（抵抗概率）增加*/
        mDCriSp_p_f: 200,
        /**物理偏斜最终概率*/
        pDevSp: 201,
        /**常量物理偏斜最终概率增加*/
        pDevSp_s: 202,
        /**百分比物理偏斜最终概率增加*/
        pDevSp_p: 203,
        /**当前帧常量物理偏斜最终概率增加*/
        pDevSp_s_f: 204,
        /**当前帧百分比物理偏斜最终概率增加*/
        pDevSp_p_f: 205,
        /**魔法偏斜最终概率*/
        mDevSp: 206,
        /**常量魔法偏斜最终概率增加*/
        mDevSp_s: 207,
        /**百分比魔法偏斜最终概率增加*/
        mDevSp_p: 208,
        /**当前帧常量魔法偏斜最终概率增加*/
        mDevSp_s_f: 209,
        /**当前帧百分比魔法偏斜最终概率增加*/
        mDevSp_p_f: 210,
        /**物理命中最终概率*/
        pHitSp: 211,
        /**常量物理命中最终概率增加*/
        pHitSp_s: 212,
        /**百分比物理命中最终概率增加*/
        pHitSp_p: 213,
        /**当前帧常量物理命中最终概率增加*/
        pHitSp_s_f: 214,
        /**当前帧百分比物理命中最终概率增加*/
        pHitSp_p_f: 215,
        /**魔法命中最终概率*/
        mHitSp: 216,
        /**常量魔法命中最终概率增加*/
        mHitSp_s: 217,
        /**百分比魔法命中最终概率增加*/
        mHitSp_p: 218,
        /**当前帧常量魔法命中最终概率增加*/
        mHitSp_s_f: 219,
        /**当前帧百分比魔法命中最终概率增加*/
        mHitSp_p_f: 220,
        /**格挡最终概率*/
        blkSp: 221,
        /**常量格挡最终概率增加*/
        blkSp_s: 222,
        /**百分比格挡最终概率增加*/
        blkSp_p: 223,
        /**当前帧常量格挡最终概率增加*/
        blkSp_s_f: 224,
        /**当前帧百分比格挡最终概率增加*/
        blkSp_p_f: 225,
        /**架招最终概率*/
        prySp: 226,
        /**常量架招最终概率增加*/
        prySp_s: 227,
        /**百分比架招最终概率增加*/
        prySp_p: 228,
        /**当前帧常量架招最终概率增加*/
        prySp_s_f: 229,
        /**当前帧百分比架招最终概率增加*/
        prySp_p_f: 230,
        /**最终伤害*/
        dmgSp: 231,
        /**常量最终伤害增加*/
        dmgSp_s: 232,
        /**百分比最终伤害增加*/
        dmgSp_p: 233,
        /**当前帧常量最终伤害增加*/
        dmgSp_s_f: 234,
        /**当前帧百分比最终伤害增加*/
        dmgSp_p_f: 235,
        /**物理防御穿透系数值*/
        iPDef: 236,
        /**常量物理防御穿透系数值增加*/
        iPDef_s: 237,
        /**百分比物理防御穿透系数值增加*/
        iPDef_p: 238,
        /**当前帧常量物理防御穿透系数值增加*/
        iPDef_s_f: 239,
        /**当前帧百分比物理防御穿透系数值增加*/
        iPDef_p_f: 240,
        /**魔法防御穿透系数值*/
        iMDef: 241,
        /**常量魔法防御穿透系数值增加*/
        iMDef_s: 242,
        /**百分比魔法防御穿透系数值增加*/
        iMDef_p: 243,
        /**当前帧常量魔法防御穿透系数值增加*/
        iMDef_s_f: 244,
        /**当前帧百分比魔法防御穿透系数值增加*/
        iMDef_p_f: 245,
        /**全攻击力*/
        atkSp: 246,
        /**常量全攻击力增加*/
        atkSp_s: 247,
        /**百分比全攻击力增加*/
        atkSp_p: 248,
        /**当前帧常量全攻击力增加*/
        atkSp_s_f: 249,
        /**当前帧百分比全攻击力增加*/
        atkSp_p_f: 250,
        /**全暴击值*/
        criSp: 251,
        /**常量全暴击值增加*/
        criSp_s: 252,
        /**百分比全暴击值增加*/
        criSp_p: 253,
        /**当前帧常量全暴击值增加*/
        criSp_s_f: 254,
        /**当前帧百分比全暴击值增加*/
        criSp_p_f: 255,
        /**全暴击伤害系数值*/
        criDmgSp: 256,
        /**常量全暴击伤害系数值增加*/
        criDmgSp_s: 257,
        /**百分比全暴击伤害系数值增加*/
        criDmgSp_p: 258,
        /**当前帧常量全暴击伤害系数值增加*/
        criDmgSp_s_f: 259,
        /**当前帧百分比全暴击伤害系数值增加*/
        criDmgSp_p_f: 260,
        /**全防御忽略最终概率*/
        iDefSp: 261,
        /**常量全防御忽略最终概率增加*/
        iDefSp_s: 262,
        /**百分比全防御忽略最终概率增加*/
        iDefSp_p: 263,
        /**当前帧常量全防御忽略最终概率增加*/
        iDefSp_s_f: 264,
        /**当前帧百分比全防御忽略最终概率增加*/
        iDefSp_p_f: 265,
        /**战斗速度*/
        bAgi: 266,
        /**常量战斗速度增加*/
        bAgi_s: 267,
        /**百分比战斗速度增加*/
        bAgi_p: 268,
        /**当前帧常量战斗速度增加*/
        bAgi_s_f: 269,
        /**当前帧百分比战斗速度增加*/
        bAgi_p_f: 270,
        /**当前HP*/
        curHp: 271,
        /**当前AP*/
        curAp: 272,
        /**当前负重*/
        curWgt: 273,
        /**当前武器攻击力*/
        curWAtk: 274,
        /**当前武器命中值*/
        curWHit: 275,
        /**当前武器需求力量*/
        curWeaponNeedStr: 276,
        /**当前盾牌格挡概率系数值*/
        curWBlk: 277,
        /**当前盾牌格挡防御力*/
        curWBlkDef: 278,
        /**当前盾牌需求力量*/
        curShieldNeedStr: 279,
        /**当前剩余移动力*/
        curMov: 280,
        /**当前剩余主动攻击次数*/
        curAtkN: 281,
        /**当前剩余主动移动次数*/
        curMovN: 282,
        /**当前剩余反击次数*/
        curResistN: 283,
        /**当前剩余主动行动次数*/
        curActN: 284,
        /**当前帧常量剩余连击次数增加*/
        curDHitN_s_f: 285,
        /**当前剩余连击次数*/
        curDHitN: 286,
        /**当前帧消耗移动力数量*/
        curMovConsume_s_f: 287,
        /**额外选择范围*/
        selectRange: 288,
        /**常量额外选择范围增加*/
        selectRange_s: 289,
        /**禁止移动开关*/
        forbidMove: 290,
        /**当前帧禁止移动开关*/
        forbidMove_s_f: 291,
        /**禁止攻击开关*/
        forbidAttack: 292,
        /**当前帧禁止攻击开关*/
        forbidAttack_s_f: 293,
        /**禁止行动开关*/
        forbidAction: 294,
        /**当前帧禁止攻击开关*/
        forbidAction_s_f: 295,
        /**禁止命中开关*/
        forbidHit: 296,
        /**当前帧禁止命中开关*/
        forbidHit_s_f: 297,
        /**禁止暴击开关*/
        forbidCri: 298,
        /**当前帧禁止暴击开关*/
        forbidCri_s_f: 299,
        /**禁止格挡开关*/
        forbidBlk: 300,
        /**当前帧禁止格挡开关*/
        forbidBlk_s_f: 301,
        /**禁止招架开关*/
        forbidPry: 302,
        /**当前帧禁止招架开关*/
        forbidPry_s_f: 303,
        /**禁止反击开关*/
        forbidResistAtk: 304,
        /**当前帧禁止反击开关*/
        forbidResistAtk_s_f: 305,
        /**禁止连击开关*/
        forbidDHit: 306,
        /**当前帧禁止连击开关*/
        forbidDHit_s_f: 307,
        /**禁止抢攻开关*/
        forbidGrabRAtk: 308,
        /**当前帧禁止抢攻开关*/
        forbidGrabRAtk_s_f: 309,
        /**豁免死亡开关*/
        exemptDeed: 310,
        /**当前帧豁免死亡开关*/
        exemptDeed_s_f: 311,
        /**必定抢攻开关*/
        ariseGrabRAtk: 312,
        /**当前帧必定抢攻开关*/
        ariseGrabRAtk_s_f: 313,
        /**禁止偏斜开关*/
        forbidDev: 314,
        /**当前帧禁止偏斜开关*/
        forbidDev_s_f: 315,
        /**当前护甲防御力*/
        curArmorDef: 316,
        /**豁免死亡次数*/
        exemptDeedNum: 317,
        /**格挡大师开关*/
        blkMaster: 318,
        /**招架大师开关*/
        pryMaster: 319,
        /**无视防御开关*/
        ignoreDef: 320,
        /**帧无视防御开关*/
        ignoreDef_s_f: 321,
    },
    /** 回合生命周期状态枚举*/
    ERoundStatus: {
        //开始
        Start: 0,
        //结束
        End: 1,
    },
    /**
     * 子代血脉随机类型
     */
    EDescentBuildType: {
        //普通类型
        common: 0,
        //同卵双胞胎
        identical: 1,
        //异卵双胞胎
        fraternal: 2,
        //变异
        variation: 3,
    },
    /**
     * 社会地位
     */
    ESocialStatus: {
        //平民
        civilian: 0,
    },
    /**
     * 女性六维属性成长补正
     */
    EAttrGrow: {
        //力量
        str: -0.1,
        //体质
        vit: -0.1,
        //意志
        wil: -0.1,
        //技巧
        dex: 0.1,
        //感知
        per: 0.1,
        //敏捷
        agi: 0.1,
    },
    /**
     * 属性计算相关常量
     */
    EAttrCorrelationConst: {
        //感知转换魔攻
        perToMAtk: 0.5,
        //力量转换物攻
        strToPAtk: 0.5,
        //技巧转换物理命中
        dexToPHit: 1.0,
        //技巧转换物理暴击
        dexToPCri: 1.0,
        //感知转换魔法暴击
        wilToMCri: 1.0,
        //技巧转换格挡概率
        dexToBlk: 1.0,
        //技巧转换架招概率
        dexToPry: 1.0,
        //真实敏捷转换物理暴击抵扣系数
        bAgiToPDCri: 1.0,
        //真实敏捷转换物防忽略概率（用于物防忽略技能的计算判断，使用双方真实敏捷差计算）
        agiToIgnoreDef: 1.0,
        //意志转换魔法命中
        wilToMHit: 1.0,
        //意志转换魔法暴击抵扣系数
        wilToMDCri: 1.0,
        //体质转换生命值上限
        vitToHp: 0.5,
        //体质转换理想负重上限
        vitToWgt: 350,
        //溢出理论负重上限的负重量转换真实敏捷惩罚
        overWgtToAgi: 250,
        //实际负重量转换真实敏捷惩罚
        agiToWgt: 1000,
        //武器攻击力转换招架防御值
        wAtkToPryDef: 0.5,
        //感知转换受到的额外治疗值
        perToHeal: 0.35,
        //基础物理暴击伤害系数
        pCriDmg: 10000,
        //基础魔法暴击伤害系数
        mCriDmg: 5000,
        //基础物理偏斜减伤系数
        pDevDmg: 5000,
        //基础魔法偏斜减伤系数
        mDevDmg: 5000,
        //最高物理偏斜减伤系数
        maxPDevDmg: 9000,
        //基础负重量
        baseWgt: 100,
        //基础AP上限
        baseAp: 3,
        //基础移动次数
        baseMovN: 1,
        //基础攻击次数
        baseAtkN: 1,
        //基础行动次数
        baseActN: 1,
    },
    /**装备槽位使用类型*/
    EquipmentSlotType: {
        /**主手武器 */
        master: 1,
        /**副手武器 */
        assistant: 2,
        /**头部护具 */
        head: 3,
        /**身体护具 */
        body: 4,
        /**足部护具 */
        foot: 5,
        /**饰品 */
        ornament: 6,
        /**双手武器 */
        both: 7,
    },
    /**装备类型 */
    EquipmentType: {
        /**单手匕首*/
        DanShouBiShou: 1001,
        /**单手剑*/
        DanShouJian: 1002,
        /**单手斧*/
        DanShouFu: 1003,
        /**单手锤*/
        DanShouChui: 1004,
        /**单手枪*/
        DanShouQiang: 1005,
        /**单手骑枪*/
        DanShouQiQiang: 1006,
        /**单手手弩*/
        DanShouShouNu: 1007,
        /**单手短杖*/
        DanShouDuanZhang: 1008,
        /**单手链锤*/
        DanShouLianChui: 1009,
        /**单手药瓶*/
        DanShouYaoPing: 1010,
        /**刺剑*/
        CiJian: 1011,
        /**副手小盾*/
        FuShouXiaoDun: 2001,
        /**副手中盾*/
        FuShouZhongDun: 2002,
        /**副手大盾*/
        FuShouDaDun: 2003,
        /**布甲头盔*/
        BuJiaTouKui: 3001,
        /**皮甲头盔*/
        PiJiaTouKui: 3002,
        /**锁甲头盔*/
        SuoJiaTouKui: 3003,
        /**板甲头盔*/
        BanJiaTouKui: 3004,
        /**布甲胸甲*/
        BuJiaXiongJia: 4001,
        /**皮甲胸甲*/
        PiJiaXiongJia: 4002,
        /**锁甲胸甲*/
        SuoJiaXiongJia: 4003,
        /**板甲胸甲*/
        BanJiaXiongJia: 4004,
        /**布甲靴子*/
        BuJiaXueZi: 5001,
        /**皮甲靴子*/
        PiJiaXueZi: 5002,
        /**锁甲靴子*/
        SuoJiaXueZi: 5003,
        /**板甲靴子*/
        BanJiaXueZi: 5004,
        /**饰品*/
        ShiPin: 6001,
        /**双手剑*/
        ShuangShouJian: 7001,
        /**双手斧*/
        ShuangShouFu: 7002,
        /**双手锤*/
        ShuangShouChui: 7003,
        /**双手枪*/
        ShuangShouQiang: 7004,
        /**短弓*/
        DuanGong: 7005,
        /**长弓*/
        ChangGong: 7006,
        /**重弩*/
        ZhongNu: 7007,
        /**双手杖*/
        ShuangShouZhang: 7008,
        /**琴*/
        Qin: 7009,
    },
    /**背包道具类型 */
    BagItemType: {
        /**装备, 需要到equipment表获得数据 */
        Equipment: 1,
        /**材料(道具),需要到itembag表获得数据 */
        BagItem: 2,
        /**宝石, 需要到baoshi表获得数据 */
        Gem: 3,
    },
    /**材料道具类型 */
    BagItem: {
        /**银币类型 */
        Silver: 1,
        /**钻石 */
        ZuanShi: 2,
        /**食物 */
        ShiWu: 3,
        /**材料 */
        CaiLiao: 4,
        /**经验 */
        Exp: 5,
        /**军团声望 */
        JunTuanShengWang: 6,
        /**升级材料 */
        UpLevelCaiLiao: 7,
        /**技能提取保存技能信息类型 */
        SkillSaveExtraAttr: 10,
    },
    /**材料道具的具体性质 */
    BagItemAddType: {
        /**增加某项的具体数值,例如货币值，经验值等 */
        AddValue: 1,
        /**增加道具数量 */
        AddItemCount: 2,
    },
    /**背包道具类型对应表名称 */
    BagTypeJsonName: {
        /**装备Equipments.json表名称，获取 BagTypeJsonName[0] == Equipments*/
        Equipments: "Equipments",
        /**材料道具表, ItemBag.json */
        BagItem: "BagItem",
        /**宝石表, Baoshi.json */
        BaoShi: "BaoShi",
    },
    ERoleProperty: {
        hp: 0,
        ap: 1,
    },
    AllControlKey: {
        adult: "adult",         //成年年龄
        bagMax: "bagMax",      //背包最大格子数
        bagMaxSp: "bagMaxSP",  //背包最大叠加数
        silverCoinMax: "silverCoinMax",    //玩家银币显示上限
        diamondMax: "diamondMax",  //玩家钻石显示上限
        minValue: "minValue",  //强化单次最小值
        teamSize: "teamSize",  //队伍人数上限
        starTime: "starTime",  //游戏开始时间
        chunLin: "chunLin",    //春临节
        yongshi: "yongshi",    //勇士节
        wangRen: "wangRen",    //亡人节
        mvp: "mvp",            //战斗mvp经验系数
        //感知转换魔攻
        perToMAtk: "perToMAtk",
        //力量转换物攻
        strToPAtk: "strToPAtk",
        //技巧转换物理命中
        dexToPHit: "dexToPHit",
        //技巧转换物理暴击
        dexToPCri: "dexToPCri",
        //感知转换魔法暴击
        wilToMCri: "wilToMCri",
        //技巧转换格挡概率
        dexToBlk: "dexToBlk",
        //技巧转换架招概率
        dexToPry: "dexToPry",
        //真实敏捷转换物理暴击抵扣系数
        bAgiToPDCri: "bAgiToPDCri",
        //真实敏捷转换物防忽略概率（用于物防忽略技能的计算判断，使用双方真实敏捷差计算）
        agiToIgnoreDef: "agiToIgnoreDef",
        //意志转换魔法命中
        wilToMHit: "wilToMHit",
        //意志转换魔法暴击抵扣系数
        wilToMDCri: "wilToMDCri",
        //体质转换生命值上限
        vitToHp: "vitToHp",
        //体质转换理想负重上限
        vitToWgt: "vitToWgt",
        //溢出理论负重上限的负重量转换真实敏捷惩罚
        overWgtToAgi: "overWgtToAgi",
        //实际负重量转换真实敏捷惩罚
        agiToWgt: "agiToWgt",
        //武器攻击力转换招架防御值
        wAtkToPryDef: "wAtkToPryDef",
        //感知转换受到的额外治疗值
        perToHeal: "perToHeal",
        //基础物理暴击伤害系数
        pCriDmg: "pCriDmg",
        //基础魔法暴击伤害系数
        mCriDmg: "mCriDmg",
        //基础物理偏斜减伤系数
        pDevDmg: "pDevDmg",
        //基础魔法偏斜减伤系数
        mDevDmg: "mDevDmg",
        //最高物理偏斜减伤系数
        maxPDevDmg: "maxPDevDmg",
        //基础负重量
        baseWgt: "baseWgt",
        //基础AP上限
        baseAp: "baseAp",
        //基础移动次数
        baseMovN: "baseMovN",
        //基础攻击次数
        baseAtkN: "baseAtkN",
        //基础行动次数
        baseActN: "baseActN",
        //附魔基础刷新价格
        enchantingBasePirce: "enchantingBasePirce",
        //消除确定附魔cd时间的基础价格
        basicCoolPirce: "basicCoolPirce",
        //附魔免费刷新间隔-小时
        nextFreeRefresh: "nextFreeRefresh",
        //重置确定附魔道具（取消确定附魔cd时间道具）
        resetProp: "resetProp",
        //商会物资刷新月份
        goodsRefreshTime: "goodsRefreshTime",
        //商会任务刷新月份
        runBusinessRefresh: "runBusinessRefresh",
        //装备出售价格计算 装备品质系数
        equipQualityCoefficient: "equipQualityCoefficient",
        //装备出售价格计算 装备附加技能数量系数
        skillCoefficient: "skillCoefficient",
    },
    EBattleRoundStatus: {
        all: 1,     //所有
        isMy: 2,    //我方
        notMy: 3,   //敌方
    },
    /**货币类型 */
    MoneyType: {
        /**0未知 */
        None: 0,
        /**1银币 */
        Silver: 1,
        /**2钻石 */
        ZuanShi: 2,
    },
    EBattleSceneCycleStatus: {
        ready: 0,          //玩家准备
        start: 1,          //战斗场景正式开始
        roundBegin: 2,     //战斗回合开始时点
        roundActive: 3,    //战斗回合操作循环
        roundEnd: 4,       //战斗回合结束时点
        battleEnd: 5,      //战斗场景结束
        result: 6,         //结算数据
        destroy: 7,        //场景销毁，清除本线程上所有本场景相关数据
    },
    EBattleActorStatus: {
        //未进入逻辑地图
        remove: 1,
        //已进入逻辑地图
        enter: 2,
        //逻辑地图上死亡
        dead: 3,
        //逻辑地图上撤离
        escape: 4,
        //忽视地形惩罚
        ignoreTileCost: 12,
        //忽视角色阻碍
        ignoreActorObstruct: 13,
        //惊惧(禁止反击)
        fright: 15,
        //恐惧(禁止行动)
        fear: 16,
        //缠绕(禁止移动)
        twine: 17,
        //豁免惊惧
        ignoreFright: 18,
        //豁免恐惧
        ignoreFear: 19,
        //禁止当前HP增加
        forbidCurHpAdd: 20,
    },
    EMoveCycleStatus: {
        enter: 1,   //进入格子
        leave: 2,   //离开格子
    },
    EAtkCycleStatus: {
        //选择主目标时
        selectMainTarget: 1,
        //使用技能前时
        beforeUseSkill: 2,
        //AP消耗计算时
        apConsumeCount: 3,
        //AP消耗结算时
        apConsumeSettle: 4,
        //进行伤害计算流程
        runDmgCount: 5,
        //偏斜结算时
        hitSettle: 6,
        //暴击结算时
        criSettle: 7,
        //防御完全穿透结算时
        ignoreDefSettle: 8,
        //格挡结算时
        blkSettle: 9,
        //招架结算时
        prySettle: 10,
        //伤害值计算开始时
        dmgCountBegin: 11,
        //伤害值计算结束时
        dmgCountEnd: 12,
        //受到攻击伤害前时
        onDmgBefore: 13,
        //致死性结算时
        killSettle: 14,
        //伤害结算时
        onDmgSettle: 15,
        //击杀结算时
        deedSettle: 16,
        //使用技能后时
        afterUseSkill: 17,
        //攻击结束时
        atkEnd: 18,
    },
    /** 技能伤害类型 */
    ESkillDamageType: {
        /** 未知 */
        None: 0,
        /** 物理伤害 */
        WuLi: 1,
        /** 法术伤害 */
        FaShu: 2,
        /** 斩击 */
        ZhanJi: 3,
        /** 突刺 */
        TuCi: 4,
        /** 钝击 */
        DunJi: 5,
        /** 近战 */
        JinZhan: 6,
        /** 远程 */
        YuanCheng: 7,
        /** 治疗*/
        ZhiLiao: 8,
        /** 辅助*/
        FuZhu: 9,

    },
    EEffectConditionType: {
        //处于战斗场景[EBattleSceneCycleStatus]阶段时
        battleSceneCycleStatus: 1,
        //战场回合类型为[EBattleRoundStatus]时
        battleRoundStatus: 2,
        //移动时点[EMoveCycleStatus]时
        moveCycleStatus: 3,
        //攻击时点[EAtkCycleStatus]时
        atkCycleStatus: 4,
        //装备槽[EquipmentSlotType]穿戴装备时
        equipSlotWear: 5,
        //装备槽[EquipmentSlotType]未穿戴装备时
        equipSlotNotWear: 6,
        //穿戴ID为[手填数值]的装备时
        wearTargetEquip: 7,
        //使用的技能伤害类型为[ESkillDamageType]时
        useSkillDamageType: 8,
        //受到的技能伤害类型为[ESkillDamageType]时
        acceptSkillDamageType: 9,
        //战斗场景中首次主动攻击时
        firstAtkAction: 10,
        //受到攻击伤害前时
        onDmgBefore: 11,
        //主动攻击宣言时
        atkActionDeclare: 12,
        //主动攻击时
        initiativeAtkAction: 13,
        //击杀攻击目标时
        killAtkTarget: 14,
        //消耗的AP值大于[手填数值]时
        consumeAp: 15,
        //主动攻击命中时
        initiativeAtkHit: 16,
        //偏斜判定结算为[EYesAndNo]时
        devSettle: 17,
        //暴击判定结算为[EYesAndNo]时
        criSettle: 18,
        //格挡判定结算为[EYesAndNo]时
        blkSettle: 19,
        //架招判定结算为[EYesAndNo]时
        prySettle: 20,
        //[EActorAttrType]属性高于受攻击目标时
        attrFiner: 21,
        //自身周围[手填数值]格范围内[ETeamType]阵营角色受到攻击伤害前检测
        areaOnDmgBeforeCheck: 22,
        //ID为[手填数值]的buff持续时间结束时
        buffStop: 23,
        //消耗的当前移动力大于[手填数值]时
        consumeCurMov: 24,
        //职业为[EMonsterOccuType]时
        jobCheck: 25,
        //装备槽[EquipmentSlotType]穿戴装备为[EquipmentType]时
        equipSlotWearEquipType: 26,
        //0~10000随机取值数小于[手填数值]时
        randomCheck: 27,
        //0~10000随机取值数小于[EActorAttrType]属性经过当前等级rate表换算值时
        randomCheckByAttr: 28,
        //受到致死性伤害时
        dmgCanKill: 29,
        //同阵营角色移动进入自身周围[手填数值]格范围内
        areaIdenticalCampMoveEnterCheck: 30,
        //处于[ESlotType]类型的格子中时
        onTileType: 31,
        //反击时
        isResistAtk: 32,
        //异阵营角色移动进入自身周围[手填数值]格范围内
        areaDifferentCampMoveEnterCheck: 33,
        //被动进入战斗时
        passiveAtkAction: 34,
        //ap值大等于于[手填数值]时
        curApNum: 35,
        //当前生命值低于生命值上限的百分之[手填数值]时
        curHpParLimit: 36,
        //目标职业为[EMonsterOccuType]时
        targetOccu: 37,
        //[EActorAttrType]属性小于[手填数值]时
        attrMinLimit: 38,
        //任意装备槽穿戴护甲类型为[EArmorType]时
        armorTypeCheck: 39,
        //自身周围[手填数值]格范围内[ETeamType]阵营角色进行伤害计算前检测检测
        areaRunDmgCountBeforeCheck: 40,
        //目标当前伤害计算过程中攻击者[EActorAttrType]属性小于自身时
        targetDmgContextAttackerAttrComparisonCheck: 41,
        //伤害过程中受攻击目标[EActorAttrType]属性小于自身时
        targetAttrComparisonCheck: 42,
        //受击方抢攻时
        mainReceiverGrabRAtk: 43,
    },
    EEffectResult: {
        //[EActorAttrType]属性增加[手填数值]
        addQuotaAttr: 1,
        //[EActorAttrType]属性增加[EActorAttrType]属性的百分之[手填数值]
        addAttrByOtherAttrPer: 2,
        //[EActorAttrType]属性自身与目标的[EActorAttrType]属性差值的百分之[手填数值]
        addAttrByContrastAttrDiffPer: 3,
        //增加[EBattleActorStatus]状态
        addBattleActorStatus: 4,
        //新增持续[手填数值]回合，MID为[手填数值]的Buff
        addBuff: 5,
        //将目标向攻击来源的反方向击退[手填数值]格，在击退过程中存在阻碍则停止
        repelTarget: 6,
        //[EActorAttrType]属性增加攻击伤害的百分之[手填数值]
        addAttrByDmgNum: 7,
        //移动到攻击目标方向的身后[手填数值]格，在攻击目标身后移动过程中存在阻碍则停止
        penetrateTarget: 8,
        //造成最终伤害为[手填数值],攻击类型为[手填数值]的伤害
        fixedFinalDamage: 9,
        //造成基础攻击力为[手填数值],攻击类型为[手填数值]的伤害
        fixedBaseDamage: 10,
        //造成攻击类型为[手填数值]，基础攻击力依照伤害类型，取物攻数值或魔攻数值的伤害
        commonDamage: 11,
        //恢复最终治疗值为[手填数值]的血量
        fixedFinalCure: 12,
        //恢复基础治疗值为[手填数值]的血量
        fixedBaseCure: 13,
        //恢复基础治疗值为魔攻数值的血量
        commonCure: 14,
        //修改角色主动攻击技能，MID为[手填数值]
        changeAtkSkill: 15,
        //修改角色反击攻击技能，MID为[手填数值]
        changeResistSkill: 16,
        //[手填数值]距离格每有一名[EEffectTarget]方角色,[EActorAttrType]属性增加[手填数值]
        basedTargetNumAddAttr: 17,
        //[EActorAttrType]属性增加自身与目标的曼哈顿距离的百分之[手填数值]
        addAttrByManhattanDistancePer: 18,
        //与目标交互站立位置
        exchangeTile: 19,
        //替换受攻击对象
        replaceBeAttacker: 20,
        //伤害计算时的受击方防御计算结果减少受击方当前护甲防御力数值
        dmgContextDefNumDetachCurArmorDef: 21,
    },
    /** 效果目标类型*/
    EEffectTarget: {
        //全体
        all: 1,
        //我方
        identity: 2,
        //我方及友方
        friend: 3,
        //非我方
        different: 4,
        //非我方及友方
        notFriend: 5,
        //自己
        self: 6,
    },
    /** 技能类型枚举*/
    ESkillGroupType: {
        //主动技能
        initiative: 1,
        //被动技能
        passive: 2,
        //固定增益技能
        fixedSkill: 3,
        //条件触发技能
        condition: 4,
        //buff技能
        buff: 5,
        //多重复合技能
        complex: 6,
    },
    /** 主动攻击技能类型*/
    EInitiativeAtkType: {
        passive: 0,
        initiativeAtk: 1,
        resistAtk: 2,
        allAtk: 3,
    },
    /** 是否展示*/
    EisShow: {
        no: 0,
        yes: 1,
    },
    /** 是和否*/
    EYesAndNo: {
        no: 0,
        yes: 1,
    },
    /**职业组*/
    EJobGroup: {
        //布甲
        cloth: 1,
        //皮甲
        leather: 2,
        //链甲
        chain: 3,
        //板甲
        plate: 4,
        //近战
        melee: 5,
        //远程
        remote: 6,
        //轻步兵
        lightInfantry: 7,
        //骑兵
        cavalry: 8,
        //弓兵
        archer: 9,
        //重步兵
        heavyInfantry: 10,
        //特殊职业
        special: 11,
        //全职业
        all: 12,
    },
    /**增加值类型道具ID定义 */
    BagItemID: {
        /**银币 */
        Silver: 2000200,
        /**经验 */
        Exp: 2000270,
        /**钻石 */
        ZuanShi: 2000300,
        /**军团声望*/
        corpsPrestige: 2000280

    },
    /**装备镶嵌宝石的槽位颜色类型 */
    EquipGemSlotColorType: {
        /**红色 */
        Hong: 1,
        /**橙色 */
        Cheng: 2,
        /**绿色 */
        Lv: 3,
        /**蓝色 */
        Lan: 4,
        /**紫色 */
        Zi: 5,
        /** 黄色 */
        Huang: 6,
        /** 彩色*/
        Cai: 7,
    },
    
    /**装备洗练品质对应数据列名称 */
    EquipRefinementType: {
        /** 白色品质 */
        whiteConsume: 1,
        /** 绿色品质 */
        greenConsume: 2,
        /** 蓝色品质 */
        blueConsume: 3,
        /** 紫色品质 */
        violetConsume: 4,
        /** 橙色品质 */
        orangeConsume: 5,
        /** 红色品质 */
        redConsume: 6
    },
    //召唤方式
    ECallType: {
        //指定格子
        Slot: 0,
        //自身周边
        SelfAround: 1,
        //随机
        Random: 2,
    },
    //条件关系
    ERelation: {
        And: 0, //与
        Or: 1 //或
    },
    //触发器结果属性集
    ETriggerResultAttrs: {
        //撤离格子索引,撤离部队
        AddRunSlotEventResultConfig: "SlotIndex,Team",
        //召唤角色ID，召唤方式，格子索引，召唤的友方角色，召唤的敌方角色
        CallEventResultConfig: "CallRoleId,CallType,SlotIndex,ActorId,MonsterId",
        //角色ID,到焦点状态的时间，相机焦点位置,相机焦点旋转角,相机焦点尺寸
        CameraFocusEventResultConfig: "RoleID,Move2FocusTime,EndPosition,EndRotation,EndCameraSize",
        //相机终点位置,相机终点旋转角,相机终点尺寸,相机移动时长
        CameraMoveEventResultConfig: "EndPosition,EndRotation,EndCameraSize,MoveTime",
        //相机位置,相机旋转角,相机尺寸
        CameraPlaceEventResultConfig: "CameraPosition,CameraRotation,CameraSize",
        //角色ID,AIID
        ChangeAIEventResultConfig: "RoleId,AIId",
        //更改BGM的Id
        ChangeBGMEventResultConfig: "BGMId",
        //元件ID,格子索引
        ChangeSlotElementEventResultConfig: "ElementId，SlotIndex",
        //角色ID,变更阵营类型
        ChangeTeamEventResultConfig: "RoleId,Team",
        //变更胜利条件ID
        ChangeWinEventResultConfig: "WinId",
        //删除角色ID
        DeleteRoleEventResultConfig: "RoleId",
        //角色死亡Id
        RoleDeathEventResultConfig: "RoleId",
        //离场角色ID,离场格子索引
        RoleLeaveEventResultConfig: "RoleId,LevelSlotIndex",
        //移动角色ID，终点格子索引,目标角色ID，角色和目标角色之间的间隔格子数,移动时间
        RoleMoveEventResultConfig: "RoleId,SlotIndex,TargetId,RolesSlotInterval,MoveTime",
        //来源角色Id,目标角色Id,攻击技能Id
        SkillEventResultConfig: "FromId,ToId,SkillId",
        //状态类型
        StatusResultConfig: "StatusType",
        //文字表ID，文字事件类型
        TextEventResultConfig: "StringId,TextType",
    },
    //触发器条件属性集
    ETriggerConditionAttrs: {
        //条件关系,条件列表
        ConditionGroupConfig: "Relation,mConditionList",
        //战斗状态
        FightScenetStatusConditionConfig: "FightStatus",
        //坚持多少回合
        KeepRoundConditionConfig: "roundNumber",
        //角色id,格子索引
        RoleArriveEventConditionConfig: "RoleId,SlotIndex",
        //角色ID，角色属性类型，角色限制值
        RoleInfoEventConditionConfig: "RoleId,Property,Limit",
        //角色唯一码
        RoleNoDeathConditionConfig: "RoleGid",
        //角色唯一码
        RoleNoRunConditionConfig: "roleGid",
        //撤离角色
        RoleRunConditionConfig: "roleGid",
        //回合数，阵营，回合状态
        RoundEventConditionConfig: "RoundNumber,Team,RoundStatus",
        //阵营,格子索引
        RunConditionConfig: "Team,SlotIndex",
        //当前场景,下一场景
        SceneChangeEventConditionConfig: "CurScene,NextScene",
        //状态类型,格子索引,ID号
        StatusConditionConfig: "StatusType,SlotIndex,StatusId",
        //死亡部队
        TeamDeathConditionConfig: "deathTeam",
        //不死亡部队
        TeamNoDeathConditionConfig: "team",
        //不撤离部队
        TeamNoRunConditionConfig: "runTeam",
        //撤离部队
        TeamRunConditionConfig: "runTeam",
        //职业击杀角色
        JobKillRoleConditionConfig: "RoleId,JobId",
    },
    //战斗状态
    EFightStatus: {
        Start: 0,
        End: 1,
    },

    //邮件状态
    MailState: {
        /** 未读 */ 
        unread: 0,
        /** 已读未领取 */       
        unreceived: 1,
        /** 可删除 */  
        delete: 3,
    },
    //护甲枚举类型
    EArmorType: {
        /**布甲*/
        cloth: 1,
        /**皮甲*/
        Leather: 2,
        /**锁甲*/
        chain: 3,
        /**板甲*/
        plate: 4,
    },
    //行为树节点状态
    EBehaviorTreeNodeState: {
        //失败
        failure: 0,
        //初始状态
        invalid: 1,
        //成功
        success: 2,
        //运行
        running: 3,
        //终止
        aborted: 4,
    },
    //行为树强制改变更新结果可选类型
    EBehaviorTreeResChangeType: {
        //失败
        failure: 0,
        //成功
        success: 1,
        //取反
        negation: 2,
    },
    //行为树节点类型
    EBehaviorTreeNodeType: {
        //重复执行子节点指定次数的装饰器
        RepeatNum: 1,
        //重复执行子节点直到子节点的状态为指定状态的装饰器
        RepeatToState: 2,
        //更改子节点执行结果的装饰器
        ChangeRes: 3,
        //子节点顺序执行模式节点，顺序执行每个子节点，直到某个子节点执行后状态不为成功时，以子节点状态作为该结点的状态更新结果，顺序执行所有子节点后仍未出现失败状态，状态更新返回成功
        Sequence: 4,
        //子节点顺序选择模式节点，顺序执行每个子节点，直到某个子节点执行后状态不为失败时，以子节点状态作为该结点的状态更新结果，顺序执行所有子节点后仍未出现成功状态，状态更新返回失败
        OrderSelector: 5,
        //子节点策略执行模式节点，顺序执行每个子节点，记录每个子节点的状态更新结果，之后根据参数配置的成功策略，返回该结点的状态更新结果
        Parallel: 6,
        //子节点优先选择模式节点，在该节点旧状态为running时，记录当前状态为running的子节点，依据OrderSelector模式重选节点，在重选节点与旧节点不同时，终止旧节点行为，该节点旧状态非running时，等价于OrderSelector节点
        ActiveSelector: 7,
        //指定配置ID的行为树子树
        SubTree: 8,
        //逻辑行为节点，根据需求的逻辑类型，执行指定AI逻辑，该类节点不应当存在子节点
        Action: 9,
        //向攻击目标位置使用技能
        runAtkAction: 10,
        //向移动目标位置移动
        runMoveAction: 11,
        //替换攻击发起位置集合为在攻击目标位置应用自身当前技能选择范围得到的位置集合，与自身可移动范围位置集合的交集，并重置攻击发起位置检索序，交集为空集时返回失败
        changeCanAtkTileByAtkTargetTile: 12,
        //将攻击发起位置集合按每个位置周边敌人数量，从小到大进行排序，并重置可攻击位置检索序
        sortCanAtkInMinEnemyNum: 13,
        //根据攻击发起位置检索序从攻击发起位置集合中获取一个攻击发起位置设为移动目标位置，之后可攻击发起位置检索序增加，如果取值时检索序超过集合大小，返回终止
        getNextAtkTile: 14,
        //获取计算生物阻挡时当前位置到移动目标位置的最短路径，并设为预计算路径
        getMovePathInCountEntity: 15,
        //获取忽略生物阻挡时当前位置到移动目标位置的最短路径，并设为预计算路径
        getMovePathInNotCountEntity: 16,
        //判断当前移动力是否满足预计算路径需求
        checkMovContrastPathCostIsGT: 17,
        //敌人集合替换为行为树预设目标ID对应的敌人集合，并重置敌人检索序
        changeEntityListByTreeParamEntityIdList: 18,
        //替换可攻击位置集合为当前位置应用当前技能选择范围得到的位置集合
        changeCanAtkTileBySkill: 19,
        //敌人集合替换为全图敌人，并重置敌人检索序
        changeEntityListBySceneEntityList: 20,
        //敌人集合中筛选保留符合[敌人血量 =< 自身主动攻击技能基础伤害 - 敌人防御]的敌人，并重置敌人检索序
        filterEntityListInCanKill: 21,
        //将敌人集合按敌人血量，从小到大进行排序，并重置敌人检索序
        sortEntityListInMinEnemyHp: 22,
        //将敌人集合按敌人血量，从大到小进行排序，并重置敌人检索序
        sortEntityListInMaxEnemyHp: 23,
        //根据检索序从敌人集合中获取一个敌人位置设为攻击目标位置，之后检索序增加，如果取值时检索序超过集合大小，返回终止
        getNextAtkTargetTile: 24,
        //判断敌人集合的排序结果的首位的排序依据值是否在集合中唯一
        checkEntityListIsOneOnlyTop: 25,
        //将敌人集合按敌人与自身的曼哈顿距离，从小到大进行排序，并重置敌人检索序
        sortEntityListInMinEnemyDis: 26,
        //将敌人集合按敌人与自身的曼哈顿距离，从大到小进行排序，并重置敌人检索序
        sortEntityListInMaxEnemyDis: 27,
        //将敌人集合按敌人等级，从小到大进行排序，并重置敌人检索序
        sortEntityListInMinEnemyLv: 28,
        //将敌人集合按敌人等级，从大到小进行排序，并重置敌人检索序
        sortEntityListInMaxEnemyLv: 29,
        //检索当前攻击范围内是否包含攻击目标位置
        checkCanAtkTileListHasAtkTargetTile: 30,
        //检索移动范围内可以对攻击目标位置进行攻击的攻击位置作为移动目标位置，并得到对应预设路径
        getMovePathAndMoveTargetTileByAtkTargetTile: 31,
        //根据预设路径进行移动，直至碰到障碍或移动力消耗完毕为止
        runMoveActionInSearchPath: 32,
        //将敌人集合按当前主动技能攻击类型对应的防御力，从小到大进行排序，并重置敌人检索序
        sortEntityListInMinEnemyDef: 33,
        //设置攻击位置为移动目标位置
        setMoveTargetTileByAtkTargetTile: 34,
        //检索预设路径上距离最近的敌人位置作为攻击位置
        getAtkTargetTileOnSearchPath: 35,
        //敌人集合替换为当前移动范围+攻击范围内的所有敌人，并重置敌人检索序
        changeEntityListByMovAndAtkRange: 36,
        //根据自身可移动范围选取该范围中的所有敌人，使用敌人的位置加自身位置的集合构造一个凸包，判断自身位置是否不属于凸包的顶点集合
        checkBeSurrounded: 37,
        //判断当前回合数
        checkBattleRoundNum: 38,
        //将撤离目标位置设置为移动目标位置
        setMoveTargetTileByEscapeTargetTile: 39,
        //判断自身当前生命值是否低于生命值上限的百分比
        checkCurHpByHpPer: 40,
        //判断自身职业类型是否属于[jobList: string 职业集合，逗号分隔]
        checkCurJob: 41,
        //替换攻击发起位置集合为在攻击目标位置应用自身当前技能选择范围计算箭楼加成得到的位置集合，与自身可移动范围位置集合的交集，并重置攻击发起位置检索序，交集为空集时返回失败
        changeCanAtkTileByAtkTargetTileAddArrowTowerBuff: 42,
        //判断攻击目标位置是否在可攻击位置列表中
        checkAtkTargetTileBeCanAtkTile: 43,
        //将攻击发起位置集合按每个位置与自身的距离，从小到大排序，并重置可攻击位置检索序
        sortCanAtkTileInMinDis: 44,
        //将攻击发起位置集合按每个位置与自身的距离，从大到小排序，并重置可攻击位置检索序
        sortCanAtkTileInMaxDis: 45,
        //攻击发起位置集合中筛选保留符合位置类型属于[tileTypeList: string 位置类型集合，逗号分隔]的位置，并重置检索序
        changeCanAtkTileByTileType: 46,
        //判断移动目标点位到防御点的距离是否小等于[dis: int 距离数]
        checkMoveTargetTileBeNearbyGuardTarget: 47,
        //判断自身当前点位到防御点的距离是否小等于[dis: int 距离数]
        checkCurTileBeNearbyGuardTarget: 48,
        //敌人集合替换为我方全体，并重置敌人检索序
        changeEntityListByScenePlayerActorList: 49,
        //敌人集合替换为当前移动范围+攻击范围内的所有我方/友方，并重置敌人检索序
        changeEntityListBeFriendAndInMovAndAtkRange: 50,
        //敌人集合替换为当前移动范围+攻击范围内的所有非我方/非友方，并重置敌人检索序
        changeEntityListBeNoFriendAndInMovAndAtkRange: 51,
        //判断我方角色是否全部都满血
        checkAllPlayerActorIsMaxHp: 52,
        //判断当前主动攻击技能AP消耗是否大等于[consumeNum: int 消耗数量]
        checkCurAtkSkillIsConsumeAp: 53,
        //判断当前主动攻击技能的首要效果目标类型是否属于[effectTargetTypeList: string 效果目标类型集合，逗号分隔]
        checkCurAtkSkillEffectTargetType: 54,
        //将敌人集合按敌人到防御点的距离，从小到大进行排序，并重置敌人检索序
        sortEntityListInGuardTargetDis: 55,
        //检索距离防御点最近的可用位置作为移动目标位置
        changeMoveTargetTileByNearbyGuardTarget: 56,
        //将自身位置设为攻击目标位置
        changeAtkTargetTileBySelfTile: 57,
        //将敌人集合按敌人的物理攻击力或魔法攻击力中的较高值，从小到大进行排序，并重置敌人检索序
        sortEntityListInMinPAtkOrMAtk: 58,
        //将敌人集合按敌人的物理攻击力或魔法攻击力中的较高值，从大到小进行排序，并重置敌人检索序
        sortEntityListInMaxPAtkOrMAtk: 59,
        //判断我方角色是否有血量低于[perNum: int 万分比]的角色
        checkAllPlayerActorCurHpPer: 60,
        //判断攻击目标位置是否在当前敌人集合中
        checkAtkTargetTileBeEntityList: 61,
        //检索预设路径上可移动到的最远位置设置为移动目标位置
        setMoveTargetTileByFarthestSearchPath: 62,
        //敌人集合替换为当前移动目标位置上计算当前技能选择范围内的敌人，并重置检索序
        changeEntityListByMoveTargetTileUseSkill: 63,
        //判断是否配置行为树预设守卫目标
        checkTreeGuardTarget: 64,
        //将撤离点集合替换为全图撤离点，并重置撤离点检索序
        changeEscapeListByScene: 65,
        //将撤离点集合根据距离进行从小到大排序，并重置撤离点检索序
        sortEscapeListByMinDis: 66,
        //根据检索序从撤离点集合中获取一个位置设为撤离目标位置，之后检索序增加，如果取值时检索序超过集合大小，返回终止
        getNextEscapeTargetTile: 67,
    },
    /**邮件附件类型 */
    MailAppendType: {
        /**奖励组 */
        RewardGroup: 1,
        /**背包物品 */
        BagItem: 2,
        /**装备 */
        Eqiutments: 3,
        /**英雄 */
        Heroes:4,
    },
    /**地形通行规则类型*/
    EPassType: {
        /**全职业通行*/
        AllPass: 1,
        /**不可通行*/
        NoPass: 2,
        /**部分职业通行*/
        PartPass: 3,
    },
    /** 角色基础六维id */
    AcotrBaseSixAttrs:[1,6,11,16,21,26],
    /**任务类型*/
    ETaskType: {
        /**主线*/
        main: 1,
        /**支线*/
        branch: 2,
        /**场景事件*/
        battleSceneEvent: 3,
    },
    ECastleArchitectureType: {
        QiSheng: 1,
        YanHui: 2,
        ZhuZhan: 3,
        YingShang: 4,
        YuYing: 5,
    }
};