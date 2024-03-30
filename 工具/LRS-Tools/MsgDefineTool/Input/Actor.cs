namespace Msg {
    public class Actor {
        public ActorInfo actorInfo = new ActorInfo();   //角色信息
        public AttrInfo attrInfo = new AttrInfo();      //属性信息
        public Part partInfo = new Part();              //外观部件信息，怪物可能没这部分数据，会给null
        public BloodInfo blood = new BloodInfo();       //角色血脉信息
        public ActorModuleEquip equip = new ActorModuleEquip(); //角色装备模块信息
        public ActorModuleSkill skill = new ActorModuleSkill(); //角色技能模块信息
    }
}