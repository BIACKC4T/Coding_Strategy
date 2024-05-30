#nullable enable


using System.Collections.Generic;
using CodingStrategy.Entities.Runtime;

namespace CodingStrategy.Entities.BadSector
{
    using Board;
    using Runtime.Statement;
    using Robot;

    public class PropellerBadSector : AbstractBadSectorDelegate
    {
        public PropellerBadSector(string id, IBoardDelegate boardDelegate, IRobotDelegate installer) : base(id, boardDelegate, installer)
        {
        }

        public override string Explanation => "발동시 바라보는 방향의 반대 방향으로 1칸 이동합니다.";

        public override IList<IStatement> Execute(IRobotDelegate target)
        {
            _commandBuilder.Clear();
            _commandBuilder.Append(new MoveCoordinateStatement(target, new Coordinate(0,-1)));
            return _commandBuilder.Build();
        }
    }
}