# Build a NewsFeed demo application using .NET MAUI ListView (SfListView).

This demo explains about how to create the NewsFeed demo application using .NET MAUI ListView (SfListView).


## Sample

```xaml
<ContentPage.Resources>
    <local:LikeIconConverter x:Key="iconConverter" />
    <Style TargetType="listView:ListViewItem">
        <Setter Property="VisualStateManager.VisualStateGroups">
            <VisualStateGroupList>
                <VisualStateGroup>
                    <VisualState x:Name="Normal">
                        <VisualState.Setters>
                            <Setter Property="Background" Value="Transparent" />
                        </VisualState.Setters>
                    </VisualState>
                    <VisualState x:Name="PointerOver">
                        <VisualState.Setters>
                            <Setter Property="Background" Value="Transparent" />
                        </VisualState.Setters>
                    </VisualState>
                </VisualStateGroup>
            </VisualStateGroupList>
        </Setter>
    </Style>
</ContentPage.Resources>

<Frame
    Padding="0"
    Background="Transparent"
    BorderColor="{OnPlatform Default=Transparent,
                                WinUI=#C2C2C2,
                                MacCatalyst=#C2C2C2}"
    CornerRadius="10"
    HasShadow="False"
    HorizontalOptions="{OnPlatform WinUI=Center,
                                    MacCatalyst=Center,
                                    Default=Fill}"
    MaximumWidthRequest="{OnPlatform WinUI=380,
                                        MacCatalyst=400}"
    VerticalOptions="{OnPlatform MacCatalyst=Center}">
    <Frame.Margin>
        <OnPlatform x:TypeArguments="thickness:Thickness">
            <On Platform="MacCatalyst" Value="20" />
            <On Platform="WinUI" Value="20" />
        </OnPlatform>
    </Frame.Margin>
    <Grid RowDefinitions="*">
        <listView:SfListView
            x:Name="listView"
            AutoFitMode="DynamicHeight"
            ItemsSource="{Binding News}"
            SelectionMode="None">
            <listView:SfListView.ItemTemplate>
                <DataTemplate x:DataType="local:Model">
                    <Border Margin="8,8,8,4" Stroke="#CAC4D0">
                        <Border.StrokeShape>
                            <RoundRectangle CornerRadius="12" />
                        </Border.StrokeShape>
                        <Grid Margin="8" RowDefinitions="Auto,Auto,Auto,Auto,Auto">
                            <Frame
                                Grid.Row="0"
                                Padding="0"
                                BorderColor="Transparent"
                                CornerRadius="{OnPlatform Android=4,
                                                            Default=5,
                                                            MacCatalyst=6}"
                                HasShadow="False"
                                HeightRequest="148"
                                IsClippedToBounds="True">
                                <ffimageloading:CachedImage
                                    Aspect="Fill"
                                    HeightRequest="148"
                                    Source="{Binding ImageName}" />
                            </Frame>
                            <Label
                                Grid.Row="1"
                                Margin="0,10,0,5"
                                FontAttributes="Bold"
                                FontSize="14"
                                Text="{Binding Title}" />
                            <Grid
                                Grid.Row="2"
                                Margin="0,5,0,5"
                                ColumnDefinitions="Auto,14,*">
                                <Label FontSize="11" Text="{Binding NewsDate}" />
                                <Label
                                    Grid.Column="1"
                                    FontFamily="ListViewFont"
                                    FontSize="14"
                                    HeightRequest="14"
                                    Text="&#xe700;"
                                    TextColor="#49454F"
                                    VerticalOptions="Center" />
                                <Label
                                    Grid.Column="2"
                                    Margin="5,0,0,0"
                                    FontSize="11"
                                    Text="{Binding Views}" />
                            </Grid>
                            <Label
                                Grid.Row="3"
                                Margin="0,5,0,0"
                                FontSize="14"
                                Text="{Binding Description}" />
                            <Grid
                                Grid.Row="4"
                                Margin="0,10,0,0"
                                ColumnDefinitions="*,*,80"
                                RowDefinitions="24">
                                <Frame
                                    Grid.Column="0"
                                    Padding="0"
                                    BorderColor="Transparent"
                                    CornerRadius="20"
                                    HasShadow="False"
                                    HeightRequest="24"
                                    HorizontalOptions="Start"
                                    IsClippedToBounds="True"
                                    WidthRequest="72">
                                    <Frame.GestureRecognizers>
                                        <TapGestureRecognizer Command="{Binding Path=BindingContext.LikeActionCommand, Source={x:Reference listView}}" CommandParameter="{Binding .}" />
                                    </Frame.GestureRecognizers>
                                    <Label
                                        Background="#EEE8F4"
                                        FontFamily="ListViewFont"
                                        FontSize="13"
                                        HeightRequest="24"
                                        HorizontalTextAlignment="Center"
                                        Text="{Binding IsLiked, Converter={StaticResource iconConverter}}"
                                        TextColor="#49454F"
                                        VerticalTextAlignment="Center"
                                        WidthRequest="72" />
                                </Frame>
                                <Frame
                                    Grid.Column="1"
                                    Padding="0"
                                    BorderColor="Transparent"
                                    CornerRadius="20"
                                    HasShadow="False"
                                    HeightRequest="24"
                                    HorizontalOptions="End"
                                    IsClippedToBounds="True"
                                    WidthRequest="72">
                                    <Label
                                        Background="#EEE8F4"
                                        FontFamily="ListViewFont"
                                        FontSize="13"
                                        HeightRequest="24"
                                        HorizontalTextAlignment="Center"
                                        Text="&#xe702;"
                                        TextColor="#49454F"
                                        VerticalTextAlignment="Center"
                                        WidthRequest="72" />
                                </Frame>
                                <Frame
                                    Grid.Column="2"
                                    Padding="0"
                                    BorderColor="Transparent"
                                    CornerRadius="20"
                                    HasShadow="False"
                                    HeightRequest="24"
                                    HorizontalOptions="End"
                                    IsClippedToBounds="True"
                                    WidthRequest="72">
                                    <Label
                                        Background="#EEE8F4"
                                        FontFamily="ListViewFont"
                                        FontSize="13"
                                        HeightRequest="24"
                                        HorizontalTextAlignment="Center"
                                        Text="&#xe703;"
                                        TextColor="#49454F"
                                        VerticalTextAlignment="Center"
                                        WidthRequest="72" />
                                </Frame>
                            </Grid>
                        </Grid>
                    </Border>
                </DataTemplate>
            </listView:SfListView.ItemTemplate>
        </listView:SfListView>
    </Grid>
</Frame>
```

```c#
public class LikeIconConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value == null)
            return "\ue701";
        else if ((bool)value)
            return "\ue704";
        else
            return "\ue701";
    }
}

public class LikeIconColorConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is bool isLiked)
        {
            return isLiked ? "LikeIcon.png" : "UnlikeIcon.png";
        }

        return "UnlikeIcon.png";
    }
}
```

## Requirements to run the demo

* [Visual Studio 2017](https://visualstudio.microsoft.com/downloads/) or [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/)
* Xamarin add-ons for Visual Studio (available via the Visual Studio installer).

## Troubleshooting

### Path too long exception

If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.
