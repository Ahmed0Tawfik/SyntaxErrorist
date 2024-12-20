﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SyntaxErrorist.Shared.Models;

namespace SyntaxErrorist.Infrastructure.Config
{
    public class FriendRequestConfig : IEntityTypeConfiguration<FriendRequest>
    {
        public void Configure(EntityTypeBuilder<FriendRequest> builder)
        {
            builder.HasKey(fr => fr.Id);

            builder.HasOne(fr => fr.SenderProfile)
                .WithMany(up => up.FriendRequestsSent)
                .HasForeignKey(fr => fr.SenderId);

            builder.HasOne(fr => fr.ReceiverProfile)
                .WithMany(up => up.FriendRequestsReceived)
                .HasForeignKey(fr => fr.ReceiverId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
