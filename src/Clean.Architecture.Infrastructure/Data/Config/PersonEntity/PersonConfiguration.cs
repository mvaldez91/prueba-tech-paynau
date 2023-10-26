using Clean.Architecture.Core.PersonAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.Architecture.Infrastructure.Data.Config.PersonEntity;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
  public void Configure(EntityTypeBuilder<Person> builder)
  {
    builder.Property(p => p.FirstName)
        .HasMaxLength(DataSchemaConstants.DEFAULT_FIRST_NAME_LENGTH)
        .IsRequired();
    
    builder.Property(p => p.LastName)
    .HasMaxLength(DataSchemaConstants.DEFAULT_LAST_NAME_LENGTH)
    .IsRequired();
    
    builder.Property(p => p.PhoneNumber)
    .HasMaxLength(DataSchemaConstants.DEFAULT_PHONE_NUMBER_LENGTH)
    .IsRequired();
    
    builder.Property(p => p.Email)
    .HasMaxLength(DataSchemaConstants.DEFAULT_EMAIL_LENGTH)
    .IsRequired();

    builder.Property(p => p.Email)
    .HasMaxLength(DataSchemaConstants.DEFAULT_EMAIL_LENGTH)
    .IsRequired();

    builder.Property(p => p.Country)
       .HasMaxLength(DataSchemaConstants.DEFAULT_COUNTRY_LENGTH)
       .IsRequired();

    builder.Property(p => p.Street)
    .HasMaxLength(DataSchemaConstants.DEFAULT_STREET_LENGTH)
    .IsRequired();

    builder.Property(p => p.City)
    .HasMaxLength(DataSchemaConstants.DEFAULT_CITY_LENGTH)
    .IsRequired();

    builder.Property(p => p.ZipCode)
    .HasMaxLength(DataSchemaConstants.DEFAULT_ZIP_CODE_LENGTH)
    .IsRequired();

    builder.Property(x => x.Status)
      .HasConversion(
          x => x.Value,
          x => PersonStatus.FromValue(x));
  }
}
