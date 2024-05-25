#nullable enable


using CodingStrategy.Entities;
using CodingStrategy.Entities.Runtime.CommandImpl;
using CodingStrategy.Network;

namespace CodingStrategy
{
    public class GameInitializer
    {
        public const int DefaultGrade1CommandStockCount = 128;
        public const int DefaultGrade2CommandStockCount = 108;
        public const int DefaultGrade3CommandStockCount = 72;
        public const int DefaultGrade4CommandStockCount = 48;
        public const int DefaultGrade5CommandStockCount = 36;


        public static void AddCommand(ICommand command, int count)
        {
            string id = command.Id;

            PhotonPlayerCommandCache.AttachCommand(command);
            PhotonPlayerCommandNetworkDelegate.AttachCommandIdCount(id, count);
        }

        public static void Initialize()
        {
            AddCommand(new MoveForwardCommand(), DefaultGrade1CommandStockCount);
            AddCommand(new MoveLeftCommand(), DefaultGrade1CommandStockCount);
            AddCommand(new MoveRightCommand(), DefaultGrade1CommandStockCount);
            AddCommand(new RotateLeftCommand(), DefaultGrade1CommandStockCount);
            AddCommand(new RotateRightCommand(), DefaultGrade1CommandStockCount);
            AddCommand(new MoveLeftForwardCommand(), DefaultGrade2CommandStockCount);
            AddCommand(new MoveRightForwardCommand(), DefaultGrade2CommandStockCount);
            AddCommand(new AddStackCommand(), DefaultGrade2CommandStockCount);
            AddCommand(new AddWormAllEnemyCommand(), DefaultGrade2CommandStockCount);
            AddCommand(new InstallMalwareCommand(), DefaultGrade3CommandStockCount);
            AddCommand(new CoinMiningCommand(), DefaultGrade4CommandStockCount);
            AddCommand(new BotnetsCommand(), DefaultGrade5CommandStockCount);
        }
    }
}