﻿using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Toolkit.Hosting;

namespace MauiDemo;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureSyncfusionToolkit()
            .ConfigureMauiHandlers(handlers =>
            {
            })
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("LXGWWenKai-Bold.ttf", "LXGWWenKaiBold");
                fonts.AddFont("LXGWWenKai-Light.ttf", "LXGWWenKaiLight");
                fonts.AddFont("LXGWWenKai-Regular.ttf", "LXGWWenKaiRegular");

                fonts.AddFont("LXGWWenKai-Regular.ttf", "OpenSansRegular");
                //fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("LXGWWenKai-Light.ttf", "OpenSansSemibold");
                //fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("LXGWWenKai-Bold.ttf", "SegoeSemibold");
                //fonts.AddFont("SegoeUI-Semibold.ttf", "SegoeSemibold");

                fonts.AddFont("FluentSystemIcons-Regular.ttf", FluentUI.FontFamily);
            });

#if DEBUG
        builder.Logging.AddDebug();
        builder.Services.AddLogging(configure => configure.AddDebug());
#endif

        builder.Services.AddSingleton<ProjectRepository>();
        builder.Services.AddSingleton<TaskRepository>();
        builder.Services.AddSingleton<CategoryRepository>();
        builder.Services.AddSingleton<TagRepository>();
        builder.Services.AddSingleton<SeedDataService>();
        builder.Services.AddSingleton<ModalErrorHandler>();
        builder.Services.AddSingleton<MainPageModel>();
        builder.Services.AddSingleton<ProjectListPageModel>();
        builder.Services.AddSingleton<ManageMetaPageModel>();

        builder.Services.AddTransientWithShellRoute<ProjectDetailPage, ProjectDetailPageModel>("project");
        builder.Services.AddTransientWithShellRoute<TaskDetailPage, TaskDetailPageModel>("task");

        return builder.Build();
    }
}
