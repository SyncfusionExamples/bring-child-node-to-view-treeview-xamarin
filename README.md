# How to bring the TreeView child node to view when the root node is collapsed in Xamarin.Forms (SfTreeView)

You can programmatically bring the child node to the view when all the root nodes are collapsed using [BringIntoView](https://help.syncfusion.com/cr/xamarin/Syncfusion.SfTreeView.XForms~Syncfusion.XForms.TreeView.SfTreeView~BringIntoView.html) method by expanding the particular root node in Xamarin.Forms [SfTreeView](https://help.syncfusion.com/xamarin/treeview/overview).

You can also refer the following article.

https://www.syncfusion.com/kb/11802/how-to-bring-the-treeview-child-node-to-view-when-the-root-node-is-collapsed-in-xamarin

**XAML**

Use [SfTreeView.NodePopulationMode](https://help.syncfusion.com/cr/xamarin/Syncfusion.XForms.TreeView.SfTreeView.html#Syncfusion_XForms_TreeView_SfTreeView_NodePopulationMode) property as Instant for SfTreeView.

``` XML
<syncfusion:SfTreeView x:Name="treeView" ChildPropertyName="SubFiles" NodePopulationMode="Instant" ItemTemplateContextType="Node" ItemsSource="{Binding ImageNodeInfo}">
    <syncfusion:SfTreeView.ItemTemplate>
        <DataTemplate>
            <Grid x:Name="grid" RowSpacing="0" >
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="40" />
                    <ColumnDefinition Width="*" />
                </Grid.ColumnDefinitions>
                <Image Source="{Binding Content.ImageIcon}" VerticalOptions="Center" HorizontalOptions="Center" HeightRequest="35" WidthRequest="35"/>
                <Grid Grid.Column="1" RowSpacing="1" Padding="1,0,0,0" VerticalOptions="Center">
                    <Label LineBreakMode="NoWrap" Text="{Binding Content.ItemName}" VerticalTextAlignment="Center"/>
                </Grid>
            </Grid>
        </DataTemplate>
    </syncfusion:SfTreeView.ItemTemplate>
</syncfusion:SfTreeView>
```
**C#**

In the [Button.Clicked](https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.button.clicked) event, bring any child item using [BringIntoView](https://help.syncfusion.com/xamarin/treeview/scrolling#scroll-to-the-collapsed-child-item) method.

``` c#
public class Behavior : Behavior<ContentPage>
{
    SfTreeView TreeView;
    Button Button;

    protected override void OnAttachedTo(ContentPage bindable)
    {
        TreeView = bindable.FindByName<SfTreeView>("treeView");
        Button = bindable.FindByName<Button>("button");
        Button.Clicked += Button_Clicked;
        base.OnAttachedTo(bindable);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var viewModel = (sender as SfTreeView).BindingContext as FileManagerViewModel;
        var item = viewModel.ImageNodeInfo[3].SubFiles[1];
        TreeView.BringIntoView(item, true, true);
        TreeView.SelectedItem = item;
    }
}
```
**Output**

![TreeViewBringToView](https://github.com/SyncfusionExamples/bring-child-node-to-view-treeview-xamarin/blob/master/ScreenShot/TreeViewBringToView.gif)
