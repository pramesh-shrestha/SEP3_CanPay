using EFCDataAccess;
using EFCDataAccess.DAOImplementation;
using EFCDataAccess.DAOInterface;
using GrpcService.Services;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddScoped<CanPayDbAccess>();
builder.Services.AddScoped<IUserDao, UserDaoImpl>();
builder.Services.AddScoped<ICardDao, CardDaoImpl>();
builder.Services.AddScoped<ITransactionDao, TransactionDaoImpl>();
builder.Services.AddScoped<INotificationDao, NotificationDaoImpl>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<DebitCardService>();
app.MapGrpcService<UserService>();
app.MapGrpcService<TransactionService>();

app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();