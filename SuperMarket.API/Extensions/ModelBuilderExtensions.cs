using Microsoft.EntityFrameworkCore;

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
                    property.SetColumnName(property.GetColumnName().ToSnakeCae());
                foreach (var key in entity.GetKeys())
                    key.SetName(key.GetName().ToSnakeCae());
                foreach (var foreing in entity.GetForeignKeys())
                    foreing.SetConstraintName(foreing.GetConstraintName().ToSnakeCae());
                foreach (var index in entity.GetIndexes())
                    index.SetName(index.GetName().ToSnakeCase());



            }
        }
    }
}