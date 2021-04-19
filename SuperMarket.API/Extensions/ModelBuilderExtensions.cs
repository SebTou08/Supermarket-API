using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SuperMarket.API.Domain.Models;

namespace SuperMarket.API.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void ApplySnakeCaseNamingConvention(this ModelBuilder builder)
        {
            foreach (var entity in builder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.GetTableName().ToSnakeCae());
                foreach (var property in entity.GetProperties())
                {
                    StoreObjectIdentifier tableIdentifier;
                    tableIdentifier = StoreObjectIdentifier.Table(entity.GetTableName(), null);
                    property.SetColumnName(property.GetColumnName(tableIdentifier).ToSnakeCae());
                }

                foreach (var key in entity.GetKeys())
                    key.SetName(key.GetName().ToSnakeCae());
                foreach (var foreing in entity.GetForeignKeys())
                    foreing.SetConstraintName(foreing.GetConstraintName().ToSnakeCae());
                foreach (var index in entity.GetIndexes())
                    index.SetDatabaseName(index.GetDatabaseName().ToSnakeCae());



            }
        }
    }
}