using System;
using Ereoz.Abstractions.Messaging;

namespace Ereoz.Messaging
{
    /// <summary>
    /// Мессенджер для реализации событийной модели межкомпонентного взаимодействия.
    /// </summary>
    public class Messenger : IMessenger
    {
        private static class TypedEvent<T>
        {
            public static event Action<T> Event;

            public static void Send(T message) =>
                Event?.Invoke(message);
        }

        /// <inheritdoc/>
        public void Subscribe<T>(Action<T> handler) =>
            TypedEvent<T>.Event += handler;

        /// <inheritdoc/>
        public void Unsubscribe<T>(Action<T> handler) =>
            TypedEvent<T>.Event -= handler;

        /// <inheritdoc/>
        public void Send<T>(T message) =>
            TypedEvent<T>.Send(message);
    }
}
