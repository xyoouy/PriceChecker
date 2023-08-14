using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.Configurations;

public class SubscriptionConfiguration :  IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.HasKey(sub => sub.Id);
        builder.HasIndex(sub => sub.Id);

        builder.Property(sub => sub.Id)
            .IsRequired();
        builder.Property(sub => sub.Url)
            .IsRequired();
        builder.Property(sub => sub.Email)
            .IsRequired();
    }
}