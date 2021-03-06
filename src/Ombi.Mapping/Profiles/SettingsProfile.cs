﻿using AutoMapper;
using Ombi.Core.Models.UI;
using Ombi.Settings.Settings.Models.Notifications;

namespace Ombi.Mapping.Profiles
{
    public class SettingsProfile : Profile
    {
        public SettingsProfile()
        {
            CreateMap<EmailNotificationsViewModel, EmailNotificationSettings>().ReverseMap();
            CreateMap<DiscordNotificationsViewModel, DiscordNotificationSettings>().ReverseMap();
            CreateMap<PushbulletNotificationViewModel, PushbulletSettings>().ReverseMap();
            CreateMap<SlackNotificationsViewModel, SlackNotificationSettings>().ReverseMap();
        }
    }
}