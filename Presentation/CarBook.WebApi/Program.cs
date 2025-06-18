using CarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers;
using CarBook.Application.Features.CQRS.Handlers.CategoryHandlers;
using CarBook.Application.Features.CQRS.Handlers.ContactHandlers;
using CarBook.Application.Features.RepositoryPattern;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Application.Interfaces.CarDescriptionInterfaces;
using CarBook.Application.Interfaces.CarFeatureInterfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Application.Interfaces.RentACarInterfaces;
using CarBook.Application.Interfaces.ReviewInterfaces;
using CarBook.Application.Interfaces.StatisticsInterfaces;
using CarBook.Application.Interfaces.TagCloudInterfaces;
using CarBook.Application.Services;
using CarBook.Persistance.Context;
using CarBook.Persistance.Repositories;
using CarBook.Persistance.Repositories.BlogRepositories;
using CarBook.Persistance.Repositories.CarDescriptionRepositories;
using CarBook.Persistance.Repositories.CarFeatureRepositories;
using CarBook.Persistance.Repositories.CarPricingRepositories;
using CarBook.Persistance.Repositories.CarRepositories;
using CarBook.Persistance.Repositories.CommentRepositories;
using CarBook.Persistance.Repositories.RentACarRepositories;
using CarBook.Persistance.Repositories.ReviewRepositories;
using CarBook.Persistance.Repositories.StatisticsRepositories;
using CarBook.Persistance.Repositories.TagCloudRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Context
builder.Services.AddScoped<CarBookContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(ICarRepository), typeof(CarRepository));
builder.Services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
builder.Services.AddScoped(typeof(ICarPricingRepository), typeof(CarPricingRepository));
builder.Services.AddScoped(typeof(ITagCloudRepository), typeof(TagCloudRepository));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(CommentRepository<>));
builder.Services.AddScoped(typeof(IStatisticsRepository), typeof(StatisticsRepository));
builder.Services.AddScoped(typeof(IRentACarRepository), typeof(RentACarRepository));
builder.Services.AddScoped(typeof(ICarFeatureRepository), typeof(CarFeatureRepository));
builder.Services.AddScoped(typeof(ICarDescriptionRepository), typeof(CarDescriptionRepository));
builder.Services.AddScoped(typeof(IReviewRepository), typeof(ReviewRepository));

//About
builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();
builder.Services.AddScoped<DeleteAboutCommandHandler>();

//Banner
builder.Services.AddScoped<GetBannerQueryHandler>();
builder.Services.AddScoped<GetBannerByIdQueryHandler>();
builder.Services.AddScoped<CreateBannerCommandHandler>();
builder.Services.AddScoped<UpdateBannerCommandHandler>();
builder.Services.AddScoped<DeleteBannerCommandHandler>();

//Brand
builder.Services.AddScoped<GetBrandQueryHandler>();
builder.Services.AddScoped<GetBrandByIdQueryHandler>();
builder.Services.AddScoped<CreateBrandCommandHandler>();
builder.Services.AddScoped<UpdateBrandCommandHandler>();
builder.Services.AddScoped<DeleteBrandCommandHandler>();

//Car
builder.Services.AddScoped<GetCarQueryHandler>();
builder.Services.AddScoped<GetCarByIdQueryHandler>();
builder.Services.AddScoped<CreateCarCommandHandler>();
builder.Services.AddScoped<UpdateCarCommandHandler>();
builder.Services.AddScoped<DeleteCarCommandHandler>();
builder.Services.AddScoped<GetCarWithBrandQueryHandler>();
builder.Services.AddScoped<GetLast5CarsWithBrandQueryHandler>();
builder.Services.AddScoped<GetCarWithBrandByIdQueryHandler>();

//Category
builder.Services.AddScoped<GetCategoryQueryHandler>();
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();
builder.Services.AddScoped<DeleteCategoryCommandHandler>();

//Contact
builder.Services.AddScoped<GetContactQueryHandler>();
builder.Services.AddScoped<GetContactByIdQueryHandler>();
builder.Services.AddScoped<CreateContactCommandHandler>();
builder.Services.AddScoped<DeleteContactCommandHandler>();
builder.Services.AddScoped<UpdateContactCommandHandler>();

//MediatR Services
builder.Services.AddApplicationService(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
