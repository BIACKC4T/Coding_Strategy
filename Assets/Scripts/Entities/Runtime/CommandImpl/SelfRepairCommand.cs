#nullable enable


namespace CodingStrategy.Entities.Runtime.CommandImpl
{
    using Robot;
    using Abnormality;
    using Statement;

    public class SelfRepairCommand : AbstractCommand
    {

        public SelfRepairCommand(string id="22", string name="자가 수리", int enhancedLevel=1, int grade=3,
        string explanation="사용시 사용한 로봇의 체력이 2 이하일 경우, 체력을 1 회복합니다. 에너지를 2 소모합니다.")
        : base(id, name, enhancedLevel, grade, 2, explanation)
        {
        }

        public override ICommand Copy(bool keepStatus = true)
        {
            if(!keepStatus)
            {
                return new SelfRepairCommand();
            }
            return new SelfRepairCommand(Id, Info.Name, Info.EnhancedLevel, Info.Grade);
        }

        public override bool Invoke(params object[] args)
        {
            throw new System.NotImplementedException();
        }

        public override bool Revoke(params object[] args)
        {
            throw new System.NotImplementedException();
        }

        protected override void AddStatementOnLevel1(IRobotDelegate robotDelegate)
        {
            _commandBuilder.Append(new AddHealthPointStatement(robotDelegate, Info.EnhancedLevel, 2));
        }

        protected override void AddStatementOnLevel2(IRobotDelegate robotDelegate)
        {
            return;
        }

        protected override void AddStatementOnLevel3(IRobotDelegate robotDelegate)
        {
            return;
        }
    }
}