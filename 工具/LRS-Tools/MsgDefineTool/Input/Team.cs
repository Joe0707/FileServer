namespace Msg {
    //战斗场景内角色数据，战斗时角色会传的模块数量和常规场景的模块数量可能不一样，这边就没直接套用ActorAgent
    public class Team {
        public int campType = 0;                        //阵营类型
        public ActorInfo actorInfo = new ActorInfo();   //角色信息
        public AttrInfo attrInfo = new AttrInfo();      //属性信息
        public BattleStateAttrInfo stateInfo = new BattleStateAttrInfo();   //状态属性
        public Part partInfo = new Part();              //外观部件信息，怪物可能没这部分数据，会给null
        public BattleTile tileInfo = new BattleTile();  //战斗时角色所在的格子位置信息
        public ActorModuleEquip equip = new ActorModuleEquip(); //角色装备模块信息
        public ActorModuleSkill skill = new ActorModuleSkill(); //角色技能模块信息
    }
}