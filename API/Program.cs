using API.Dtos.Room;
using API.Dtos.User;
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
using API.Services.review;
using API.Services.room;
using API.Services.room_amenities;
using API.Services.room_amenities_mapping;
using API.Services.user;
using API.Services.ward;
using API.Validators.room;
using API.Validators.user;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
            builder.Services.AddScoped<IReviewService, ReviewService>();

            builder.Services.AddScoped<IRoleRepository, RoleRepository>();

            builder.Services.AddScoped<IRoomRepository, RoomRepository>();
            builder.Services.AddScoped<IRoomService, RoomService>();

            builder.Services.AddScoped<IRoomAmenitiesRepository, RoomAmenitiesRepository>();
            builder.Services.AddScoped<IRoomAmenitiesService, RoomAmenitiesService>();

            builder.Services.AddScoped<IRoomAmenitiesMappingRepository, RoomAmenitiesMappingRepository>();
            builder.Services.AddScoped<IRoomAmenitiesMappingService, RoomAmenitiesMappingService>();

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();

            // Add service of validation
            builder.Services.AddScoped<IValidator<RoomAddRequest>, RoomAddValidator>();
            builder.Services.AddScoped<IValidator<RoomUpdateRequest>, RoomUpdateValidator>();
            builder.Services.AddScoped<IValidator<UserUpdateProfileRequest>, UserUpdateProfileValidator>();
            builder.Services.AddScoped<IValidator<UserRequest>, UserAddValidator>();


            //builder.Services.AddControllers(options =>
            //{
            //    options.Filters.Add<ModelStateValidationActionFilter>();
            //})
            //.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<RoomValidator>());
            builder.Services.AddControllers();


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                    };
                });

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://127.0.0.1:5500")
                                      .AllowAnyMethod()
                                      .AllowAnyHeader());
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //app.UseMiddleware<ExceptionMiddleWare>();

            app.UseHttpsRedirection();
            app.UseCors("AllowSpecificOrigin");
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
