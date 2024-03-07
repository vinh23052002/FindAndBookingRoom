using API.Models;
using API.Repositoriest.district;
using API.Repositoriest.image;
using API.Repositoriest.message;
using API.Repositoriest.province;
using API.Repositoriest.review;
using API.Repositoriest.role;
using API.Repositoriest.room;
using API.Repositoriest.room_amenities;
using API.Repositoriest.room_amenties_mapping;
using API.Repositoriest.user;
using API.Repositoriest.ward;
using API.Services.district;
using API.Services.image;
using API.Services.province;
using API.Services.room_amenities;
using API.Services.room_amenities_mapping;
using API.Services.ward;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<RoomContext>(options =>
                           options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Add services and repositories to the container.
            builder.Services.AddScoped<IProvinceRepository, ProvinceRepository>();
            builder.Services.AddScoped<IProvinceService, ProvinceService>();

            builder.Services.AddScoped<IDistrictRepository, DistrictRepository>();
            builder.Services.AddScoped<IDistrictService, DistrictService>();

            builder.Services.AddScoped<IWardRepository, WardRepository>();
            builder.Services.AddScoped<IWardService, WardService>();

            builder.Services.AddScoped<IImageRepository, ImageRepository>();
            builder.Services.AddScoped<IImageService, ImageService>();

            builder.Services.AddScoped<IMessageRepository, MessageRepository>();

            builder.Services.AddScoped<IReviewRepository, ReviewRepository>();

            builder.Services.AddScoped<IRoleRepository, RoleRepository>();

            builder.Services.AddScoped<IRoomRepository, RoomRepository>();

            builder.Services.AddScoped<IRoomAmenitiesRepository, RoomAmenitiesRepository>();
            builder.Services.AddScoped<IRoomAmenitiesService, RoomAmenitiesService>();

            builder.Services.AddScoped<IRoomAmenitiesMappingRepository, RoomAmenitiesMappingRepository>();
            builder.Services.AddScoped<IRoomAmenitiesMappingService, RoomAmenitiesMappingService>();

            builder.Services.AddScoped<IUserRepository, UserRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //app.UseMiddleware<ExceptionMiddleWare>();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
