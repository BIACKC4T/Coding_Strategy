﻿using CodingStrategy.Entities;

namespace CodingStrategy.Factory
{
    public class PlayerDelegateCreateStrategy : IPlayerDelegateCreateStrategy
    {
        public PlayerDelegateCreateStrategy(string id)
        {
            Id = id;
        }

        public string Id { get; }
        public IAlgorithm Algorithm => new AlgorithmImpl(3);
        public int HealthPoint => 5;
        public int Level => 1;
        public int Exp => 0;
        public int Currency => 0;
    }
}
