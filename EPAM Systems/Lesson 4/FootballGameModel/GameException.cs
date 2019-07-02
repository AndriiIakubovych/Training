using System;

namespace FootballGameModel
{
    class GameException : Exception
    {
        public GameException() : base() { }
        public GameException(string message) : base(message) { }
        public GameException(string message, Exception innerException) : base(message, innerException) { }
        public GameException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}