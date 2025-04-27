



namespace uintofwork.core.Configrations
{
    public class BookConfigration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.id);

            builder.Property(b => b.title).IsRequired().HasMaxLength(100);
            builder.HasOne(b => b.author).WithMany().HasForeignKey(b => b.authorId);
        }
    }
  
    
}
