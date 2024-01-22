﻿using Usuarios.Domain.Core.Messaging;

namespace Usuarios.Domain.Core.Events
{
    public class History : Event
    {
        public History(Event theEvent, string data, string user)
        {
            Id = Guid.NewGuid();
            AggregateId = theEvent.AggregateId;
            MessageType = theEvent.MessageType;
            Data = data;
            User = user;

        }

        // EF Constructor
        protected History() { }

        public Guid Id { get; private set; }

        public string Data { get; private set; }

        public string User { get; private set; }
    }
}
