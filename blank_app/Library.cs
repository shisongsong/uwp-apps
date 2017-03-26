using System;
using Windows.Storage;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

public class Library
{
    public bool rotating = false;
    private Storyboard rotation = new Storyboard();

    public string LoadSetting(string key)
    {
        if (ApplicationData.Current.LocalSettings.Values[key] != null)
        {
            return ApplicationData.Current.LocalSettings.Values[key].ToString();
        }
        else
        {
            return string.Empty;
        }
    }

    /// <summary>
    /// 保存设置
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public void SaveSetting(string key, string value)
    {
        ApplicationData.Current.LocalSettings.Values[key] = value;
    }

    public void Rotate(string axis, ref Image target)
    {
        if (rotating)
        {
            rotation.Stop();
            rotating = false;
        }
        else
        {
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 0.0;
            animation.To = 360.0;
            animation.BeginTime = TimeSpan.FromSeconds(1);
            animation.RepeatBehavior = RepeatBehavior.Forever;
            Storyboard.SetTarget(animation, target);
            // 字符串里的内容十分容易出错，一定要谨慎输入，或者直接复制粘贴，比较保险一点
            Storyboard.SetTargetProperty(animation, "(UIElement.Projection).(PlaneProjection.Rotation" + axis + ")");
            rotation.Children.Clear();
            rotation.Children.Add(animation);
            rotation.Begin();
            rotating = true;
        }
    }
}