#nullable enable


namespace CodingStrategy.Entities.Runtime.CommandImpl
{
    using System.Collections.Generic;
    using CodingStrategy.Entities.BadSector;
    using CodingStrategy.Entities.Board;
    using Robot;
    using Statement;

    public class InstallJumpBadSectorCommand : AbstractCommand
    {
        public static int installNum=0;
        private readonly List<Coordinate> _coordinates=new();

        public InstallJumpBadSectorCommand(string id="13", string name="점프대 설치", int enhancedLevel=1, int grade=1,
        string explanation="사용시 공격 범위에 해당하는 칸에 로봇이 바라보는 방향으로 로봇이 이동하게 만드는 배드섹터를 설치합니다.에너지를 1 소모합니다.")
        : base(id, name, enhancedLevel, grade, 1, explanation)
        {
        }

        public override ICommand Copy(bool keepStatus = true)
        {
            if(!keepStatus)
            {
                return new InstallJumpBadSectorCommand();
            }
            return new InstallJumpBadSectorCommand(Id, Info.Name, Info.EnhancedLevel, Info.Grade);
        }
        public IBadSectorDelegate InstallJumpBadSector(IBoardDelegate boardDelegate, IRobotDelegate robotDelegate)
        {
            return new JumpBadSector(robotDelegate.Id+"-"+installNum++, boardDelegate, robotDelegate);
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
            _coordinates.Add(new Coordinate(0,1));
            _commandBuilder.Append(new PointerStatement(robotDelegate, InstallJumpBadSector, _coordinates));
        }

        protected override void AddStatementOnLevel2(IRobotDelegate robotDelegate)
        {
            return;
        }

        protected override void AddStatementOnLevel3(IRobotDelegate robotDelegate)
        {
            _commandBuilder.Clear();
            _coordinates.Add(new Coordinate(-1,1));
            _coordinates.Add(new Coordinate(1,1));
            _commandBuilder.Append(new PointerStatement(robotDelegate, InstallJumpBadSector, _coordinates));
        }
    }
}