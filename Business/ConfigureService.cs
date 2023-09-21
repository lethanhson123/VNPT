namespace Business
{
    public static class ConfigureService
    {
        public static IServiceCollection AddBusinessService(this IServiceCollection services)
        {
            

            services.AddSingleton<HtmlEncoder>(HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.All }));
            return services;
        }
        public static IServiceCollection AddContextService(this IServiceCollection services)
        {
            services.AddDbContext<VNPTContext>(opts =>
            {
            });
            return services;
        }
        public static IServiceCollection AddRepositoryService(this IServiceCollection services)
        {
            

            return services;
        }
    }
}
