﻿using MessageQueue.Domain.Entities;
using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Threading.Tasks;
using System.Transactions;

namespace MessageQueue.Server2Event
{
    public class ServerHandler : IHandleMessages<MessageEventEntity>
    {
        private readonly ILog nsbLog = LogManager.GetLogger<ServerHandler>();

        public Task Handle(MessageEventEntity message, IMessageHandlerContext context)
        {
            try
            {
                nsbLog.Info($"Message {message.Id} received at {typeof(ServerHandler)}");

                // TransactionScope may cause issues
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    // Implement logic and log
                }

                return Task.CompletedTask;
            }
            catch (Exception e)
            {
                return Task.FromException(e);
            }
        }
    }
}
