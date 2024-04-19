#nullable enable


namespace CodingStrategy.Runtime
{
    using CodingStrategy.Entities.Board;

    /// <summary>
    /// IStatement 실행 후 IBoardDelegate 상태가 유효한지 검사합니다.
    /// </summary>
    public interface IExecutionValidator
    {
        /// <summary>
        /// IBoardDelegate 상태가 유효한지 검사합니다.
        /// </summary>
        /// <param name="boardDelegate">상태가 유효한지 검사할 IBoardDelegate 인스턴스입니다.</param>
        /// <returns>상태가 유효하면 true, 유효하지 않으면 false를 반환합니다.</returns>
        public bool IsValid(IBoardDelegate boardDelegate);
    }
}
