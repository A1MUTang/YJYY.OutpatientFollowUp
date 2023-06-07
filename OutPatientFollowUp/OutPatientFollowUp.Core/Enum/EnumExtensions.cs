using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace OutPatientFollowUp.Core;

public static class EnumExtensions
{
    public static string GetName(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        var attribute = field.GetCustomAttribute<DisplayAttribute>();
        return attribute != null ? attribute.Name : value.ToString();
    }

    public static string GetDescription(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        var attribute = field.GetCustomAttribute<DisplayAttribute>();
        return attribute != null ? attribute.Description : value.ToString();
    }
}