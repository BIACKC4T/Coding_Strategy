#nullable enable


namespace CodingStrategy.Entities.Runtime.Abnormality
{
    using Robot;
    using Player;
    public class Stack : AbstractAbnormality
    {
        public new static readonly string Name = "스택";
        public Stack(IRobotDelegate robotDelegate, int value=0)
        :base(Name, robotDelegate, value)
        {
        }
        public override int Value
        {
            get => _value;
            set
            {
                _value=value;
                _value%=10;
                if(_value < 0)
                {
                    _value=0;
                }
            }
        }
        public override IAbnormality Copy(IRobotDelegate robotDelegate, bool keepStatus = false)
        {
            IAbnormality stack=new Stack(robotDelegate);
            if(keepStatus)
            {
                stack.Value=Value;
            }
            return stack;
        }

        public override void Execute()
        {
            if(_value <= 0)
                return;
        }
    }
}