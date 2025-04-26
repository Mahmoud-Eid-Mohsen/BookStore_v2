
namespace uintofwork.core.Configrations
{
    class AuthorConfigration:IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a => a.id);
            builder.Property(a => a.name).IsRequired().HasMaxLength(50);
            
        }
    }
  
    
}
