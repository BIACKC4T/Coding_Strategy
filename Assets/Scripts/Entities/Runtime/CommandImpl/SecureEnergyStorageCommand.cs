#nullable enable


namespace CodingStrategy.Entities.Runtime.CommandImpl
{
    using System.Collections.Generic;
    using CodingStrategy.Entities.Robot;
    using Statement;

    public class SecureEnergyStorageCommand : AbstractCommand
    {
        private readonly IList<Coordinate> _coordinates=new List<Coordinate>();

        public SecureEnergyStorageCommand(string id="19", string name="에너지 스토리지 확보", int enhancedLevel=1, int grade=2,
        string explanation="사용시 모든 에너지를 소모합니다. 소모된 에너지가 1 이상인 경우 최대 에너지 량을 1칸 늘립니다.")
        : base(id, name, enhancedLevel, grade, 0, explanation)
        {
        }

        public override ICommand Copy(bool keepStatus = true)
        {
            if(!keepStatus)
            {
                return new SecureEnergyStorageCommand();
            }
            return new SecureEnergyStorageCommand(Id, Info.Name, Info.EnhancedLevel, Info.Grade);
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
            _commandBuilder.Append(new AddMaxEnergyStatement(robotDelegate, Info.EnhancedLevel));
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